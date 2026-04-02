# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. What architectural challenges appear when migrating from legacy ASPX pages to an API-based architecture?
2. Given an array of integers, how do you find the number closest to zero and prefer the greater value on a tie?
3. How do you reason about edge cases such as `0`, equal absolute values, and negative-only ranges in that problem?
4. How does inheritance work in C# using a simple example like `Animal` and `Dog`?
5. If both base and derived classes define the same method, which one executes and why?
6. What is the difference between overriding and method hiding with `new`?
7. What is polymorphism, and how does method overloading differ from runtime overriding?
8. Can method overloading differ only by return type?
9. How do you achieve multiple inheritance in C#?
10. What are the SOLID principles, and how is dependency injection implemented in .NET?
11. What are `Singleton`, `Scoped`, and `Transient` lifetimes?
12. What is the Open-Closed Principle?
13. What are the key REST principles?
14. What is the difference between authentication and authorization, including JWT-based claims and policy models?
15. What is the difference between unit testing, integration testing, and BDD?
16. What is boxing and unboxing, and why can it hurt performance?
17. What are extension methods?
18. What are delegates?
19. What are the different SQL joins?
20. How would you optimize backend performance when the bottleneck is data volume and aggregation?
21. What is Angular two-way binding?
22. What is the difference between stored procedures and functions in SQL Server?

## Architecture and Problem Solving

### Migrating from ASPX Pages to API-Centric Architecture
* **The Question:** What architectural challenges appear when migrating from legacy ASPX pages to a decoupled API-based architecture?
* **The Follow-ups:** Why is debugging harder in page-centric systems? What changes when React or another frontend is introduced on top of APIs?
* **Interviewer's Mental Model:**
    * **The 'Why':** This was a migration-readiness probe. The interviewer wanted to know whether the engineer understands the architectural shift from **page-bound logic** to **service boundaries**.
    * **Seniority Markers:** Expected depth includes **separation of concerns**, **API contracts**, **front/backend decoupling**, **data shaping**, **performance tuning**, and migration risk awareness.
* **The Definitive Answer:** Legacy ASPX pages often mix UI rendering, request orchestration, and data access in the same execution path. Migrating to an API-based architecture requires:

  Extracting business logic out of the page lifecycle.

  Defining stable REST contracts.

  Separating DTOs from UI state.

  Making backend operations observable and testable.

  Reshaping data for modern client rendering rather than server-side page composition.

  The main gains are **debuggability**, **testability**, **performance control**, and frontend/backend independence.

---

### Closest-to-Zero Array Problem
* **The Question:** Given an array of integers, find the number closest to zero. If two values are equally close, return the greater one.
* **The Follow-ups:** How do you compare negative and positive values? What happens with `0`? How should ties be handled?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can keep business rules and edge cases correct under live coding pressure.
    * **Seniority Markers:** Expected depth includes **absolute-value comparisons**, **tie-breaking logic**, **single-pass iteration**, and clean edge-case handling.
* **The Definitive Answer:** The optimal solution is a **single pass** that tracks the current best candidate. Compare candidates using `Math.Abs()`. If the current value is closer to zero, replace the best. If the absolute values are equal, keep the numerically greater value.

  ```csharp
  static int ClosestToZero(int[] values)
  {
      if (values.Length == 0)
          throw new ArgumentException("Input cannot be empty.", nameof(values));

      var best = values[0];

      foreach (var value in values)
      {
          var absValue = Math.Abs(value);
          var absBest = Math.Abs(best);

          if (absValue < absBest || (absValue == absBest && value > best))
              best = value;
      }

      return best;
  }
  ```

  This is **`O(n)` time** and **`O(1)` space**.

---

### 🎯 Critical Focus Areas for this Section
- **Migration architecture**: extract page-bound logic into explicit API and service layers.
- **Edge-case discipline**: coding questions often test correctness under tie rules and null/empty cases.
- **Single-pass reasoning**: many interview problems reward a clean scan more than clever complexity.

## OOP and SOLID

### Inheritance, Overriding, and Polymorphism
* **The Question:** How does inheritance work in C#? If a base and derived class both define the same method, which one executes?
* **The Follow-ups:** What is the difference between overriding and method hiding? What is polymorphism? What is method overloading?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing actual command of the C# type system, not just memorized OOP terms.
    * **Seniority Markers:** Expected depth includes **`virtual` / `override` / `new`**, **runtime dispatch**, **compile-time overload resolution**, and the ability to explain how base references interact with derived instances.
* **The Definitive Answer:** Runtime polymorphism in C# depends on **overriding**, not just name reuse. If a base method is marked `virtual` and the derived method is marked `override`, then the derived implementation runs when the runtime object is of the derived type, even if the reference is typed as the base class.

  ```csharp
  public class Animal
  {
      public virtual string Bark() => "Animal sound";
  }

  public class Dog : Animal
  {
      public override string Bark() => "Dog bark";
  }

  Animal animal = new Dog();
  Console.WriteLine(animal.Bark()); // Dog bark
  ```

  **Method hiding** with `new` changes compile-time resolution, not runtime polymorphic dispatch. **Method overloading** is different: it means same method name, different parameter lists, and resolution occurs at compile time.

---

### Multiple Inheritance in C#
* **The Question:** How do you achieve multiple inheritance in C#?
* **The Follow-ups:** Why can’t multiple class inheritance be used directly?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks language fluency and understanding of why C# uses interfaces instead of multiple class inheritance.
    * **Seniority Markers:** Expected depth includes **interface-based multiple capability composition** and awareness of ambiguity problems in class-based multiple inheritance.
* **The Definitive Answer:** C# does **not** support multiple inheritance of classes. It supports multiple inheritance of **interfaces**.

  ```csharp
  public interface IWalk { void Walk(); }
  public interface IFly { void Fly(); }

  public sealed class Bird : IWalk, IFly
  {
      public void Walk() { }
      public void Fly() { }
  }
  ```

---

### SOLID, DI, and Lifetime Management
* **The Question:** What are the SOLID principles, how is dependency injection implemented in .NET, and what do `Singleton`, `Scoped`, and `Transient` mean?
* **The Follow-ups:** What is the Open-Closed Principle? How should services be registered? Why do lifetimes matter?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a backend architecture baseline check. Without DI and SOLID fluency, large .NET systems become brittle and hard to test.
    * **Seniority Markers:** Expected depth includes **constructor injection**, **abstractions over concrete types**, **request scope**, **thread safety**, and **extension without modification**.
* **The Definitive Answer:** In .NET, dependency injection is usually implemented through the built-in service container. Services should be injected through constructors and coded against abstractions where appropriate.

  `Singleton` = one instance for the application lifetime.

  `Scoped` = one instance per request scope.

  `Transient` = a new instance every time it is requested.

  ```csharp
  builder.Services.AddSingleton<IClock, SystemClock>();
  builder.Services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
  builder.Services.AddTransient<IEmailFormatter, EmailFormatter>();
  ```

  The **Open-Closed Principle** means behavior should be extensible without rewriting stable code. In practice, that often means abstractions, composition, and policy-based extension rather than `if/else` sprawl.

---

### 🎯 Critical Focus Areas for this Section
- **Runtime dispatch**: know exactly how overriding, hiding, and overload resolution differ.
- **Dependency injection fluency**: service registration, lifetime selection, and constructor injection are core .NET skills.
- **Extension-safe design**: use abstractions and composition to satisfy Open-Closed instead of piling behavior into monolith classes.

## REST, Testing, and Runtime Behavior

### REST Principles, Authentication, and Authorization
* **The Question:** What are the principles of REST, and what is the difference between authentication and authorization?
* **The Follow-ups:** How do JWT, claims-based authorization, and policy-based authorization fit into API design?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands both API design and security boundaries.
    * **Seniority Markers:** Expected depth includes **statelessness**, **resource-oriented design**, **JWT bearer auth**, **claims**, and **policy enforcement**.
* **The Definitive Answer:** REST APIs should be **stateless**, **resource-oriented**, and use correct HTTP semantics. Authentication answers “Who is making the call?” Authorization answers “What is that caller allowed to do?” In modern ASP.NET Core APIs, JWT bearer tokens carry identity and claims, and authorization policies evaluate those claims before granting access.

---

### Unit Testing vs Integration Testing vs BDD
* **The Question:** What is the difference between unit testing, integration testing, and BDD?
* **The Follow-ups:** What should be mocked? What should hit real dependencies? Why is BDD different from a narrow unit test?
* **Interviewer's Mental Model:**
    * **The 'Why':** This distinguishes engineers who merely mention tests from engineers who understand **test scope** and **behavior verification**.
    * **Seniority Markers:** Expected depth includes **isolation vs integration**, **mock boundaries**, **system behavior testing**, and awareness of **Gherkin/Cucumber-style flows**.
* **The Definitive Answer:** **Unit tests** isolate a small piece of code and usually replace external dependencies with mocks, fakes, or stubs. **Integration tests** exercise multiple real components together, such as API + database or service + messaging integration. **BDD** describes system behavior in business-readable scenarios and validates end-to-end or broad workflow behavior, often using `Given / When / Then`.

---

### Boxing, Unboxing, Extension Methods, and Delegates
* **The Question:** What are boxing and unboxing? What are extension methods? What are delegates?
* **The Follow-ups:** Why can boxing hurt performance? How do extension methods work syntactically? Why are delegates useful?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are core C# language/runtime concepts that separate day-to-day coders from engineers who understand the platform.
    * **Seniority Markers:** Expected depth includes **heap allocation caused by boxing**, **generic alternatives**, **static-class extension methods**, and **type-safe function references**.
* **The Definitive Answer:** **Boxing** converts a value type to a reference type, usually `object`, allocating on the heap. **Unboxing** converts it back. Excessive boxing causes allocation pressure and GC overhead, which is why generics are preferred.

  **Extension methods** are static methods declared in static classes with `this` on the first parameter, allowing instance-style syntax.

  **Delegates** are type-safe method references used for callbacks, event pipelines, and function passing.

---

### 🎯 Critical Focus Areas for this Section
- **API security boundaries**: stateless REST, JWT bearer auth, claims, and policies.
- **Test-scope discipline**: know which layer should be mocked and which should be integrated.
- **C# runtime literacy**: understand boxing cost, extension-method mechanics, and delegate use cases.

## SQL, Performance, and Frontend Basics

### SQL Joins and Query Shape
* **The Question:** What are the different SQL joins?
* **The Follow-ups:** What data does each join preserve?
* **Interviewer's Mental Model:**
    * **The 'Why':** Join semantics are table-stakes SQL knowledge for backend development.
    * **Seniority Markers:** Expected depth includes **inner vs outer join semantics**, null extension behavior, and using the right join for the right result shape.
* **The Definitive Answer:** `INNER JOIN` returns matching rows only. `LEFT JOIN` keeps all rows from the left side plus any matches from the right. `RIGHT JOIN` does the reverse. `FULL OUTER JOIN` keeps all rows from both sides and fills unmatched columns with `NULL`.

---

### Backend Performance Optimization by Reducing Data Volume
* **The Question:** How do you optimize backend performance when the real bottleneck is large data transfer and aggregation?
* **The Follow-ups:** What if concurrency is already improved and the response is still slow? What role do filtering and pagination play?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a practical system-design question about recognizing when **payload size**, not pure compute, is the limiting factor.
    * **Seniority Markers:** Expected depth includes **fan-out API diagnosis**, **payload shaping**, **pagination**, **lazy loading**, and backend/frontend contract refinement.
* **The Definitive Answer:** If downstream concurrency is already reasonable but performance is still poor, inspect **response volume** and **data shape**. Often the correct fix is not more parallelism, but **sending less data**. Apply filtering, pagination, on-demand loading, and lighter projections so the backend returns only what the client needs for the immediate view.

---

### Angular Two-Way Binding and SQL Stored Procedures vs Functions
* **The Question:** What is Angular two-way binding, and what is the difference between stored procedures and SQL functions?
* **The Follow-ups:** When is two-way binding appropriate? What can functions do that procedures cannot, and vice versa?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are cross-stack baseline concepts for a developer expected to operate across frontend and database boundaries.
    * **Seniority Markers:** Expected depth includes **`[(ngModel)]` semantics**, **event + property binding composition**, and SQL differences around **side effects**, **result usage**, and composability.
* **The Definitive Answer:** Angular **two-way binding** combines property binding and event binding so that component state and template input stay synchronized, commonly via `[(ngModel)]`.

  In SQL Server, **stored procedures** are executable routines that can perform broader procedural operations, multiple statements, and side effects. **Functions** return a scalar or table value and are more constrained; they are meant for composable expression-style use and cannot be treated as full procedural scripts.

---

### 🎯 Critical Focus Areas for this Section
- **Join semantics**: understand the exact preservation behavior of each join type.
- **Payload-aware optimization**: pagination, filtering, and lazy loading often beat brute-force aggregation.
- **Cross-stack basics**: two-way binding and stored procedure/function differences should be immediately explainable.
