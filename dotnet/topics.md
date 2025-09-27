# Complete .NET Topics Checklist for 4+ Years Experience

## 1. C# Language Fundamentals
- [ ] **Data Types and Variables**
  - [ ] Value types vs Reference types
  - [ ] Built-in types (int, string, bool, DateTime, decimal)
  - [ ] Nullable value types
  - [ ] var keyword and type inference
  - [ ] Dynamic typing (dynamic keyword)

- [ ] **Operators and Expressions**
  - [ ] Arithmetic, relational, logical operators
  - [ ] Null-conditional operator (?.)
  - [ ] Null-coalescing operator (??)
  - [ ] Ternary operator
  - [ ] Operator overloading

- [ ] **Control Flow Statements**
  - [ ] if-else, switch statements
  - [ ] for, foreach, while, do-while loops
  - [ ] break, continue, goto
  - [ ] Pattern matching (C# 7.0+)

- [ ] **Methods and Parameters**
  - [ ] Method overloading
  - [ ] Optional and named parameters
  - [ ] params keyword
  - [ ] ref, out, in parameters
  - [ ] Local functions

- [ ] **Arrays and Collections**
  - [ ] Single and multi-dimensional arrays
  - [ ] List<T>, Dictionary<TKey, TValue>, HashSet<T>
  - [ ] IEnumerable vs ICollection vs IList
  - [ ] Collection initializers
  - [ ] Collection interfaces hierarchy

## 2. Object-Oriented Programming (OOP)
- [ ] **Classes and Objects**
  - [ ] Constructors (default, parameterized, static, private)
  - [ ] Properties (auto-implemented, computed, expression-bodied)
  - [ ] Fields vs Properties
  - [ ] Access modifiers (public, private, protected, internal, protected internal)
  - [ ] Partial classes and methods

- [ ] **Inheritance**
  - [ ] Base and derived classes
  - [ ] sealed keyword
  - [ ] base keyword usage
  - [ ] Constructor chaining

- [ ] **Polymorphism**
  - [ ] Method overriding (virtual, override)
  - [ ] Method hiding (new keyword)
  - [ ] Abstract classes and methods
  - [ ] Runtime vs compile-time polymorphism

- [ ] **Interfaces**
  - [ ] Interface implementation
  - [ ] Explicit interface implementation
  - [ ] Interface inheritance
  - [ ] Default interface methods (C# 8.0+)
  - [ ] Interface segregation principle

- [ ] **Encapsulation and Abstraction**
  - [ ] Property accessors (get, set, init)
  - [ ] Readonly fields and structs
  - [ ] Constants vs readonly
  - [ ] Accessor accessibility levels

## 3. Advanced C# Features
- [ ] **Generics**
  - [ ] Generic classes and methods
  - [ ] Constraints (where T : class, new(), struct, etc.)
  - [ ] Covariance and contravariance (in/out)
  - [ ] Generic type inference
  - [ ] Generic variance in interfaces and delegates

- [ ] **Delegates and Events**
  - [ ] Delegate types and declarations
  - [ ] Action, Func, Predicate delegates
  - [ ] Event handlers and patterns
  - [ ] Anonymous methods and lambda expressions
  - [ ] Multicast delegates

- [ ] **Lambda Expressions and Expression Trees**
  - [ ] Expression lambdas vs statement lambdas
  - [ ] Lambda expression trees
  - [ ] Expression tree compilation
  - [ ] Dynamic LINQ queries

- [ ] **LINQ (Language Integrated Query)**
  - [ ] Query syntax vs method syntax
  - [ ] Standard query operators (Where, Select, GroupBy, Join, Aggregate)
  - [ ] Deferred execution vs immediate execution
  - [ ] Select vs SelectMany
  - [ ] LINQ providers (LINQ to Objects, LINQ to Entities, LINQ to XML)

- [ ] **Exception Handling**
  - [ ] try-catch-finally blocks
  - [ ] Exception filters (when keyword)
  - [ ] Custom exception classes
  - [ ] throw vs throw ex
  - [ ] Exception handling best practices

- [ ] **Attributes and Reflection**
  - [ ] Custom attribute creation
  - [ ] Reflection for type inspection and dynamic invocation
  - [ ] Dynamic type creation (AssemblyBuilder, TypeBuilder)
  - [ ] Attribute usage and targets

## 4. Memory Management and Performance
- [ ] **Garbage Collection Deep Dive**
  - [ ] GC Generations (Gen 0, 1, 2) and Large Object Heap (LOH)
  - [ ] Workstation GC vs Server GC
  - [ ] Concurrent GC vs Background GC
  - [ ] GC latency modes (LowLatency, SustainedLowLatency)
  - [ ] Forced garbage collection (GC.Collect()) and best practices

- [ ] **Memory Management Patterns**
  - [ ] IDisposable pattern implementation
  - [ ] using statement and declaration
  - [ ] Object pooling strategies
  - [ ] Weak references and caching strategies
  - [ ] Finalization and resurrection

- [ ] **High-Performance Coding**
  - [ ] Span<T> and Memory<T> usage
  - [ ] SIMD operations with Vector<T>
  - [ ] ArrayPool<T> and MemoryPool<T>
  - [ ] Zero-allocation coding techniques
  - [ ] Stackalloc and unsafe code

## 5. CLR (Common Language Runtime) Internals
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

## 6. .NET Framework/Core Fundamentals
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

## 7. ASP.NET Core Web API
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
  - [ ] Configuration providers and custom configuration

## 8. Entity Framework Core
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

## 9. Testing in .NET
- [ ] **Unit Testing Fundamentals**
  - [ ] xUnit, NUnit, or MSTest frameworks
  - [ ] Test classes, methods, and fixtures
  - [ ] Assertions and test patterns (AAA pattern)
  - [ ] Test data generation and theories

- [ ] **Mocking and Test Doubles**
  - [ ] Moq framework and mocking techniques
  - [ ] Mocking dependencies and verifying interactions
  - [ ] Test isolation and setup/teardown
  - [ ] Fake implementations and test doubles

- [ ] **Integration and Functional Testing**
  - [ ] Testing with real databases
  - [ ] WebApplicationFactory for API testing
  - [ ] Test containers for database testing
  - [ ] End-to-end testing strategies

## 10. Security
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

## 11. Performance and Optimization
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
  - [ ] Performance profiling and benchmarking

## 12. Design Patterns and Principles
- [ ] **SOLID Principles**
  - [ ] Single Responsibility Principle
  - [ ] Open/Closed Principle
  - [ ] Liskov Substitution Principle
  - [ ] Interface Segregation Principle
  - [ ] Dependency Inversion Principle

- [ ] **Architectural Patterns**
  - [ ] Repository Pattern and Unit of Work
  - [ ] Specification Pattern
  - [ ] Mediator Pattern (MediatR)
  - [ ] CQRS (Command Query Responsibility Segregation)
  - [ ] Event Sourcing

- [ ] **Design Patterns Implementation**
  - [ ] Factory Method and Abstract Factory
  - [ ] Builder and Fluent Interface
  - [ ] Strategy and Template Method
  - [ ] Observer and Publisher-Subscriber
  - [ ] Decorator and Composite

## 13. Advanced Architecture
- [ ] **Microservices Architecture**
  - [ ] Service decomposition and bounded contexts
  - [ ] Inter-service communication (gRPC, Message Queues)
  - [ ] Distributed transactions and Saga pattern
  - [ ] API Gateway and service discovery
  - [ ] Circuit breaker and retry patterns

- [ ] **Domain-Driven Design (DDD)**
  - [ ] Strategic Design (Bounded Contexts, Context Mapping)
  - [ ] Tactical Design (Entities, Value Objects, Aggregates)
  - [ ] Domain Events and event-driven architecture
  - [ ] Hexagonal Architecture (Ports and Adapters)

- [ ] **Cloud-Native Development**
  - [ ] Containerization with Docker
  - [ ] Kubernetes orchestration and Helm charts
  - [ ] Serverless functions and cloud services
  - [ ] Infrastructure as Code (Terraform, Bicep)

## 14. DevOps and Deployment
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

## 15. Advanced Topics
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

## 16. Cross-Cutting Concerns
- [ ] **Middleware Development**
  - [ ] Custom middleware components
  - [ ] Middleware pipeline order and branching
  - [ ] Exception handling and logging middleware
  - [ ] Request/response transformation

- [ ] **API Design and Versioning**
  - [ ] RESTful API design principles
  - [ ] API versioning strategies (URL, header, query)
  - [ ] Hypermedia and HATEOAS
  - [ ] API documentation with Swagger/OpenAPI
