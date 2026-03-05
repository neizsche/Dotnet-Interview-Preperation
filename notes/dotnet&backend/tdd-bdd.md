# TDD and BDD - Senior Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
This module now combines two interview-critical tracks: quality engineering (TDD/BDD/unit testing strategy) and EF Core query-performance depth. TDD/BDD gives fast feedback loops and shared behavior language, while query-performance practices prevent production latency and scale failures. Senior engineers need both: reliable delivery mechanics and data-access performance discipline.

## 2. Structured Study Material

### A. Testing Strategy and Engineering Quality

#### Why Unit Testing Matters

Unit testing = validating the smallest testable unit (method/function/class) in isolation.

Key impact:
- Early defect detection.
- Better code quality and maintainability.
- Regression safety for refactoring.
- Faster feedback in CI/CD.
- Executable behavior documentation.

#### Unit vs Integration vs End-to-End

| Aspect | Unit Testing | Integration Testing | End-to-End Testing | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Scope | Single unit | Interactions between components | Full user workflow | Broader scope gives higher confidence but slower runs | Use all three with pyramid balance |
| Isolation | High | Medium | Low | Isolation improves speed but can miss wiring issues | Majority at unit level |
| Speed | Fastest | Medium | Slowest | Slow suites reduce release velocity | Keep E2E minimal and high-value |
| Failure diagnosis | Easiest | Moderate | Hardest | Debug cost rises with scope | Use integration/E2E for boundary and journey checks |

#### .NET Test Frameworks (NUnit, MSTest, xUnit)

| Aspect | NUnit | MSTest | xUnit | Trade-offs | When to Use |
|---|---|---|---|---|---|
| Style | Attribute-driven (`[Test]`, `[TestCase]`) | VS-native framework | Modern convention (`[Fact]`, `[Theory]`) | Feature differences are smaller than team/tooling consistency | Standardize one per repo |
| Ecosystem | Mature | Microsoft-integrated | Strong modern ecosystem | Switching frameworks has migration and training cost | Keep stable unless clear gain |
| Parameterized tests | `TestCase`/`TestCaseSource` | `DataRow` | `Theory`/`InlineData` | Syntax preference varies | Choose by team familiarity |

#### Testable Code Characteristics and Design Principles

Testable code is:
- Modular, cohesive, and clear.
- Loosely coupled with explicit dependencies.
- Minimal side effects.
- Easy to isolate via interfaces.

Design patterns/principles that improve testability:
- Dependency Injection (DI).
- Inversion of Control (IoC).
- Single Responsibility Principle (SRP).
- Separation of Concerns (SoC).
- Factory Method for creation seams.

#### Arrange-Act-Assert Structure

```csharp
using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void Add_WhenGivenTwoNumbers_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 7;
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(a, b);

        // Assert
        Assert.AreEqual(12, result);
    }
}
```

Core test components:
- Test fixture.
- Test method.
- Arrange setup.
- Act execution.
- Assert verification.
- Optional teardown.

#### Test Doubles

| Type | Purpose | Typical Use |
|---|---|---|
| Mock | Verify interactions/calls | Collaboration-heavy logic |
| Stub | Return canned responses | Deterministic branch control |
| Spy | Observe interactions post-fact | Side-effect observation |
| Fake | Lightweight working impl | In-memory replacement for heavy infra |
| Dummy | Placeholder input | Unused parameter satisfaction |

#### Mocking Frameworks

Moq:

```bash
Install-Package Moq
```

```csharp
using Moq;

var mockDependency = new Mock<IDependency>();
mockDependency.Setup(d => d.MethodToMock()).Returns(expectedResult);

var result = codeUnderTest.DoSomething(mockDependency.Object);

mockDependency.Verify(d => d.MethodToVerify(), Times.Once);
```

NSubstitute:

```bash
Install-Package NSubstitute
```

```csharp
using NSubstitute;

var substituteDependency = Substitute.For<IDependency>();
substituteDependency.MethodToMock().Returns(expectedResult);

var result = codeUnderTest.DoSomething(substituteDependency);

substituteDependency.Received(1).MethodToVerify();
```

#### Coverage Metrics

| Metric | What It Measures | Strength | Limitation |
|---|---|---|---|
| Statement coverage | Executed statements | Fast baseline signal | Can hide weak assertions |
| Branch coverage | Executed branch paths | Better logic-path confidence | Still not behavior quality alone |
| Function coverage | Invoked methods | API surface signal | Limited depth |
| Decision/condition coverage | True/false condition evaluation | Strong for rule-heavy logic | More setup complexity |
| Path coverage | Execution path combinations | Deepest confidence | Path explosion impractical |

Guideline: high coverage is useful, but assertion quality and risk-based scenario coverage matter more.

#### CI/CD Integration

- Run tests automatically on every commit/PR.
- Publish test and coverage artifacts.
- Fail pipeline on regression.
- Use parallelization for runtime control.

```bash
dotnet test --configuration Release --collect:"XPlat Code Coverage"
```

#### TDD Methodology (Red-Green-Refactor)

1. Red: write failing test.
2. Green: write minimal code to pass.
3. Refactor: improve code while tests stay green.
4. Repeat incrementally.

Benefits:
- Better design and modularity.
- Faster bug discovery.
- Safer refactoring.

Challenges:
- Initial learning curve.
- Test maintenance overhead.
- Harder in highly coupled legacy code.

#### BDD Methodology

BDD emphasizes behavior and stakeholder collaboration using executable scenarios.

Given-When-Then example:

```gherkin
Feature: Withdraw cash
  Scenario: Account has sufficient balance
    Given an account balance of 100
    When the user withdraws 40
    Then the remaining balance should be 60
```

BDD workflow:
1. Identify features and user stories.
2. Write scenarios.
3. Automate scenarios.
4. Implement behavior.
5. Execute and validate.
6. Improve continuously.

Benefits:
- Shared business-technical language.
- Clear executable requirements.
- Better collaboration and acceptance alignment.

Challenges:
- Cultural/process shift.
- Scenario maintenance overhead.
- Tooling/training investment.

## 3. Senior Perspective (The "Why")

- Software quality is two-dimensional: correctness confidence (testing) and runtime performance correctness (data access behavior under load).
- TDD/BDD reduce requirement ambiguity and defect leakage; EF query discipline reduces latency, DB pressure, and scaling risk.
- Over-investment in one side creates blind spots: strong tests with poor queries still fail in production, and fast queries with weak tests still regress behavior.
- The best teams align test pyramid strategy with query-observability strategy (`ToQueryString`, logs, plans, coverage of risky data paths).
- Behavioral tests should protect domain intent; data-access tests should protect performance-sensitive contracts.

## 4. Interview Gotchas & Confusion Points

1. High coverage equals high quality.
Why candidates fail: they optimize metric, not behavior assurance.
Strong answer: pair coverage with meaningful assertions and risk-based scenarios.

2. Unit tests calling real DB/network.
Why candidates fail: slow, flaky, hard-to-diagnose suites.
Strong answer: isolate units and move external interactions to integration tests.

3. Confusing `IQueryable` and `IEnumerable` execution.
Why candidates fail: accidental client-side execution and performance issues.
Strong answer: `IQueryable` stays server-translatable; `IEnumerable` is in-memory.

4. Hidden client evaluation in LINQ.
Why candidates fail: custom C# methods inside query break translation.
Strong answer: split at translation boundary (`AsEnumerable`) intentionally.

5. N+1 not identified early.
Why candidates fail: passes small test data but explodes in prod.
Strong answer: use `Include`, projection, and SQL inspection.

6. Over-using `Include` causing over-fetching/cartesian problems.
Why candidates fail: memory and payload bloat.
Strong answer: choose eager vs explicit loading deliberately.

7. Raw SQL interpolation misuse.
Why candidates fail: SQL injection risk.
Strong answer: parameterize with `FromSqlRaw` placeholders or `FromSqlInterpolated`.

8. Modifying no-tracked entities and expecting persistence.
Why candidates fail: `SaveChanges` does nothing.
Strong answer: track entity or reattach with state setting.

9. Treating `ExecuteUpdate` as equivalent to tracked updates.
Why candidates fail: misunderstand change tracker side effects.
Strong answer: bulk SQL path bypasses entity tracking for performance.

10. BDD scenarios too technical.
Why candidates fail: stakeholders cannot validate behavior.
Strong answer: keep domain language business-readable.

11. Test suite flakiness ignored.
Why candidates fail: team loses trust in tests.
Strong answer: treat flaky tests as defects and fix determinism.

12. Pagination done client-side.
Why candidates fail: huge memory load and slow endpoints.
Strong answer: enforce server-side `Skip/Take` with ordering.

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How it works"

1. What is the core difference between TDD and BDD?
Answer: TDD drives implementation through failing tests; BDD drives behavior through stakeholder-readable scenarios.

2. What is the AAA test pattern?
Answer: Arrange setup, Act execution, Assert expected outcome.

3. Unit vs integration vs E2E in one line?
Answer: Unit tests logic, integration tests boundaries, E2E tests end-user workflows.

4. What is `IQueryable` vs `IEnumerable`?
Answer: `IQueryable` builds server-side query expressions; `IEnumerable` executes in memory.

5. What is the N+1 query problem?
Answer: One parent query plus one child query per row, causing many round trips.

6. When should you use `AsNoTracking()`?
Answer: Read-only query paths (reports, GET APIs, dashboards).

7. Eager loading vs explicit loading?
Answer: Eager preloads known relationships; explicit loads conditionally on demand.

8. Why parameterize raw SQL?
Answer: To prevent SQL injection and ensure safe query execution.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

1. You have 90% coverage but still many production incidents. What next?
Answer: Improve assertion quality, add integration checks for risky boundaries, and map tests to production failure modes.

2. EF endpoint slows down at scale after feature rollout. How do you debug?
Answer: Inspect generated SQL, query plan, indexes, N+1 patterns, payload size, and tracking behavior.

3. Team debates `Include` everywhere vs minimal loading.
Answer: Use access-pattern-driven loading: eager for always-needed data, explicit/projection for conditional or heavy graphs.

4. You need secure complex reporting query not well expressed in LINQ.
Answer: Use parameterized raw SQL/stored procedures with clear ownership and test coverage.

5. Update job touching millions of rows is timing out.
Answer: Use set-based `ExecuteUpdate`/`ExecuteDelete`, proper indexes, and batching strategy.

6. Detached entity from no-tracking must be updated. What do you do?
Answer: Attach and set state to modified or reload tracked entity before updating.

7. BDD adoption stalled after initial excitement.
Answer: Reduce scenario sprawl, keep feature files business-focused, enforce ownership and review cadence.

8. CI runtime doubled after adding tests. How do you recover speed?
Answer: Rebalance test pyramid, parallelize, remove duplication, and isolate slow integration/E2E suites.

## 6. The Revision Bank

1. Define TDD in one sentence.
2. Define BDD in one sentence.
3. Why does AAA improve test readability?
4. Mock vs stub: what is the key difference?
5. Why is branch coverage often more useful than statement coverage?
6. What causes N+1 and how do you prevent it?
12. Why should CI enforce tests as release gates?
