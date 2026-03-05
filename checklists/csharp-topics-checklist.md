# C# Topics Checklist

## Basic Syntax & Concepts
- [ ] Data types (value vs reference types)
- [ ] Variables, constants, literals
- [ ] Operators (arithmetic, logical, ternary, null-coalescing, null-conditional)
- [ ] Control structures (if/else, switch, loops)
- [ ] Comments and XML documentation
- [ ] Namespaces and using directives

## Object-Oriented Programming (OOP)
- [ ] Classes and Objects
- [ ] Encapsulation (access modifiers: public, private, protected, internal, private protected)
- [ ] Inheritance (base, derived classes, sealed)
- [ ] Polymorphism (method overriding, virtual/override)
- [ ] Abstraction (abstract classes, interfaces)
- [ ] Explicit interface implementation
- [ ] Interface default methods (C# 8.0+)
- [ ] Shadowing (new keyword for method hiding) vs overriding
- [ ] Liskov Substitution Principle violations
- [ ] Interface Segregation with explicit implementation
- [ ] Dependency Inversion with factory patterns
- [ ] Object lifetime and construction sequence

## Core Types and Members
- [ ] Methods (parameters, return types, overloading, optional parameters)
- [ ] Properties (auto-implemented, get/set, computed, init-only)
- [ ] Constructors (default, parameterized, static, private)
- [ ] Fields vs Properties
- [ ] Structs vs Classes
- [ ] Enums and Flags
- [ ] Static classes, methods, and constructors
- [ ] Partial classes and methods
- [ ] Indexers
- [ ] Operator overloading
- [ ] Extension methods
- [ ] Object initializer syntax
- [ ] Collection initializers
- [ ] Named and optional arguments
- [ ] Expression-bodied members

## Memory Management & Performance
- [ ] Garbage Collection (Generations: Gen 0, 1, 2)
- [ ] Stack vs Heap allocation
- [ ] IDisposable interface and using statement
- [ ] Finalizers vs Destructors
- [ ] Boxing and Unboxing
- [ ] String interning and StringBuilder
- [ ] Weak references (WeakReference, WeakReference<T>)
- [ ] Memory<T> and Span<T> advanced usage
- [ ] Array segment and memory slicing
- [ ] Unmanaged memory allocation with Marshal
- [ ] Object pooling
- [ ] ArrayPool<T>
- [ ] Struct layout (StructLayout, FieldOffset)
- [ ] Volatile keyword and memory barriers
- [ ] SkipLocalsInit attribute
- [ ] AggressiveInlining method attribute
- [ ] Stack-based value types optimization
- [ ] Large Object Heap (LOH) and fragmentation
- [ ] GC collection modes (Optimized, SustainedLowLatency)

## Generics
- [ ] Generic classes, methods, interfaces
- [ ] Constraints (where T : class, new(), struct, Interface, base class)
- [ ] Covariance and Contravariance (in, out modifiers)
- [ ] Generic collections (List<T>, Dictionary<TKey,TValue>)
- [ ] Generic type inference rules
- [ ] Static members in generic classes
- [ ] Generic attribute constraints (C# 11+)
- [ ] Open vs closed generics

## Collections & LINQ
- [ ] Collections hierarchy (IEnumerable, ICollection, IList, IReadOnlyCollection)
- [ ] LINQ (Language Integrated Query)
- [ ] Deferred vs immediate execution
- [ ] IQueryable vs IEnumerable
- [ ] LINQ methods (Where, Select, GroupBy, Join, Aggregate)
- [ ] LINQ query syntax vs method syntax
- [ ] LINQ providers and custom IQueryable implementation
- [ ] Expression tree manipulation and building
- [ ] PLINQ (Parallel LINQ) and limitations
- [ ] LINQ to Objects vs LINQ to Entities
- [ ] Custom LINQ extension methods
- [ ] ToList() vs ToArray() performance

## Delegates, Events & Lambdas
- [ ] Delegates (Action, Func, Predicate)
- [ ] Events and event handlers
- [ ] Anonymous methods
- [ ] Lambda expressions
- [ ] Expression trees
- [ ] Delegate covariance and contravariance
- [ ] Event accessors (add/remove)
- [ ] Multicast delegates

## Exception Handling
- [ ] try-catch-finally blocks
- [ ] Exception filters (when keyword)
- [ ] Custom exception classes
- [ ] throw vs throw ex
- [ ] Exception stack traces preservation
- [ ] First-chance vs second-chance exceptions
- [ ] Exception performance costs

## Asynchronous Programming
- [ ] async/await pattern
- [ ] Task Parallel Library (TPL)
- [ ] Task, Task<T>, ValueTask
- [ ] Task.Run vs Task.Factory.StartNew
- [ ] ConfigureAwait(false) and synchronization context
- [ ] Parallel class (Parallel.For, Parallel.ForEach)
- [ ] CancellationToken and cooperative cancellation
- [ ] Async void method dangers
- [ ] TaskCompletionSource for custom async operations
- [ ] ValueTask pooling and usage
- [ ] IAsyncDisposable and await using
- [ ] Async streams (IAsyncEnumerable<T>)
- [ ] Async state machines internals
- [ ] Task continuations (ContinueWith)
- [ ] Task status and exception handling
- [ ] WhenAll vs WhenAny

## Advanced Language Features
- [ ] Nullable reference types (C# 8+)
- [ ] Pattern Matching (C# 7+)
- [ ] Type patterns, property patterns, tuple patterns
- [ ] Switch expressions
- [ ] Pattern matching with and, or, not patterns
- [ ] Records (C# 9+)
- [ ] Positional records, with-expressions
- [ ] Top-level statements (C# 9+)
- [ ] Global using directives (C# 10+)
- [ ] File-scoped namespaces (C# 10+)
- [ ] Raw string literals (C# 11+)
- [ ] Primary constructors (C# 12+)
- [ ] Collection expressions (C# 12+)
- [ ] Local functions (static, capturing vs non-capturing)
- [ ] Discards (_) and various uses
- [ ] Range and Index operators
- [ ] Null-forgiving operator (!) implications
- [ ] Required members (C# 11+)
- [ ] Inline arrays (C# 12+)
- [ ] ref returns and ref locals
- [ ] ref struct constraints and limitations
- [ ] Caller argument expression attribute (C# 10+)
- [ ] Interpolated string handlers (C# 10+)
- [ ] Unsigned right shift operator (>>>)
- [ ] Target-typed new expressions
- [ ] Static anonymous functions
- [ ] Module initializers

## Reflection & Attributes
- [ ] System.Reflection namespace
- [ ] Custom attributes
- [ ] Compile-time vs runtime reflection
- [ ] Source Generators (C# 9+)
- [ ] InternalsVisibleTo attribute for testing
- [ ] Assembly loading contexts
- [ ] DynamicMethod and IL generation
- [ ] Custom attribute usage and restrictions

## Unsafe Code & Pointers
- [ ] unsafe keyword
- [ ] Pointers and pointer types
- [ ] fixed statement
- [ ] stackalloc
- [ ] Pointer arithmetic
- [ ] sizeof and typeof with pointers

## Dynamic Programming
- [ ] dynamic keyword
- [ ] Dynamic Language Runtime (DLR)
- [ ] ExpandoObject
- [ ] Dynamic for COM interop
- [ ] DynamicObject custom implementation
- [ ] IDynamicMetaObjectProvider

## Concurrency & Parallelism
- [ ] Thread vs Task
- [ ] ThreadPool mechanics
- [ ] Synchronization primitives
- [ ] lock, Monitor, Mutex, SemaphoreSlim
- [ ] ReaderWriterLockSlim
- [ ] Concurrent collections
- [ ] Interlocked operations
- [ ] Volatile read/write semantics
- [ ] Memory barriers and reordering
- [ ] SpinLock and SpinWait
- [ ] Lazy<T> initialization patterns
- [ ] Timer classes comparison
- [ ] Barrier and CountdownEvent
- [ ] Channel<T> for producer-consumer scenarios
- [ ] Async synchronization primitives (SemaphoreSlim, AsyncLock)

## Design Patterns in C#
- [ ] Repository Pattern
- [ ] Factory Pattern variations
- [ ] Strategy Pattern
- [ ] Observer Pattern (events/delegates)
- [ ] Dependency Injection Pattern
- [ ] Singleton Pattern (thread-safe implementations)
- [ ] Builder Pattern
- [ ] Adapter Pattern
- [ ] Decorator Pattern
- [ ] Command Pattern
- [ ] Mediator Pattern
- [ ] Template Method Pattern

## Advanced C# Internals
- [ ] Expression Trees and compilation
- [ ] Caller Information Attributes
- [ ] Conditional compilation (#if, #endif)
- [ ] Default interface methods (C# 8+)
- [ ] Covariant return types (C# 9+)
- [ ] Compiler-generated code (async, iterators, anonymous types)
- [ ] Just-In-Time (JIT) compilation
- [ ] Ahead-of-Time (AOT) compilation
- [ ] Method inlining and [MethodImpl]
- [ ] Assembly loading and reflection context
- [ ] Friend assemblies

## Serialization & IO
- [ ] System.Text.Json vs Newtonsoft.Json differences
- [ ] Memory-mapped files
- [ ] Pipelines (System.IO.Pipelines) for high-performance IO
- [ ] Stream types and usage patterns
- [ ] Binary serialization
- [ ] XML serialization
- [ ] Custom serializers

## Diagnostics & Debugging
- [ ] ConditionalAttribute advanced usage
- [ ] DebuggerDisplay and DebuggerTypeProxy
- [ ] Caller information attributes in production
- [ ] Performance counters
- [ ] EventSource and ETW
- [ ] Debugger attributes (DebuggerStepThrough, DebuggerHidden)
- [ ] Code analysis attributes

## COM Interop & Platform Invoke
- [ ] P/Invoke and marshaling attributes
- [ ] COM visibility and registration
- [ ] COM interop with dynamic
- [ ] SafeHandle and critical finalizers
- [ ] DllImport and calling conventions

## Common Pitfalls & Gotchas
- [ ] String comparison culture sensitivity
- [ ] DateTime vs DateTimeOffset usage
- [ ] Floating-point precision issues
- [ ] Collection modification during enumeration
- [ ] Event handler memory leaks
- [ ] Task.Result vs await deadlock scenarios
- [ ] Closure capture issues
- [ ] Null coalescing operator precedence
- [ ] String immutability and concatenation
- [ ] Enum parsing and validation
- [ ] Hash code collisions and GetHashCode implementation

## C# Version-Specific Features
- [ ] C# 2.0: Generics, anonymous methods, iterators
- [ ] C# 3.0: LINQ, lambda expressions, extension methods
- [ ] C# 4.0: dynamic, named arguments, optional parameters
- [ ] C# 5.0: async/await, caller info attributes
- [ ] C# 6.0: null-conditional, string interpolation, nameof
- [ ] C# 7.0: tuples, pattern matching, local functions
- [ ] C# 7.1: async Main, default literal
- [ ] C# 7.2: in parameters, readonly struct, private protected
- [ ] C# 7.3: enhanced generic constraints, == for tuples
- [ ] C# 8.0: nullable reference types, async streams, ranges
- [ ] C# 9.0: records, init-only, pattern matching enhancements
- [ ] C# 10.0: record structs, global using, file-scoped namespaces
- [ ] C# 11.0: raw string literals, required members, generic math
- [ ] C# 12.0: primary constructors, collection expressions, inline arrays

## Performance Optimization
- [ ] String creation and manipulation optimizations
- [ ] Collection choice and performance characteristics
- [ ] Allocation reduction techniques
- [ ] Loop optimization and bounds checking
- [ ] Interface dispatch performance
- [ ] Sealed class performance benefits
- [ ] Struct pass semantics (in, ref, readonly)
- [ ] Enumeration performance (foreach vs for)
- [ ] LINQ performance implications
- [ ] Async method state machine overhead

## Updated Key Focus Areas for 4-Years Experience
1. **Async/Await Deep Dive** - State machines, deadlock prevention, performance
2. **Memory Management** - GC behavior, disposal patterns, leak detection
3. **LINQ & Performance** - Query optimization, IQueryable providers, N+1 issues
4. **Dependency Injection** - Lifetime management, service disposal, testing
5. **Latest C# Features** - Practical application of newer language features
6. **Performance Optimization** - Allocation reduction, hot path optimization
7. **Concurrency** - Thread safety, synchronization, async patterns
8. **Design Patterns** - Real-world implementation and tradeoffs
