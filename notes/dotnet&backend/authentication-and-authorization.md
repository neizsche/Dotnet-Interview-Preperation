# Authentication and Authorization - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Authentication and authorization in .NET are not just middleware settings; they are architecture decisions that define trust boundaries, user identity flow, and access risk. Production-grade systems combine robust identity protocols (JWT/cookies/OAuth2/OIDC), policy-based authorization, and secure transport controls (HTTPS/TLS), with operational safeguards like auditing, revocation, and compliance controls. Senior engineers optimize for both security correctness and scalability across web, API, microservice, and serverless environments.

## 2. Structured Study Material

### Core Security Flow: Authentication vs Authorization

| Aspect | Authentication | Authorization | Why It Matters |
|---|---|---|---|
| Core question | Who are you? | What are you allowed to do? | Prevents identity and permission logic confusion |
| Input | Credentials/tokens/identity proof | Roles, claims, policies, resource context | Ensures access is evaluated after identity is trusted |
| Outcome | Principal established | Access allowed/denied | Correct pipeline sequencing is critical |
| Dependency | Happens first | Depends on authentication | Avoids false access decisions |

How they work together:
1. User/service presents identity proof.
2. System authenticates and builds principal/claims.
3. Authorization evaluates roles/claims/policies/resource context.
4. Request is allowed or rejected (`401`/`403` pathways).

### Authentication Methods in .NET

| Method | Best Fit | Strengths | Trade-offs |
|---|---|---|---|
| Forms Authentication | Traditional web apps | Full UI/session control | Session scaling complexity |
| Windows Authentication | Intranet/domain environments | Seamless enterprise SSO | Limited internet/public use |
| Token/JWT Authentication | APIs, SPAs, mobile, distributed systems | Stateless and scalable | Token lifecycle/revocation complexity |
| OAuth 2.0 | Delegated access and API auth | Standardized authorization framework | Not identity by itself |
| OpenID Connect | SSO and identity federation | Identity layer over OAuth2 (`id_token`) | IdP integration complexity |

### JWT and Bearer Authentication

JWT essentials:
- RFC 7519 token format: `header.payload.signature`
- Header: algorithm + type
- Payload: claims
- Signature: integrity verification

Example JWT parts:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```

```json
{
  "sub": "1234567890",
  "name": "John Doe",
  "iat": 1516239022,
  "exp": 1516242622
}
```

Bearer usage:

```http
Authorization: Bearer <token>
```

JWT signing algorithms:

| Type | Algorithms | Characteristics | When to Prefer |
|---|---|---|---|
| Symmetric | HS256/HS384/HS512 | Same key signs and verifies | Simpler single trust domain |
| Asymmetric | RS256/RS384/RS512 | Private key signs, public key verifies | Distributed/multi-service verification |

JWT service example (generate + validate):

```csharp
public class JwtService
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtService(IConfiguration config)
    {
        _secretKey = config["Jwt:Secret"];
        _issuer = config["Jwt:Issuer"];
        _audience = config["Jwt:Audience"];
    }

    public string GenerateToken(User user, IList<string> roles)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("custom_claim", "custom_value")
        }.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _issuer,
            ValidateAudience = true,
            ValidAudience = _audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            return tokenHandler.ValidateToken(token, validationParameters, out _);
        }
        catch (SecurityTokenException)
        {
            return null;
        }
    }
}
```

Critical JWT security controls:
1. Secret/key management in secure storage.
2. Strict signature validation.
3. Issuer/audience/lifetime checks.
4. Reasonable token expiry.
5. Secure token storage and transport.
6. Algorithm validation to prevent downgrade/substitution attacks.

### Cookie Authentication and Claims Transformation

Cookie flow:
1. User authenticates.
2. Server issues auth cookie.
3. Cookie travels with subsequent requests.
4. Server validates and reconstructs principal.

Claims transformation example:

```csharp
public class ClaimsTransformationService : IClaimsTransformation
{
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = principal.Identities.First();

        if (identity.HasClaim(c => c.Type == ClaimTypes.Name))
        {
            var nameClaim = identity.FindFirst(ClaimTypes.Name);
            var transformedClaims = await GetAdditionalClaims(nameClaim.Value);
            identity.AddClaims(transformedClaims);
        }

        return principal;
    }

    private Task<IEnumerable<Claim>> GetAdditionalClaims(string username)
    {
        return Task.FromResult<IEnumerable<Claim>>(new[]
        {
            new Claim("custom_permission", "special_access"),
            new Claim("membership_level", "premium")
        });
    }
}
```

Cookie configuration hardening:

```csharp
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AuthCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = async context =>
            {
                var userId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!await IsUserActive(userId))
                {
                    context.RejectPrincipal();
                    await context.HttpContext.SignOutAsync();
                }
            }
        };
    });

services.AddTransient<IClaimsTransformation, ClaimsTransformationService>();
```

### JWT vs Cookie Authentication

| Aspect | JWT | Cookie | Trade-offs | When to Use |
|---|---|---|---|---|
| State model | Stateless | Session/cookie oriented | Stateless scales easier; revocation harder | JWT for APIs/microservices/mobile |
| Browser security pressure | XSS/token theft risk if poorly stored | CSRF risk if anti-forgery not configured | Different attack surfaces, both need hardening | Cookies for server-rendered web apps |
| Mobile/native support | Strong | Limited | Token model fits non-browser clients better | Mobile + public API ecosystems |
| Revocation ease | Harder per-token revocation | Easier session invalidation | Operational model differs | Cookies for simple centralized sessions |

When to choose:
- JWT: APIs, microservices, SPAs/mobile, cross-domain auth.
- Cookies: traditional server-rendered apps and straightforward session workflows.

### ASP.NET Core Identity and Custom Stores

Identity architecture:
- `UserManager<TUser>` for user lifecycle.
- `SignInManager<TUser>` for sign-in operations.
- `RoleManager<TRole>` for role lifecycle.
- `IUserStore<TUser>`/`IRoleStore<TRole>` as persistence abstraction.

Custom user/role stores example:

```csharp
public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
{
    private readonly CustomDbContext _context;

    public CustomUserStore(CustomDbContext context) => _context = context;

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        user.Id = Guid.NewGuid().ToString();
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
        => await _context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);

    public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken = default)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        => Task.FromResult(user.PasswordHash);

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        => Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));

    public void Dispose() => _context?.Dispose();
}

public class CustomRoleStore : IRoleStore<ApplicationRole>
{
    private readonly CustomDbContext _context;

    public CustomRoleStore(CustomDbContext context) => _context = context;

    public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken = default)
    {
        role.Id = Guid.NewGuid().ToString();
        _context.Roles.Add(role);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<ApplicationRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default)
        => await _context.Roles.FirstOrDefaultAsync(r => r.NormalizedName == normalizedRoleName, cancellationToken);

    public void Dispose() => _context?.Dispose();
}
```

Identity options configuration:

```csharp
services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
})
.AddUserStore<CustomUserStore>()
.AddRoleStore<CustomRoleStore>()
.AddDefaultTokenProviders();
```

### Role-Based, Policy-Based, Claims-Based, and Resource-Based Authorization

#### Role-based authorization

```csharp
[Authorize(Roles = "Admin,Manager")]
public class AdminController : Controller
{
    [Authorize(Roles = "Admin")]
    public IActionResult SuperAdminAction() => View();
}
```

#### Policy-based authorization with custom requirements

```csharp
public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; }
    public MinimumAgeRequirement(int minimumAge) => MinimumAge = minimumAge;
}

public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var dob = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
        if (dob != null)
        {
            var age = DateTime.Today.Year - Convert.ToDateTime(dob.Value).Year;
            if (age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}
```

Complex policy and assertion:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("Over18", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(18)));

    options.AddPolicy("FinanceManager", policy =>
    {
        policy.RequireRole("Manager");
        policy.RequireClaim("Department", "Finance");
    });

    options.AddPolicy("CustomPolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim("SpecialAccess", "true") &&
            DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 17));
});

services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
```

#### Claims-based authorization

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("MinimumAgePolicy", policy =>
        policy.RequireClaim(ClaimTypes.DateOfBirth)
              .RequireAssertion(context =>
              {
                  var dob = context.User.FindFirstValue(ClaimTypes.DateOfBirth);
                  return DateTime.Today.Year - Convert.ToDateTime(dob).Year >= 18;
              }));
});
```

#### Resource-based authorization

```csharp
public class SameAuthorRequirement : IAuthorizationRequirement { }

public class DocumentAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Document>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameAuthorRequirement requirement, Document resource)
    {
        if (context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value == resource.AuthorId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

[Authorize]
public class DocumentController : Controller
{
    private readonly IAuthorizationService _authorizationService;

    public DocumentController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<IActionResult> Edit(int id)
    {
        var document = await _documentRepository.GetByIdAsync(id);
        var authResult = await _authorizationService.AuthorizeAsync(User, document, "SameAuthor");

        if (!authResult.Succeeded)
            return Forbid();

        return View(document);
    }
}
```

Role vs Policy comparison:

| Aspect | Role-based | Policy-based | Trade-offs | When to Use |
|---|---|---|---|---|
| Complexity | Simpler | More flexible | Role-only can become coarse | Roles for simple hierarchies |
| Granularity | Coarse | Fine-grained | Policies require more design effort | Policies for business-rule-rich domains |
| Resource/context awareness | Limited | Strong with requirements/handlers | Policy model is more maintainable at scale | Multi-tenant/resource-sensitive systems |

### External Providers: OAuth 2.0 and OpenID Connect

OAuth2 flow (high level):
`Client -> Authorization Server -> Authorization Code -> Access Token`

OIDC adds identity semantics (`id_token`) on top of OAuth2.

OAuth2 vs OIDC:

| Aspect | OAuth 2.0 | OpenID Connect |
|---|---|---|
| Primary purpose | Authorization delegation | Authentication + identity |
| Token focus | Access token | ID token + access token |
| User identity claims | Not standardized | Standardized claims via OIDC spec |

Implementation example:

```csharp
services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect("Google", options =>
{
    options.Authority = "https://accounts.google.com";
    options.ClientId = Configuration["Google:ClientId"];
    options.ClientSecret = Configuration["Google:ClientSecret"];
    options.CallbackPath = "/signin-google";
    options.SaveTokens = true;
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.Events = new OpenIdConnectEvents
    {
        OnTokenValidated = context =>
        {
            var identity = (ClaimsIdentity)context.Principal.Identity!;
            identity.AddClaim(new Claim("LoginProvider", "Google"));
            return Task.CompletedTask;
        },
        OnRedirectToIdentityProvider = context =>
        {
            context.ProtocolMessage.SetParameter("hd", "mycompany.com");
            return Task.CompletedTask;
        }
    };
})
.AddOAuth("GitHub", options =>
{
    options.ClientId = Configuration["GitHub:ClientId"];
    options.ClientSecret = Configuration["GitHub:ClientSecret"];
    options.CallbackPath = "/signin-github";

    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
    options.UserInformationEndpoint = "https://api.github.com/user";

    options.Scope.Add("user:email");
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();

            var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            context.RunClaimActions(user.RootElement);
        }
    };
});
```

### Advanced Authentication Configuration Patterns

JWT events and multi-scheme selection:

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://demo.identityserver.io";
        options.Audience = "api";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                var identity = (ClaimsIdentity)context.Principal!.Identity!;
                identity.AddClaim(new Claim("custom_claim", "value"));
                return Task.CompletedTask;
            }
        };
    });

services.AddAuthentication(options =>
{
    options.DefaultScheme = "MultiScheme";
    options.DefaultChallengeScheme = "MultiScheme";
})
.AddPolicyScheme("MultiScheme", "MultiScheme", options =>
{
    options.ForwardDefaultSelector = context =>
    {
        if (context.Request.Headers.ContainsKey("Authorization") &&
            context.Request.Headers["Authorization"].ToString().StartsWith("Bearer "))
        {
            return JwtBearerDefaults.AuthenticationScheme;
        }

        return CookieAuthenticationDefaults.AuthenticationScheme;
    };
})
.AddCookie()
.AddJwtBearer();
```

### API Security and Token Lifecycle

Secure API baseline:
1. Configure JWT auth middleware.
2. Validate token integrity and metadata.
3. Protect endpoints with `[Authorize]` + policies.
4. Handle `401`/`403` paths consistently.
5. Add refresh/revocation strategies.

Secure refresh token pattern (from source concept):

```csharp
public class TokenService
{
    public async Task<AuthResult> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var storedRefreshToken = await _refreshTokenStore.GetAsync(refreshToken);

        if (storedRefreshToken == null || storedRefreshToken.IsRevoked || storedRefreshToken.Expires < DateTime.UtcNow)
            throw new SecurityTokenException("Invalid refresh token");

        var principal = ValidateToken(accessToken, validateLifetime: false);

        var newAccessToken = GenerateToken(principal.Claims);
        var newRefreshToken = GenerateRefreshToken();

        await _refreshTokenStore.RevokeAsync(refreshToken);
        await _refreshTokenStore.StoreAsync(newRefreshToken, principal.FindFirstValue(ClaimTypes.NameIdentifier));

        return new AuthResult
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresIn = 3600
        };
    }
}
```

Replay risk mitigations:
- Short access-token TTL.
- `jti` and replay detection/blacklisting.
- Audience/issuer validation.
- TLS everywhere.

### Microservices and Serverless Authorization Strategies

Microservices authz strategies from source:
- Centralized authorization/identity provider.
- Claims propagation via JWT.
- API gateway validation and policy enforcement.
- Service-to-service auth (client credentials, mTLS).
- Dynamic/attribute-based access rules.
- Cross-service token propagation.
- Auditing and monitoring of authorization decisions.

Cross-service token propagation checklist:
1. Validate incoming token at edge/gateway.
2. Forward token securely to downstream services.
3. Re-validate claims at each service boundary.
4. Use mTLS for service transport trust.
5. Audit token usage, failures, and propagation paths.

Scenario code (microservices):

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://auth-service";
        options.Audience = "api-gateway";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true
        };
    });

services.AddHttpClient<ISomeService, SomeService>()
    .AddHttpMessageHandler(() => new ClientCredentialsHandler(
        "https://auth-service/token",
        "client-id",
        "client-secret"));
```

Serverless custom authorizer sample:

```csharp
public class CustomAuthorizer
{
    public async Task<APIGatewayCustomAuthorizerResponse> AuthorizeAsync(APIGatewayCustomAuthorizerRequest request)
    {
        var token = request.AuthorizationToken?.Replace("Bearer ", "");
        var user = await ValidateJwtTokenAsync(token);

        return new APIGatewayCustomAuthorizerResponse
        {
            PrincipalID = user.Id,
            PolicyDocument = new APIGatewayCustomAuthorizerPolicy
            {
                Statement = new List<APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement>
                {
                    new APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement
                    {
                        Effect = "Allow",
                        Resource = new HashSet<string> { request.MethodArn },
                        Action = new HashSet<string> { "execute-api:Invoke" }
                    }
                }
            },
            Context = new Dictionary<string, object>
            {
                ["user"] = JsonSerializer.Serialize(user)
            }
        };
    }
}
```

### Transport Security: TLS/HTTPS Enforcement

Transport hardening steps:
1. Obtain and install valid TLS certificate.
2. Bind certificate to HTTPS endpoint.
3. Redirect HTTP -> HTTPS.
4. Enforce strong TLS versions/ciphers.
5. Validate and monitor certificate lifecycle.

ASP.NET Core HTTPS enforcement:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseHttpsRedirection();
    // other middleware
}
```

TLS protocol enforcement concept:

```csharp
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
```

Add security headers (source recommendation):
- `Strict-Transport-Security` (HSTS)
- `Content-Security-Policy`
- `X-Content-Type-Options`

### Compliance: GDPR and HIPAA Implications

GDPR implications:
- Privacy by design/default.
- Consent management.
- Data subject rights support (access/erase/portability).
- Breach detection and notification.
- Controlled cross-border transfer safeguards.

HIPAA implications:
- PHI protection controls.
- Strong authentication/access controls.
- Audit trails for PHI access.
- BAAs with service providers.
- Ongoing security risk assessments.

Shared compliance security controls:
- Encryption at rest/in transit.
- Fine-grained access policies.
- Auditable security events.
- Security training.
- Periodic audits and remediation.

### Best Practices for Authorization Design and Operations

1. Enforce least privilege.
2. Prefer policy-based authorization for complex domains.
3. Use claims for contextual access decisions.
4. Centralize identity/authorization where practical.
5. Keep transport secure (HTTPS/TLS).
6. Audit and monitor authorization outcomes.
7. Review and patch security dependencies regularly.
8. Document policies and train teams.

## 3. Senior Perspective (The "Why")

- Authentication and authorization decisions define blast radius in incidents; they are core architecture, not add-ons.
- Role-only models are fast to start but degrade at scale; policy/claims/resource models sustain complex business rules better.
- JWT/cookie choice is mostly a trust-boundary and client-type decision, not a trend decision.
- Security posture depends on lifecycle controls (key rotation, token refresh/revocation, cert management), not just initial setup.
- Distributed systems force explicit choices about token propagation, gateway enforcement, and service identity.
- Compliance frameworks (GDPR/HIPAA) translate directly into engineering requirements around data handling, auditability, and incident response.

## 4. Interview Gotchas & Confusion Points

1. Treating OAuth2 as authentication.
Why candidates fail: OAuth2 alone is authorization; identity semantics require OIDC.
Strong answer: OAuth2 delegates access; OIDC authenticates users and returns identity claims.

2. Skipping JWT signature validation.
Why candidates fail: attacker can tamper claims.
Strong answer: always validate signature, issuer, audience, and expiry.

3. Storing sensitive data in JWT payload.
Why candidates fail: payload is base64url encoded, not encrypted.
Strong answer: keep payload minimal; use JWE/encrypted channels for sensitive data.

4. Wrong middleware order (`UseAuthorization` before `UseAuthentication`).
Why candidates fail: authorization runs without authenticated principal.
Strong answer: authenticate first, authorize second.

5. Cookie auth without CSRF mitigation.
Why candidates fail: assume cookie settings alone are enough.
Strong answer: configure SameSite/anti-forgery and secure cookie flags.

6. Over-reliance on coarse RBAC.
Why candidates fail: role explosion and brittle permission model.
Strong answer: combine RBAC with policies and claims.

7. No resource-based checks for tenant-owned data.
Why candidates fail: users can access others' resources.
Strong answer: use `IAuthorizationService` with resource requirements.

8. Missing token revocation strategy.
Why candidates fail: compromised token remains usable.
Strong answer: short TTL + refresh token storage + revocation list/rotation.

9. Ignoring implicit-flow risks in SPAs.
Why candidates fail: token leakage via browser artifacts.
Strong answer: prefer authorization code + PKCE.

10. Not securing inter-service communication.
Why candidates fail: token trust but transport exposure remains.
Strong answer: mTLS + token validation at every boundary.

11. Compliance treated as paperwork only.
Why candidates fail: misses enforceable engineering controls.
Strong answer: map each regulation to concrete technical controls and audit trails.

12. Weak logging for auth failures.
Why candidates fail: impossible to investigate incidents.
Strong answer: capture structured authz/authn logs without leaking sensitive details.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. Difference between authentication and authorization?
Answer: authentication proves identity; authorization controls permitted actions/resources.

2. JWT components?
Answer: header, payload, signature.

3. Role-based vs policy-based authorization?
Answer: role-based is simple/coarse; policy-based is flexible/fine-grained.

4. Why use claims?
Answer: claims carry user attributes for contextual authorization.

5. Cookie vs token auth for browser clients?
Answer: cookies simplify SSR sessions; tokens scale APIs/SPAs/mobile better.

6. Why HTTPS is mandatory with auth tokens/cookies?
Answer: prevents interception/tampering in transit.

7. What does `[AllowAnonymous]` do?
Answer: bypasses auth requirement for specific endpoints.

8. Why short token expiry?
Answer: limits window of misuse if token is stolen.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. How would you design auth for microservices?
Answer: centralized IdP, JWT validation at gateway/services, client credentials for service-to-service, token propagation controls, and strong observability.

2. How to implement business-hours access policy?
Answer: custom `IAuthorizationRequirement` and handler evaluating current time + user claims.

3. Token theft incident: what immediate controls?
Answer: revoke refresh tokens, rotate signing keys if needed, reduce token TTL, monitor suspicious reuse, and force re-authentication.

4. How to enforce author-only document edits?
Answer: resource-based authorization with `IAuthorizationService` comparing principal claim vs resource owner.

5. Hybrid app using browser pages and APIs: one auth scheme or many?
Answer: multi-scheme policy selector (cookie for browser pages, bearer for API calls).

6. Why avoid implicit flow for modern SPAs?
Answer: token exposure risks; use authorization code flow with PKCE.

7. How to rate-limit based on claims?
Answer: claims-aware middleware/policy that maps identity tier/plan to quota and enforces per-window counts.

8. How do compliance requirements affect architecture?
Answer: they mandate encryption, consent/data-rights workflows, auditability, and incident response controls in code and operations.

## 6. The Revision Bank

1. OAuth2 vs OIDC in one sentence.
2. What validation checks are mandatory for JWT?
3. Why can role-only auth become unmaintainable?
4. When should resource-based authorization be used?
5. What is claims transformation and where does it run?
6. Why are refresh tokens needed?
7. What attack does PKCE help mitigate?
8. Why is token propagation a microservice concern?
9. What are top cookie hardening flags?
10. Why does middleware order matter for authn/authz?
11. Which controls are most important for GDPR/HIPAA alignment?
12. What telemetry should you collect for auth security operations?