# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. How do inner join, left join, right join, full outer join, and `UNION` differ in SQL?
2. How would you return values from two overlapping tables as a combined distinct set?
3. How would you find all first-rank students when multiple students can share the top mark?
4. How would you optimize a query that currently uses a subquery for `MAX(Marks)`?
5. What is the difference between a Primary Key and a Unique Key?
6. What is the difference between `ExecuteReader` and `DataAdapter` in ADO.NET?
7. What is the difference between `IEnumerable` and `List`?
8. How do microservices communicate, and what makes an architecture truly microservice-based?
9. What is lazy loading or deferred execution in LINQ?
10. How would you optimize a slow API that aggregates data from many backend services for a React page?
11. What is a static class, and how is it different from just keeping constants in a static-like file?
12. What happens at runtime when a new object is instantiated in .NET?
13. What is the difference between React class components and functional components?
14. When should `map` be used in React?
15. What is a React key?
16. What are Hooks, especially `useState` and `useEffect`?

## SQL and Data Access

### SQL Join Semantics vs `UNION`
* **The Question:** How do inner join, left join, right join, full outer join, and `UNION` differ?
* **The Follow-ups:** What would each query return for overlapping and non-overlapping ID sets? Why is a join not always the right answer?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether the engineer understands **set semantics** instead of mechanically writing joins.
    * **Seniority Markers:** Expected depth includes **matching vs preserving rows**, **null-extended rows**, **shape of result sets**, and knowing when **`UNION`** is the correct relational operation.
* **The Definitive Answer:** Use a **join** when you need to combine columns from related rows across tables. Use **`UNION`** when you need to combine compatible result sets vertically.

  `INNER JOIN` returns only matching rows.

  `LEFT JOIN` returns all left-side rows plus matching right-side rows.

  `RIGHT JOIN` returns all right-side rows plus matching left-side rows.

  `FULL OUTER JOIN` returns all rows from both sides with nulls where no match exists.

  `UNION` merges two result sets and removes duplicates.

  `UNION ALL` merges two result sets and keeps duplicates.

  ```sql
  select Id from dbo.A
  union
  select Id from dbo.B;
  ```

  For a combined result of `1..10` across two overlapping ID sets, `UNION` is the most direct expression.

---

### Ranking Queries: First Rank and Nth Highest
* **The Question:** How do you return all first-rank students when multiple students may share the highest mark?
* **The Follow-ups:** What if a subquery using `MAX(Marks)` becomes slow? How should ranking be written for production clarity?
* **Interviewer's Mental Model:**
    * **The 'Why':** This probes for correct use of **ranking functions**, **tie handling**, and **set-based SQL**.
    * **Seniority Markers:** The interviewer was looking for **`DENSE_RANK()` / `ROW_NUMBER()`**, clean joins, and a move beyond fragile nested subqueries.
* **The Definitive Answer:** The best modern answer is to use **window functions**. For “all first-rank students,” use `DENSE_RANK()` over marks in descending order and filter rank `1`.

  ```sql
  with RankedStudents as (
      select
          s.Id,
          s.Name,
          m.Marks,
          dense_rank() over (order by m.Marks desc) as RankNo
      from dbo.Student s
      join dbo.Marks m
          on m.StudentId = s.Id
  )
  select Id, Name, Marks
  from RankedStudents
  where RankNo = 1;
  ```

  If the interviewer asks for the nth highest salary or nth rank, the same windowing approach applies. Prefer this over ad hoc subqueries when readability and correctness under ties matter.

---

### Primary Key vs Unique Key
* **The Question:** What is the difference between a Primary Key and a Unique Key?
* **The Follow-ups:** Why are they not interchangeable in schema design?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a schema-design fluency check. Real systems use both, and confusing them leads to weak relational modeling.
    * **Seniority Markers:** Expected depth includes **entity identity vs alternate keys**, **nullability behavior**, and **FK targeting**.
* **The Definitive Answer:** A **Primary Key** is the principal identifier for a row. It enforces uniqueness and non-nullability and is the default relational identity of the entity. A **Unique Key** also enforces uniqueness, but it is usually an **alternate key**, not the table’s primary identity.

  In SQL Server, a table has one primary key but may have multiple unique constraints. Foreign keys often reference the primary key, though they can reference other unique candidate keys if explicitly modeled.

---

### ADO.NET: `ExecuteReader` vs `DataAdapter`
* **The Question:** What is the difference between `ExecuteReader` and `DataAdapter`?
* **The Follow-ups:** When should each be used in a .NET data-access layer?
* **Interviewer's Mental Model:**
    * **The 'Why':** This checks whether the engineer understands **connected** vs **disconnected** ADO.NET patterns.
    * **Seniority Markers:** Expected depth includes **forward-only readers**, **buffered `DataSet`/`DataTable` filling**, and memory/performance trade-offs.
* **The Definitive Answer:** `ExecuteReader()` returns a **connected**, forward-only `DbDataReader` for streaming result consumption with minimal overhead. `DataAdapter` is part of the older disconnected ADO.NET model and is used to **fill** a `DataSet` or `DataTable`.

  ```csharp
  await using var cmd = connection.CreateCommand();
  cmd.CommandText = "select Id, Name from dbo.Student";

  await using var reader = await cmd.ExecuteReaderAsync();
  while (await reader.ReadAsync())
  {
      var id = reader.GetInt32(0);
      var name = reader.GetString(1);
  }
  ```

  Use `ExecuteReader` for efficient streaming and low overhead. Use `DataAdapter` only when a disconnected tabular representation is specifically required.

---

### `IEnumerable<T>` vs `List<T>`
* **The Question:** What is the difference between `IEnumerable<T>` and `List<T>`?
* **The Follow-ups:** Why should APIs prefer abstractions over concrete collections?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is about abstraction discipline and understanding iteration contracts.
    * **Seniority Markers:** Expected depth includes **enumeration-only contracts**, **materialized collections**, and avoiding over-constraining signatures.
* **The Definitive Answer:** `IEnumerable<T>` is an **abstraction for forward enumeration**. `List<T>` is a concrete in-memory collection with indexing, resizing, mutation support, and additional methods. Accept `IEnumerable<T>` when the caller only needs iteration. Return a more specific type only when indexing or mutation semantics are part of the contract.

---

### 🎯 Critical Focus Areas for this Section
- **Set semantics in SQL**: know when to join and when to union.
- **Window functions**: ranking, ties, and clean nth-value logic.
- **Abstraction in data access**: stream when possible, materialize only when needed, and use the least-constraining contracts.

## Backend Architecture and Performance

### Microservices Communication and Boundaries
* **The Question:** How do two microservices communicate, and what makes an architecture truly microservice-based?
* **The Follow-ups:** Why is a microservice architecture different from a modular monolith? What are the real benefits?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was checking whether the engineer understands that microservices are about **bounded autonomy**, not just many APIs.
    * **Seniority Markers:** Expected depth includes **HTTP/gRPC/event-driven communication**, **independent deployability**, **bounded contexts**, and **failure isolation**.
* **The Definitive Answer:** Microservices communicate through **explicit service boundaries** such as synchronous HTTP/gRPC calls or asynchronous event/message systems. A true microservice architecture is not just “many services”; it requires independently deployable services, bounded ownership, isolated data where possible, and explicit failure handling.

  The benefit is not automatic scalability alone. The benefit is **independent evolution**, **bounded blast radius**, and clearer domain boundaries when the organization and problem justify the complexity.

---

### LINQ Deferred Execution
* **The Question:** What does lazy loading or deferred execution mean in LINQ?
* **The Follow-ups:** When does a LINQ query actually execute? What changes after calling `ToList()`?
* **Interviewer's Mental Model:**
    * **The 'Why':** LINQ misuse causes hidden multiple enumerations, late exceptions, and performance surprises.
    * **Seniority Markers:** The expected depth includes **query expression building**, **materialization**, and the distinction between in-memory and provider-backed queries.
* **The Definitive Answer:** LINQ queries are often **deferred**: defining the query does not execute it immediately. Execution happens when the sequence is enumerated, for example via `foreach`, `ToList()`, `ToArray()`, `Count()`, or `First()`. Once materialized, the results become an in-memory collection.

  ```csharp
  var query = source.Where(x => x.IsActive); // not executed yet
  var list = query.ToList();                 // executed here
  ```

  This matters because repeated enumeration can re-execute expensive pipelines if the query is not materialized intentionally.

---

### Optimizing a Slow Aggregation API
* **The Question:** How would you optimize a slow API that aggregates data from many backend services for a React page?
* **The Follow-ups:** What if the frontend is acceptable but the API is the bottleneck? What if the endpoint fetches too much data?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a classic full-stack systems question. The interviewer was looking for a developer who thinks in terms of **payload shaping**, **fan-out latency**, **pagination**, and **backpressure**.
    * **Seniority Markers:** Expected depth includes **parallel fan-out analysis**, **request coalescing**, **pagination**, **partial loading**, **BFF patterns**, **caching**, and payload reduction.
* **The Definitive Answer:** Start by measuring the latency budget per downstream call and the total fan-out path. Then optimize in layers:

  Reduce unnecessary downstream calls.

  Parallelize independent calls.

  Cache stable data.

  Shape the response to only what the first render needs.

  Add **pagination**, **sorting**, **filtering**, or **lazy fetch of detail panes**.

  If needed, introduce a **BFF (Backend for Frontend)** or a pre-computed read model.

  The key architectural move is often to stop returning the entire world in one payload.

---

### Static Class vs Constants and CLR Object Creation
* **The Question:** What is a static class, and how is that different from simply storing constants? What happens at runtime when you instantiate an object?
* **The Follow-ups:** When is a static class appropriate? What role does the CLR play during object creation?
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether the engineer understands **type-level utility design** and **CLR-managed allocation**.
    * **Seniority Markers:** Expected depth includes **non-instantiable type semantics**, **managed heap allocation**, and avoiding static-as-global-state abuse.
* **The Definitive Answer:** A **static class** is a non-instantiable type that can contain only static members. It is appropriate for stateless utility behavior or strongly grouped static members. A constants file is usually just a naming convention; a static class is an actual type with language-enforced semantics.

  When `new` is used for a reference type in .NET, the CLR allocates memory on the managed heap, zero-initializes it, wires type metadata, and runs the instance constructor after base-type construction rules are satisfied.

---

### 🎯 Critical Focus Areas for this Section
- **Distributed performance thinking**: fan-out latency, payload shaping, and pagination over brute-force aggregation.
- **LINQ execution awareness**: deferred execution, materialization, and repeated enumeration hazards.
- **CLR and type semantics**: understand static utility types and object allocation at runtime.

## React Fundamentals

### Class Components vs Functional Components
* **The Question:** What is the difference between React class components and functional components?
* **The Follow-ups:** Why are functional components generally preferred now?
* **Interviewer's Mental Model:**
    * **The 'Why':** A full-stack developer working with modern React should know that the ecosystem has moved toward **function components + Hooks**.
    * **Seniority Markers:** Expected depth includes **Hook-based composition**, simpler mental model, and reduced class/lifecycle complexity.
* **The Definitive Answer:** Class components were the older stateful React pattern using lifecycle methods such as `componentDidMount`. Functional components are plain functions that render UI and use **Hooks** for state, effects, memoization, and context. Modern React code is primarily written with **functional components** because they compose behavior more cleanly and align with current tooling and React’s direction.

---

### `map`, Keys, and Hooks in React
* **The Question:** When should `map` be used in React, what is a React key, and what do `useState` and `useEffect` do?
* **The Follow-ups:** Why do keys matter? When does `useEffect` run?
* **Interviewer's Mental Model:**
    * **The 'Why':** These are basic but critical React concepts. Getting them wrong causes unstable list rendering, unnecessary re-renders, and effect bugs.
    * **Seniority Markers:** Expected depth includes **list rendering**, **stable identity**, **local state**, **side effects**, and dependency-array semantics.
* **The Definitive Answer:** Use `map` to transform a collection into a list of React elements. Every list element should have a **stable key** that identifies the underlying entity, not the array index unless the list is static and append-only.

  `useState` stores local component state.

  `useEffect` runs side effects such as subscriptions, data fetches, timers, or imperative sync logic after render, according to its dependency list.

  ```tsx
  function UserList({ users }: { users: User[] }) {
    const [selectedId, setSelectedId] = useState<string | null>(null);

    useEffect(() => {
      if (selectedId) {
        console.log("Selection changed", selectedId);
      }
    }, [selectedId]);

    return (
      <ul>
        {users.map(user => (
          <li key={user.id} onClick={() => setSelectedId(user.id)}>
            {user.name}
          </li>
        ))}
      </ul>
    );
  }
  ```

  Use entity IDs for keys wherever possible so React reconciliation stays stable.

---

### 🎯 Critical Focus Areas for this Section
- **Modern React model**: function components over class components for current production code.
- **Stable list rendering**: correct use of `map` and keys to preserve identity.
- **Effect discipline**: know when local state changes should trigger side effects and how dependencies control execution.
