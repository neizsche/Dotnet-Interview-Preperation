# Architectural Patterns Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Repository/UoW, Specification, Mediator, CQRS, and Event Sourcing are high-leverage architecture patterns for complex .NET backends where domain complexity, scalability, and auditability matter. Senior usage is contextual: each pattern adds structure and testability, but also indirection, consistency complexity, and operational cost. Strong interview answers explain why to combine them, when to avoid them, and how to handle concurrency, transactions, schema evolution, and performance.

## 2. Structured Study Material

### 2.1 Pattern Landscape

| Pattern | Primary Purpose | Complexity | Performance Impact | Typical Use Cases |
|---|---|---|---|---|
| Repository + Unit of Work | Abstract data access + transactional consistency boundary | Medium | Minimal overhead in most apps | Complex domains, testability, multiple aggregates |
| Specification | Encapsulate reusable query/business criteria | Low-Medium | Can improve query shaping if used well | Dynamic filters, query reuse |
| Mediator (MediatR) | Decouple request senders from handlers | Medium | Slight dispatch overhead | CQRS, cross-cutting behavior pipelines |
| CQRS | Separate write and read models | High | Better scale profile but more moving parts | High read/write asymmetry, complex business logic |
| Event Sourcing | Persist events, rebuild state by replay | Very High | Read-side complexity; write-side audit strength | Temporal queries, strict audit, replay/debug needs |

### 2.2 Repository + Unit of Work

**Surface framing:**
- Repository exposes collection-like access to aggregates.
- Unit of Work coordinates atomic persistence across changes.

**Core implementation pattern:**
```csharp
public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Order> Orders { get; }
    int Commit();
    Task<int> CommitAsync();
}
```

```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(DbContext context) => _context = context;

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out var existing))
            return (IRepository<T>)existing;

        var repo = new Repository<T>(_context);
        _repositories[typeof(T)] = repo;
        return repo;
    }

    public int Commit() => _context.SaveChanges();
    public Task<int> CommitAsync() => _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
```

**Benefits from source notes:**
- Decoupling of business logic from data access implementation.
- Testability through repository abstraction.
- Maintainability via centralized access rules.
- Flexibility for multiple backing stores.

**When to use:**
- Complex domains with multiple aggregates.
- Need for testable application/service layer.
- Multiple data-source abstractions.
- Reusable, non-trivial query composition.

**When not to use:**
- Simple CRUD apps where EF Core direct usage is enough.
- Small microservices with minimal persistence complexity.
- Cases where extra abstraction only duplicates ORM capabilities.

**Concurrency handling (from source Q&A guidance):**
```csharp
public class Entity
{
    public int Id { get; set; }
    public byte[] Version { get; set; } // Optimistic concurrency token
}
```

**Repository vs DAO (interview distinction):**

| Aspect | Repository | DAO |
|---|---|---|
| Abstraction level | Domain-centric | Data-store-centric |
| Typical model | Works with aggregates/entities as domain concepts | Works closer to tables/queries |
| Interview shorthand | "Collection of domain objects" | "Storage access object" |

### 2.3 Specification Pattern

**Surface framing:** Encapsulate query/business rules into reusable, composable specifications.

```csharp
public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
}

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    protected BaseSpecification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;
}
```

**Example spec from notes:**
```csharp
public class ActiveUsersWithOrdersSpecification : BaseSpecification<User>
{
    public ActiveUsersWithOrdersSpecification()
        : base(u => u.IsActive && u.Orders.Any(o => o.TotalAmount > 100))
    {
        AddInclude(u => u.Orders);
        AddInclude(u => u.Profile);
        AddOrderBy(u => u.CreatedDate);
    }
}
```

**Composite specification pattern:**
```csharp
public class AndSpecification<T> : BaseSpecification<T>
{
    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        : base(CombineCriteria(left, right)) { }

    private static Expression<Func<T, bool>> CombineCriteria(ISpecification<T> left, ISpecification<T> right)
    {
        var param = Expression.Parameter(typeof(T));
        var combined = Expression.AndAlso(
            Expression.Invoke(left.Criteria, param),
            Expression.Invoke(right.Criteria, param));
        return Expression.Lambda<Func<T, bool>>(combined, param);
    }
}
```

**When to use:**
- Reusable complex query logic.
- Dynamic query building.
- Separation of query rules from repository plumbing.

**Performance caveat from source:**
- Too many `Include`s can hurt performance; prefer projection or explicit loading when appropriate.

### 2.4 Mediator Pattern (MediatR)

**Surface framing:** Decouple collaborators by routing requests through a mediator.

**Command/Query/Notification structure:**
```csharp
public class CreateUserCommand : IRequest<int>
{
    public string Email { get; set; }
    public string Name { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository) => _repository = repository;

    public async Task<int> Handle(CreateUserCommand request, CancellationToken ct)
    {
        var user = new User { Email = request.Email, Name = request.Name };
        _repository.Add(user);
        await _repository.SaveChangesAsync(ct);
        return user.Id;
    }
}

public class GetUserQuery : IRequest<UserDto>
{
    public int UserId { get; set; }
}
```

```csharp
public class UserCreatedNotification : INotification
{
    public int UserId { get; set; }
    public string Email { get; set; }
}

public class EmailNotificationHandler : INotificationHandler<UserCreatedNotification>
{
    public Task Handle(UserCreatedNotification notification, CancellationToken ct)
    {
        // Send welcome email
        return Task.CompletedTask;
    }
}
```

**Pipeline behaviors (cross-cutting middleware):**
```csharp
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        _logger.LogInformation("Handling {Request}", typeof(TRequest).Name);
        var response = await next();
        _logger.LogInformation("Handled {Request}", typeof(TRequest).Name);
        return response;
    }
}
```

```csharp
public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly DbContext _context;

    public TransactionBehavior(DbContext context) => _context = context;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        await using var tx = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            var response = await next();
            await tx.CommitAsync(ct);
            return response;
        }
        catch
        {
            await tx.RollbackAsync(ct);
            throw;
        }
    }
}
```

**When to use:**
- Complex interactions and dependency reduction.
- CQRS command/query pipelines.
- Consistent cross-cutting concerns (logging, validation, transactions, caching).

**Trade-offs:**
- Harder debugging due to indirection.
- Slight performance overhead.
- Team learning curve.
- Risk of anemic domain model if every behavior is moved into handlers blindly.

### 2.5 CQRS

**Surface framing:** Separate command (write) and query (read) models.

**Architecture from notes:**
```text
Commands -> Command Handlers -> Write Model -> Event Publishing
Queries  -> Query Handlers   -> Read Model (Denormalized)
```

**Implementation shape:**
```csharp
public class UpdateProductPriceCommand : IRequest
{
    public int ProductId { get; set; }
    public decimal NewPrice { get; set; }
}

public class UpdateProductPriceCommandHandler : IRequestHandler<UpdateProductPriceCommand>
{
    private readonly IProductRepository _repository;

    public async Task<Unit> Handle(UpdateProductPriceCommand request, CancellationToken ct)
    {
        var product = await _repository.GetByIdAsync(request.ProductId);
        product.UpdatePrice(request.NewPrice);
        await _repository.SaveChangesAsync(ct);
        return Unit.Value;
    }
}

public class GetProductsQuery : IRequest<List<ProductDto>>
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}
```

```csharp
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } // Denormalized read model
}
```

**Advanced CQRS with event-sourced aggregate root (from source):**
```csharp
public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _changes = new();

    public Guid Id { get; protected set; }
    public int Version { get; protected set; }

    public IReadOnlyCollection<IDomainEvent> GetUncommittedChanges() => _changes.AsReadOnly();
    public void MarkChangesAsCommitted() => _changes.Clear();

    protected void ApplyChange(IDomainEvent @event, bool isNew = true)
    {
        Apply(@event);
        if (isNew) _changes.Add(@event);
    }

    protected abstract void Apply(IDomainEvent @event);
}
```

**When to use:**
- High-performance workloads with different read/write scaling needs.
- Complex business logic and collaborative domains.

**When CQRS is overkill:**
- Simple CRUD systems.
- Nearly identical read/write models.
- Teams not ready for eventual consistency complexity.

**Eventual consistency handling strategies from source:**
- Compensating actions.
- Retries and failure handling.
- User feedback on processing state.
- Saga/process manager patterns for complex workflows.

### 2.6 Event Sourcing

**Surface framing:** Persist events instead of latest state; rebuild current state by replay.

**Core event store shape:**
```csharp
public interface IEventStore
{
    Task SaveEventsAsync(Guid aggregateId, IEnumerable<IDomainEvent> events, int expectedVersion);
    Task<List<IDomainEvent>> GetEventsForAggregateAsync(Guid aggregateId);
}

public class EventStore : IEventStore
{
    private readonly Dictionary<Guid, List<IDomainEvent>> _eventStore = new();

    public async Task SaveEventsAsync(Guid aggregateId, IEnumerable<IDomainEvent> events, int expectedVersion)
    {
        if (!_eventStore.ContainsKey(aggregateId))
            _eventStore[aggregateId] = new List<IDomainEvent>();

        var currentVersion = _eventStore[aggregateId].Count - 1;
        if (currentVersion != expectedVersion)
            throw new ConcurrencyException();

        _eventStore[aggregateId].AddRange(events);
        await Task.CompletedTask;
    }

    public async Task<List<IDomainEvent>> GetEventsForAggregateAsync(Guid aggregateId)
    {
        if (_eventStore.ContainsKey(aggregateId))
            return await Task.FromResult(_eventStore[aggregateId]);
        return await Task.FromResult(new List<IDomainEvent>());
    }
}
```

**Aggregate replay example:**
```csharp
public class BankAccount : AggregateRoot
{
    public decimal Balance { get; private set; }
    public bool IsClosed { get; private set; }

    public BankAccount() { }

    public BankAccount(Guid id, string accountHolder)
    {
        ApplyChange(new AccountCreatedEvent(id, accountHolder, DateTime.UtcNow));
    }

    public void Deposit(decimal amount)
    {
        if (IsClosed) throw new AccountClosedException();
        ApplyChange(new MoneyDepositedEvent(Id, amount, DateTime.UtcNow));
    }

    protected override void Apply(IDomainEvent @event)
    {
        switch (@event)
        {
            case AccountCreatedEvent e:
                Id = e.AccountId;
                Balance = 0;
                break;
            case MoneyDepositedEvent e:
                Balance += e.Amount;
                break;
        }
    }
}
```

**Projection/read-model builder:**
```csharp
public class BankAccountProjection
{
    private readonly Dictionary<Guid, BankAccountView> _views = new();

    public void Handle(AccountCreatedEvent @event)
    {
        _views[@event.AccountId] = new BankAccountView
        {
            AccountId = @event.AccountId,
            AccountHolder = @event.AccountHolder,
            Balance = 0,
            CreatedDate = @event.CreatedDate
        };
    }

    public void Handle(MoneyDepositedEvent @event)
    {
        if (_views.ContainsKey(@event.AccountId))
        {
            _views[@event.AccountId].Balance += @event.Amount;
            _views[@event.AccountId].LastTransactionDate = @event.DepositDate;
        }
    }
}
```

**Snapshot strategy for replay performance (from source):**
```csharp
public interface ISnapshotStore
{
    Task<Snapshot> GetSnapshotAsync(Guid aggregateId);
    Task SaveSnapshotAsync(Guid aggregateId, Snapshot snapshot);
}

public class Snapshot
{
    public Guid AggregateId { get; set; }
    public int Version { get; set; }
    public string Data { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

**When to use:**
- Strong audit-trail requirements.
- Temporal/history queries.
- Replay/debug requirements.
- High-reliability domains with explicit event history value.

**Operational concerns:**
- Event schema evolution: version events and use upcasters.
- Ordering/concurrency: sequence/version checks and optimistic concurrency.
- Replay cost: snapshots and projection optimization.

### 2.7 Pattern Combination Guidance

| Combination | Why It Works |
|---|---|
| MediatR + CQRS | Clear command/query pipeline + cross-cutting behaviors |
| Repository + Specification | Reusable, testable query logic without leaking persistence details |
| CQRS + Event Sourcing | Strong write-side model with replayable event log and optimized read side |
| All together (carefully) | Useful for complex domains, but only with strong team maturity and observability |

### 2.8 Trade-off Table (Decision View)

| Aspect | Repository/UoW | Specification | Mediator | CQRS | Event Sourcing |
|---|---|---|---|---|---|
| Primary value | Data abstraction + transaction boundary | Query rule reuse | Decoupled request handling | Read/write optimization | Full history + replay |
| Main cost | Extra layer over ORM | Expression complexity | Indirection | Multiple models and consistency handling | Highest complexity and ops burden |
| Scale impact | Neutral to moderate | Neutral (can optimize query shape) | Slight overhead | Better independent read/write scaling | Write audit strength, read complexity |
| Interview trap | Re-wrapping EF blindly | Over-fetching with includes | Handler explosion/anemic domain | Using for simple CRUD | Ignoring versioning/snapshots |

## 3. Senior Perspective (The "Why")
- These patterns are complexity shifters: they trade local simplicity for global maintainability, scale control, and domain clarity.
- Repository/UoW and Specification are often enough for many business systems; CQRS/Event Sourcing should be introduced only when read/write pressure, audit, or temporal requirements justify the cost.
- MediatR is most effective when pipeline behaviors standardize validation, logging, transactions, and exception handling consistently across use cases.
- Eventual consistency is an organizational as much as technical decision: product and UX must reflect asynchronous truth (statuses, retries, compensations).
- Event Sourcing provides unmatched audit and replay semantics, but requires disciplined event contracts, upcasting strategy, projection health monitoring, and snapshot governance.
- Senior design chooses the minimum architecture that preserves future optionality, not the maximum number of patterns.

## 4. Interview Gotchas & Confusion Points

| Gotcha | Why Candidates Fail | What a Strong Senior Answer Clarifies |
|---|---|---|
| "Repository always required with EF Core" | Treats patterns as mandatory boilerplate. | EF Core already offers repository/UoW characteristics; add abstraction only when it protects domain boundaries or test seams. |
| Exposing `IQueryable` from repository by default | Leaks persistence concerns and query internals. | Prefer specification/projection boundaries; expose queryables only intentionally with clear constraints. |
| Ignoring transaction boundaries in MediatR | Focuses only on handler code. | Use transaction pipeline behavior for atomic command processing and rollback semantics. |
| Mediator overuse | Everything becomes thin handlers, domain logic disappears. | Keep rich domain behavior in aggregates/services; mediator coordinates, not replaces domain model. |
| CQRS for simple CRUD | Architecture cargo-culting. | CQRS is justified by asymmetric workloads/complex domains, not by trend. |
| Treating eventual consistency as implementation detail | Misses product impact. | Surface async state to users, add retries/compensations, and monitor lag. |
| Event Sourcing without versioning strategy | Breaks replay when contracts evolve. | Immutable events + versioned schemas + upcasters/migration plan. |
| Event replay performance ignored | Assumes replay cost is always acceptable. | Use snapshots and projection tuning for long streams. |
| Unit of Work commit failure misunderstood | Assumes partial write success. | Commit is atomic transaction boundary: all succeed or rollback. |
| Specification include explosion | Over-eager loading causes heavy queries. | Use projection/explicit loading and query profiling. |
| Pattern stacking without boundaries | Creates accidental complexity. | Define clear responsibilities per pattern and add only where pressure exists. |

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

**Q1. Repository vs DAO: what is the practical difference?**
A: Repository is domain-oriented and models aggregate access; DAO is persistence-oriented and closer to storage details.

**Q2. When should you avoid custom Repository over EF Core?**
A: In simple CRUD services where EF directly is clear and adding another abstraction only adds boilerplate.

**Q3. How do you handle complex reusable queries in Repository style?**
A: Use Specification pattern. Alternative is exposing `IQueryable`, but that can leak persistence concerns.

**Q4. What happens if `Commit()` fails in Unit of Work?**
A: The transaction should rollback atomically; no partial success.

**Q5. How do you combine specifications?**
A: Use composite specifications (`And`, `Or`) by combining expression trees.

**Q6. What is MediatR pipeline behavior used for?**
A: Cross-cutting concerns like logging, validation, exception handling, transactions, caching.

**Q7. When is CQRS overkill?**
A: Small CRUD systems with near-identical read/write concerns and low scaling pressure.

**Q8. Is read-model data duplication acceptable in CQRS?**
A: Yes, denormalization is intentional for read performance.

**Q9. How do you handle event schema changes in Event Sourcing?**
A: Version events, keep old contracts immutable, and use upcasters/migrations.

**Q10. Why do Event Sourcing systems use snapshots?**
A: To reduce state rebuild latency for long event streams.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

**Q11. You need strong audit trails and temporal queries. Which architecture path do you choose?**
A: CQRS + Event Sourcing for critical aggregates, with projections for read models and snapshot strategy for replay performance.

**Q12. Your MediatR system has slow command throughput. What do you inspect first?**
A: Pipeline behavior cost, DB transaction scope, handler allocations/IO, and repeated serialization/logging overhead.

**Q13. Eventual consistency causes user confusion after commands. How do you fix UX/architecture?**
A: Return processing state, expose async completion/status endpoints, implement retries and compensations, and monitor projection lag.

**Q14. A repository method keeps growing filters and includes. Refactor direction?**
A: Extract specifications per business use case, apply projections, and separate read concerns if complexity persists.

**Q15. Can these patterns be combined safely in one app?**
A: Yes, but with disciplined boundaries: MediatR for coordination, specifications for query reuse, CQRS for separation, Event Sourcing for selected high-value aggregates.

**Q16. How do you test these patterns effectively?**
A:
- Repository: mock abstraction or run integration tests with real DB provider.
- Mediator: test handlers and pipeline behaviors separately.
- CQRS: test command and query paths independently.
- Event Sourcing: test aggregate behavior by replaying events and asserting state/projections.

**Q17. How do you standardize error handling across handlers?**
A: Pipeline exception behavior + domain-specific exceptions + explicit result model for expected failures.

```csharp
public class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }

    private Result(bool isSuccess, T value, string error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string error) => new(false, default, error);
}
```

## 6. The Revision Bank
1. Repository vs DAO in one sentence each.
2. When is custom Repository/UoW unnecessary with EF Core?
3. How does Specification prevent query duplication?
4. Why can too many includes be a performance issue?
5. What are the top two benefits of MediatR pipeline behaviors?
6. CQRS: when does its complexity become justified?
7. Name two techniques for handling eventual consistency.
8. Why is read-model denormalization acceptable in CQRS?
9. Event Sourcing: how do you evolve event schemas safely?
10. What problem do snapshots solve?
11. How does optimistic concurrency protect event streams?
12. What does a strong testing strategy look like across these patterns?

## 7. Clarification / Suggested Additions Before Finalizing
- Suggested addition: Add interview-ready trade-off examples for small teams vs large teams adopting these patterns.
