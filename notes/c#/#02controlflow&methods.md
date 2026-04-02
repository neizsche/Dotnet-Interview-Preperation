
# Statements

Statements are the building blocks of C# code execution, controlling the flow of your program and dictating how operations are carried out. Understanding these core language constructs is essential for effective C# programming.

## Control flow

Control flow statements allow you to make decisions and execute different code paths based on conditions.

### If-else statements

If-else statements execute different code blocks based on boolean conditions. They form the foundation of decision-making in C#.

```csharp
// Basic if statement
if (condition)
{
    // Code executed if condition is true
}

// If-else
if (temperature > 30)
{
    Console.WriteLine("It's hot outside");
}
else
{
    Console.WriteLine("It's not too hot");
}

// If-else if-else chain
if (temperature > 30)
{
    Console.WriteLine("It's hot outside");
}
else if (temperature > 20)
{
    Console.WriteLine("It's warm outside");
}
else if (temperature > 10)
{
    Console.WriteLine("It's cool outside");
}
else
{
    Console.WriteLine("It's cold outside");
}

// Conditional (ternary) operator - shorthand for simple if-else
string message = age >= 18 ? "Adult" : "Minor";

// Null-coalescing operator (??) - returns the left operand if it's not null, otherwise the right
string name = userName ?? "Anonymous";

// Null-conditional operator (?.) - safely accesses members of potentially null objects
int? length = customer?.Name?.Length;

// Null-coalescing assignment (??=) - C# 8.0+
// Assigns the right operand only if the left operand is null
userName ??= "Anonymous";
```

### Switch statements and expressions

Switch statements provide a way to handle multiple possible conditions for a single value. Modern C# also offers powerful switch expressions.

```csharp
// Traditional switch statement
switch (dayOfWeek)
{
    case DayOfWeek.Monday:
        Console.WriteLine("Start of work week");
        break;
    case DayOfWeek.Friday:
        Console.WriteLine("End of work week");
        break;
    case DayOfWeek.Saturday:
    case DayOfWeek.Sunday:
        Console.WriteLine("Weekend");
        break;
    default:
        Console.WriteLine("Midweek");
        break;
}

// Switch expression (C# 8.0+)
string GetDayType(DayOfWeek day) => day switch
{
    DayOfWeek.Monday => "Start of work week",
    DayOfWeek.Friday => "End of work week",
    DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend",
    _ => "Midweek"  // Default case
};

// Switch expression with pattern matching
string GetShapeDescription(object shape) => shape switch
{
    Circle c when c.Radius > 10 => "Large circle",
    Circle _ => "Circle",
    Rectangle { Width: 0 } => "Line",
    Rectangle { Length: var l, Width: var w } when l == w => "Square",
    Rectangle _ => "Rectangle",
    null => "No shape",
    _ => "Unknown shape"
};
```

## Loops

Loops allow you to execute a block of code repeatedly until a condition is met.

### For loops

For loops are ideal when you know the number of iterations in advance.

```csharp
// Basic for loop
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Iteration {i}");
}

// Multiple loop variables
for (int i = 0, j = 10; i < j; i++, j--)
{
    Console.WriteLine($"i = {i}, j = {j}");
}

// Nested for loops
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.WriteLine($"Position [{i},{j}]");
    }
}

// Breaking out of a loop
for (int i = 0; i < 100; i++)
{
    if (i > 10)
        break;  // Exits the loop
    
    Console.WriteLine(i);
}

// Skipping an iteration
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
        continue;  // Skips to the next iteration
    
    Console.WriteLine($"Odd number: {i}");
}
```

### Foreach loops

Foreach loops are designed for iterating through collections and are simpler to use than for loops when the iteration count isn't important.

```csharp
// Basic foreach loop
foreach (string name in names)
{
    Console.WriteLine(name);
}

// Using index with foreach (C# 9.0+)
foreach (string name in names.Select((value, index) => new { value, index }))
{
    Console.WriteLine($"{name.index}: {name.value}");
}

// Iterating through key-value pairs
foreach (KeyValuePair<string, int> pair in dictionary)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}

// Using deconstruction with foreach (C# 7.0+)
foreach (var (key, value) in dictionary)
{
    Console.WriteLine($"{key}: {value}");
}

// Breaking and continuing also work in foreach
foreach (var item in collection)
{
    if (ShouldSkip(item))
        continue;
    
    if (ShouldStop(item))
        break;
    
    Process(item);
}
```

### While and do-while loops

While loops check the condition before executing the loop body, while do-while loops execute the body at least once before checking the condition.

```csharp
// While loop - may execute zero times
while (condition)
{
    // Loop body
}

// Example: reading until a condition is met
while (!Console.KeyAvailable)
{
    // Process until a key is pressed
    ProcessData();
}

// Do-while loop - always executes at least once
do
{
    // Loop body
} while (condition);

// Example: menu system
string choice;
do
{
    DisplayMenu();
    choice = Console.ReadLine();
    ProcessChoice(choice);
} while (choice != "exit");
```


### **if-else Statements - Beyond Basics**

**Advanced Patterns:**
```csharp
// 1. Pattern matching with if (C# 7.0+)
if (obj is string s && s.Length > 5)
{
    Console.WriteLine($"String length: {s.Length}");
}

// 2. Null pattern matching
if (nullableInt is int number)
{
    Console.WriteLine($"Number: {number}");
}

// 3. Complex condition evaluation
if (value is > 0 and < 100 or 999) // C# 9.0 relational patterns
{
    Console.WriteLine("Valid range or special value");
}
```

### **switch Statements - Advanced Features**

**Pattern Matching Switch (C# 8.0+):**
```csharp
public static string GetDisplayText(object obj) => obj switch
{
    string s when s.Length > 10 => $"Long string: {s.Substring(0, 10)}...",
    string s => $"String: {s}",
    int i when i > 0 => $"Positive number: {i}",
    int i => $"Number: {i}",
    null => "Null object",
    _ => "Unknown type"
};

// Property patterns
static bool IsConferenceSpeaker(Person person) => person switch
{
    { Role: "Speaker", Experience: > 5 } => true,
    { Company: "Microsoft" or "Google" } => true,
    _ => false
};
```

**Switch Expressions (C# 8.0+):**
```csharp
// Traditional switch statement
string result;
switch (value)
{
    case 1: result = "One"; break;
    case 2: result = "Two"; break;
    default: result = "Other"; break;
}

// Switch expression (more concise)
string result = value switch
{
    1 => "One",
    2 => "Two",
    _ => "Other"
};
```

### **Loop Optimization Techniques**

**foreach vs for Performance:**
```csharp
var list = new List<int> { 1, 2, 3, 4, 5 };

// ❌ Creates enumerator (slight overhead)
foreach (var item in list)
{
    Console.WriteLine(item);
}

// ✅ Direct index access (faster for lists)
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

// 🚀 Best for arrays - no bounds check in release mode
var array = new int[] { 1, 2, 3, 4, 5 };
for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
```

**Loop Variable Capture Gotcha:**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}

foreach (var action in actions)
{
    action(); // Prints "3" three times! (captured variable)
}

// Fix: create local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```

---

## Grouped Control Flow Deep-Dive Copies

These copies are kept together so you can compare overlapping explanations before removing anything.

### Control Flow Deep-Dive Copy 1
# Control Flow Statements & Methods/Parameters - Deep Dive

## 🔍 Control Flow Statements - Deep Understanding

### **if-else Statements - Beyond Basics**

**Advanced Patterns:**
```csharp
// 1. Pattern matching with if (C# 7.0+)
if (obj is string s && s.Length > 5)
{
    Console.WriteLine($"String length: {s.Length}");
}

// 2. Null pattern matching
if (nullableInt is int number)
{
    Console.WriteLine($"Number: {number}");
}

// 3. Complex condition evaluation
if (value is > 0 and < 100 or 999) // C# 9.0 relational patterns
{
    Console.WriteLine("Valid range or special value");
}
```

**Performance Considerations:**
```csharp
// ❌ Inefficient - multiple evaluations
if (IsValid(user)) { /* ... */ }
if (IsValid(user)) { /* ... */ }

// ✅ Efficient - single evaluation
bool isValid = IsValid(user);
if (isValid) { /* ... */ }
if (isValid) { /* ... */ }
```

### **switch Statements - Advanced Features**

**Pattern Matching Switch (C# 8.0+):**
```csharp
public static string GetDisplayText(object obj) => obj switch
{
    string s when s.Length > 10 => $"Long string: {s.Substring(0, 10)}...",
    string s => $"String: {s}",
    int i when i > 0 => $"Positive number: {i}",
    int i => $"Number: {i}",
    null => "Null object",
    _ => "Unknown type"
};

// Property patterns
static bool IsConferenceSpeaker(Person person) => person switch
{
    { Role: "Speaker", Experience: > 5 } => true,
    { Company: "Microsoft" or "Google" } => true,
    _ => false
};
```

**Switch Expressions (C# 8.0+):**
```csharp
// Traditional switch statement
string result;
switch (value)
{
    case 1: result = "One"; break;
    case 2: result = "Two"; break;
    default: result = "Other"; break;
}

// Switch expression (more concise)
string result = value switch
{
    1 => "One",
    2 => "Two",
    _ => "Other"
};
```

### **Loop Optimization Techniques**

**foreach vs for Performance:**
```csharp
var list = new List<int> { 1, 2, 3, 4, 5 };

// ❌ Creates enumerator (slight overhead)
foreach (var item in list)
{
    Console.WriteLine(item);
}

// ✅ Direct index access (faster for lists)
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

// 🚀 Best for arrays - no bounds check in release mode
var array = new int[] { 1, 2, 3, 4, 5 };
for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
```

**Loop Variable Capture Gotcha:**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}

foreach (var action in actions)
{
    action(); // Prints "3" three times! (captured variable)
}

// Fix: create local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```

---

### Control Flow Deep-Dive Copy 2
# Control Flow Statements & Methods/Parameters - Deep Dive

## 🔍 Control Flow Statements - Deep Understanding

### **if-else Statements - Beyond Basics**

**Advanced Patterns:**
```csharp
// 1. Pattern matching with if (C# 7.0+)
if (obj is string s && s.Length > 5)
{
    Console.WriteLine($"String length: {s.Length}");
}

// 2. Null pattern matching
if (nullableInt is int number)
{
    Console.WriteLine($"Number: {number}");
}

// 3. Complex condition evaluation
if (value is > 0 and < 100 or 999) // C# 9.0 relational patterns
{
    Console.WriteLine("Valid range or special value");
}
```

**Performance Considerations:**
```csharp
// ❌ Inefficient - multiple evaluations
if (IsValid(user)) { /* ... */ }
if (IsValid(user)) { /* ... */ }

// ✅ Efficient - single evaluation
bool isValid = IsValid(user);
if (isValid) { /* ... */ }
if (isValid) { /* ... */ }
```

### **switch Statements - Advanced Features**

**Pattern Matching Switch (C# 8.0+):**
```csharp
public static string GetDisplayText(object obj) => obj switch
{
    string s when s.Length > 10 => $"Long string: {s.Substring(0, 10)}...",
    string s => $"String: {s}",
    int i when i > 0 => $"Positive number: {i}",
    int i => $"Number: {i}",
    null => "Null object",
    _ => "Unknown type"
};

// Property patterns
static bool IsConferenceSpeaker(Person person) => person switch
{
    { Role: "Speaker", Experience: > 5 } => true,
    { Company: "Microsoft" or "Google" } => true,
    _ => false
};
```

**Switch Expressions (C# 8.0+):**
```csharp
// Traditional switch statement
string result;
switch (value)
{
    case 1: result = "One"; break;
    case 2: result = "Two"; break;
    default: result = "Other"; break;
}

// Switch expression (more concise)
string result = value switch
{
    1 => "One",
    2 => "Two",
    _ => "Other"
};
```

### **Loop Optimization Techniques**

**foreach vs for Performance:**
```csharp
var list = new List<int> { 1, 2, 3, 4, 5 };

// ❌ Creates enumerator (slight overhead)
foreach (var item in list)
{
    Console.WriteLine(item);
}

// ✅ Direct index access (faster for lists)
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

// 🚀 Best for arrays - no bounds check in release mode
var array = new int[] { 1, 2, 3, 4, 5 };
for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}
```

**Loop Variable Capture Gotcha:**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}

foreach (var action in actions)
{
    action(); // Prints "3" three times! (captured variable)
}

// Fix: create local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```

---

## Control Flow Related Keywords and Senior Notes

This block stays near control flow because it expands on `lock`, `using`, `unsafe`, `yield`, and related interview talking points.
## Lock statement

The lock statement prevents multiple threads from accessing a shared resource simultaneously, helping to avoid race conditions in multithreaded code.

```csharp
// Define a lock object (private to avoid external locking)
private readonly object _lockObject = new object();

// Using the lock statement
public void AddItem(string item)
{
    lock (_lockObject)
    {
        // This code can only be executed by one thread at a time
        _items.Add(item);
        _count++;
    }
}

```

**Best practices for locks:**
1. Use a private dedicated object for locking (or `System.Threading.Lock` in .NET 9 / C# 13+)
2. Keep the locked section as small as possible
3. Avoid locking on 'this' or public objects
4. Don't execute long-running or blocking operations inside a lock
5. Consider using higher-level synchronization primitives for complex scenarios

## Using statement

The `using` statement ensures that disposable resources are properly cleaned up, even if exceptions occur. It's an essential pattern for working with resources like files, network connections, and database connections that need to be explicitly released.

```csharp
// Traditional using statement
using (StreamReader reader = new StreamReader("file.txt"))
{
    string content = reader.ReadToEnd();
    // reader is automatically disposed here, even if an exception occurs
}

// Using declaration (C# 8.0+)
using StreamWriter writer = new StreamWriter("output.txt");
writer.WriteLine("Hello, World!");
// writer is disposed at the end of the scope

// Multiple resources in one using statement
using (var connection = new SqlConnection(connectionString))
using (var command = new SqlCommand(queryString, connection))
{
    connection.Open();
    using (var reader = command.ExecuteReader())
    {
        // Process data
    }
}

// Using declaration with multiple resources (C# 8.0+)
using var fileStream = new FileStream("data.bin", FileMode.Create);
using var binaryWriter = new BinaryWriter(fileStream);
binaryWriter.Write(42);
// Both binaryWriter and fileStream are disposed at end of scope
```

## Unsafe code

The unsafe keyword allows you to write code that directly manipulates memory. This is primarily used for performance-critical operations or interop with native code.

```csharp
// Must enable unsafe code in project settings or compiler options
// <AllowUnsafeBlocks>true</AllowUnsafeBlocks> in .csproj

// Unsafe method
public unsafe void ProcessBuffer(byte[] buffer)
{
    fixed (byte* ptr = buffer)
    {
        // Direct memory manipulation
        for (int i = 0; i < buffer.Length; i++)
        {
            *(ptr + i) = (byte)(*(ptr + i) * 2);
        }
    }
}

// Unsafe context with pointer operations
unsafe
{
    int value = 10;
    int* pointer = &value;
    
    Console.WriteLine($"Value: {*pointer}");
    
    // Increment the value through the pointer
    *pointer = 20;
    Console.WriteLine($"Updated value: {value}");
}

// sizeof operator (only allowed in unsafe context)
unsafe
{
    Console.WriteLine($"Size of int: {sizeof(int)} bytes");
    Console.WriteLine($"Size of double: {sizeof(double)} bytes");
}
```

## Yield statement

The yield statement is used in iterator methods to provide values one at a time, enabling deferred execution and efficient handling of sequences.

```csharp
// Simple iterator method
public IEnumerable<int> GetNumbers(int count)
{
    for (int i = 0; i < count; i++)
    {
        yield return i;
    }
}

// Iterator method with conditional logic
public IEnumerable<int> GetEvenNumbers(int max)
{
    for (int i = 0; i <= max; i++)
    {
        if (i % 2 == 0)
        {
            yield return i;
        }
    }
}

// Yield break to exit early
public IEnumerable<int> GetNumbersUntil(int max, int stopAt)
{
    for (int i = 0; i <= max; i++)
    {
        if (i == stopAt)
        {
            yield break;  // Exit the iterator
        }
        
        yield return i;
    }
}

// Using yield to implement filtering
public IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
{
    foreach (var item in source)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```

### Benefits of yield:

1. **Lazy evaluation**: Results are computed only when needed
2. **Memory efficiency**: No need to build the entire collection at once
3. **Composability**: Iterator methods can be chained together
4. **Simplicity**: Easier to write than manually implementing IEnumerator

**Additional resources:**
- [C# Statements (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/statements)
- [Selection statements - if, if-else, and switch (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)
- [Iteration statements (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)
- [Lock statement (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock)
- [Using statement (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using)
- [Unsafe keyword (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe)
- [Yield (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield)

### Interview Prep

**Senior Perspective (The "Why")**

- Statements are where control flow, lifetime, and correctness become explicit.
- `switch` improves clarity when branching should be exhaustive and intention-revealing.
- `using` and `await using` are lifetime-management tools that reduce cleanup bugs.
- `lock` protects shared invariants, and `yield` enables deferred, memory-efficient sequence generation.

**Interview Gotchas & Confusion Points**

- `using var` disposes at the end of the current scope, not right after the next statement.
- `await` cannot be used inside a `lock`, which is a common concurrency interview trap.
- Iterator methods do not execute when called; they execute when enumerated.
- `switch` expressions are not just shorter `if/else`; they communicate mapping and exhaustiveness better.
- Many candidates know middleware-like syntax patterns for loops and conditions, but not the runtime behavior behind them.

**Corner Cases**

- Modifying a collection during `foreach` usually invalidates the enumerator.
- `break` exits only the innermost loop or switch.
- `yield return` works with `try/finally`, but not inside `catch` or `finally`.
- Locking the wrong object, such as `this` or a public object, creates hard-to-debug concurrency bugs.

**Behind the Scenes / Internal Logic**

- `using` is conceptually lowered to a `try/finally` so cleanup still happens when exceptions occur.
- `foreach` uses the enumerator pattern behind the scenes (`GetEnumerator`, `MoveNext`, and `Current`), with arrays receiving optimized treatment.
- `lock` traditionally uses `Monitor.Enter` / `Monitor.Exit` with a `try/finally` pattern to guarantee release.
- `yield` causes the compiler to generate a state machine that remembers where iteration should resume.

**Must Remember Facts**

- Prefer `switch` when branching is really a mapping from input shape/value to output.
- Prefer `using` over manual `Dispose()` calls for deterministic cleanup.
- Lock on a private dedicated object and keep critical sections small.
- Reach for `yield` when you want deferred iteration without materializing everything up front.

Here is the breakdown of these advanced keywords and how they impact the CLR.

---

### 1. `yield` (State Machine Iteration)
The `yield` keyword tells the compiler to generate a **state machine** (a hidden class) that implements `IEnumerable<T>` or `IEnumerator<T>`.

* **Execution:** It provides **deferred execution**. The code inside the method doesn't run until you start iterating (e.g., in a `foreach` loop).
* **Memory Benefit:** It allows you to process large data sets (like a 10GB log file) one item at a time without loading the entire collection into RAM.
* **Senior Trap:** Never put a `try-catch` block around a `yield return`. It is a compile-time error because the execution "jumps" in and out of the method, making standard exception handling impossible across those jumps.

---

### 2. `await` (Asynchronous Continuation)
Like `yield`, `await` triggers the compiler to build a complex state machine.

* **Mechanism:** When the code hits `await`, it checks if the task is complete. If not, it signs up the rest of the method as a **callback (continuation)**, captures the `SynchronizationContext`, and returns control to the caller (freeing up the thread).
* **The "Senior" Nuance:** `await` does not necessarily mean "run on a new thread." It means "don't block this thread while waiting." 
* **Performance:** Use `ValueTask` instead of `Task` for methods that often return synchronously to avoid unnecessary heap allocations.

---

### 3. `lock` (Syntactic Sugar for Monitor)
The `lock` keyword is a wrapper around `System.Threading.Monitor`.

* **How it works:** It acquires a mutual exclusion lock for a given object. It translates to a `Monitor.Enter` and a `finally { Monitor.Exit }` block.
* **The "Senior" Rule:** **Never lock on `this`, a `Type` object, or a `string`.** * Locking on `this` or a `Type` can be accessed by external code, leading to deadlocks.
    * Locking on a `string` is dangerous because of **String Interning** (you might be locking an object used by a completely different part of the app).
    * **Best Practice:** Use a `private readonly object _lock = new();`.

---

### 4. `using` (Deterministic Resource Cleanup)
There are two versions: the **Statement** and the **Declaration**.

* **Requirement:** The object must implement `IDisposable` or `IAsyncDisposable`.
* **Modern C# (Using Declaration):** `using var file = new StreamReader(...);` cleans up the resource when the current **scope** ends.
* **Senior Nuance:** `using` is just a `try-finally` block. Even if an exception occurs, `Dispose()` is guaranteed to be called. This is critical for preventing leaks of unmanaged resources like Database connections or File handles.

---

### 5. `unsafe` (Bypassing the Pointer Safety)
This allows you to use **Pointers** (`*`, `&`, `->`) directly, similar to C++.

* **Context:** Used for high-performance scenarios, Interop with C++ libraries, or manipulating bitmaps/buffers directly.
* **Memory:** Pointers point to a fixed memory address. To use a pointer on a managed object (like a string), you must use the `fixed` keyword to "pin" the object so the Garbage Collector doesn't move it while you are reading it.
* **Risk:** You lose the "managed" safety net. You can cause buffer overflows or access violations that crash the entire process.

---

### 📊 Comparison Summary for Study Notes

| Keyword      | Primary Benefit            | Compiler Action                     | Main Risk                       |
| :----------- | :------------------------- | :---------------------------------- | :------------------------------ |
| **`yield`**  | Memory efficiency          | Generates an Iterator State Machine | Deferred execution side-effects |
| **`await`**  | Responsiveness/Scalability | Generates an Async State Machine    | Deadlocks (Async-over-sync)     |
| **`lock`**   | Thread safety              | `Monitor.Enter/Exit`                | Deadlocks / Thread Contention   |
| **`using`**  | Resource Management        | `try-finally { Dispose }`           | Disposing too early             |
| **`unsafe`** | Raw Performance            | Direct memory/pointer access        | Memory corruption/Stability     |

---

### 📝 Final Note for your Markdown

### Advanced C# Keywords
* **Yield:** Use for "Streaming" data. Avoid in logic that needs immediate execution.
* **Await:** Use `ConfigureAwait(false)` in library code to avoid context-switching overhead.
* **Lock:** Always lock on a private, dedicated object. Never use `lock(this)`.
* **Using:** Essential for anything that wraps an OS handle (Files, Sockets, DB).
* **Unsafe:** The last resort for performance. Always prefer `Span<T>` over `unsafe` if possible, as `Span` is type-safe and often just as fast.


**Question Bank (Common Questions + What to Say)**

- `Q: When would you choose switch over if/else?`<br>
  `What to say:` Use `switch` when the logic is really a mapping from input value or shape to an outcome, especially when exhaustiveness and readability matter. Use `if/else` when the logic is more open-ended or sequential.<br>
  `Focus on:` mapping/exhaustiveness vs ad hoc branching.
- `Q: What is the difference between using (...) {} and using var?`<br>
  `What to say:` Both guarantee disposal, but the classic `using` creates an explicit nested scope, while `using var` disposes at the end of the current scope.<br>
  `Focus on:` lifetime boundary, not disposal semantics.
- `Q: Why is await not allowed inside lock?`<br>
  `What to say:` Because `lock` expects the critical section to be entered and exited synchronously. Suspending in the middle would break the lifetime assumptions around the monitor and make concurrency behavior unsafe.<br>
  `Focus on:` synchronous critical-section semantics.
- `Q: What does yield return actually do?`<br>
  `What to say:` It turns the method into an iterator that produces values lazily. The compiler generates a state machine so enumeration can pause and resume across each yielded item.<br>
  `Focus on:` deferred execution and generated state machine.
- `Q: Why is modifying a collection during foreach risky?`<br>
  `What to say:` Most collection enumerators assume the collection stays stable during iteration. Changing it usually invalidates the enumerator and results in runtime failure or inconsistent behavior.<br>
  `Focus on:` enumerator invalidation.



## Grouped Control Flow Interview Copies

These interview blocks are separated from the methods interview copies so the repeated control-flow material stays together.

### Control Flow Interview Copy 1
### **Control Flow Questions**

**Q1: What's the difference between `switch` statement and `switch` expression?**
```csharp
// Answer with examples:
// Switch statement (traditional)
switch (value)
{
    case 1: 
        result = "One";
        break;
    default:
        result = "Other";
        break;
}

// Switch expression (C# 8.0+) - returns a value
result = value switch
{
    1 => "One",
    _ => "Other"
};

// Key differences:
// - Expressions return values, statements don't
// - Expressions are more concise
// - Expressions support more pattern matching features
```

**Q2: When would you use `foreach` vs `for` loops?**
**Answer:**
- Use `foreach` for:
  - Read-only iteration
  - Any IEnumerable collection
  - Cleaner, more readable code
  - When you don't need the index

- Use `for` for:
  - Modifying collection elements
  - When you need the index
  - Performance-critical code (arrays, lists)
  - Reverse iteration or custom step sizes

- Use `for` with arrays for best performance
- Use `foreach` for complex collections where index access is expensive

**Q3: What's wrong with this loop and how to fix it?**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}
foreach (var action in actions) action(); // Prints 3,3,3
```

**Answer:**
```csharp
// Problem: lambda captures the variable 'i', not its value
// Fix: create a local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy for each iteration
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```


### **Tricky Follow-up Questions**

**Q8: What will this code output and why?**
```csharp
int x = 5;
if (x = 5)  // ❌ Compile error in C#
{
    Console.WriteLine("True");
}
```

**Answer:**
**This won't compile in C#** because assignment returns a value, but C# requires a boolean expression in if statements.

**Correct version**:
```csharp
if (x == 5)  // Comparison, not assignment
{
    Console.WriteLine("True");
}
```

**In C/C++ this would work** and always be true, but C# prevents this common bug.

**Q9: Explain this pattern matching code**
```csharp
if (obj is string { Length: > 5 } s)
{
    Console.WriteLine(s.ToUpper());
}
```

**Answer:**
This uses **property pattern** (C# 8.0+):
- Checks if `obj` is a string
- Checks if the string's Length property is greater than 5
- If both true, assigns to variable `s`
- Then uses `s` in the block

**Equivalent to**:
```csharp
if (obj is string temp && temp.Length > 5)
{
    string s = temp;
    Console.WriteLine(s.ToUpper());
}
```

The property pattern is more concise and readable.

**Q10: What's the problem with this method and how to fix it?**
```csharp
public IEnumerable<int> GetNumbers()
{
    var result = new List<int>();
    for (int i = 0; i < 1000000; i++)
    {
        result.Add(i);
    }
    return result;
}
```

**Answer:**
**Problem**: Creates a huge list in memory before returning

**Solution**: Use yield return for lazy evaluation
```csharp
public IEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 1000000; i++)
    {
        yield return i; // Returns immediately, memory efficient
    }
}
```

**Benefits**:
- Memory efficient (only one number at a time)
- Execution starts immediately
- Can handle infinite sequences

---

## 🎯 Key Takeaways for Interviews

1. **Understand the "why"** behind language features, not just the "how"
2. **Know performance implications** of different control flow structures
3. **Master pattern matching** - it's heavily tested in modern C# interviews
4. **Understand parameter passing** nuances - especially value vs reference semantics
5. **Practice explaining complex concepts** with clear, concise examples

This deep understanding will help you answer not just "what" but "why" and "when" questions during interviews.




### Control Flow Interview Copy 2
### **Control Flow Questions**

**Q1: What's the difference between `switch` statement and `switch` expression?**
```csharp
// Answer with examples:
// Switch statement (traditional)
switch (value)
{
    case 1: 
        result = "One";
        break;
    default:
        result = "Other";
        break;
}

// Switch expression (C# 8.0+) - returns a value
result = value switch
{
    1 => "One",
    _ => "Other"
};

// Key differences:
// - Expressions return values, statements don't
// - Expressions are more concise
// - Expressions support more pattern matching features
```

**Q2: When would you use `foreach` vs `for` loops?**
**Answer:**
- Use `foreach` for:
  - Read-only iteration
  - Any IEnumerable collection
  - Cleaner, more readable code
  - When you don't need the index

- Use `for` for:
  - Modifying collection elements
  - When you need the index
  - Performance-critical code (arrays, lists)
  - Reverse iteration or custom step sizes

- Use `for` with arrays for best performance
- Use `foreach` for complex collections where index access is expensive

**Q3: What's wrong with this loop and how to fix it?**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}
foreach (var action in actions) action(); // Prints 3,3,3
```

**Answer:**
```csharp
// Problem: lambda captures the variable 'i', not its value
// Fix: create a local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy for each iteration
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```

### **Tricky Follow-up Questions**

**Q8: What will this code output and why?**
```csharp
int x = 5;
if (x = 5)  // ❌ Compile error in C#
{
    Console.WriteLine("True");
}
```

**Answer:**
**This won't compile in C#** because assignment returns a value, but C# requires a boolean expression in if statements.

**Correct version**:
```csharp
if (x == 5)  // Comparison, not assignment
{
    Console.WriteLine("True");
}
```

**In C/C++ this would work** and always be true, but C# prevents this common bug.

**Q9: Explain this pattern matching code**
```csharp
if (obj is string { Length: > 5 } s)
{
    Console.WriteLine(s.ToUpper());
}
```

**Answer:**
This uses **property pattern** (C# 8.0+):
- Checks if `obj` is a string
- Checks if the string's Length property is greater than 5
- If both true, assigns to variable `s`
- Then uses `s` in the block

**Equivalent to**:
```csharp
if (obj is string temp && temp.Length > 5)
{
    string s = temp;
    Console.WriteLine(s.ToUpper());
}
```

The property pattern is more concise and readable.

**Q10: What's the problem with this method and how to fix it?**
```csharp
public IEnumerable<int> GetNumbers()
{
    var result = new List<int>();
    for (int i = 0; i < 1000000; i++)
    {
        result.Add(i);
    }
    return result;
}
```

**Answer:**
**Problem**: Creates a huge list in memory before returning

**Solution**: Use yield return for lazy evaluation
```csharp
public IEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 1000000; i++)
    {
        yield return i; // Returns immediately, memory efficient
    }
}
```

**Benefits**:
- Memory efficient (only one number at a time)
- Execution starts immediately
- Can handle infinite sequences


---

## 🎯 Key Takeaways for Interviews

1. **Understand the "why"** behind language features, not just the "how"
2. **Know performance implications** of different control flow structures
3. **Master pattern matching** - it's heavily tested in modern C# interviews
4. **Understand parameter passing** nuances - especially value vs reference semantics
5. **Practice explaining complex concepts** with clear, concise examples

This deep understanding will help you answer not just "what" but "why" and "when" questions during interviews.

### Control Flow Interview Copy 3
### **Control Flow Questions**

**Q1: What's the difference between `switch` statement and `switch` expression?**
```csharp
// Answer with examples:
// Switch statement (traditional)
switch (value)
{
    case 1: 
        result = "One";
        break;
    default:
        result = "Other";
        break;
}

// Switch expression (C# 8.0+) - returns a value
result = value switch
{
    1 => "One",
    _ => "Other"
};

// Key differences:
// - Expressions return values, statements don't
// - Expressions are more concise
// - Expressions support more pattern matching features
```

**Q2: When would you use `foreach` vs `for` loops?**
**Answer:**
- Use `foreach` for:
  - Read-only iteration
  - Any IEnumerable collection
  - Cleaner, more readable code
  - When you don't need the index

- Use `for` for:
  - Modifying collection elements
  - When you need the index
  - Performance-critical code (arrays, lists)
  - Reverse iteration or custom step sizes

- Use `for` with arrays for best performance
- Use `foreach` for complex collections where index access is expensive

**Q3: What's wrong with this loop and how to fix it?**
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++)
{
    actions.Add(() => Console.WriteLine(i));
}
foreach (var action in actions) action(); // Prints 3,3,3
```

**Answer:**
```csharp
// Problem: lambda captures the variable 'i', not its value
// Fix: create a local copy
for (int i = 0; i < 3; i++)
{
    int temp = i; // Local copy for each iteration
    actions.Add(() => Console.WriteLine(temp)); // Prints 0,1,2
}
```

### **Tricky Follow-up Questions**

**Q8: What will this code output and why?**
```csharp
int x = 5;
if (x = 5)  // ❌ Compile error in C#
{
    Console.WriteLine("True");
}
```

**Answer:**
**This won't compile in C#** because assignment returns a value, but C# requires a boolean expression in if statements.

**Correct version**:
```csharp
if (x == 5)  // Comparison, not assignment
{
    Console.WriteLine("True");
}
```

**In C/C++ this would work** and always be true, but C# prevents this common bug.

**Q9: Explain this pattern matching code**
```csharp
if (obj is string { Length: > 5 } s)
{
    Console.WriteLine(s.ToUpper());
}
```

**Answer:**
This uses **property pattern** (C# 8.0+):
- Checks if `obj` is a string
- Checks if the string's Length property is greater than 5
- If both true, assigns to variable `s`
- Then uses `s` in the block

**Equivalent to**:
```csharp
if (obj is string temp && temp.Length > 5)
{
    string s = temp;
    Console.WriteLine(s.ToUpper());
}
```

The property pattern is more concise and readable.

**Q10: What's the problem with this method and how to fix it?**
```csharp
public IEnumerable<int> GetNumbers()
{
    var result = new List<int>();
    for (int i = 0; i < 1000000; i++)
    {
        result.Add(i);
    }
    return result;
}
```

**Answer:**
**Problem**: Creates a huge list in memory before returning

**Solution**: Use yield return for lazy evaluation
```csharp
public IEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 1000000; i++)
    {
        yield return i; // Returns immediately, memory efficient
    }
}
```

**Benefits**:
- Memory efficient (only one number at a time)
- Execution starts immediately
- Can handle infinite sequences


---

## 🎯 Key Takeaways for Interviews

1. **Understand the "why"** behind language features, not just the "how"
2. **Know performance implications** of different control flow structures
3. **Master pattern matching** - it's heavily tested in modern C# interviews
4. **Understand parameter passing** nuances - especially value vs reference semantics
5. **Practice explaining complex concepts** with clear, concise examples

This deep understanding will help you answer not just "what" but "why" and "when" questions during interviews.

<div id="methods-and-functions"></div>

# Methods and functions
Methods are the fundamental building blocks of C# programs that encapsulate behavior and logic. They provide a way to organize code into reusable units, improving maintainability and readability. 

C# offers various ways to define methods with different parameter types, return values, and syntax options to accommodate different programming styles and needs.

## Basic method syntax

```csharp
// Instance method
public int Add(int a, int b)
{
    return a + b;
}

// Static method
public static double CalculateArea(double radius)
{
    return Math.PI * radius * radius;
}

// Void method (no return value)
public void PrintMessage(string message)
{
    Console.WriteLine(message);
}
```

## Expression-bodied members (C# 6.0+)

Expression-bodied members provide a concise syntax for methods, properties, and other members that can be represented by a single expression.

```csharp
// Expression-bodied method (one-line methods)
public int Multiply(int a, int b) => a * b;

// Expression-bodied property
public string FullName => $"{FirstName} {LastName}";
```

## Method parameters

C# provides flexible parameter passing options to handle different programming scenarios.

```csharp
// Optional parameters
public void Greet(string name, string greeting = "Hello")
{
    Console.WriteLine($"{greeting}, {name}!");
}

// Named arguments
Greet(greeting: "Hi", name: "Alice");

// Ref parameters (pass by reference)
public void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}
// Usage: Swap(ref x, ref y);

// Out parameters (for returning multiple values)
public bool TryParse(string input, out int result)
{
    return int.TryParse(input, out result);
}
// Usage: bool success = TryParse("123", out int number);

// In parameters (read-only reference - C# 7.2+)
public double CalculateDistance(in Point p1, in Point p2)
{
    // p1 and p2 cannot be modified
    return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
}

// Params array (variable number of arguments)
public int Sum(params int[] numbers)
{
    int total = 0;
    foreach (int number in numbers)
    {
        total += number;
    }
    return total;
}
// Usage: Sum(1, 2, 3, 4, 5);
```

**Quick mental model**

- Parameters are passed by value by default in C#, even when the value being copied is a reference.
- Use `ref`, `out`, and `in` only when the signature genuinely needs aliasing or by-reference semantics, not just to avoid returns.
- Optional parameters improve call-site readability, but they also create versioning risk in shared libraries.
- `params` is mainly a convenience feature for callers; it should not hide an expensive or ambiguous API shape.

**Behind the covers**

- Passing a reference type parameter by value copies the reference, so caller and callee still point to the same object instance.
- `ref` and `out` pass the storage location itself, which is why assignments in the callee affect the caller's variable.
- Optional argument defaults are substituted at the call site at compile time.
- A `params` call can allocate an array behind the scenes unless the caller already passes one.

## Local functions (C# 7.0+)

Local functions allow you to define methods inside other methods, encapsulating helper logic that is only relevant to the containing method.

```csharp
public int Factorial(int n)
{
    // Local function defined inside another method
    int CalculateFactorial(int number)
    {
        if (number <= 1) return 1;
        return number * CalculateFactorial(number - 1);
    }
    
    return CalculateFactorial(n);
}
```

## Extension methods

Extension methods allow you to add methods to existing types without modifying the original type, making them particularly useful for extending types you don't control.

```csharp
// Must be defined in a non-nested, non-generic static class
public static class StringExtensions
{
    // Extension method for string type
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }
    
    // Extension method with parameters
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}

// Usage
string text = "Hello, World!";
bool isEmpty = text.IsNullOrEmpty(); // false
string truncated = text.Truncate(5); // "Hello"
```

**Quick mental model**

- Extension methods are syntax for making helper APIs feel instance-like without changing the original type.
- They are best when they make a natural fluent API on types you do not own, such as strings, collections, or framework abstractions.
- They should stay unsurprising: if the method has heavy side effects or domain meaning, a normal service or instance member is often clearer.

**Behind the covers**

- An extension method call like `text.Truncate(5)` is compiled as a static method call such as `StringExtensions.Truncate(text, 5)`.
- Resolution is based on the compile-time type in scope plus imported namespaces, not dynamic runtime dispatch.
- Instance methods always take precedence over extension methods with the same applicable signature.

## Lambda expressions

Lambda expressions provide a concise way to create anonymous functions, especially useful for LINQ queries, event handlers, and functional programming patterns.

```csharp
// Func delegate (takes parameters, returns a value)
Func<int, int, int> add = (a, b) => a + b;
int sum = add(2, 3); // 5

// Action delegate (takes parameters, returns void)
Action<string> print = message => Console.WriteLine(message);
print("Hello!"); // Prints "Hello!"

// Predicate delegate (takes parameters, returns bool)
Predicate<int> isEven = number => number % 2 == 0;
bool result = isEven(4); // true

// Multi-line lambda
Func<int, int> factorial = n =>
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
};
```

**Quick mental model**

- A lambda is just an anonymous function value that can be stored, passed around, or executed later.
- Lambdas are ideal when behavior is short-lived, local, and easier to read inline than as a named method.
- Prefer a local function when the logic is meaningful enough to deserve a name, recursion, or a clearer debugging surface.

**Behind the covers**

- A lambda can be converted either to a delegate or to an expression tree, depending on the target type.
- When a lambda captures outer variables, the compiler may synthesize a closure object to store that state.
- Captured variables are shared variables, not frozen snapshots, which is why loop-capture bugs happen.

### Default parameters in lambdas (C# 12)

Lambdas can now have default values for parameters:

```csharp
Func<int, int, int> add = (x, y = 10) => x + y;
int result = add(5); // 15
```

## Method overloading

Method overloading allows multiple methods with the same name but different parameter lists, providing flexibility in how a method can be called.

```csharp
// Method overloading (same name, different parameters)
public void Display(int value)
{
    Console.WriteLine($"Integer: {value}");
}

public void Display(string value)
{
    Console.WriteLine($"String: {value}");
}

public void Display(int value, string format)
{
    Console.WriteLine($"Formatted: {value.ToString(format)}");
}
```


## Grouped Methods Deep-Dive Copies

These copies are grouped here so overloading, parameter modifiers, `params`, and local-function notes stay near the main methods section.

### Methods Deep-Dive Copy 1
## 🔍 Methods and Parameters - Deep Understanding

### **Method Overloading Resolution**

**Complex Overloading Scenarios:**
```csharp
public class OverloadExample
{
    public void Process(object obj) => Console.WriteLine("object");
    public void Process(string str) => Console.WriteLine("string");
    public void Process(int num) => Console.WriteLine("int");
    
    public void Test()
    {
        Process(null);        // Calls Process(string) - most specific
        Process(123);         // Calls Process(int) - exact match
        Process(123L);        // Calls Process(object) - no exact match
    }
}
```

**Generic Method Overloading:**
```csharp
public class GenericOverload
{
    public void Process<T>(T item) => Console.WriteLine($"Generic: {item}");
    public void Process(string item) => Console.WriteLine($"String: {item}");
    
    public void Test()
    {
        Process("hello");     // Calls Process(string) - more specific
        Process(123);         // Calls Process<int>(123) - generic
        Process<int>(123);    // Explicit generic call
    }
}
```

### **Parameter Modifiers Deep Dive**

**ref vs out vs in:**
```csharp
public class ParameterModifiers
{
    // ref - two-way communication, variable must be initialized
    public void ModifyWithRef(ref int value)
    {
        value *= 2; // Can read and modify
    }
    
    // out - output only, variable doesn't need initialization
    public void GetValues(out int result1, out string result2)
    {
        result1 = 42;        // Must assign before return
        result2 = "Hello";   // Must assign before return
    }
    
    // in - read-only reference, prevents copying large structs
    public double CalculateDistance(in Point p1, in Point p2)
    {
        // p1.X = 10; // ❌ Compile error - read-only reference
        return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }
}
```

**Advanced ref Usage:**
```csharp
// ref returns and ref locals
public class RefAdvanced
{
    private int[] numbers = { 1, 2, 3, 4, 5 };
    
    // ref return
    public ref int FindNumber(int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
                return ref numbers[i]; // Return reference, not copy
        }
        throw new ArgumentException("Not found");
    }
    
    public void Test()
    {
        ref int found = ref FindNumber(3); // ref local
        found = 100; // Modifies the original array element
        Console.WriteLine(numbers[2]); // Prints 100
    }
}
```

### **params Keyword Internals**

**Performance Implications:**
```csharp
public class ParamsExample
{
    // Compiler creates array internally
    public int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
            sum += num;
        return sum;
    }
    
    // Better performance for common cases
    public int SumOptimized(int num1, int num2)
    {
        return num1 + num2;
    }
    
    public int SumOptimized(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }
    
    public int SumOptimized(params int[] numbers)
    {
        // Fallback for larger numbers
        return numbers.Sum();
    }
}
```

### **Local Functions vs Lambda Expressions**

**When to Use Which:**
```csharp
public class LocalVsLambda
{
    public void ProcessData()
    {
        // Local function - better for recursion, iterator methods
        int CalculateFactorial(int n)
        {
            if (n <= 1) return 1;
            return n * CalculateFactorial(n - 1);
        }
        
        // Lambda - better for short, one-off operations
        Func<int, int> square = x => x * x;
        
        var result = CalculateFactorial(5);
        Console.WriteLine($"Factorial: {result}, Square: {square(4)}");
    }
    
    // Local functions can be iterator methods
    public IEnumerable<int> GetFibonacciSequence()
    {
        return GenerateSequence();
        
        IEnumerable<int> GenerateSequence() // Iterator local function
        {
            int a = 0, b = 1;
            while (true)
            {
                yield return a;
                (a, b) = (b, a + b);
            }
        }
    }
}
```

---

### Methods Deep-Dive Copy 2
## 🔍 Methods and Parameters - Deep Understanding

### **Method Overloading Resolution**

**Complex Overloading Scenarios:**
```csharp
public class OverloadExample
{
    public void Process(object obj) => Console.WriteLine("object");
    public void Process(string str) => Console.WriteLine("string");
    public void Process(int num) => Console.WriteLine("int");
    
    public void Test()
    {
        Process(null);        // Calls Process(string) - most specific
        Process(123);         // Calls Process(int) - exact match
        Process(123L);        // Calls Process(object) - no exact match
    }
}
```

**Generic Method Overloading:**
```csharp
public class GenericOverload
{
    public void Process<T>(T item) => Console.WriteLine($"Generic: {item}");
    public void Process(string item) => Console.WriteLine($"String: {item}");
    
    public void Test()
    {
        Process("hello");     // Calls Process(string) - more specific
        Process(123);         // Calls Process<int>(123) - generic
        Process<int>(123);    // Explicit generic call
    }
}
```

### **Parameter Modifiers Deep Dive**

**ref vs out vs in:**
```csharp
public class ParameterModifiers
{
    // ref - two-way communication, variable must be initialized
    public void ModifyWithRef(ref int value)
    {
        value *= 2; // Can read and modify
    }
    
    // out - output only, variable doesn't need initialization
    public void GetValues(out int result1, out string result2)
    {
        result1 = 42;        // Must assign before return
        result2 = "Hello";   // Must assign before return
    }
    
    // in - read-only reference, prevents copying large structs
    public double CalculateDistance(in Point p1, in Point p2)
    {
        // p1.X = 10; // ❌ Compile error - read-only reference
        return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }
}
```

**Advanced ref Usage:**
```csharp
// ref returns and ref locals
public class RefAdvanced
{
    private int[] numbers = { 1, 2, 3, 4, 5 };
    
    // ref return
    public ref int FindNumber(int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
                return ref numbers[i]; // Return reference, not copy
        }
        throw new ArgumentException("Not found");
    }
    
    public void Test()
    {
        ref int found = ref FindNumber(3); // ref local
        found = 100; // Modifies the original array element
        Console.WriteLine(numbers[2]); // Prints 100
    }
}
```

### **params Keyword Internals**

**Performance Implications:**
```csharp
public class ParamsExample
{
    // Compiler creates array internally
    public int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
            sum += num;
        return sum;
    }
    
    // Better performance for common cases
    public int SumOptimized(int num1, int num2)
    {
        return num1 + num2;
    }
    
    public int SumOptimized(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }
    
    public int SumOptimized(params int[] numbers)
    {
        // Fallback for larger numbers
        return numbers.Sum();
    }
}
```

### **Local Functions vs Lambda Expressions**

**When to Use Which:**
```csharp
public class LocalVsLambda
{
    public void ProcessData()
    {
        // Local function - better for recursion, iterator methods
        int CalculateFactorial(int n)
        {
            if (n <= 1) return 1;
            return n * CalculateFactorial(n - 1);
        }
        
        // Lambda - better for short, one-off operations
        Func<int, int> square = x => x * x;
        
        var result = CalculateFactorial(5);
        Console.WriteLine($"Factorial: {result}, Square: {square(4)}");
    }
    
    // Local functions can be iterator methods
    public IEnumerable<int> GetFibonacciSequence()
    {
        return GenerateSequence();
        
        IEnumerable<int> GenerateSequence() // Iterator local function
        {
            int a = 0, b = 1;
            while (true)
            {
                yield return a;
                (a, b) = (b, a + b);
            }
        }
    }
}
```

### Methods Deep-Dive Copy 3
## 🔍 Methods and Parameters - Deep Understanding

### **Method Overloading Resolution**

**Complex Overloading Scenarios:**
```csharp
public class OverloadExample
{
    public void Process(object obj) => Console.WriteLine("object");
    public void Process(string str) => Console.WriteLine("string");
    public void Process(int num) => Console.WriteLine("int");
    
    public void Test()
    {
        Process(null);        // Calls Process(string) - most specific
        Process(123);         // Calls Process(int) - exact match
        Process(123L);        // Calls Process(object) - no exact match
    }
}
```

**Generic Method Overloading:**
```csharp
public class GenericOverload
{
    public void Process<T>(T item) => Console.WriteLine($"Generic: {item}");
    public void Process(string item) => Console.WriteLine($"String: {item}");
    
    public void Test()
    {
        Process("hello");     // Calls Process(string) - more specific
        Process(123);         // Calls Process<int>(123) - generic
        Process<int>(123);    // Explicit generic call
    }
}
```

### **Parameter Modifiers Deep Dive**

**ref vs out vs in:**
```csharp
public class ParameterModifiers
{
    // ref - two-way communication, variable must be initialized
    public void ModifyWithRef(ref int value)
    {
        value *= 2; // Can read and modify
    }
    
    // out - output only, variable doesn't need initialization
    public void GetValues(out int result1, out string result2)
    {
        result1 = 42;        // Must assign before return
        result2 = "Hello";   // Must assign before return
    }
    
    // in - read-only reference, prevents copying large structs
    public double CalculateDistance(in Point p1, in Point p2)
    {
        // p1.X = 10; // ❌ Compile error - read-only reference
        return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }
}
```

**Advanced ref Usage:**
```csharp
// ref returns and ref locals
public class RefAdvanced
{
    private int[] numbers = { 1, 2, 3, 4, 5 };
    
    // ref return
    public ref int FindNumber(int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
                return ref numbers[i]; // Return reference, not copy
        }
        throw new ArgumentException("Not found");
    }
    
    public void Test()
    {
        ref int found = ref FindNumber(3); // ref local
        found = 100; // Modifies the original array element
        Console.WriteLine(numbers[2]); // Prints 100
    }
}
```

### **params Keyword Internals**

**Performance Implications:**
```csharp
public class ParamsExample
{
    // Compiler creates array internally
    public int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
            sum += num;
        return sum;
    }
    
    // Better performance for common cases
    public int SumOptimized(int num1, int num2)
    {
        return num1 + num2;
    }
    
    public int SumOptimized(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }
    
    public int SumOptimized(params int[] numbers)
    {
        // Fallback for larger numbers
        return numbers.Sum();
    }
}
```

### **Local Functions vs Lambda Expressions**

**When to Use Which:**
```csharp
public class LocalVsLambda
{
    public void ProcessData()
    {
        // Local function - better for recursion, iterator methods
        int CalculateFactorial(int n)
        {
            if (n <= 1) return 1;
            return n * CalculateFactorial(n - 1);
        }
        
        // Lambda - better for short, one-off operations
        Func<int, int> square = x => x * x;
        
        var result = CalculateFactorial(5);
        Console.WriteLine($"Factorial: {result}, Square: {square(4)}");
    }
    
    // Local functions can be iterator methods
    public IEnumerable<int> GetFibonacciSequence()
    {
        return GenerateSequence();
        
        IEnumerable<int> GenerateSequence() // Iterator local function
        {
            int a = 0, b = 1;
            while (true)
            {
                yield return a;
                (a, b) = (b, a + b);
            }
        }
    }
}
```

---

## Grouped Methods Interview Copies

These copies are kept together so the overlap around `ref`, `out`, `in`, overload resolution, `params`, and local functions is easy to compare.

### Methods Interview Copy 1
### **Methods & Parameters Questions**

**Q4: Explain the difference between `ref`, `out`, and `in` parameters**
**Answer:**
- `ref`: 
  - Two-way communication
  - Variable must be initialized before call
  - Method can read and modify

- `out`:
  - Output-only parameter  
  - Variable doesn't need initialization
  - Method must assign before returning
  - Caller doesn't care about input value

- `in`:
  - Read-only reference
  - Variable must be initialized
  - Prevents copying large structs
  - Method cannot modify

**When to use:**
- `ref`: When you need to modify and see the change
- `out`: When you need multiple return values
- `in`: With large structs for performance

**Q5: How does method overloading resolution work?**
```csharp
public void Process(object obj) { }
public void Process(string str) { }
public void Process<T>(T item) { }

Process(null);    // Which one gets called?
```

**Answer:**
The overload resolution follows this priority:
1. **Exact match** - most specific type
2. **Generic type inference** 
3. **Implicit conversions**
4. **params array**

For `Process(null)`:
- `Process(string)` is chosen because:
  - `string` is more specific than `object`
  - `string` is more specific than generic `T`
  - `null` can be assigned to `string` but is more specific than object

**Q6: What are the performance implications of `params`?**
**Answer:**
- **Advantage**: Flexible method calls
- **Disadvantage**: Array allocation overhead
- **Optimization**: Provide overloads for common cases:

```csharp
public void Log(string message) { }                    // Most common
public void Log(string format, object arg1) { }        // Common  
public void Log(string format, object arg1, object arg2) { }
public void Log(string format, params object[] args) { } // Fallback
```

**Q7: When should you use local functions vs lambda expressions?**
**Answer:**
**Use local functions when:**
- You need recursion
- Creating iterator methods (yield return)
- Better performance (no delegate allocation)
- The function is called multiple times

**Use lambda expressions when:**
- Short, one-off operations
- Need to pass as a delegate parameter
- Functional programming style
- Event handlers

**Performance**: Local functions are generally faster as they don't allocate delegate objects.


### Methods Interview Copy 2
**Q4: Explain the difference between `ref`, `out`, and `in` parameters**

**Answer:**
- `ref`:
  - Two-way communication
  - Variable must be initialized before call
  - Method can read and modify

- `out`:
  - Output-only parameter
  - Variable doesn't need initialization
  - Method must assign before returning
  - Caller doesn't care about input value

- `in`:
  - Read-only reference
  - Variable must be initialized
  - Prevents copying large structs
  - Method cannot modify

**When to use:**
- `ref`: When you need to modify and see the change
- `out`: When you need multiple return values
- `in`: With large structs for performance

**Q5: How does method overloading resolution work?**
```csharp
public void Process(object obj) { }
public void Process(string str) { }
public void Process<T>(T item) { }

Process(null);    // Which one gets called?
```

**Answer:**
The overload resolution follows this priority:
1. **Exact match** - most specific type
2. **Generic type inference**
3. **Implicit conversions**
4. **params array**

For `Process(null)`:
- `Process(string)` is chosen because:
  - `string` is more specific than `object`
  - `string` is more specific than generic `T`
  - `null` can be assigned to `string` but is more specific than object

**Q6: What are the performance implications of `params`?**

**Answer:**
- **Advantage**: Flexible method calls
- **Disadvantage**: Array allocation overhead
- **Optimization**: Provide overloads for common cases:

```csharp
public void Log(string message) { }                    // Most common
public void Log(string format, object arg1) { }        // Common
public void Log(string format, object arg1, object arg2) { }
public void Log(string format, params object[] args) { } // Fallback
```

**Q7: When should you use local functions vs lambda expressions?**

**Answer:**
**Use local functions when:**
- You need recursion
- Creating iterator methods (`yield return`)
- Better performance (no delegate allocation)
- The function is called multiple times

**Use lambda expressions when:**
- Short, one-off operations
- Need to pass as a delegate parameter
- Functional programming style
- Event handlers

**Performance:** Local functions are generally faster as they don't allocate delegate objects.


**Additional resources:**

- [Methods (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/methods)
- [Expression-bodied members (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)
- [Method parameters (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters)
- [Extension methods (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
- [Lambda expressions (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

### Interview Prep

**Senior Perspective (The "Why")**

- Method design is API design in miniature.
- A strong method signature communicates intent, side effects, ownership of data, and error behavior clearly.
- Senior candidates usually talk about cohesion, misuse resistance, and versioning impact, not just syntax.
- Choosing between a normal method, local function, lambda, or extension method should follow readability and API boundary needs.
- `Good opening answer:` "A method signature is a contract, so I optimize for clear intent, safe mutation rules, and call-site readability first."
- `Then add:` explain why choices like `ref`/`out`/`in`, optional parameters, local functions, lambdas, and extension methods affect misuse resistance and versioning.

**Interview Gotchas & Confusion Points**

- Optional parameter defaults are baked into the caller at compile time, which matters for shared-library versioning.
- Extension methods are resolved from the compile-time type, not runtime type.
- Overload resolution gets tricky with `null`, default values, numeric conversions, and named arguments.
- Many candidates misuse `ref`, `out`, and `in` because they know the keywords but not the design trade-offs.

**Corner Cases**

- Lambdas capture variables, not snapshots of values, which causes classic closure bugs.
- `params` can accept an expanded list, an array, or even `null`.
- Local functions can be recursive and sometimes avoid delegate allocations that a lambda would create.
- An instance method always wins over an extension method with the same signature.

**Behind the Scenes / Internal Logic**

- Optional parameter default values are copied into the calling code at compile time, which is why changing them later can be a versioning trap.
- Extension methods are just static methods with special call syntax; there is no true runtime instance-member dispatch involved.
- A lambda that captures locals may cause the compiler to generate a hidden closure object to hold that captured state.
- Local functions can sometimes be compiled more efficiently than lambdas because they do not always need a delegate allocation.

**Must Remember Facts**

- `ref` passes by reference and requires prior assignment.
- `out` requires the callee to assign a value.
- `in` passes by readonly reference.
- Prefer the clearest signature over clever parameter tricks.

**Question Bank (Common Questions + What to Say)**

- `Q: What is the difference between ref, out, and in?`<br>
  `What to say:` `ref` passes an existing variable by reference, `out` is for callee-assigned output, and `in` passes by readonly reference. The real distinction is ownership and mutation expectations.<br>
  `Focus on:` who assigns and whether mutation is allowed.
- `Q: Why can optional parameters become a versioning problem?`<br>
  `What to say:` Because the default value is compiled into the caller. If a library changes the default later, already-compiled callers may still use the old value until they are recompiled.<br>
  `Focus on:` call-site substitution at compile time.
- `Q: How are extension methods resolved?`<br>
  `What to say:` They are resolved from the compile-time type and are really static methods with special syntax. They do not override instance methods or participate in runtime polymorphism.<br>
  `Focus on:` static resolution, not dynamic dispatch.
- `Q: What is the difference between a lambda and a local function?`<br>
  `What to say:` A lambda is an anonymous function value, often used where a delegate is needed. A local function is a named helper inside a method and can be clearer, recursive, and sometimes more efficient.<br>
  `Focus on:` delegate value vs local named helper.
- `Q: What bugs come from closure capture in lambdas?`<br>
  `What to say:` The common bug is assuming the lambda captured the value at that moment, when it actually captured the variable itself. Later changes to that variable can affect all lambdas that closed over it.<br>
  `Focus on:` variable capture, not value snapshot.

Here is the professional breakdown for your notes.

---

### 1. Method Parameters: `ref`, `in`, and `out`
These modifiers control how arguments are passed to methods (Pass-by-Reference).

| Modifier  | Direction | Requirement                             | Senior Use Case                                 |
| :-------- | :-------- | :-------------------------------------- | :---------------------------------------------- |
| **`ref`** | In/Out    | Must be initialized before calling.     | Mutating an existing value type in place.       |
| **`out`** | Out Only  | Must be assigned before method returns. | Returning multiple values (e.g., `TryParse`).   |
| **`in`**  | In Only   | Read-only; cannot be modified.          | Passing large `structs` without copying memory. |

> **The "Senior" Nuance:** Use `in` for performance with large custom `structs`. It prevents the CPU from copying the entire struct onto the stack, passing a pointer instead. However, beware of "hidden copies" if the struct is not marked `readonly`.

---

### 2. Basic vs. Expression-Bodied Members
* **Basic Syntax:** Best for complex logic, multiple lines, and local variables.
* **Expression-Bodied (`=>`):** Best for simple getters, single-line calculations, or mapping.
    * *Senior Tip:* Overusing `=>` for complex logic reduces readability. Use it to keep "boilerplate" code (like DTO mapping) concise.

---

### 3. Local Functions vs. Lambda Expressions
Both allow nesting logic inside a method, but they differ significantly under the hood.

* **Local Functions:** * **Performance:** They are faster. The compiler can often avoid allocating a "closure" object on the heap if the function doesn't capture variables.
    * **Capability:** They support `ref`, `out`, and generics.
    * **Use Case:** Recursive logic or helper logic that only exists within one method.
* **Lambda Expressions (`delegate`):**
    * **Nature:** They are objects (delegates). 
    * **Use Case:** Passing logic as an argument (LINQ, Event Handlers). 
    * **Memory:** Capturing local variables in a lambda usually forces a heap allocation (the "Closure").



---

### 4. Extension Methods
Static methods that "act" like instance methods.
* **Requirement:** Must be in a `static class` and use the `this` keyword on the first parameter.
* **Senior Strategy:** Use these to keep your Domain Models "clean" (POCOs) while adding utility logic elsewhere. 
    * *Warning:* Don't overuse them; they can make code discovery difficult for new team members.

---

### 5. Method Overloading
Defining multiple methods with the same name but different signatures.
* **The Trap:** Overloading with `optional parameters` can lead to ambiguity.
* **Senior Best Practice:** If you find yourself overloading more than 3-4 times, consider the **Builder Pattern** or passing a "Parameter Object" (Options pattern) to keep the API clean.

---

### 📝 Final Study Note for Markdown

### Methods & Parameters Summary
* **ref/out/in:** Use to avoid copying large structs or to return multiple values. Use `in` for read-only performance optimization.
* **Local Functions:** Prefer over Lambdas for internal method logic because they are more performant and support `ref/out`.
* **Extension Methods:** Great for "fluent" APIs and keeping models thin. Always place in a specific `.Extensions` namespace.
* **Lambdas:** Use primarily for LINQ or when a delegate/Action/Func is required as a parameter.

---

### Methods Interview Copy 3
### **Methods & Parameters Questions**

**Q4: Explain the difference between `ref`, `out`, and `in` parameters**
**Answer:**
- `ref`: 
  - Two-way communication
  - Variable must be initialized before call
  - Method can read and modify

- `out`:
  - Output-only parameter  
  - Variable doesn't need initialization
  - Method must assign before returning
  - Caller doesn't care about input value

- `in`:
  - Read-only reference
  - Variable must be initialized
  - Prevents copying large structs
  - Method cannot modify

**When to use:**
- `ref`: When you need to modify and see the change
- `out`: When you need multiple return values
- `in`: With large structs for performance

**Q5: How does method overloading resolution work?**
```csharp
public void Process(object obj) { }
public void Process(string str) { }
public void Process<T>(T item) { }

Process(null);    // Which one gets called?
```

**Answer:**
The overload resolution follows this priority:
1. **Exact match** - most specific type
2. **Generic type inference** 
3. **Implicit conversions**
4. **params array**

For `Process(null)`:
- `Process(string)` is chosen because:
  - `string` is more specific than `object`
  - `string` is more specific than generic `T`
  - `null` can be assigned to `string` but is more specific than object

**Q6: What are the performance implications of `params`?**
**Answer:**
- **Advantage**: Flexible method calls
- **Disadvantage**: Array allocation overhead
- **Optimization**: Provide overloads for common cases:

```csharp
public void Log(string message) { }                    // Most common
public void Log(string format, object arg1) { }        // Common  
public void Log(string format, object arg1, object arg2) { }
public void Log(string format, params object[] args) { } // Fallback
```

**Q7: When should you use local functions vs lambda expressions?**
**Answer:**
**Use local functions when:**
- You need recursion
- Creating iterator methods (yield return)
- Better performance (no delegate allocation)
- The function is called multiple times

**Use lambda expressions when:**
- Short, one-off operations
- Need to pass as a delegate parameter
- Functional programming style
- Event handlers

**Performance**: Local functions are generally faster as they don't allocate delegate objects.

