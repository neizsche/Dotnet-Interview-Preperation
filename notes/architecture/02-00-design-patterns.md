# Design Patterns Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
Design patterns are reusable design templates that help teams solve recurring architecture problems with predictable trade-offs. Senior engineers use patterns as decision tools, not ornaments: apply them only when the underlying problem exists, and balance extensibility with readability, performance, and delivery speed. In .NET backend interviews, strong answers connect intent, implementation shape, operational cost, and when not to use a pattern.

## 2. Structured Study Material

### 2.1 What Design Patterns Solve

| Problem Type | Pattern Contribution | Interview Framing |
|---|---|---|
| Repeated design mistakes | Provides proven structure | "I use patterns to reduce accidental complexity." |
| Tight coupling | Introduces abstractions and extension seams | "Pattern choice should lower blast radius of change." |
| Hard-to-extend features | Encapsulates variation points | "I optimize for safe extension, not speculative abstraction." |
| Team misalignment | Shared vocabulary (Factory, Strategy, Adapter, etc.) | "Pattern names improve design communication during reviews." |

### 2.2 Pattern Families

| Family | Core Goal | Typical Patterns in Notes | Primary Trade-off |
|---|---|---|---|
| Creational | Control object creation | Singleton, Factory Method, Abstract Factory, Builder, Prototype | More factory/builder types and indirection |
| Structural | Compose/wrap objects cleanly | Adapter, Decorator, Facade, Composite, Bridge | Extra layers may hide control flow |
| Behavioral | Organize object interaction/algorithm flow | Observer, Publisher-Subscriber, Strategy, Command, Template Method, State, Iterator, Chain of Responsibility | Runtime behavior can become harder to trace |

### 2.3 DRY, KISS, YAGNI with Patterns

| Principle | Pattern Interaction | Senior Rule |
|---|---|---|
| DRY | Patterns can centralize repeated behavior (Strategy/Template/Decorator). | Remove meaningful duplication; avoid abstracting accidental duplication too early. |
| KISS | Patterns should simplify change, not impress with abstraction depth. | If the pattern makes simple flows opaque, step back. |
| YAGNI | Premature factories/abstractions create unused complexity. | Add pattern only after variability or extension pressure appears. |

### 2.4 Benefits vs Challenges in Real Projects

| Aspect | Benefits | Risks/Challenges | Mitigation |
|---|---|---|---|
| Reusability | Reusable templates for common problems | Pattern cargo-culting | Map pattern to explicit pain point first |
| Maintainability | Better modularity and readable architecture | Over-abstraction hurts readability | Prefer smallest pattern that solves current need |
| Scalability | Easier extension and substitution | Pattern proliferation | Periodic architecture pruning |
| Performance | Some patterns reduce cost (Proxy/Flyweight-like ideas) | Indirection/object churn/method dispatch overhead | Measure hotspots before optimizing |
| Team velocity | Shared language improves collaboration | Learning curve for juniors | Pairing + short internal pattern guides |

### 2.5 Pattern Selection Matrix

| Scenario | Preferred Pattern | Why It Fits | Watch-out |
|---|---|---|---|
| Need one globally shared instance | Singleton | Single access point for shared resource | Global state and test isolation issues |
| Choose object type at runtime | Factory Method | Encapsulates product creation | Creator hierarchy complexity |
| Create related product families | Abstract Factory | Guarantees product compatibility | Adding new product type can ripple across factories |
| Construct complex object step-by-step | Builder | Clear staged construction + validation | Extra types for simple objects |
| Expensive object creation via copy | Prototype | Clone instead of rebuilding | Deep vs shallow copy correctness |
| Integrate incompatible interface | Adapter | Wraps legacy/third-party API | Adapter translation drift over time |
| Add optional behavior dynamically | Decorator | Runtime composition | Ordering and debugging complexity |
| Expose simplified facade | Facade | Hides subsystem complexity | Can become a god-facade |
| Represent tree part-whole hierarchy | Composite | Uniform leaf/composite handling | Leaf-only invalid operations |
| Vary abstraction and implementation independently | Bridge | Avoids subclass explosion | Requires upfront axis modeling |
| One-to-many state change notifications | Observer | Decoupled reactive updates | Leaks and notification storms |
| Many-to-many async topic messaging | Pub-Sub | Decoupled distributed events | Delivery guarantees/ordering complexity |
| Swap algorithm at runtime | Strategy | Replace if-else chains with policies | Strategy registry management |
| Support undo/redo, queue, audit | Command | Request as object | Command history memory growth |
| Keep algorithm skeleton fixed, vary steps | Template Method | Shared invariant flow | Inheritance coupling |
| Route request across handlers | Chain of Responsibility | Dynamic request pipelines | Unhandled request fall-through |
| State-driven behavior changes | State | Removes giant state conditionals | Many state classes |
| Traversal without exposing structure | Iterator | Encapsulated traversal logic | Iterator consistency under mutation |

### 2.6 .NET-Centric Pattern Mapping

| .NET Context | Pattern Mapping | Why It Matters |
|---|---|---|
| ASP.NET Core DI container | Abstract Factory/Factory-like composition root | Decoupled creation and configurable implementations |
| `System.IO.Stream` wrappers | Decorator | Adds buffering/compression/encryption without base edits |
| LINQ over diverse sources | Adapter-like abstraction | Uniform query model over different providers |
| C# events/delegates | Observer | Native one-to-many notification model |
| Auth strategy switching (JWT/Cookie/etc.) | Strategy | Runtime policy selection |
| WPF/Xamarin UI architecture | MVVM (framework pattern) | Decouples view logic and state management |

### 2.7 Real-World Case Studies Mentioned

| Case | Pattern | Practical Outcome |
|---|---|---|
| Logging framework single instance | Singleton | Centralized logging and consistent access |
| GUI component creation | Factory Method | Extend UI element creation without rewriting clients |
| Event handling in frontend frameworks | Observer | Reactive updates with loose coupling |
| Java I/O layered streams | Decorator | Add buffering/compression behavior dynamically |
| Runtime algorithm choice in sorting/payment-like domains | Strategy | Swap behavior with minimal client change |

### 2.8 Refactoring Process to Apply Patterns

| Step | Key Actions | Validation |
|---|---|---|
| Understand current codebase | Code review, map hotspots, gather requirements | Baseline behavior/tests captured |
| Choose pattern intentionally | Match pain point to pattern; assess trade-offs | Decision record with alternatives |
| Refactor incrementally | Extract abstractions in small steps | Green unit + integration tests per step |
| Test and validate | Unit, integration, regression | No behavior regression and stable performance |
| Document and socialize | Why this pattern, usage rules, constraints | Team can extend pattern safely |
| Iterate | Collect feedback and simplify where needed | Pattern remains net-positive over time |

### 2.9 Anti-Patterns to Detect and Refactor

| Anti-pattern | Why It Hurts | Refactoring Direction |
|---|---|---|
| God Object | Too many responsibilities; low cohesion | Split by responsibility and use interfaces/services |
| Spaghetti Code | Untraceable control flow | Modularize and introduce clear boundaries |
| Circular Dependency | Tight module lock-in and test difficulty | Introduce interfaces/events to break cycles |
| Massive Controller (MVC) | UI/controller bloat | Move logic to services/view-model/application layer |
| Magic Strings/Numbers | Fragile and unclear code | Constants/enums/value objects |
| Shotgun Surgery | One change touches many files | Consolidate responsibilities and reduce coupling |
| Gold Plating | Unneeded complexity | Re-anchor to requirements/MVP |
| Feature Envy | Misplaced behavior across classes | Move behavior to data-owning type |
| Reinventing the Wheel | Lost time and reliability | Prefer standard libs/framework features |

**Anti-pattern detection aids from notes:**
- Manual code review
- Static analysis tools (`SonarQube`, `ReSharper`, `ESLint`)
- Metrics (`cyclomatic complexity`, coupling, churn)

### 2.10 Creational Patterns with Contextual Code

#### Singleton (thread-safe lazy access)
```csharp
public sealed class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new();
    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance is null)
        {
            lock (_lock)
            {
                _instance ??= new Logger();
            }
        }
        return _instance;
    }

    public void Log(string message) => Console.WriteLine($"[INFO] {DateTime.UtcNow:o} {message}");
}
```
Use for shared resources like logging/configuration with controlled lifetime.

#### Factory Method (document generation)
```csharp
public interface IDocument { void Generate(); }
public sealed class PdfDocument : IDocument { public void Generate() => Console.WriteLine("PDF"); }
public sealed class WordDocument : IDocument { public void Generate() => Console.WriteLine("Word"); }

public abstract class DocumentCreator
{
    public abstract IDocument CreateDocument();
}

public sealed class PdfCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new PdfDocument();
}
```
Use when client should not know concrete product type.

#### Abstract Factory (cross-platform UI family)
```csharp
public interface IButton { void Render(); }
public interface ICheckbox { void Render(); }

public interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public sealed class WinFactory : IGuiFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}
```
Use when products must be created as compatible families.

#### Builder (validation at `Build()`)
```csharp
public sealed class User
{
    public string Username { get; }
    public string Email { get; }
    public string? FirstName { get; }

    private User(UserBuilder b)
    {
        Username = b.Username;
        Email = b.Email;
        FirstName = b.FirstName;
    }

    public sealed class UserBuilder
    {
        public string Username { get; }
        public string Email { get; }
        public string? FirstName { get; private set; }

        public UserBuilder(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public UserBuilder WithFirstName(string firstName) { FirstName = firstName; return this; }
        public User Build()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email))
                throw new InvalidOperationException("Username and Email are required");
            return new User(this);
        }
    }
}
```

#### Fluent Interface (readable query composition)
```csharp
public sealed class SqlQueryBuilder
{
    private readonly StringBuilder _sql = new();
    public SqlQueryBuilder Select(params string[] columns) { _sql.Append($"SELECT {string.Join(", ", columns)}"); return this; }
    public SqlQueryBuilder From(string table) { _sql.Append($" FROM {table}"); return this; }
    public SqlQueryBuilder Where(string predicate) { _sql.Append($" WHERE {predicate}"); return this; }
    public string Build() => _sql.ToString();
}
```

### 2.11 Structural Patterns with Contextual Code

#### Adapter (analytics integration)
```csharp
public interface IAnalyticsService
{
    void TrackEvent(string eventName, IDictionary<string, string> properties);
}

public interface ILegacyAnalyticsProvider
{
    void LogEvent(string eventName, string payload);
}

public sealed class AnalyticsAdapter : IAnalyticsService
{
    private readonly ILegacyAnalyticsProvider _legacy;
    public AnalyticsAdapter(ILegacyAnalyticsProvider legacy) => _legacy = legacy;

    public void TrackEvent(string eventName, IDictionary<string, string> properties)
    {
        var payload = string.Join(";", properties.Select(kv => $"{kv.Key}={kv.Value}"));
        _legacy.LogEvent(eventName, payload);
    }
}
```

#### Bridge (shape abstraction + renderer implementation)
```csharp
public interface IRenderer
{
    void RenderCircle(double radius);
    void RenderSquare(double side);
}

public abstract class Shape
{
    protected readonly IRenderer Renderer;
    protected Shape(IRenderer renderer) => Renderer = renderer;
    public abstract void Draw();
}

public sealed class Circle : Shape
{
    private readonly double _radius;
    public Circle(IRenderer renderer, double radius) : base(renderer) => _radius = radius;
    public override void Draw() => Renderer.RenderCircle(_radius);
}
```

#### Decorator (dynamic behavior layering)
```csharp
public interface ICoffee { string Description { get; } decimal Cost { get; } }
public sealed class SimpleCoffee : ICoffee { public string Description => "Simple Coffee"; public decimal Cost => 2.0m; }

public abstract class CoffeeDecorator(ICoffee inner) : ICoffee
{
    public virtual string Description => inner.Description;
    public virtual decimal Cost => inner.Cost;
}

public sealed class MilkDecorator(ICoffee inner) : CoffeeDecorator(inner)
{
    public override string Description => base.Description + ", Milk";
    public override decimal Cost => base.Cost + 0.5m;
}
```

#### Composite (file-directory hierarchy)
```csharp
public interface IFileSystemComponent { long GetSize(); }

public sealed class FileLeaf(string name, long size) : IFileSystemComponent
{
    public long GetSize() => size;
}

public sealed class DirectoryComposite : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _children = new();
    public void Add(IFileSystemComponent child) => _children.Add(child);
    public long GetSize() => _children.Sum(c => c.GetSize());
}
```

### 2.12 Behavioral Patterns with Contextual Code

#### Strategy (runtime algorithm swap)
```csharp
public interface IPaymentStrategy { void Pay(decimal amount); }
public sealed class CardPayment : IPaymentStrategy { public void Pay(decimal amount) => Console.WriteLine($"Card {amount}"); }
public sealed class PaypalPayment : IPaymentStrategy { public void Pay(decimal amount) => Console.WriteLine($"PayPal {amount}"); }

public sealed class CheckoutContext
{
    private IPaymentStrategy _strategy;
    public CheckoutContext(IPaymentStrategy strategy) => _strategy = strategy;
    public void SetStrategy(IPaymentStrategy strategy) => _strategy = strategy;
    public void Checkout(decimal total) => _strategy.Pay(total);
}
```

#### Template Method (fixed workflow + overridable steps)
```csharp
public abstract class DataProcessor
{
    public void Process()
    {
        Read();
        Transform();
        Write();
        if (Hook()) AdditionalProcessing();
    }

    private void Read() { }
    private void Write() { }
    protected abstract void Transform();
    protected virtual bool Hook() => false;
    protected virtual void AdditionalProcessing() { }
}
```

#### Observer (stock updates)
```csharp
public interface IStockObserver { void Update(decimal price); }

public sealed class StockMarket
{
    private readonly List<IStockObserver> _observers = new();
    public void Subscribe(IStockObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IStockObserver observer) => _observers.Remove(observer);
    public void SetPrice(decimal price)
    {
        foreach (var o in _observers) o.Update(price);
    }
}
```

#### Publisher-Subscriber (topic-based broker)
```csharp
public sealed class MessageBroker
{
    private readonly Dictionary<string, List<Action<string>>> _topics = new();

    public void Subscribe(string topic, Action<string> handler)
    {
        if (!_topics.ContainsKey(topic)) _topics[topic] = new List<Action<string>>();
        _topics[topic].Add(handler);
    }

    public void Publish(string topic, string message)
    {
        if (_topics.TryGetValue(topic, out var handlers))
            foreach (var h in handlers) h(message);
    }
}
```

#### Command (undo-capable operations)
```csharp
public interface IImageCommand { void Execute(); void Undo(); }

public sealed class ImageEditor
{
    private readonly Stack<IImageCommand> _history = new();

    public void Execute(IImageCommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void Undo()
    {
        if (_history.Count == 0) return;
        _history.Pop().Undo();
    }
}
```

#### Chain of Responsibility (priority ticket routing)
```csharp
public abstract class TicketHandler
{
    private TicketHandler? _next;
    public TicketHandler SetNext(TicketHandler next) { _next = next; return next; }

    public virtual void Handle(Ticket ticket)
    {
        if (_next is not null) _next.Handle(ticket);
    }
}
```

### 2.13 Critical Pattern Comparisons

#### Factory Method vs Abstract Factory

| Aspect | Factory Method | Abstract Factory | Trade-off | When to Use |
|---|---|---|---|---|
| Purpose | Create one product type via creator hierarchy | Create related product families | AF gives stronger family consistency but more types | FM for one product line; AF for multi-product families |
| Extension style | Subclass creator | Swap factory implementation/composition | FM simpler; AF more scalable for families | FM for simple extension, AF for cross-platform/theming |
| Complexity | Lower | Higher | AF adds interface/factory/product matrices | Use AF only when family compatibility matters |

#### Builder vs Fluent Interface

| Aspect | Builder | Fluent Interface | Trade-off | When to Use |
|---|---|---|---|---|
| Goal | Build complex object safely | Improve readability via chaining | Builder safer for invariants; Fluent lighter | Builder for many optionals/validation; Fluent for API readability |
| Validation point | Typically `Build()` | Usually during chain or terminal method | Build-time validation is explicit | Use Builder when invalid partial state is risky |

#### Strategy vs Template Method

| Aspect | Strategy | Template Method | Trade-off | When to Use |
|---|---|---|---|---|
| Design basis | Composition (`has-a`) | Inheritance (`is-a`) | Strategy more runtime-flexible; Template fewer objects | Strategy for runtime swaps; Template for fixed pipeline |
| Override scope | Entire algorithm replacement | Specific steps only | Template enforces flow, Strategy maximizes pluggability | Choose based on whether algorithm skeleton is stable |

#### Observer vs Publisher-Subscriber

| Aspect | Observer | Publisher-Subscriber | Trade-off | When to Use |
|---|---|---|---|---|
| Coupling | Subject knows observers | Broker decouples publishers/subscribers | Pub-Sub scales better but operationally heavier | Observer inside process/UI; Pub-Sub for distributed events |
| Delivery model | Direct callback | Topic/channel routing | Pub-Sub needs routing, retries, ordering rules | Use Pub-Sub for multi-service asynchronous domains |

#### Decorator vs Composite

| Aspect | Decorator | Composite | Trade-off | When to Use |
|---|---|---|---|---|
| Purpose | Add responsibilities | Represent tree part-whole structure | Decorator layers behavior; Composite layers hierarchy | Decorator for optional features; Composite for hierarchical domains |
| Relationship | Wrapper one-to-one | Parent with many children | Composite requires child lifecycle rules | Use based on behavior extension vs structural composition |

### 2.14 Work Experience Scenarios from Notes

| Scenario | Pattern | Why It Was Chosen |
|---|---|---|
| Centralized logging used across modules | Singleton | Single instance and global access point |
| User-selected document generation (PDF/Word) | Factory Method | Runtime product selection without client coupling |
| Cross-platform UI toolkit (Windows/macOS) | Abstract Factory | Guaranteed compatible control families |
| Third-party analytics integration mismatch | Adapter | Interface translation without changing legacy provider |
| Drawing app with shapes + render modes | Bridge | Independent variation of shape and renderer |
| Ticket processing by priority chain | Chain of Responsibility | Dynamic routing through handlers |
| Image editor with undo/redo | Command | Encapsulated operations and command history |
| Real-time stock update subscribers | Observer | Dynamic attach/detach and broadcast updates |

## 3. Senior Perspective (The "Why")
- Pattern choice is an economic decision: reduce long-term change cost without overpaying in short-term complexity.
- In distributed .NET systems, behavioral patterns (Strategy, Command, Pub-Sub) often determine operability as much as correctness (retry strategy, ordering, back-pressure, idempotency).
- Creational patterns plus DI shape testability and deployment flexibility; overusing factories where constructor injection is enough creates avoidable indirection.
- Structural patterns can improve extension and integration, but every wrapper/layer can increase call depth and allocation pressure; profile before optimizing and keep hot paths simple.
- Observer and Pub-Sub systems must be designed for lifecycle and memory discipline: weak subscriptions/unsubscribe paths, bounded queues, and filtered notifications.
- Template Method and inheritance-heavy designs can lock architecture early; prefer Strategy/composition when change axis is uncertain.
- Mature teams periodically remove obsolete patterns. Pattern debt is real: abstractions that no longer serve active variability should be collapsed.

## 4. Interview Gotchas & Confusion Points

| Gotcha | Why Candidates Fail | What a Strong Answer Clarifies |
|---|---|---|
| Factory Method vs Abstract Factory confusion | They memorize names, not creation scope. | FM creates one product hierarchy; AF creates families of related products with compatibility guarantees. |
| Using Abstract Factory for simple one-product use case | Overengineering instinct. | Start with FM/simple factory; move to AF only when multiple related products must vary together. |
| Builder without validation | Candidate focuses on chaining only. | Builder value includes safe construction and invariant checks in `Build()`. |
| Fluent Interface treated as Builder equivalent | Ignores intent difference. | Fluent improves readability; Builder governs complex construction + validation. |
| Strategy runtime switching without thread-safety plan | No concurrency thinking. | Mention immutable strategies, synchronization, or context-per-request model. |
| Template Method overused for runtime variability | Defaults to inheritance. | If behavior must change at runtime, Strategy is usually superior. |
| Observer memory leak blind spot | Forgets subject holds observer references. | Unsubscribe discipline, weak references, lifecycle ownership, and cleanup hooks are essential. |
| Observer performance storms | Broadcasts every update to every observer. | Use filtered notifications, batched updates, or move to topic-based Pub-Sub. |
| Decorator order dependency ignored | Assumes wrapping order is always commutative. | Order can change behavior/cost; either design order-independent decorators or document order rules. |
| Composite leaf child operations handled poorly | API allows invalid operations on leaves. | Use safe defaults, explicit errors, or separate interfaces where needed. |
| Singleton advocated as universal global access | Misses testability and hidden coupling risks. | Use sparingly; prefer DI-managed singleton lifetime and explicit dependencies. |
| Pattern overuse as “best practice” | Candidate optimizes for pattern count. | Patterns solve specific problems; when no problem exists, they become anti-patterns. |

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

**Q1. What problem should exist before applying a design pattern?**
A: A recurring design problem with clear change pressure or complexity that the pattern directly addresses.

**Q2. When would you choose Factory Method over Simple Factory?**
A: When creation must be extensible via subclassing and clients/framework users need customization points.

**Q3. Can Factory Method be combined with dependency injection?**
A: Yes. Inject factory abstractions and let DI provide concrete factories via configuration.

**Q4. How does Abstract Factory ensure product compatibility?**
A: Each concrete factory creates a coherent family of products designed to work together.

**Q5. What is a common disadvantage of Abstract Factory?**
A: Added complexity and broader interface changes when introducing new product types.

**Q6. When is Builder better than telescoping constructors?**
A: Many optional parameters, invariant checks, and readability requirements.

**Q7. How does Strategy improve testability?**
A: You can unit test each strategy independently and mock strategy interfaces in context tests.

**Q8. Strategy or Template Method: how do you choose?**
A: Template for fixed workflow with overridable steps; Strategy for runtime algorithm replacement.

**Q9. How do you avoid infinite loops in Observer systems?**
A: Prevent nested notify cascades, use change flags, and control update propagation rules.

**Q10. What memory leak risk exists in Observer?**
A: Long-lived subjects retaining strong references to observers that never unsubscribe.

**Q11. How is Decorator different from inheritance?**
A: Decorator composes behavior at runtime; inheritance fixes behavior at compile time.

**Q12. How do you handle unsupported leaf operations in Composite?**
A: Clear API boundaries, explicit errors/defaults, or split interfaces by capability.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

**Q13. You need cross-platform UI controls (Windows/macOS/Linux). Which pattern and why?**
A: Abstract Factory for consistent product families per platform and clean family switching.

**Q14. Your if-else payment routing keeps growing. Refactor strategy?**
A: Introduce Strategy with keyed strategy registry/factory and explicit fallback/error path.

**Q15. Production reports rising latency after adding multiple decorators. What do you do?**
A: Profile call stack/allocations, collapse redundant wrappers, cache expensive decorators, and document order constraints.

**Q16. Observer-based notifications are flooding downstream services. How would you fix it?**
A: Add topic filtering, batch/coalesce updates, back-pressure, and potentially evolve to Pub-Sub broker.

**Q17. How do you design undo/redo for an editor handling large objects?**
A: Command pattern with bounded history, snapshot/delta strategy, and memory-aware eviction.

**Q18. Your chain of handlers silently drops unhandled requests. Senior fix?**
A: Add terminal handler/default policy, observability metrics, and explicit unhandled result contracts.

**Q19. A singleton logger hurts tests through hidden global state. What refactor?**
A: Move to interface + DI-managed singleton lifetime; inject logger dependency explicitly.

**Q20. How do you migrate legacy incompatible APIs without breaking consumers?**
A: Add adapters at boundaries, keep old contracts stable, run parallel validation, then gradually deprecate legacy paths.

**Q21. Pattern overuse is making onboarding difficult. What governance would you apply?**
A: Architecture decision records, pattern usage guidelines, mandatory trade-off notes in PRs, and periodic simplification passes.

## 6. The Revision Bank
1. What exact problem does each pattern family solve?
2. When does Factory Method become insufficient, requiring Abstract Factory?
3. Builder vs Fluent Interface: where is validation supposed to happen?
4. Strategy vs Template Method: which one supports runtime swapping and why?
5. Observer vs Pub-Sub: what changes in coupling and operational complexity?
6. Why can Decorator order change behavior/performance?
7. What is the primary failure mode of Singleton in tests?
8. Which anti-pattern usually appears before introducing Strategy?
9. How do you prevent memory leaks in Observer implementations?
10. What metrics help detect anti-pattern hotspots early?
11. When is Chain of Responsibility better than a giant conditional block?
12. Name one case where adding a pattern would violate YAGNI.

## 7. Clarification / Suggested Additions Before Finalizing
- Clarification: Do you want this playbook to include fully equivalent C# code for all patterns currently shown in Java snippets (Factory/Builder/Strategy/etc.) so language is uniform for .NET interviews?
- Clarification: Should `Prototype`, `Facade`, `State`, and `Iterator` get full code examples (they are currently covered conceptually/scenario-level from source notes)?
- Suggested addition: Add a dedicated section on .NET built-in implementations (e.g., middleware pipeline as CoR, options/config patterns, MediatR command/query mapping).
- Suggested addition: Add a one-page "pattern smell detector" checklist for code reviews (when *not* to use each pattern).
- Suggested addition: Add performance-oriented interview drills (allocation/call-depth impact for Decorator/Observer/Command-heavy designs).
