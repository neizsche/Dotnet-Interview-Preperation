# Dependency Injection and Configuration Interview Playbook (5 Years Experience)

## The Elevator Pitch (Executive Summary)
Dependency Injection and configuration in ASP.NET Core are less about syntax and more about controlling object lifetimes, isolation boundaries, and runtime behavior across environments. Senior candidates are expected to explain trade-offs between lifetimes, registration styles, and configuration sources, especially how these decisions affect thread safety, memory pressure, and production reliability. Interviewers look for practical judgment: avoiding captive dependencies, validating options early, and keeping dependency graphs explicit and testable.

## Structured Study Material

### 1) Service Lifetimes and Instance Semantics

| Aspect | Transient | Scoped | Singleton | Trade-offs / When to Use |
|---|---|---|---|---|
| Instance creation | New every resolve | One per scope/request | One for app lifetime | Choose based on state sharing and cost to create |
| Memory profile | Highest churn | Medium | Lowest churn | Transient can increase allocation pressure |
| Thread-safety need | Usually lower risk | Request-bound | Critical | Singleton must be thread-safe |
| Disposal point | End of usage chain | End of scope | App shutdown | Wrong lifetime can delay or misalign disposal |
| Typical use cases | Stateless lightweight services | `DbContext`, unit-of-work, request context | Caches, config, expensive shared services | Match lifetime to data consistency boundary |

Registration syntax:

```csharp
services.AddTransient<IService, ServiceImplementation>();
services.AddScoped<IService, ServiceImplementation>();
services.AddSingleton<IService, ServiceImplementation>();
```

Lifetime behavior illustration:

```csharp
public class TransientService : ITransientService
{
    private readonly Guid _id = Guid.NewGuid();
    public Guid GetId() => _id;
}

public class ScopedService : IScopedService
{
    private readonly Guid _id = Guid.NewGuid();
    public Guid GetId() => _id;
}

public class SingletonService : ISingletonService
{
    private readonly Guid _id = Guid.NewGuid();
    public Guid GetId() => _id;
}
```

### 2) Lifetime Hazards and Scope Management

#### Captive Dependency Problem

| Scenario | Why It Is Risky | Fix Pattern |
|---|---|---|
| Singleton captures Transient/Scoped dependency in constructor | Shorter-lived dependency becomes effectively long-lived; stale state and hidden coupling | Align lifetimes, or create explicit scope at operation time |

```csharp
// WRONG: Singleton capturing transient
public class SingletonService
{
    private readonly ITransientService _transient;

    public SingletonService(ITransientService transient)
    {
        _transient = transient;
    }
}
```

#### Resolving Scoped from Singleton Safely

```csharp
public class SingletonService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SingletonService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void ProcessRequest()
    {
        using var scope = _scopeFactory.CreateScope();
        var scopedService = scope.ServiceProvider.GetService<IScopedService>();
        // Use scopedService
    }
}
```

Manual scope creation pattern:

```csharp
using (var scope = serviceProvider.CreateScope())
{
    var scopedService = scope.ServiceProvider.GetService<IScopedService>();
}
```

### 3) Service Registration Strategies

#### Core Registration Patterns

| Pattern | Syntax | When to Use |
|---|---|---|
| Interface -> implementation | `AddTransient<IService, ServiceImplementation>()` | Default for abstraction-driven design |
| Concrete type registration | `AddTransient<ServiceImplementation>()` | Internal implementations injected directly |
| Existing instance registration | `AddSingleton<IService>(instance)` | External object already created |
| Factory-based registration | `AddTransient<IService>(provider => ...)` | Dynamic creation using runtime state/dependencies |

```csharp
services.AddTransient<IService, ServiceImplementation>();
services.AddTransient<ServiceImplementation>();

var instance = new ServiceImplementation();
services.AddSingleton<IService>(instance);

services.AddTransient<IService>(provider =>
{
    var dependency = provider.GetService<IDependency>();
    return new ServiceImplementation(dependency);
});
```

#### Advanced Registration Patterns

| Pattern | Syntax | Trade-off |
|---|---|---|
| Conditional registration | Factory checks environment | Flexible but can hide policy complexity |
| Multiple implementations | Register many; consume `IEnumerable<T>` | Good extensibility, requires deterministic ordering rules |
| Open generic registration | `AddTransient(typeof(IRepository<>), typeof(Repository<>))` | Scales generic abstractions cleanly |

```csharp
services.AddTransient<IService>(provider =>
{
    var env = provider.GetService<IWebHostEnvironment>();
    return env.IsDevelopment()
        ? new DevelopmentService()
        : new ProductionService();
});

services.AddTransient<IService, ServiceA>();
services.AddTransient<IService, ServiceB>();

public class Consumer
{
    private readonly IEnumerable<IService> _services;
    public Consumer(IEnumerable<IService> services) => _services = services;
}

services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
```

#### Factory Patterns in DI

```csharp
public interface IServiceFactory
{
    IService CreateService(string type);
}

services.AddTransient<IServiceFactory, ServiceFactory>();
```

```csharp
public delegate IService ServiceFactory(string type);

services.AddTransient<ServiceA>();
services.AddTransient<ServiceB>();
services.AddTransient<ServiceFactory>(provider => type =>
{
    return type switch
    {
        "A" => provider.GetService<ServiceA>(),
        "B" => provider.GetService<ServiceB>(),
        _ => throw new ArgumentException($"Unknown service type: {type}")
    };
});
```

#### `Add` vs `TryAdd` and Singleton Overload Differences

| Comparison | Behavior | Interview Expectation |
|---|---|---|
| `Add...` vs `TryAdd...` | `Add` always registers; `TryAdd` skips if service already registered | Use `TryAdd` in libraries to avoid overriding app-level registrations |
| `AddSingleton<TService>()` vs `AddSingleton<TService>(instance)` | Type-based registration lets container manage creation lifecycle; instance overload registers an existing object that is typically externally owned | Know ownership/disposal implications for externally created instances |

```csharp
services.AddTransient<IService, ServiceA>();
services.TryAddTransient<IService, ServiceB>(); // ServiceB not added here
```

### 4) Constructor vs Property Injection

| Aspect | Constructor Injection | Property Injection | Trade-offs / Guidance |
|---|---|---|---|
| Dependency visibility | Explicit in constructor | Hidden/late-bound | Constructor injection preferred for required dependencies |
| Immutability | Strong | Weak | Required dependencies should be immutable |
| Compile-time safety | High | Lower | Missing required deps easier to catch with constructor injection |
| Framework usage | Default | Common in specific framework hooks | Property injection acceptable for optional/framework-provided dependencies |
| Circular dependency pressure | Hard to hide cycles | Can mask cycles | Redesign for explicit acyclic graph |

Constructor injection example:

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository repository, ILogger<OrderService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}
```

Property injection example:

```csharp
public class OrderService
{
    [FromServices]
    public IOrderRepository Repository { get; set; }

    [FromServices]
    public ILogger<OrderService> Logger { get; set; }
}
```

Required-vs-optional dependency pattern:

```csharp
public class Service
{
    private readonly IRequiredService _required;
    private IOptionalService _optional;

    public Service(IRequiredService required)
    {
        _required = required;
    }

    public IOptionalService Optional
    {
        get => _optional ??= GetDefaultOptional();
        set => _optional = value;
    }
}
```

Optional dependency handling with constructor overload/default:

```csharp
public class OptionalExample
{
    private readonly IOptionalService _optional;

    public OptionalExample(IRequiredService required, IOptionalService optional = null)
    {
        _optional = optional ?? new DefaultOptionalService();
    }
}

public class OptionalExampleWithOverload
{
    private readonly IOptionalService _optional;

    public OptionalExampleWithOverload(IRequiredService required)
        : this(required, new DefaultOptionalService()) { }

    public OptionalExampleWithOverload(IRequiredService required, IOptionalService optional)
    {
        _optional = optional;
    }
}
```

### 5) Options Pattern and Typed Configuration

#### Basic Options Binding

```csharp
public class ApiSettings
{
    public string BaseUrl { get; set; }
    public int TimeoutSeconds { get; set; }
    public int RetryCount { get; set; }
}
```

```json
{
  "ApiSettings": {
    "BaseUrl": "https://api.example.com",
    "TimeoutSeconds": 30,
    "RetryCount": 3
  }
}
```

```csharp
services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

public class ApiClient
{
    private readonly ApiSettings _settings;

    public ApiClient(IOptions<ApiSettings> options)
    {
        _settings = options.Value;
    }
}
```

#### `IOptions<T>` vs `IOptionsSnapshot<T>` vs `IOptionsMonitor<T>`

| Interface | Lifetime Semantics | Change Behavior | Best Fit |
|---|---|---|---|
| `IOptions<T>` | Singleton access pattern | No runtime refresh | Static config during app run |
| `IOptionsSnapshot<T>` | Scoped | Refreshed per request | Request-scoped services needing latest values |
| `IOptionsMonitor<T>` | Singleton | Push-style change notifications | Long-lived services reacting to config changes |

```csharp
public class SnapshotConsumer
{
    private readonly ApiSettings _settings;

    public SnapshotConsumer(IOptionsSnapshot<ApiSettings> snapshot)
    {
        _settings = snapshot.Value;
    }
}

public class MonitorConsumer : IDisposable
{
    private ApiSettings _settings;
    private readonly IDisposable _changeToken;

    public MonitorConsumer(IOptionsMonitor<ApiSettings> monitor)
    {
        _settings = monitor.CurrentValue;
        _changeToken = monitor.OnChange(settings =>
        {
            _settings = settings;
        });
    }

    public void Dispose() => _changeToken?.Dispose();
}
```

#### Options Validation

```csharp
public class ApiSettings : IValidatableObject
{
    [Required]
    [Url]
    public string BaseUrl { get; set; }

    [Range(1, 60)]
    public int TimeoutSeconds { get; set; }

    public int RetryCount { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (TimeoutSeconds > 30 && RetryCount > 5)
        {
            yield return new ValidationResult("Timeout too long for many retries");
        }
    }
}

services.AddOptions<ApiSettings>()
    .Bind(Configuration.GetSection("ApiSettings"))
    .ValidateDataAnnotations()
    .Validate(settings => !string.IsNullOrEmpty(settings.BaseUrl))
    .ValidateOnStart();
```

### 6) Configuration Providers and Precedence

#### Provider Comparison

| Provider | Typical Role | Priority Behavior |
|---|---|---|
| `appsettings.json` | Baseline defaults | Lower precedence |
| `appsettings.{Environment}.json` | Environment overrides | Overrides base JSON |
| User secrets | Dev-time secret storage | Overrides JSON in development |
| Environment variables | Runtime/infrastructure overrides | Usually high precedence |
| Command line | Per-run explicit overrides | Typically highest precedence |
| Custom provider | Domain-specific source (DB, remote store) | Depends on insertion order |

Built-in provider usage:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddUserSecrets<Program>();
```

Configuration precedence rule (last provider wins):

```csharp
builder.Configuration
    .AddJsonFile("appsettings.json")                    // Lowest
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()                           // Higher
    .AddCommandLine(args)                                // Highest (typical)
    .AddUserSecrets<Program>();                          // Development context
```

Environment variable override example:

```text
MYAPP_APISETTINGS__BASEURL=https://override.com
```

#### Custom Configuration Provider Pattern

```csharp
public class DatabaseConfigurationProvider : ConfigurationProvider
{
    private readonly string _connectionString;

    public DatabaseConfigurationProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public override void Load()
    {
        using var connection = new SqlConnection(_connectionString);
        var settings = connection.Query<KeyValuePair<string, string>>(
            "SELECT Key, Value FROM Settings");

        Data = settings.ToDictionary(x => x.Key, x => x.Value);
    }
}

public class DatabaseConfigurationSource : IConfigurationSource
{
    private readonly string _connectionString;

    public DatabaseConfigurationSource(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new DatabaseConfigurationProvider(_connectionString);
    }
}

public static class DatabaseConfigurationExtensions
{
    public static IConfigurationBuilder AddDatabaseConfiguration(
        this IConfigurationBuilder builder,
        string connectionString)
    {
        return builder.Add(new DatabaseConfigurationSource(connectionString));
    }
}

builder.Configuration.AddDatabaseConfiguration("Server=...");
```

Reloadable custom provider concept:

```csharp
public class ReloadableDatabaseConfigurationProvider : ConfigurationProvider, IDisposable
{
    private readonly Timer _timer;

    public ReloadableDatabaseConfigurationProvider()
    {
        _timer = new Timer(Reload, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    }

    private void Reload(object state) => Load();

    public void Dispose() => _timer?.Dispose();
}
```

### 7) Dependency Graph Health and Anti-Patterns

#### Circular Dependency Resolution

```csharp
public interface ICommonFunctionality { }
public class CommonService : ICommonFunctionality { }

public class ServiceA
{
    public ServiceA(ServiceB b, ICommonFunctionality common) { }
}

public class ServiceB
{
    public ServiceB(ICommonFunctionality common) { }
}
```

#### Disposal Semantics

| Scenario | Disposal Behavior |
|---|---|
| Container-created `Transient`/`Scoped` implementing `IDisposable` | Disposed automatically at appropriate boundary |
| Container-managed singleton implementing `IDisposable` | Disposed when container shuts down |
| Factory-created/manual instances | Often require explicit manual disposal |

```csharp
using (var service = factory.CreateService())
{
    // manual lifecycle ownership path
}
```

#### Service Locator Anti-Pattern vs Proper DI

```csharp
// ANTI-PATTERN
public class BadService
{
    private readonly IServiceProvider _provider;

    public void DoWork()
    {
        var dependency = _provider.GetService<IDependency>();
    }
}

// PROPER
public class GoodService
{
    private readonly IDependency _dependency;

    public GoodService(IDependency dependency)
    {
        _dependency = dependency;
    }
}
```

## Senior Perspective (The "Why")

- Lifetime modeling is a correctness boundary: wrong lifetimes create stale state bugs, hidden sharing, or avoidable allocation churn.
- Captive dependencies are architecture smells that often pass tests but fail under concurrent production load.
- DI registration style impacts maintainability: factory-heavy registration is powerful, but can hide business rules in container setup and reduce discoverability.
- Constructor injection preserves explicit contracts and makes failure modes deterministic; property/service-locator patterns increase runtime ambiguity.
- Options design is operational design: choosing between snapshot and monitor determines whether config changes are pull-based per request or push-based across singleton services.
- Early options validation (`ValidateOnStart`) converts runtime incidents into startup failures, which is usually safer in CI/CD environments.
- Configuration precedence is a deployment control plane. Teams that cannot explain “who wins” between providers usually ship environment drift bugs.
- Custom configuration providers should include reload/error strategy and observability; otherwise they become silent runtime risk.

## Interview Gotchas & Confusion Points

- Captive dependency trap: “it compiles, so it is fine” is not enough. A singleton holding scoped/transient state can create stale data, memory retention, and hard-to-reproduce concurrency defects.
- Scoped-in-singleton trap: injecting scoped services directly into singleton constructors is invalid by design; use `IServiceScopeFactory` at execution time.
- Lifetime oversimplification trap: candidates choose singleton for performance by default. Interviewers expect discussion of thread safety, mutability, and state isolation boundaries.
- Constructor vs property trap: using property injection for required dependencies hides contracts and shifts failures to runtime null issues.
- Service locator trap: resolving dependencies from `IServiceProvider` inside methods hides dependency graph intent and weakens testability.
- Factory overuse trap: factory registrations solve specific cases, but overusing them can turn DI configuration into untraceable business logic.
- `Add` vs `TryAdd` confusion: many candidates miss that library code should often avoid clobbering app registrations and prefer `TryAdd` semantics.
- `AddSingleton(instance)` ownership trap: externally created instances have different lifecycle ownership expectations than container-created objects.
- Options interface mismatch trap: using `IOptionsSnapshot<T>` in singleton services is a scope mismatch; use `IOptionsMonitor<T>` when singleton change tracking is required.
- Validation timing trap: validating options lazily in first request delays failure detection. Startup validation is often preferred for operational safety.
- Precedence misconception trap: teams assume environment variables always win, but precedence is determined by provider order (last added wins).
- User secrets misuse trap: user secrets are for development convenience and not a production secret-management strategy.
- Circular dependency workaround trap: using property injection to “fix” cycles usually hides design coupling; better approach is boundary refactoring.
- Disposal misunderstanding trap: container only disposes what it owns; manual/factory-created resources still need explicit cleanup.

## Tiered Interview Q&A

### Mid-Level: Foundational "How it works" questions

1. What is the difference between transient, scoped, and singleton lifetimes?
2. Why is `DbContext` typically registered as scoped?
3. What is constructor injection and why is it preferred for required dependencies?
4. When is property injection acceptable?
5. What is the difference between `Add` and `TryAdd` registration methods?
6. How do you register multiple implementations and consume all of them?
7. What is an open generic registration in DI?
8. What is the difference between `IOptions<T>`, `IOptionsSnapshot<T>`, and `IOptionsMonitor<T>`?
9. How do you validate options at startup?
10. What is configuration provider precedence and how is it determined?
11. What does user secrets solve, and what does it not solve?
12. Why is service locator considered an anti-pattern in most business services?

### Senior/Lead: Scenario-based "Design & Troubleshooting" questions

1. A singleton depends on a transient service and shows stale behavior in production. How would you diagnose and redesign this?
2. A background singleton needs request-scoped dependencies. How would you apply scope factory safely without leaking scopes?
3. Your app supports plugin-like strategy selection by key. Would you use delegate factories, `IEnumerable<T>`, or keyed abstractions, and why?
4. Configuration changed at runtime, but singleton consumers do not update. How do you choose between snapshot and monitor patterns?
5. Startup fails after introducing `ValidateOnStart`. How do you separate real validation failures from environment bootstrap ordering issues?
6. A production environment ignores expected environment variable overrides. What precedence and provider-order checks do you run first?
7. You inherited heavy service-locator usage in a core domain service. How do you migrate incrementally to explicit DI without destabilizing releases?
8. Circular dependency exceptions appear after refactoring. How do you redesign boundaries instead of introducing brittle workarounds?
9. A custom DB-backed configuration provider causes intermittent startup slowness. How do you add resilience, caching, and observability?
10. Multiple `IService` implementations exist and resolution order now affects business results. How do you make behavior deterministic?
11. Memory increases over time after adding singleton caches and monitor callbacks. Which lifecycle and disposal assumptions would you verify?
12. You are building a reusable library: when should it use `TryAdd` vs explicit `Add` registrations?

## The Revision Bank

1. What lifetime should be used for request-specific state and why?
2. What is a captive dependency, and how do you fix it?
3. Why is constructor injection usually safer than property injection?
4. How do `Add` and `TryAdd` differ in registration behavior?
5. When is `IOptionsMonitor<T>` preferable to `IOptionsSnapshot<T>`?
6. Why is `ValidateOnStart()` operationally valuable?
7. What does “last provider wins” mean in configuration precedence?
8. How do you override JSON config via environment variables?
9. What is the core risk of service locator in application services?
10. How does open generic registration reduce boilerplate?
11. Which resources are auto-disposed by the container vs manually disposed by your code?
12. How do you break circular dependencies without masking design problems?

## Clarification / Suggested Additions Before Finalizing

To make this note stronger for senior interviews, consider adding:
- keyed services and named strategy patterns in modern .NET;
- assembly scanning/registration conventions and startup-time trade-offs;
- secret management patterns (vault/app configuration services) beyond user secrets;
- DI diagnostics, service validation (`ValidateScopes`/`ValidateOnBuild`), and startup health checks.

If you want, I can add a compact advanced addendum in the same playbook format.
