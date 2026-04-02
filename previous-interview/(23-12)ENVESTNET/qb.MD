# .NET Full-Stack Interview Knowledge Base

## Questions Asked

1. What factors, constraints, and trade-offs must be considered when designing a database schema for an application?
2. How should a team evaluate introducing a new database technology or framework into a long-running SQL Server product?
3. What is an API, and what advantages does API-driven design provide in a modern backend?
4. How do you identify who is calling an API, and how do you choose the correct HTTP verb and request shape?
5. What are the core HTTP verbs, and when should `GET`, `POST`, `PUT`, `PATCH`, and `DELETE` be used?
6. What practical limits apply to `POST` requests, and where should request data live: route, query, headers, or body?
7. If you create a TypeScript or Angular component, how do you make it available inside a test?
8. Given employees, positions, sales milestones, incentive amounts, and caps, how would you compute incentive payouts in SQL?
9. Can the incentive SQL be expressed in a different set-based shape without a direct join, and what trade-offs does that introduce?
10. How would you translate the incentive-calculation problem into C# using classes and proper object-oriented design?
11. How should the design change if organization-specific rules alter the incentive cap for one position, such as halving the cap for `GM`?
12. How should defaults and tenant-specific overrides be modeled in a reusable rule engine?
13. When should you use an interface, and when should you use an abstract class?
14. Which is the better fit for an extensible rule engine: an interface or an abstract class?
15. If a base class and derived class define the same method, which implementation executes at runtime?
16. How do `virtual`, `override`, `abstract`, and method hiding with `new` differ in C#?

## Database and Persistence

### OLTP Schema Design for SQL Server
* **The Question:** When designing the database for an application, what factors, constraints, and trade-offs must be considered?
* **The Follow-ups:** Normalization vs duplication; integrity enforcement; indexing strategy; performance; whether stored procedures and database functions should be part of the design; whether newer database technologies should be introduced.
* **Interviewer's Mental Model:**
    * **The 'Why':** In a production OLTP system, schema mistakes become latency, lock escalation, deadlocks, migration pain, and data-quality defects. A full-stack engineer working on backend-heavy fintech systems must understand how domain modeling maps to **transactional integrity**, **query plans**, and **operational safety**.
    * **Seniority Markers:** The interviewer was looking for depth in **3NF vs targeted denormalization**, **PK/FK/UNIQUE/CHECK constraints**, **index selectivity**, **covering indexes**, **SARGability**, **transaction isolation**, **concurrency control**, and awareness that stored procedures/functions are deployment and ownership choices, not just coding preferences.
* **The Definitive Answer:** A production-grade SQL Server schema should be designed from **access patterns backward**, not from entities alone. Start with the domain invariants, write patterns, read patterns, audit requirements, and retention rules. Use **normalized tables by default** to avoid update anomalies, then denormalize only where measured read pressure justifies it. Encode invariants in the database with **PRIMARY KEY**, **FOREIGN KEY**, **UNIQUE**, **CHECK**, and **NOT NULL** constraints. Choose data types deliberately: avoid oversized variable-width columns, use `decimal(p,s)` for money-like values, use `datetime2`, and avoid stringly typed status fields if the state machine is constrained.

  Indexes should be driven by actual `WHERE`, `JOIN`, `ORDER BY`, and pagination patterns. In SQL Server, that means: cluster on a stable, narrow key when possible; add **nonclustered indexes** for hot predicates; include columns to avoid key lookups where justified; use **filtered indexes** for sparse predicates; and keep predicates **SARGable** so indexes are usable. Model concurrency explicitly with **rowversion**, optimistic concurrency tokens, or carefully chosen isolation levels such as **READ COMMITTED SNAPSHOT** where appropriate. Stored procedures and user-defined functions are architectural tools, not defaults: use them when you need **security boundaries**, **plan stability**, **centralized business logic**, or DBA-governed performance tuning.

  ```sql
  create table dbo.Employee (
      EmployeeId      int            not null primary key,
      PositionId      int            not null,
      MonthlySales    int            not null check (MonthlySales >= 0),
      RowVersion      rowversion     not null
  );

  create table dbo.PositionRule (
      PositionId              int             not null primary key,
      SalesMilestone          int             not null check (SalesMilestone > 0),
      IncentivePerMilestone   decimal(18,2)   not null check (IncentivePerMilestone >= 0),
      MaxCapAmount            decimal(18,2)   not null check (MaxCapAmount >= 0)
  );

  create index IX_Employee_PositionId on dbo.Employee(PositionId);
  ```

---

### Evaluating New Persistence Technology in a Long-Lived System
* **The Question:** If a long-running product already uses SQL Server, how should a team evaluate introducing a new framework or a new kind of database?
* **The Follow-ups:** What if stakeholders ask for a newer technology? How do you approach change when the platform already has many customers and a large amount of data?
* **Interviewer's Mental Model:**
    * **The 'Why':** Mature systems fail from reckless rewrites more often than from old-but-stable technology. The interviewer was probing for **architectural governance**, **migration safety**, and **risk-based modernization**.
    * **Seniority Markers:** Expected signals include **ADR-driven decisions**, **proof-of-concept benchmarking**, **dual-write avoidance**, **backfill strategy**, **cutover safety**, **backward compatibility**, **operability**, and a clear understanding of when **polyglot persistence** is justified.
* **The Definitive Answer:** Do not introduce a new persistence technology because it is newer; introduce it only when there is a demonstrated mismatch between current non-functional requirements and the relational store. The decision process should be: define the problem in measurable terms, list non-functional requirements, create an **Architecture Decision Record (ADR)**, benchmark the current SQL Server approach first, then benchmark the candidate technology against the same workload. If the relational model still satisfies the access pattern, operational maturity, consistency requirements, and reporting needs, keep SQL Server.

  A new store becomes justified only when the problem is specific, such as extremely high-cardinality append-only events, document-shaped data with weak relational constraints, key-value lookups at scale, or search-heavy workloads better served by a dedicated engine. In a regulated or fintech-style environment, prefer **incremental extraction** over a platform-wide rewrite: isolate one bounded context, define migration and rollback paths, validate observability, confirm backup/restore posture, and avoid hidden consistency models. The safest path is usually **polyglot persistence by bounded context**, not random technology drift inside the same core transactional workflow.

---

### Set-Based SQL for Incentive Calculation
* **The Question:** Given employees, positions, sales milestones, incentive amounts, and caps, how would you compute the earned incentive in SQL?
* **The Follow-ups:** Interpret milestone math correctly; treat sales in multiples of the threshold; return results ordered by employee ID; explain whether a join is needed or whether a set-based alternative exists.
* **Interviewer's Mental Model:**
    * **The 'Why':** This tests whether the engineer can translate business rules into **set-based SQL** instead of imperative loops. In high-throughput systems, poor SQL shape produces bad execution plans, excessive scans, and correctness bugs.
    * **Seniority Markers:** They were looking for **integer division / floor semantics**, **set-based joins**, **cap logic with `CASE`**, avoidance of RBAR, and awareness that a correlated subquery or `APPLY` can replace a join but is not automatically better.
* **The Definitive Answer:** The correct SQL solution is to join the employee row to the rule row for that employee's position, compute the number of completed milestones using integer division, multiply by the incentive amount, then cap the result with `CASE`. The solution should remain purely set-based.

  ```sql
  select
      e.EmployeeId,
      case
          when (e.MonthlySales / r.SalesMilestone) * r.IncentivePerMilestone > r.MaxCapAmount
              then r.MaxCapAmount
          else (e.MonthlySales / r.SalesMilestone) * r.IncentivePerMilestone
      end as EarnedIncentive
  from dbo.Employee e
  join dbo.PositionRule r
      on r.PositionId = e.PositionId
  order by e.EmployeeId;
  ```

  In SQL Server, integer division already truncates toward zero for positive values, so `MonthlySales / SalesMilestone` gives the completed milestone count for non-negative sales. A join is the cleanest formulation because the rules are normalized into a separate table. A scalar subquery or `cross apply` can express the same logic, but the right question is not "Can I avoid a join?" The right question is "Which shape is most legible and gives the best plan for the real schema and indexes?"

---

### Translating a SQL Rule into an Extensible C# Domain Model
* **The Question:** How would you implement the same incentive-calculation problem in C# using classes and design patterns instead of embedding everything in one procedure?
* **The Follow-ups:** The implementation must work across multiple organizations; return typed results; keep the design reusable; prepare for future enhancements.
* **Interviewer's Mental Model:**
    * **The 'Why':** The interviewer was testing whether the engineer can move from a one-off SQL answer to a maintainable **domain model**. This is about **change isolation**, **multi-tenant policy variation**, and avoiding a brittle `if/else` rules blob.
    * **Seniority Markers:** Expected depth includes **records or immutable DTOs**, **separation of data from policy**, **Strategy/Policy pattern**, **dependency injection**, testability, and avoiding hard-coded rule branching by position or organization.
* **The Definitive Answer:** The correct .NET 8+ design is to separate **input data**, **calculation policy**, and **result projection**. The rule engine should not know about UI concerns or persistence concerns. Model the domain with immutable inputs, then inject one or more rule policies.

  ```csharp
  public sealed record EmployeeInput(
      int EmployeeId,
      string PositionCode,
      int MonthlySales);

  public sealed record IncentiveRule(
      string PositionCode,
      int SalesMilestone,
      decimal IncentivePerMilestone,
      decimal MaxCapAmount);

  public sealed record IncentiveResult(
      int EmployeeId,
      decimal Amount);

  public interface IIncentivePolicy
  {
      decimal Calculate(EmployeeInput employee, IncentiveRule rule);
  }

  public sealed class DefaultIncentivePolicy : IIncentivePolicy
  {
      public decimal Calculate(EmployeeInput employee, IncentiveRule rule)
      {
          var milestoneCount = employee.MonthlySales / rule.SalesMilestone;
          var rawAmount = milestoneCount * rule.IncentivePerMilestone;
          return Math.Min(rawAmount, rule.MaxCapAmount);
      }
  }
  ```

  The service layer should compose data retrieval and policy execution, not bury business rules inside controllers. That keeps the system testable, multi-organization friendly, and ready for versioned rule sets. In .NET 8+, favor small services, constructor injection, and pure rule functions that are deterministic and easy to unit test.

---

### 🎯 Critical Focus Areas for this Section
- **SQL Server schema design**: constraints, data types, SARGability, and index design tied to real query patterns.
- **Set-based rule implementation**: integer-division business rules, capping logic, joins vs `APPLY`, and execution-plan awareness.
- **Domain/persistence separation**: keep transaction data, rule policy, and organization-specific variation isolated so changes do not ripple through the codebase.

## Backend and API Design

### API Design Fundamentals in ASP.NET Core
* **The Question:** What is an API, and what is the advantage of using APIs in a modern backend?
* **The Follow-ups:** Why are APIs better than page-coupled request handling? What makes a REST-style API maintainable?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is not a beginner definition question. It is a probe for whether the engineer understands **contract boundaries**, **decoupling**, **deployment independence**, and the reason a legacy page-centric application should be moved to services.
    * **Seniority Markers:** The expected depth is **resource design**, **statelessness**, **versioning**, **consumer independence**, **cross-service interoperability**, and how APIs fit into **microservices** and **frontend/backend separation**.
* **The Definitive Answer:** An API is a **stable contract boundary** that lets one component interact with another without embedding implementation details. In ASP.NET Core, the value of an API is not merely "communication"; the real value is **decoupling**. It lets the frontend evolve independently, enables other internal services to reuse the same contract, supports observability and authorization at the boundary, and turns a monolithic page flow into explicit domain operations.

  A well-designed REST API should be **resource-oriented**, **stateless**, **versionable**, and explicit about status codes and error contracts. For a long-lived system, the API boundary also becomes the place to enforce **authentication**, **authorization**, **validation**, **idempotency**, **rate limiting**, **structured logging**, and **OpenAPI-based discoverability**.

  ```csharp
  app.MapGet("/api/v1/employees/{employeeId:int}/incentive",
      Results<Ok<IncentiveResult>, NotFound> (
          int employeeId,
          IIncentiveService service) =>
      {
          var result = service.GetIncentive(employeeId);
          return result is null ? TypedResults.NotFound() : TypedResults.Ok(result);
      });
  ```

---

### Caller Identity, HTTP Semantics, and Request Payload Design
* **The Question:** How do you identify who is calling an API, how do you choose the right HTTP verb, and how should request data be passed?
* **The Follow-ups:** List the common HTTP verbs; explain their semantics; explain how to tell whether the caller is a user or another application; explain how data is passed in path, query, headers, or body; discuss whether `POST` has limits.
* **Interviewer's Mental Model:**
    * **The 'Why':** This is the heart of production API design: **identity**, **authorization**, **idempotency**, and **transport correctness**. In full-stack work, these choices directly affect cacheability, retries, incident blast radius, and security posture.
    * **Seniority Markers:** The interviewer was looking for **OAuth 2.0 / OpenID Connect**, **JWT claims**, **client credentials**, **mTLS/API key awareness**, correct use of **GET/POST/PUT/PATCH/DELETE**, and knowledge that size limits are controlled by **Kestrel/reverse proxy/server configuration**, not the HTTP verb itself.
* **The Definitive Answer:** You do not identify the caller by guessing from the body. You identify the caller through the **authentication mechanism** at the transport boundary. For an end user, that is typically **OpenID Connect** with a user token; for a machine-to-machine call, it is usually **OAuth 2.0 client credentials**, **mTLS**, or another service identity mechanism. The API determines who the caller is from the authenticated principal and its claims, scopes, client ID, certificate identity, or API key policy.

  Use HTTP verbs by semantics:

  `GET` reads a resource and must be safe and idempotent.

  `POST` creates a subordinate resource or triggers a non-idempotent processing action.

  `PUT` replaces a resource representation and should be idempotent.

  `PATCH` partially updates a resource and may or may not be idempotent depending on the patch document.

  `DELETE` removes a resource and should be idempotent from the client's perspective.

  Request data belongs in different places depending on meaning:

  `route/path` identifies the resource.

  `query` filters, sorts, pages, or modifies read behavior.

  `headers` carry metadata such as auth, correlation IDs, and content negotiation.

  `body` carries the command or representation.

  `POST` does not have a universal protocol-level payload limit. The effective limit is imposed by **Kestrel**, **IIS**, **Nginx**, **load balancers**, WAFs, and application-level configuration. The correct approach is to set explicit limits, validate size early, and avoid oversized request bodies when streaming or chunked upload patterns are more appropriate.

  ```csharp
  builder.Services
      .AddAuthentication("Bearer")
      .AddJwtBearer("Bearer", options =>
      {
          options.Authority = "https://issuer.example";
          options.Audience = "trading-api";
      });

  app.MapPatch("/api/v1/patients/{id:int}/address",
      async (int id, UpdateAddressRequest request, IPatientService service) =>
      {
          await service.UpdateAddressAsync(id, request);
          return Results.NoContent();
      })
      .RequireAuthorization();
  ```

---

### Framework Selection and Governance for Full-Stack Systems
* **The Question:** How should a team approach framework or stack decisions such as pairing a .NET backend with Angular or another frontend framework?
* **The Follow-ups:** Who should make the decision? How should architectural ownership differ from feature implementation ownership?
* **Interviewer's Mental Model:**
    * **The 'Why':** In senior full-stack work, engineers must understand that architectural choices are not random taste decisions. They affect **team topology**, **testing**, **build pipelines**, **upgrade cadence**, **component reuse**, and **operational complexity**.
    * **Seniority Markers:** The interviewer was looking for awareness of **architecture decision records**, **frontend testing/tooling implications**, **team-level standards**, and separation between product delivery and architecture governance.
* **The Definitive Answer:** Framework choice should be a deliberate architecture decision, not an ad hoc feature-team preference. The right process is to define the business constraints and non-functional requirements first: component complexity, rendering model, state management complexity, hiring footprint, testing strategy, bundle size, accessibility needs, SSR/CSR trade-offs, and operational tooling. Then capture the decision in an **ADR**, define the supported version policy, and document the migration path.

  In a mature product, the individual engineer should be able to **justify** the choice and implement within it, but governance belongs to the architecture process. That means the team standardizes the framework, linting, testing, deployment, and dependency-upgrade posture so that the codebase does not fragment into multiple UI patterns with incompatible maintenance costs.

---

### 🎯 Critical Focus Areas for this Section
- **HTTP correctness**: verb semantics, idempotency, route/query/body boundaries, and status-code discipline.
- **Security at the API boundary**: caller identity via OAuth/JWT/client credentials, claims-based authorization, and request-size enforcement.
- **Contract-first design**: versioned APIs, OpenAPI, typed DTOs, and architecture decisions that separate service boundaries from UI concerns.

## Frontend Testing

### Testing a TypeScript/Angular Component Correctly
* **The Question:** If you create a component in TypeScript, how do you use that component in a test?
* **The Follow-ups:** How does the component become available to the test? What if it has dependencies, providers, or child components?
* **Interviewer's Mental Model:**
    * **The 'Why':** A full-stack engineer cannot stop at "the selector is used somewhere." The interviewer was probing whether the engineer understands **Angular test composition**, **module/provider setup**, and how UI logic is validated without booting the whole application.
    * **Seniority Markers:** Expected depth includes **Angular TestBed**, **standalone components**, **module imports**, **provider mocking**, **change detection**, **component fixtures**, **DOM assertions**, and isolation from backend services via stubs or HTTP testing utilities.
* **The Definitive Answer:** In modern Angular, a component is tested by creating a **testing module** or **standalone TestBed configuration**, importing the component (or its module), wiring required providers, creating a `ComponentFixture`, and then driving change detection and assertions. You do not "use the selector" as the core testing mechanism; the selector matters only when composing a host component or integration test.

  For Angular 17+ standalone components:

  ```ts
  import { TestBed } from '@angular/core/testing';
  import { By } from '@angular/platform-browser';
  import { UserCardComponent } from './user-card.component';

  describe('UserCardComponent', () => {
    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [UserCardComponent]
      }).compileComponents();
    });

    it('renders the user name', () => {
      const fixture = TestBed.createComponent(UserCardComponent);
      fixture.componentRef.setInput('name', 'Alex');
      fixture.detectChanges();

      const el = fixture.debugElement.query(By.css('[data-testid="name"]'));
      expect(el.nativeElement.textContent).toContain('Alex');
    });
  });
  ```

  For components with dependencies, mock providers explicitly. For HTTP interactions, use Angular's HTTP testing utilities. For parent-child composition, create a host test component or include the dependent component in the testing configuration. The goal is deterministic, isolated UI verification with clear control over change detection and async behavior.

---

### 🎯 Critical Focus Areas for this Section
- **Angular testing fundamentals**: `TestBed`, `ComponentFixture`, standalone imports, host testing, and provider mocking.
- **Typed UI contracts**: strong input/output contracts, testable component boundaries, and deterministic DOM assertions.
- **Async stability**: change detection timing, HTTP test doubles, and avoiding flaky component tests.

## Object-Oriented Design and Extensibility

### Rule Variation for Multi-Organization Deployments
* **The Question:** If a new organization-specific requirement changes the incentive cap for one role, how should the design accommodate that without hard-coding special cases everywhere?
* **The Follow-ups:** What if the `GM` role gets a 50% cap reduction? Should the input be changed? Should a new parameter be passed? How should defaults behave? Can interfaces be used?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a classic maintainability test. The interviewer wanted to see whether the engineer would build a rule engine with **policy injection** or fall into a brittle pile of `if (position == "GM")` branches.
    * **Seniority Markers:** They were looking for **Strategy pattern**, **configuration-driven behavior**, **tenant-aware policy selection**, **default policy fallbacks**, and separation between **core calculation logic** and **organization overrides**.
* **The Definitive Answer:** Organization-specific rule variation should be modeled as a **policy**, not as a conditional tangle inside one calculation method. The calculation flow should resolve the applicable rule set for the tenant and role, then apply the policy. Defaults should come from a baseline policy, and overrides should be additive.

  ```csharp
  public interface ICapPolicy
  {
      decimal ResolveCap(EmployeeInput employee, IncentiveRule rule);
  }

  public sealed class DefaultCapPolicy : ICapPolicy
  {
      public decimal ResolveCap(EmployeeInput employee, IncentiveRule rule)
          => rule.MaxCapAmount;
  }

  public sealed class GmHalfCapPolicy : ICapPolicy
  {
      public decimal ResolveCap(EmployeeInput employee, IncentiveRule rule)
          => employee.PositionCode == "GM"
              ? rule.MaxCapAmount / 2m
              : rule.MaxCapAmount;
  }

  public sealed class IncentivePolicy : IIncentivePolicy
  {
      private readonly ICapPolicy _capPolicy;

      public IncentivePolicy(ICapPolicy capPolicy) => _capPolicy = capPolicy;

      public decimal Calculate(EmployeeInput employee, IncentiveRule rule)
      {
          var milestones = employee.MonthlySales / rule.SalesMilestone;
          var rawAmount = milestones * rule.IncentivePerMilestone;
          var cap = _capPolicy.ResolveCap(employee, rule);
          return Math.Min(rawAmount, cap);
      }
  }
  ```

  In .NET 8+, this policy can be selected via DI per tenant, per organization, or via a rules registry keyed by organization and role. That keeps the code open for extension without rewriting the base calculator.

---

### Interface vs Abstract Class
* **The Question:** When should you use an interface, and when should you use an abstract class?
* **The Follow-ups:** Which is the better fit for a rule engine? Can an abstract class include implementation? Can an interface express capability without shared state?
* **Interviewer's Mental Model:**
    * **The 'Why':** This question probes whether the engineer understands **behavior contracts** versus **shared implementation/state**. It is really about designing stable extension points.
    * **Seniority Markers:** The interviewer expected clarity around **multiple implementations**, **shared protected members**, **template method pattern**, **default interface members**, and using interfaces as **DI boundaries**.
* **The Definitive Answer:** Use an **interface** when you need a capability contract and want consumers to depend on behavior rather than implementation. Interfaces are the preferred boundary for **dependency injection**, testing, and multiple independent implementations. Use an **abstract class** when the types truly share **state**, **protected helpers**, or **default implementation** that should live in one place.

  In modern C#, interfaces may have **default interface members**, but that does not make them a replacement for abstract classes. The decision rule is simple:

  If you need a contract boundary, use an interface.

  If you need shared state or reusable implementation with inheritance semantics, use an abstract class.

  For the incentive-engine case, an interface is usually better for the rule policy boundary, while an abstract base may make sense only if multiple policies genuinely share reusable stateful behavior.

---

### Runtime Dispatch, `virtual`, `override`, and Method Hiding
* **The Question:** If a base class and derived class define the same method, which implementation executes at runtime, and how do you properly override behavior?
* **The Follow-ups:** What happens when an object is referenced by the base type? How do `virtual`, `override`, `abstract`, and `new` differ? How would you model a `Vehicle`/`Car` example correctly?
* **Interviewer's Mental Model:**
    * **The 'Why':** This is a probe into actual C# object model understanding. A backend engineer with real experience should understand **runtime polymorphism**, not just know the word "inheritance."
    * **Seniority Markers:** Expected depth includes **base-reference/derived-instance dispatch**, **virtual dispatch table behavior at the language level**, **abstract methods**, **method hiding with `new`**, and why misuse breaks extensibility and predictability.
* **The Definitive Answer:** If the method is marked `virtual` in the base class and `override` in the derived class, and the object is actually a derived instance, the **derived override executes**, even if the variable is typed as the base class. If the derived method uses `new`, the method is only **hidden**, not overridden, and the chosen method depends on the **compile-time type of the reference**.

  ```csharp
  public abstract class Vehicle
  {
      public abstract string Drive();
  }

  public sealed class Car : Vehicle
  {
      public override string Drive() => "Car-specific drive logic";
  }

  Vehicle vehicle = new Car();
  var result = vehicle.Drive(); // "Car-specific drive logic"
  ```

  Use `abstract` when the base type requires derived implementations to supply behavior. Use `virtual` when the base type provides default behavior that a derived type may refine. Avoid `new` unless you intentionally want compile-time method hiding, which is usually the wrong tool for domain extensibility.

---

### 🎯 Critical Focus Areas for this Section
- **Policy-based design**: Strategy/Policy pattern, default behaviors, and tenant-specific overrides without branching sprawl.
- **Type-system fluency**: interfaces as contracts, abstract classes for shared state, and correct use of `virtual`/`override`/`abstract`.
- **Runtime correctness**: understand dispatch, method hiding, and how OOP choices affect testability, maintainability, and extension safety.
