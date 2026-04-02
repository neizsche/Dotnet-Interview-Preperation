# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. What is the difference between a static constructor and a private constructor?
2. What is Reflection in .NET?
3. What is a sealed class or sealed method?
4. What are extension methods, and how are they defined?
5. How should an ASP.NET Core project be structured across controllers, services, and the data layer?
6. How do you design API endpoints, models, and return types in ASP.NET Core?
7. What are common HTTP status codes, and what do they mean?
8. What does `IActionResult` do?
9. What is the difference between `IEnumerable` and `IQueryable`?
10. How do LINQ joins fit into query composition?
11. How would you solve a string problem that prints progressive substrings such as `A AB ABC ABCD`?
12. What are indexes in SQL Server, and how many clustered indexes can a table have?
13. What are SQL functions, including table-valued and inline functions?
14. What is the difference between `ROW_NUMBER` and dense ranking functions?
15. What is the difference between `UNION` and `UNION ALL`?
16. What Angular topics matter beyond basic component familiarity, such as operators, custom pipes, and forms?
17. What is the difference between `git fetch` and `git pull`?
18. What baseline cloud knowledge is expected for a modern full-stack role?

## .NET and API Design

### Static Constructor vs Private Constructor
* **The Question:** What is the difference between a static constructor and a private constructor?
* **The Follow-ups:** When does each run? When would each be used in production code?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks whether the engineer understands **type initialization** vs **instance construction control**.
    * **Seniority Markers:** Expected depth includes **CLR static initialization timing**, **singleton/factory patterns**, and why a private constructor changes instantiation semantics.
* **The Definitive Answer:** A **static constructor** initializes a type, not an object. It has no access modifier, no parameters, and runs automatically once per type before first use. A **private constructor** is an instance constructor that blocks outside instantiation, commonly used in **singleton**, **static utility**, or **factory-controlled** designs.

  ```csharp
  public sealed class AppCache
  {
      public static readonly AppCache Instance;

      static AppCache() => Instance = new AppCache();

      private AppCache() { }
  }
  ```

---

### Reflection and Sealed Types
* **The Question:** What is Reflection, and what is a sealed class?
* **The Follow-ups:** Why would you use Reflection? What problem does `sealed` solve?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are baseline C# runtime and inheritance-control concepts.
    * **Seniority Markers:** Expected depth includes **metadata inspection**, **runtime type loading**, **attribute discovery**, and **inheritance restriction** for correctness or optimization.
* **The Definitive Answer:** **Reflection** allows runtime inspection of assemblies, types, members, attributes, generic parameters, and metadata. It is used in serializers, mappers, test runners, ORMs, plugin systems, and framework infrastructure. Use it judiciously because it can add complexity and overhead.

  A **sealed class** prevents inheritance. A **sealed override** prevents further overriding of an inherited virtual method. Use `sealed` when subtype extension would violate invariants or when a closed type design is intentional.

---

### Extension Methods
* **The Question:** What are extension methods, and how are they defined?
* **The Follow-ups:** Why do they look like instance methods? What are the requirements for declaring them?
* **Interviewer's Mental Model:**
    * **The 'Why':** This probes whether the engineer understands C# language sugar and API ergonomics.
    * **Seniority Markers:** They were looking for the exact requirements: **static class**, **static method**, and `this` on the first parameter.
* **The Definitive Answer:** Extension methods are static methods that are callable with instance syntax. They must live in a **static class**, be declared as **static methods**, and the first parameter must be prefixed with `this`.

  ```csharp
  public static class StringExtensions
  {
      public static bool IsNullOrTrimEmpty(this string? value)
          => string.IsNullOrWhiteSpace(value);
  }

  var empty = "  ".IsNullOrTrimEmpty();
  ```

---

### ASP.NET Core Project Structure and API Contracts
* **The Question:** How should an API project be structured, and how should endpoints, controllers, models, and service layers be organized?
* **The Follow-ups:** What belongs in controllers vs services vs the DB layer? What return types should API actions use?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests practical backend architecture discipline.
    * **Seniority Markers:** Expected depth includes **controller thinness**, **service orchestration**, **data-access abstraction**, **DTO separation**, and **HTTP-first return design**.
* **The Definitive Answer:** In a maintainable ASP.NET Core application:

  Controllers or minimal endpoints should handle **HTTP concerns only**.

  Services should coordinate business workflows.

  Repositories or query services should isolate persistence logic when appropriate.

  DTOs should be distinct from domain models when the API contract differs from the internal model.

  Return types should express HTTP outcomes clearly, using `Results<T1, T2>` in minimal APIs or `ActionResult<T>` / `IResult` depending on style.

  ```csharp
  app.MapGet("/api/v1/orders/{id:int}",
      async Task<Results<Ok<OrderDto>, NotFound>> (int id, IOrderService service) =>
      {
          var order = await service.GetAsync(id);
          return order is null ? TypedResults.NotFound() : TypedResults.Ok(order);
      });
  ```

---

### HTTP Status Codes and `IActionResult`
* **The Question:** What are common HTTP status codes, and what does `IActionResult` do?
* **The Follow-ups:** What should be returned for success, creation, validation failure, unauthorized/forbidden access, missing resources, and server errors?
* **Interviewer's Mental Model:**
    * **The 'Why':** APIs live or die by clear transport semantics. This is foundational backend correctness.
    * **Seniority Markers:** They were looking for **transport-level clarity**, **distinguishing 401 vs 403**, and understanding that endpoint return types model multiple response outcomes.
* **The Definitive Answer:** Common status codes:

  `200 OK` for successful reads or command completion with a body.

  `201 Created` for resource creation, ideally with a `Location` header.

  `204 No Content` for successful operations with no response body.

  `400 Bad Request` for validation or malformed input.

  `401 Unauthorized` when authentication is missing or invalid.

  `403 Forbidden` when authentication succeeded but authorization failed.

  `404 Not Found` when the resource does not exist.

  `500 Internal Server Error` for unhandled server faults.

  `IActionResult` is an MVC abstraction that allows an action to return different HTTP result types dynamically. In new .NET applications, `ActionResult<T>`, `IResult`, or typed minimal API results often provide stronger semantics.

---

### `IEnumerable` vs `IQueryable`
* **The Question:** What is the difference between `IEnumerable` and `IQueryable`?
* **The Follow-ups:** When is filtering done in memory, and when is it translated to the provider?
* **Interviewer's Mental Model:**
    * **The 'Why':** Misusing `IQueryable` and materialization boundaries causes major backend performance problems.
    * **Seniority Markers:** Expected depth includes **provider-translated query trees**, **database execution**, **premature materialization**, and repository-boundary caution.
* **The Definitive Answer:** `IEnumerable<T>` represents an in-memory enumerable sequence. LINQ over it runs in the CLR. `IQueryable<T>` represents a provider-backed query expression, usually translated by EF Core or another provider into SQL or another remote query language.

  ```csharp
  IQueryable<User> query = db.Users.Where(u => u.IsActive);
  var list = await query.ToListAsync(); // SQL executes here
  ```

  Keep `IQueryable` inside the data-access boundary unless you intentionally want composable provider queries. Exposing it broadly can leak persistence concerns and produce unbounded query composition.

---

### 🎯 Critical Focus Areas for this Section
- **Type-system fluency**: static initialization, constructor control, reflection, sealed types, and extension methods.
- **HTTP-first API design**: status codes, endpoint return types, and clean project layering.
- **Query-boundary awareness**: know exactly when logic runs in memory vs at the provider/database level.

## Coding and SQL Server

### Progressive Substring Printing
* **The Question:** Given `ABCD`, how do you print `A AB ABC ABCD` in one line using C#?
* **The Follow-ups:** Can the solution be expressed with explicit loops and string operations?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests straightforward string and loop fluency without overcomplication.
    * **Seniority Markers:** The interviewer was checking whether the engineer can quickly express simple iteration logic in C#.
* **The Definitive Answer:** Iterate from `1` to `input.Length`, append `input[..i]` each time, and join with spaces.

  ```csharp
  static string ProgressiveSubstrings(string input)
  {
      var parts = new List<string>(input.Length);

      for (var i = 1; i <= input.Length; i++)
          parts.Add(input[..i]);

      return string.Join(' ', parts);
  }
  ```

---

### SQL Server Indexes and Clustered Index Rules
* **The Question:** What are indexes in SQL Server, and how many clustered indexes can a table have?
* **The Follow-ups:** Why do indexes improve performance? What is the structural role of a clustered index?
* **Interviewer's Mental Model:**
    * **The 'Why':** Indexing is core to backend performance, especially in read-heavy fintech systems.
    * **Seniority Markers:** Expected depth includes **clustered vs nonclustered**, **B-tree access paths**, **seek vs scan behavior**, and the fact that a table can have only **one clustered index** because it defines physical row order.
* **The Definitive Answer:** Indexes improve lookup, join, and ordering performance by providing alternative access paths to data. A SQL Server table can have **exactly one clustered index** because the clustered index defines the physical sort order of the table’s leaf pages. It can have many nonclustered indexes.

  ```sql
  create clustered index CX_Orders_OrderDate on dbo.Orders(OrderDate);
  create nonclustered index IX_Orders_CustomerId on dbo.Orders(CustomerId);
  ```

---

### SQL Functions, `ROW_NUMBER`, `DENSE_RANK`, `UNION`, and `UNION ALL`
* **The Question:** What are SQL functions, what is the difference between `ROW_NUMBER` and dense ranking, and how does `UNION` differ from `UNION ALL`?
* **The Follow-ups:** What are inline and table-valued functions? When should duplicates be preserved?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks ranking semantics, function taxonomy, and result-set combination correctness.
    * **Seniority Markers:** Expected depth includes **inline TVFs**, **multi-statement TVFs**, **rank vs dense rank semantics**, and **duplicate elimination cost** in `UNION`.
* **The Definitive Answer:** SQL Server functions can return a scalar value or a table. An **inline table-valued function (iTVF)** returns the result of a single query and behaves much like a parameterized view. A multi-statement table-valued function materializes into a table variable and often performs worse.

  `ROW_NUMBER()` assigns a unique sequence even across ties.

  `DENSE_RANK()` gives the same rank to ties and does not skip the next rank value.

  `UNION` removes duplicates.

  `UNION ALL` preserves duplicates and is therefore cheaper when deduplication is not required.

  ```sql
  select
      Salary,
      row_number() over (order by Salary desc) as RowNo,
      dense_rank() over (order by Salary desc) as DenseRankNo
  from dbo.Employee;
  ```

---

### 🎯 Critical Focus Areas for this Section
- **String-and-loop fluency**: simple coding tasks should be immediate and clean.
- **SQL Server indexing fundamentals**: clustered index count, access-path design, and performance implications.
- **Ranking and set operators**: know when ties matter and when deduplication is worth the cost.

## Frontend, Tooling, and Delivery

### Angular Basics: Operators, Pipes, and Forms
* **The Question:** What Angular concepts matter beyond basic component familiarity, such as operators, custom pipes, and forms?
* **The Follow-ups:** What are custom pipes used for? What role do operators play?
* **Interviewer's Mental Model:**
    * **The 'Why':** Even in a backend-leaning full-stack role, the interviewer expected practical familiarity with Angular fundamentals.
    * **Seniority Markers:** Expected depth includes **RxJS operators**, **custom transformation logic via pipes**, **reactive vs template-driven forms**, and form validation patterns.
* **The Definitive Answer:** Angular developers should understand:

  **RxJS operators** such as `map`, `switchMap`, `mergeMap`, `catchError`, and `debounceTime`.

  **Pipes**, including built-in pipes and **custom pipes** for display transformation only.

  **Reactive Forms**, including `FormGroup`, `FormControl`, validators, touched/dirty state, and async validation.

  Prefer reactive forms for non-trivial enterprise forms because they are more explicit and testable.

---

### `git fetch` vs `git pull`
* **The Question:** What is the difference between `git fetch` and `git pull`?
* **The Follow-ups:** When should you use each in a team workflow?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a practical workflow literacy question.
    * **Seniority Markers:** Expected depth includes understanding that `pull` is effectively `fetch` plus integration, and that safer workflows often inspect incoming changes before merge/rebase.
* **The Definitive Answer:** `git fetch` downloads remote refs and updates local remote-tracking branches without changing the current working branch. `git pull` performs a `fetch` and then integrates the fetched changes into the current branch, usually via merge or rebase depending on configuration.

  Use `fetch` when you want to inspect changes first. Use `pull` when you intend to integrate them immediately.

---

### Cloud Expectations for a Modern Full-Stack Role
* **The Question:** What level of cloud knowledge is expected for a modern full-stack engineer?
* **The Follow-ups:** Is basic AWS familiarity enough, or is deeper operational awareness needed?
* **Interviewer's Mental Model:**
    * **The 'Why':** Modern full-stack delivery is inseparable from deployment, observability, identity, and environment configuration.
    * **Seniority Markers:** Expected depth includes **basic AWS services**, **compute vs storage vs networking awareness**, **CI/CD integration**, **secret management**, and monitoring basics.
* **The Definitive Answer:** A solid full-stack baseline today includes understanding:

  Compute hosting such as containers, App Service, ECS/EKS, EC2, or Lambda.

  Object storage such as S3.

  Identity and access basics such as IAM.

  Networking concepts such as load balancers, security groups, and private/public boundaries.

  Logging, metrics, alarms, and deployment pipelines.

  For a .NET engineer, cloud literacy should include how APIs are configured, deployed, secured, and observed in non-local environments.

---

### 🎯 Critical Focus Areas for this Section
- **Angular breadth**: RxJS operators, pipes, and forms are baseline full-stack expectations.
- **Git workflow correctness**: understand remote-sync behavior before changing shared branches.
- **Cloud readiness**: deployment, identity, networking, and observability are now table stakes.
