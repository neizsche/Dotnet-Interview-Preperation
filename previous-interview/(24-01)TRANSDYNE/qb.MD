# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. If a list is sorted, how does that change search time complexity?
2. What are RESTful resource-naming conventions, especially for child resources?
3. What does idempotent mean in HTTP, and how is it different from safe methods?
4. If only one field of a resource needs to be updated, which HTTP method and URI shape should be used?
5. What are the key differences between `PUT` and `PATCH`?
6. What is the difference between `Select` and `SelectMany` in LINQ?
7. What are `Singleton`, `Scoped`, and `Transient` lifetimes in dependency injection?
8. What is a CTE, and how is it different from a temporary table?
9. How would you write a SQL query to compute winners by constituency and avoid misuse of `DISTINCT` or missing `GROUP BY`?
10. How would you find the one-based index of the last unique character in a string?
11. How would you determine the largest odd-number substring from a numeric string?
12. How would you solve the 7-liter and 11-liter water-container problem to measure 15 liters?

## Algorithms and Problem Solving

### Search Complexity on Sorted Data
* **The Question:** If a list is sorted, how does that affect search time complexity?
* **The Follow-ups:** Would it still be `O(n)`? Does the answer depend on the algorithm used?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands that performance comes from the **algorithm + data shape**, not from the data being sorted by itself.
    * **Seniority Markers:** Awareness of **linear search vs binary search**, **preconditions for binary search**, and the trade-off between sort cost and lookup frequency.
* **The Definitive Answer:** Sorting does not automatically change lookup complexity. It only enables algorithms that rely on ordering. If you still do a linear scan, the complexity remains **`O(n)`**. If the data is sorted and random access is available, you can use **Binary Search** and reduce lookup to **`O(log n)`**. If sorting must be performed first, the end-to-end cost becomes **`O(n log n)` + lookup cost**, so binary search is only a win when either the data is already sorted or many lookups amortize the sort.

  ```csharp
  var index = Array.BinarySearch(sortedArray, target);
  ```

---

### Last Unique Character Index
* **The Question:** How would you compute the one-based index of the last unique character in a string?
* **The Follow-ups:** Can you do it without reversing the string? Can you do it with one or two passes cleanly?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can reason about **frequency tracking**, **order preservation**, and **single-pass vs two-pass trade-offs**.
    * **Seniority Markers:** Expected depth includes **dictionary counting**, **stable iteration**, and avoidance of wasteful string reversal when not needed.
* **The Definitive Answer:** The cleanest answer is a **two-pass** solution: first count character frequencies, then scan the string from right to left and return the first character whose frequency is `1`. This avoids reversal and keeps the logic explicit.

  ```csharp
  static int LastUniqueCharIndex1Based(string input)
  {
      var counts = new Dictionary<char, int>();

      foreach (var ch in input)
          counts[ch] = counts.TryGetValue(ch, out var n) ? n + 1 : 1;

      for (var i = input.Length - 1; i >= 0; i--)
      {
          if (counts[input[i]] == 1)
              return i + 1; // one-based index
      }

      return -1;
  }
  ```

---

### Largest Odd-Number Substring
* **The Question:** Given a numeric string, how do you determine the largest odd number that is a substring of it?
* **The Follow-ups:** Is generating all substrings necessary? What is the shortest valid reasoning path?
* **Interviewer's Mental Model:**
    * **The 'Why':** This probes whether the engineer can discover the **greedy property** of the problem instead of brute-forcing substrings.
    * **Seniority Markers:** The interviewer was looking for **pattern recognition**, **string-index reasoning**, and avoidance of unnecessary combinatorics.
* **The Definitive Answer:** The largest odd-number substring is the **longest prefix ending at the last odd digit that can serve as the suffix endpoint**. Since the string is numeric and we want the largest substring in-place, scan from right to left for the first odd digit. Return the prefix from index `0` to that index. If no odd digit exists, return an empty string.

  ```csharp
  static string LargestOddSubstring(string digits)
  {
      for (var i = digits.Length - 1; i >= 0; i--)
      {
          if (((digits[i] - '0') & 1) == 1)
              return digits[..(i + 1)];
      }

      return string.Empty;
  }
  ```

---

### Water Jug State-Space Reasoning
* **The Question:** With 7-liter and 11-liter containers, how do you measure exactly 15 liters?
* **The Follow-ups:** Can you minimize the sequence of steps? Can you reason about state transitions rather than trial and error?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a state-transition problem. The interviewer wanted to see structured reasoning rather than random operations.
    * **Seniority Markers:** Expected depth includes **state modeling**, **BFS-style reasoning**, and recognition that jug problems are graph problems over reachable states.
* **The Definitive Answer:** Model each state as `(x, y)` where `x` is the amount in the 7-liter jug and `y` is the amount in the 11-liter jug. Allowed transitions are fill, empty, and pour until one jug is full or the other is empty. To reach 15 liters total across both containers, one valid target state is `(4, 11)`. This can be found via deterministic reasoning or BFS over states.

  The architecturally correct answer in interview form is not memorizing a specific sequence; it is showing you understand how to model the problem as **reachable states** and derive the shortest valid path.

---

### 🎯 Critical Focus Areas for this Section
- **Algorithm preconditions**: sorted data only matters if the algorithm can exploit ordering.
- **Greedy vs brute-force reasoning**: recognize when a full substring search is unnecessary.
- **State modeling**: many “puzzle” questions are graph/search problems disguised as logic exercises.

## Backend and API Design

### RESTful Resource Naming
* **The Question:** What are RESTful naming conventions, especially when representing child resources?
* **The Follow-ups:** How should resource paths look? Why is a path like `patients/{id}/address` clearer than a generic patch endpoint?
* **Interviewer's Mental Model:**
    * **The 'Why':** Resource naming affects **discoverability**, **contract clarity**, **OpenAPI readability**, and long-term maintainability.
    * **Seniority Markers:** Expected depth includes **plural resource naming**, **hierarchical resource paths**, and resource-oriented thinking instead of RPC-style URLs.
* **The Definitive Answer:** In REST, URIs should identify **resources**, not actions. Use plural collections and nested sub-resources where the hierarchy is meaningful. If the address of a patient is being updated, the path should make that explicit, for example:

  ```http
  PATCH /patients/{id}/address
  ```

  This is clearer than burying semantics in vague action routes because it aligns the URI with the domain resource model and makes the contract easier to understand for humans, documentation tools, and clients.

---

### Idempotency vs Safe Methods
* **The Question:** What does idempotent mean in HTTP, and how is that different from a safe method?
* **The Follow-ups:** Is `PUT` idempotent? Is `POST` idempotent? Are safe methods the same thing?
* **Interviewer's Mental Model:**
    * **The 'Why':** Correct retry behavior, cache design, and incident recovery depend on understanding **idempotency** precisely.
    * **Seniority Markers:** The interviewer was looking for clear separation between **safety** and **idempotency**, especially for backend systems exposed to retries and distributed calls.
* **The Definitive Answer:** A method is **idempotent** if making the same request multiple times results in the same final server state as making it once. A method is **safe** if it does not modify server state. These are related but different ideas.

  `GET` is generally both safe and idempotent.

  `PUT` is typically idempotent because replacing a resource with the same representation repeatedly should end in the same state.

  `DELETE` is idempotent from the resource-state perspective even if the second call returns a different status code.

  `POST` is usually not idempotent because repeated calls often create multiple resources or trigger repeated actions.

---

### `PUT` vs `PATCH`
* **The Question:** If only part of a resource changes, should the API use `PUT` or `PATCH`, and what are the real differences between them?
* **The Follow-ups:** Can `PUT` create a resource? Should `PATCH` be used for partial updates? How should the route be modeled for a field such as address?
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests API contract correctness and whether the engineer understands update semantics deeply enough to avoid ambiguous write behavior.
    * **Seniority Markers:** The interviewer wanted clarity on **full replacement**, **partial update**, **idempotency nuance**, and contract design discipline.
* **The Definitive Answer:** Use **`PUT`** when the client is replacing the full resource representation at the target URI. Use **`PATCH`** when the client is modifying only part of the resource. `PUT` is normally modeled as idempotent replacement. `PATCH` semantics depend on the patch document and operation design.

  ```http
  PUT   /patients/{id}
  PATCH /patients/{id}/address
  ```

  In modern ASP.NET Core, a clean partial update is often better represented by a specific command DTO rather than a huge generic mutable contract.

  ```csharp
  public sealed record UpdateAddressRequest(string Line1, string City, string PostalCode);
  ```

---

### 🎯 Critical Focus Areas for this Section
- **Resource-oriented API design**: plural nouns, meaningful child-resource routes, and explicit update targets.
- **Transport correctness**: understand safe vs idempotent semantics for retries and distributed workflows.
- **Write-contract design**: choose `PUT` vs `PATCH` intentionally and keep DTOs explicit.

## LINQ, DI, and SQL Semantics

### `Select` vs `SelectMany`
* **The Question:** What is the difference between `Select` and `SelectMany` in LINQ?
* **The Follow-ups:** Why would `SelectMany` be used when traversing categories and products? What does flattening actually mean?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a probe for whether the engineer understands query shape, not just syntax memorization.
    * **Seniority Markers:** Expected depth includes **projection**, **flattening nested enumerables**, and choosing operators based on data shape.
* **The Definitive Answer:** `Select` performs a **one-to-one projection** from each source element to a result element. `SelectMany` performs a projection that returns nested sequences and then **flattens** them into a single sequence.

  ```csharp
  var categoryNames = categories.Select(c => c.Name);
  var allProducts = categories.SelectMany(c => c.Products);
  ```

  Use `SelectMany` when the source contains collections inside each element and the final result should be a single flattened stream.

---

### Dependency Injection Lifetimes
* **The Question:** What are `Singleton`, `Scoped`, and `Transient` lifetimes in ASP.NET Core dependency injection?
* **The Follow-ups:** How do these behave across controller, service, and repository layers? Why does it matter for database access?
* **Interviewer's Mental Model:**
    * **The 'Why':** Lifetime misuse causes **shared-state bugs**, **thread-safety issues**, **DbContext misuse**, and hidden data corruption patterns.
    * **Seniority Markers:** The expected depth includes **one instance per app**, **one instance per request**, **one instance per resolution**, and the ability to explain why services with request-specific state must not be singletons.
* **The Definitive Answer:** In ASP.NET Core:

  `Singleton` creates exactly one instance for the entire application lifetime.

  `Scoped` creates one instance per request scope.

  `Transient` creates a new instance every time the service is resolved.

  ```csharp
  builder.Services.AddSingleton<IClock, SystemClock>();
  builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
  builder.Services.AddTransient<IHashingService, HashingService>();
  ```

  Use `Scoped` for request-bound services such as EF `DbContext`. Use `Singleton` only for stateless, thread-safe, app-wide services. Use `Transient` for lightweight, state-free helpers where per-resolution creation is acceptable.

---

### Common Table Expressions in SQL Server
* **The Question:** What is a CTE, and how is it different from a temporary table?
* **The Follow-ups:** Does a CTE physically store data? Does it stay in memory? Why would you use it?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands SQL expression shaping versus physical materialization.
    * **Seniority Markers:** They wanted awareness that a CTE is primarily a **query-expression tool**, not a magical storage construct.
* **The Definitive Answer:** A **CTE** (`WITH ... AS`) is a named query expression that exists for the scope of a single statement. It improves readability and supports recursive queries, but it is not the same thing as a temp table. SQL Server may inline or optimize it as part of the execution plan; it is not inherently materialized into a reusable stored structure.

  ```sql
  with RankedVotes as (
      select
          ConstituencyId,
          CandidateId,
          Votes,
          row_number() over (
              partition by ConstituencyId
              order by Votes desc
          ) as rn
      from dbo.Results
  )
  select *
  from RankedVotes
  where rn = 1;
  ```

  Use a temp table when you need intermediate persistence across multiple statements, indexing on intermediate results, or plan-shaping benefits for large multi-step workloads.

---

### SQL Aggregation Correctness: `GROUP BY`, `DISTINCT`, and Winner Queries
* **The Question:** How should a constituency-winner SQL query be written correctly, and why are `DISTINCT` and missing `GROUP BY` often misused?
* **The Follow-ups:** Why might the query fail under stricter SQL modes? Why is `DISTINCT` not a substitute for proper aggregation?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is about writing SQL that is both **correct** and **portable** across stricter execution modes and team code review.
    * **Seniority Markers:** Expected depth includes **window functions**, **aggregation legality**, and understanding that `DISTINCT` hides mistakes instead of expressing intent.
* **The Definitive Answer:** If the goal is “winner per constituency,” the safest modern approach is a **window function** such as `row_number()` instead of mixing aggregates and non-aggregates loosely. `DISTINCT` should not be used to paper over an incorrect grouping shape.

  ```sql
  with RankedCandidates as (
      select
          c.Party,
          r.ConstituencyId,
          r.Votes,
          row_number() over (
              partition by r.ConstituencyId
              order by r.Votes desc
          ) as rn
      from dbo.Results r
      join dbo.Candidates c
          on c.CandidateId = r.CandidateId
  )
  select Party, count(*) as SeatsWon
  from RankedCandidates
  where rn = 1
  group by Party
  order by SeatsWon desc;
  ```

  This expresses the intent directly: identify one winner per constituency, then aggregate by party.

---

### 🎯 Critical Focus Areas for this Section
- **LINQ query shape**: know when you are projecting, flattening, grouping, or materializing.
- **DI lifetime safety**: understand request scope and why backend service lifetime mistakes become production defects.
- **SQL legality and plan quality**: prefer explicit windowing and grouping over `DISTINCT`-driven guesswork.
