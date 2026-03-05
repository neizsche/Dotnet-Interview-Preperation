# Security - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Security in .NET is a layered system: authentication, authorization, transport security, data protection, and operational controls. Senior-level security design is mostly about least privilege, threat modeling, and failure handling under real production constraints, not just enabling `[Authorize]`. In practice, teams choose the right auth model (cookie, JWT, OAuth2/OIDC, Windows auth) based on client type, trust boundary, and scale requirements.

## 2. Structured Study Material

### Security Architecture Foundations

High-signal security model from source notes:
- Authenticate identity (who is calling).
- Authorize actions (what they can do).
- Protect transport (TLS/HTTPS).
- Protect tokens and sensitive data.
- Log and audit privileged actions.
- Apply least privilege by default.

### Authentication Methods in .NET

| Method | What It Is | Strengths | Limitations | When to Use |
|---|---|---|---|---|
| Forms Authentication | App-managed login form + cookie/session flow | Full UX control, simple for server-rendered apps | Session/cookie handling complexity at scale | Traditional web apps with custom login pages |
| Windows Authentication | Uses current Windows identity (IIS/AD integrated) | Seamless intranet SSO, no extra credentials | Not suited for public internet apps | Corporate intranet and domain-joined users |
| OAuth 2.0 | Authorization delegation framework | Strong for API authorization and third-party access | Not an identity protocol by itself | API access delegation, machine-to-machine, social login flows |
| OpenID Connect (OIDC) | Identity layer on top of OAuth 2.0 | Standardized authentication + SSO | Requires IdP integration and flow design | Modern web/mobile SSO and federated login |

### Token-Based vs Cookie-Based Authentication

| Aspect | Token-Based (JWT Bearer) | Cookie-Based | Trade-offs | When to Use |
|---|---|---|---|---|
| Storage/transport | Token sent in `Authorization: Bearer` header | Browser sends cookie automatically | Tokens are client-managed; cookies are browser-managed | JWT for APIs/SPAs/mobile; cookies for SSR web apps |
| Server state | Usually stateless | Often session-oriented | Stateless scales better but revocation is harder | Horizontal API scale favors JWT |
| CSRF/XSS considerations | Lower CSRF surface when header-based, but token theft risk (XSS/storage) | CSRF risk unless mitigated (`SameSite`, anti-forgery) | Security posture depends on storage and mitigations | Browser-first apps often still use secure cookies |
| Cross-domain/API use | Works well across domains/services | Harder in cross-site and non-browser clients | Simplicity vs interoperability | Public APIs and microservices prefer bearer tokens |
| Mobile support | Natural fit | Less natural | Token model fits native clients | Mobile and distributed clients |

### RBAC (Role-Based Access Control)

RBAC definition from source:
- Assign users to roles.
- Assign permissions to roles.
- Enforce access using role/policy checks.

Implementation steps in .NET:
1. Define roles (for example `Admin`, `Manager`, `User`).
2. Map permissions to roles.
3. Associate users with roles.
4. Enforce authorization at endpoint/service levels.
5. Handle access-denied paths consistently.
6. Provide admin tooling for role assignment lifecycle.

Example policy + role enforcement in ASP.NET Core:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

[Authorize(Roles = "Admin")]
[HttpPost("/admin/reindex")]
public IActionResult Reindex() => Ok();

[Authorize(Policy = "AdminOnly")]
[HttpDelete("/users/{id}")]
public IActionResult DeleteUser(string id) => Ok();
```

### Claims-Based Authentication and Advantages

Claims-based model from source:
- Identity provider issues claims (name, email, role, tenant, etc.) inside a token.
- Relying application validates token and uses claims for authorization decisions.

Advantages:
- Flexible identity attributes beyond simple roles.
- Good fit for SSO and federation.
- Decouples authentication from app business logic.
- Enables attribute-aware authorization decisions.

Typical claims checks:

```csharp
[Authorize]
[HttpGet("/profile")]
public IActionResult GetProfile()
{
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var role = User.FindFirst(ClaimTypes.Role)?.Value;
    return Ok(new { userId, role });
}
```

### JWT Authentication in .NET

JWT basics from source:
- Header + payload + signature.
- Signed token carries claims.
- Commonly used for API authentication.

Authentication workflow:
1. User authenticates with credentials.
2. Server generates JWT with claims and expiry.
3. Client sends token on subsequent requests.
4. API validates signature, issuer, audience, expiry.
5. Claims drive authorization.

#### Generating JWT Tokens (C#)

```csharp
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class JwtService
{
    public string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        string userId,
        string[] roles,
        int expiryMinutes)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
```

#### Validating JWT Tokens (C#)

```csharp
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

public class JwtService
{
    public ClaimsPrincipal? ValidateToken(
        string token,
        string secretKey,
        string issuer,
        string audience)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };

        try
        {
            SecurityToken validatedToken;
            return tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
        catch
        {
            return null;
        }
    }
}
```

### Securing APIs with JWT in ASP.NET Core

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
```

```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders() => Ok();
}
```

### TLS/SSL and HTTPS Configuration

Source principles preserved:
1. Obtain certificate from trusted CA.
2. Install certificate on host.
3. Bind certificate to HTTPS endpoint.
4. Redirect HTTP to HTTPS.
5. Keep TLS config modern (disable old protocols/ciphers).
6. Monitor and renew certificates.

ASP.NET Core HTTPS enforcement:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    // other middleware
}
```

ASP.NET MVC style enforcement (concept from source):
- Configure HTTPS bindings in IIS.
- Use web.config rewrite rules or filters to enforce HTTPS.

### Security Control Checklist for Production

| Control Area | Baseline Control | Why It Matters |
|---|---|---|
| Identity | Strong auth mechanism with MFA where possible | Reduces credential abuse risk |
| Authorization | RBAC/policy checks and least privilege | Limits blast radius |
| Token security | Short access token TTL, strong signing key, refresh design | Reduces token replay window |
| Transport | TLS 1.2+ and HTTPS-only endpoints | Protects data in transit |
| Error handling | Do not leak internals in auth failures | Prevents information disclosure |
| Auditability | Log auth events, role changes, sensitive actions | Enables incident response |

## 3. Senior Perspective (The "Why")

- Security choices are architecture choices: cookie/session and token models have different trust and scale implications.
- JWT is operationally efficient for distributed APIs but increases revocation complexity; teams must design refresh/revocation patterns explicitly.
- RBAC is maintainable at scale, but role explosion happens without policy discipline; claims and policy-based auth often scale better for complex domains.
- TLS is not optional: even perfect auth logic fails if transport is weak or misconfigured.
- Threat modeling is the prioritization tool: without it, teams overinvest in low-risk controls and miss high-impact attack paths.
- Evolution note (.NET Framework vs modern .NET 8+): modern ASP.NET Core security pipeline (`AddAuthentication`, `AddAuthorization`, middleware ordering, policy system) is cleaner and more composable than many legacy configurations.

## 4. Interview Gotchas & Confusion Points

1. Using JWT for everything by default.
Why candidates fail: they ignore browser cookie advantages in SSR apps.
Strong answer: choose auth mechanism by client type and threat model, not trend.

2. Confusing OAuth2 and OpenID Connect.
Why candidates fail: they treat OAuth as authentication.
Strong answer: OAuth2 is authorization delegation; OIDC adds authentication identity layer.

3. Missing `UseAuthentication()` before `UseAuthorization()`.
Why candidates fail: authorization runs without an authenticated principal.
Strong answer: pipeline order must be `UseAuthentication` then `UseAuthorization`.

4. Storing JWT insecurely in browser storage without mitigation.
Why candidates fail: XSS can expose tokens.
Strong answer: weigh storage model and XSS/CSRF trade-offs; harden frontend and token lifetime.

5. Weak JWT validation settings.
Why candidates fail: only signature checked, issuer/audience/lifetime skipped.
Strong answer: validate issuer, audience, signature, and expiration with bounded clock skew.

6. Long-lived access tokens without refresh strategy.
Why candidates fail: compromised token remains valid too long.
Strong answer: short-lived access tokens + secure refresh token workflow.

7. Role checks hardcoded across controllers.
Why candidates fail: brittle authorization and duplicated logic.
Strong answer: centralize via policies and claims requirements.

8. Assuming HTTPS in dev means secure production.
Why candidates fail: certificate and TLS policy drift in deployment.
Strong answer: enforce HTTPS + HSTS and monitor cert lifecycle in prod.

9. Over-privileged service accounts.
Why candidates fail: one compromise gives broad system access.
Strong answer: least privilege for users and workloads.

10. Not handling token revocation/logout semantics.
Why candidates fail: stateless token remains usable post-logout.
Strong answer: design revocation list/versioning/short TTL strategy.

11. Access-denied responses leaking sensitive details.
Why candidates fail: attackers learn system internals.
Strong answer: return minimal error details externally, detailed logs internally.

12. Treating RBAC as complete fine-grained authorization.
Why candidates fail: role-only control becomes too coarse.
Strong answer: combine RBAC with claim/policy checks for domain-level decisions.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. What is the difference between authentication and authorization?
Answer: authentication proves identity; authorization decides permitted actions.

2. Cookie auth vs JWT auth in one line?
Answer: cookie auth is browser/session-oriented; JWT is stateless bearer-token oriented, common for APIs.

3. What is RBAC?
Answer: users are assigned roles, roles carry permissions, access is enforced by role membership.

4. Why do we use claims?
Answer: claims carry identity attributes used by apps for contextual authorization.

5. What should a JWT contain at minimum?
Answer: subject/user identifier, issuer, audience, expiration, and signature-protected claims.

6. Which validations are mandatory for JWT?
Answer: signature key, issuer, audience, and token lifetime.

7. Why enforce HTTPS?
Answer: to prevent interception/tampering of credentials and tokens in transit.

8. How do you protect an API endpoint in ASP.NET Core?
Answer: configure auth middleware and add `[Authorize]` on controllers/actions.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. Multi-service API platform needs scalable auth with SSO.
Answer: use OIDC/OAuth2 with centralized IdP, JWT access tokens, and policy-based authorization per service.

2. Security incident: stolen access token reported.
Answer: rotate signing keys if required, reduce token TTL, revoke session/refresh tokens, audit suspicious access, and patch root cause.

3. Need internal app with seamless corporate login.
Answer: use Windows authentication for intranet where AD/Kerberos context is available.

4. Large app has role explosion and unclear access logic.
Answer: migrate to policy-based authorization with claims requirements and standardized permission model.

5. Public SPA with API, concern about CSRF and XSS.
Answer: define token/cookie strategy explicitly, harden CSP/XSS controls, apply anti-forgery where cookie-based flows are used.

6. Legacy ASP.NET MVC app moving to ASP.NET Core.
Answer: re-map auth pipeline order, re-implement policies, and validate behavior differences in cookies/JWT middleware.

7. Compliance requires auditable access changes.
Answer: log role/permission assignment changes, privileged operations, and failed authz attempts with immutable audit trails.

8. High-traffic API sees auth bottlenecks.
Answer: optimize token validation path, cache metadata/keys safely, and reduce expensive downstream authorization lookups.

## 6. The Revision Bank

1. OAuth2 vs OpenID Connect: what is the exact difference?
2. Why is `UseAuthentication()` ordering critical in ASP.NET Core?
3. What are the core JWT validation parameters you should never skip?
4. When is cookie auth a better choice than JWT?
5. What problem does RBAC solve, and where does it fall short?
6. Why can long-lived JWTs be dangerous?
7. What is claims-based authorization in practical API design?
8. How does HSTS improve HTTPS security posture?
9. What is least privilege, and how do you enforce it operationally?
10. How would you invalidate access quickly after credential compromise?
11. Why is transport security still required even with signed tokens?
12. Which security logs are most useful during incident response?

## 7. Clarification / Suggested Additions Before Finalizing

Suggested senior-level additions for one more refinement pass:
- Threat modeling workflow (STRIDE) mapped to .NET controls.
- Secret management patterns (Azure Key Vault, user secrets, rotation process).
- Advanced token topics: signing key rollover (`kid`), JWT revocation patterns, and introspection.
- Defense-in-depth controls: CSP, anti-forgery strategy, rate limiting, and anomaly detection.
- Secure SDLC checks: dependency vulnerability scanning, SAST/DAST, and security unit/integration tests.
