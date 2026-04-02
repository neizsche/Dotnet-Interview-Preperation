# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. How would you move all zero values to the end of an array efficiently?
2. How would you solve a string-transformation problem without relying heavily on built-in helpers?
3. How do static members and constructors affect output in an inheritance scenario?
4. How does exception flow work in nested `try` / `catch` / `finally` blocks?
5. How much practical DB design and Entity Framework experience is expected for a backend engineer?
6. How would you write a SQL query to find the nth highest salary, such as the 10th highest?
7. What is the role of stored procedures in a backend application architecture?
8. What is the Liskov Substitution Principle, and why does it matter?
9. What is the Dependency Inversion Principle, and how is it implemented in practice?
10. What are nullable types in C#?
11. What is the difference between `string` and `StringBuilder`?
12. What does `protected` mean in C# access control?
13. What is Middleware in ASP.NET Core?
14. What is the difference between `Scoped` and `Transient` service lifetimes?
15. What are the core REST principles?
16. What is the difference between authentication and authorization, and how does JWT fit into that flow?
17. What are Factory, Adapter, and Decorator patterns, and when do they matter?
18. What is a Singleton?
19. What Angular concepts matter beyond components?
20. What are bindings, directives, lifecycle hooks, Observables, and component communication patterns in Angular?

## Algorithms and C# Fundamentals

### Move Zeroes to the End Efficiently
* **The Question:** How would you move all zero values to the end of an array efficiently?
* **The Follow-ups:** Can it be done without unnecessary removals and reinsertions? Can it be done in-place?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can convert a naive list-editing idea into an **in-place linear algorithm**.
    * **Seniority Markers:** Expected depth includes **two-pointer techniques**, **stable compaction**, and reasoning about time and space complexity.
* **The Definitive Answer:** The optimal approach is a **stable in-place compaction**: keep a write pointer for the next non-zero slot, scan left to right, copy non-zero values forward, and fill the tail with zeros. This yields **`O(n)` time** and **`O(1)` extra space**.

  ```csharp
  static void MoveZeroes(int[] values)
  {
      var write = 0;

      for (var read = 0; read < values.Length; read++)
      {
          if (values[read] != 0)
              values[write++] = values[read];
      }

      while (write < values.Length)
          values[write++] = 0;
  }
  ```

---

### Solving String Problems Without Overusing Built-Ins
* **The Question:** How should a string transformation problem be solved when built-in helpers are intentionally restricted?
* **The Follow-ups:** Can the solution be expressed with explicit iteration and state instead of `Split`, `Reverse`, or other shortcuts?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was distinguishing between **API familiarity** and **actual algorithmic understanding**.
    * **Seniority Markers:** They were looking for comfort with **character iteration**, **buffer construction**, and explicit control over whitespace and separators.
* **The Definitive Answer:** When built-ins are restricted, solve the problem by iterating over characters directly, tracking boundaries explicitly, and building the result with `Span<T>`, `StringBuilder`, or indexed writes. The key is to show the underlying logic rather than hiding it in library calls.

  ```csharp
  static string ReverseWordsPreservingSingleSpaces(string input)
  {
      var words = new List<string>();
      var start = -1;

      for (var i = 0; i < input.Length; i++)
      {
          if (input[i] != ' ' && start == -1)
              start = i;

          if ((input[i] == ' ' || i == input.Length - 1) && start != -1)
          {
              var end = input[i] == ' ' ? i : i + 1;
              words.Add(input[start..end]);
              start = -1;
          }
      }

      words.Reverse();
      return string.Join(' ', words);
  }
  ```

---

### Static Constructors and Type Initialization Order
* **The Question:** In a program involving parent/child types and static members, how does output execution order behave?
* **The Follow-ups:** When is a static constructor invoked? How does type initialization differ from instance construction?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks actual understanding of **type initialization semantics** rather than vague class-order intuition.
    * **Seniority Markers:** Expected depth includes **type initialization timing**, **instance constructor chaining**, and **base-before-derived initialization rules**.
* **The Definitive Answer:** A **static constructor** runs automatically once per type before any static member is accessed or before the first instance is created, depending on runtime triggers. Instance construction then follows normal constructor chaining: **base constructor before derived constructor**. Static initialization is a type-level concern; instance construction is an object-level concern.

  ```csharp
  class A
  {
      static A() => Console.WriteLine("A static");
      public A() => Console.WriteLine("A ctor");
  }

  class B : A
  {
      static B() => Console.WriteLine("B static");
      public B() => Console.WriteLine("B ctor");
  }
  ```

  Creating `new B()` causes type initialization and constructor chaining in a deterministic order governed by CLR rules.

---

### Nested `try` / `catch` / `finally` Flow
* **The Question:** How does control flow behave in nested `try` / `catch` / `finally` blocks?
* **The Follow-ups:** What changes if the exception is caught and not rethrown? When does `finally` run?
* **Interviewer's Mental Model:**
    * **The 'Why':** Real backend error handling depends on understanding **propagation**, **cleanup guarantees**, and **rethrow semantics**.
    * **Seniority Markers:** Expected signals include **stack unwinding**, **`throw;` vs `throw ex;`**, and deterministic cleanup behavior.
* **The Definitive Answer:** If an exception is caught and not rethrown, propagation stops there. A `finally` block executes whether an exception was thrown or not, including during returns. In nested flows, the runtime unwinds outward until it finds a matching catch, running `finally` blocks along the way.

  ```csharp
  try
  {
      try
      {
          ThrowSomething();
      }
      catch (InvalidOperationException)
      {
          // handled here
      }
      finally
      {
          CleanupInner();
      }
  }
  finally
  {
      CleanupOuter();
  }
  ```

  Use `throw;` to preserve the original stack trace when rethrowing.

---

### 🎯 Critical Focus Areas for this Section
- **In-place array algorithms**: two-pointer thinking, stable compaction, and complexity analysis.
- **CLR execution model**: type initialization, constructor order, and exception propagation.
- **Code without crutches**: show the logic when built-in helpers are intentionally constrained.

## Database and Persistence

### Nth Highest Salary Query in SQL Server
* **The Question:** How would you query the nth highest salary, such as the 10th highest?
* **The Follow-ups:** Can the query handle ties? Should the approach be ranking-based or subquery-based?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can express **ranking logic** correctly in SQL rather than relying on vague sorting intuition.
    * **Seniority Markers:** They were looking for **`DENSE_RANK()` / `ROW_NUMBER()` / `OFFSET` trade-offs**, tie behavior, and clean set-based SQL.
* **The Definitive Answer:** In SQL Server, use a **window function**. If ties should share the same rank, use `DENSE_RANK()`. If exact positional ordering is required regardless of ties, use `ROW_NUMBER()`.

  ```sql
  with RankedSalary as (
      select
          EmployeeId,
          Salary,
          dense_rank() over (order by Salary desc) as SalaryRank
      from dbo.Employee
  )
  select EmployeeId, Salary
  from RankedSalary
  where SalaryRank = 10;
  ```

  This is clearer and more maintainable than nested correlated subqueries for most interview and production scenarios.

---

### DB Design Ownership and Stored Procedures
* **The Question:** What level of database design depth should a backend engineer have, and how should stored procedures fit into the architecture?
* **The Follow-ups:** If the DB team owns stored procedures, what should the application team still understand?
* **Interviewer's Mental Model:**
    * **The 'Why':** In enterprise teams, backend developers often do not own every DB artifact, but they still need strong **query literacy** and **schema-awareness**.
    * **Seniority Markers:** The interviewer was probing for **query-shape awareness**, **ownership boundaries**, and whether the engineer can collaborate effectively with DB specialists.
* **The Definitive Answer:** Even if a dedicated DB team owns stored procedures, the application team still needs to understand **schema design**, **index-sensitive query patterns**, **parameter shape**, **transaction boundaries**, and how stored procedures affect deployment, performance, and testing. Stored procedures are useful for **security boundaries**, **plan stabilization**, **legacy interoperability**, or DB-governed logic, but they should not become an excuse for the app team to ignore SQL behavior.

---

### 🎯 Critical Focus Areas for this Section
- **Window functions**: `ROW_NUMBER`, `RANK`, and `DENSE_RANK` for ranking and tie handling.
- **SQL literacy**: backend engineers still need strong query and schema awareness even with DB-team ownership.
- **Set-based thinking**: express ranking and aggregation declaratively, not procedurally.

## OOP, SOLID, and ASP.NET Core

### Liskov Substitution Principle
* **The Question:** What is the Liskov Substitution Principle, and why do we need it?
* **The Follow-ups:** What breaks when a derived type cannot safely replace a base type?
* **Interviewer's Mental Model:**
    * **The 'Why':** LSP is about **safe inheritance**. Violating it creates runtime surprises, broken invariants, and fragile abstractions.
    * **Seniority Markers:** Expected depth includes **behavioral substitutability**, **postconditions/preconditions**, and understanding that inheritance is not just code reuse.
* **The Definitive Answer:** **Liskov Substitution Principle** means any derived type must be usable anywhere the base type is expected **without breaking correctness or caller assumptions**. A child type must honor the behavioral contract of the parent. It must not strengthen preconditions unexpectedly or violate invariants the caller relies on.

  A common failure is inheriting solely for reuse even when the subtype relationship is false. If `Derived` cannot safely stand in for `Base`, composition or a different abstraction is the correct design.

---

### Dependency Inversion Principle
* **The Question:** What is the Dependency Inversion Principle, and how does it work in practice?
* **The Follow-ups:** How is it implemented in real .NET projects? Why does it improve testability?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is core to scalable ASP.NET Core architecture. Without DIP, systems become tightly coupled and hard to test, replace, or evolve.
    * **Seniority Markers:** They were looking for **abstractions over concrete types**, **constructor injection**, **test doubles**, and DI-container integration.
* **The Definitive Answer:** High-level modules should depend on **abstractions**, not concrete implementations. In ASP.NET Core, this is implemented with **constructor injection** and service registration in the DI container.

  ```csharp
  public interface INotificationSender
  {
      Task SendAsync(string message, CancellationToken ct);
  }

  public sealed class OrderService
  {
      private readonly INotificationSender _sender;

      public OrderService(INotificationSender sender) => _sender = sender;
  }
  ```

  This allows replacing implementations for testing, environment differences, or runtime composition without rewriting the caller.

---

### Nullable Types, `string`, `StringBuilder`, and `protected`
* **The Question:** What are nullable types in C#? How does `string` differ from `StringBuilder`? What does `protected` mean?
* **The Follow-ups:** When should each be used in performance-sensitive backend code?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are baseline C# fluency checks. In production code, misunderstanding them causes null bugs, allocation pressure, and poor encapsulation.
    * **Seniority Markers:** Expected depth includes **nullable value types**, **nullable reference types**, **immutability**, **heap allocation patterns**, and access control semantics.
* **The Definitive Answer:** `int?`, `DateTime?`, and other nullable value types allow a value type to represent `null`. In modern C#, nullable reference types are a compiler-assisted safety feature that makes null intent explicit.

  `string` is **immutable**. Repeated concatenation creates new allocations. `StringBuilder` is appropriate for repeated mutations or large dynamic text assembly.

  `protected` means the member is accessible in the declaring type and in derived types, but not from unrelated callers.

  ```csharp
  string s = "a";
  s += "b"; // new string allocated

  var sb = new StringBuilder();
  sb.Append("a").Append("b");
  ```

---

### Middleware in ASP.NET Core
* **The Question:** What is Middleware in ASP.NET Core?
* **The Follow-ups:** Where do authentication, authorization, exception handling, and request processing belong in the pipeline?
* **Interviewer's Mental Model:**
    * **The 'Why':** Middleware is the backbone of request processing in ASP.NET Core. A full-stack backend engineer must understand pipeline order because it directly affects **security**, **latency**, **short-circuiting**, and **observability**.
    * **Seniority Markers:** The expected depth includes **pipeline ordering**, **short-circuit behavior**, **endpoint routing**, and custom middleware use cases.
* **The Definitive Answer:** Middleware is a pipeline of components that inspect, mutate, short-circuit, or forward HTTP requests and responses. Ordering matters. For example, exception handling should be early, authentication before authorization, and routing before endpoint execution.

  ```csharp
  app.UseExceptionHandler("/error");
  app.UseRouting();
  app.UseAuthentication();
  app.UseAuthorization();
  app.MapControllers();
  ```

  Middleware is where cross-cutting concerns such as logging, correlation IDs, CORS, rate limiting, auth, caching, and exception translation are applied.

---

### Scoped vs Transient vs Singleton
* **The Question:** What is the difference between `Scoped`, `Transient`, and `Singleton` lifetimes?
* **The Follow-ups:** Why does the distinction matter for request processing and service design?
* **Interviewer's Mental Model:**
    * **The 'Why':** Wrong DI lifetime selection causes thread-safety bugs, stale state, and improper `DbContext` usage.
    * **Seniority Markers:** Expected depth includes **per-request scope**, **per-resolution instantiation**, and **thread-safe singleton constraints**.
* **The Definitive Answer:** `Scoped` means one instance per request scope. `Transient` means a new instance every time the service is requested. `Singleton` means one application-wide instance for the process lifetime.

  ```csharp
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
  builder.Services.AddTransient<IClockFormatter, ClockFormatter>();
  builder.Services.AddSingleton<ISystemClock, SystemClock>();
  ```

  Use `Scoped` for EF Core `DbContext` and request-bound services. Use `Singleton` only for stateless, thread-safe shared services. Use `Transient` for lightweight, stateless helpers.

---

### REST, Authentication, Authorization, JWT, and Common Patterns
* **The Question:** What are REST principles? What is the difference between authentication and authorization? What role does JWT play?
* **The Follow-ups:** What about Factory, Adapter, Decorator, and Singleton patterns?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are foundational architecture concepts for a full-stack role that touches APIs, security, and backend composition.
    * **Seniority Markers:** The interviewer was looking for **stateless API thinking**, **claims/scopes**, **token-based auth flow**, and familiarity with common structural/creational patterns.
* **The Definitive Answer:** REST principles include **statelessness**, **resource-oriented URIs**, correct use of HTTP verbs, and cacheability where appropriate. **Authentication** answers “Who are you?” **Authorization** answers “What are you allowed to do?” A **JWT** is a signed token that carries identity and claims used by the API to authenticate and authorize requests.

  `Factory` centralizes object creation.

  `Adapter` translates one interface into another.

  `Decorator` adds behavior around an existing component without modifying its code.

  `Singleton` ensures a single shared instance where that is genuinely appropriate.

---

### 🎯 Critical Focus Areas for this Section
- **Behavioral design correctness**: LSP, DIP, and choosing inheritance vs abstraction responsibly.
- **ASP.NET Core pipeline fluency**: middleware order, DI lifetime selection, and security boundaries.
- **C# fundamentals under production constraints**: nullability, allocation behavior, and access control.

## Angular and Reactive UI Basics

### Angular Bindings, Directives, Hooks, and Observables
* **The Question:** What Angular concepts matter beyond components: bindings, directives, lifecycle hooks, Observables, and component communication?
* **The Follow-ups:** What are `ngOnInit` and `ngOnChanges`? How do `@Input` and `@Output` work? What role do Observables play?
* **Interviewer's Mental Model:**
    * **The 'Why':** Even for a backend-leaning full-stack role, the engineer must understand how modern Angular moves data, reacts to change, and manages async work.
    * **Seniority Markers:** Expected depth includes **property binding**, **event binding**, **two-way binding awareness**, **structural vs attribute directives**, **RxJS streams**, and parent-child communication patterns.
* **The Definitive Answer:** Angular relies on component-driven UI with explicit template bindings. Important concepts:

  **Bindings**
  `{{value}}` for interpolation, `[prop]` for property binding, `(event)` for event binding, and `[(ngModel)]` for two-way binding where forms infrastructure is used.

  **Directives**
  Structural directives such as `*ngIf` and `*ngFor` change DOM structure. Attribute directives such as `ngClass` or custom attribute directives change appearance or behavior.

  **Lifecycle Hooks**
  `ngOnInit` runs after Angular initializes component inputs. `ngOnChanges` runs when input-bound values change.

  **Observables**
  Observables represent asynchronous streams such as HTTP responses, router events, and UI event pipelines. They are central to RxJS-based reactive programming in Angular.

  **Component Communication**
  Parent-to-child uses `@Input()`. Child-to-parent uses `@Output()` with `EventEmitter`.

  ```ts
  @Input() userId!: string;
  @Output() saved = new EventEmitter<void>();
  ```

---

### 🎯 Critical Focus Areas for this Section
- **Angular data flow**: interpolation, property/event binding, and `@Input`/`@Output`.
- **Lifecycle reasoning**: know when hooks run and what work belongs in them.
- **Reactive UI fundamentals**: Observables, async flows, and template-driven state updates.
