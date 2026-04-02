# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. In a legacy ASPX-to-API migration, what principles help create a decoupled backend architecture?
2. How do you apply Single Responsibility Principle in a real provider-integration design?
3. How do you isolate provider-specific behavior such as API calls, authentication, and request parameters?
4. What are the SOLID principles, and what does each one mean in practice?
5. What is the difference between Single Responsibility Principle and Interface Segregation Principle?
6. Why depend on interfaces instead of concrete implementations?
7. What is encapsulation, and how do you enforce controlled mutation in C#?
8. If an external system needs to set a sensitive field, how should that be modeled safely?
9. What is the difference between an abstract class and an interface, and when would you use each?
10. Can a non-abstract class declare an abstract method? Why not?
11. How do you break a cyclic dependency between two classes?
12. How should error handling be structured in a .NET application?
13. What does `finally` do in `try` / `catch` / `finally`?
14. When should you use custom exceptions, and how are they written?
15. What are delegates in C#?
16. What is the difference between `Action`, `Func`, and `Predicate`?
17. What are events, and how do they relate to delegates?
18. How does garbage collection work in .NET?
19. How does the runtime determine whether an object is still reachable?
20. When does the garbage collector run?
21. How should unmanaged resources be handled with `IDisposable`?
22. Whose responsibility is it to call `Dispose()`?

## Architecture and SOLID

### Decoupled Architecture in a Legacy-to-Modern Migration
* **The Question:** In a legacy ASPX-to-API migration, what principles help create a decoupled backend architecture?
* **The Follow-ups:** What does a backend engineer own in that migration? How should controllers, services, and internal APIs be structured in a microservices-based system?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was evaluating whether the engineer understands migration work as **boundary redesign**, not just page rewrites.
    * **Seniority Markers:** Expected depth includes **controller-service separation**, **DTO mapping**, **provider abstraction**, **microservice integration**, **performance improvements**, and a clean break from page-bound data access.
* **The Definitive Answer:** A decoupled migration from legacy ASPX to modern ASP.NET Core should separate responsibilities into explicit layers:

  - **Controllers**: HTTP boundary, validation handoff, response mapping.
  - **Application / service layer**: orchestration and business use cases.
  - **Integration layer**: internal API calls, provider communication, resilience, retries, and translation.
  - **Persistence / data access**: isolated behind repositories or query services where appropriate.

  In practice, that means moving away from a model where the page performs querying, formatting, and business logic all at once. A modern design uses **RESTful APIs**, **dependency injection**, **typed clients**, **structured logging**, and clear **request/response contracts** so the frontend, backend, and downstream systems can evolve independently.

---

### Single Responsibility Principle in Provider Integrations
* **The Question:** How do you apply Single Responsibility Principle in a real provider-integration design?
* **The Follow-ups:** How do you avoid a god class? How do you keep provider-specific behavior from leaking everywhere?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can translate SRP from theory into a concrete design for external integrations.
    * **Seniority Markers:** Strong answers identify **reasons to change**, isolate provider-specific rules, and avoid combining API contracts, mapping, auth, and domain logic in the same class.
* **The Definitive Answer:** SRP means a class should have **one reason to change**, not merely “be small.” For provider integrations, that usually means separating:

  - **Provider authentication logic**
  - **Provider request/response mapping**
  - **Common orchestration logic**
  - **Domain-level policy or validation**

  A common pattern is:

  ```csharp
  public interface IProviderAccountClient
  {
      Task<AccountSnapshot> GetAccountsAsync(CancellationToken cancellationToken);
  }

  public sealed class FidelityAccountClient : IProviderAccountClient { /* ... */ }
  public sealed class SchwabAccountClient : IProviderAccountClient { /* ... */ }
  ```

  This keeps each provider class focused on its own API behavior while shared orchestration lives elsewhere.

---

### Isolating Provider-Specific Behavior
* **The Question:** How do you isolate provider-specific behavior such as API calls, authentication, and request parameters?
* **The Follow-ups:** How do you model common versus provider-specific fields? When is a shared base class useful, and when is an interface enough?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer wanted proof of practical integration design, especially around external systems that vary in auth and contract details.
    * **Seniority Markers:** Expected depth includes **anti-corruption boundaries**, **strategy-style substitution**, **shared abstractions**, and keeping provider rules from bleeding into generic code.
* **The Definitive Answer:** Provider-specific logic should be isolated behind a stable abstraction. The rest of the application should not need `if (provider == "...")` branches everywhere.

  A strong design uses:

  - An **interface** for the capability contract.
  - Provider-specific implementations for auth, payload shape, and HTTP behavior.
  - Optional **abstract base classes** only when there is meaningful shared implementation.
  - A normalization layer that translates provider responses into internal domain models.

  ```csharp
  public abstract class ProviderClientBase
  {
      protected ProviderClientBase(HttpClient httpClient) => HttpClient = httpClient;
      protected HttpClient HttpClient { get; }
  }
  ```

  Use this only if there is real shared behavior. If the only commonality is the contract, prefer an interface.

---

### SOLID Principles in Practice
* **The Question:** What are the SOLID principles, and what does each one mean in practice?
* **The Follow-ups:** Explain Open-Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion in a real .NET codebase.
* **Interviewer's Mental Model:**
    * **The 'Why':** This is an architecture maturity check. The interviewer was looking for more than acronym recall.
    * **Seniority Markers:** Better answers frame SOLID around **change isolation**, **safe extension**, **substitutability**, **consumer-oriented contracts**, and **dependency direction**.
* **The Definitive Answer:**

  - **Single Responsibility Principle**: a class should have one reason to change.
  - **Open-Closed Principle**: behavior should be extended through composition, new implementations, or policies rather than rewriting stable code.
  - **Liskov Substitution Principle**: derived types must remain behaviorally compatible with the base contract.
  - **Interface Segregation Principle**: consumers should not depend on large interfaces containing irrelevant members.
  - **Dependency Inversion Principle**: high-level policy should depend on abstractions, not concrete low-level details.

  In ASP.NET Core, SOLID often shows up through **constructor injection**, **small service contracts**, **provider-specific implementations**, and extension via **new handlers or strategies** instead of editing central switch statements.

---

### SRP vs Interface Segregation
* **The Question:** What is the difference between Single Responsibility Principle and Interface Segregation Principle?
* **The Follow-ups:** Both seem to advocate “keeping things small,” so what exactly is different about them?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether the engineer understands the axis of each principle rather than collapsing them into the same rule.
    * **Seniority Markers:** Strong answers distinguish **change responsibility in an implementation unit** from **consumer-specific contract design**.
* **The Definitive Answer:** These principles address different problems:

  - **SRP** is about the **implementation unit**: a class, service, or module should not accumulate unrelated reasons to change.
  - **ISP** is about the **shape of the contract**: consumers should not be forced to depend on methods they do not need.

  Example:

  ```csharp
  public interface IAccountReader
  {
      Task<Account> GetAsync(Guid id, CancellationToken cancellationToken);
  }

  public interface IAccountWriter
  {
      Task SaveAsync(Account account, CancellationToken cancellationToken);
  }
  ```

  Splitting a bloated interface is **ISP**. Splitting a service that handles validation, persistence, caching, and notification all at once is **SRP**.

---

### Interfaces vs Concrete Implementations
* **The Question:** Why depend on interfaces instead of concrete implementations?
* **The Follow-ups:** What happens when implementations change? How does this help with extensibility and maintainability?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks whether the engineer understands abstraction as a coupling-management tool, not just a DI convention.
    * **Seniority Markers:** Expected depth includes **substitution**, **testability**, **implementation swapping**, and knowing that interfaces matter most at meaningful boundaries.
* **The Definitive Answer:** Depending on interfaces reduces coupling because callers depend on a **stable contract** rather than a specific implementation detail.

  ```csharp
  builder.Services.AddScoped<IProviderAccountClient, FidelityAccountClient>();
  ```

  Benefits:

  - Easier implementation swaps.
  - Better test seams.
  - Less impact when internals change.
  - Cleaner extension for new providers or strategies.

  The nuanced answer is that interfaces should be introduced at **real abstraction boundaries**, not mechanically for every class.

---

### 🎯 Critical Focus Areas for this Section
- Treat legacy migrations as architecture redesign, not just technology replacement.
- Be able to explain SOLID with concrete provider-integration examples.
- Know the difference between cohesion problems, contract-shape problems, and dependency-direction problems.

## OOP, Encapsulation, and Dependency Management

### Encapsulation and Controlled Mutation
* **The Question:** What is encapsulation, and how do you enforce controlled mutation in C#?
* **The Follow-ups:** Why are public setters risky? How do access modifiers and methods help protect invariants?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether the engineer understands encapsulation as **invariant protection**, not just “using properties.”
    * **Seniority Markers:** Strong answers discuss **private setters**, **constructor initialization**, and domain methods that guard state transitions.
* **The Definitive Answer:** Encapsulation means keeping an object’s state valid by exposing only controlled ways to change it.

  ```csharp
  public sealed class BankAccount
  {
      public string AccountNumber { get; }
      public decimal Balance { get; private set; }

      public BankAccount(string accountNumber)
      {
          AccountNumber = accountNumber;
      }

      public void Deposit(decimal amount)
      {
          if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
          Balance += amount;
      }
  }
  ```

  A public `set` on sensitive state is often a design smell because it allows arbitrary mutation outside the domain rules.

---

### Allowing External Systems to Set Sensitive Fields Safely
* **The Question:** If an external system needs to set a sensitive field, how should that be modeled safely?
* **The Follow-ups:** Should the field simply have a public setter? How do you allow the update without breaking encapsulation?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can preserve invariants even when integration requirements create pressure for looser models.
    * **Seniority Markers:** Better answers model this as a **controlled application use case**, not unrestricted external mutation.
* **The Definitive Answer:** Do not expose a wide-open public setter for sensitive fields just because another system needs to populate them. Use a **controlled method**, **factory**, or **application service** that validates the input and records the intended transition.

  ```csharp
  public void AttachExternalId(string externalId)
  {
      if (string.IsNullOrWhiteSpace(externalId))
          throw new ArgumentException("External ID is required.", nameof(externalId));

      if (!string.IsNullOrEmpty(ExternalId))
          throw new InvalidOperationException("External ID is already assigned.");

      ExternalId = externalId;
  }
  ```

  This preserves auditability and invariants while still supporting the integration scenario.

---

### Abstract Classes vs Interfaces
* **The Question:** What is the difference between an abstract class and an interface, and when would you use each?
* **The Follow-ups:** What if types share state such as account number or balance? What if only a behavioral contract is needed?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer can choose the correct abstraction tool for provider families and related domain types.
    * **Seniority Markers:** Expected depth includes **shared state**, **constructors**, **protected members**, and when interfaces better preserve flexibility.
* **The Definitive Answer:** Use an **abstract class** when related types need shared state or shared implementation:

  ```csharp
  public abstract class AccountBase
  {
      protected AccountBase(string accountNumber) => AccountNumber = accountNumber;
      public string AccountNumber { get; }
      public abstract Task SyncAsync(CancellationToken cancellationToken);
  }
  ```

  Use an **interface** when the concern is purely contractual:

  ```csharp
  public interface IAccountSynchronizer
  {
      Task SyncAsync(CancellationToken cancellationToken);
  }
  ```

  Abstract classes model a **family with shared implementation**. Interfaces model **capability and substitution**.

---

### Abstract Methods and Non-Abstract Classes
* **The Question:** Can a non-abstract class declare an abstract method? Why not?
* **The Follow-ups:** What does the language require when a type contains abstract members?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a syntax-and-semantics check on how C# models incomplete types.
    * **Seniority Markers:** A correct answer explains that abstract members imply incomplete implementation, so the containing type cannot be instantiated directly.
* **The Definitive Answer:** No. A non-abstract class cannot declare an abstract method because an abstract method has **no implementation in that type**. Any class containing abstract members must itself be marked `abstract`.

  ```csharp
  public abstract class ProviderJob
  {
      public abstract Task ExecuteAsync(CancellationToken cancellationToken);
  }
  ```

  The rule exists because otherwise C# would allow instantiating a type whose required behavior is still incomplete.

---

### Breaking Cyclic Dependencies
* **The Question:** How do you break a cyclic dependency between two classes?
* **The Follow-ups:** What should the extracted third component contain? Why is that better than leaving the circular reference in place?
* **Interviewer's Mental Model:**
    * **The 'Why':** Cyclic dependencies are a design smell. The interviewer was checking whether the engineer can recognize missing abstractions and separate concerns.
    * **Seniority Markers:** Strong answers mention **extracting shared responsibilities**, **introducing an abstraction**, or using **events/mediators** where appropriate.
* **The Definitive Answer:** Break the cycle by extracting the shared or coordinating behavior into a third abstraction so the original two classes no longer depend on each other directly.

  Typical options:

  - Extract a **shared service**.
  - Introduce a **narrow interface** so one side depends on the contract only.
  - Move orchestration into a **higher-level coordinator**.
  - Use **domain events** or a mediator when asynchronous notification is the real requirement.

  The important design move is to identify which responsibility created the two-way dependency and relocate it.

---

### 🎯 Critical Focus Areas for this Section
- Encapsulation means enforcing invariants, not merely exposing properties.
- Choose abstract classes for shared state and interfaces for capability contracts.
- Cyclic dependencies usually indicate a missing abstraction or misplaced orchestration.

## Error Handling and Runtime Behavior

### Error Handling in .NET Applications
* **The Question:** How should error handling be structured in a .NET application?
* **The Follow-ups:** Where should exceptions be caught? When should project-level error-handling conventions or middleware be used?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking for production-grade thinking around predictability, logging, and consistent failure behavior.
    * **Seniority Markers:** Expected depth includes **exception boundaries**, **global middleware**, **structured logging**, and distinguishing exceptional failures from validation results.
* **The Definitive Answer:** In modern ASP.NET Core systems:

  - Use **exceptions for exceptional conditions**, not ordinary branching.
  - Catch exceptions at **meaningful boundaries**, such as integration edges or global middleware.
  - Preserve context through **structured logging** and correlation data.
  - Translate failures into consistent API responses through **exception-handling middleware** or filters.
  - Use result objects or validation errors for expected business-rule failures when exceptions would be too noisy.

  Good error handling is about **predictable system behavior**, **diagnosability**, and **clear ownership of failure boundaries**.

---

### The Role of `finally`
* **The Question:** What does `finally` do in `try` / `catch` / `finally`?
* **The Follow-ups:** Why is it useful for cleanup? Does it run only when an exception occurs?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a core control-flow check around cleanup semantics.
    * **Seniority Markers:** A complete answer says `finally` runs regardless of success or failure, subject to catastrophic process termination scenarios.
* **The Definitive Answer:** The `finally` block runs after `try` and `catch` processing whether an exception occurred or not. It is used for cleanup actions that must happen regardless of outcome.

  ```csharp
  StreamReader? reader = null;

  try
  {
      reader = File.OpenText(path);
      return await reader.ReadToEndAsync();
  }
  finally
  {
      reader?.Dispose();
  }
  ```

  In modern C#, `using` and `await using` are often cleaner than manual `finally`, but `finally` is still the core mechanism behind guaranteed cleanup.

---

### Custom Exceptions
* **The Question:** When should you use custom exceptions, and how are they written?
* **The Follow-ups:** How do custom exceptions help distinguish business or integration failures? What should they contain?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer wanted to know whether the engineer can model domain-specific failures instead of collapsing everything into generic exceptions.
    * **Seniority Markers:** Strong answers use custom exceptions sparingly, name them well, include context, and preserve inner exceptions when wrapping lower-level failures.
* **The Definitive Answer:** Use a custom exception when the failure type is meaningful to callers or to boundary handling, such as a provider auth failure or a domain-specific invariant violation.

  ```csharp
  public sealed class ProviderAuthenticationException : Exception
  {
      public ProviderAuthenticationException(string message, Exception? innerException = null)
          : base(message, innerException)
      {
      }
  }
  ```

  Good practices:

  - Suffix the name with `Exception`.
  - Include a clear message.
  - Preserve the original exception as `innerException` when wrapping.
  - Do not create custom exception types for every minor error.

---

### Delegates
* **The Question:** What are delegates in C#?
* **The Follow-ups:** Why are they useful? How do they allow behavior to be passed around and invoked later?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks understanding of function references, callback pipelines, and event infrastructure in the language.
    * **Seniority Markers:** Expected depth includes **type safety**, **multicast invocation**, and practical use in callbacks, LINQ, and events.
* **The Definitive Answer:** A delegate is a **type-safe function reference**. It defines the shape of a callable target so methods matching that signature can be passed, stored, and invoked later.

  ```csharp
  public delegate decimal FeeCalculator(decimal amount);
  ```

  Delegates enable callbacks, strategy-style behavior injection, and event handling. Many common .NET APIs use the generic delegate types `Action<>`, `Func<>`, and `Predicate<>` instead of custom delegate declarations.

---

### `Action`, `Func`, and `Predicate`
* **The Question:** What is the difference between `Action`, `Func`, and `Predicate`?
* **The Follow-ups:** Which one returns a value? Which one is specifically Boolean-returning?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a practical language-usage question. The interviewer wanted more than “they are delegates.”
    * **Seniority Markers:** Strong answers map each type to its signature and common use case.
* **The Definitive Answer:**

  - `Action<T1, ...>`: returns **`void`**.
  - `Func<T1, ..., TResult>`: returns **a value of `TResult`**.
  - `Predicate<T>`: returns **`bool`** and is semantically used for yes/no tests.

  ```csharp
  Action<string> log = message => Console.WriteLine(message);
  Func<int, int, int> add = (x, y) => x + y;
  Predicate<int> isEven = value => value % 2 == 0;
  ```

  `Predicate<T>` is essentially a specialized Boolean-returning delegate, while `Func<T, bool>` is the more general form commonly seen in modern APIs.

---

### Events and Their Relationship to Delegates
* **The Question:** What are events, and how do they relate to delegates?
* **The Follow-ups:** Why are events safer than exposing raw delegates directly? What happens when there are no subscribers?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands publisher-subscriber control and the delegated mechanism beneath events.
    * **Seniority Markers:** Better answers explain that events restrict outside callers to **subscription/unsubscription**, while only the publisher can raise the event.
* **The Definitive Answer:** An event is a delegate-based notification mechanism with restricted access. External code can subscribe and unsubscribe, but only the declaring type can raise the event.

  ```csharp
  public sealed class AccountNotifier
  {
      public event EventHandler<string>? ThresholdReached;

      public void Raise(string message) => ThresholdReached?.Invoke(this, message);
  }
  ```

  If no subscribers exist, the backing delegate is `null`, which is why `?.Invoke(...)` is the standard pattern. Events are safer than exposing a delegate field because callers cannot replace or invoke the invocation list directly.

---

### Garbage Collection in .NET
* **The Question:** How does garbage collection work in .NET?
* **The Follow-ups:** What are generations? What is the collector trying to optimize?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer wanted platform-level understanding beyond “memory is cleaned automatically.”
    * **Seniority Markers:** Expected depth includes **generational collection**, **reachability**, and the distinction between managed memory cleanup and explicit unmanaged resource cleanup.
* **The Definitive Answer:** .NET uses a **tracing, generational garbage collector**. Managed objects are allocated on the managed heap, and the GC reclaims objects that are no longer reachable from application roots.

  Key concepts:

  - **Generation 0**: short-lived objects.
  - **Generation 1**: intermediate survivors.
  - **Generation 2**: longer-lived objects.

  This design optimizes for the fact that most objects die young. The GC focuses on reclaiming memory efficiently while minimizing pause cost.

---

### Reachability and “Still in Use”
* **The Question:** How does the runtime determine whether an object is still reachable?
* **The Follow-ups:** Is it just about scope, or more generally about references from GC roots?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer understands the real GC model instead of reducing it to “variables going out of scope.”
    * **Seniority Markers:** Strong answers mention **GC roots** such as stack references, statics, and active handles.
* **The Definitive Answer:** The GC determines liveness by tracing from **GC roots**:

  - Local variables on active stacks
  - Static fields
  - CPU registers
  - GC handles and runtime-managed references

  If an object cannot be reached from those roots, it becomes eligible for collection. Scope often correlates with reachability, but the precise rule is **graph reachability from roots**, not simply lexical scope.

---

### When the Garbage Collector Runs
* **The Question:** When does the garbage collector run?
* **The Follow-ups:** Is it on a fixed schedule? Should `GC.Collect()` normally be called manually?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands GC as runtime-managed and heuristic-driven.
    * **Seniority Markers:** A strong answer says GC runs based on **allocation pressure** and runtime heuristics, and that manual forcing is unusual.
* **The Definitive Answer:** The GC does **not** run on a fixed schedule like “every two hours.” It runs based on runtime heuristics such as:

  - Allocation pressure
  - Available memory
  - Survivor promotion patterns
  - Overall application behavior

  Calling `GC.Collect()` manually is usually discouraged unless there is a very specific, measured scenario. In most applications, the runtime is better at deciding when collection should occur.

---

### `IDisposable` and Unmanaged Resources
* **The Question:** How should unmanaged resources be handled with `IDisposable`?
* **The Follow-ups:** Why is garbage collection not enough for file handles, sockets, and other unmanaged resources?
* **Interviewer's Mental Model:**
    * **The 'Why':** This distinguishes memory reclamation from deterministic resource cleanup.
    * **Seniority Markers:** Expected depth includes **`using`**, **`await using`**, ownership semantics, and the difference between managed objects and unmanaged handles.
* **The Definitive Answer:** Garbage collection manages **managed memory**, but it does not provide timely cleanup of unmanaged resources such as file handles, sockets, or native handles. Types that own such resources should implement `IDisposable` so callers can release them deterministically.

  ```csharp
  await using var stream = new FileStream(path, FileMode.Open);
  ```

  `Dispose()` is for **deterministic cleanup**. Finalizers are a fallback safety net for specific cases, not the primary cleanup strategy.

---

### Ownership of `Dispose()`
* **The Question:** Whose responsibility is it to call `Dispose()`?
* **The Follow-ups:** Does the runtime call it automatically? What changes when the DI container creates the object?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests a subtle but important ownership rule in .NET resource management.
    * **Seniority Markers:** Strong answers explain that the **owner** of the disposable resource is responsible, unless ownership is transferred to a framework such as the DI container.
* **The Definitive Answer:** The code that **owns** the disposable object is responsible for disposing it.

  - If you create it directly, you should dispose it, usually with `using` or `await using`.
  - If ASP.NET Core's DI container creates a scoped or singleton disposable service, the **container** disposes it at the end of the appropriate lifetime.

  ```csharp
  using var connection = new SqlConnection(connectionString);
  ```

  The key rule is **ownership determines disposal responsibility**. The GC does not guarantee timely `Dispose()` calls for you.

---

### 🎯 Critical Focus Areas for this Section
- Error handling should be consistent, observable, and boundary-aware.
- Know the delegate/event model well enough to explain invocation, subscription, and safety.
- Distinguish managed memory collection from deterministic cleanup of unmanaged resources.
