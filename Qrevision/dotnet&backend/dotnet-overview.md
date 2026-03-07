# .NET Core Concepts – Revision Notes

---

# 1. What is .NET

.NET is a **managed runtime platform** for building applications using languages like **C#, F#, VB.NET**.

Main components:

```
.NET
 ├── CLR (runtime execution engine)
 └── BCL/FCL (libraries)
```

Provides:

* managed execution
* garbage collection
* type safety
* language interoperability
* large base libraries

---

# 2. CLR (Common Language Runtime)

CLR is the **execution engine of .NET**.

Responsibilities:

```
JIT compilation (IL → machine code)
Garbage collection
Memory management
Thread management
Exception handling
Security verification
Assembly loading
```

Similar concept:

```
CLR ≈ JVM
```

---

# 3. BCL vs FCL

### BCL (Base Class Library)

Core APIs used by all .NET apps.

Examples:

```
System
System.IO
System.Collections
System.Threading
System.Text
System.Linq
```

---

### FCL (Framework Class Library)

FCL = **BCL + higher-level frameworks**

Examples:

```
ASP.NET
WPF
Windows Forms
ADO.NET
WCF
Entity Framework
```

Structure:

```
FCL
 └── BCL
```

---

# 4. Why .NET Compiles to IL

Compilation pipeline:

```
C# → IL → JIT → Native Code
```

Reasons:

**1. Language interoperability**

```
C#
VB.NET
F#
→ compile to IL
```

**2. Platform portability**

Same IL runs on:

```
Windows
Linux
Mac
```

**3. Runtime optimization**

JIT optimizes for:

```
CPU architecture
runtime conditions
```

**4. Security**

CLR verifies IL for type safety.

---

# 5. JIT Compilation Flow

Execution pipeline:

```
C# code
   ↓
Roslyn compiler
   ↓
IL + Metadata
   ↓
Assembly (.dll/.exe)
   ↓
CLR loads assembly
   ↓
IL verification
   ↓
JIT compiles methods
   ↓
Native machine code
   ↓
CPU execution
```

Important concept:

```
JIT compiles methods only when first used
```

Example:

```
Main() compiled first
Other methods compiled when called
```

---

# 6. Assemblies

Assembly = **deployment unit of .NET**

Examples:

```
MyApp.dll
MyLibrary.dll
```

Contains:

```
IL code
metadata
manifest
resources
```

---

# 7. Assembly Manifest

Manifest describes assembly identity.

Contains:

```
Assembly name
Version
Culture
Public key token
Dependencies
File list
Security information
```

Example identity:

```
MyLibrary, Version=1.0.0.0
```

---

# 8. Managed vs Unmanaged Code

### Managed Code

Runs under **CLR control**.

Features:

```
automatic memory management
type safety
exception handling
garbage collection
```

Examples:

```
C#
F#
VB.NET
```

---

### Unmanaged Code

Runs directly on OS.

Examples:

```
C
C++
Win32 API
COM
```

Memory managed manually.

---

### Interoperability (P/Invoke)

Example:

```
[DllImport("kernel32.dll")]
static extern uint GetTickCount();
```

Allows **C# → native OS calls**.

---

# 9. Garbage Collection

GC removes **unreachable objects from managed heap**.

Example:

```
object obj = new object();
obj = null
```

Object becomes eligible for GC.

---

### Generations

```
Gen 0 → short-lived objects
Gen 1 → medium-lived
Gen 2 → long-lived
```

Reason:

```
Most objects die young
```

---

### Large Object Heap (LOH)

Objects > **85KB**.

Examples:

```
large arrays
images
buffers
```

Not compacted frequently.

---

# 10. IDisposable

GC cleans **memory**, not **external resources**.

Implement IDisposable when using:

```
file handles
database connections
network sockets
unmanaged memory
```

Example:

```
using(var file = new FileStream(...))
{
}
```

Calls:

```
Dispose()
```

---

# 11. CTS vs CLS

### CTS (Common Type System)

Defines **all .NET data types**.

Examples:

```
Int32
String
Object
Array
```

Rules for:

```
type declaration
inheritance
memory layout
```

---

### CLS (Common Language Specification)

Subset of CTS ensuring **language interoperability**.

Example issue:

```
C# supports unsigned int
VB.NET does not
```

CLS avoids non-compatible types.

Relationship:

```
CTS
 └── CLS (subset)
```

---

# 12. ADO.NET Disconnected Architecture

Traditional DB access:

```
connection open
query
process
connection close
```

Bad for scalability.

---

ADO.NET approach:

```
Database
 ↓
DataAdapter
 ↓
DataSet (in memory)
 ↓
Connection closed
```

Benefits:

```
fewer open connections
better scalability
```

---

# 13. DataReader vs DataSet

### DataReader

```
Connected
Forward-only
Read-only
Very fast
Low memory
```

Example:

```
SqlDataReader
```

---

### DataSet

```
Disconnected
Stores multiple tables
Editable
Higher memory usage
```

Structure:

```
DataSet
 ├── DataTable
 ├── DataRow
 └── DataRelation
```

---

# 14. Entity Framework

EF is an **ORM (Object Relational Mapper)**.

Maps:

```
Database tables
↓
C# objects
```

Example:

```
Users table → User class
```

---

Core capabilities:

```
LINQ queries
change tracking
lazy/eager loading
migrations
code-first development
```

Example:

```
context.Users.Where(u => u.Age > 18)
```

---

# 15. Globalization vs Localization

### Globalization

Application supports **multiple cultures**.

Examples:

```
date formats
number formats
currency
```

---

### Localization

Translate UI for specific languages.

Example:

```
Hello → Bonjour
```

Done using:

```
.resx resource files
```

---

# 16. WCF

Windows Communication Foundation = **service communication framework**.

Used for:

```
distributed systems
SOA architectures
enterprise services
```

Supports protocols:

```
HTTP
TCP
Named Pipes
MSMQ
```

---

### WCF ABC Model

```
A → Address (service location)
B → Binding (protocol)
C → Contract (service interface)
```

---

# 17. Target Framework Moniker (TFM)

TFM specifies **target runtime**.

Examples:

```
net8.0
net7.0
net6.0
netstandard2.0
```

Defined in:

```
.csproj
```

Example:

```
<TargetFramework>net8.0</TargetFramework>
```

Determines:

```
API availability
runtime compatibility
dependency resolution
```

---

# 18. Deployment Types

### Framework-dependent

App requires installed runtime.

Run:

```
dotnet app.dll
```

Advantages:

```
smaller size
shared runtime
```

---

### Self-contained

Runtime bundled with app.

Advantages:

```
runs without .NET installed
```

Tradeoff:

```
large size
```

---

# 19. runtimeconfig.json

Generated during build.

Example:

```
MyApp.runtimeconfig.json
```

Controls:

```
runtime version
framework dependency
GC settings
ThreadPool settings
roll-forward behavior
```

Example:

```
{
 "runtimeOptions": {
  "tfm": "net8.0",
  "framework": {
   "name": "Microsoft.NETCore.App",
   "version": "8.0.0"
  }
 }
}
```

---

# 20. Important Runtime Concepts

### Managed Heap

Where CLR allocates objects.

Structure:

```
Gen0
Gen1
Gen2
```

---

### ThreadPool

Pool of reusable threads used by:

```
Task
async/await
parallel operations
```

---

### async/await

Async methods compile into **state machines**.

Concept:

```
await pauses method
thread released
continuation resumes later
```

---

# 21. ASP.NET Core Concepts

### Middleware

Component in request pipeline.

Example pipeline:

```
Request
 ↓
Logging
 ↓
Authentication
 ↓
Authorization
 ↓
Controller
 ↓
Response
```

---

### Dependency Injection

Built-in container manages object creation.

Example:

```
services.AddScoped<IUserService, UserService>();
```

Injection:

```
UserController(IUserService service)
```

Benefits:

```
loose coupling
testability
maintainability
```

---

# 22. EF Loading Strategies

### Lazy Loading

Data loaded **when accessed**.

Example:

```
user.Orders
```

Triggers query.

---

### Eager Loading

Load related data immediately.

Example:

```
context.Users.Include(u => u.Orders)
```

---

# 23. .NET Versions

| Platform       | Description         |
| -------------- | ------------------- |
| .NET Framework | Windows-only legacy |
| .NET Core      | Cross-platform      |
| .NET 5+        | Unified modern .NET |

---

# 24. Kestrel

Default **ASP.NET Core web server**.

Features:

```
high performance
cross platform
async networking
```

Often behind:

```
IIS
Nginx
Apache
```

---
