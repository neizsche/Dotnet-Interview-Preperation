# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. What are the four OOP concepts, and can you give an example of each?
2. Is an interface the only way to achieve abstraction in C#?
3. When should you use an interface versus an abstract class?
4. How do you create and use an object from another class in C#?
5. How does inheritance work with a base type like `LivingThing` and a derived type like `Person`?
6. If both base and derived classes define the same method, how do you get different behavior?
7. Why can an invalid cast from a base type to a derived type fail?
8. What is method overloading, and can overloads differ only by return type?
9. How do you achieve multiple inheritance in C#?
10. What do `public`, `private`, `protected`, `internal`, and `protected internal` mean?
11. What are the major Angular building blocks apart from components?
12. How do you pass data between parent-child, child-parent, and sibling Angular components?
13. Given an array of integers, how do you return the number closest to zero and prefer the positive value on ties?
14. How would you solve that problem if `Math.Abs()` were unavailable?
15. How do you print one result for numbers divisible by `3`, another for `5`, and a combined result for numbers divisible by both?

## Object-Oriented Design and C# Fundamentals

### The Four OOP Concepts
* **The Question:** What are encapsulation, abstraction, inheritance, and polymorphism, and how should they be explained with C# examples?
* **The Follow-ups:** Give a practical example for each concept. Tie polymorphism to overloading and overriding. Connect encapsulation to access control and properties.
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a baseline fluency check. A mid-level .NET engineer should be able to move from textbook definitions to **runtime behavior**, **API design**, and **maintainable class modeling**.
    * **Seniority Markers:** Strong answers distinguish **what the concept is**, **how C# implements it**, and **where it improves maintainability or extensibility in production code**.
* **The Definitive Answer:** The four OOP pillars are:

  **Encapsulation**: hide internal state and expose controlled behavior. In C#, that means **private fields**, **restricted setters**, and methods that preserve invariants.

  **Abstraction**: expose required behavior while hiding implementation details. In C#, this is typically modeled with **interfaces** or **abstract classes**.

  **Inheritance**: derive a more specific type from a base type to reuse behavior and express an **is-a** relationship.

  **Polymorphism**: allow one contract to drive multiple implementations. In C#, runtime polymorphism comes from **`virtual` / `override`**, while compile-time polymorphism comes from **method overloading**.

  ```csharp
  public abstract class Account
  {
      public decimal Balance { get; protected set; }
      public abstract void Post(decimal amount);
  }

  public sealed class SavingsAccount : Account
  {
      public override void Post(decimal amount) => Balance += amount;
  }
  ```

  The important distinction is that good OOP is not about using all four terms. It is about **preserving invariants**, **reducing coupling**, and **making change safe**.

---

### Abstraction with Interfaces and Abstract Classes
* **The Question:** Is an interface the only way to achieve abstraction in C#?
* **The Follow-ups:** Can abstract classes also provide abstraction? What changes when shared state or shared implementation is required?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether abstraction is understood as a **design boundary**, not as a memorized keyword.
    * **Seniority Markers:** Expected depth includes distinguishing **behavior contracts** from **shared implementation**, and knowing how that affects DI, reuse, and versioning.
* **The Definitive Answer:** No. C# supports abstraction through both **interfaces** and **abstract classes**.

  Use an **interface** when you want to define a capability or contract that unrelated types can implement:

  ```csharp
  public interface INotifier
  {
      Task SendAsync(string message, CancellationToken cancellationToken);
  }
  ```

  Use an **abstract class** when related types share **state**, **protected helpers**, or **partial implementation**:

  ```csharp
  public abstract class ProviderClient
  {
      protected HttpClient HttpClient { get; }

      protected ProviderClient(HttpClient httpClient) => HttpClient = httpClient;

      public abstract Task AuthenticateAsync(CancellationToken cancellationToken);
  }
  ```

  Both are abstraction tools. The choice depends on whether the problem is primarily about a **contract** or a **shared base implementation with invariants**.

---

### Interface vs Abstract Class
* **The Question:** When should you use an interface versus an abstract class?
* **The Follow-ups:** Why does the distinction matter for maintainability and scaling? When is hierarchy appropriate, and when is capability composition better?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests architectural judgment. Many systems become rigid because inheritance and abstraction are used mechanically instead of intentionally.
    * **Seniority Markers:** Strong answers mention **multiple implementations**, **shared state**, **constructor requirements**, **protected members**, and whether the relationship is truly **is-a**.
* **The Definitive Answer:** Use an **interface** when:

  - You need a **behavioral contract** across unrelated types.
  - The consuming code should depend on **abstractions** for DI, testing, and substitution.
  - You may need **multiple implementations** without a shared inheritance tree.

  Use an **abstract class** when:

  - The derived types are genuinely in the **same conceptual family**.
  - You need **shared fields, constructor logic, or protected utility methods**.
  - The base type must enforce some behavior while leaving specific steps abstract.

  In modern .NET, interfaces are usually preferred at **service boundaries**, while abstract classes are used selectively for **shared implementation**. If there is no meaningful common state or invariant, an interface is usually the cleaner choice.

---

### Creating and Using Objects Across Classes
* **The Question:** How do you create and use an object from another class in C#?
* **The Follow-ups:** What must be accessible for this to work? What changes if the type lives outside the current file or namespace?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a lightweight check on type visibility, constructors, and object instantiation fundamentals.
    * **Seniority Markers:** Better answers connect object creation to **access modifiers**, **assembly boundaries**, and **dependency injection** rather than only `new`.
* **The Definitive Answer:** A type can be instantiated from another class when:

  - The type itself is visible, such as `public` or otherwise accessible in the same assembly.
  - The constructor used is accessible.
  - The referencing code has access to the namespace and assembly.

  ```csharp
  using MyApp.Domain;

  public sealed class PersonController
  {
      public Person Build() => new Person("Alex");
  }
  ```

  In production-grade ASP.NET Core code, object creation often happens through **dependency injection** or **factory methods** rather than scattered `new` calls. The key idea is that **visibility rules** and **constructor accessibility** govern whether a type can be created and used.

---

### Inheritance with Base and Derived Types
* **The Question:** How does inheritance work with a base type like `LivingThing` and a derived type like `Person`?
* **The Follow-ups:** What does the derived class receive from the base class? Why is inheritance useful beyond simple code reuse?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer wanted to confirm that inheritance is understood as a **type relationship** and reuse mechanism, not just copied code.
    * **Seniority Markers:** Strong answers explain the **is-a relationship**, inherited members, and when inheritance is appropriate versus composition.
* **The Definitive Answer:** Inheritance allows a derived class to reuse and extend members from a base class when there is a genuine **is-a** relationship.

  ```csharp
  public class LivingThing
  {
      public string Category => "Living";
  }

  public sealed class Person : LivingThing
  {
      public string Name { get; }

      public Person(string name) => Name = name;
  }
  ```

  `Person` inherits the accessible members of `LivingThing` and can add its own state and behavior. Inheritance is useful when derived types share stable common structure or rules. If the relationship is only about behavior sharing, **composition or interfaces** are often a better fit.

---

### Overriding for Different Derived Behavior
* **The Question:** If both base and derived classes define the same method, how do you get different behavior?
* **The Follow-ups:** Which keywords are required? Why is overriding different from simply redeclaring a method?
* **Interviewer's Mental Model:**
    * **The 'Why':** This probes whether the engineer understands **runtime dispatch** and how polymorphism actually works in C#.
    * **Seniority Markers:** Expected depth includes **`virtual`**, **`override`**, and the difference between runtime overriding and compile-time name hiding.
* **The Definitive Answer:** To get different runtime behavior in the derived class, the base method must be marked `virtual` and the derived implementation must be marked `override`.

  ```csharp
  public class LivingThing
  {
      public virtual string Describe() => "A living thing";
  }

  public sealed class Person : LivingThing
  {
      public override string Describe() => "A person";
  }

  LivingThing item = new Person();
  Console.WriteLine(item.Describe()); // A person
  ```

  The runtime selects the implementation based on the **actual object type**. If the derived class merely redeclares the method with `new`, that is **method hiding**, not true runtime overriding.

---

### Invalid Casting from Base to Derived
* **The Question:** Why can an invalid cast from a base type to a derived type fail?
* **The Follow-ups:** Why does a base reference to a derived object work, but the reverse can fail? How do you cast safely?
* **Interviewer's Mental Model:**
    * **The 'Why':** This probes whether the engineer understands **reference type compatibility** and **runtime type safety**.
    * **Seniority Markers:** Strong answers distinguish **compile-time assignability** from **runtime object identity** and mention safe checks like pattern matching.
* **The Definitive Answer:** A cast from base to derived succeeds only when the runtime object is actually an instance of that derived type. A base variable can point to a derived object:

  ```csharp
  LivingThing item = new Person();
  ```

  But this fails if the underlying object is only a `LivingThing`:

  ```csharp
  LivingThing item = new LivingThing();
  var person = (Person)item; // InvalidCastException
  ```

  Use pattern matching or `as` when the type is uncertain:

  ```csharp
  if (item is Person person)
  {
      Console.WriteLine(person.Describe());
  }
  ```

  The rule is simple: **reference conversion is safe only when the object really is that type**.

---

### Method Overloading and Return Types
* **The Question:** What is method overloading, and can overloads differ only by return type?
* **The Follow-ups:** How does the compiler choose an overload? What must be different for overload resolution to work?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a C# language fluency check around compile-time method resolution.
    * **Seniority Markers:** Expected depth includes **parameter-based resolution**, optional parameters, generics, and the fact that return type alone is insufficient.
* **The Definitive Answer:** **Method overloading** means using the same method name with different **parameter signatures**. The compiler resolves the correct overload using the argument list, not the return type.

  ```csharp
  public sealed class MathHelper
  {
      public int Sum(int left, int right) => left + right;
      public decimal Sum(decimal left, decimal right) => left + right;
  }
  ```

  This is **not** valid:

  ```csharp
  // Invalid: only return type differs
  // int Parse(string value)
  // bool Parse(string value)
  ```

  Overloads must differ by **parameter count**, **parameter types**, or **parameter modifiers**, not only by return type.

---

### Multiple Inheritance in C#
* **The Question:** How do you achieve multiple inheritance in C#?
* **The Follow-ups:** Why is class-based multiple inheritance not supported? What is the supported alternative?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests language fundamentals and whether the engineer knows how C# composes behavior safely.
    * **Seniority Markers:** Better answers mention **interfaces**, composition, and the ambiguity problems that class-based multiple inheritance can introduce.
* **The Definitive Answer:** C# does **not** support multiple inheritance of classes. It supports multiple interface implementation:

  ```csharp
  public interface IReadable { string Read(); }
  public interface IWritable { void Write(string value); }

  public sealed class FileAdapter : IReadable, IWritable
  {
      public string Read() => "data";
      public void Write(string value) { }
  }
  ```

  In real systems, the preferred alternative is usually **composition plus interfaces**, not deep inheritance trees.

---

### Access Modifiers in C#
* **The Question:** What do `public`, `private`, `protected`, `internal`, and `protected internal` mean?
* **The Follow-ups:** When would you choose each one? How do assembly boundaries affect visibility?
* **Interviewer's Mental Model:**
    * **The 'Why':** Access control is central to encapsulation and API design. The interviewer wanted clear command of visibility rules.
    * **Seniority Markers:** Strong answers connect modifiers to **encapsulation**, **inheritance**, and **assembly-level boundaries**, not just textbook definitions.
* **The Definitive Answer:**

  - `public`: accessible from any code with reference visibility.
  - `private`: accessible only inside the containing type.
  - `protected`: accessible inside the containing type and derived types.
  - `internal`: accessible anywhere in the same assembly.
  - `protected internal`: accessible either from the same assembly or from derived types in other assemblies.

  Example:

  ```csharp
  public class Account
  {
      private decimal _balance;
      protected decimal Balance => _balance;
      internal string InternalCode { get; init; } = string.Empty;
  }
  ```

  These modifiers are how C# enforces **safe exposure of state and behavior**.

---

### 🎯 Critical Focus Areas for this Section
- Understand OOP as runtime behavior and design boundaries, not just definitions.
- Be precise about `interface` vs `abstract class`, `virtual` vs `override`, and safe casting.
- Treat visibility and type compatibility as part of maintainable API design.

## Frontend Fundamentals

### Angular Building Blocks Beyond Components
* **The Question:** What are the major Angular building blocks apart from components?
* **The Follow-ups:** What roles do services, templates, styling, and supporting framework features play?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the candidate understands Angular as more than a component file with HTML and TypeScript.
    * **Seniority Markers:** Good answers mention **services**, **dependency injection**, **routing**, **directives**, **forms**, and current Angular patterns such as **standalone components** where relevant.
* **The Definitive Answer:** Angular applications are built from more than components. Core building blocks include:

  - **Templates** for declarative UI composition.
  - **Services** for shared logic, API calls, and state coordination.
  - **Dependency Injection** for wiring services into components and other services.
  - **Directives** for reusable DOM behavior.
  - **Routing** for navigation and route-based composition.
  - **Forms** for validation and stateful input handling.
  - **RxJS / signals-based state patterns** for async data flow and shared state.

  In current Angular versions, many applications use **standalone components** instead of relying heavily on `NgModule`-centric structure, but the underlying ideas stay the same: **UI composition**, **shared services**, and **predictable state flow**.

---

### Angular Component Communication
* **The Question:** How do you pass data between parent-child, child-parent, and sibling Angular components?
* **The Follow-ups:** What should be used for direct hierarchy communication, and what should be used when components are siblings or otherwise indirectly related?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks practical frontend communication patterns rather than surface-level Angular familiarity.
    * **Seniority Markers:** Expected depth includes **`@Input` / `input()`**, **`@Output` / `output()`**, shared services, and avoiding tightly coupled component trees.
* **The Definitive Answer:**

  - **Parent to child:** pass data through `@Input()` or the modern `input()` API.
  - **Child to parent:** emit events through `@Output()` or `output()`.
  - **Sibling to sibling:** use a **shared parent**, a **shared service**, or a dedicated state store.

  ```typescript
  @Component({ /* ... */ })
  export class ChildComponent {
    @Input() value = '';
    @Output() saved = new EventEmitter<string>();
  }
  ```

  For sibling components, the cleanest pattern is often a shared service:

  ```typescript
  @Injectable({ providedIn: 'root' })
  export class SelectionService {
    readonly selectedId$ = new BehaviorSubject<number | null>(null);
  }
  ```

  Use direct inputs/outputs for **local tree communication** and shared services or state tools for **cross-component coordination**.

---

### 🎯 Critical Focus Areas for this Section
- Know Angular beyond components: services, DI, templates, routing, directives, and forms.
- Use `@Input` and `@Output` for direct hierarchy flow.
- Use shared state or services for sibling communication instead of forcing component coupling.

## Algorithmic Problem Solving

### Closest Number to Zero with Positive Tie-Breaking
* **The Question:** Given an array of integers, how do you return the number closest to zero and prefer the positive value on ties?
* **The Follow-ups:** How do you handle arrays containing both `-1` and `1`? What about `0`? Can the solution be done in one pass?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a live-coding correctness test. The interviewer was checking edge-case handling under time pressure.
    * **Seniority Markers:** Strong answers show **single-pass iteration**, **deterministic tie-breaking**, and awareness of numerical edge cases.
* **The Definitive Answer:** The correct approach is a **single pass** over the array while tracking the current best candidate. Compare by absolute distance from zero, and if two numbers are equally close, keep the **greater** value so that `1` beats `-1`.

  ```csharp
  static int ClosestToZero(int[] values)
  {
      if (values.Length == 0)
          throw new ArgumentException("Input cannot be empty.", nameof(values));

      var best = values[0];

      foreach (var value in values)
      {
          var absValue = Math.Abs((long)value);
          var absBest = Math.Abs((long)best);

          if (absValue < absBest || (absValue == absBest && value > best))
              best = value;
      }

      return best;
  }
  ```

  Important edge cases:

  - `0` should win immediately because nothing is closer to zero.
  - Equal distances such as `-1` and `1` must return `1`.
  - Using `long` in the absolute-value comparison avoids overflow issues around `int.MinValue`.

---

### Solving the Same Problem Without `Math.Abs()`
* **The Question:** How would you solve the closest-to-zero problem if `Math.Abs()` were unavailable?
* **The Follow-ups:** Can you implement the same logic manually? What edge case must be considered when negating integers?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was probing for underlying reasoning rather than library dependence.
    * **Seniority Markers:** Expected depth includes manually expressing the comparison logic and knowing that naive negation can overflow for `int.MinValue`.
* **The Definitive Answer:** If `Math.Abs()` is unavailable, write a helper that normalizes the comparison safely:

  ```csharp
  static long AbsValue(int value) => value < 0 ? -(long)value : value;
  ```

  Then reuse the same core algorithm:

  ```csharp
  static int ClosestToZero(int[] values)
  {
      if (values.Length == 0)
          throw new ArgumentException("Input cannot be empty.", nameof(values));

      var best = values[0];

      foreach (var value in values)
      {
          var absValue = AbsValue(value);
          var absBest = AbsValue(best);

          if (absValue < absBest || (absValue == absBest && value > best))
              best = value;
      }

      return best;
  }
  ```

  The important point is not whether `Math.Abs()` is used. It is whether the engineer understands the **comparison rule** and the **tie-break rule**.

---

### Divisibility Logic for `3`, `5`, and Both
* **The Question:** How do you print one result for numbers divisible by `3`, another for `5`, and a combined result for numbers divisible by both?
* **The Follow-ups:** In what order should conditions be checked? Why must the combined case come first?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a control-flow sanity check. The interviewer wanted clean branching logic rather than a broken partial solution.
    * **Seniority Markers:** Strong answers handle the **combined branch first**, keep the code simple, and avoid duplicated conditions.
* **The Definitive Answer:** Check the combined divisibility case first. If you check `3` or `5` independently before `3 && 5`, you will consume `15` incorrectly.

  ```csharp
  static string Classify(int value)
  {
      if (value % 15 == 0)
          return "ThreeFive";

      if (value % 3 == 0)
          return "Three";

      if (value % 5 == 0)
          return "Five";

      return value.ToString();
  }
  ```

  `value % 15 == 0` is just a concise way to express divisibility by both `3` and `5`. The real requirement is **ordering the conditions correctly**.

---

### 🎯 Critical Focus Areas for this Section
- Coding questions here emphasize correctness under edge cases more than cleverness.
- Prefer one-pass solutions with explicit tie-break logic.
- For branch problems like `3` / `5` / both, condition ordering is the key correctness detail.
