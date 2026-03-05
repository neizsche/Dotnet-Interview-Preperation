# Middleware - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Middleware is the execution model behind ASP.NET Core: every request moves through an ordered chain where each component can inspect, mutate, short-circuit, or forward. Senior-level middleware design is mostly about ordering, failure boundaries, observability, and performance under concurrency, not just writing `InvokeAsync`. Strong teams keep middleware focused on cross-cutting concerns (security, logging, error handling, routing, caching) and treat the pipeline as a contract.

## 2. Structured Study Material

### Middleware in Web Applications

Middleware is the bridge layer that processes inbound HTTP requests and outbound responses.

Core roles from the source notes:
- Request processing and response shaping.
- Pipeline composition where each component can run pre and post logic.
- Centralized cross-cutting concerns: logging, authentication, authorization, caching, compression, error handling.
- Modularity, reusability, and separation of concerns.
- Extension point for customization without changing business endpoints.

### Basic Middleware Structure

```csharp
public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Pre-processing logic

        await _next(context); // Pass to next middleware

        // Post-processing logic
    }
}
```

### Middleware Categories

| Aspect | Application Middleware | Terminal Middleware | Router/Endpoint Middleware | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Responsibility | Cross-cutting logic before/after next component | Ends pipeline and writes final response | Matches route and dispatches endpoint | More flexibility increases ordering complexity | Use application middleware for reusable cross-cutting concerns |
| Calls `next` | Yes (usually) | No | Depends on routing stage | Not calling `next` short-circuits later middleware | Use terminal for final fallback/static responses |
| Typical examples | Logging, auth, CORS, exception handling | `app.Run(...)`, hard stop responses | `UseRouting`, endpoint mapping | Incorrect placement causes unreachable logic | Place routing before authz decisions tied to endpoints |

### Custom Middleware Creation Patterns

#### Method 1: Class-based (`UseMiddleware<T>`) with extension method

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

        _logger.LogInformation("Request took: {ElapsedMs}ms", stopwatch.ElapsedMilliseconds);
    }
}

public static class TimingMiddlewareExtensions
{
    public static IApplicationBuilder UseTimingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TimingMiddleware>();
    }
}
```

#### Method 2: Inline (`Use`)

```csharp
app.Use(async (context, next) =>
{
    var start = DateTime.UtcNow;

    await next();

    var duration = DateTime.UtcNow - start;
    Console.WriteLine($"Request took: {duration.TotalMilliseconds}ms");
});
```

#### Method 3: Factory-activated (`IMiddleware`)

```csharp
public class FactoryActivatedMiddleware : IMiddleware
{
    private readonly ILogger<FactoryActivatedMiddleware> _logger;

    public FactoryActivatedMiddleware(ILogger<FactoryActivatedMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Factory-activated middleware executing");
        await next(context);
    }
}

services.AddSingleton<FactoryActivatedMiddleware>();
```

### Registration Method Comparison

| Aspect | `UseMiddleware<T>()` | `Use(...)` Inline | `Run(...)` | `IMiddleware` Factory | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Testability | High | Low/Medium | Low | High | Inline is quick but harder to unit test cleanly | Use class/factory styles for production middleware |
| DI support | Full | Limited direct constructor DI | Minimal | Full + DI-controlled activation | DI improves modularity and mockability | Use DI-heavy middleware for logging/security/metrics |
| Pipeline behavior | Continues by default | Continues if `next()` called | Terminal | Continues if `next(context)` called | Terminal placement can accidentally bypass later middleware | Use `Run` only as intentional terminal component |
| Complexity | Moderate | Low | Low | Moderate | Boilerplate vs maintainability trade-off | Start inline for tiny concerns, promote to class when logic grows |

### Request Pipeline Execution and Order

Pipeline ordering determines correctness and security. A canonical order:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseTimingMiddleware();

app.MapControllers();
app.Run();
```

Why this order matters:
- Exception middleware should wrap as much of the pipeline as possible.
- Static files can execute before auth/authz to avoid unnecessary security checks for public assets.
- `UseAuthentication()` must run before `UseAuthorization()`.
- Routing metadata is established before endpoint authorization checks.

### Branching, Rejoining, and Short-Circuiting

| Aspect | `Map` | `MapWhen` | `UseWhen` | `Run` | Trade-offs | When to Use |
|---|---|---|---|---|---|---|
| Branch trigger | Path prefix | Arbitrary condition | Arbitrary condition | Always terminal | More branch power can reduce readability | Use concise conditions and document branch intent |
| Rejoins main pipeline | No | No | Yes | No | Non-rejoining branches are easier to isolate but can duplicate setup | Use `UseWhen` for additive behavior |
| Typical use | `/admin` or `/api` isolated sub-pipeline | Header/query-based branch | Conditional middleware with common tail | Final fallback response | Misuse can produce inconsistent behavior per route | Reserve `Map/MapWhen` for real isolation needs |

```csharp
app.Map("/admin", adminApp =>
{
    adminApp.UseExceptionHandler("/admin-error");
    adminApp.UseAuthentication();
    adminApp.UseAuthorization();
    adminApp.MapControllers();
});

app.MapWhen(context => context.Request.Query.ContainsKey("version"), versionApp =>
{
    versionApp.UseMiddleware<VersionMiddleware>();
});

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), apiBranch =>
{
    apiBranch.UseMiddleware<ApiHeaderMiddleware>();
});

app.UseMiddleware<CommonMiddleware>(); // Runs for all requests after UseWhen branch
```

Terminal middleware behavior:

```csharp
app.Run(async context =>
{
    await context.Response.WriteAsync("Terminal middleware - pipeline ends here");
});

// Middleware added after Run will not execute.
```

### Built-in Middleware Components

| Component | Purpose | Ordering Constraint | Common Mistake |
|---|---|---|---|
| `UseStaticFiles` | Serve CSS/JS/images without MVC overhead | Usually before auth/authz | Placing after endpoint middleware and never hitting static files |
| `UseRouting` | Resolve endpoint metadata | Before auth/authz and endpoint mapping | Running authz before route data is available |
| `UseAuthentication` | Build `HttpContext.User` | Before authz | Calling authz first and getting unexpected forbids/challenges |
| `UseAuthorization` | Enforce policies/roles/claims | After authentication | Assuming it authenticates users |
| `UseExceptionHandler` / `UseDeveloperExceptionPage` | Central exception translation | Very early | Placing too late and missing upstream exceptions |
| `UseCors` | Add CORS policy checks/headers | Before endpoints and usually after routing | Global `AllowAnyOrigin` in sensitive APIs |
| Response compression/caching middleware | Performance optimization | Before endpoints that produce large cacheable payloads | Caching personalized or non-idempotent responses |

### Exception Handling Middleware

#### Global custom exception middleware

```csharp
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            NotImplementedException => StatusCodes.Status501NotImplemented,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = _env.IsDevelopment()
            ? new { error = exception.Message, stackTrace = exception.StackTrace }
            : new { error = "An error occurred. Please try again later." };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
```

#### Built-in exception handling options

```csharp
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.Map("/error", errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerPathFeature>();
        await context.Response.WriteAsync("Error occurred");
    });
});
```

### Logging and Correlation Middleware

```csharp
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        var request = context.Request;

        _logger.LogInformation("HTTP {Method} {Path} started", request.Method, request.Path);

        try
        {
            await _next(context);

            _logger.LogInformation(
                "HTTP {Method} {Path} completed with {StatusCode} in {ElapsedMs}ms",
                request.Method,
                request.Path,
                context.Response.StatusCode,
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HTTP {Method} {Path} failed", request.Method, request.Path);
            throw;
        }
    }
}
```

```csharp
public class CorrelationMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<CorrelationMiddleware> logger)
    {
        var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault()
                           ?? Guid.NewGuid().ToString();

        context.Response.Headers["X-Correlation-ID"] = correlationId;

        using (logger.BeginScope("{CorrelationId}", correlationId))
        {
            await _next(context);
        }
    }
}
```

### Request/Response Transformation

#### Request transformation + response stream replacement

```csharp
public class RequestTransformationMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTransformationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        var originalBody = context.Response.Body;

        try
        {
            await TransformRequest(context.Request);

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            await TransformResponse(context.Response, responseBody, originalBody);
        }
        finally
        {
            context.Response.Body = originalBody;
        }
    }

    private Task TransformRequest(HttpRequest request)
    {
        if (request.ContentType?.Contains("application/json") == true)
        {
            request.Headers["X-Original-ContentType"] = request.ContentType;
        }

        return Task.CompletedTask;
    }

    private async Task TransformResponse(HttpResponse response, MemoryStream responseBody, Stream originalBody)
    {
        responseBody.Seek(0, SeekOrigin.Begin);
        var responseText = await new StreamReader(responseBody).ReadToEndAsync();

        if (!string.IsNullOrEmpty(responseText) && response.ContentType?.Contains("application/json") == true)
        {
            var transformedResponse = TransformJsonResponse(responseText);
            var bytes = Encoding.UTF8.GetBytes(transformedResponse);
            await originalBody.WriteAsync(bytes, 0, bytes.Length);
        }
        else
        {
            await responseBody.CopyToAsync(originalBody);
        }
    }

    private string TransformJsonResponse(string originalJson)
    {
        return originalJson;
    }
}
```

#### Response caching middleware pattern

```csharp
public class ResponseCachingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;

    public ResponseCachingMiddleware(RequestDelegate next, IMemoryCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var cacheKey = $"{context.Request.Path}{context.Request.QueryString}";

        if (_cache.TryGetValue(cacheKey, out byte[] cachedResponse))
        {
            context.Response.Headers["X-Cache"] = "HIT";
            await context.Response.Body.WriteAsync(cachedResponse, 0, cachedResponse.Length);
            return;
        }

        using var responseBody = new MemoryStream();
        var originalBody = context.Response.Body;
        context.Response.Body = responseBody;

        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status200OK)
        {
            var responseData = responseBody.ToArray();
            _cache.Set(cacheKey, responseData, TimeSpan.FromMinutes(5));
            context.Response.Headers["X-Cache"] = "MISS";
            await originalBody.WriteAsync(responseData, 0, responseData.Length);
        }
    }
}
```

#### Content negotiation middleware pattern

```csharp
public class ContentNegotiationMiddleware
{
    private readonly RequestDelegate _next;

    public ContentNegotiationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var acceptHeader = context.Request.Headers["Accept"].ToString();

        if (acceptHeader.Contains("application/xml"))
        {
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.ContentType = "application/xml";
                return Task.CompletedTask;
            }, context);
        }

        await _next(context);
    }
}
```

### CORS Middleware

```csharp
// ConfigureServices
services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://example.com")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Configure / Program pipeline
app.UseCors("AllowSpecificOrigin");
```

```csharp
[EnableCors("AllowSpecificOrigin")]
public class MyController : ControllerBase
{
}
```

CORS trade-off summary:
- Tight allow-list policies reduce attack surface.
- `AllowAnyOrigin` is easy for development but risky in production.
- Credentialed requests require stricter policy design.

### Authentication and Authorization Middleware

```csharp
// Configure authentication scheme
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // cookie options
    });

// Configure authorization policy
services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
    {
        policy.RequireRole("Admin");
    });
});

// Pipeline
app.UseAuthentication();
app.UseAuthorization();
```

```csharp
[Authorize(Policy = "RequireAdminRole")]
public IActionResult AdminDashboard()
{
    return View();
}
```

### Dependency Injection in Middleware

Constructor injection for app-level dependencies and method injection for request-scoped services:

```csharp
public class DependencyInjectionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISingletonService _singleton;

    public DependencyInjectionMiddleware(RequestDelegate next, ISingletonService singleton)
    {
        _next = next;
        _singleton = singleton;
    }

    public async Task InvokeAsync(HttpContext context, IScopedService scoped, ITransientService transient)
    {
        _singleton.DoWork();
        scoped.DoWork();
        transient.DoWork();

        await _next(context);
    }
}
```

Service lifetime reference:

| Lifetime | Middleware Context | Risk | Interview framing |
|---|---|---|---|
| Singleton | Safe in constructor if stateless/thread-safe | Shared mutable state bugs | "Middleware is effectively app-wide; constructor deps should be safe for concurrent requests." |
| Scoped | Inject via `InvokeAsync` parameter | Capturing scoped in singleton state | "Use per-request services in method injection." |
| Transient | New instance per resolve | Over-allocation in hot path | "Use when cheap and stateless; avoid heavy transient chains." |

### Testing Custom Middleware

```csharp
public class MiddlewareTests
{
    [Fact]
    public async Task Middleware_AddsCustomHeader()
    {
        var hostBuilder = new WebHostBuilder()
            .ConfigureServices(services => services.AddMyServices())
            .Configure(app =>
            {
                app.UseMiddleware<CustomHeaderMiddleware>();
                app.Run(async ctx => await ctx.Response.WriteAsync("Test"));
            });

        using var server = new TestServer(hostBuilder);
        var client = server.CreateClient();

        var response = await client.GetAsync("/");
        Assert.True(response.Headers.Contains("X-Custom-Header"));
    }
}
```

### Real-world Pattern: Rate Limiting Middleware

```csharp
public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;

    public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var cacheKey = $"rate_limit_{clientIp}";

        if (_cache.TryGetValue(cacheKey, out int requestCount) && requestCount > 100)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            return;
        }

        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(1)
        };

        _cache.Set(cacheKey, requestCount + 1, options);
        await _next(context);
    }
}
```

### Performance and Design Best Practices

| Aspect | Recommended Approach | Anti-pattern | Trade-offs | When to Use |
|---|---|---|---|---|
| Responsibility | Single-purpose middleware | "God middleware" doing auth+logging+transform+db | Smaller components are easier to test/reorder | Always |
| Async execution | `async/await` end-to-end | Sync blocking on body I/O | Async improves throughput; misuse causes context overhead | Any network or stream operation |
| Exception handling | Global handler early in pipeline | Per-middleware ad hoc catch + swallow | Global approach standardizes error contract | Production APIs |
| Body operations | Avoid full buffering unless required | Always reading/replacing large bodies | Buffering enables transformations but adds memory pressure | Use for specific transformation/compliance use cases |
| Security | Narrow CORS, enforce auth/authz order | Broad CORS + misplaced auth middleware | Secure defaults can reduce developer convenience | Internet-facing services |
| Observability | Structured logs + correlation ID | Unstructured console-only logs | Structured logs improve querying/alerting | Multi-service environments |

## 3. Senior Perspective (The "Why")

- Pipeline order is architecture, not style: small ordering mistakes create security bugs, unreachable branches, or missing telemetry.
- Middleware is a control plane for cross-cutting concerns: global exception handling, auth, CORS, and correlation are cheaper and more consistent here than in controllers.
- Performance sensitivity is real: request body buffering and response stream interception allocate memory; on high QPS systems this drives GC pressure and tail latency.
- Short-circuit behavior is a feature: cache hits, auth failures, and blocked paths should terminate early to save downstream compute.
- DI lifetimes matter in middleware more than in controllers because middleware components are reused widely; thread-safety and scoped usage discipline are critical.
- Evolution note (.NET Framework vs .NET 8+): modern ASP.NET Core has cleaner middleware primitives, better DI integration, endpoint routing, and built-in middleware (rate limiting, improved diagnostics) that reduce custom plumbing.

## 4. Interview Gotchas & Confusion Points

1. Thinking middleware order is "mostly preference".
Why candidates fail: they describe components but not execution graph.
Strong answer: explains pre/post flow around `await _next(...)`, ordering constraints, and concrete failure examples.

2. Mixing up `Use`, `Run`, `Map`, `MapWhen`, and `UseWhen`.
Why candidates fail: they memorize API names without branch semantics.
Strong answer: clearly states that `Run` is terminal, `Map/MapWhen` branch and do not rejoin, `UseWhen` re-joins.

3. Putting `UseAuthorization()` before `UseAuthentication()`.
Why candidates fail: they treat authorization as identity resolution.
Strong answer: authentication builds principal; authorization evaluates policy on that principal.

4. Wrong mental model for exception middleware placement.
Why candidates fail: they place handlers late and assume global coverage.
Strong answer: exception handler must wrap the pipeline early to catch downstream exceptions.

5. Reading request/response bodies without understanding buffering cost.
Why candidates fail: they implement transformation middleware that copies large payloads on every request.
Strong answer: explains memory/latency trade-offs and scopes transformations to necessary paths/content types.

6. Confusing CORS with authentication.
Why candidates fail: they expect CORS to secure APIs.
Strong answer: CORS is browser policy negotiation; auth/authz enforce identity and permissions.

7. Injecting scoped services into middleware constructors.
Why candidates fail: middleware is long-lived; constructor is not per request.
Strong answer: scoped services should be injected in `InvokeAsync` parameters.

8. Swallowing exceptions in logging middleware.
Why candidates fail: request appears successful while failures disappear.
Strong answer: log then rethrow so centralized handler can produce proper response.

9. Assuming static files always require auth.
Why candidates fail: they accidentally protect public assets or over-authenticate every static request.
Strong answer: explains intentional ordering based on asset sensitivity.

10. Returning ad hoc error payloads from different middleware/components.
Why candidates fail: clients cannot parse errors consistently.
Strong answer: enforces a stable global error contract and environment-aware detail levels.

11. Overusing inline middleware for complex logic.
Why candidates fail: difficult testing and maintainability.
Strong answer: starts inline for tiny concerns and refactors to class-based middleware with DI.

12. Ignoring route metadata timing.
Why candidates fail: trying to read endpoint info before routing runs.
Strong answer: route-aware middleware must run after `UseRouting()`.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. What is middleware in ASP.NET Core?
Answer: A pipeline component that can inspect/modify request and response, optionally call next middleware, or short-circuit.

2. Why does middleware order matter?
Answer: Registration order defines execution order; incorrect sequence can break auth, routing, exceptions, and performance behavior.

3. Difference between `Use` and `Run`?
Answer: `Use` can call `next`; `Run` is terminal.

4. Difference between `Map` and `UseWhen`?
Answer: `Map` isolates branch and does not rejoin; `UseWhen` runs conditional branch then rejoins pipeline.

5. How do you implement global exception handling?
Answer: Add early middleware with try/catch around `_next`, map exceptions to status codes, and return standardized payload.

6. How do you add request timing/logging?
Answer: Wrap `_next` with stopwatch measurement and structured logs for method/path/status/elapsed.

7. Where should CORS middleware be configured?
Answer: Configure policy in services, apply via `UseCors` in pipeline before endpoint execution.

8. How do scoped services work in middleware?
Answer: Use method injection in `InvokeAsync` for per-request scoped dependencies.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. Production API suddenly returns inconsistent auth failures. How do you debug middleware order?
Answer: Inspect `Program.cs` ordering first, verify routing/auth/authz sequence, then trace with correlation IDs and request logs.

2. A new transformation middleware increased memory and latency. What changes?
Answer: Restrict to selected routes/content types, avoid full buffering where possible, stream transform when feasible, benchmark before/after.

3. Need admin-only behavior and separate diagnostics for `/admin` routes.
Answer: Use `Map("/admin", ...)` branch with dedicated auth/error middleware and isolated policies.

4. Team asks whether to keep huge inline middleware block.
Answer: Move to class-based middleware for testability and DI; retain inline only for tiny one-off concerns.

5. Errors are logged but clients receive blank 500 bodies.
Answer: Ensure logging middleware rethrows and global exception middleware writes a consistent payload.

6. Cross-origin browser calls fail despite valid JWT.
Answer: Check CORS policy origin/method/header/credentials; JWT validity does not bypass browser CORS checks.

7. Need endpoint-specific behavior based on route metadata.
Answer: Place middleware after `UseRouting()` and use `context.GetEndpoint()` for metadata-driven logic.

8. API flood from a single client causes thread pool pressure.
Answer: Add rate limiting middleware (or built-in rate limiter), return `429`, and include observability for throttled requests.

## 6. The Revision Bank

1. What exact behavior changes if middleware omits `await _next(context)`?
2. Why is `Run` terminal while `Use` is not?
3. What is the difference between `MapWhen` and `UseWhen` in branch rejoin behavior?
4. Why should exception middleware be early in the pipeline?
5. Which middleware must execute first: authentication or authorization?
6. Why is request body buffering potentially expensive?
7. How do you attach and propagate correlation IDs?
8. When should you choose class-based middleware over inline middleware?
9. Why can scoped dependencies be problematic in middleware constructors?
10. How do you test middleware behavior without running the full app?
11. What does CORS protect against, and what does it not protect against?
12. In which position can middleware safely access `context.GetEndpoint()`?

## 7. Clarification / Suggested Additions Before Finalizing

Suggested senior-level additions for a final refinement pass:
- Built-in `.NET 8+` rate limiting middleware (`AddRateLimiter` / `UseRateLimiter`) and policy design.
- `ProblemDetails` integration for consistent exception-to-HTTP mapping.
- OpenTelemetry tracing in middleware and correlation propagation across distributed services.
- Security headers middleware (`X-Content-Type-Options`, `X-Frame-Options`, CSP) and where to place it.
- Request decompression/response compression trade-offs by payload profile.
