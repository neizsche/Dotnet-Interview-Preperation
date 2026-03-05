# .NET Interview Playbook (5 Years Experience)

## The Elevator Pitch (Executive Summary)
Modern .NET is a unified, cross-platform ecosystem for building web, cloud, desktop, worker, and mobile-connected applications with a consistent runtime (CLR), shared libraries (BCL/FCL), and strong tooling. Senior-level understanding is less about memorizing components and more about choosing trade-offs: startup vs throughput, managed safety vs low-level control, abstraction speed vs data-access predictability, and portability vs platform-specific optimization. In interviews, strong candidates explain not just what CLR/IL/JIT/GC do, but why those design choices exist and how they influence architecture under production load.

## Structured Study Material

### 1) Platform Fundamentals

| Building Block | What It Is | Why It Matters Architecturally |
|---|---|---|
| .NET (definition) | Microsoft development platform and runtime ecosystem | Standardizes app model, runtime behavior, and libraries across teams |
| Purpose | CLR runtime + class libraries for app development | Speeds delivery with reusable primitives and managed execution |
| Languages | C#, VB.NET, F#, others | Enables polyglot development with shared runtime contracts |
| Runtime | Common Language Runtime (CLR) | Central control point for execution, memory, exceptions, security, threading |
| Libraries | FCL/BCL APIs for I/O, networking, DB, UI, etc. | Reduces boilerplate and implementation risk |
| Managed code model | Source code compiles to IL and runs under CLR | Gives portability, safety checks, and runtime services |
| Language interoperability | Cross-language component interaction | Supports mixed-language systems with common type/runtime contracts |
| Cross-platform | .NET Core/.NET 5+ support Windows, Linux, macOS | Enables consistent backend deployments and container portability |
| Evolution | .NET Framework (Windows) -> .NET Core -> unified modern .NET | Impacts migration strategy, hosting, APIs, and long-term support decisions |
| Tooling | Visual Studio + .NET SDK tooling | Improves build/debug/profile productivity |
| Web stack | ASP.NET/ASP.NET Core for APIs and web apps | First-class hosting, middleware pipeline, DI, config, logging |
| Desktop stack | WinForms, WPF | Relevant for existing enterprise and Windows-heavy ecosystems |
| Mobile integration | Xamarin (historical path for cross-platform mobile) | Important for legacy mobile codebases and migration context |
| Cloud integration | Azure-hosted scaling, management, observability | Aligns runtime model with cloud-native operations |
| Ecosystem | Ongoing runtime/library updates + strong community | Lowers adoption friction and improves maintainability |

### 2) CLR Runtime Services

| CLR Capability | Core Role | Senior Notes |
|---|---|---|
| Execution engine | Executes managed code | Central runtime contract for all .NET languages |
| Memory management | Automatic allocation + GC cleanup | Fewer leaks than manual memory; still requires allocation discipline |
| JIT compilation | IL -> native code at runtime | Enables platform-specific optimization with startup overhead trade-off |
| Exception handling | Unified runtime error model | Standardized propagation/catching across languages |
| Security | Runtime checks (historically CAS, security transparency) | Know modern relevance vs legacy .NET Framework behavior |
| Interoperability | Cross-language execution in same runtime | Useful for shared libraries across teams/languages |
| Language independence | Multiple compilers target same runtime | Preserves architecture while allowing language choice |
| Versioning/deployment | Multiple assembly versions can coexist | Reduces dependency collisions in complex enterprise estates |
| BCL integration | Runtime works with core libraries | Consistent baseline APIs across app types |
| Debugging/profiling hooks | Runtime diagnostics support | Essential for production troubleshooting and performance tuning |
| Thread management | Scheduling/synchronization primitives | Critical for scalability and deadlock/throughput analysis |
| Hosting support | Runs in desktop/server/service contexts | Same runtime model, different hosting constraints |
| Performance optimizations | Runtime/JIT optimization passes | Affects hot-path performance and latency patterns |
| Resource management | Coordinates cleanup with `IDisposable`/finalization model | Deterministic disposal still required for non-memory resources |
| Cross-language exceptions | Unified exception semantics | Prevents language-boundary reliability gaps |
| DLR integration | Supports dynamic language scenarios | Useful for scripting/extensibility patterns |
| Unified type system | Shared runtime type behavior | Foundation for language interoperability |
| Cross-platform runtime | Modern runtime on Windows/Linux/macOS | Enables homogeneous operational model across environments |
| Open source runtime components | Runtime/libraries developed openly | Improves transparency and ecosystem contribution path |

### 3) CTS, CLS, and IL Pipeline

| Concept | What It Defines | Interview-Grade Significance |
|---|---|---|
| CTS (Common Type System) | Common type rules for all .NET languages | Ensures type safety, interoperability, cross-language inheritance/polymorphism, and consistent value/reference semantics |
| CTS + metadata/reflection | Type/member metadata discoverable at runtime | Enables dynamic loading, code generation, debugging, tooling |
| CTS arrays/exceptions/runtime support | Shared behavior for arrays and exceptions | Cross-language consistency in data structures and error handling |
| CLS (Common Language Specification) | Interoperability subset/rules of CTS | Governs naming, visibility, exceptions, and minimum type support for language-neutral libraries |
| CLS compliance | Compiler/library adherence to CLS rules | Improves cross-language assembly consumption and debugging |
| IL (Intermediate Language) | Architecture-neutral compiled output | Universal representation for all .NET languages |
| IL platform independence | IL is not machine-specific | Same binaries can execute across targets via runtime/JIT |
| IL verification/security | Verifiable, type-safe model with runtime checks | Strengthens execution safety vs raw native binaries |
| IL + JIT execution | Native code generated on demand | Late binding and runtime adaptation to host machine |
| IL performance model | Runtime specialization and optimization opportunities | Trade-off: first-hit JIT cost vs tuned steady-state execution |
| IL for debugging/reflection | Inspectable by tools (for example, IL disassembly) | Helps deep diagnostics and understanding generated behavior |
| IL and evolution | Runtime/library improvements can benefit existing IL | Helps long-term maintainability and platform evolution |
| IL interop | Supports P/Invoke and COM interop paths | Enables reuse of native/legacy components |
| IL and dynamic languages | DLR-targeted scenarios compile/execute through runtime | Supports dynamic extensibility in managed ecosystems |
| IL deployment/versioning | Portable assemblies simplify deployment updates | Supports componentized release and compatibility management |
| IL precompilation/obfuscation | Optional ahead-of-time optimizations/protection flows | Balances startup goals and IP/security posture |
| Language-agnostic libraries | Shared IL contracts across languages | Maximizes reuse across teams and codebases |

Key CLS rule categories to retain for interviews: naming conventions, accessibility/visibility rules, common data type support, exception-handling consistency, cross-language inheritance compatibility, assembly interoperability, and cross-language debugging expectations.

### 4) Assembly Anatomy and Deployment

| Area | Key Facts |
|---|---|
| Definition | Assembly is the smallest deployable unit: executable or library |
| Core contents | IL code, metadata, manifest, type info, resources, security/permission-related metadata, references, compilation metadata |
| Manifest role | Holds identity/version/culture/strong-name/dependency information |
| References | Tracks dependent assemblies (strong/weak naming contexts) |
| Types of assemblies | EXE, DLL, private assembly, satellite assembly, GAC-shared assembly |
| Localization tie-in | Satellite assemblies package culture-specific resources |
| Deployment models | Private deployment (app-local) or shared deployment (historically GAC-centric scenarios) |

### 5) Managed vs Unmanaged Code

| Factor | Managed Code | Unmanaged Code |
|---|---|---|
| Execution | Runs under CLR | Runs directly as native code |
| Memory | GC-managed | Manual allocation/deallocation |
| Performance profile | Runtime overhead + safety services | Potentially faster low-level paths with higher error risk |
| Portability | IL-based, runtime-portable | Platform/architecture specific |
| Interoperability | Strong cross-.NET-language support | Typically language/platform constrained |
| Security model | Runtime-enforced safety mechanisms | Security must be engineered manually |
| Exception model | Unified runtime handling | Manual/native patterns |
| Debug/profiling | Rich managed diagnostics tooling | Lower-level diagnostics complexity |
| Versioning | Assembly/version-friendly model | Rebuild/relink often required |
| Resource/system access | Governed by runtime patterns | Direct system access with fewer guardrails |
| Typical examples | C#, VB.NET, F# apps | C/C++/assembly native binaries |

Sample syntax (managed resource cleanup and native interop):

```csharp
await using var stream = File.OpenRead(path);
// process stream safely; resource is disposed deterministically
```

```csharp
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern uint GetTickCount();
}
```

### 6) JIT Compiler (Focused View)

| JIT Aspect | Condensed Notes |
|---|---|
| Dynamic compilation | Compiles IL to native code at runtime on demand |
| Platform adaptation | Produces machine-specific code for current OS/CPU |
| Optimization | Applies runtime-aware optimizations; improves hot-path throughput |
| Caching/reuse | Reuses compiled code to avoid repeat translation cost |
| Late binding | Supports flexible runtime behavior and dynamic execution context |
| Security/type checks | Enforces valid and type-safe execution during compilation path |
| Memory/runtime interaction | Works with managed runtime lifecycle and GC-driven memory model |
| Trade-off | Higher startup/JIT latency vs better machine-tuned steady-state performance |

### 7) Garbage Collector (GC) Benefits

| GC Benefit Area | What to Remember |
|---|---|
| Automatic memory management | Runtime handles reclaiming unreachable objects |
| Leak prevention | Reduces retained garbage vs manual memory patterns |
| Dangling reference reduction | Avoids many classic pointer-lifetime failures |
| Stability/reliability | Fewer memory-corruption classes of bugs |
| Developer velocity | Less manual cleanup code, more focus on domain logic |
| Performance features | Generational GC, background collection, workload adaptation |
| Short-lived object handling | Young-generation focus improves common allocation patterns |
| Fragmentation management | Compaction reduces heap fragmentation risk |
| LOH handling | Dedicated path for large objects with distinct behavior |
| Resource management integration | Works with `IDisposable` and finalization semantics |
| Multithreaded operation | Thread-safe collection tuned for concurrent apps |
| Security posture | Reduced memory misuse vulnerabilities vs manual models |
| Ecosystem consistency | Common memory semantics across .NET languages/frameworks |

### 8) Globalization and Localization

| Domain | Key Notes |
|---|---|
| Globalization | Culture-aware formatting for dates, numbers, currency, strings |
| `CultureInfo` usage | Represents culture/locale behavior and formatting rules |
| Localization assets | Resource files + satellite assemblies for language/culture content |
| UI localization | Localized labels/messages/control text per user culture |
| Thread/UI culture | Per-thread and UI culture settings supported |
| Invariant culture | Culture-neutral operations for deterministic behavior |
| Formatting APIs | `String.Format` and related APIs respect culture context |
| Framework support | ASP.NET, WinForms, WPF include globalization/localization capabilities |
| Tooling support | Resource manager + IDE tooling for localized content workflows |
| Testing | Culture simulation and localization validation are required |
| Unicode/multilingual data | Full character set support; DB strategy must match multilingual requirements |

Sample syntax (culture-aware formatting):

```csharp
var culture = new CultureInfo("fr-FR");
var amount = 12345.67m;
string display = string.Format(culture, "{0:C}", amount); // 12 345,67 €
```

### 9) Data Access and Enterprise Frameworks

#### ADO.NET vs Classic ADO

| Area | ADO.NET | Classic ADO |
|---|---|---|
| Core model | Disconnected-first architecture | Mostly connected model |
| In-memory structure | `DataSet` (tables/relations/constraints) | Recordset-centric |
| Transfer component | `DataAdapter` fill/update workflow | Different connected data flow |
| Read efficiency | `DataReader` forward-only lightweight access | Heavier patterns in many cases |
| XML support | Native XML integration and schema handling | Less native, less integrated |
| Disconnected manipulation | Supports offline updates and in-memory transformations before sync | More connection-bound workflows |
| Async operations | Supported | Limited/older model |
| Strong typing | Strongly typed `DataSet` support | Less compile-time guidance |
| Disconnected events | Row-level change events (`RowChanged`, `RowDeleted`, etc.) | Different event model |
| Update automation | `CommandBuilder` can auto-generate update commands | More manual SQL wiring |
| Transactions | Improved/distributed transaction support | Older transaction capabilities |
| Provider model | Consistent programming model across DB providers | Provider story less modernized |
| .NET feature integration | Tight integration with ASP.NET, WinForms, and web service ecosystems | Less unified with modern managed app stack |
| Security/integration | Managed-code and .NET-integrated security model | Less aligned with modern managed stack |

Sample syntax (ADO.NET connected read and disconnected model):

```csharp
await using var conn = new SqlConnection(connectionString);
await conn.OpenAsync();

await using var cmd = new SqlCommand(
    "SELECT Id, Name FROM Customers WHERE IsActive = 1", conn);
await using var reader = await cmd.ExecuteReaderAsync();

while (await reader.ReadAsync())
{
    var id = reader.GetInt32(0);
    var name = reader.GetString(1);
}
```

```csharp
using var conn = new SqlConnection(connectionString);
using var adapter = new SqlDataAdapter("SELECT * FROM Customers", conn);
var ds = new DataSet();
adapter.Fill(ds, "Customers");

DataTable table = ds.Tables["Customers"]!;
```

#### Entity Framework (EF) Significance

| EF Capability | Why It Matters |
|---|---|
| ORM abstraction | Maps relational data to domain objects and reduces boilerplate SQL |
| Code-First/Database-First | Supports greenfield and brownfield database strategies |
| LINQ integration | Type-safe, expressive query composition |
| Change tracking | Automates update detection and persistence workflows |
| Multi-provider support | SQL Server, MySQL, PostgreSQL, SQLite, etc. |
| Migrations | Schema evolution/versioning as application evolves |
| Transactions | Atomic commit/rollback boundaries |
| Concurrency controls | Detects/resolves conflicting updates |
| Validation | Pre-persistence integrity checks |
| ASP.NET Core integration | Standard data layer choice in modern .NET web stacks |
| Async queries/saves | Improves responsiveness under I/O latency/high concurrency |
| Open source + tooling | Active community + strong IDE support improves productivity |
| Cross-platform | Aligns with modern .NET runtime portability |

Sample syntax (EF Core async query + tracked update):

```csharp
var activeUsers = await dbContext.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.LastName)
    .ToListAsync();

var user = await dbContext.Users.FindAsync(userId);
if (user is not null)
{
    user.LastLoginUtc = DateTime.UtcNow;
    await dbContext.SaveChangesAsync();
}
```

### 10) Communication and UI Frameworks

| Technology | Interview Notes |
|---|---|
| WCF | .NET framework for distributed/interoperable services with protocol flexibility, security, transactions, and messaging support |
| WPF | Windows desktop UI framework using XAML with declarative UI, MVVM fit, data binding, styling/templates, layout engine, custom controls, animations/effects, media + 3D support, dependency properties, commanding model, vector graphics/resolution independence, rich text/typography, accessibility, localization/globalization, touch/gesture + Windows shell integration, optional browser-hosted XBAP model, and integration patterns with WCF/WF in enterprise apps |

### 11) .NET Framework vs .NET Core vs Modern .NET

| Aspect | .NET Framework | .NET Core | Modern .NET (5+) |
|---|---|---|---|
| Historical role | Original .NET line (2002) | Cross-platform rewrite (2016) | Unified platform line (2020 onward) |
| Platform support | Windows only | Windows/Linux/macOS | Windows/Linux/macOS |
| Open source posture | Mostly proprietary-era model | Fully open source | Fully open source |
| Deployment model | Machine/system-wide runtime assumption | Framework-dependent or self-contained | Framework-dependent or self-contained |
| Side-by-side execution | Limited; machine-level friction possible | Strong app-level isolation | Strong app-level isolation |
| Performance trend | Solid baseline | Major runtime gains | Best overall with newer runtime features |
| Microservices and containers | Limited fit | Strong fit | Strong fit |
| Docker posture | Historically limited (especially Windows-centric) | Excellent | Excellent |
| Typical TFMs | `net45/net46/net48` | `netcoreapp2.1/netcoreapp3.1` | `net5.0+` (for example `net8.0`) |
| Lifecycle posture | Final major line at 4.8.x; legacy-focused maintenance | Historical line mainly encountered in legacy estates | Modern LTS/STS cadence for active development |
| Strategic recommendation | Legacy maintenance and Windows-only dependencies | Legacy maintenance for existing Core-era apps | Default target for new development |

### 12) Side-by-Side, Deployment Models, and Runtime Selection

| Topic | Key Notes | Architectural Trade-off |
|---|---|---|
| Framework-dependent deployment | App uses runtime installed on host | Smaller app package, tighter ops/runtime dependency |
| Self-contained deployment | App ships with its own runtime | Larger artifact size, stronger deployment isolation/reproducibility |
| Side-by-side runtime behavior | Modern .NET apps can run with app-specific runtime requirements | Great for multi-app hosts; reduces cross-app version conflicts |
| `.runtimeconfig.json` purpose | Declares runtime options (`tfm`, framework name/version, config properties, roll-forward behavior) | Central runtime-governance file for production behavior |
| Roll-forward policies | `Disable`, `LatestPatch`, `Minor`, `Major`/latest-major style policies | Flexibility vs risk of unintended runtime behavior changes |
| Legacy roll-forward switch | `rollForwardOnNoCandidateFx` appears in older config patterns | Important when reading inherited runtime configs during migration |
| Runtime knobs: GC | `System.GC.Server`, `System.GC.Concurrent`, `System.GC.RetainVM`, `System.GC.HeapHardLimit` | Throughput/latency/memory-footprint tuning trade-offs |
| Runtime knobs: Threading | `System.Threading.ThreadPool.MinThreads/MaxThreads` | Under/over-provisioning affects tail latency and resource usage |
| Runtime knobs: Compilation | Tiered compilation settings and startup/perf tuning | Startup speed vs steady-state throughput balance |
| Runtime knobs: Trimming safety | DI trimmability verification switches (for example, open generic service checks) | Early detection of trim/AOT unsafe registrations |
| Runtime knobs: serialization safety | `System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization` hardening toggle | Security compatibility vs legacy serializer dependencies |
| Included frameworks | `includedFrameworks` and framework resolution metadata | Stronger predictability for runtime binding in packaged apps |

Sample syntax (`.runtimeconfig.json`):

```json
{
  "runtimeOptions": {
    "tfm": "net8.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "8.0.0"
    },
    "rollForward": "Minor",
    "configProperties": {
      "System.GC.Server": true,
      "System.Threading.ThreadPool.MinThreads": 10
    }
  }
}
```

```json
{
  "runtimeOptions": {
    "tfm": "net8.0",
    "includedFrameworks": [
      {
        "name": "Microsoft.NETCore.App",
        "version": "8.0.0"
      }
    ],
    "configProperties": {
      "System.GC.HeapHardLimit": 1073741824,
      "System.Threading.ThreadPool.MinThreads": 50,
      "System.Runtime.TieredCompilation": true,
      "System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization": false
    },
    "rollForwardOnNoCandidateFx": 2,
    "rollForward": "Minor"
  }
}
```

### 13) Target Framework Monikers (TFMs), Compatibility, and Multi-targeting

| Area | Interview Notes |
|---|---|
| TFM purpose | Identifies API surface and runtime line your project targets |
| Canonical examples | `net48`, `netcoreapp3.1`, `net8.0` |
| Cross-target portability | `netstandard2.0` remains an important compatibility bridge in mixed ecosystems |
| Multi-targeting | `<TargetFrameworks>net48;netcoreapp3.1;net8.0</TargetFrameworks>` builds per-target outputs |
| Compatibility direction | `net8.0` can consume many modern libraries; direct `net48` reuse may require bridge/rewrite |
| .NET Framework library reuse | Direct `net48` references from modern runtimes are typically not possible; prefer `netstandard2.0` bridge or migration |
| Decision pattern | Multi-target only when required by consumers; otherwise reduce target count to lower maintenance cost |

Sample syntax (`.csproj` targeting):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
  </PropertyGroup>
</Project>
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
</Project>
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net48;net8.0</TargetFrameworks>
  </PropertyGroup>
</Project>
```

### 14) Migration and Legacy Constraints

| Constraint / Question | Senior-Level Interpretation |
|---|---|
| Web Forms availability | Web Forms is .NET Framework-only; modern migration paths are ASP.NET Core MVC, Razor Pages, or Blazor |
| WCF in modern .NET | WCF client support exists; WCF server is not native in modern .NET and usually requires migration (gRPC/REST/CoreWCF) |
| Windows Forms/WPF on Linux/macOS | These UI frameworks remain Windows-oriented despite modern runtime portability |
| AppDomain model changes | AppDomains are no longer a primary isolation model; use `AssemblyLoadContext` and process/container isolation patterns |
| Config system shift | Framework-era `web.config/app.config` vs modern `appsettings.json` + provider-based configuration |
| Environment-specific runtime behavior | Commonly modeled using `appsettings.Development.json` and `appsettings.Production.json` plus host/runtime overrides |
| Migration approach | Use upgrade tooling, audit dependencies first, and sequence migration by risk (hosting/API/data/interop/UI) |
| Intermediate hops | Some teams used .NET Core 3.1 as an intermediate step; for current migrations, target a supported modern LTS directly unless blocked |

Sample syntax (legacy binding, environment config, and modern isolation):

```xml
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
  </startup>
</configuration>
```

```csharp
var alc = new AssemblyLoadContext("PluginContext", isCollectible: true);
var asm = alc.LoadFromAssemblyPath(pluginPath);
// use types via reflection/contracts
alc.Unload();
```

```json
// appsettings.Development.json
{
  "Runtime": {
    "GCServer": false,
    "TieredCompilation": true
  }
}
```

```json
// appsettings.Production.json
{
  "Runtime": {
    "GCServer": true,
    "TieredCompilation": false
  }
}
```

## Senior Perspective (The "Why")

- CLR, IL, and JIT exist to separate developer productivity from hardware specificity: you write language-level code once, runtime specializes execution per environment. The trade-off is startup/JIT overhead versus optimized steady-state throughput.
- Managed memory (GC) shifts failure modes from manual deallocation bugs to allocation/retention discipline problems. Senior engineers optimize allocation rate, object lifetime, LOH churn, and disposal patterns (`IDisposable`) rather than trying to outsmart the GC.
- CTS/CLS are architectural enablers for multi-team, multi-language ecosystems: they reduce integration friction and allow reusable shared libraries with predictable contracts.
- Assembly metadata/manifest design underpins reliable deployment and versioning. In enterprise systems, dependency hygiene and version boundaries are often more critical than raw coding speed.
- ADO.NET gives low-level control (especially with `DataReader` and explicit SQL patterns), while EF maximizes productivity and consistency. Senior choice is contextual: high-throughput hot paths may favor lower abstraction; complex domain workflows often benefit from EF tracking/migrations.
- Globalization/localization is not cosmetic; it affects correctness (currency/date parsing, sorting, Unicode behavior), compliance, and user trust in multi-region systems.
- WCF/WPF knowledge remains relevant for legacy modernization, not just greenfield development. Senior candidates should explain migration and coexistence strategies, not only framework features.
- Deployment mode is an architecture decision: framework-dependent reduces image size and patch centralization cost, while self-contained improves runtime determinism and reduces host-drift failures.
- Runtime policy (`rollForward`, GC mode, thread pool limits, tiered compilation) is a production control plane, not just configuration trivia; wrong defaults can materially change latency and memory behavior.
- Modern .NET performance gains are tied to runtime and BCL evolution (`Span<T>`, SIMD/vectorization improvements, JIT upgrades, GC tuning, and AOT options). Senior trade-off is startup and footprint vs compatibility, reflection flexibility, and build complexity.
- Evolution perspective: .NET Framework was Windows-centric; modern .NET (.NET Core -> .NET 5+ -> current .NET 8 generation) is unified and cross-platform. This shifts architecture toward cloud-native hosting, containerization, and performance-first runtime improvements.

## Interview Gotchas & Confusion Points

- Framework naming trap: many candidates answer "I use .NET Framework 8" or mix the terms. Interviewers expect you to separate legacy Windows-only `.NET Framework` from modern cross-platform `.NET` (5+), and to explain the migration/hosting implications of that difference.
- CTS vs CLS confusion: candidates often treat them as interchangeable. Strong answers state that CTS is the full runtime type system, while CLS is the interoperability subset for public APIs that must be consumable across .NET languages.
- IL execution misconception: candidates sometimes claim IL is interpreted end-to-end. In practice, production execution relies on JIT-generated native code for hot paths, and interviewers want you to explain startup vs steady-state behavior.
- GC misconception: candidates say "GC cleans everything." GC only manages managed memory; unmanaged handles (files, sockets, DB connections) still require deterministic cleanup via `IDisposable`/`await using`.
- Managed vs native performance myth: blanket claims like "native is always faster" are weak. Senior framing is workload-driven: managed code can be highly optimized, while native paths trade safety and maintainability for low-level control.
- EF abstraction trap: saying "EF removes SQL knowledge needs" is a red flag. You still need query-shape awareness, indexing strategy, generated SQL inspection, and transaction/concurrency control.
- ADO.NET disconnected model trap: candidates praise scalability but ignore consistency costs. Disconnected updates can cause stale-write conflicts unless optimistic concurrency and transaction boundaries are designed carefully.
- WCF migration trap: "WCF works the same in .NET 8" is incorrect for server hosting. Mature answers distinguish WCF client support from server migration paths (CoreWCF, gRPC, REST) and discuss contract/operational trade-offs.
- Localization simplification trap: reducing localization to translated strings misses critical failures. Date/number parsing, collation, Unicode normalization, and invariant vs user culture rules can break business logic and reporting.
- Security history trap: CAS/security transparency is often asked in interviews, but mostly as legacy context. Good answers acknowledge historical relevance while focusing on modern security posture and runtime hardening practices.
- GC mode migration trap: candidates assume identical defaults between legacy and modern deployments. In real systems, workstation/server GC choices and tuning strategy materially affect latency, throughput, and memory footprint.
- Runtime roll-forward trap: broad `rollForward` policies can silently change runtime behavior after host updates. Interviewers expect you to balance patch agility with deterministic production behavior and validation strategy.
- Deployment-model trap: self-contained is not automatically "best practice." It improves isolation but increases artifact size and per-app patch governance; framework-dependent can simplify fleet-wide runtime servicing.
- TFM compatibility trap: many candidates assume `net8.0` can directly consume all `net48` libraries. In practice, compatibility often requires `netstandard2.0` bridging, retargeting, or partial rewrite.
- Isolation model trap: AppDomain-centric answers signal outdated design assumptions. Modern .NET discussions should reference `AssemblyLoadContext`, process boundaries, and container-based isolation where appropriate.
- Legacy-target trap: `.NET Core 3.1` is still common in interview questions, but senior candidates should treat it as maintenance context and steer greenfield design toward supported modern LTS versions.

## Tiered Interview Q&A

### Mid-Level: Foundational "How it works" questions

1. What is .NET, and how do CLR and BCL/FCL differ in responsibility?
2. Why do .NET languages compile to IL instead of directly to native code?
3. How does JIT compilation work from assembly load to method execution?
4. What are assemblies, and what information does the manifest contain?
5. Explain managed vs unmanaged code with one practical interoperability example.
6. What does the GC collect, and when would you still implement `IDisposable`?
7. What is CTS, and how is it different from CLS?
8. How does ADO.NET disconnected architecture improve scalability?
9. What is the difference between `DataReader` and `DataSet` usage?
10. What problem does Entity Framework solve, and what are its core capabilities?
11. How do globalization and localization differ in .NET applications?
12. What is WCF, and in what kind of systems is it commonly found?
13. What is a Target Framework Moniker (TFM), and how does it affect API compatibility?
14. What is the difference between framework-dependent and self-contained deployment?
15. What does `.runtimeconfig.json` control in modern .NET apps?

### Senior/Lead: Scenario-based "Design & Troubleshooting" questions

1. Your API shows high P99 latency after deployment. How would you separate JIT/startup effects from sustained throughput bottlenecks?
2. Memory usage keeps climbing in a service without OOM crashes. How would you distinguish true leaks from high object retention and GC pressure?
3. A multilingual e-commerce app calculates totals incorrectly in some regions. How would you audit culture-sensitive parsing/formatting paths?
4. A team wants to replace EF with raw SQL for performance. What evidence and profiling strategy would you require before deciding?
5. Two services share libraries written in different .NET languages. How do CTS/CLS constraints influence your public API design?
6. A legacy WCF system must integrate with modern services. What coexistence or migration strategy would you propose?
7. Startup time is critical in autoscaling environments. How would you tune runtime/app behavior while preserving maintainability?
8. ADO.NET disconnected workflows produce conflicting updates. How would you enforce transaction and concurrency strategy?
9. Large object allocations are causing intermittent latency spikes. What GC/heap behaviors would you investigate first?
10. Multiple versions of shared components are deployed across apps. How do assembly versioning and dependency boundaries affect rollout safety?
11. A desktop WPF app becomes hard to maintain. How would MVVM, commanding, and templating reduce long-term cost?
12. Your team is migrating from .NET Framework to modern .NET. How do you sequence risk: platform APIs, hosting model, data layer, and deployment?
13. A production incident appears only after host runtime patching. How would you evaluate and adjust `rollForward` policy safely?
14. Your org wants self-contained builds for all services. When would you push back and prefer framework-dependent deployment?
15. A plugin-heavy app used AppDomains on .NET Framework. How would you redesign isolation/unloading with `AssemblyLoadContext`?
16. You are asked to migrate WCF server endpoints to .NET 8. How do you evaluate CoreWCF vs gRPC vs REST by contract compatibility and operational risk?

## The Revision Bank

1. What is the practical difference between CLR services and BCL APIs?
2. Why is IL central to language interoperability in .NET?
3. How do CTS and CLS work together to support cross-language libraries?
4. What assembly metadata fields are critical for versioning and deployment?
5. When is managed code preferred over unmanaged code, and why?
6. What GC behaviors most affect API latency under load?
7. When should `DataReader`, `DataSet`, or EF each be preferred?
8. How do EF migrations and concurrency controls reduce production risk?
9. What are the most common globalization/localization bugs in enterprise apps?
10. In what scenarios is WCF still a valid architectural choice?
11. Which deployment model (framework-dependent vs self-contained) fits your service and why?
12. How did .NET evolve from Framework to modern .NET, and why does that matter for architecture?

## Clarification / Suggested Additions Before Finalizing

To strengthen this note for true senior interviews, I recommend adding a short extension section on:
- modern runtime choices: ReadyToRun, NativeAOT, trimming, and startup trade-offs;
- async internals: thread pool behavior, context capture, backpressure, and cancellation strategy;
- observability: structured logging, distributed tracing, metrics, and production diagnostics tooling;
- cloud deployment specifics: containers, health probes, graceful shutdown, and configuration/secret management.

If you want, I can add this as a compact "Advanced Addendum" in the same file while keeping the current structure intact.
