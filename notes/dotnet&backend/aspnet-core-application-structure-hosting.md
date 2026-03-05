# ASP.NET Core Application Structure and Hosting Interview Playbook (5 Years Experience)

## The Elevator Pitch (Executive Summary)
ASP.NET Core hosting is about composing three things correctly: startup bootstrapping, middleware pipeline order, and server/runtime configuration across environments. Senior-level interviews focus less on “which API exists” and more on why ordering, hosting model, routing constraints, and deployment choices change latency, security posture, and operability. Strong answers connect code structure decisions (Program/Startup style, controller design, model binding, response contracts) to production behavior and migration trade-offs.

## Structured Study Material

### 1) Bootstrapping Evolution: `Startup.cs` vs Minimal Hosting

| Aspect | Traditional (`Startup.cs`, .NET Core 1.0-3.1) | Minimal Hosting (`Program.cs`, .NET 6+) | Trade-offs / When to Use |
|---|---|---|---|
| Service registration | `ConfigureServices` | `builder.Services` | Minimal hosting reduces file hopping; Startup style can still improve separation in very large solutions |
| Middleware pipeline | `Configure` method | Direct `app.Use...` in `Program.cs` | Minimal model improves readability for small/medium APIs |
| Entry point | `CreateHostBuilder(...).UseStartup<Startup>()` | `WebApplication.CreateBuilder(args)` | Minimal approach is the current default for new apps |
| Complexity management | Explicit two-class pattern | Single-file by default (can still split with extension methods) | Use modular extension methods when `Program.cs` grows too large |

Traditional syntax:

```csharp
// Startup.cs
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<AppDbContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args) =>
        CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

Minimal hosting syntax:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.MapControllers();
app.Run();
```

### 2) Middleware Pipeline and Ordering

| Order | Middleware | Why This Position Matters | Typical Failure If Wrong |
|---|---|---|---|
| 1 | `UseExceptionHandler` | Must wrap downstream pipeline to catch unhandled exceptions globally | Exceptions bypass global handler |
| 2 | `UseHttpsRedirection` | Enforce HTTPS early before business processing | Mixed HTTP/HTTPS behavior and security drift |
| 3 | `UseStaticFiles` | Static assets can bypass controller pipeline | Unnecessary routing/auth cost for static requests |
| 4 | `UseRouting` | Selects endpoint candidates | Endpoint selection fails if moved after endpoint execution |
| 5 | `UseAuthentication` | Establish user identity before authZ | AuthZ runs without principal |
| 6 | `UseAuthorization` | Enforce policies on selected endpoint | Unauthorized access or policy failures |
| 7 | `UseCors` | Apply cross-origin policy in request flow | Browser CORS failures on valid API calls |
| 8 | Endpoint execution (`UseEndpoints`/`MapControllers`) | Terminal stage for route execution | 404s or route mismatch behavior |

Canonical order syntax:

```csharp
var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
```

Custom and conditional middleware patterns:

```csharp
app.Use(async (context, next) =>
{
    var start = DateTime.UtcNow;
    await next();
    var duration = DateTime.UtcNow - start;
    context.Response.Headers["X-Processing-Time"] = duration.ToString();
});

if (app.Environment.IsProduction())
{
    app.UseHsts();
}
```

Dedicated middleware class pattern:

```csharp
public class TimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TimingMiddleware> _logger;

    public TimingMiddleware(RequestDelegate next, ILogger<TimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        _logger.LogInformation($"Request took {stopwatch.ElapsedMilliseconds}ms");
        context.Response.Headers["X-Processing-Time"] = stopwatch.ElapsedMilliseconds.ToString();
    }
}

public static class TimingMiddlewareExtensions
{
    public static IApplicationBuilder UseTiming(this IApplicationBuilder app)
        => app.UseMiddleware<TimingMiddleware>();
}
```

Performance-oriented middleware guidance:
- Prefer built-in middleware over custom implementations when requirements already exist in the framework.
- Use `UseWhen` to branch costly middleware only for relevant request paths.
- Avoid heavy initialization logic in middleware constructors.

```csharp
app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/api"),
    branch => branch.UseTiming());
```

### 3) Host Configuration and Environments

| Concern | Recommended Pattern | Why It Matters |
|---|---|---|
| Base + environment overrides | `appsettings.json` + `appsettings.{Environment}.json` | Predictable config layering across dev/stage/prod |
| Infrastructure overrides | Environment variables | Works well in containers/CI/CD |
| Service registration per env | `IsDevelopment()`/`IsProduction()` branches | Keep test mocks out of production runtime |

Environment-aware configuration syntax:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    builder.Services.AddTransient<IDatabaseService, MockDatabaseService>();
}
else
{
    builder.Services.AddTransient<IDatabaseService, ProductionDatabaseService>();
}
```

Environment can be set via:
- `ASPNETCORE_ENVIRONMENT` environment variable
- `launchSettings.json` (local development profile)
- Command line argument (`--environment Production`)

Host/server settings in `appsettings.json`:

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "Https": {
        "Url": "https://localhost:5001"
      }
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

`launchSettings.json` for local launch profiles:

```json
{
  "profiles": {
    "Development": {
      "commandName": "Project",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "Production": {
      "commandName": "Project",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production"
      }
    }
  }
}
```

### 4) Server Hosting: Kestrel vs IIS and Process Models

| Aspect | Kestrel | IIS | Trade-offs / When to Use |
|---|---|---|---|
| Server type | ASP.NET Core cross-platform server | Windows web server | Kestrel for cross-platform/cloud-native; IIS for Windows enterprise integration |
| Platform | Windows/Linux/macOS | Windows only | Platform constraints decide architecture early |
| Performance profile | Lightweight, high throughput | Feature-rich, heavier | Kestrel often preferred for containerized microservices |
| Protocol support | HTTP/1.x, HTTP/2, HTTP/3 | HTTP/1.x, HTTP/2 | Protocol needs may influence edge/server topology |
| TLS/SSL | Built-in support | Config-driven in IIS | Operational model differs by hosting team/tooling |
| Process model context | App process by default | In-process or out-of-process options | Operational isolation vs raw performance trade-off |
| Reverse proxy pattern | Frequently hosts app directly or behind proxy | Often used as reverse proxy/front door for Kestrel on Windows | Common enterprise topology: IIS front, Kestrel app behind |

Programmatic Kestrel configuration:

```csharp
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxConcurrentConnections = 100;
    serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
    serverOptions.Listen(IPAddress.Loopback, 5000);
    serverOptions.Listen(IPAddress.Loopback, 5001,
        listenOptions => listenOptions.UseHttps());
});
```

IIS integration (`web.config`):

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*"
           modules="AspNetCoreModuleV2" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet"
                arguments=".\MyApp.dll"
                stdoutLogEnabled="false"
                stdoutLogFile=".\logs\stdout"
                hostingModel="inprocess" />
  </system.webServer>
</configuration>
```

IIS hosting model difference syntax:

```xml
<!-- In-process: faster -->
<aspNetCore processPath="dotnet" hostingModel="inprocess" />

<!-- Out-of-process: more isolation -->
<aspNetCore processPath="dotnet" hostingModel="outofprocess" />
```

### 5) Controllers, Routing, and Constraints

#### Controller Type Selection

| Type | Primary Use | Adds View Support | When to Choose |
|---|---|---|---|
| `ControllerBase` | Web APIs | No | Default for API-only services |
| `Controller` | MVC with views | Yes | Server-rendered MVC/UI scenarios |

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts() => Ok(new List<Product>());
}

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
```

#### Attribute Routing Patterns

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) => Ok(new Product(id));

    [HttpGet("category/{category:alpha}")]
    public IActionResult GetByCategory(string category) => Ok();

    [HttpPost]
    public IActionResult Create([FromBody] Product product) => Created();

    [HttpGet("search/{name:minlength(3)}/{category?}")]
    public IActionResult Search(string name, string category = "all") => Ok();
}
```

Built-in and custom route constraints:

```csharp
[HttpGet("{id:int:min(1)}")]
[HttpGet("{name:alpha:minlength(2)}")]
[HttpGet("{date:datetime}")]
[HttpGet("{email:regex(^\\w+@\\w+\\.\\w+$)}")]
```

```csharp
public class ValidProductCategoryConstraint : IRouteConstraint
{
    private readonly string[] _validCategories = { "electronics", "books", "clothing" };

    public bool Match(HttpContext httpContext, IRouter route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        return values.TryGetValue(routeKey, out var value) &&
               _validCategories.Contains(value?.ToString().ToLower());
    }
}

// Usage:
[HttpGet("category/{category:validCategory}")]
```

Catch-all route syntax:

```csharp
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    [HttpGet("{*path}")]
    public IActionResult GetDocument(string path)
    {
        return Ok($"Requested path: {path}");
    }
}
```

Route conflict resolution rule of thumb:
- ASP.NET Core picks the most specific match based on template specificity, registration order, and constraint match quality.

### 6) Model Binding Sources and API Contracts

| Binding Source | Typical Input | Use Case |
|---|---|---|
| `[FromRoute]` | URL path segments | Resource identity in REST routes |
| `[FromQuery]` | Query string | Filtering, pagination, flags |
| `[FromBody]` | Request body (JSON/XML) | Create/update payloads |
| `[FromForm]` | Form-data payload | Multipart/form submissions |

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(
        [FromRoute] int id,
        [FromQuery] bool details)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        return Created();
    }

    [HttpPost("form")]
    public IActionResult CreateFromForm([FromForm] Product product)
    {
        return Created();
    }
}
```

### 7) Action Results, Response Modeling, and Conventions

| Return Style | Strength | Typical Trade-off |
|---|---|---|
| `IActionResult` | Maximum flexibility for multiple result shapes | Weaker compile-time type signal |
| `ActionResult<T>` | Stronger API contract signal with typed success body | Slightly tighter return design |

```csharp
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _repository.GetProduct(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpGet("typed/{id}")]
    public ActionResult<Product> GetProductTyped(int id)
    {
        var product = _repository.GetProduct(id);
        return product ?? NotFound();
    }

    public IActionResult VariousResults()
    {
        return Ok(new { message = "Success" });
        return Created("/api/products/1", newProduct);
        return BadRequest("Invalid data");
        return NotFound();
        return Unauthorized();
        return Redirect("/home");
    }
}
```

API convention usage:

```csharp
[ApiConventionType(typeof(DefaultApiConventions))]
public class ProductsController : ControllerBase
{
    [ApiConventionMethod(typeof(DefaultApiConventions),
                         nameof(DefaultApiConventions.Get))]
    public IActionResult GetProduct(int id) => Ok();
}

public static class CustomConventions
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static void Get(int id) { }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public static void Post(Product product) { }
}
```

### 8) API Versioning and Contract Evolution

| Concern | Pattern |
|---|---|
| Default behavior | Set `DefaultApiVersion` + assume default when unspecified |
| Client discoverability | Enable `ReportApiVersions` |
| URL versioning | Use route template `v{version:apiVersion}` |
| Per-version behavior | Use `[MapToApiVersion]` per action |

```csharp
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    [MapToApiVersion("1.0")]
    [HttpGet]
    public IActionResult GetV1() => Ok("Version 1");

    [MapToApiVersion("2.0")]
    [HttpGet]
    public IActionResult GetV2() => Ok("Version 2");
}
```

## Senior Perspective (The "Why")

- Bootstrapping style is a maintainability decision: minimal hosting improves flow for most APIs, but larger domains still need composition boundaries (extension methods/modules) to avoid `Program.cs` sprawl.
- Middleware order is architecture, not syntax. Small ordering mistakes can create silent security regressions (auth/authz/CORS sequencing), observability blind spots, or route failures that are hard to debug.
- Hosting choice (Kestrel-only, IIS integration, in-process/out-of-process) should follow deployment topology and operational ownership, not local development preference.
- Environment configuration layering is a reliability boundary. Missing precedence rules between `appsettings`, environment-specific files, and environment variables causes production-only defects.
- Routing constraints are correctness and performance tools: they reduce ambiguous matches and fail invalid requests earlier.
- Return type strategy (`IActionResult` vs `ActionResult<T>`) impacts API contract clarity, generated documentation quality, and consumer confidence.
- API versioning is organizational risk control. It decouples client migration from server release cadence, but increases testing and support matrix cost.
- Custom middleware should stay lightweight and deterministic. Heavy logic in pipeline layers increases P95/P99 latency for every request.

## Interview Gotchas & Confusion Points

- Startup migration trap: candidates say `.NET 6+ removed Startup so separation is impossible`. Stronger answer: separation still exists via extension methods/modules; only default bootstrap style changed.
- Middleware order trap: many remember the list but not the reason. Interviewers expect causality: `UseRouting` selects endpoint, `UseAuthorization` evaluates endpoint metadata, endpoint execution comes last.
- Auth sequence trap: placing `UseAuthorization` before `UseAuthentication` can fail policy evaluation because principal identity has not been established.
- CORS placement trap: incorrect placement often passes backend tests but fails browser clients in production; explain that cross-origin policy must execute at the correct point in request processing.
- Exception handling trap: dev exception page and global exception handling are environment-sensitive. Production must use hardened handlers; development diagnostics should not leak to prod.
- Kestrel vs IIS oversimplification: “Kestrel is always better” is shallow. Better answer: choose based on platform, ops tooling, reverse-proxy topology, security/compliance model, and process isolation needs.
- In-process/out-of-process misunderstanding: candidates often present only performance. Interviewers expect discussion on isolation boundaries, diagnostics behavior, and failure blast radius.
- Config source confusion: `launchSettings.json` is dev-time launch metadata, not production configuration strategy.
- Model binding ambiguity trap: candidates frequently confuse `[FromBody]` and `[FromForm]`; explain payload format expectations and why wrong binding attributes cause 415/validation failures.
- Routing conflict trap: when multiple templates match, route specificity/constraints/order matter. Good answers mention deterministic matching strategy rather than “first one wins” simplification.
- Constraint overuse trap: regex-heavy constraints can become brittle and hard to maintain; balance strictness with readability and API evolution.
- `IActionResult` vs `ActionResult<T>` trap: strong candidates explain contract clarity trade-offs, not just syntax preference.
- API versioning trap: enabling versioning without deprecation policy and documentation governance creates long-term maintenance debt.
- Custom middleware performance trap: expensive logging/serialization in middleware affects every request path and can dominate tail latency under load.

## Tiered Interview Q&A

### Mid-Level: Foundational "How it works" questions

1. What changed from `Startup.cs` to minimal hosting in .NET 6+?
2. Why does middleware order matter in ASP.NET Core?
3. What is the practical difference between `ControllerBase` and `Controller`?
4. How do `[FromRoute]`, `[FromQuery]`, `[FromBody]`, and `[FromForm]` differ?
5. What is the difference between `IActionResult` and `ActionResult<T>`?
6. How does attribute routing with constraints improve API behavior?
7. What does `launchSettings.json` do, and where should it not be used?
8. How is environment-specific configuration loaded?
9. What are the primary differences between Kestrel and IIS?
10. What is the difference between IIS in-process and out-of-process hosting?
11. How do catch-all routes work in ASP.NET Core?
12. What problem does API versioning solve?

### Senior/Lead: Scenario-based "Design & Troubleshooting" questions

1. Production started returning 404 after a deployment with middleware changes. How do you isolate order-related regressions quickly?
2. Browser clients fail with CORS errors while Postman succeeds. Where do you inspect pipeline ordering and policy scope?
3. A latency regression appears after adding request-timing middleware. How do you quantify middleware overhead and redesign it?
4. You need to host the same API across Linux containers and Windows VMs. How do Kestrel/IIS choices differ by environment?
5. A monolith migration introduces both old and new bootstrap patterns. How do you standardize composition without losing modularity?
6. Routes with optional segments and regex constraints become hard to maintain. How would you redesign route strategy?
7. Consumers break after introducing v2 APIs. How would you roll out versioning with backward compatibility and deprecation policy?
8. An endpoint receives empty models unexpectedly. How do you debug binding source mismatches (`FromBody` vs `FromForm` vs `FromQuery`)?
9. Security review flags misconfigured exception and HSTS behavior. How do you enforce environment-safe defaults?
10. You need strict request-body limits for abuse prevention. Where do you configure it and how do you validate operational impact?
11. Multiple routes match a request unexpectedly. How do you reason about specificity, constraints, and registration order?
12. Your team wants all APIs to return `IActionResult`. When would you mandate `ActionResult<T>` for contract clarity?

## The Revision Bank

1. Why did ASP.NET Core move from `Startup.cs` patterns to minimal hosting defaults?
2. What are the non-negotiable middleware ordering rules in a secured API?
3. When should you use `Controller` instead of `ControllerBase`?
4. Which model binding source is correct for JSON body vs multipart form uploads?
5. Why can incorrect CORS placement pass backend testing but fail in browsers?
6. What is the operational difference between IIS in-process and out-of-process?
7. How do route constraints reduce ambiguity in endpoint matching?
8. When is `ActionResult<T>` preferable to `IActionResult`?
9. How does API versioning reduce release risk for clients?
10. Why is `launchSettings.json` not a production configuration mechanism?
11. Which Kestrel limits are commonly tuned for safety and throughput?
12. What is the first debugging step when `UseRouting`/endpoint ordering is suspected broken?
