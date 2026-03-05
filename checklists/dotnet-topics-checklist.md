# .NET Topics Checklist


## .NET Framework/Core Fundamentals
- [ ] **Runtime Versions and Compatibility**
  - [ ] .NET Framework vs .NET Core vs .NET 5+ differences
  - [ ] Side-by-side execution
  - [ ] Target framework monikers (TFMs)
  - [ ] Runtime configuration (.runtimeconfig.json)

- [ ] **Assembly and Type System**
  - [ ] Assembly metadata and manifests
  - [ ] Type forwarding
  - [ ] Friend assemblies (InternalsVisibleTo)
  - [ ] Custom attribute discovery

## Memory Management & Performance
- [ ] Garbage Collection (Generations: Gen 0, 1, 2)
- [ ] Stack vs Heap allocation
- [ ] IDisposable interface and using statement
- [ ] Finalizers vs Destructors
- [ ] Boxing and Unboxing
- [ ] String interning and StringBuilder
- [ ] Weak references (WeakReference, WeakReference<T>)
- [ ] Memory<T> and Span<T> advanced usage
- [ ] Array segment and memory slicing
- [ ] Unmanaged memory allocation with Marshal
- [ ] Object pooling
- [ ] ArrayPool<T>
- [ ] Struct layout (StructLayout, FieldOffset)
- [ ] Volatile keyword and memory barriers
- [ ] SkipLocalsInit attribute
- [ ] AggressiveInlining method attribute
- [ ] Stack-based value types optimization
- [ ] Large Object Heap (LOH) and fragmentation
- [ ] GC collection modes (Optimized, SustainedLowLatency)

## CLR (Common Language Runtime) Internals
- [ ] **CLR Architecture**
  - [ ] Just-In-Time (JIT) compilation process
  - [ ] Managed vs unmanaged code execution
  - [ ] Common Type System (CTS)
  - [ ] Common Language Specification (CLS)
  - [ ] Application Domains (AppDomains) and Assembly Load Contexts

- [ ] **Assembly Loading and Execution**
  - [ ] Assembly resolution process (Fusion Log)
  - [ ] Strong naming and versioning
  - [ ] Global Assembly Cache (GAC)
  - [ ] Assembly binding redirects

- [ ] **Intermediate Language (IL)**
  - [ ] IL instruction set basics
  - [ ] Using ILDasm/ILAsm tools
  - [ ] Performance implications of IL patterns
  - [ ] JIT optimization techniques

## ASP.NET Core Web API
- [ ] **Application Structure and Hosting**
  - [ ] Program.cs and Startup.cs configuration
  - [ ] Middleware pipeline and order
  - [ ] Host configuration and environment settings
  - [ ] Kestrel vs IIS hosting

- [ ] **Controllers and Routing**
  - [ ] ControllerBase vs Controller usage
  - [ ] Attribute routing and route templates
  - [ ] Route constraints and custom constraints
  - [ ] Action results (IActionResult, ActionResult<T>)
  - [ ] API convention classes

- [ ] **Model Binding and Validation**
  - [ ] FromBody, FromQuery, FromRoute, FromHeader attributes
  - [ ] Model validation with DataAnnotations
  - [ ] Custom validation attributes and IValidatableObject
  - [ ] ModelState validation and custom model binders

- [ ] **Dependency Injection and Configuration**
  - [ ] Service lifetimes (Transient, Scoped, Singleton)
  - [ ] Service registration methods and factory patterns
  - [ ] Constructor injection and property injection
  - [ ] Options pattern and IOptions<T>
  - [ ] Configuration binding patterns
  - [ ] Configuration providers and custom configuration
  - [ ] Service provider and scope management
  - [ ] Disposable service handling
  - [ ] Lazy service resolution (Lazy<T>, Func<T>)
  - [ ] Custom DI container behaviors

## Entity Framework Core
- [ ] **DbContext and Data Modeling**
  - [ ] DbContext configuration and lifetime management
  - [ ] DbSet operations and change tracking
  - [ ] Code First vs Database First approaches
  - [ ] Data annotations and Fluent API configuration
  - [ ] Relationships (one-to-many, many-to-many, one-to-one)

- [ ] **Querying and Performance**
  - [ ] LINQ to Entities translation and limitations
  - [ ] Eager loading (Include, ThenInclude) vs Explicit loading
  - [ ] Raw SQL queries and stored procedures
  - [ ] Query performance optimization and indexing
  - [ ] No-tracking queries and AsNoTracking()

- [ ] **Transactions and Concurrency**
  - [ ] Transaction management strategies
  - [ ] Concurrency conflict handling
  - [ ] SaveChanges vs SaveChangesAsync patterns
  - [ ] Resilient connections and execution strategies

- [ ] **Migrations and Database Management**
  - [ ] Creating and applying migrations
  - [ ] Migration scripts and version control
  - [ ] Seeding data and initialization
  - [ ] Database provider-specific configurations

## Testing in .NET
- [ ] **Unit Testing Fundamentals**
  - [ ] xUnit, NUnit, or MSTest frameworks
  - [ ] Test classes, methods, and fixtures
  - [ ] Assertions and test patterns (AAA pattern)
  - [ ] Test data generation and theories
  - [ ] Async testing patterns
  - [ ] Testing private/internal members (InternalsVisibleTo/reflection tradeoffs)
  - [ ] Test parallelization and isolation

- [ ] **Mocking and Test Doubles**
  - [ ] Moq framework and mocking techniques
  - [ ] Mocking dependencies and verifying interactions
  - [ ] Test isolation and setup/teardown
  - [ ] Fake implementations and test doubles
  - [ ] Test data builders

- [ ] **Integration and Functional Testing**
  - [ ] Testing with real databases
  - [ ] WebApplicationFactory for API testing
  - [ ] Test containers for database testing
  - [ ] End-to-end testing strategies

## Security
- [ ] **Authentication and Authorization**
  - [ ] JWT (JSON Web Tokens) and bearer authentication
  - [ ] Cookie authentication and claims transformation
  - [ ] Identity framework and custom stores
  - [ ] Role-based and policy-based authorization
  - [ ] External providers (OAuth 2.0, OpenID Connect)

- [ ] **Application Security**
  - [ ] OWASP Top 10 implementation defenses
  - [ ] Input validation and sanitization
  - [ ] CSRF protection and anti-forgery tokens
  - [ ] Secure headers and HTTPS enforcement

- [ ] **Data Protection**
  - [ ] Hashing and salting passwords (BCrypt, PBKDF2)
  - [ ] Encryption and decryption strategies
  - [ ] Secure storage of secrets and connection strings
  - [ ] Data Protection API (IDataProtector)

## Performance and Optimization
- [ ] **Caching Strategies**
  - [ ] MemoryCache and distributed caching
  - [ ] Redis integration and clustering
  - [ ] Response caching and cache headers
  - [ ] Cache invalidation patterns and strategies

- [ ] **Asynchronous Programming**
  - [ ] async/await patterns and best practices
  - [ ] Task Parallel Library (TPL) and Dataflow
  - [ ] ConfigureAwait best practices
  - [ ] Async streams (IAsyncEnumerable) and cancellation

- [ ] **Performance Best Practices**
  - [ ] String manipulation and StringBuilder usage
  - [ ] Object pooling and resource management
  - [ ] Lazy initialization and lazy caching
  - [ ] Logging performance considerations
  - [ ] Performance profiling and benchmarking


## DevOps and Deployment
- [ ] **CI/CD Pipelines**
  - [ ] Azure DevOps/GitHub Actions pipelines
  - [ ] Build and release strategies
  - [ ] Automated testing in pipelines
  - [ ] Blue-green and canary deployments

- [ ] **Monitoring and Observability**
  - [ ] Application Insights and logging
  - [ ] Distributed tracing and correlation IDs
  - [ ] Health checks and readiness probes
  - [ ] Performance counters and metrics

## Advanced Topics
- [ ] **Message Brokers and Event-Driven Architecture**
  - [ ] Azure Service Bus and RabbitMQ
  - [ ] Event-driven architecture patterns
  - [ ] Message ordering and idempotency
  - [ ] Dead letter queues and retry policies

- [ ] **Advanced Serialization**
  - [ ] System.Text.Json customization
  - [ ] Protocol Buffers and gRPC
  - [ ] Custom serializers and formatters
  - [ ] Version tolerant serialization

- [ ] **Internationalization and Localization**
  - [ ] Resource files and satellite assemblies
  - [ ] Culture-specific formatting
  - [ ] Right-to-left language support
  - [ ] Globalization and localization best practices

## Cross-Cutting Concerns
- [ ] **Middleware Development**
  - [ ] Custom middleware components
  - [ ] Middleware pipeline order and branching
  - [ ] Exception handling and logging middleware
  - [ ] Request/response logging middleware
  - [ ] Correlation ID propagation middleware
  - [ ] Request/response transformation

- [ ] **API Design and Versioning**
  - [ ] RESTful API design principles
  - [ ] API versioning strategies (URL, header, query)
  - [ ] Hypermedia and HATEOAS
  - [ ] API documentation with Swagger/OpenAPI

- [ ] **Operational and Cross-Cutting Patterns**
  - [ ] Background service patterns (IHostedService, BackgroundService)
  - [ ] Feature flag implementation and rollout strategy
  - [ ] Configuration management across environments
  - [ ] Validation patterns and techniques beyond DataAnnotations
  - [ ] Accessibility in API design and documentation
