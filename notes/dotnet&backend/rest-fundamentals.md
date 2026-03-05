# REST Fundamentals - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
REST is an architectural style that uses HTTP semantics to model resources with predictable, cacheable, and evolvable contracts. Senior-level API design is less about CRUD syntax and more about idempotency, compatibility, error contracts, security boundaries, and operational reliability under scale. In ASP.NET Core, strong REST design is implemented through clear resource modeling, versioning strategy, consistent validation/error handling, and performance-aware query/pagination patterns.

## 2. Structured Study Material

### REST Architecture and Core Constraints

| Constraint | What It Means | Why It Matters | Common Failure Mode |
|---|---|---|---|
| Client-Server | UI/client concerns are separated from data/business logic | Independent evolution of frontend and backend | Server returns UI-shaped responses that are too specific |
| Stateless | Every request contains all required context | Horizontal scaling, easier failover | Hidden session dependency on a specific server node |
| Cacheable | Responses explicitly define cacheability | Lower latency and backend load | Missing/incorrect cache headers causing stale or no-cache behavior |
| Uniform Interface | Resources + standard HTTP methods + standard representations | Predictability and client simplicity | RPC-style endpoints like `/getUser`, `/updateUser` |
| Layered System | Intermediaries (gateway/proxy/CDN) can exist transparently | Security, scalability, observability | Leaking internal topology assumptions to clients |
| Code-on-Demand (optional) | Server can send executable code | Rarely used in APIs; optional by design | Treating it as mandatory REST requirement |

REST definition: an architectural style where resources are identified by URIs and manipulated via standard HTTP verbs while maintaining stateless interactions.

### HTTP Methods, Safety, and Idempotency

| Aspect | `GET` | `POST` | `PUT` | `PATCH` | `DELETE` | Trade-offs | When to Use |
|---|---|---|---|---|---|---|---|
| Primary intent | Read | Create | Full replace | Partial update | Remove | Method semantics affect retry safety, caching, and client behavior | Follow HTTP semantics strictly; avoid semantic drift |
| Safe | Yes | No | No | No | No | Safe methods can be prefetched/cached more aggressively | Read-only operations |
| Idempotent | Yes | No | Yes | Usually no (can be designed idempotent) | Yes | Idempotency matters for retries and duplicate request handling | Any operation retried by clients/gateways |
| Typical success code | `200` | `201` | `200` or `204` | `200` or `204` | `204` | Wrong status codes create contract ambiguity | Keep status code semantics explicit |

```http
# Create (server assigns id)
POST /users
Content-Type: application/json

{ "name": "Alice", "email": "alice@example.com" }

HTTP/1.1 201 Created
Location: /users/123
```

```http
# Full replace (idempotent)
PUT /users/123
Content-Type: application/json

{ "id": 123, "name": "Alice", "email": "alice@new.com" }
```

```http
# Partial update
PATCH /users/123
Content-Type: application/json

{ "email": "alice@new.com" }
```

### PUT vs POST vs PATCH (Decision Comparison)

| Aspect | `POST` | `PUT` | `PATCH` | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Resource identity | Usually server-generated | Client targets known URI | Client targets known URI | URI ownership affects conflict handling and retries | `POST` for creation in collection; `PUT/PATCH` for existing resource |
| Payload shape | Creation command | Full representation | Partial changes | Full replace can accidentally null fields if client sends incomplete payload | Use `PUT` only when full model is intended |
| Idempotency | No | Yes | Usually no | Idempotent operations are safer for retries | Use `PUT` for retry-safe full updates |
| Typical risk | Duplicate records | Overwrite unintended fields | Patch semantics inconsistency | Requires clear docs and tests | Use explicit field update rules |

### HTTP Request Components and Status Code Contract

| HTTP Request Component | Purpose | Example |
|---|---|---|
| Method | Action semantics | `GET`, `POST`, `PUT`, `PATCH`, `DELETE` |
| URI | Resource identifier | `/users/123?include=orders` |
| Headers | Metadata/auth/content negotiation | `Authorization`, `Accept`, `Content-Type` |
| Body | Data payload | JSON/XML/form-data |

| Aspect | Option A | Option B | Trade-offs | When to Use |
|---|---|---|---|---|
| Validation failure code | `400 Bad Request` | `422 Unprocessable Entity` | `400` for malformed/structurally invalid request, `422` for semantically invalid domain state | Use `400` for parse/schema errors, `422` for business validation |
| Auth failure | `401 Unauthorized` | `403 Forbidden` | `401` means identity missing/invalid, `403` means identity valid but disallowed | Preserve both to avoid security/diagnostic confusion |
| Not found vs conflict | `404 Not Found` | `409 Conflict` | `404` for missing resource, `409` for state/version conflicts | Use `409` for concurrency/version collisions |

Common response codes to memorize:
- Success: `200`, `201`, `204`
- Client error: `400`, `401`, `403`, `404`, `409`, `422`
- Server error: `500`, `503`

### Resource Modeling, URI Design, and API Surface

Resource naming rules:
- Use nouns, not verbs: `/users`, `/orders`, `/products`
- Use hyphens for readability: `/product-categories`
- Represent hierarchy with sub-resources: `/users/{userId}/orders`
- Avoid RPC-style paths: `/getUser`, `/updateUser`, `/deleteUser`

```http
GET    /users
POST   /users
GET    /users/{id}
PUT    /users/{id}
PATCH  /users/{id}
DELETE /users/{id}
```

Consistent response envelope pattern (from notes):

```csharp
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}

[HttpGet("{id}")]
public async Task<ActionResult<ApiResponse<UserDto>>> GetUser(int id)
{
    var user = await _userService.GetUserAsync(id);
    if (user == null)
        return NotFound(new ApiResponse<UserDto>
        {
            Success = false,
            Message = "User not found"
        });

    return Ok(new ApiResponse<UserDto>
    {
        Success = true,
        Data = user
    });
}
```

### Error Handling Contract and Global Exceptions

Standard error body concept from notes:

```json
{
  "error": {
    "code": "INVALID_EMAIL",
    "message": "Invalid email format",
    "details": "email@domain"
  }
}
```

ASP.NET Core global exception handling:

```csharp
public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, message) = exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, "Validation failed"),
            NotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
            _ => (StatusCodes.Status500InternalServerError, "Internal server error")
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new { error = message });
        return true;
    }
}
```

### Content Negotiation

Goal: server returns a representation the client requested (`Accept`), while declaring what it sent (`Content-Type`).

```http
GET /users/123 HTTP/1.1
Accept: application/xml

HTTP/1.1 200 OK
Content-Type: application/xml
<user><id>123</id><name>Alice</name></user>
```

Use `406 Not Acceptable` if supported representations do not satisfy `Accept`. Defaulting to JSON is common for API simplicity.

### Authentication and Authorization

| Aspect | Authentication | Authorization | Trade-offs | When to Use |
|---|---|---|---|---|
| Core question | Who are you? | What are you allowed to do? | Confusing these leads to wrong status codes and policy leaks | Every protected API |
| Common mechanisms | JWT, OAuth2, API keys | RBAC, scope-based policies, claims-based policies | Fine-grained authz increases policy complexity | Use scopes/claims for API granularity |
| Typical failure code | `401` | `403` | Incorrect code harms client handling and diagnostics | Keep failure semantics explicit |

OAuth2 flows noted:
- Authorization Code flow: user-centric web/mobile flows.
- Client Credentials flow: machine-to-machine service calls.

JWT concept:
- Token shape: `header.payload.signature`
- Apply minimal claims, expiration, issuer/audience validation.

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});
```

Security best practices from notes:
- Always enforce HTTPS.
- Use secure token storage (for browsers, prefer HTTP-only cookies for session-like token transport).
- Add CORS, rate limiting, and input validation as layered controls.

### Versioning Strategies and Compatibility

| Aspect | URI Path Versioning | Header Versioning | Query Versioning | Media Type Versioning | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Example | `/api/v1/users` | `api-version: 2.0` | `/users?version=2.0` | `Accept: application/vnd.company.v2+json` | Each strategy optimizes for different client/tooling visibility | Choose one primary strategy and stay consistent |
| Debuggability | High | Medium/Low | High | Low | Better debuggability can reduce REST purity | Public APIs often choose URI versioning |
| URL cleanliness | Low | High | Medium | High | Cleaner URLs may require stronger client/platform conventions | Internal APIs can prefer headers |
| Tooling support | High | High | High | Medium | Media type versioning can be harder for clients/proxies | Use media type when strict representation negotiation matters |

ASP.NET Core versioning sample:

```csharp
services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("x-api-version")
    );
});

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [MapToApiVersion("1.0")]
    [HttpGet]
    public IActionResult GetV1() => Ok("Version 1.0");

    [MapToApiVersion("2.0")]
    [HttpGet]
    public IActionResult GetV2() => Ok("Version 2.0");
}
```

Breaking-change strategy patterns:
- Versioning: isolate incompatible contracts.
- Expand-contract: add fields first, deprecate old fields later.
- Deprecation policy: announce timeline and migration path.
- Feature toggles: gradual rollout and rollback safety.

```csharp
public class UserV2
{
    [Obsolete("Use FirstName and LastName instead")]
    public string Name { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

### Hypermedia (HATEOAS)

HATEOAS: response includes available next actions as links, reducing hardcoded client workflows.

```csharp
public class Resource<T>
{
    public T Data { get; set; }
    public List<Link> Links { get; set; } = new();
}

public class Link
{
    public string Href { get; set; }
    public string Rel { get; set; }
    public string Method { get; set; }
}

[HttpGet("{id}")]
public ActionResult<Resource<UserDto>> GetUser(int id)
{
    var user = _userService.GetUser(id);
    if (user == null) return NotFound();

    var resource = new Resource<UserDto> { Data = user };
    resource.Links.Add(new Link { Href = Url.Link("GetUser", new { id }), Rel = "self", Method = "GET" });
    resource.Links.Add(new Link { Href = Url.Link("UpdateUser", new { id }), Rel = "update", Method = "PUT" });
    resource.Links.Add(new Link { Href = Url.Link("DeleteUser", new { id }), Rel = "delete", Method = "DELETE" });

    return resource;
}
```

HATEOAS trade-off summary:
- Helps dynamic workflow discoverability and decouples clients from hardcoded routes.
- Increases payload size and implementation complexity.
- Usually strongest value in complex workflows, weaker value in simple CRUD APIs.

### API Documentation with Swagger / OpenAPI

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API Description",
        Contact = new OpenApiContact { Name = "Support", Email = "support@company.com" }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
```

```csharp
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Retrieves a specific user by unique id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        // Implementation
    }
}
```

### Pagination, Filtering, and Query Efficiency

| Aspect | Offset Pagination | Cursor Pagination | Keyset Pagination | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Example | `?page=2&size=20` | `?cursor=abc123&size=20` | `?last_id=100&size=20` | Offset is easiest but slower for large offsets; cursor/keyset scale better | Offset for small datasets/admin tools; cursor/keyset for high-scale feeds |
| Stability under writes | Low | High | High | Offset can skip/duplicate rows during concurrent inserts/deletes | Real-time/high-write systems |

```csharp
public class PagedResponse<T>
{
    public List<T> Data { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
    public bool HasPrevious => PageNumber > 1;
    public bool HasNext => PageNumber < TotalPages;
}
```

N+1 query pitfall and fix:

```csharp
// Bad: N+1
var users = _context.Users.ToList();
foreach (var user in users)
{
    var orders = _context.Orders.Where(o => o.UserId == user.Id).ToList();
}

// Better: eager loading + projection
var usersWithOrders = _context.Users
    .Include(u => u.Orders)
    .Select(u => new UserDto
    {
        Id = u.Id,
        Name = u.Name,
        Orders = u.Orders.Select(o => new OrderDto
        {
            Id = o.Id,
            Amount = o.Amount
        }).ToList()
    })
    .ToList();
```

### Reliability, Performance, and API Pitfalls

High-signal pitfalls from notes:
- Chatty APIs: too many small round-trips.
- Overfetching/underfetching: inefficient payload contracts.
- Ignoring caching: avoidable backend load and latency.
- No real-time support in pure REST: use WebSockets/SignalR for push.

Rate limiting strategies:

| Aspect | Fixed Window | Sliding Window | Token Bucket | User/Tier Based | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Operational behavior | Simple counter per time bucket | Smoother enforcement | Handles bursts with refill rate | Different limits by identity/plan | Simplicity vs fairness and burst handling | Start with fixed window, evolve to token/sliding for internet-facing APIs |

```csharp
services.AddRateLimiting(options =>
{
    options.AddFixedWindowLimiter("Fixed", opt =>
    {
        opt.PermitLimit = 100;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});

[EnableRateLimiting("Fixed")]
public class ProductsController : ControllerBase
{
    // Actions
}
```

### ASP.NET Core Model Binding and Validation (Included from Source)

#### Model Binding Attributes Comparison

| Aspect | `[FromBody]` | `[FromQuery]` | `[FromRoute]` | `[FromHeader]` | `[FromForm]` | `[FromServices]` | Trade-offs | When to Use |
|---|---|---|---|---|---|---|---|---|
| Source | Request body | Query string | Route values | Headers | Form data | DI container | Wrong source selection causes binding errors or hidden defaults | Match source to contract semantics |
| Typical payload | JSON/XML object | Filter/sort/page | Resource ID | Metadata/version/correlation | Form/multipart/file upload | Services, not user data | Body is richer but less cache-friendly than query/route | APIs use body for create/update, route for identity |

```csharp
[HttpGet("{id:int}")]
public IActionResult GetProduct(
    [FromRoute] int id,
    [FromQuery] string include = "",
    [FromHeader(Name = "X-Correlation-Id")] string correlationId = "")
{
    // id from route, include from query, correlationId from header
    return Ok();
}

[HttpPut("{id:int}")]
public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
{
    return Ok();
}
```

#### DataAnnotations and Validation Flow

```csharp
public class Product
{
    [Required(ErrorMessage = "Product ID is required")]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(0.01, 10000.00)]
    public decimal Price { get; set; }

    [EmailAddress]
    public string SupplierEmail { get; set; }

    [Url]
    public string ProductUrl { get; set; }

    [RegularExpression(@"^[A-Z]{3}-\d{3}$")]
    public string ProductCode { get; set; }

    [Compare("EmailConfirmation")]
    public string Email { get; set; }
    public string EmailConfirmation { get; set; }
}

[HttpPost]
public IActionResult CreateProduct([FromBody] Product product)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var created = _service.CreateProduct(product);
    return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
}
```

Validation execution order and null handling:
- Attribute evaluation order: required checks first, then other attributes, then custom validators, then `IValidatableObject.Validate`.
- Value type binding default can hide missing values (`int` becomes `0`), while nullable/reference types can remain `null`.

#### Custom Validation Attribute and `IValidatableObject`

```csharp
public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute() : base("{0} must be a future date") { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue && dateValue <= DateTime.Now)
        {
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }
}

public class Order : IValidatableObject
{
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DeliveryDate.HasValue && DeliveryDate <= OrderDate)
        {
            yield return new ValidationResult("Delivery date must be after order date", new[] { nameof(DeliveryDate) });
        }

        if (Items.Sum(item => item.Quantity) > 100)
        {
            yield return new ValidationResult("Total quantity cannot exceed 100 items", new[] { nameof(Items) });
        }

        if (Items.Any(item => item.Quantity <= 0))
        {
            yield return new ValidationResult("All items must have positive quantity", new[] { nameof(Items) });
        }
    }
}
```

Validation with DI-backed custom attribute concept:

```csharp
public class UniqueProductNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var productService = (IProductService)validationContext.GetService(typeof(IProductService));

        if (productService.ProductNameExists(value?.ToString()))
        {
            return new ValidationResult("Product name already exists");
        }

        return ValidationResult.Success;
    }
}
```

#### ModelState, Problem Details, and Programmatic Validation

| Aspect | `ModelState.IsValid` | `TryValidateModel(model)` | Trade-offs | When to Use |
|---|---|---|---|---|
| Behavior | Reads current validation state | Executes validation for a given model and updates `ModelState` | `TryValidateModel` gives control for manual/late validation flows | Use `ModelState.IsValid` in standard request pipeline; `TryValidateModel` in custom workflows |

```csharp
[HttpPost]
public IActionResult CreateProduct(Product product)
{
    if (product.Price <= 0)
    {
        ModelState.AddModelError(nameof(product.Price), "Price must be positive");
    }

    if (!ModelState.IsValid)
    {
        var problemDetails = new ValidationProblemDetails(ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred."
        };

        return BadRequest(problemDetails);
    }

    return Ok();
}
```

Global API behavior:

```csharp
[ApiController]
public class ProductsController : ControllerBase
{
    // Automatic 400 for invalid model state unless suppressed
}

services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});
```

#### Custom Model Binder, Binder Provider, and Value Provider

```csharp
public class ProductModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
            throw new ArgumentNullException(nameof(bindingContext));

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
            return Task.CompletedTask;

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
            return Task.CompletedTask;

        if (!int.TryParse(value, out var id))
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Product Id must be an integer.");
            return Task.CompletedTask;
        }

        var httpContext = bindingContext.HttpContext;
        var product = new Product
        {
            Id = id,
            CreatedBy = httpContext.User.Identity.Name,
            CreatedAt = DateTime.UtcNow
        };

        bindingContext.Result = ModelBindingResult.Success(product);
        return Task.CompletedTask;
    }
}

public class ProductModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(Product))
            return new ProductModelBinder();

        return null;
    }
}

services.AddMvc(options =>
{
    options.ModelBinderProviders.Insert(0, new ProductModelBinderProvider());
});
```

```csharp
public class HeaderValueProvider : BindingSourceValueProvider
{
    private readonly IHeaderDictionary _headers;

    public HeaderValueProvider(BindingSource bindingSource, IHeaderDictionary headers)
        : base(bindingSource)
    {
        _headers = headers;
    }

    public override bool ContainsPrefix(string prefix) => _headers.ContainsKey(prefix);

    public override ValueProviderResult GetValue(string key)
    {
        if (_headers.TryGetValue(key, out var values))
            return new ValueProviderResult(values);

        return ValueProviderResult.None;
    }
}
```

#### Configuration Binding and Validation via DI

```csharp
public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public int Timeout { get; set; }
    public bool EnableLogging { get; set; }
}

services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));

public class ProductsController : Controller
{
    private readonly DatabaseSettings _dbSettings;

    public ProductsController(IOptions<DatabaseSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }
}
```

```csharp
public interface IProductValidator
{
    ValidationResult Validate(Product product);
}

public class ProductValidator : IProductValidator
{
    private readonly IProductRepository _repository;

    public ProductValidator(IProductRepository repository)
    {
        _repository = repository;
    }

    public ValidationResult Validate(Product product)
    {
        var results = new List<ValidationResult>();

        if (_repository.Exists(product.Name))
        {
            results.Add(new ValidationResult("Product name already exists"));
        }

        return new ValidationResult(results);
    }
}

services.AddScoped<IProductValidator, ProductValidator>();
```

#### Testing Validation Behavior

```csharp
[Test]
public void Product_WithInvalidPrice_ShouldFailValidation()
{
    var product = new Product { Price = -10 };
    var controller = new ProductsController();

    controller.ModelState.Clear();
    var result = controller.CreateProduct(product);

    Assert.IsFalse(controller.ModelState.IsValid);
    Assert.IsTrue(controller.ModelState.ContainsKey(nameof(product.Price)));
}
```

### Practical Design Example: E-commerce Resource Model

```text
/products
/products/{id}
/categories
/users
/users/{id}/orders
/orders
/orders/{id}
/payments
```

Design checks:
- Payments/financial operations require idempotency and replay protection.
- Product listing endpoints require pagination/filtering and cache strategy.
- Order APIs need clear state transition contracts and conflict handling (`409`).

## 3. Senior Perspective (The "Why")

- Scalability: Statelessness and explicit cache directives enable horizontal scaling and lower tail latency. Without these, node-local state and cache misses increase infra cost.
- Reliability: Idempotent contract design (`PUT`, `DELETE`, idempotency keys for creation-like operations) prevents duplicate side effects during retries, gateway timeouts, and at-least-once delivery scenarios.
- Performance and memory: Over-fetching inflates payload size, serializer CPU, and allocation pressure. Cursor/keyset pagination and field projection reduce memory churn and DB pressure.
- Compatibility: Versioning is not only URL choice; it is a lifecycle policy (expand-contract, deprecation windows, telemetry-driven migration). Strong teams design for N-1 client compatibility.
- Security boundary clarity: Distinguishing `401` from `403`, claims/scopes from roles, and transport security (HTTPS) from app-level authorization avoids common incident patterns.
- Operational maturity: Rate limits, consistent `ProblemDetails`-style errors, and versioned OpenAPI contracts improve observability, incident response, and client debuggability.
- Platform evolution (.NET Framework vs modern .NET 8+): Legacy .NET Framework APIs often had more custom plumbing for middleware/versioning/error handling; modern ASP.NET Core/.NET 8+ provides first-class primitives (`IExceptionHandler`, built-in rate limiting, improved minimal/API conventions) that reduce boilerplate and standardize behavior.

## 4. Interview Gotchas & Confusion Points

1. `PUT` vs `PATCH`: Candidates often say both are "update" and stop there. Strong answer clarifies that `PUT` is full replacement and idempotent, while `PATCH` is partial mutation and usually non-idempotent unless explicitly designed.
2. Idempotency misunderstanding: Many people define idempotency as "same response every time". Correct framing is "same server-side effect for repeated identical requests," which is critical for safe retries.
3. `401` vs `403`: A frequent miss is returning `403` for unauthenticated users. Senior answer explains pipeline order: authentication first (`401`), authorization second (`403`).
4. `400` vs `422`: Weak answers collapse all validation into `400`. Strong answer separates malformed/syntactic input (`400`) from semantically invalid but well-formed input (`422`).
5. Versioning strategy dogmatism: Candidates claim one strategy is always best. Strong answer ties strategy to consumers, tooling, observability, and migration costs; consistency matters more than ideology.
6. HATEOAS overstatement: Some claim REST is invalid without HATEOAS. Better answer: HATEOAS is part of REST maturity model but practical value depends on workflow complexity and client ecosystem.
7. `[ApiController]` assumptions: Candidates forget it auto-generates `400` on invalid model state and infers binding sources. Strong answer mentions when to keep defaults versus override behavior.
8. Model binding defaults: Missing value-type inputs silently binding to defaults (e.g., `0`) is often overlooked. Strong answer calls this out as a validation trap and uses nullable types where appropriate.
9. N+1 blind spot: Many discuss endpoint correctness but ignore query shape. Strong answer pairs contract design with EF query plan design (`Include`, projections, paging).
10. Error payload inconsistency: Teams often mix ad hoc error formats across endpoints. Strong answer insists on a uniform error contract for client resilience and telemetry correlation.
11. Caching omission: Candidates discuss performance but skip HTTP caching (`Cache-Control`, conditional requests). Strong answer links caching strategy to endpoint volatility and stale data tolerance.
12. Security surface minimization: Weak answers only say "use JWT". Strong answer includes token lifetime, issuer/audience/signing validation, scope-based authorization, HTTPS, CORS, and rate limiting as layered controls.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How It Works"

1. What are REST constraints and why does statelessness help scaling?
Answer: REST uses client-server, statelessness, cacheability, uniform interface, layered system, and optional code-on-demand. Statelessness removes server session coupling so any node can serve any request.

2. What is the practical difference between `POST`, `PUT`, and `PATCH`?
Answer: `POST` creates (often non-idempotent), `PUT` fully replaces (idempotent), `PATCH` partially modifies (usually non-idempotent).

3. Which HTTP codes should you return for common CRUD operations?
Answer: `200` for successful read/update response, `201` for create, `204` for delete/no-body success, plus `400/401/403/404/409/422` for client-side failures and `500/503` for server-side failures.

4. How does content negotiation work?
Answer: Client sends `Accept`, server returns `Content-Type` matching supported representation, otherwise `406 Not Acceptable`.

5. How is authentication different from authorization?
Answer: Authentication verifies identity; authorization enforces permissions/scopes/roles after identity is known.

6. What does `[ApiController]` give you in ASP.NET Core?
Answer: Automatic model validation error responses, binding source inference, and API-focused conventions.

7. When do you use `[FromRoute]`, `[FromQuery]`, and `[FromBody]`?
Answer: Route for identity, query for optional filters/paging, body for complex create/update payloads.

8. How do `ModelState.IsValid` and `TryValidateModel` differ?
Answer: `ModelState.IsValid` reads existing validation results; `TryValidateModel` actively validates a model and populates model state.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. You need to introduce breaking response changes for a public API. What migration strategy do you use?
Answer: Version explicitly, apply expand-contract where possible, publish deprecation timeline, and monitor migration via API telemetry before retirement.

2. Mobile clients experience duplicate order submissions after network retries. How do you fix it?
Answer: Enforce idempotency for order creation (idempotency key or client-generated identifiers), keep request dedupe store, and ensure retry-safe semantics.

3. An endpoint is correct functionally but slow under load. What do you inspect first?
Answer: Query shape (N+1, missing indexes, projection), payload size, pagination strategy, cache headers, and serialization overhead.

4. Should you choose URI or header versioning for an enterprise API platform?
Answer: Decide by client ecosystem and observability needs; URI is easier to debug and communicate externally, header keeps URLs clean for internal clients.

5. How do you design a consistent validation strategy across controller and domain layers?
Answer: Controller handles shape/basic input validation; service/domain handles business invariants. Merge into one consistent error contract.

6. How would you expose a workflow-heavy domain where allowed actions change by state?
Answer: Consider HATEOAS links for state-driven next actions to reduce client hardcoding and improve discoverability.

7. How do you secure a multi-tenant API beyond just adding JWT?
Answer: Validate issuer/audience/signature/lifetime, enforce tenant-aware authorization policies/scopes, lock down CORS, rate limit per tenant/key, and audit security events.

8. A team reports confusing client behavior on validation failures. What do you change?
Answer: Standardize `400` vs `422` usage, return machine-readable error codes, include field-level detail, and version the error contract if needed.

## 6. The Revision Bank

1. Define idempotency and give one practical retry scenario.
2. Why is `DELETE` idempotent even when resource is already deleted?
3. When should an API return `409 Conflict`?
4. What is the difference between malformed JSON and domain validation error in status-code terms?
5. Why can offset pagination degrade at high page numbers?
6. When is HATEOAS useful enough to justify payload overhead?
7. What does `[ApiController]` do automatically that changes controller code style?
8. Name two risks of using non-nullable value types in bound request models.
9. Compare URI vs header versioning for external partner APIs.
10. What causes N+1 queries and how do you detect/fix them in EF Core?
11. Why should authentication and authorization failures use different status codes?
12. Which rate limiting algorithm would you start with and how would you evolve it?

## 7. Clarification / Suggested Additions Before Finalizing

Suggested senior-level additions (if you want one more refinement pass):
- Contract testing and backward compatibility gates in CI.
- Observability patterns for APIs (structured logs, trace correlation IDs, OpenTelemetry).
- API gateway concerns: auth offloading, per-route rate limits, and response caching policy.
