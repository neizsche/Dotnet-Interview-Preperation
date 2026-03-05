# SOLID Principles Interview Playbook

## 1. The Elevator Pitch (Executive Summary)
SOLID is a set of design heuristics that improves maintainability, extensibility, testability, and long-term code health by reducing coupling and increasing cohesion. A senior engineer uses SOLID pragmatically: apply SRP/DIP early for clarity and testability, then evolve OCP/ISP/LSP boundaries based on real change pressure and domain constraints. In interviews, strong answers go beyond definitions and explain trade-offs, failure modes, and how principles influence architecture, refactoring cost, and team velocity.

## 2. Structured Study Material

### 2.1 SOLID at a Glance

| Principle | Core Definition | Why It Matters | Typical Violation Signal | Common Patterns/Mechanisms |
|---|---|---|---|---|
| SRP | A class/module should have one reason to change (one axis of change). | Higher cohesion, easier maintenance and testing. | God classes, mixed concerns (business + IO + reporting). | Extract Class, Service/Repository split, Composition. |
| OCP | Open for extension, closed for modification. | Add behavior with lower regression risk. | Repeated `if/else` or `switch` on type in core logic. | Strategy, Decorator, Template Method, Observer. |
| LSP | Subtypes must be substitutable for base types without breaking correctness. | Safe polymorphism and predictable behavior. | `NotImplementedException`, contract-breaking overrides. | Contract design, composition over inheritance. |
| ISP | Clients should not depend on methods they do not use. | Smaller interfaces, less coupling, easier mocks. | Fat interfaces; classes implementing irrelevant methods. | Role interfaces, interface composition, adapters. |
| DIP | High-level and low-level modules both depend on abstractions. | Flexibility, testability, replaceable implementations. | High-level logic instantiates concrete dependencies directly. | Constructor injection, IoC container, abstraction-first design. |

### 2.2 Core Outcomes of Applying SOLID

| Outcome | How SOLID Enables It | Practical Result |
|---|---|---|
| Code Quality | Better cohesion, clearer module boundaries. | Faster onboarding and fewer accidental side effects. |
| Scalability | Extension points instead of rewrite-heavy changes. | Features evolve without destabilizing stable code. |
| Robustness | Contract-consistent polymorphism + isolated responsibilities. | Fewer regressions during change. |
| Reusability | Abstraction-oriented components. | Components reused across domains/services. |
| Testability | Dependency seams and focused behavior. | Faster unit tests, easier mocking and fault simulation. |

### 2.3 Single Responsibility Principle (SRP)

**Surface Definition:** A class should have only one reason to change.

**Deep View:** SRP is about a single axis of change, not one-method-per-class.

| Aspect | Guidance |
|---|---|
| Core concept | Keep business, persistence, reporting, and notifications in separate units. |
| Violation indicators | God class, mixed responsibilities, high fan-out dependencies. |
| Benefits | Easier maintenance, stronger test isolation, clearer ownership. |
| Misconception | SRP does not mean tiny classes for every line of logic. |

**Beginner Analogy:** A toolbox works because each tool has a focused purpose; classes should behave the same way.

**Violation Example:**
```java
class Employee {
    public void calculateSalary() { /* business logic */ }
    public void saveToDatabase() { /* database logic */ }
    public void generateReport() { /* reporting logic */ }
    public void sendEmail() { /* notification logic */ }
}
```

**SRP-Compliant Split:**
```java
class Employee {
    public void calculateSalary() { /* business logic */ }
}

class EmployeeRepository {
    public void save(Employee employee) { /* database logic */ }
}

class ReportGenerator {
    public void generateReport(Employee employee) { /* reporting logic */ }
}

class EmailService {
    public void sendEmail(Employee employee) { /* notification logic */ }
}
```

**Everyday SRP Examples:**
- `User` entity manages user state/behavior; email sending belongs in `EmailService`.
- `FileParser` parses files; UI formatting belongs in presentation layer.
- `Calculator` performs operations; input/output belongs in UI/controller.

**Refactoring Moves for SRP:**
- Extract Class for grouped behavior that changes for different reasons.
- Extract Method for mixed procedural blocks.
- Replace inheritance with composition when behavior boundaries are unclear.

### 2.4 Open/Closed Principle (OCP)

**Surface Definition:** Software entities should be open for extension but closed for modification.

**Deep View:** Prefer adding new behavior through new implementations, not editing stable, tested flows.

| OCP Strategy | What Differs | Why It Matters | Trade-offs | When to Use |
|---|---|---|---|---|
| Strategy Pattern | Behavior moved to interchangeable classes. | New behavior without changing caller logic. | More types/interfaces. | Variant algorithms (pricing, validation, routing). |
| Template Method | Base class defines algorithm skeleton; subclasses override steps. | Consistent workflow with controlled extension points. | Inheritance coupling. | Stable process with limited variation points. |
| Decorator | Wrap existing behavior to add features. | Runtime composability without core edits. | Debug complexity due to chains. | Layered behaviors (logging, caching, retry). |
| Observer/Event-Driven | Publish events, subscribers extend reactions. | Loose coupling, extensible reactions. | Event ordering/debugging complexity. | Cross-cutting integrations and async workflows. |
| Plugin Architecture | External modules add capabilities. | Independent deployability and team autonomy. | Versioning/compatibility management. | Product platforms and extensible ecosystems. |

**Violation Example:**
```java
class AreaCalculator {
    public double calculateArea(Object shape) {
        if (shape instanceof Circle) {
            Circle circle = (Circle) shape;
            return Math.PI * circle.radius * circle.radius;
        } else if (shape instanceof Rectangle) {
            Rectangle rectangle = (Rectangle) shape;
            return rectangle.width * rectangle.height;
        }
        throw new IllegalArgumentException("Unknown shape");
    }
}
```

**OCP-Compliant Example:**
```java
interface Shape {
    double calculateArea();
}

class Circle implements Shape {
    private double radius;
    public double calculateArea() {
        return Math.PI * radius * radius;
    }
}

class Rectangle implements Shape {
    private double width, height;
    public double calculateArea() {
        return width * height;
    }
}

class AreaCalculator {
    public double calculateArea(Shape shape) {
        return shape.calculateArea();
    }
}
```

**Why OCP Improves Maintainability/Extensibility:**
- Existing behavior stays stable (lower regression risk).
- Teams can add features in parallel with less merge friction.
- New capabilities are localized in extension modules.
- Abstractions plus dependency injection create extension seams without core edits.

### 2.5 Liskov Substitution Principle (LSP)

**Surface Definition:** Subtypes must be substitutable for base types.

**Deep View:** Subclasses must preserve the contract of the base type.

| Contract Rule | Meaning | Violation Example |
|---|---|---|
| Preconditions | Subtype cannot require stricter input conditions. | Base accepts any writable stream; subtype rejects most streams. |
| Postconditions | Subtype cannot promise less than base. | Base promises persisted data; subtype caches only in-memory unexpectedly. |
| Invariants | Subtype must keep base invariants valid. | Base expects independent width/height; subtype forces equality silently. |
| History Constraint | Subtype should not allow forbidden state transitions. | Subtype mutates internal state in ways base contract disallows. |

**Violation Indicators:**
- `instanceof` checks in clients to avoid subtype behavior.
- Overridden methods throwing `UnsupportedOperationException` unexpectedly.
- Behavioral drift from parent expectations.

**Classic Violation (Rectangle/Square):**
```java
class Rectangle {
    protected int width, height;

    public void setWidth(int width) { this.width = width; }
    public void setHeight(int height) { this.height = height; }
    public int getArea() { return width * height; }
}

class Square extends Rectangle {
    @Override
    public void setWidth(int width) {
        super.setWidth(width);
        super.setHeight(width);
    }

    @Override
    public void setHeight(int height) {
        super.setHeight(height);
        super.setWidth(height);
    }
}

void testRectangle(Rectangle rectangle) {
    rectangle.setWidth(5);
    rectangle.setHeight(4);
    assert rectangle.getArea() == 20; // fails for Square
}
```

**LSP-Compliant Direction (Separate Abstraction):**
```java
interface Shape {
    int getArea();
}

class Rectangle implements Shape {
    private int width, height;
    public int getArea() { return width * height; }
}

class Square implements Shape {
    private int side;
    public int getArea() { return side * side; }
}
```

**Less-Obvious LSP Trap:**
```java
class ReadOnlyCollection extends Collection {
    @Override
    public void add(Object element) {
        throw new UnsupportedOperationException("Read-only");
    }
}
```
Client code expecting writable `Collection` now breaks.

**Adherence Scenario:** `TextFile` can extend `File` if all `File` contract guarantees are preserved for reads/writes/error behavior.

**Another Contract-Based LSP Scenario (Logger):**
- If client code expects a logger contract with a specific durability or output guarantee, a subtype that silently changes those guarantees violates LSP.
- Fix: define an explicit `LoggerInterface` contract and ensure each implementation preserves it.

### 2.6 Interface Segregation Principle (ISP)

**Surface Definition:** Clients should not depend on interfaces they do not use.

**Deep View:** Prefer cohesive role interfaces over monolithic contracts.

**Violation Example:**
```java
interface Worker {
    void work();
    void eat();
    void sleep();
    void code();
    void design();
    void test();
}

class Programmer implements Worker {
    public void work() { /* implementation */ }
    public void eat() { /* implementation */ }
    public void sleep() { /* implementation */ }
    public void code() { /* implementation */ }
    public void design() { /* empty - not needed */ }
    public void test() { /* empty - not needed */ }
}
```

**ISP-Compliant Split:**
```java
interface BasicHuman {
    void eat();
    void sleep();
}

interface Workable {
    void work();
}

interface ProgrammerTasks {
    void code();
}

interface DesignerTasks {
    void design();
}

interface TesterTasks {
    void test();
}

class Programmer implements BasicHuman, Workable, ProgrammerTasks {
    public void eat() { /* implementation */ }
    public void sleep() { /* implementation */ }
    public void work() { /* implementation */ }
    public void code() { /* implementation */ }
}
```

| ISP Strategy | Why It Helps | Trade-off | Interview Signal |
|---|---|---|---|
| Interface Segregation | Removes irrelevant dependencies. | More interfaces to manage. | Better mockability and clearer responsibilities. |
| Interface Composition | Recombines small roles as needed. | Requires clear naming discipline. | Flexible contracts per client context. |
| Dependency Injection | Consumers request only the role interface they need. | Requires disciplined composition root. | Cuts coupling between clients and concrete types. |
| Adapter for External APIs | Shields clients from broad vendor APIs. | Adapter maintenance cost. | Better isolation and migration safety. |
| Versioned Interfaces | Evolve contracts without breaking all clients. | Multiple versions to support. | Controlled backward compatibility. |

**Over-Segregation Trap:**
```java
interface NameGetter { String getName(); }
interface AgeGetter { int getAge(); }
interface EmailGetter { String getEmail(); }
```
Better when cohesive usage is shared:
```java
interface UserInfo {
    String getName();
    int getAge();
    String getEmail();
}
```

**When a broader interface can be acceptable:** cohesive operations that change together, e.g.:
```java
interface CRUDOperations {
    void create();
    void read();
    void update();
    void delete();
}
```

**Impact of ISP Violations:**
- Interface pollution from unrelated members.
- Tight coupling across otherwise independent clients.
- Code duplication as clients work around irrelevant contracts.
- Reduced reusability due to bloated dependencies.

### 2.7 Dependency Inversion Principle (DIP)

**Surface Definition:** Depend on abstractions, not concretions.

**Deep View:** High-level policy should not be coupled to low-level details.

**Violation Example:**
```java
class MySQLDatabase {
    public void saveData(String data) {
        // MySQL specific implementation
    }
}

class DataProcessor {
    private MySQLDatabase database;

    public DataProcessor() {
        this.database = new MySQLDatabase();
    }

    public void processData(String data) {
        database.saveData(data);
    }
}
```

**DIP-Compliant Example:**
```java
interface Database {
    void saveData(String data);
}

class MySQLDatabase implements Database {
    public void saveData(String data) {
        // MySQL specific implementation
    }
}

class PostgreSQLDatabase implements Database {
    public void saveData(String data) {
        // PostgreSQL specific implementation
    }
}

class DataProcessor {
    private Database database;

    public DataProcessor(Database database) {
        this.database = database;
    }

    public void processData(String data) {
        database.saveData(data);
    }
}
```

| Injection/IoC Option | What Differs | Pros | Cons | When to Use |
|---|---|---|---|---|
| Constructor Injection | Required deps passed at creation time. | Immutable objects, explicit contract, test-friendly. | Long constructors if overused. | Default choice for required dependencies. |
| Method Injection | Dependency passed per call. | Scope-limited dependency usage. | Call-site repetition. | Occasional/operation-specific collaborators. |
| Property/Setter Injection | Dependency assigned after construction. | Useful for optional deps. | Invalid state risk if unset. | Truly optional or framework-managed deps. |
| Service Locator | Class pulls dependencies from registry. | Quick retrofits. | Hidden dependencies, testing pain. | Prefer only in constrained legacy cases. |
| IoC Container | Framework resolves dependency graph. | Centralized wiring, lifetime management. | Misconfiguration/debug complexity. | Medium/large systems with many services. |

**DIP vs DI (interview framing):**
- DIP is the design principle.
- DI is a mechanism to implement DIP.
- IoC containers automate DI wiring and lifetimes.
- Common container examples seen in .NET ecosystems/interviews: built-in ASP.NET Core DI, Autofac, Ninject, Unity.

### 2.8 SOLID Contribution Matrix: Quality, Scalability, Robustness

| Principle | Code Quality Contribution | Scalability Contribution | Robustness Contribution |
|---|---|---|---|
| SRP | Clearer, cohesive modules. | Feature growth through isolated responsibilities. | Lower side effects from localized changes. |
| OCP | Stable core behavior with extension points. | New features via additions, not risky edits. | Reduced regressions in previously tested code. |
| LSP | Consistent behavior across implementations. | Easy replacement of implementations behind contracts. | Predictable runtime behavior under polymorphism. |
| ISP | Focused contracts and cleaner client code. | Independent evolution of client-specific interfaces. | Fewer accidental breakages from irrelevant method changes. |
| DIP | Decoupled architecture and test seams. | Swappable infrastructure and easier modular growth. | Isolation from low-level implementation churn. |

### 2.9 When to Use Each Principle

| Principle | When to Use | Key Benefit | Typical Caution |
|---|---|---|---|
| SRP | A class has multiple unrelated change triggers. | Isolated change, easier testing. | Too many tiny classes if over-split. |
| OCP | Roadmap expects variant behavior over time. | Extend with lower regression risk. | Over-abstraction in stable/simple domains. |
| LSP | You rely on inheritance/polymorphism contracts. | Safe substitution and predictable behavior. | Forcing inheritance where composition fits better. |
| ISP | Clients use only subsets of a large interface. | Less coupling, clearer contracts. | Interface explosion from premature splitting. |
| DIP | High-level modules depend on concrete infrastructure. | Swap implementations, easier tests. | DI/abstraction overhead in trivial apps. |

### 2.10 Relationship Between Principles

```text
SRP -> focused responsibilities
   -> OCP extension points are easier to design
   -> LSP contracts stay clearer in polymorphic designs
   -> ISP keeps interfaces lean for specific clients
   -> DIP decouples policies from implementation details
```

### 2.11 SOLID and Design Patterns

| Principle | Pattern Alignment | Why It Matters |
|---|---|---|
| SRP | Factory, Command, Observer (focused responsibilities). | Creation, actions, and notifications separated cleanly. |
| OCP | Strategy, Decorator, State, Template Method. | New behavior added without editing stable code. |
| LSP | Strategy, Composite, Factory/Abstract Factory. | Implementations remain substitutable behind contracts. |
| ISP | Adapter, Bridge, Observer role-specific contracts. | Clients depend on focused interfaces only. |
| DIP | Dependency Injection + IoC + Factory abstractions. | High-level logic depends on interfaces, not concrete classes. |

### 2.12 SOLID Refactoring Playbook

| Principle | Refactoring Techniques | Safety Net |
|---|---|---|
| SRP | Extract Class, Extract Method, move cross-cutting concerns to services. | Unit tests on each extracted unit. |
| OCP | Replace conditional branches with polymorphism/strategy. | Characterization tests before replacement. |
| LSP | Remove inheritance misuse, introduce separate abstractions. | Contract tests across implementations. |
| ISP | Split fat interfaces by client usage clusters. | Consumer-focused tests per interface role. |
| DIP | Introduce interfaces at architectural boundaries, inject dependencies. | Mock-based unit tests and integration tests per adapter. |

### 2.13 Applying SOLID in Code Reviews and QA

| Practice | What to Check | Example Review Prompt |
|---|---|---|
| Code Review Checklist | SRP, OCP, LSP, ISP, DIP violations. | "Does this class have more than one reason to change?" |
| Static Analysis | God classes, coupling spikes, unused members. | "Which modules exceed cohesion/coupling thresholds?" |
| Quality Metrics | Cohesion, instability, interface breadth. | "Did this PR increase dependency fan-out?" |
| Peer Reviews/Pairing | Early detection of design drift. | "Can we extend this behavior without touching existing code?" |
| TDD | Design test seams first. | "Can this behavior be tested without real infrastructure?" |
| Documentation/Knowledge Sharing | Shared vocabulary for SOLID decisions. | "Is this pattern choice documented with trade-offs?" |
| Training/Onboarding | Team consistency in applying principles. | "Do juniors know what a contract test is for LSP?" |

### 2.14 Implementation Challenges and How to Overcome Them

| Challenge | Why It Happens | Pragmatic Mitigation |
|---|---|---|
| Knowledge Gaps | SOLID remembered as definitions, not design heuristics. | Run focused design reviews with real examples. |
| Legacy Code | Existing tight coupling and unclear boundaries. | Incremental refactoring + characterization tests. |
| Delivery Pressure | Quick fixes accumulate in central classes. | Reserve refactor budget per sprint; gate high-risk hotspots. |
| Resistance to Change | Familiar patterns feel faster short-term. | Show concrete before/after defect and change-cost data. |
| Over-Engineering | Premature abstractions without change evidence. | Apply YAGNI guardrails and defer speculative layers. |
| Tooling Gaps | Violations not visible early. | Add static analysis and architecture checks into CI. |

## 3. Senior Perspective (The "Why")
- SOLID is primarily a change-management strategy: it reduces blast radius when requirements evolve.
- SRP and DIP usually return value early because they improve testability and deployment confidence quickly.
- OCP and ISP should follow observable volatility; over-applying them early can add indirection cost without payoff.
- LSP is a reliability principle: weak contracts in inheritance hierarchies become production bugs under polymorphic usage.
- In .NET backends, abstractions and DI improve modularity but can add overhead (indirection, more objects, lifetime complexity); senior design balances this with simplicity for stable paths.
- At scale, team throughput depends on modular boundaries as much as on code correctness. SOLID-aligned boundaries reduce merge conflicts and make ownership clearer.
- In modern .NET (Core/.NET 8+), built-in DI and interface-driven architecture make DIP natural, but architecture should still avoid unnecessary interfaces for purely local/stable code.

## 4. Interview Gotchas & Confusion Points

| Gotcha | Why Candidates Fail | What a Strong Senior Answer Clarifies |
|---|---|---|
| "SRP means one method per class" | Over-literal interpretation; ignores axis-of-change concept. | SRP is about one reason to change. A class can have many cohesive methods if they serve one responsibility. |
| "OCP means abstract everything upfront" | Premature abstraction causes unnecessary complexity. | OCP is applied where change is expected. Use concrete code first for stable domains; extract extension points with evidence. |
| "LSP is only the square/rectangle story" | Memorized example without contract reasoning. | LSP is about preserving behavioral contracts (pre/postconditions, invariants, history), not just shape hierarchies. |
| Throwing `UnsupportedOperationException` in subtype is fine | Misses substitutability break in client expectations. | If base contract says operation is supported, subtype cannot silently remove that capability. Split abstraction instead. |
| "ISP requires tiny interfaces always" | Over-segmentation leads to noisy APIs. | Group operations by client usage and change cadence; cohesive sets like CRUD can remain together. |
| Confusing DIP with DI container usage | Tool-first answer misses principle. | DIP is architectural direction of dependencies; DI container is only one implementation mechanism. |
| Service Locator treated as equivalent to DI | Hidden dependencies reduce testability and transparency. | Prefer explicit constructor dependencies; use service locator only as controlled legacy bridge. |
| "SOLID always improves performance" | Ignores runtime cost of indirection/object graph complexity. | SOLID optimizes maintainability first; performance impacts must be measured and tuned based on hotspots. |
| Copying design patterns without design intent | Pattern cargo-culting creates accidental complexity. | Start with responsibility and contracts; choose patterns only when they solve a concrete pressure point. |
| Treating SOLID as strict rules instead of heuristics | Leads to brittle, over-engineered systems. | SOLID is contextual guidance; senior engineers balance it with YAGNI, deadlines, and domain stability. |
| Refactoring legacy code in one big rewrite | High delivery risk and regression exposure. | Use incremental refactoring with tests, feature toggles, and staged rollout. |
| Ignoring QA and review enforcement | Principles remain aspirational, not operational. | Integrate SOLID checks into PR templates, CI analysis, and team standards. |

## 5. Tiered Interview Q&A

### Mid-Level: Foundational "How It Works"

**Q1. What does SOLID stand for?**
A: SRP, OCP, LSP, ISP, DIP.

**Q2. Why are SOLID principles important?**
A: They improve maintainability, extensibility, testability, reusability, and robustness by reducing coupling and clarifying responsibilities.

**Q3. Explain SRP to someone new to software.**
A: A class should have one job (one reason to change). Like tools in a toolbox, each class should be specialized, not all-in-one.

**Q4. How does OCP improve maintainability/extensibility?**
A: You add new behavior via extensions (new classes/strategies/plugins) instead of editing stable code, lowering regression risk.

**Q5. How do you ensure LSP in class hierarchies?**
A: Define clear contracts, keep pre/postconditions compatible, preserve invariants, and run contract tests across implementations.

**Q6. How can ISP violations create code smells?**
A: Fat interfaces force irrelevant implementations, leading to empty methods, tight coupling, noisy tests, and difficult evolution.

**Q7. How do SOLID principles complement design patterns?**
A: Patterns operationalize SOLID; for example Strategy/Decorator support OCP, and DI/Factory techniques support DIP.

**Q8. Can you violate one SOLID principle while following others?**
A: Yes. Example: SRP-compliant classes can still violate DIP if they depend directly on concrete infrastructure.

### Senior/Lead: Scenario-Based "Design & Troubleshooting"

**Q9. The square-rectangle issue is obvious. Give a less obvious LSP violation.**
A: A `ReadOnlyCollection` inheriting from `Collection` but throwing on `add()` breaks client expectations for writable collection behavior.

**Q10. Can OCP be overused?**
A: Yes. Creating abstraction layers for stable/simple behavior increases maintenance cost without real extensibility benefit.

**Q11. How does DIP relate to Dependency Injection?**
A: DIP is the principle (dependency direction), DI is the mechanism (inject dependencies), and IoC containers automate DI.

**Q12. Is it possible to have too many interfaces with ISP?**
A: Yes. Over-segmentation creates cognitive overhead. Interfaces should align with usage boundaries and change patterns.

**Q13. You are designing a payment system. Apply SOLID quickly.**
A:
- SRP: Separate validation, processing, persistence, notifications.
- OCP: Add payment methods via new implementations.
- LSP: Ensure each payment provider honors the same payment contract.
- ISP: Split processing, refund, status interfaces.
- DIP: Payment orchestrator depends on abstractions.

**Q14. Refactor this SRP/OCP violation:**
```java
class ReportGenerator {
    public void generateReport(String type) {
        if (type.equals("PDF")) {
            // Generate PDF
        } else if (type.equals("HTML")) {
            // Generate HTML
        }
        // Save to database
        // Send email
    }
}
```
A:
```java
interface Report {
    void generate();
}

class PDFReport implements Report { /* ... */ }
class HTMLReport implements Report { /* ... */ }

class ReportService {
    private Report report;
    private Repository repository;
    private NotificationService notification;

    public ReportService(Report report, Repository repo, NotificationService notif) {
        this.report = report;
        this.repository = repo;
        this.notification = notif;
    }

    public void generateAndSend() {
        report.generate();
        repository.save(report);
        notification.send(report);
    }
}
```

**Q15. What principle is most commonly violated in real teams and why?**
A: Usually SRP, because teams keep appending behavior to existing classes under delivery pressure.

**Q16. How do you balance SOLID with YAGNI?**
A: Apply SRP/DIP early, defer heavier abstractions (OCP/ISP variants) until volatility is real, then refactor with tests.

**Q17. LSP seems impossible due to business rules (e.g., penguin cannot fly). What do you do?**
A: Replace forced inheritance with composition/strategy so behavior is configured, not hardcoded in an invalid subtype.

```java
class Bird {
    private FlyingAbility flyingAbility;
    public void fly() { flyingAbility.fly(); }
}

class Penguin extends Bird {
    public Penguin() { this.flyingAbility = new NoFlying(); }
}
```

**Q18. When can a broader interface be acceptable despite ISP?**
A: When methods are highly cohesive and usually change together (for example, canonical CRUD contract).

## 6. The Revision Bank
1. What is the difference between "single method" and "single reason to change" in SRP?
2. Which OCP extension mechanism would you choose for runtime feature toggling and why?
3. Name one LSP violation that does not involve geometry classes.
4. Why is `UnsupportedOperationException` often an LSP smell?
5. How do you detect ISP violations from a pull request quickly?
6. DIP is a principle; DI is a mechanism. Explain with one concrete example.
7. When is service locator acceptable, and what is the primary risk?
8. How do SOLID and YAGNI coexist in a fast-moving product team?
9. Which SOLID principle gives the fastest payoff in legacy refactoring, and why?
10. How does SOLID influence test pyramid design in backend services?
11. Give one case where over-applying OCP hurts more than helps.
12. How would you enforce SOLID continuously in code review + CI?

## 7. Clarification / Suggested Additions Before Finalizing
- Clarification: Do you want all Java examples converted to C#/.NET equivalents while preserving the same design intent?
- Clarification: Should this playbook include a dedicated "SOLID in ASP.NET Core" subsection (middleware, hosted services, EF Core repositories)?
- Suggested addition: Add a short "Contract Testing for LSP" checklist with xUnit examples.
- Suggested addition: Add a "SOLID anti-pattern catalog" (God Service, Anemic interfaces, Leaky abstractions, Service Locator misuse) with remediation steps.
- Suggested addition: Add a small legacy-refactor case study showing incremental migration from tightly coupled service code to DIP + SRP.
