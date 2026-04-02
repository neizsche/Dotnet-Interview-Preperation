# C# Programming Cheat Sheet (2025 Edition)

## Table of contents

- [Strings](#strings)
- [Basic types and literals](#basic-types-and-literals)
- [Data types](#data-types)
  - [Classes](#classes)
  - [Structs](#structs)
  - [Records](#records-c-90)
  - [Record structs](#record-structs-c-100)
  - [Interfaces](#interfaces)
  - [Enums](#enums)
  - [Tuples](#tuples)
  - [Nullable types](#nullable-types)
- [Statements](#statements)
  - [Control flow](#control-flow)
  - [Loops](#loops)
  - [Lock statement](#lock-statement)
  - [Using statement](#using-statement)
  - [Unsafe code](#unsafe-code)
  - [Yield statement](#yield-statement)
- [Methods and functions](#methods-and-functions)
  - [Basic method syntax](#basic-method-syntax)
  - [Expression-bodied members](#expression-bodied-members-c-60)
  - [Method parameters](#method-parameters)
  - [Local functions](#local-functions-c-70)
  - [Extension methods](#extension-methods)
  - [Lambda expressions](#lambda-expressions)
  - [Method overloading](#method-overloading)
- [Delegates and events](#delegates-and-events)
- [Generics](#generics)
  - [Generic classes](#generic-classes) 
  - [Generic methods](#generic-methods)
  - [Constraints](#constraints)  
- [Classes](#classes-and-inheritance)
  - [Constructors and initialization](#constructors-and-initialization)
  - [Primary constructors](#primary-constructors-c-12)
  - [Inheritance](#inheritance)
  - [Abstract classes](#abstract-classes)
  - [Sealed classes and members](#sealed-classes-and-members)
  - [Polymorphism](#polymorphism)
- [Collections](#collections)
  - [Collection expressions](#collection-expressions-c-12)
  - [Arrays](#arrays)
  - [Lists](#lists)
  - [Dictionary](#dictionary)
  - [HashSet](#hashset)
  - [Queue and Stack](#queue-and-stack)
  - [LINQ](#linq-language-integrated-query)
- [Pattern matching](#pattern-matching)
  - [Type patterns](#type-patterns)
  - [Property patterns](#property-patterns)
  - [Tuple patterns](#tuple-patterns)
  - [Logical patterns](#logical-patterns)
  - [List patterns](#list-patterns-c-110)
  - [Discard patterns](#discard-pattern)
- [Exceptions](#exceptions)
  - [Try-Catch-Finally](#try-catch-finally)
  - [Throwing exceptions](#throwing-exceptions)
  - [Custom exceptions](#custom-exceptions)
- [Asynchronous programming](#asynchronous-programming)
  - [Async and await basics](#async-and-await-basics)
  - [Task-based asynchronous pattern](#task-based-asynchronous-pattern)
  - [Exception handling in async code](#exception-handling-in-async-code)
  - [Cancellation in async operations](#cancellation-in-async-operations)
  - [ValueTask and async streams](#valuetask-and-async-streams-c-80)
- [Code organization](#code-organization)
  - [Namespaces](#namespaces)
  - [Using directives](#using-directives)
  - [File-scoped types](#file-scoped-types-c-11)
  - [Partial classes](#partial-classes)
  - [Access modifiers](#access-modifiers)
  - [Properties and indexers](#properties-and-indexers)

# Strings

Strings in C# are immutable sequences of Unicode characters represented by the `string` type (an alias for `System.String`). C# offers a rich set of string manipulation features, from basic concatenation to advanced interpolation and raw string literals. The language has evolved significantly to make string handling more intuitive and efficient.

```csharp
// Basic string creation
string greeting = "Hello";
string name = "World";
string message = greeting + " " + name; // "Hello World"

// String interpolation (C# 6.0+)
string interpolated = $"{greeting} {name}!"; // "Hello World!"

// Verbatim strings (preserves formatting and ignores escape sequences except "")
string path = @"C:\Users\UserName\Documents";
string multiline = @"This is a
multi-line string
that preserves formatting";

// Verbatim string interpolation
string verbatimInterpolated = $@"User {name}
Path: {path}";

// Raw string literals (C# 11+) - no escape sequences, preserves formatting
string json = """
{
    "name": "John Doe",
    "age": 30,
    "isActive": true
}
""";

// Raw string interpolation (C# 11+)
string name = "Jane";
string rawInterpolated = $"""
{
    "name": "{{name}}",
    "created": "{{DateTime.Now}}"
}
""";

// Common string methods
string text = "Hello, World!";
bool contains = text.Contains("World"); // true
string upper = text.ToUpper(); // "HELLO, WORLD!"
string lower = text.ToLower(); // "hello, world!"
string replaced = text.Replace("Hello", "Hi"); // "Hi, World!"
string trimmed = "  text  ".Trim(); // "text"
string[] split = text.Split(','); // ["Hello", " World!"]
int length = text.Length; // 13

// String comparison
bool equals = string.Equals("abc", "ABC", StringComparison.OrdinalIgnoreCase); // true
int comparison = string.Compare("abc", "ABC", StringComparison.Ordinal); // not equal

 string.Equals (The Gatekeeper)
//     This method is used for equality checking. It returns a boolean value (true or false).
//     Goal: To determine if two strings are identical based on your criteria (like ignoring case).
//     Best Use Case: Login systems (checking a username), conditional logic (if statements), or validating input.

 string.Compare (The Librarian)
//     This method is used for sorting and ordering. It returns an integer that tells you the relationship between the two strings.
//     Goal: To determine the relative position of strings in an alphabetized list.
//     The Return Values:
//     0: The strings are equal.
//     Less than 0 (negative): The first string comes before the second string (e.g., "apple" vs "banana").
//     Greater than 0 (positive): The first string comes after the second string.
//     Best Use Case: Sorting a list of names, creating a search index, or building a leaderboard.
```

For better performance with repeated string concatenation (as String is immutable type), use `StringBuilder`:

```csharp
using System.Text;

StringBuilder sb = new StringBuilder();
for (int i = 0; i < 100; i++)
{
    sb.Append($"Item {i}, ");
}
string result = sb.ToString();
```

## 1. Core Architecture
* **Immutability:** Strings cannot be changed once created. Any "modification" creates a new object on the managed heap.
* **Memory Layout (64-bit):** * Sync Block Index (8 bytes)
    * Type Handle (8 bytes)
    * Length (4 bytes)
    * Char array + Null Terminator (2 bytes per char)
* **UTF-16 Encoding:** Every `char` is 2 bytes. Loading a 1GB UTF-8 file results in a ~2GB `System.String` object.

---

## 2. Equality vs. Comparison
| Feature           | `string.Equals`                | `string.Compare`                      |
| :---------------- | :----------------------------- | :------------------------------------ |
| **Return**        | `bool`                         | `int` (-1, 0, 1)                      |
| **Purpose**       | Identity/Validation            | Sorting/Ordering                      |
| **Best Practice** | Use `StringComparison.Ordinal` | Use for `IComparable` implementations |

---

## 3. High-Performance Patterns
### `ReadOnlySpan<char>`
* **What:** A `ref struct` representing a contiguous region of memory.
* **Why:** Allows slicing strings (e.g., `s.AsSpan(0, 5)`) without allocating a new string object on the heap.
* **Benefit:** Zero Garbage Collection (GC) pressure.

### `string.Create<TState>`
* **What:** Allocates the string first, then provides a `Span` to write data into it.
* **Why:** Avoids the overhead and intermediate copies of `StringBuilder` when the final length is known.

### `Rune` vs `char`
* A `char` is 16-bit and cannot represent all Unicode characters (e.g., Emojis).
* `Rune` represents a **Unicode Scalar Value**. Always use `Rune` for linguistically correct text processing.

---

## 4. The "Intern Pool" & LOH
* **Interning:** `string.Intern()` stores a string in a process-wide table. 
    * **Trap:** Interning dynamic data (like GUIDs) causes a **permanent memory leak** because the pool is not GC'd.
* **Large Object Heap (LOH):** Strings > 85,000 bytes go to the LOH. 
    * **Risk:** The LOH is not compacted by default, leading to **Memory Fragmentation**.

---

## 5. Interview "Gotchas" (Senior Level)

### 🚩 The `ToUpper()` Comparison Trap
* **Bad:** `if (a.ToUpper() == b.ToUpper())` — Allocates two temporary strings.
* **Good:** `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` — Allocation-free comparison.

### 🚩 `const` vs `static readonly`
* `const` values are baked into the **calling** assembly at compile-time. If the library changes the constant, the caller must be recompiled.
* `static readonly` is resolved at runtime.

### 🚩 `GetHashCode()` Persistence
* **Never** store `string.GetHashCode()` in a database. It is non-deterministic across .NET versions and app domains to prevent **Hash Flooding DoS attacks**.

### 🚩 The "Turkish I" Problem
* Linguistic comparisons (e.g., `CurrentCulture`) behave differently based on the OS locale (e.g., "i" vs "İ").
* **Always** use `StringComparison.Ordinal` for system-level strings (paths, keys, headers).

---

## 6. Performance Ranking
1.  **`ReadOnlySpan<char>` / `stackalloc`** (Fastest - No Heap)
2.  **`string.Create`** (Fastest Heap Allocation)
3.  **`string.Concat` / Interpolation** (Optimized for small counts)
4.  **`StringBuilder`** (Best for loops with unknown iterations)
5.  **`string.Format`** (Slowest - parsing + boxing overhead)

---

**Quick mental model**

- A `string` is a reference type, but it behaves value-like in day-to-day code because it is immutable and equality is based on content.
- For a small number of concatenations, `+` and interpolation are usually fine and often the clearest option.
- For repeated appends in a loop or pipeline, `StringBuilder` is usually the better choice because it reduces repeated intermediate allocations.
- Always decide whether your text is machine-readable text or human-readable text before choosing a comparison strategy.

**Behind the covers**

- C# strings store UTF-16 code units, so `Length` is not the same thing as user-perceived characters or grapheme clusters.
- The runtime can intern identical string literals, which means multiple literals may point at the same underlying instance.
- String interpolation is often lowered into concatenation-like operations or interpolated string handlers depending on context.
- `StringBuilder` mutates an expandable internal buffer, but `ToString()` still creates the final immutable string object.

### Interview Prep

**Senior Perspective (The "Why")**

- String handling is mostly a correctness and maintainability topic, not just a syntax topic.
- Because strings are immutable, every transformation creates a new value, so allocation behavior matters in hot paths.
- Comparison strategy is a domain decision: culture-aware comparison is for user-facing text, while ordinal comparison is usually right for identifiers, keys, and protocol values.
- `Good opening answer:` "Strings are immutable reference types, so the real interview themes are comparison correctness, Unicode behavior, and allocation patterns."
- `Then add:` separate machine-facing comparisons from user-facing comparisons before talking about `StringBuilder` or interpolation performance.

**Interview Gotchas & Confusion Points**

- Saying "use `==` for strings" is incomplete unless you explain comparison rules and `StringComparison`.
- `ToUpper()` and `ToLower()` can be culture-sensitive, so they are not always safe normalization strategies.
- Raw strings, interpolated strings, and verbatim strings improve readability, but they do not automatically improve performance.
- Many candidates forget that repeated concatenation inside loops is a common allocation smell.

**Corner Cases**

- `null`, `""`, and whitespace-only strings are different states with different business meaning.
- `string.Length` counts UTF-16 code units, not user-perceived characters.
- Unicode, emoji, combining characters, and culture-sensitive casing can make apparently simple string logic behave unexpectedly.
- Mixing raw, verbatim, and interpolated string syntaxes without care can create escaping bugs.

**Behind the Scenes / Internal Logic**

- String literals can be interned by the runtime, which means identical literals may share storage.
- `string` equality compares character content, not object identity, which is why two separately created but identical strings can compare equal.
- `StringBuilder` works by mutating an internal buffer rather than creating a brand new string for every append.

**Must Remember Facts**

- `string` is an alias for `System.String`.
- Strings are immutable reference types.
- `StringComparison.Ordinal` / `OrdinalIgnoreCase` is usually the safe interview answer for machine-readable values.
- Use `StringBuilder` when many concatenations happen in a loop or iterative process.

**Question Bank (Common Questions + What to Say)**

- `Q: Why are strings immutable in C#, and what does that imply for performance?`<br>
  `What to say:` Immutability makes strings safe to share and reason about, but every modification produces a new value. That is great for correctness and thread safety, but repeated transformations can create allocation pressure.<br>
  `Focus on:` safety plus allocation trade-off.
- `Q: When do you use StringBuilder instead of + or interpolation?`<br>
  `What to say:` Use normal concatenation or interpolation for a few values because it is readable. Use `StringBuilder` when you are building a string incrementally in loops or many-step operations where repeated allocations would become wasteful.<br>
  `Focus on:` repeated appends and hot paths.
- `Q: What is the difference between ordinal and culture-aware string comparison?`<br>
  `What to say:` Ordinal comparison compares code units and is usually right for machine-readable values like keys, tokens, and identifiers. Culture-aware comparison follows language rules and is appropriate for user-facing text and sorting.<br>
  `Focus on:` machine text vs human text.
- `Q: Why can ToLower() or ToUpper() introduce bugs?`<br>
  `What to say:` Because casing can be culture-sensitive, so converting and then comparing can behave differently across locales. It is usually safer to compare with an explicit `StringComparison` instead of normalizing with casing first.<br>
  `Focus on:` culture-sensitive behavior.
- `Q: What is the difference between IsNullOrEmpty and IsNullOrWhiteSpace?`<br>
  `What to say:` `IsNullOrEmpty` checks only `null` and `""`, while `IsNullOrWhiteSpace` also treats spaces, tabs, and similar characters as empty for validation purposes.<br>
  `Focus on:` business meaning of blank input.

**Additional resources:**

- [String class (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/api/system.string)
- [String interpolation (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)
- [Raw String literals (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/raw-string-literal)
- [String performance best practices](https://learn.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings)

<div id="basic-types-and-literals"></div>

# Basic types and literals

C# is a strongly-typed language with a comprehensive type system that forms the foundation of all C# programs. Understanding these basic types is essential for writing efficient and type-safe code. 

C# types are categorized as **value types** and **reference types**. The important difference is semantics and copy behavior, not a guaranteed stack-vs-heap rule: value types store their data directly, while reference types store a reference to an object.


**Core Concepts:**
```csharp
// VALUE TYPES (stored on stack)
int x = 10;         // Stack: x = 10
int y = x;          // Stack: y = 10 (COPY)
y = 20;             // Stack: y = 20, x remains 10

// REFERENCE TYPES (stored on heap)
class Person { public string Name; }
Person p1 = new Person { Name = "John" };  // Heap: object, Stack: reference
Person p2 = p1;                            // Stack: copy of reference
p2.Name = "Jane";                          // Both p1 and p2 see the change
```

**Memory Layout:**
```
STACK (Value Types)      HEAP (Reference Types)
┌──────────────┐        ┌──────────────────┐
│ int x = 10   │        │ Person Object    │
│ int y = 20   │        │ - Name = "Jane"  │
│ ref p1 ──────┼───────►│ ...              │
│ ref p2 ──────┘        └──────────────────┘
└──────────────┘
```

**Advanced Scenarios:**
```csharp
// Struct (value type) vs Class (reference type)
public struct Point { public int X, Y; }
public class Rectangle { public Point Location; }

var rect = new Rectangle { Location = new Point { X = 10, Y = 20 } };
var location = rect.Location;  // COPY of the struct
location.X = 30;               // rect.Location.X remains 10
```


```csharp
// Integer types
byte byteValue = 255;                // 8-bit unsigned integer (0 to 255)
sbyte sbyteValue = -128;             // 8-bit signed integer (-128 to 127)
short shortValue = -32768;           // 16-bit signed integer (-32,768 to 32,767)
ushort ushortValue = 65535;          // 16-bit unsigned integer (0 to 65,535)
int intValue = -2147483648;          // 32-bit signed integer (-2,147,483,648 to 2,147,483,647)
uint uintValue = 4294967295;         // 32-bit unsigned integer (0 to 4,294,967,295)
long longValue = -9223372036854775808; // 64-bit signed integer (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807)
ulong ulongValue = 18446744073709551615; // 64-bit unsigned integer (0 to 18,446,744,073,709,551,615)

// Integer literals
int decimalLiteral = 42;             // Decimal (base 10)
int hexLiteral = 0x2A;               // Hexadecimal (base 16)
int binaryLiteral = 0b101010;        // Binary (base 2)
int withSeparator = 1_000_000;       // Digit separator for readability

// Floating point types
float floatValue = 3.14f;            // 32-bit floating-point (7 significant digits precision)
double doubleValue = 3.14159265359;  // 64-bit floating-point (15-16 significant digits precision)
decimal decimalValue = 3.14159265359m; // 128-bit high-precision decimal (28-29 significant digits)

// Boolean type
bool trueValue = true;
bool falseValue = false;

// Character type
char charValue = 'A';                // Unicode character
char unicodeChar = '\u0041';         // Unicode escape sequence for 'A'
char escapeChar = '\n';              // Newline escape sequence

// DateTime and TimeSpan
DateTime now = DateTime.Now;
DateTime utcNow = DateTime.UtcNow;
DateOnly today = DateOnly.FromDateTime(DateTime.Today); // Date without time (C# 10+)
TimeOnly noon = new TimeOnly(12, 0, 0);                 // Time without date (C# 10+)
DateTime specific = new DateTime(2023, 1, 1);
TimeSpan oneHour = TimeSpan.FromHours(1);
TimeSpan duration = TimeSpan.FromMinutes(90);

// Nullable types (can be null)
int? nullableInt = null;
bool? nullableBool = null;

// Default values
int defaultInt = default;            // 0
bool defaultBool = default;          // false
string defaultString = default;      // null
DateTime defaultDateTime = default;  // 0001-01-01 00:00:00

// Numeric type aliases (C# 12+)
using intptr = nint;               // Native-sized integer
using uintptr = nuint;             // Unsigned native-sized integer
using index = System.Index;        // Type alias for Index
```

## 1. Data Types and Variables

### Value Types vs Reference Types - Deep Understanding

**Core Concepts:**
```csharp
// VALUE TYPES (stored on stack)
int x = 10;         // Stack: x = 10
int y = x;          // Stack: y = 10 (COPY)
y = 20;             // Stack: y = 20, x remains 10

// REFERENCE TYPES (stored on heap)
class Person { public string Name; }
Person p1 = new Person { Name = "John" };  // Heap: object, Stack: reference
Person p2 = p1;                            // Stack: copy of reference
p2.Name = "Jane";                          // Both p1 and p2 see the change
```

**Memory Layout:**
```
STACK (Value Types)      HEAP (Reference Types)
┌──────────────┐        ┌──────────────────┐
│ int x = 10   │        │ Person Object    │
│ int y = 20   │        │ - Name = "Jane"  │
│ ref p1 ──────┼───────►│ ...              │
│ ref p2 ──────┘        └──────────────────┘
└──────────────┘
```

**Advanced Scenarios:**
```csharp
// Struct (value type) vs Class (reference type)
public struct Point { public int X, Y; }
public class Rectangle { public Point Location; }

var rect = new Rectangle { Location = new Point { X = 10, Y = 20 } };
var location = rect.Location;  // COPY of the struct
location.X = 30;               // rect.Location.X remains 10
```

### Probable Questions & Answers

**Q1: What happens when you pass a struct to a method? Does it get copied?**
```csharp
public void ModifyPoint(Point p) { p.X = 100; }

var point = new Point { X = 10, Y = 20 };
ModifyPoint(point);
Console.WriteLine(point.X); // Output: 10 (original unchanged)
```
**Answer:** Yes, structs are passed by value (copied). Use `ref` to pass by reference.

**Q2: Why can't structs have parameterless constructors in C#?**
**Answer:** Structs always have an implicit parameterless constructor that zero-initializes all fields. Allowing explicit ones could create inconsistency.

**Q3: What's the performance implication of large structs?**
**Answer:** Large structs cause expensive copies. Guideline: keep structs under 16-24 bytes.

**Q4: Can value types contain reference types?**
```csharp
public struct DataContainer 
{ 
    public string Name;  // Reference type in value type
    public int Value;
}
```
**Answer:** Yes, but the reference is stored on the stack pointing to heap data.

---

## 2. Built-in Types Deep Dive

### Numeric Types Precision
```csharp
// INTEGER TYPES
byte  (1 byte): 0 to 255
sbyte (1 byte): -128 to 127
short (2 bytes): -32,768 to 32,767
ushort(2 bytes): 0 to 65,535
int   (4 bytes): ±2.1 billion
long  (8 bytes): ±9.2 quintillion

// FLOATING POINT (IEEE 754)
float  (4 bytes): ~6-9 digits precision, suffix 'f'
double (8 bytes): ~15-17 digits precision, default
decimal(16 bytes): 28-29 digits precision, financial, suffix 'm'

// PRECISION ISSUES
float f = 0.1f + 0.2f;        // 0.30000001192092896
double d = 0.1 + 0.2;         // 0.30000000000000004  
decimal m = 0.1m + 0.2m;      // 0.3 (exact)
```

### DateTime Deep Dive
```csharp
// DATETIME KINDS
DateTime local = DateTime.Now;        // Local time
DateTime utc = DateTime.UtcNow;       // UTC time
DateTime unspecified = new DateTime(2023, 1, 1); // Unspecified

// TICKS RESOLUTION
DateTime dt = DateTime.Now;
long ticks = dt.Ticks; // 100-nanosecond intervals since 1/1/0001

// DATETIME vs DATETIMEOFFSET
DateTime dt = new DateTime(2023, 1, 1); // No timezone info
DateTimeOffset dto = DateTimeOffset.Now; // Includes offset from UTC
```

### Probable Questions & Answers

**Q1: Why should you use decimal for financial calculations?**
**Answer:** decimal uses base-10 floating point, avoiding binary representation errors that affect float/double with decimal fractions.

**Q2: What's the difference between DateTime.Kind Unspecified, Local, and Utc?**
**Answer:** 
- Unspecified: No timezone information (dangerous for conversions)
- Local: Machine's local timezone
- Utc: Coordinated Universal Time

**Q3: When would you use DateTimeOffset instead of DateTime?**
**Answer:** When working with multiple timezones or storing absolute points in time. DateTimeOffset preserves the offset information.

**Q4: What's the maximum value of DateTime and what happens after?**
```csharp
DateTime max = DateTime.MaxValue; // December 31, 9999
// DateTime.MaxValue.AddTicks(1) throws OverflowException
```

---

## 3. Nullable Value Types

### Deep Implementation
```csharp
// NULLABLE<T> STRUCT INTERNAL (conceptual)
public struct Nullable<T> where T : struct
{
    private readonly T value;
    private readonly bool hasValue;
    
    public T Value => hasValue ? value : throw new InvalidOperationException();
    public bool HasValue => hasValue;
}

// SYNTAX SUGAR
int? nullableInt = null;        // Equivalent to Nullable<int>
int regularInt = nullableInt.Value; // Throws if null
```

### Advanced Patterns
```csharp
// NULL COALESCING WITH NULLABLES
int? maybeNumber = null;
int result = maybeNumber ?? 10; // 10

// NULLABLE PATTERN MATCHING
if (maybeNumber is int number)
{
    Console.WriteLine(number);
}

// NULLABLE HASHCODE CONSIDERATIONS
int? a = null;
int? b = null;
Console.WriteLine(a.GetHashCode() == b.GetHashCode()); // True
```

### Probable Questions & Answers

**Q1: What's the difference between `int?` and `Nullable<int>`?**
**Answer:** They're identical. `int?` is syntactic sugar for `Nullable<int>`.

**Q2: Can you have `Nullable<Nullable<int>>`?**
**Answer:** No, the type parameter must be a non-nullable value type.

**Q3: How does boxing work with nullable types?**
```csharp
int? nullable = 42;
object boxed = nullable; // Boxes the underlying int, not Nullable<int>
Console.WriteLine(boxed.GetType()); // System.Int32

int? nullValue = null;
object nullBoxed = nullValue; // Results in null reference
```

**Q4: What happens when you call GetType() on a nullable with value?**
```csharp
int? number = 42;
Console.WriteLine(number.GetType()); // System.Int32 (not Nullable<Int32>)
```

---

## 4. var Keyword and Type Inference

### Compiler Implementation
```csharp
// COMPILER INFERENCE PROCESS
var name = "John";          // Compiler: string name = "John";
var count = 10;             // Compiler: int count = 10;
var list = new List<int>(); // Compiler: List<int> list = new List<int>();

// WHAT VAR IS NOT
// var x;                   // ERROR: must be initialized
// var y = null;            // ERROR: can't infer type from null
// var z = GetData();       // OK if return type is known at compile time
```

### Advanced Scenarios
```csharp
// ANONYMOUS TYPES REQUIRE VAR
var person = new { Name = "John", Age = 30 }; // Compiler-generated type

// CAPTURED VARIABLES IN LAMBDAS
var numbers = new List<int> { 1, 2, 3 };
var multiplier = 2; // Type inferred as int
var result = numbers.Select(x => x * multiplier); // multiplier captured

// TYPE INFERENCE WITH GENERICS
var dictionary = new Dictionary<string, List<int>>(); // Complex type inferred
```

### Probable Questions & Answers

**Q1: Does using `var` affect performance?**
**Answer:** No, it's purely compile-time. The generated IL is identical to explicit typing.

**Q2: When should you avoid using `var`?**
**Answer:** 
- When the type isn't obvious from the right-hand side
- For primitive types where explicit typing improves readability
- When you want to specify an interface type explicitly

**Q3: What happens with `var` and inheritance?**
```csharp
IEnumerable<int> numbers = new List<int>(); // Type is IEnumerable<int>
var numbersVar = new List<int>();           // Type is List<int>
```

**Q4: Can `var` be used in method parameters or return types?**
**Answer:** No, `var` is only for local variable type inference.

---

## 5. Dynamic Typing (dynamic keyword)

### DLR (Dynamic Language Runtime) Integration
```csharp
// DYNAMIC VS VAR
var name = "John";     // Compile-time type: string (static typing)
dynamic data = "John"; // Runtime type resolution (dynamic typing)

// DYNAMIC METHOD DISPATCH
dynamic obj = GetSomeObject();
obj.SomeMethod(); // Resolution deferred to runtime

// COMPILER GENERATED CODE (conceptual)
// dynamic call becomes: 
// Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(...)
```

### Advanced Dynamic Scenarios
```csharp
// DYNAMIC WITH EXPANDOOBJECT
dynamic person = new ExpandoObject();
person.Name = "John";      // Adds property at runtime
person.Age = 30;           // Adds another property
person.SayHello = (Action)(() => Console.WriteLine("Hello")); // Adds method

// DYNAMIC OPERATOR OVERLOADING
dynamic x = 10;
dynamic y = 20;
dynamic result = x + y; // Runtime operator resolution

// DYNAMIC WITH COM INTEROP
dynamic excelApp = Microsoft.VisualBasic.Interaction.GetObject("Excel.Application");
excelApp.Visible = true; // Late-bound COM calls
```

### Performance Implications
```csharp
// DLR CACHING MECHANISM
// First call to a dynamic member: slow (resolution + cache)
// Subsequent calls: faster (using cache)

// BOXING WITH DYNAMIC
dynamic number = 42;        // int boxed to object
int result = number + 10;   // Unboxing + operation
```

### Probable Questions & Answers

**Q1: What's the difference between `dynamic` and `object`?**
```csharp
object obj = "hello";
// obj.Length; // COMPILE ERROR: object doesn't have Length

dynamic dyn = "hello";
int length = dyn.Length; // RUNTIME: resolves successfully
```

**Q2: When would you use `dynamic` in real applications?**
**Answer:** 
- COM interop with Office applications
- Working with JSON data without POCO classes
- Duck typing scenarios
- Reflection simplification (but consider `dynamic` vs proper reflection)

**Q3: What exceptions can `dynamic` throw?**
**Answer:** `RuntimeBinderException` when members don't exist or operations are invalid.

**Q4: How does `dynamic` work with inheritance?**
```csharp
class Base { public void Method() { } }
class Derived : Base { public void NewMethod() { } }

dynamic obj = new Derived();
obj.Method();    // Works (inherited)
obj.NewMethod(); // Works (defined on derived)
obj.Unknown();   // RuntimeBinderException
```

---

## 6. Operators and Expressions

### Operator Precedence Deep Dive
```csharp
// PRECEDENCE HIERARCHY (high to low)
// Primary: x.y, f(x), a[x], x++, x--, new, typeof, checked, unchecked
// Unary: +, -, !, ~, ++x, --x, (T)x, await
// Multiplicative: *, /, %
// Additive: +, -
// Shift: <<, >>
// Relational: <, >, <=, >=, is, as
// Equality: ==, !=
// Logical AND: &
// Logical XOR: ^
// Logical OR: |
// Conditional AND: &&
// Conditional OR: ||
// Null coalescing: ??
// Conditional: ?:
// Assignment: =, +=, -=, etc.

// COMPLEX EXPRESSION
var result = a + b * c ?? d is string ? e : f;
// Equivalent to: (a + (b * c)) ?? (d is string ? e : f)
```

### Custom Operator Overloading
```csharp
public struct Vector
{
    public double X, Y;
    
    public static Vector operator +(Vector a, Vector b) 
        => new Vector { X = a.X + b.X, Y = a.Y + b.Y };
    
    public static bool operator ==(Vector a, Vector b) 
        => a.X == b.X && a.Y == b.Y;
    
    public static bool operator !=(Vector a, Vector b) 
        => !(a == b);
    
    // Must override Equals and GetHashCode when overloading ==
    public override bool Equals(object obj) => obj is Vector v && this == v;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}
```

### Tricky Operator Questions

**Q1: What's the difference between `x++` and `++x`?**
```csharp
int x = 5;
int a = x++; // a = 5, x = 6 (post-increment)
int b = ++x; // b = 7, x = 7 (pre-increment)
```

**Q2: How does the null-conditional operator short-circuit?**
```csharp
Person person = null;
string name = person?.Address?.City; // Entire expression returns null
// Equivalent to: person == null ? null : person.Address?.City
```

**Q3: What's the behavior of nullable equality operators?**
```csharp
int? a = null;
int? b = null;
int? c = 5;

Console.WriteLine(a == b); // True (both null)
Console.WriteLine(a == c); // False (null vs value)
Console.WriteLine(a > c);  // False (any comparison with null returns false)
```

**Q4: How does operator lifting work with nullables?**
```csharp
int? a = 10;
int? b = 20;
int? result = a + b; // 30 (operators "lifted" to work with nullables)

int? nullValue = null;
int? test = nullValue + 10; // null (any operation with null returns null)
```

**Q5: What's the difference between `&` and `&&`?**
```csharp
bool Method1() { Console.Write("1"); return false; }
bool Method2() { Console.Write("2"); return true; }

bool result1 = Method1() & Method2();  // Output: "12" (both evaluated)
bool result2 = Method1() && Method2(); // Output: "1" (short-circuited)
```

This deep dive covers the fundamental concepts, implementation details, and tricky scenarios you'll encounter in interviews. Practice these patterns and understand the "why" behind each behavior.

---

## 7. Quick Reference Comparisons

### `var` vs `dynamic`

These are both used when declaring variables in C#, but they behave very differently.

| Feature         | `var`                                        | `dynamic`                              |
| --------------- | -------------------------------------------- | -------------------------------------- |
| Type resolution | At compile time                              | At runtime                             |
| IntelliSense    | Full support                                 | Limited                                |
| Error detection | Compile time                                 | Runtime                                |
| Best use case   | When the type is obvious from the assignment | When the type is unknown until runtime |

#### `var`

- Type-safe: the compiler infers the real type from the right-hand side.
- Compile-time checking: you get IntelliSense, validation, and early errors.
- Must be initialized so the compiler can infer the type.

```csharp
var name = "Alice";  // inferred as string
var age = 30;        // inferred as int

// var something = null; // Compile-time error
```

#### `dynamic`

- Runtime-bound: member access and method resolution happen at runtime.
- Flexible, but unsafe compared to `var`.
- Useful with COM interop, reflection-heavy APIs, or dynamic JSON-like structures.

```csharp
dynamic something = "Hello";
Console.WriteLine(something.Length);  // OK

something = 123;
Console.WriteLine(something.Length);  // RuntimeBinderException at runtime
```

#### When to use each

- Use `var` when the type is known or easily inferred and you want safety.
- Use `dynamic` only when you intentionally want runtime binding.

#### Key point

- `var` is compiler syntax sugar. The actual type is fixed at compile time.
- `dynamic` participates in runtime binding and skips normal compile-time member checks.

---

### `object` vs `dynamic`

Both can hold values of any type, but they differ in how member access is validated.

| Feature         | `object`                | `dynamic`                                     |
| --------------- | ----------------------- | --------------------------------------------- |
| Type checking   | Compile time            | Runtime                                       |
| Member access   | Requires cast           | No cast required                              |
| Error detection | Compile time            | Runtime                                       |
| Performance     | Faster                  | Slower due to runtime binding                 |
| Best use case   | General-purpose storage | Dynamic APIs, COM, reflection-heavy scenarios |

#### `object`

- Base type of all .NET types.
- You can store anything in it, but you usually need to cast before using members.

```csharp
object obj = "hello";

// Console.WriteLine(obj.Length); // Compile-time error
Console.WriteLine(((string)obj).Length); // Must cast
```

#### `dynamic`

- Internally works like a general reference, but member resolution is deferred to runtime.
- Convenient, but easier to break at execution time.

```csharp
dynamic d = "hello";
Console.WriteLine(d.Length);  // Works

d = 10;
Console.WriteLine(d.Length);  // RuntimeBinderException
```

#### Illustrated difference

```csharp
object obj = "hello";
// Console.WriteLine(obj.Length); // Compile-time error

dynamic dyn = "hello";
Console.WriteLine(dyn.Length); // Checked at runtime
```

#### Guidance

- Use `object` when you want compiler safety and explicit casts.
- Use `dynamic` when the shape of the data is genuinely unknown until runtime.

---

### `&` vs `&&`

These operators look similar but behave differently.

| Operator | Meaning                    | Works with            | Short-circuits | Common use                                              |
| -------- | -------------------------- | --------------------- | -------------- | ------------------------------------------------------- |
| `&`      | Bitwise AND or logical AND | Integers and booleans | No             | Bitwise work or forcing both boolean expressions to run |
| `&&`     | Logical AND                | Booleans only         | Yes            | Conditional checks in `if`, `while`, and guards         |

#### `&&`

- Evaluates the left side first.
- If the left side is `false`, the right side is skipped.
- This makes it safer for null checks.

```csharp
bool a = false;
bool b = true;

if (a && b)
{
    // Does not execute
}

if (obj != null && obj.SomeProperty == 5)
{
    // Safe null check pattern
}
```

#### `&`

- With booleans, both sides are always evaluated.
- With integers, it performs a bitwise AND.

```csharp
bool a = false;
bool b = true;

if (a & b)
{
    // Still false, but both expressions were evaluated
}

int x = 5;      // 0101
int y = 3;      // 0011
int z = x & y;  // 0001 => 1
```

#### Use case tip

- Use `&&` for regular boolean logic.
- Use `&` for bitwise operations or rare cases where both boolean expressions must run.

---

### `|` vs `||`

These are the OR equivalents of `&` and `&&`.

| Operator | Meaning | Works with               | Short-circuits        | Common use    |
| -------- | ------- | ------------------------ | --------------------- | ------------- |
| `        | `       | Bitwise OR or logical OR | Integers and booleans | No            | Bit flags or forcing both boolean expressions to run |
| `        |         | `                        | Logical OR            | Booleans only | Yes                                                  | Conditional checks where one true condition is enough |

#### `||`

- If the left side is `true`, the right side is skipped.
- This is the usual choice in control flow.

```csharp
bool a = true;
bool b = false;

if (a || b)
{
    // Executes because a is true
}

if (user == null || user.IsDisabled)
{
    // Safe: user.IsDisabled is not evaluated when user is null
}
```

#### `|`

- With booleans, both sides are evaluated.
- With integers, it performs a bitwise OR.

```csharp
bool a = true;
bool b = false;

if (a | b)
{
    // True, and both expressions are evaluated
}

int x = 5;      // 0101
int y = 3;      // 0011
int z = x | y;  // 0111 => 7
```

#### Use case tip

- Use `||` for normal boolean logic.
- Use `|` for bitwise operations, flags, or rare cases where both expressions must run.

#### Bit flags example

```csharp
[Flags]
enum FileAccess
{
    Read = 1,
    Write = 2,
    Execute = 4
}

var permissions = FileAccess.Read | FileAccess.Write;
bool canWrite = (permissions & FileAccess.Write) != 0;
```



Type inference with `var` (compile-time determined):

```csharp
var inferredInt = 42;                // Compiler infers int
var inferredString = "Hello";        // Compiler infers string
var inferredList = new List<int>();  // Compiler infers List<int>
```

Constants and readonly:

```csharp
// Compile-time constants (must be primitive types or string)
const double Pi = 3.14159;
const string AppName = "MyApp";

// Runtime constants
readonly DateTime StartTime = DateTime.Now;

// Static readonly - initialized only once at runtime
public static readonly HttpClient SharedClient = new HttpClient();

// Init-only setter - can only be set during initialization
public string Id { get; init; } = Guid.NewGuid().ToString();

// Read-only fields/properties with field/property initializers
public required string Name { get; init; }
```

### Const vs. Readonly
* **Use `const` for:** True immutable constants that will NEVER change (e.g., `Math.PI`, `DaysInWeek`).
* **Use `static readonly` for:** Configuration values, calculated values, or reference types that should be shared across the app but resolved at runtime.
* **The Difference:** `const` is a "Search and Replace" by the compiler; `static readonly` is a "Look up in memory" by the CPU.
* **`static` with `readonly`:** Moves the field from the object instance to the Type definition in the Loader Heap.

### Summary of Constants
* **Implicit Static:** `const` is always static. You never write `static const`.
* **The "Magic Number" Rule:** Use `const` only for values that are physically/mathematically impossible to change (e.g., `MinutesInHour = 60`).
* **The "Config" Rule:** Use `static readonly` for anything that might change between environments (e.g., `BaseUrl`, `MaxTimeout`) or requires an object instance.

### 📊 C# Constants & Static Modifiers Comparison

| Feature             | `const`                            | `readonly`                 | `static readonly`                 |
| :------------------ | :--------------------------------- | :------------------------- | :-------------------------------- |
| **Binding Time**    | **Compile-time**                   | **Runtime**                | **Runtime**                       |
| **Initialization**  | Only at declaration                | Declaration or Constructor | Declaration or Static Constructor |
| **Memory Location** | Embedded in IL code (No Heap)      | Instance Heap (Gen 0/1/2)  | Loader Heap (Static)              |
| **Accessibility**   | Type-level (Implicitly static)     | Instance-level             | Type-level                        |
| **Supported Types** | Primitives, `string`, `null`       | **Any** Type               | **Any** Type                      |
| **Versioning Risk** | **High** (Requires full recompile) | Low                        | Low                               |
| **Use Case**        | Mathematical constants, fixed IDs  | Per-instance unique IDs    | Global Config, Service Instances  |

---

### 💡 Senior-Level Context for the Table

* **The "Versioning Trap":** If you change a `const` in a DLL, any project referencing that DLL **must** be recompiled to see the new value. With `static readonly`, the change is picked up at runtime without a recompile of the calling app.
* **Implicit Statics:** You never write `static const`. By definition, a compile-time constant cannot belong to an instance; it belongs to the Type.
* **Memory Efficiency:** `const` is the "cheapest" because it doesn't occupy a memory slot at runtime—the value is literally swapped into the instruction stream by the compiler.
* **Thread Safety:** The CLR guarantees that the Static Constructor (where `static readonly` fields are often set) is executed in a thread-safe manner.



---

### 📝 Final Note for your Study Guide

```markdown
### Quick Decision Logic
1. Is it a math/physical constant (e.g., `PI`, `DaysInWeek`)? → Use **const**.
2. Is it a reference type (e.g., `new List<int>()`)? → Use **static readonly**.
3. Does the value come from a Config file or Database at startup? → Use **static readonly**.
4. Does each object instance need its own unique fixed ID? → Use **readonly**.
```

**Quick mental model**

- Pick types based on domain meaning first: `decimal` for money, `double` for general floating-point math, `DateTimeOffset` when offset-aware timestamps matter, and nullable annotations when absence matters.
- Value type vs reference type is mainly about copy behavior and identity, not a simplistic memory-location rule.
- `const` means compile-time constant substitution, while `readonly` means runtime initialization with later immutability.
- `var` improves readability when the type is obvious from the right-hand side; it does not make the code weakly typed.

**Behind the covers**

- `double` uses binary floating-point, so many decimal fractions cannot be represented exactly; `decimal` uses a scaled decimal representation that fits financial calculations better.
- Boxing copies a value type into an object wrapper so it can be treated as `object` or an interface reference.
- `default(T)` is a zero/default initialization operation; it does not call user-defined constructors for structs.
- Literal suffixes such as `m`, `f`, `d`, `u`, and `l` influence inferred type and overload resolution at compile time.

### Interview Prep

**Senior Perspective (The "Why")**

- Type choice is a modeling decision first and a syntax decision second.
- Strong answers explain value semantics vs reference semantics, precision vs range, and correctness vs performance trade-offs.
- The goal is to choose the type that best matches the domain: for example, `decimal` for money, `DateTimeOffset` or UTC strategies for distributed time, and nullable annotations for safer APIs.
- `Good opening answer:` "I choose types based on semantics first: copy behavior, precision, nullability, and time handling, not just what compiles."
- `Then add:` compare `decimal` vs `double`, nullable value vs nullable reference types, and value vs reference semantics without falling back to the oversimplified stack/heap answer.

**Interview Gotchas & Confusion Points**

- `var` is compile-time type inference, not dynamic typing.
- `decimal` vs `double` is a classic question: money usually means `decimal`, while many scientific/general computations use `double`.
- Boxing happens when a value type is treated as `object` or an interface, and it can add allocations and overhead.
- Many candidates still repeat the oversimplified "value types are on the stack, reference types are on the heap" explanation.

**Corner Cases**

- Value types can still exist inside heap objects, arrays, or boxed values.
- `default(SomeStruct)` ignores any parameterless struct constructor logic.
- `DateTime.Now` and `DateTime.UtcNow` are not interchangeable.
- Integer overflow is often unchecked unless you use `checked` or project-level settings.

**Behind the Scenes / Internal Logic**

- Assigning a value type copies its data, while assigning a reference type copies the reference, not the underlying object.
- Boxing wraps a value type inside an object instance so it can be treated like a reference, which introduces allocation and copy cost.
- `var` is resolved entirely by the compiler at compile time; there is no runtime type inference happening after compilation.

**Must Remember Facts**

- Nullable value types use `Nullable<T>` / `T?`.
- Nullable reference types are compile-time analysis, not runtime enforcement.
- Literal suffixes like `m`, `f`, `u`, and `l` affect type inference and overload resolution.
- Choose types based on semantics and correctness before micro-optimizing.

**Question Bank (Common Questions + What to Say)**

- `Q: What is the real difference between a value type and a reference type?`<br>
  `What to say:` Value types store their data directly and copy the value on assignment. Reference types copy the reference, so multiple variables can point to the same object.<br>
  `Focus on:` semantics and copy behavior, not just memory location.
- `Q: Why is "stack vs heap" an incomplete explanation?`<br>
  `What to say:` Because value types can live inside heap objects or arrays, and the key difference is not where they live but how they behave when assigned, passed, and boxed.<br>
  `Focus on:` runtime semantics over oversimplified storage rules.
- `Q: When do you choose decimal over double?`<br>
  `What to say:` Choose `decimal` for money or precision-sensitive decimal arithmetic. Choose `double` for most scientific, geometric, or general floating-point workloads where binary floating-point is acceptable.<br>
  `Focus on:` precision model and domain fit.
- `Q: What is boxing, and why can it hurt performance?`<br>
  `What to say:` Boxing wraps a value type in an object so it can be treated as a reference. That usually introduces an allocation and a copy, so it can add overhead in tight paths.<br>
  `Focus on:` allocation plus copy cost.
- `Q: What is the difference between nullable value types and nullable reference types?`<br>
  `What to say:` Nullable value types are runtime-supported wrappers around value types. Nullable reference types are compile-time annotations and flow analysis that help catch null-safety issues earlier.<br>
  `Focus on:` runtime representation vs compile-time analysis.


### Probable Questions & Answers

**Q1: What happens when you pass a struct to a method? Does it get copied?**
```csharp
public void ModifyPoint(Point p) { p.X = 100; }

var point = new Point { X = 10, Y = 20 };
ModifyPoint(point);
Console.WriteLine(point.X); // Output: 10 (original unchanged)
```
**Answer:** Yes, structs are passed by value (copied). Use `ref` to pass by reference.

**Q2: Why can't structs have parameterless constructors in C#?**
**Answer:** Structs always have an implicit parameterless constructor that zero-initializes all fields. Allowing explicit ones could create inconsistency.

**Q3: What's the performance implication of large structs?**
**Answer:** Large structs cause expensive copies. Guideline: keep structs under 16-24 bytes.

**Q4: Can value types contain reference types?**
```csharp
public struct DataContainer 
{ 
    public string Name;  // Reference type in value type
    public int Value;
}
```
**Answer:** Yes, but the reference is stored on the stack pointing to heap data.

---


**Additional resources:**

- [Built-in types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Value types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [Reference types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Constants (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const)
- [DateOnly and timeOnly types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6#dateonly-and-timeonly)

---

### 1. The Core Architecture

| Feature              | Value Types (`struct`, `enum`, primitives)           | Reference Types (`class`, `interface`, `delegate`, `string`) |
| :------------------- | :--------------------------------------------------- | :----------------------------------------------------------- |
| **Storage Location** | Typically the **Stack** (or inline in a heap object) | **Managed Heap** (variable stores a pointer)                 |
| **Assignment**       | **Copy by Value:** Creates a full independent copy.  | **Copy by Reference:** Copies the memory address.            |
| **Memory Overhead**  | Low (only the data itself).                          | High (8-byte pointer + 16-byte object header).               |
| **Default Value**    | A "Zeroed" instance (e.g., `0` or `false`).          | `null`.                                                      |
| **Inheritance**      | None (they are implicitly `sealed`).                 | Full support for inheritance/polymorphism.                   |



---

### 2. The Senior "Deep Dive" Concepts

#### A. Memory Locality & CPU Cache
Value types are "cache-friendly." If you have an array of structs (`Point[]`), the data is stored contiguously in memory. When the CPU loads one `Point`, it likely loads the next few into the L1 cache.
With an array of classes, the array only contains **pointers**. To get the actual data, the CPU has to "jump" to different locations on the heap (a Cache Miss), which is significantly slower.

#### B. The Boxing/Unboxing Performance Hit
Boxing happens when a value type is converted to a reference type (e.g., casting an `int` to an `object`).
* **The Cost:** A new object is allocated on the heap, the value is copied into it, and a pointer is returned. 
* **The Senior Fix:** Use **Generics** (`List<T>`) to ensure the type stays as a value type throughout its lifecycle, avoiding GC pressure.

#### C. `ref struct` (The Ultra-Fast Value Type)
Introduced in modern .NET (like `Span<T>`), a `ref struct` is a value type that is **guaranteed** to never leave the stack. It cannot be boxed, cannot be a field in a class, and cannot be used in `async` methods. This allows for high-performance, allocation-free code.

---

### 3. Common Interview "Gotchas"

**Q: Are value types ALWAYS on the stack?**
**A: No.** This is a common junior mistake. Value types live wherever they are declared. If a `struct` is a field inside a `class`, that struct lives on the **Heap** as part of the class object. If a value type is part of an array, it lives on the Heap.

**Q: Why is `string` a reference type if it behaves like a value type?**
**A: For memory efficiency.** Strings can be massive. If they were value types, passing them to a method would involve copying the entire character array. By making them **immutable reference types**, .NET can safely pass pointers around without worrying about the original data being changed.

---

### 📝 Note for your Study Guide

```markdown
### Value vs. Reference Types
* **Value Types:** Best for small, short-lived data. They reduce GC pressure because they are cleaned up immediately when the stack frame pops.
* **Reference Types:** Best for complex objects with identity and long lifecycles. 
* **Architecture Tip:** Use `readonly struct` for small data structures to ensure the compiler doesn't make "defensive copies," which can slow down your code.
```



---


# Data types

C# supports a variety of composite data types to organize and represent data.

## Classes

Classes are reference types that encapsulate data and behavior.

```csharp
// Basic class definition
public class Person
{
    // Fields
    private string name;
    private int age;
    
    // Properties
    public string Name 
    { 
        get { return name; }
        set { name = value; } 
    }
    
    // Auto-implemented property
    public int Age { get; set; }
    
    // Read-only property
    public bool IsAdult => Age >= 18;
    
    // Constructors
    public Person()
    {
        // Default constructor
    }
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    // Methods
    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name} and I'm {Age} years old.");
    }
    
    public string GetDescription() => $"{Name}, {Age} years old";
    
    // Static members
    public static int MinimumAge { get; } = 0;
    
    public static bool IsValidAge(int age)
    {
        return age >= MinimumAge;
    }
}

// Usage
Person person = new Person();
person.Name = "Alice";
person.Age = 30;
person.Introduce();

Person bob = new Person("Bob", 25);
string description = bob.GetDescription();
bool isAdult = bob.IsAdult;

bool isValid = Person.IsValidAge(20);
```

## Structs

Structs are value types and are suitable for small, immutable data structures.

Modern C# lets structs declare field/property initializers and parameterless constructors, but `default(T)` and array allocation still produce zero-initialized values, so invariants need extra care.

```csharp
// Basic struct definition
public struct Point
{
    // Fields
    public double X { get; set; }
    public double Y { get; set; }
    
    // Constructor
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    // Methods
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
    
    // Override ToString method
    public override string ToString() => $"({X}, {Y})";
}

// Usage
Point point = new Point(3, 4);
double distance = point.DistanceFromOrigin(); // 5
```

**Quick mental model**

- A struct should model a small value that behaves like data, not like an entity with long-lived identity.
- `readonly struct` or effectively immutable struct design is usually the safest interview answer.
- If mutation matters, pause and verify whether a class would express the semantics more safely.

**Behind the covers**

- Struct assignment copies the entire value, so mutation after a copy affects only that copy.
- Returning or accessing mutable structs through properties can produce copy-on-access surprises.
- Even though modern structs can declare constructors, `default(T)` and array allocation still produce zero-initialized values.

## Records (C# 9.0+)

Records are reference types designed for representing immutable data.

```csharp
// Positional record (concise syntax)
public record Person(string FirstName, string LastName, int Age);

// Usage
var person1 = new Person("John", "Doe", 30);
var person2 = new Person("John", "Doe", 30);

// Records have value-based equality
bool areEqual = person1 == person2; // true

// Non-destructive mutation with 'with' expression
var person3 = person1 with { Age = 31 };

// Records can also be defined with standard syntax for more flexibility
public record Employee
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Id { get; init; }
    
    // Additional members can be defined
    public string FullName => $"{FirstName} {LastName}";
}
```

**Quick mental model**

- Records are for data-centric models where value-based equality and non-destructive mutation matter more than identity.
- They shine in DTOs, commands, settings objects, and other shapes where "same data means same value" is the main concern.
- They are not automatically the right choice for rich domain entities with lifecycle, identity, or mutation rules.

**Behind the covers**

- Positional records synthesize properties, a primary constructor, deconstruction support, equality members, and a useful `ToString()`.
- `with` expressions create a copy and then apply member changes, so they are shallow copy operations.
- Record class equality considers both member values and runtime type, which matters in inheritance hierarchies.

## Record structs (C# 10.0+)

Record structs combine the value semantics of structs with the special features of records.

```csharp
// Record struct
public record struct Point(double X, double Y);

// Mutable record struct
public record struct MutablePoint
{
    public double X { get; set; }
    public double Y { get; set; }
    
    public double Distance => Math.Sqrt(X * X + Y * Y);
}
```

## Interfaces

Interfaces define a contract that classes can implement.

```csharp
// Interface definition
public interface IShape
{
    double Area { get; }
    double Perimeter { get; }
    void Draw();
    string GetDescription() => $"Shape with area {Area} and perimeter {Perimeter}"; // Default implementation (C# 8.0+)
}

// Implementing an interface
public class Circle : IShape
{
    public double Radius { get; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public double Area => Math.PI * Radius * Radius;
    public double Perimeter => 2 * Math.PI * Radius;
    
    public void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
    
    // Override default implementation
    public string GetDescription() => $"Circle with radius {Radius}";
}
```

From C# 8.0, interfaces can have **default implementations for methods and properties**, allowing you to provide a base implementation that can be overridden by implementing classes.

```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default implementation
    void LogError(string message) => Log($"ERROR: {message}");
    void LogWarning(string message) => Log($"WARNING: {message}");
    
    // Static method in interface
    static string FormatMessage(string level, string message) => $"[{level}] {message}";
}

// Implement only required methods
public class MinimalLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
    
    // Other methods use default implementations
}
```

**Quick mental model**

- Interfaces model capabilities and contracts, especially when unrelated types should present the same behavior.
- Use them when consumers should depend on what something can do instead of what concrete class it is.
- Keep interfaces cohesive; a small focused contract is easier to implement, test, and evolve than a wide one.

**Behind the covers**

- Interface calls use interface dispatch rather than direct non-virtual calls, which adds an indirection boundary.
- When a struct is used through an interface reference, boxing may occur because the value must be represented as an object.
- Default interface members add versioning flexibility, but they also make dispatch and behavior ownership less obvious than a pure contract-only interface.

## Enums

Enums define a set of named constants.

```csharp
// Basic enum
public enum DayOfWeek
{
    Sunday,     // 0
    Monday,     // 1
    Tuesday,    // 2
    Wednesday,  // 3
    Thursday,   // 4
    Friday,     // 5
    Saturday    // 6
}

// Enum with explicit values
public enum HttpStatusCode
{
    OK = 200,
    Created = 201,
    BadRequest = 400,
    Unauthorized = 401,
    NotFound = 404,
    InternalServerError = 500
}

// Enum with flags attribute (for bitwise operations)
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    All = Read | Write | Execute
}

// Usage
DayOfWeek today = DayOfWeek.Monday;
HttpStatusCode status = HttpStatusCode.OK;

// Convert between enum and integer
int dayValue = (int)today;
DayOfWeek convertedDay = (DayOfWeek)3; // Wednesday

// Parsing from string
DayOfWeek parsed = Enum.Parse<DayOfWeek>("Friday");
bool success = Enum.TryParse("Sunday", out DayOfWeek result);

// Using flags
Permissions userPermissions = Permissions.Read | Permissions.Write;
bool canRead = userPermissions.HasFlag(Permissions.Read); // true
bool canExecute = userPermissions.HasFlag(Permissions.Execute); // false
```

## Tuples

Tuples group multiple values without defining a specific type.

```csharp
// Creating tuples (C# 7.0+)
(int, string) pair = (1, "one");
var person = (Name: "Alice", Age: 30);

// Accessing tuple elements
int id = pair.Item1;
string value = pair.Item2;
string name = person.Name;
int age = person.Age;

// Tuple deconstruction
var (newId, newValue) = pair;
var (newName, newAge) = person;

// Using tuples as method return values
(int Min, int Max) FindMinMax(int[] numbers)
{
    return (numbers.Min(), numbers.Max());
}

var result = FindMinMax(new[] { 1, 2, 3, 4, 5 });
Console.WriteLine($"Min: {result.Min}, Max: {result.Max}");

// Tuple as method parameter
void ProcessData((string Name, int Age) person)
{
    Console.WriteLine($"Processing data for {person.Name}, {person.Age}");
}
```

## Nullable types

Nullable types represent values that can be null.

```csharp
// Nullable value types
int? nullableInt = null;
double? nullableDouble = 3.14;

// Checking for null
if (nullableInt.HasValue)
{
    int value = nullableInt.Value;
}

// Null-coalescing operator
int result = nullableInt ?? 0; // If nullableInt is null, use 0

// Nullable reference types (C# 8.0+)
// Enable with: #nullable enable
string? nullableString = null;
string nonNullableString = "Hello"; // Cannot be null

// Null-conditional operator
int? length = nullableString?.Length; // null if nullableString is null

// Null-coalescing assignment (C# 8.0+)
nullableString ??= "Default";
```

**Quick mental model**

- Nullable value types answer "can this value-type slot be empty?" while nullable reference types answer "is null an allowed part of this API contract?"
- Nullable annotations help you communicate intent to both the compiler and future maintainers.
- Nullability reduces bugs, but it does not replace validation, invariants, or good API design.

**Behind the covers**

- `int?` is shorthand for `Nullable<int>`, which stores both a value and a `HasValue` flag.
- Nullable reference types are mostly compile-time metadata plus flow analysis; the CLR does not enforce them at runtime.
- The null-forgiving operator `!` only suppresses warnings; it does not change the runtime value.

### Interview Prep

**Senior Perspective (The "Why")**

- This topic is really about choosing the right semantic model for data.
- Good answers explain when you need identity, when you need value semantics, and when you need abstraction boundaries.
- Class vs struct vs record vs interface should sound like a design decision based on correctness, mutability, equality, and allocation behavior.
- Tuples and enums are modeling tools too, not just convenience syntax.
- `Good opening answer:` "I model data based on identity, value semantics, abstraction needs, and nullability contracts, not just language feature preference."
- `Then add:` compare `class`, `struct`, `record`, and `interface` by mutation risk, equality semantics, and API intent rather than syntax alone.

**Interview Gotchas & Confusion Points**

- Mutable structs are dangerous because copies happen more often than many candidates expect.
- Records are not deeply immutable by default; their members can still refer to mutable objects.
- Interfaces can introduce boxing and dispatch costs when value types are involved.
- Enum defaults are zero even if you never define a meaningful zero member.
- Nullable reference types are compile-time analysis, not runtime safety checks.

**Corner Cases**

- Record equality in inheritance scenarios depends on runtime type as well as data.
- `default(struct)` can bypass invariants you intended to enforce.
- Tuple element names mainly help at compile time; they are not a full domain model.
- Arrays and lists inside records remain mutable unless you wrap or copy them.

**Behind the Scenes / Internal Logic**

- Struct assignment copies the full value, which is why large or mutable structs can become surprisingly expensive or error-prone.
- Record types synthesize equality-related members, `ToString()`, and support for `with` expressions, which is why they feel more data-centric out of the box.
- Interface calls often involve virtual/interface dispatch, and value types may be boxed when treated through interface references.

**Must Remember Facts**

- Use structs for small value-like data, ideally immutable.
- Use records when value-based equality and data-centric modeling matter.
- Prefer defining `None = 0` for enums when possible.
- Use nullable annotations together with validation, not instead of validation.

Here is the professional breakdown for your notes, focusing on memory, performance, and modern C# (10/11/12) features.

---

### 1. The "Big Three" Comparison: Class vs. Struct vs. Record

| Feature         | `class`                | `struct`                | `record` (class)        | `record struct`          |
| :-------------- | :--------------------- | :---------------------- | :---------------------- | :----------------------- |
| **Type**        | Reference              | Value                   | Reference               | Value                    |
| **Identity**    | By Reference (Pointer) | By Value (Data)         | **By Value** (Equality) | **By Value**             |
| **Inheritance** | Full Support           | None                    | Full Support            | None                     |
| **Use Case**    | Complex logic/State    | Small, short-lived data | **DTOs / API Models**   | High-perf Immutable data |
| **Mutation**    | Mutable by default     | Mutable (Avoid!)        | Immutable (`with`)      | Both available           |

> **The "Senior" Nuance:** Use `record` for DTOs because they provide **Value-based Equality** out of the box. Two different record objects with the same data will return `true` for `Equals()`, which is a lifesaver for unit testing and caching.

---

### 2. Delegates and Events
* **Delegates:** Type-safe function pointers. Use `Action`, `Func`, and `Predicate` instead of custom delegates whenever possible to keep the API standard.
* **Events:** A wrapper around delegates that provides **encapsulation**. 
    * **The Trap:** External classes can only "Subscribe" (`+=`) or "Unsubscribe" (`-=`). They cannot clear the invocation list or trigger the event. 
    * **Memory Leak Alert:** If a long-lived object subscribes to an event in a short-lived object, the short-lived object **cannot be GC'd**. Always unsubscribe in `Dispose()`.

---

### 3. Interfaces
* **Senior Perspective:** Interfaces define **contracts**, not behavior.
* **Default Interface Methods (C# 8.0+):** You can now add a body to an interface method. This allows you to update an interface without breaking every class that implements it.
* **Explicit Implementation:** Used to hide methods that aren't relevant to the general consumer but are required for the internal contract.

---

### 4. Tuples (`(T1, T2)`)
* **Evolution:** We used `System.Tuple` (Reference type, clunky). Now we use **ValueTuples** (Value type, lightweight).
* **Use Case:** Returning multiple values from a private/internal method. 
* **The "Senior" Rule:** **Do not expose Tuples in public APIs.** Use a `Record` or `Class` instead. Tuples lack semantic meaning (even with named elements) and make breaking changes harder.

---

### 5. Nullable Types (`T?`)
* **Value Types (`int?`):** A wrapper around `Nullable<T>`. It adds a `bool HasValue` flag.
* **Reference Types (`string?`):** This is **Reference Type Nullable Context** (C# 8.0+). It doesn't change the runtime behavior; it provides **compiler warnings** to help you avoid `NullReferenceException`.
* **The "Senior" Nuance:** Treat "Nullable Warnings" as Errors. It forces the team to handle nulls at the boundaries of the application.

---

### 6. Enums
* **Best Practice:** Always use the `[Flags]` attribute if the enum represents a bitmask (e.g., `Permissions.Read | Permissions.Write`).
* **Senior Trap:** Never use an Enum as a database Primary Key. If the order of the Enum changes in code, your database logic breaks. Always map Enums to `int` or `string` explicitly.

---

### 📊 Summary Note for Markdown

```markdown
### Type System Strategy
* **Classes:** Use for Service logic, Repositories, and objects with a long lifecycle.
* **Structs:** Use for tiny data (<= 16 bytes) that is copied frequently.
* **Records:** The default choice for Data Transfer Objects (DTOs) and "Value Objects" in DDD.
* **Nullable Context:** Enable `<Nullable>enable</Nullable>` in your `.csproj` to eliminate 80% of production bugs.
* **Events:** Great for decoupling, but must be managed carefully to avoid memory leaks (the "Lapsed Listener" problem).
```

---

### 🏆 The Final Step: Mock Interview
You have all the "Senior" knowledge now. Are you ready for a **Quick Fire Interview**? 

I will give you **3 Scenarios**, and you tell me which C# feature you would use and **why**. 

**Scenario 1:** You are building a high-performance math library that processes millions of 3D coordinates $(x, y, z)$ per second. Which type do you use: `class`, `struct`, or `record`?
**Scenario 2:** You need to return an Error Message and an Integer Code from a private validation method. What is the most efficient return type?
**Scenario 3:** You want to allow users to subscribe to a "PriceChanged" notification in a Stock trading app. What mechanism do you use?

**Write your answers and I'll grade your "Seniority"!**
**Question Bank (Common Questions + What to Say)**

- `Q: What is the difference between a class and a struct?`<br>
  `What to say:` A class is a reference type with identity semantics, while a struct is a value type that copies its data on assignment. Use a struct only when the type is small, value-like, and preferably immutable.<br>
  `Focus on:` identity vs value semantics and copy cost.
- `Q: When is a record a better fit than a class?`<br>
  `What to say:` A record is usually better when the type is data-centric and value-based equality matters. A normal class is often better when identity, lifecycle, or mutable domain behavior matters more.<br>
  `Focus on:` value equality vs identity.
- `Q: Why are mutable structs considered risky?`<br>
  `What to say:` Because structs copy by value, mutation can happen on copies instead of the original instance. That leads to subtle bugs when structs are passed around, returned, or exposed through properties.<br>
  `Focus on:` copy semantics causing unexpected mutation behavior.
- `Q: Why is None = 0 a good enum design practice?`<br>
  `What to say:` Because zero is the default value for enums, so giving it a meaningful name makes default-initialized values safer and easier to reason about.<br>
  `Focus on:` default value safety.
- `Q: Are records truly immutable by default?`<br>
  `What to say:` Not deeply. Records make immutable-style modeling easier, but if a record contains mutable members like arrays or lists, those members can still change.<br>
  `Focus on:` shallow vs deep immutability.
- `Q: What is the difference between an interface and an abstract class?`<br>
  `What to say:` An interface defines a capability contract and supports multiple implementation across unrelated types. An abstract class is better when you need shared state or partial implementation in a controlled hierarchy.<br>
  `Focus on:` contract-only capability vs shared base behavior/state.
- `Q: What does nullable reference type syntax actually give you?`<br>
  `What to say:` It gives compile-time annotations and flow analysis that make null intent visible and help the compiler warn earlier. It improves safety, but it does not enforce null correctness at runtime by itself.<br>
  `Focus on:` compile-time guidance, not runtime enforcement.
- `Q: Why can using a struct through an interface hurt performance?`<br>
  `What to say:` Because the struct may be boxed so it can be treated as an interface reference. That introduces allocation and copy overhead and can erase some of the value-type benefits.<br>
  `Focus on:` boxing and dispatch cost.


<div id="statements"></div>

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

## ❓ Probable Interview Questions & Answers

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
```markdown
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
```

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

### **Methods & Parameters Questions**

**Q4: Explain the difference between `ref`, `out`, and `in` parameters**
```markdown
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
```

**Q5: How does method overloading resolution work?**
```csharp
public void Process(object obj) { }
public void Process(string str) { }
public void Process<T>(T item) { }

Process(null);    // Which one gets called?
```

**Answer:**
```markdown
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
```

**Q6: What are the performance implications of `params`?**
```markdown
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
```markdown
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
```markdown
**This won't compile in C#** because assignment returns a value, but C# requires a boolean expression in if statements.

**Correct version**:
```csharp
if (x == 5)  // Comparison, not assignment
{
    Console.WriteLine("True");
}
```

**In C/C++ this would work** and always be true, but C# prevents this common bug.
```

**Q9: Explain this pattern matching code**
```csharp
if (obj is string { Length: > 5 } s)
{
    Console.WriteLine(s.ToUpper());
}
```

**Answer:**
```markdown
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
```

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
```markdown
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
```

---

## 🎯 Key Takeaways for Interviews

1. **Understand the "why"** behind language features, not just the "how"
2. **Know performance implications** of different control flow structures
3. **Master pattern matching** - it's heavily tested in modern C# interviews
4. **Understand parameter passing** nuances - especially value vs reference semantics
5. **Practice explaining complex concepts** with clear, concise examples

This deep understanding will help you answer not just "what" but "why" and "when" questions during interviews.



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

```markdown
### Advanced C# Keywords
* **Yield:** Use for "Streaming" data. Avoid in logic that needs immediate execution.
* **Await:** Use `ConfigureAwait(false)` in library code to avoid context-switching overhead.
* **Lock:** Always lock on a private, dedicated object. Never use `lock(this)`.
* **Using:** Essential for anything that wraps an OS handle (Files, Sockets, DB).
* **Unsafe:** The last resort for performance. Always prefer `Span<T>` over `unsafe` if possible, as `Span` is type-safe and often just as fast.
```


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
```markdown
**This won't compile in C#** because assignment returns a value, but C# requires a boolean expression in if statements.

**Correct version**:
```csharp
if (x == 5)  // Comparison, not assignment
{
    Console.WriteLine("True");
}
```

**In C/C++ this would work** and always be true, but C# prevents this common bug.
```

**Q9: Explain this pattern matching code**
```csharp
if (obj is string { Length: > 5 } s)
{
    Console.WriteLine(s.ToUpper());
}
```

**Answer:**
```markdown
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
```

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
```markdown
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
```

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
```markdown
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
```

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

```

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

```markdown
### Methods & Parameters Summary
* **ref/out/in:** Use to avoid copying large structs or to return multiple values. Use `in` for read-only performance optimization.
* **Local Functions:** Prefer over Lambdas for internal method logic because they are more performant and support `ref/out`.
* **Extension Methods:** Great for "fluent" APIs and keeping models thin. Always place in a specific `.Extensions` namespace.
* **Lambdas:** Use primarily for LINQ or when a delegate/Action/Func is required as a parameter.
```

---


<div id="delegates-and-events"></div>

# Delegates and events

**Delegates** are type-safe pointers to methods, enabling flexible method invocation. They are often used for callbacks, event handling, and implementing the observer pattern. Delegates can point to static or instance methods and can be multicast (pointing to multiple methods).

```csharp
public delegate int Operation(int x, int y);

public int Add(int a, int b) => a + b;
public int Multiply(int a, int b) => a * b;

// Usage
Operation op = Add;
int result = op(3, 4); // 7
op += Multiply; // Multicast delegate
```

**Events** are built on delegates and provide a way for classes to notify subscribers when something happens. Events are typically used in GUI applications and other scenarios where you want to decouple the event source from the event handler.

```csharp:
public class Button
{
    public event EventHandler Clicked;

    protected virtual void OnClicked() =>
        Clicked?.Invoke(this, EventArgs.Empty);
}

// Usage
var button = new Button();
button.Clicked += (sender, args) => Console.WriteLine("Clicked!");
```

**Quick mental model**

- Delegates represent behavior you can call; events represent notifications other code may observe.
- Reach for delegates when you need callback-style composition and events when you need publisher/subscriber ownership boundaries.
- If you expose a delegate directly, outside code can replace or invoke it; if you expose an event, outside code is intentionally more constrained.

**Behind the covers**

- A delegate instance usually stores a target object reference plus a method pointer.
- Multicast delegates maintain an invocation list, so adding handlers effectively creates a new delegate chain.
- Event syntax typically compiles to controlled `add` and `remove` accessors around a backing delegate field.

**Additional resources**:

- [Delegates (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)
- [Events (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/events-overview)

### Interview Prep

**Senior Perspective (The "Why")**

- Delegates model behavior; events model controlled notification.
- That distinction matters because delegates are callable references, while events deliberately restrict who can trigger or replace the invocation list.
- Strong answers connect this topic to callbacks, observer-style design, and ownership boundaries.
- `Good opening answer:` "A delegate is a callable behavior reference; an event is the restricted publication surface built on top of that idea."
- `Then add:` mention ownership, subscription lifetime, and why unsubscribe strategy matters in long-lived publishers.

**Interview Gotchas & Confusion Points**

- Multicast delegates execute handlers in order, but only the last return value is preserved when the delegate returns a value.
- Events are built on delegates, but outside code cannot raise the event directly.
- Event subscriptions can create memory leaks when long-lived publishers keep subscribers alive.
- Candidates often describe delegates and events as the same thing, which sounds shallow in interviews.

**Corner Cases**

- Anonymous lambdas are hard to unsubscribe unless you retain the exact delegate reference.
- One failing event handler can prevent later handlers from running.
- Event invocation in multithreaded code still needs care because subscribers can change during execution.
- Custom delegate types can improve readability when `Func<>` or `Action<>` becomes too generic.

**Behind the Scenes / Internal Logic**

- A delegate instance conceptually stores both the target object and the method to call.
- A multicast delegate keeps an invocation list, which is why multiple handlers can be attached to a single delegate or event.
- An event usually exposes controlled `add` / `remove` accessors so only the declaring type can trigger it directly.

**Must Remember Facts**

- `Action`, `Func`, and `Predicate` cover many common delegate scenarios.
- Delegates are immutable objects.
- `EventHandler` and `EventHandler<TEventArgs>` are the conventional .NET event patterns.
- Events are a constrained, encapsulated delegate-based notification mechanism.

**Question Bank (Common Questions + What to Say)**

- `Q: What is the difference between a delegate and an event?`<br>
  `What to say:` A delegate is a callable reference to methods. An event is a restricted publication mechanism built on delegates, where outside code can usually subscribe and unsubscribe but cannot raise the event directly.<br>
  `Focus on:` behavior pointer vs controlled notification boundary.
- `Q: What is a multicast delegate, and how does its return value behave?`<br>
  `What to say:` A multicast delegate has an invocation list and calls handlers in order. If it has a return type, only the last handler's return value is preserved.<br>
  `Focus on:` invocation list plus last-return-value rule.
- `Q: Why can event subscriptions cause memory leaks?`<br>
  `What to say:` Because the publisher can keep a reference to the subscriber through the delegate. If the publisher lives longer, the subscriber may never be collected unless it unsubscribes.<br>
  `Focus on:` object lifetime and retained references.
- `Q: Why can code subscribe to an event but not invoke it directly?`<br>
  `What to say:` Because events intentionally restrict invocation to the declaring type. That preserves ownership and prevents outside code from arbitrarily firing lifecycle notifications.<br>
  `Focus on:` encapsulation and controlled publication.
- `Q: When would you use a custom delegate type instead of Func<> or Action<>?`<br>
  `What to say:` Use `Func<>` and `Action<>` for generic callback shapes. Use a custom delegate when the signature deserves domain meaning or clearer readability in the API.<br>
  `Focus on:` semantic clarity over raw convenience.

  ### What is a delegate in C#? How is it different from a function pointer in C++?

**Answer:**
### Delegate in C#:
1. **Definition** :
- A delegate in C# is a type that represents references to methods with a particular parameter list and return type. It essentially acts as a function pointer in C#. 
2. **Syntax** :

```csharp
delegate returnType DelegateName(parameters);
```
3. **Usage** :
- Delegates are used to define callback methods and implement event handling, among other things.
- They allow methods to be passed as parameters to other methods.
- They enable defining and using anonymous methods and lambda expressions. 
4. **Example** :

```csharp
delegate int MathOperation(int a, int b);

class Calculator {
    public int Add(int a, int b) {
        return a + b;
    }

    public int Multiply(int a, int b) {
        return a * b;
    }
}

class Program {
    static void Main(string[] args) {
        Calculator calc = new Calculator();
        MathOperation operation = calc.Add;
        int result = operation(5, 3); // result will be 8
    }
}
```
5. **Multicast Delegates** :
- Delegates in C# support multicast, meaning they can reference multiple methods. 
6. **Event Handling** :
- Delegates are widely used in C# for implementing event handling mechanism, where they serve as a way to encapsulate and manage methods that are called when events occur.
### Difference from Function Pointers in C++:
1. **Type Safety** :
- Delegates in C# are type-safe, meaning they are bound to a specific method signature. Attempts to assign a method with a different signature will result in a compile-time error. In contrast, function pointers in C++ are not inherently type-safe. 
2. **Object-Oriented** :
- Delegates in C# are object-oriented and can be associated with instances of classes. They are thus compatible with object-oriented programming principles. Function pointers in C++ are more low-level constructs and lack the object-oriented features of delegates. 
3. **Event Handling** :
- Delegates in C# are often used for event handling, providing a higher level of abstraction and encapsulation compared to function pointers in C++, which are typically used for more low-level operations. 
4. **Syntax** :
- The syntax for declaring and using delegates in C# is different from function pointers in C++. C# provides a more streamlined syntax for defining delegates and working with them, making them easier to use and understand in many cases.

In summary, while both delegates in C# and function pointers in C++ serve similar purposes of referencing methods/functions dynamically, delegates offer additional features such as type safety, object-oriented capabilities, and built-in support for event handling.

---
### Explain the concept of multicast delegates. Provide an example.

**Answer:**
### Multicast Delegates in C#:

Multicast delegates in C# are delegates that can hold references to multiple methods. They allow you to call multiple methods through a single delegate invocation. Multicast delegates are commonly used in scenarios where you want to invoke multiple methods in response to an event or perform multiple operations with a single delegate invocation.
### Example of Multicast Delegates:

```csharp
using System;

delegate void MyDelegate(string message);

class Program
{
    static void Main(string[] args)
    {
        MyDelegate delegate1 = Method1;
        MyDelegate delegate2 = Method2;

        // Combining delegates using the "+" operator
        MyDelegate multicastDelegate = delegate1 + delegate2;

        // Invoking the multicast delegate will call both Method1 and Method2
        multicastDelegate("Hello from multicast delegate!");

        Console.ReadLine();
    }

    static void Method1(string message)
    {
        Console.WriteLine("Method1: " + message);
    }

    static void Method2(string message)
    {
        Console.WriteLine("Method2: " + message);
    }
}
```



In this example: 
- We define a delegate type `MyDelegate` that takes a string parameter. 
- We define two methods `Method1` and `Method2` that match the delegate signature. 
- We create instances of `MyDelegate` using each method. 
- We then combine these delegates into a single multicast delegate `multicastDelegate` using the `+` operator. 
- When we invoke `multicastDelegate`, both `Method1` and `Method2` will be called, and the message will be passed to each method. 
- Running this code will produce the following output:

```vbnet
Method1: Hello from multicast delegate!
Method2: Hello from multicast delegate!
```
### Notes:
- The order of invocation of the methods is the same as the order in which they were combined.
- If any of the methods in the multicast delegate throws an exception, the subsequent methods will not be called, and the exception will propagate back to the caller. 
- You can also remove delegates from a multicast delegate using the `-` operator or the `Delegate.Remove()` method.
- Multicast delegates are commonly used in event handling scenarios where multiple subscribers need to be notified when an event occurs.

---
### What is an event in C#? How is it implemented?

**Answer:**
### Events in C#:

In C#, an event is a mechanism that enables a class or object to notify other classes or objects when something of interest occurs. Events are a key part of the observer design pattern, allowing for loose coupling between components in a system.
### Key Concepts: 
1. **Publisher/Subscriber Model** :
- In the event-driven programming model, there are typically two parties involved: the publisher (or sender) and the subscriber (or receiver).
- The publisher is responsible for raising the event when a particular action or condition occurs.
- The subscriber is interested in receiving notifications about the event and registers itself to handle those notifications. 
2. **Event Declaration** : 
- Events are declared using the `event` keyword in C#.
- Events are based on delegates and can only be invoked from within the declaring class or a derived class.
- Typically, events are declared as members of a class and are often exposed publicly to allow external classes to subscribe to them. 
3. **Event Handlers** :
- Event handlers are methods that are invoked when the event occurs.
- Event handlers are associated with events using delegate types that match the signature of the event.
- Multiple event handlers can be attached to the same event, allowing for multiple subscribers to be notified when the event is raised. 
4. **Publishing Events** : 
- To raise (or publish) an event, the publisher invokes the event using the event invocation syntax (`eventName?.Invoke(this, EventArgs)`).
- The event can include additional information by passing parameters to the event handler method.
### Example of Event Implementation:

```csharp
using System;

// Define custom event arguments if needed
public class CustomEventArgs : EventArgs
{
    public string Message { get; set; }

    public CustomEventArgs(string message)
    {
        Message = message;
    }
}

public class Publisher
{
    // Declare an event using EventHandler delegate
    public event EventHandler<CustomEventArgs> MyEvent;

    public void DoSomething()
    {
        Console.WriteLine("Something is happening...");
        // Raise the event
        OnMyEvent("Event message");
    }

    protected virtual void OnMyEvent(string message)
    {
        MyEvent?.Invoke(this, new CustomEventArgs(message));
    }
}

public class Subscriber
{
    public void Subscribe(Publisher publisher)
    {
        // Subscribe to the event
        publisher.MyEvent += HandleEvent;
    }

    public void HandleEvent(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        // Subscribe to the event
        subscriber.Subscribe(publisher);

        // Trigger the event
        publisher.DoSomething();

        Console.ReadLine();
    }
}
```



In this example: 
- `Publisher` declares an event named `MyEvent` using the `EventHandler<CustomEventArgs>` delegate. 
- `Subscriber` subscribes to the `MyEvent` event by attaching its `HandleEvent` method as an event handler. 
- When `Publisher` calls `DoSomething()`, it raises the `MyEvent`, and all subscribed `Subscriber` instances receive notifications through their `HandleEvent` method.
### Notes:
- Events provide a powerful way to implement the observer pattern, facilitating loosely coupled communication between objects.
- Events are commonly used in GUI programming, asynchronous programming, and many other scenarios where a class needs to notify other classes about changes or occurrences.

---
### How do you subscribe to and unsubscribe from events in C#?

**Answer:**
In C#, subscribing to and unsubscribing from events involves adding and removing event handlers to and from the event. This is typically done using the `+=` operator to subscribe and the `-=` operator to unsubscribe. Here's how you can subscribe to and unsubscribe from events:
### Subscribing to Events:

To subscribe to an event, you attach an event handler method to the event using the `+=` operator.

```csharp
publisher.MyEvent += HandleEvent;
```



In this example, `publisher` is the instance of the class declaring the event, `MyEvent` is the event, and `HandleEvent` is the method that will handle the event.
### Unsubscribing from Events:

To unsubscribe from an event, you detach the event handler method from the event using the `-=` operator.

```csharp
publisher.MyEvent -= HandleEvent;
```



This removes the `HandleEvent` method from the list of event handlers for `MyEvent`.
### Example:

```csharp
public class Subscriber
{
    public void Subscribe(Publisher publisher)
    {
        // Subscribe to the event
        publisher.MyEvent += HandleEvent;
    }

    public void Unsubscribe(Publisher publisher)
    {
        // Unsubscribe from the event
        publisher.MyEvent -= HandleEvent;
    }

    public void HandleEvent(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}
```



In this example, `Subscribe` method subscribes to the event, and `Unsubscribe` method unsubscribes from the event by adding and removing the `HandleEvent` method to and from the event, respectively.
### Notes:
- It's important to properly manage event subscriptions and unsubscriptions to prevent memory leaks and unexpected behavior.
- Subscribing multiple times to the same event with the same handler will result in the handler being invoked multiple times when the event is raised.
- Unsubscribing from an event that hasn't been subscribed to has no effect and won't throw an exception.

---
### Can you explain the concept of event-driven programming in the context of C#?

**Answer:**
Certainly! Event-driven programming is a programming paradigm where the flow of the program is determined by events such as user actions (e.g., mouse clicks, keyboard presses), system notifications, or messages from other programs. In the context of C#, event-driven programming is commonly used in graphical user interface (GUI) applications, web development, and asynchronous programming.
### Key Concepts of Event-Driven Programming in C#: 
1. **Events** :
- Events are occurrences that happen during the execution of a program, such as user actions or system notifications. 
- In C#, events are represented by the `event` keyword and are typically declared as members of classes.
- Events are based on delegates and allow one class (the publisher) to notify other classes (the subscribers) when a specific action or condition occurs. 
2. **Event Handlers** :
- Event handlers are methods that respond to events when they are raised.
- In C#, event handlers are typically methods with a specific signature that matches the delegate associated with the event. 
- Event handlers are attached to events using the `+=` operator and are executed when the event is raised. 
3. **Publishers and Subscribers** :
- In the event-driven programming model, there are typically two parties involved: publishers and subscribers.
- Publishers are responsible for raising events when specific actions or conditions occur.
- Subscribers are interested in receiving notifications about these events and register themselves to handle those notifications. 
4. **Loose Coupling** :
- Event-driven programming promotes loose coupling between components in a system.
- Publishers and subscribers are independent of each other, and the communication between them is facilitated through events.
- This allows for better modularity, scalability, and maintainability of the codebase. 
5. **Asynchronous Programming** :
- Event-driven programming is often used in asynchronous programming models, where code execution is not blocked while waiting for certain operations to complete.
- Asynchronous operations, such as I/O operations or user interactions, are handled through events and event handlers.
### Example:

In a GUI application written in C#, event-driven programming is used to handle user interactions with the interface. For instance, when a user clicks a button on a form, a `Click` event is raised by the button control. The application can subscribe to this event and execute a specific method (event handler) in response to the click event. This allows the application to respond dynamically to user actions without blocking the main thread of execution.

```csharp
button.Click += HandleButtonClick;

void HandleButtonClick(object sender, EventArgs e)
{
    // Perform actions in response to the button click event
}
```



In this example, `HandleButtonClick` is an event handler method that is executed when the `Click` event of the `button` control is raised. This follows the event-driven programming paradigm, where the flow of the program is determined by user actions triggering events and the corresponding event handlers responding to those events.

---
### What are some advantages of using events and delegates in software development?

**Answer:**
Using events and delegates in software development offers several advantages, including:
1. **Loose Coupling** : Events and delegates facilitate loose coupling between components in a system. Publishers and subscribers are decoupled, allowing changes to one component without affecting others. This promotes modularity and easier maintenance of the codebase. 
2. **Flexibility and Extensibility** : Events and delegates enable flexible and extensible architectures. New functionalities can be added by subscribing to existing events or creating new events without modifying existing code. This makes it easier to adapt the system to changing requirements. 
3. **Asynchronous Programming** : Delegates are commonly used in asynchronous programming models to execute code asynchronously without blocking the main thread. This improves responsiveness and scalability, especially in GUI applications and network programming. 
4. **Event-Driven Programming** : Events and delegates are fundamental to event-driven programming paradigms, where the flow of the program is determined by events such as user actions or system notifications. This allows for dynamic and responsive user interfaces and efficient handling of asynchronous operations. 
5. **Decoupling Layers of an Application** : Events and delegates can be used to decouple different layers of an application, such as the presentation layer and the business logic layer. For example, UI elements can raise events that are handled by business logic components, keeping the presentation layer separated from the application logic. 
6. **Testing and Debugging** : Events and delegates facilitate testing and debugging by allowing for easier isolation of components. Mock objects can be used to simulate events and test event handlers independently, improving the testability of the code. 
7. **Cross-Cutting Concerns** : Delegates can be used to implement cross-cutting concerns such as logging, error handling, and authentication. By attaching event handlers to specific events, these concerns can be addressed in a centralized manner without scattering the codebase. 
8. **Encapsulation and Information Hiding** : Events and delegates promote encapsulation and information hiding by allowing objects to expose only the events they want to be publicly accessible. This helps in building more maintainable and scalable systems by hiding implementation details from external components.

Overall, events and delegates are powerful constructs in C# and other programming languages that offer numerous benefits in terms of modularity, flexibility, responsiveness, and maintainability of software systems.

---
### Understanding the lifecycle of delegates and event handlers.

**Answer:**
Understanding the lifecycle of delegates and event handlers involves grasping how they are created, used, and managed throughout the execution of a program. Here's an overview of their lifecycle:
### Delegates: 
1. **Creation** : Delegates are created by defining a delegate type and instantiating it with a method or a lambda expression that matches its signature. 
2. **Invocation** : Delegates can be invoked to execute the method(s) they reference. Multiple methods can be combined into a single delegate using the `+` operator. 
3. **Execution** : When a delegate is invoked, it executes the methods it references in the order they were added. Each method is executed synchronously. 
4. **Completion** : After all methods have been executed, the delegate invocation completes, and control returns to the caller. 
5. **Garbage Collection** : Delegates are reference types and are subject to garbage collection. If no references to a delegate exist, it will be eligible for garbage collection.
### Event Handlers: 
1. **Subscription** : Event handlers are methods that are registered to handle events raised by an object. They are typically subscribed to events using the `+=` operator. 
2. **Execution** : When the event occurs, all registered event handlers are invoked in the order they were subscribed. Event handlers execute synchronously. 
3. **Unsubscription** : Event handlers can be unsubscribed from events using the `-=` operator. This removes them from the list of event handlers, preventing them from being invoked when the event occurs. 
4. **Completion** : After all registered event handlers have been invoked, control returns to the code that raised the event. 
5. **Lifetime Management** : Event handlers can have a shorter lifetime than the object raising the event. If an event handler is not properly unsubscribed, it can lead to memory leaks as the object holding a reference to the event handler prevents it from being garbage collected. 
6. **Thread Safety** : Event handlers should be written with thread safety in mind, especially in multithreaded applications. It's important to consider synchronization mechanisms to ensure proper handling of events in concurrent scenarios.
### Summary:
- Delegates are used to represent references to methods, while event handlers are methods that handle events raised by objects.
- Delegates and event handlers have lifecycles that involve creation, invocation or subscription, execution when triggered, unsubscription, and potential garbage collection.
- Proper management of delegates and event handlers, including subscription and unsubscription, is important to prevent memory leaks and ensure the correct behavior of the application.
- Considerations such as thread safety and lifetime management are crucial when working with event handlers, especially in complex or multithreaded applications.

---
### Best practices for managing memory and preventing memory leaks with delegates.

**Answer:**
Managing memory and preventing memory leaks when working with delegates is crucial for ensuring the stability and performance of your application. Here are some best practices:
### 1. Unsubscribe from Events:
- Always unsubscribe from events when they are no longer needed, especially in long-lived objects or when dynamically subscribing to events.
- Failing to unsubscribe from events can lead to memory leaks because the event source holds a reference to the event handler, preventing garbage collection.
### 2. Use Weak Event Patterns:
- Consider using weak event patterns to prevent memory leaks when subscribing to events.
- Weak event patterns use weak references to the event handlers, allowing them to be garbage collected even if the event source still holds a reference to them.
### 3. Avoid Capturing Unnecessary References:
- Be cautious when capturing references to objects in closures or anonymous methods, especially in long-lived delegates.
- Capturing unnecessary references can inadvertently keep objects alive longer than necessary, leading to memory leaks.
### 4. Implement IDisposable for Custom Delegates:
- If you create custom delegates or types that manage resources, implement the IDisposable interface to properly release resources when they are no longer needed.
- Dispose any resources held by the delegate when it is no longer needed or when the object owning the delegate is disposed.
### 5. Use Weak References:
- Consider using weak references to hold references to objects that are used as event handlers or delegates.
- Weak references allow objects to be garbage collected even if there are other references to them, preventing memory leaks.
### 6. Profile and Monitor Memory Usage:
- Profile and monitor memory usage of your application to detect any memory leaks caused by delegates.
- Use memory profiling tools to identify objects that are being held in memory longer than necessary and investigate potential causes.
### 7. Avoid Circular References:
- Be mindful of circular references between objects and delegates, as they can prevent objects from being garbage collected.
- Break circular references by using weak references or by redesigning the object relationships if necessary.
### 8. Test and Validate:
- Test your application thoroughly to ensure that delegates are properly managed and that no memory leaks occur under different usage scenarios.
- Perform memory leak detection and stress testing to identify any potential issues before deploying your application to production.

By following these best practices, you can effectively manage memory and prevent memory leaks when working with delegates in your applications, leading to improved performance and stability.

---
### How does garbage collection handle delegate instances?

**Answer:**
Garbage collection in .NET manages memory by reclaiming memory that is no longer in use, allowing it to be reused by the application. When it comes to delegate instances, garbage collection treats them like any other reference type objects. Here's how garbage collection handles delegate instances:
### 1. Reference Counting:
- Garbage collection in .NET does not use reference counting to track object lifetimes. Instead, it uses a tracing garbage collector that determines which objects are still reachable by the application.
### 2. Reachability Analysis:
- The garbage collector starts with a set of root objects, such as global variables, local variables, and object references on the stack.
- It then performs reachability analysis to traverse the object graph, identifying objects that are reachable from the roots. Any objects that are not reachable are considered garbage and eligible for collection.
### 3. Delegate Instances and Reachability:
- Delegate instances are considered reachable if they are referenced by root objects, local variables, or other reachable objects in the application.
- If a delegate instance is not reachable from any root object or other reachable objects, it becomes eligible for garbage collection.
### 4. Weak References:
- Weak references can be used to hold references to delegate instances without preventing them from being garbage collected.
- Weak references allow you to maintain a reference to an object while still allowing it to be collected if there are no strong references to it.
### 5. Finalization:
- Before an object is reclaimed by the garbage collector, its Finalize method (if defined) is called for cleanup tasks.
- However, delegate instances do not have finalizers by default, so they do not incur the performance overhead associated with finalization.
### 6. Timing of Garbage Collection:
- Garbage collection occurs periodically based on various factors such as memory pressure, generation sizes, and allocation rates.
- The exact timing of garbage collection is determined by the garbage collector itself and is not under direct control of the application.
### Summary:

Garbage collection in .NET treats delegate instances like any other reference type objects. It relies on reachability analysis to determine whether an object, including delegate instances, is still in use by the application. If a delegate instance is no longer reachable, it becomes eligible for garbage collection, and its memory is reclaimed for future use by the application.

---



<div id="generics"></div>

# Generics

Generics let you define type-safe, reusable classes, methods, and interfaces. They improve code reuse, type safety, and performance by avoiding boxing/unboxing overhead.

## Generic classes

```csharp
public class Repository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public T Get(int index) => _items[index];
}

// Usage
var intRepo = new Repository<int>();
intRepo.Add(42);
int number = intRepo.Get(0);
```

## Generic methods

```csharp
public T Echo<T>(T input) => input;

// Usage
string message = Echo("Hello");
int number = Echo(123);
```

## Constraints

```csharp
public class EmployeeRepository<T> where T : Employee, new()
{
    public T Create() => new T();
}
```

**Quick mental model**

- Generics let you write one abstraction that stays strongly typed for every concrete type it is used with.
- Good generic design is about expressing the minimum contract the implementation really needs, not maximizing cleverness.
- A generic API becomes stronger when its constraints explain what operations are valid and what assumptions are safe.

**Behind the covers**

- `List<int>` and `List<string>` are distinct closed generic types known to the runtime, which is why generics in .NET are not just erased templates.
- Invariant generic types protect type safety by preventing unsafe substitutions like treating `List<string>` as `List<object>`.
- Static fields on a generic type exist separately for each closed type argument combination.

### Interview Prep

**Senior Perspective (The "Why")**

- Generics let you express reusable behavior without giving up type safety.
- They reduce casts, avoid many `object`-style APIs, and often avoid boxing overhead.
- Strong answers frame generics as both a correctness tool and an API-design tool.
- A well-designed generic abstraction makes invalid usage harder at compile time.
- `Good opening answer:` "Generics are mainly about type-safe reuse and compile-time guarantees, with performance as a secondary benefit."
- `Then add:` mention invariance and constraints early, then bring in boxing avoidance and reusable API design as supporting points.

**Interview Gotchas & Confusion Points**

- Generics are invariant by default, so `List<string>` is not a `List<object>`.
- Variance applies only to certain interfaces and delegates.
- Constraint order matters, and `new()` must come last.
- Many candidates know constraint syntax but cannot explain why a constraint exists.

**Corner Cases**

- `default(T)` may be `null`, zero, or a default-initialized struct depending on `T`.
- An unconstrained `T` gives you very limited assumptions about construction, operators, and nullability.
- Static state on generic types is maintained per closed type, such as `Cache<int>` vs `Cache<string>`.
- Generic abstractions can become too vague if constraints do not communicate intent.

**Behind the Scenes / Internal Logic**

- .NET generics are reified at runtime, which means the runtime knows about the actual closed generic type such as `List<int>` vs `List<string>`.
- Constraints are used by the compiler and runtime to decide what operations are legal and what guarantees a generic implementation can rely on.
- Static members on generic types are effectively tracked per closed generic type, which is why `Repository<int>` and `Repository<string>` do not share the same static field values.

**Must Remember Facts**

- Generic method type arguments are often inferred.
- Common constraints include `class`, `struct`, `notnull`, `unmanaged`, and `new()`.
- `where T : new()` requires a public parameterless constructor.
- Type safety, invariance, and constraints are the core interview themes here.

**Question Bank (Common Questions + What to Say)**

- `Q: Why are generics better than using object everywhere?`<br>
  `What to say:` Generics preserve compile-time type safety, reduce casting, and often avoid boxing. They make APIs clearer because the contract says what type the abstraction actually works with.<br>
  `Focus on:` type safety, clarity, and performance.
- `Q: What does invariance mean in C# generics?`<br>
  `What to say:` Invariance means `List<string>` is not assignable to `List<object>` even though `string` is assignable to `object`. The type arguments must match exactly unless variance is explicitly supported.<br>
  `Focus on:` why generic collections are not automatically substitutable.
- `Q: When do covariance and contravariance apply?`<br>
  `What to say:` They apply only to certain interfaces and delegates. Covariance is about returning more specific types safely, and contravariance is about accepting more general input types safely.<br>
  `Focus on:` limited support plus input/output direction.
- `Q: What does where T : new() actually guarantee?`<br>
  `What to say:` It guarantees that `T` has a public parameterless constructor, so the generic code can create an instance with `new T()`.<br>
  `Focus on:` public parameterless construction.
- `Q: What are the risks of using default(T) blindly?`<br>
  `What to say:` You may get `null`, zero, or a default-initialized struct that violates business invariants. It is only safe when you truly understand what `T` can be.<br>
  `Focus on:` default value ambiguity.
- `Q: Why is List<string> not assignable to List<object>?`<br>
  `What to say:` Because generic collections like `List<T>` are invariant. Allowing that conversion would let callers insert an `object` that is not a `string`, which would break type safety.<br>
  `Focus on:` invariance protecting mutation safety.
- `Q: Why do generic constraints matter in interviews?`<br>
  `What to say:` They show that you know how to express the minimum guarantees generic code depends on. A good constraint makes misuse fail at compile time and makes the abstraction more self-documenting.<br>
  `Focus on:` compile-time guarantees and API design.

**Additional resources**:

- [Generics (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)


### Explanation of generics in .NET and their benefits.

**Answer:**
Generics in .NET provide a way to create classes, structures, methods, and interfaces with placeholders for data types. This allows you to write code that can work with any data type while still maintaining type safety. Here's an explanation of generics and their benefits:
### Explanation of Generics: 
1. **Type Parameter** :
- Generics allow you to define placeholders, called type parameters, for data types in classes, methods, structures, and interfaces.
- These type parameters can be used within the generic construct to define the types of parameters, fields, return types, etc. 
2. **Reusability** :
- Generics enable you to write code that can be reused with different data types without having to rewrite the code for each type.
- This promotes code reuse and reduces code duplication, leading to more maintainable and scalable codebases. 
3. **Type Safety** :
- Generics provide compile-time type checking, ensuring that the code is type-safe.
- The compiler enforces type constraints specified on the generic type parameters, preventing runtime errors related to type mismatches. 
4. **Performance** :
- Generics improve performance by avoiding the need for boxing and unboxing operations when working with value types.
- Unlike non-generic code that operates on objects (which requires boxing value types into objects), generic code operates directly on the underlying value types, leading to better performance. 
5. **Code Clarity** :
- Generics improve code clarity and maintainability by making the code more expressive and self-documenting.
- Using generics, you can write code that explicitly states its intention to work with a specific data type, making it easier for other developers to understand and maintain the code.
### Benefits of Generics: 
1. **Flexibility** :
- Generics allow you to write highly flexible code that can adapt to different data types without sacrificing type safety.
- This flexibility makes generics suitable for a wide range of scenarios, from collections and algorithms to data structures and utilities. 
2. **Performance Optimization** :
- By avoiding boxing and unboxing operations, generics improve the performance of code, especially when working with value types.
- This can lead to significant performance improvements in scenarios where performance is critical, such as high-performance computing or large-scale data processing. 
3. **Reduced Code Duplication** :
- Generics enable you to write generic algorithms, data structures, and components that can be reused with different data types.
- This reduces code duplication and promotes a more modular and maintainable codebase by centralizing common functionality. 
4. **Type Safety and Compile-Time Checking** :
- Generics provide type safety and compile-time checking, ensuring that type-related errors are caught at compile time rather than at runtime.
- This helps in identifying and fixing issues early in the development process, reducing the likelihood of runtime errors and improving code reliability. 
5. **Improved Developer Productivity** :
- Generics simplify the development process by allowing developers to write generic code that can be used with various data types.
- This improves developer productivity by reducing the need to write and maintain specialized code for each data type, leading to faster development cycles and shorter time-to-market.

Overall, generics in .NET offer a powerful mechanism for writing reusable, type-safe, and efficient code, leading to improved code quality, performance, and developer productivity. They are a fundamental feature of the .NET framework and are widely used across various domains, from application development to system programming.

---
### Writing generic classes, methods, and interfaces.

**Answer:**
Certainly! Below are examples of how to write generic classes, methods, and interfaces in C#:
### 1. Generic Class:

```csharp
public class GenericClass<T>
{
    private T _value;

    public GenericClass(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }
}
```



In this example, `GenericClass<T>` is a generic class with a single type parameter `T`. The constructor takes a parameter of type `T`, and the `GetValue` method returns the stored value of type `T`.
### 2. Generic Method:

```csharp
public class GenericMethod
{
    public T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}
```



Here, `Max` is a generic method that takes two parameters of type `T`. The `where T : IComparable<T>` constraint ensures that the type `T` implements the `IComparable<T>` interface, allowing comparison between the values.
### 3. Generic Interface:

```csharp
public interface IGenericInterface<T>
{
    T GetValue();
}
```



This is a generic interface `IGenericInterface<T>` with a single type parameter `T`. Any class implementing this interface must provide an implementation for the `GetValue` method, which returns a value of type `T`.
### Usage Examples:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Using generic class
        GenericClass<int> intClass = new GenericClass<int>(10);
        Console.WriteLine("Value: " + intClass.GetValue()); // Output: Value: 10

        // Using generic method
        GenericMethod genericMethod = new GenericMethod();
        Console.WriteLine("Max value: " + genericMethod.Max(5, 10)); // Output: Max value: 10

        // Using generic interface
        class Implementation : IGenericInterface<string>
        {
            public string GetValue()
            {
                return "Hello, world!";
            }
        }

        Implementation implementation = new Implementation();
        Console.WriteLine("Value: " + implementation.GetValue()); // Output: Value: Hello, world!
    }
}
```



In this example, we create instances of the generic class, call the generic method, and implement the generic interface. Each usage demonstrates how generics provide flexibility in working with different data types while maintaining type safety.

---
### Advantages of using generics over non-generic solutions.

**Answer:**
Using generics over non-generic solutions offers several advantages:
### 1. Type Safety: 
- **Generics** : With generics, the compiler enforces type safety at compile time. This ensures that the code operates on the correct data types, reducing the risk of runtime type errors. 
- **Non-Generic** : Non-generic solutions often rely on casting and boxing/unboxing operations, which can lead to runtime type errors if not handled correctly.
### 2. Code Reusability: 
- **Generics** : Generic classes, methods, and interfaces can be reused with different data types without modification. This promotes code reusability and reduces code duplication. 
- **Non-Generic** : Non-generic solutions may require separate implementations for each data type, leading to code duplication and maintenance overhead.
### 3. Performance: 
- **Generics** : Generics improve performance by avoiding boxing and unboxing operations for value types. They operate directly on the underlying data types, leading to better performance. 
- **Non-Generic** : Non-generic solutions may involve unnecessary overhead due to boxing and unboxing operations, especially when working with value types.
### 4. Compile-Time Checking: 
- **Generics** : Generics provide compile-time checking for type constraints and method signatures. This helps in identifying type-related errors early in the development process. 
- **Non-Generic** : Non-generic solutions may rely on runtime type checking, which can lead to errors that are discovered only at runtime.
### 5. Code Clarity and Maintainability: 
- **Generics** : Generics improve code clarity and maintainability by making the code more expressive and self-documenting. They explicitly specify the intended data types, making the code easier to understand and maintain. 
- **Non-Generic** : Non-generic solutions may require additional documentation or comments to clarify the expected data types, leading to less readable code.
### 6. Flexibility: 
- **Generics** : Generics provide flexibility in working with different data types without sacrificing type safety. They allow developers to write highly flexible and adaptable code. 
- **Non-Generic** : Non-generic solutions may be less flexible and require modification to support new data types or scenarios.
### 7. Scalability: 
- **Generics** : Generics facilitate scalable solutions by allowing developers to write generic algorithms, data structures, and components that can be reused and extended as the application evolves. 
- **Non-Generic** : Non-generic solutions may become less scalable as the codebase grows, leading to maintenance challenges and potential performance bottlenecks.

In summary, generics offer several advantages over non-generic solutions, including improved type safety, code reusability, performance, compile-time checking, code clarity, flexibility, and scalability. They are a powerful feature of the .NET framework and are widely used to write efficient, type-safe, and maintainable code.

---
### Understanding generic type constraints (e.g., class, struct, new(), interface).

**Answer:**
Generic type constraints in C# allow you to restrict the types that can be used as type arguments for a generic type parameter. These constraints specify the capabilities or characteristics that the type argument must have. Here are the common generic type constraints:
### 1. `where T : class`: 
- **Description** : Requires the type argument `T` to be a reference type (class). It cannot be a value type. 
- **Example** :

```csharp
public class MyClass<T> where T : class
{
    // Implementation
}
```
### 2. `where T : struct`: 
- **Description** : Requires the type argument `T` to be a value type (struct). It cannot be a reference type. 
- **Example** :

```csharp
public class MyClass<T> where T : struct
{
    // Implementation
}
```
### 3. `where T : new()`: 
- **Description** : Requires the type argument `T` to have a public parameterless constructor. This allows you to create new instances of `T` within the generic type or method. 
- **Example** :

```csharp
public class MyClass<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```
### 4. `where T : <base class>`: 
- **Description** : Requires the type argument `T` to be derived from or implement a specified base class or interface. 
- **Example** :

```csharp
public class MyClass<T> where T : MyBaseClass
{
    // Implementation
}
```
### 5. `where T : <interface>`: 
- **Description** : Requires the type argument `T` to implement a specified interface. 
- **Example** :

```csharp
public class MyClass<T> where T : IDisposable
{
    // Implementation
}
```
### 6. Combining Constraints: 
- You can combine multiple constraints using the `where` keyword and separating them with commas. 
- **Example** :

```csharp
public class MyClass<T> where T : MyBaseClass, IDisposable, new()
{
    // Implementation
}
```
### Usage Examples:

```csharp
public class Repository<T> where T : class
{
    public void Add(T item)
    {
        // Implementation
    }
}

public class Calculator<T> where T : struct
{
    public T Add(T a, T b)
    {
        return (dynamic)a + (dynamic)b;
    }
}

public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```



In these examples: 
- `Repository<T>` accepts only reference types (`class`) as type arguments. 
- `Calculator<T>` accepts only value types (`struct`) as type arguments. 
- `Factory<T>` requires type arguments with a parameterless constructor (`new()`).

---
### How do constraints help in writing more robust and maintainable code?

**Answer:**
Constraints in generic programming help in writing more robust and maintainable code by enforcing rules and requirements on the type arguments used with generic types or methods. Here's how constraints contribute to code robustness and maintainability:
### 1. Type Safety: 
- Constraints ensure that type arguments meet specific criteria, such as being a reference type (`class`) or a value type (`struct`). This prevents unexpected behavior or runtime errors due to incompatible types.
### 2. Encapsulation of Assumptions:
- Constraints encapsulate assumptions about the capabilities or characteristics of type arguments. This makes the code more self-documenting and communicates the intended usage of generic types or methods to other developers.
### 3. Compiler Warnings and Errors:
- Constraints result in compiler warnings or errors if type arguments do not satisfy the specified criteria. This helps in detecting type-related issues early in the development process, leading to fewer bugs and better code quality.
### 4. Improved Readability:
- Constraints improve the readability of code by explicitly stating the requirements for type arguments. Developers can easily understand the constraints and make informed decisions when using generic types or methods.
### 5. Preventing Runtime Errors:
- Constraints prevent runtime errors by ensuring that type arguments possess the necessary capabilities or characteristics required by the generic type or method. This reduces the likelihood of runtime exceptions or crashes due to incompatible types.
### 6. Code Reusability:
- Constraints promote code reusability by specifying generic types or methods that can work with a wide range of type arguments. This reduces code duplication and encourages the creation of generic components that can be reused across different parts of the codebase.
### 7. Ease of Maintenance:
- Constraints make code maintenance easier by providing clear guidelines on the types that can be used with generic types or methods. Developers can quickly understand the constraints and make changes or updates to the code with confidence, knowing that type-related issues are handled appropriately.
### 8. Enforcing Design Contracts:
- Constraints enforce design contracts by specifying the expectations and requirements for type arguments. This helps in designing robust and maintainable software architectures by enforcing consistency and adherence to design principles.

In summary, constraints in generic programming contribute to code robustness and maintainability by enforcing type safety, encapsulating assumptions, providing compiler feedback, improving readability, preventing runtime errors, promoting code reusability, facilitating maintenance, and enforcing design contracts. By leveraging constraints effectively, developers can write more reliable, scalable, and maintainable software solutions.

---
### Examples of using constraints in generic programming scenarios.

**Answer:**
Certainly! Here are some examples of using constraints in generic programming scenarios:
### 1. Repository with Class Constraint:

```csharp
public class Repository<T> where T : class
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T GetById(int id)
    {
        // Implementation
    }
}
```



In this example, `Repository<T>` is a generic class constrained to accept only reference types (`class`). This ensures that only class objects can be stored in the repository.
### 2. Calculator with Struct Constraint:

```csharp
public class Calculator<T> where T : struct
{
    public T Add(T a, T b)
    {
        return (dynamic)a + (dynamic)b;
    }
}
```



Here, `Calculator<T>` is a generic class constrained to accept only value types (`struct`). This ensures that the `Add` method can work with numeric value types like `int`, `float`, `double`, etc.
### 3. Factory with New Constraint:

```csharp
public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```



In this example, `Factory<T>` is a generic class constrained to accept only type arguments with a parameterless constructor (`new()`). This allows the factory to create instances of the specified type using the default constructor.
### 4. Generic Sorting Algorithm with Interface Constraint:

```csharp
public class SortingAlgorithm<T> where T : IComparable<T>
{
    public void Sort(T[] array)
    {
        // Sorting implementation using comparison via IComparable<T>
    }
}
```



Here, `SortingAlgorithm<T>` is a generic class constrained to accept only type arguments that implement the `IComparable<T>` interface. This ensures that the elements of the array can be compared and sorted.
### 5. Data Transformer with Multiple Constraints:

```csharp
public class DataTransformer<TInput, TOutput>
    where TInput : class
    where TOutput : struct
{
    public TOutput Transform(TInput input)
    {
        // Transformation logic from TInput to TOutput
    }
}
```



In this example, `DataTransformer<TInput, TOutput>` is a generic class constrained to accept: 
- `TInput` as a reference type (`class`). 
- `TOutput` as a value type (`struct`).
This allows the transformer to work with reference types as input and value types as output.

These examples demonstrate how constraints in generic programming scenarios enforce requirements and ensure type safety, contributing to more robust and maintainable code.

---
### Explaining covariance and contravariance in the context of generics.

**Answer:**
Covariance and contravariance are concepts related to the inheritance relationships between generic types. They specify how the inheritance relationship between types is preserved when using generic types with different type arguments. These concepts are important in ensuring type safety and flexibility when working with generic types. Let's explore each concept:
### Covariance:

Covariance allows you to use a more derived type (a derived class or interface) as a type argument where a less derived type (a base class or interface) is expected. In other words, it enables you to treat a generic type as more specific than originally specified.

In C#, covariance is supported in scenarios involving interfaces and delegates. It is denoted by the `out` keyword.

Example of covariance with interfaces:

```csharp
public interface IAnimal { }
public class Dog : IAnimal { }
public class Cat : IAnimal { }

public interface IAnimalShelter<out T>
{
    T GetAnimal();
}

public class AnimalShelter<T> : IAnimalShelter<T>
{
    private T _animal;

    public AnimalShelter(T animal)
    {
        _animal = animal;
    }

    public T GetAnimal()
    {
        return _animal;
    }
}
```



In this example, `IAnimalShelter<out T>` is covariant in `T`, meaning that you can use a more derived type (`Dog` or `Cat`) as `T` where `IAnimalShelter<IAnimal>` is expected. This allows for more flexibility when working with generic interfaces.
### Contravariance:

Contravariance allows you to use a less derived type as a type argument where a more derived type is expected. In other words, it enables you to treat a generic type as less specific than originally specified.

In C#, contravariance is supported only in delegate types. It is denoted by the `in` keyword.

Example of contravariance with delegates:

```csharp
public delegate void AnimalHandler<in T>(T animal);

public class AnimalHandlerHelper
{
    public static void HandleAnimal(IAnimal animal)
    {
        Console.WriteLine($"Handling {animal.GetType().Name}");
    }
}
```



In this example, `AnimalHandler<in T>` is contravariant in `T`, meaning that you can use a less derived type (`IAnimal`) as `T` where `AnimalHandler<Dog>` or `AnimalHandler<Cat>` is expected. This allows for more flexibility when passing arguments to delegate methods.
### Summary:
- Covariance allows you to use a more derived type as a type argument.
- Contravariance allows you to use a less derived type as a type argument.
- Covariance is supported in interfaces and return types of methods, while contravariance is supported only in delegate types and method parameter types. 
- Covariance is denoted by the `out` keyword, while contravariance is denoted by the `in` keyword.

---
### Differences between covariance and contravariance in tabular form
Here's a comparison between covariance and contravariance in a tabular form:

| Aspect                   | Covariance                                                                                                                                                                                                | Contravariance                                                                                                                                                                                                                 |
| ------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Definition               | Covariance allows the use of a more derived type (subclass) as the type argument where a less derived type (base class) is expected.                                                                      | Contravariance allows the use of a less derived type (base class) as the type argument where a more derived type (subclass) is expected.                                                                                       |
| Denoted by               | `out` keyword in C#                                                                                                                                                                                       | `in` keyword in C#                                                                                                                                                                                                             |
| Applicable to            | Interfaces and delegates                                                                                                                                                                                  | Delegates                                                                                                                                                                                                                      |
| Example                  | `IEnumerable<out T>`                                                                                                                                                                                      | `Comparison<in T>`                                                                                                                                                                                                             |
| Usage                    | Enables returning a more specific type from a method, such as returning `IEnumerable<Derived>` from a method that specifies `IEnumerable<Base>`.                                                          | Enables passing a less specific type to a method, such as passing `Comparison<Base>` to a method that expects `Comparison<Derived>`.                                                                                           |
| Example Scenario         | A method returning a collection of objects, where the method can return a more specialized collection (e.g., `List<Derived>`) when a less specialized collection (e.g., `IEnumerable<Base>`) is expected. | A method accepting a comparison function, where the method can accept a less specialized comparison function (e.g., `Comparison<Base>`) when a more specialized comparison function (e.g., `Comparison<Derived>`) is expected. |
| Direction of Inheritance | From the more derived type (subclass) to the less derived type (base class).                                                                                                                              | From the less derived type (base class) to the more derived type (subclass).                                                                                                                                                   |
| Use Cases                | Commonly used for read-only scenarios, such as enumerating collections.                                                                                                                                   | Commonly used for write-only or contravariant scenarios, such as passing parameter inputs.                                                                                                                                     |

These differences illustrate how covariance and contravariance provide flexibility when working with generic types, allowing you to write more flexible and reusable code in certain scenarios.


---

### 1. Generics: Classes & Methods
Generics allow you to use a placeholder (usually `T`) for a type.

* **Generic Classes:** `List<T>`, `Repository<T>`. The type is defined when the class is instantiated.
* **Generic Methods:** `public void Swap<T>(ref T a, ref T b)`. The type is inferred or specified when the method is called.

**The "Senior" Detail: Reification**
In .NET, generics are **reified**. This means the runtime knows the type at execution time. 
* If you use `List<int>`, the JIT compiler creates a specialized version of the class optimized for `int` (no boxing).
* If you use `List<string>`, it creates a version for reference types (sharing the same machine code because pointers are the same size).



---

### 2. Constraints (`where T : ...`)
Constraints restrict what types can be used for `T`, allowing you to call specific methods on the object.

| Constraint         | Syntax                  | Meaning                                               |
| :----------------- | :---------------------- | :---------------------------------------------------- |
| **Value Type**     | `where T : struct`      | `T` must be a value type (like `int`, `DateTime`).    |
| **Reference Type** | `where T : class`       | `T` must be a reference type (like `string`, `User`). |
| **Constructor**    | `where T : new()`       | `T` must have a public parameterless constructor.     |
| **Base Class**     | `where T : Entity`      | `T` must inherit from or be `Entity`.                 |
| **Interface**      | `where T : IComparable` | `T` must implement the interface.                     |
| **Not-Null**       | `where T : notnull`     | `T` cannot be a nullable type.                        |

---

### 3. Variance: Invariance, Covariance, Contravariance
This is how "assignment compatibility" works between generic types.

#### A. Invariance (The Default)
By default, generics are invariant. `List<Dog>` is **not** a `List<Animal>`, even if `Dog` inherits from `Animal`. 
* **Why?** Because if you could cast `List<Dog>` to `List<Animal>`, you could try to add a `Cat` to a list of `Dogs`, crashing the app.

#### B. Covariance (`out T`)
Allows you to use a more derived type than originally specified.
* **Keyword:** `out` (Think: Data is only coming **OUT**).
* **Example:** `IEnumerable<out T>`. 
* **Logic:** `IEnumerable<string>` can be treated as `IEnumerable<object>`. This is safe because you can't "Add" to an `IEnumerable`, so you can't break the list's type integrity.

#### C. Contravariance (`in T`)
Allows you to use a more generic type than originally specified.
* **Keyword:** `in` (Think: Data is only going **IN**).
* **Example:** `Action<in T>`, `IComparer<in T>`.
* **Logic:** If you have an `Action<object>` (which can log any object), it is perfectly safe to use it as an `Action<string>`.



---

### 📊 Summary Table for Study Notes

| Term               | Direction                      | Keyword | Example          | Use Case                |
| :----------------- | :----------------------------- | :------ | :--------------- | :---------------------- |
| **Invariance**     | Fixed                          | None    | `List<T>`        | Read/Write collections. |
| **Covariance**     | Specific $\rightarrow$ General | `out`   | `IEnumerable<T>` | Read-only / Producers.  |
| **Contravariance** | General $\rightarrow$ Specific | `in`    | `IComparer<T>`   | Write-only / Consumers. |

---

### 📝 Final Note for your Markdown

```markdown
### Generics & Variance
* **Performance:** Generics avoid boxing/unboxing and allow the JIT to optimize code for specific types.
* **Constraints:** Use `where` to limit `T`. Always use `new()` if your factory needs to instantiate `T`.
* **Covariance (out):** Safe for reading. `IEnumerable<string>` -> `IEnumerable<object>`.
* **Contravariance (in):** Safe for writing/consuming. `Action<object>` -> `Action<string>`.
* **Best Practice:** When designing interfaces, use `out` and `in` markers to make your API more flexible for consumers.
```

---


<div id="classes-and-inheritance"></div>

# Classes 

**Classes** are the foundation of object-oriented programming in C#, serving as blueprints for creating objects that encapsulate data and behavior. 

**Inheritance** is a powerful mechanism that enables code reuse and polymorphism by allowing classes to inherit attributes and methods from parent classes. 

Proper use of these features helps create maintainable, extensible code with clear hierarchies.

## Constructors and initialization

Constructors are special methods that initialize objects. They set initial state, enforce invariants, and can chain to other constructors to share initialization logic. Understanding constructor patterns is essential for creating maintainable class hierarchies.

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Default constructor
    public Person()
    {
        Name = "Unknown";
        Age = 0;
    }
    
    // Parameterized constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    // Static constructor (called once before type is used)
    static Person()
    {
        Console.WriteLine("Person type initialized");
    }
}

// Constructor chaining
public class Employee : Person
{
    public string Department { get; set; }
    
    // Call the base class constructor
    public Employee(string name, int age, string department) 
        : base(name, age)
    {
        Department = department;
    }
    
    // Chain to another constructor in the same class
    public Employee(string name, int age)
        : this(name, age, "General")
    {
    }
}
```

**Quick mental model**

- Constructors are for establishing a valid object, not for doing arbitrary work.
- Prefer constructor parameters for mandatory state, and use object initializers or `init`/`required` members for clearly optional or setup-time-only data.
- If constructor logic becomes heavy, it usually signals missing abstractions or work that belongs in a factory or service instead.

**Behind the covers**

- Object creation begins with memory being default-initialized before constructor logic makes the object valid for normal use.
- Constructor chaining centralizes initialization so multiple constructors do not drift apart over time.
- Static constructors run once per type before first use, and a failure there can poison the type for the rest of the AppDomain/process lifetime.

## Primary constructors (C# 12+)

Primary constructors are a new feature in C# 12 that simplify class initialization by allowing constructor parameters to be defined directly in the class declaration. This reduces boilerplate code and makes the relationship between constructor parameters and class members more explicit.

```csharp
// Class with primary constructor
public class Person(string name, int age)
{
    // Properties initialized by primary constructor parameters
    public string Name { get; } = name;
    public int Age { get; } = age;
    
    // Can use constructor parameters directly in methods
    public string Introduce() => $"My name is {name} and I'm {age} years old";
    
    // Can still have additional constructors
    public Person(string name) : this(name, 0)
    {
        Console.WriteLine("Created a person with default age");
    }
}

// Inheritance with primary constructors
public class Employee(string name, int age, string department) : Person(name, age)
{
    public string Department { get; } = department;
    
    // Using base constructor parameters
    public override string Introduce() => $"{base.Introduce()} working in {department}";
}

// Usage
var alice = new Person("Alice", 30);
var bob = new Employee("Bob", 25, "Engineering");
```

## Inheritance

Inheritance allows a class (derived class) to inherit properties, methods, and events from another class (base class). This promotes code reuse and establishes an "is-a" relationship between classes. In C#, a class can inherit from only one base class but can implement multiple interfaces.

```csharp
// Base class
public class Animal
{
    public string Name { get; set; }
    
    public Animal(string name)
    {
        Name = name;
    }
    
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic animal sound");
    }
    
    // Non-overridable method
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping");
    }
}

// Derived class
public class Dog : Animal
{
    public string Breed { get; set; }
    
    public Dog(string name, string breed) : base(name)
    {
        Breed = breed;
    }
    
    // Override base class method
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
    
    // New method
    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball");
    }
}
```

**Quick mental model**

- Inheritance is about substitutability, not just "I want to reuse some code."
- A derived type should preserve the promises of the base type rather than adding surprising restrictions.
- When the relationship is really "uses" or "has a," composition is usually the safer model.

**Behind the covers**

- A derived instance contains its base-state portion as part of the same object, which is why base behavior and state are always present.
- Base constructor logic runs before derived constructor bodies complete, so derived assumptions may not be valid yet.
- Member hiding with `new` changes name lookup, but it does not change runtime virtual dispatch behavior.

## Abstract classes

Abstract classes serve as incomplete templates that cannot be instantiated directly but must be inherited by concrete classes. They're useful when you want to define common functionality while forcing derived classes to implement specific methods. An abstract class can have both abstract members (without implementation) and concrete members (with implementation).

```csharp
// Abstract class
public abstract class Shape
{
    // Abstract property (must be implemented)
    public abstract double Area { get; }
    
    // Abstract method (must be implemented)
    public abstract double Perimeter();
    
    // Concrete method
    public void PrintInfo()
    {
        Console.WriteLine($"Area: {Area}, Perimeter: {Perimeter()}");
    }
}

// Concrete implementation
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double Area => Width * Height;
    
    public override double Perimeter() => 2 * (Width + Height);
}
```

## Sealed classes and members

Sealed classes prevent inheritance, making them useful for security-sensitive classes or when inheritance would break functionality. Sealed methods prevent further overriding in derived classes, ensuring that specific implementations remain unchanged throughout the inheritance chain.

```csharp
// Sealed class (cannot be inherited)
public sealed class Utility
{
    public static void DoSomething() { }
}

public class Base
{
    // Virtual method that can be overridden
    public virtual void Method1() { }
    
    // Virtual method that can be overridden
    public virtual void Method2() { }
}

public class Derived : Base
{
    public override void Method1() { }
    
    // Sealed method (can't be overridden further in inheritance chain)
    public sealed override void Method2() { }
}

public class Further : Derived
{
    public override void Method1() { } // OK
    // public override void Method2() { } // Error: cannot override sealed method
}
```

## Polymorphism

Polymorphism allows objects to be treated as instances of their parent class rather than their actual type. This enables more flexible and extensible code by letting you write methods that operate on base classes but respond differently based on the actual object type at runtime.

```csharp
// Base class reference can refer to derived class objects
Animal myPet = new Dog("Fido", "Beagle");
myPet.MakeSound(); // Outputs "Woof!"

// Array of base class can hold derived objects
Animal[] animals = new Animal[]
{
    new Dog("Fido", "Beagle"),
    new Cat("Whiskers"),
    new Rabbit("Hopper")
};

// Polymorphic behavior
foreach (Animal animal in animals)
{
    Console.WriteLine($"{animal.Name} says:");
    animal.MakeSound(); // Each animal makes its own sound
}

// Type checking and casting
if (animals[0] is Dog dog)
{
    dog.Fetch(); // Access Dog-specific method
}

// Explicit casting
Dog anotherDog = (Dog)animals[0];
```

**Quick mental model**

- Polymorphism lets callers code against a stable contract while the runtime chooses the correct implementation.
- The real benefit is decoupling callers from concrete types, which makes extension and testing easier.
- Good polymorphism reduces branching in consumers because behavior moves into the types that own it.

**Behind the covers**

- Virtual and interface calls are resolved at runtime based on the actual object instance, not just the variable's static type.
- Casting narrows the view of an object; it does not change the object itself, and invalid casts fail at runtime.
- `sealed override` intentionally closes a customization point lower in the inheritance chain.

When designing class hierarchies, consider these guidelines:
- Use inheritance when there is a true "is-a" relationship between classes
- Prefer composition over inheritance for "has-a" relationships
- Use abstract classes when you want to provide common behavior with forced specialization
- Use sealed classes for security-sensitive code or to prevent unintended inheritance
- Implement interfaces for defining capabilities that can be shared across unrelated classes

**Additional resources:**

- [Classes and objects (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/classes-and-objects)
- [Inheritance (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Abstract classes and methods (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract)
- [Primary constructors (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/primary-constructors)
- [C# object-oriented programming best practices (Microsoft Learn)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming)

### Interview Prep

**Senior Perspective (The "Why")**

- Constructors are where object validity begins.
- Inheritance is a modeling decision about substitutability, not just a reuse tool.
- Composition is often safer than inheritance because it reduces hierarchy fragility and hidden coupling.
- Polymorphism is valuable when consumers should depend on behavior contracts rather than concrete implementations.
- `Good opening answer:` "I think about OOP here in terms of valid object construction, safe substitutability, and whether composition is a better fit than inheritance."
- `Then add:` explain why constructor rules, virtual dispatch, and hierarchy design all affect long-term change safety.

**Interview Gotchas & Confusion Points**

- Calling virtual members from constructors is dangerous because derived state may not be ready yet.
- `new` hides a member; `override` participates in runtime polymorphism.
- Primary constructor parameters are not automatically stored as members.
- Many candidates choose inheritance for reuse when composition would model the relationship better.

**Corner Cases**

- Abstract classes can still contain state, constructors, and concrete methods.
- Static constructor failures can make a type unusable.
- Explicit casts can throw at runtime.
- Sealed overrides intentionally stop further customization lower in the hierarchy.

**Behind the Scenes / Internal Logic**

- Constructor execution flows from base to derived, which is why base-class assumptions can run before derived state is fully initialized.
- Virtual dispatch is resolved at runtime based on the actual object type, not the static variable type.
- Sealing a class or override can help the runtime reason more precisely about calls and enable some optimizations.

**Must Remember Facts**

- Use inheritance only when a true "is-a" relationship exists.
- Keep constructors focused on establishing valid state.
- Prefer composition unless the hierarchy is stable and semantically correct.
- Polymorphism in C# relies on `virtual`, `abstract`, or interface-based dispatch.

**Question Bank (Common Questions + What to Say)**

- `Q: Why is composition often preferred over inheritance?`<br>
  `What to say:` Composition creates looser coupling and avoids fragile hierarchies. Inheritance should be used when a real substitutable "is-a" relationship exists, not just for code reuse.<br>
  `Focus on:` loose coupling and substitutability.
- `Q: What is the risk of calling virtual methods from constructors?`<br>
  `What to say:` The override may run before the derived object has finished initializing, so it can observe incomplete state and behave incorrectly.<br>
  `Focus on:` initialization order.
- `Q: What is the difference between new and override?`<br>
  `What to say:` `override` participates in runtime polymorphism and replaces the virtual base behavior. `new` only hides the member from the perspective of the derived type and does not change virtual dispatch.<br>
  `Focus on:` hiding vs polymorphic replacement.
- `Q: When should you use an abstract class instead of an interface?`<br>
  `What to say:` Use an abstract class when you need shared state or partial implementation. Use an interface when you want to define a capability contract without forcing a class hierarchy.<br>
  `Focus on:` shared implementation/state vs pure contract.
- `Q: What makes a class hierarchy a good fit for polymorphism?`<br>
  `What to say:` A hierarchy is a good fit when derived types can truly be substituted anywhere the base type is expected without breaking assumptions.<br>
  `Focus on:` Liskov-style substitutability.


---

# 🏗️ C# Object-Oriented Design (Senior Level)

## 1. Member Types: The Building Blocks
A class is more than just methods. A Senior Engineer understands the memory and access implications of each:

* **Fields:** The raw data. Usually `private` to maintain encapsulation.
* **Properties:** The "Smart Field." Use for validation or computed values.
* **Methods:** The behavior.
* **Events:** A way for a class to provide notifications (Encapsulated delegates).
* **Nested Types:** Classes defined inside classes. Use only when the inner class is a "helper" strictly for the outer class.
* **Finalizers (`~ClassName`):** Used **only** for cleaning up unmanaged resources. Avoid them if possible; use `IDisposable` instead.

---

## 2. Construction & Execution Flow
When you call `new Derived()`, the CLR follows a strict sequence:

1.  **Static Field Initializers** (Derived → Base).
2.  **Static Constructors** (Base → Derived).
3.  **Instance Field Initializers** (Derived → Base).
4.  **Base Class Constructor** (`base()`).
5.  **Derived Class Constructor** (The body of the derived constructor).

> **🚩 Senior Warning:** Never call a `virtual` method inside a constructor. Because the derived constructor hasn't run yet, an overridden method might try to access fields that are still `null`.



---

## 3. Polymorphism: Static vs. Dynamic
Polymorphism is the ability of an object to take on many forms.

### Static Polymorphism (Compile-Time)
* **Method Overloading:** Same name, different signatures.
* **Generic Specialization:** Different types using the same logic template.

### Dynamic Polymorphism (Runtime)
* **`virtual`**: A method in a base class that **can** be overridden.
* **`abstract`**: A method that **must** be overridden (no base implementation).
* **`override`**: The keyword used in the child to replace the base behavior.
* **`sealed`**: Stops the chain. A `sealed` method cannot be overridden further.

---

## 4. Abstract Classes vs. Interfaces

| Feature          | Abstract Class                  | Interface                                                  |
| :--------------- | :------------------------------ | :--------------------------------------------------------- |
| **Relationship** | "Is-A" (Identity)               | "Can-Do" (Capability)                                      |
| **State**        | Can have fields/variables.      | No state (only properties/methods).                        |
| **Multiple?**    | Only inherit from **one**.      | Can implement **multiple**.                                |
| **Evolution**    | Adding a method breaks nothing. | Adding a method breaks all (unless using Default Methods). |

---

## 5. Composition Over Inheritance (COI)
Inheritance creates a **Tight Coupling**. If the base class changes, the entire tree can break (The "Fragile Base Class" problem).

* **Inheritance:** `class Manager : Employee` (Rigid hierarchy).
* **Composition:** `class Order { private ILogger _logger; }` (Flexible behavior).

### Why Seniors Favor Composition:
1.  **Flexibility:** You can swap the `ILogger` at runtime. You cannot swap a Base Class at runtime.
2.  **Testability:** You can easily inject a "Mock" logger.
3.  **Encapsulation:** The internal workings of the helper class remain hidden from the consumer.

---

## 6. Modern C# Features (12+)
* **Primary Constructors:** `public class User(int id)`. The `id` is available throughout the class body.
* **Required Members:** Use the `required` keyword on properties to force the caller to initialize them without needing a constructor overload.



---

### 📝 Final Note for your Markdown

```markdown
### OOP Design Strategy
* **Favor Composition:** Use Dependency Injection to bring in behavior.
* **Sealed by Default:** Mark classes as `sealed` unless you explicitly designed them to be inherited.
* **Interface Segregation:** Don't create "God Interfaces." Split them so classes only implement what they need.
* **Virtual Table (vtable):** Remember that polymorphism has a tiny performance cost because the CLR has to look up the correct method address at runtime.
```


<div id="collections"></div>

# Collections

Collections in C# provide powerful ways to store, manage, and manipulate groups of related objects. The .NET framework offers various collection types optimized for different scenarios, from simple arrays to complex specialized collections. Choosing the right collection type is essential for writing efficient and maintainable code.

## Collection Expressions (C# 12+)

Collection expressions are a concise way to initialize collections, introduced in C# 12. They provide a unified syntax for creating and initializing different collection types.

```csharp
// Creating collections with the new collection expressions syntax
int[] numbers = [1, 2, 3, 4, 5];                   // Array
List<string> names = ["Alice", "Bob", "Charlie"];  // List
HashSet<char> letters = ['a', 'b', 'c'];           // HashSet
IEnumerable<int> values = [1, 2, 3, 4, 5];         // Target-typed collection expression

// Spread operator - combining collections
int[] moreNumbers = [0, .. numbers, 6];     // [0, 1, 2, 3, 4, 5, 6]
string[] firstThree = [.. names[0..3]];     // ["Alice", "Bob", "Charlie"]

// Pattern matching with collection expressions
bool IsValidPoint(int[] point) => point is [var x, var y] && x >= 0 && y >= 0;
```

## Arrays

Arrays are fixed-size collections of elements of the same type. They provide efficient random access but have a predetermined size that cannot change after creation.

```csharp
// Declaration and initialization
int[] numbers = new int[5];                      // Array of 5 integers with default values (0)
int[] initialized = new int[] { 1, 2, 3, 4, 5 }; // Initialized array
int[] shorthand = { 1, 2, 3, 4, 5 };             // Shorthand initialization
string[] names = { "Alice", "Bob", "Charlie" };

// Accessing elements
int firstNumber = numbers[0];                     // First element (zero-based indexing)
numbers[0] = 10;                                  // Assign value to first element

// Multi-dimensional arrays
int[,] matrix = new int[3, 3];                    // 3x3 2D array
matrix[0, 0] = 1;                                 // Assign to specific position
int[,] initialized2D = {                          // Initialize 2D array
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

// Jagged arrays (arrays of arrays)
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
jagged[2] = new int[] { 6, 7, 8, 9 };

// Array properties and methods
int length = numbers.Length;                      // Number of elements
Array.Sort(numbers);                              // Sort array in-place
Array.Reverse(numbers);                           // Reverse array in-place
int index = Array.IndexOf(names, "Bob");          // Find index of element
bool exists = Array.Exists(numbers, n => n > 10); // Check if condition exists
```

## Lists

Lists are dynamic arrays that can grow or shrink in size. They provide flexibility and are generally the go-to collection type for most scenarios when you need a sequence of elements.

```csharp
using System.Collections.Generic;

// Create a list
List<string> names = new List<string>();          // Empty list
List<int> numbers = new List<int> { 1, 2, 3 };    // Initialized list

// Add elements  
names.Add("Alice");                               // Add single element
names.AddRange(new[] { "Bob", "Charlie" });       // Add multiple elements

// Access elements
string first = names[0];                          // Access by index
names[0] = "Alicia";                              // Modify by index

// Remove elements
names.Remove("Bob");                              // Remove specific element
names.RemoveAt(0);                                // Remove element at index
names.RemoveAll(x => x.StartsWith("C"));          // Remove all that match condition
names.Clear();                                    // Remove all elements

// Search and query
bool contains = numbers.Contains(2);              // Check if contains value
int index = numbers.IndexOf(3);                   // Find index of element
List<int> filtered = numbers.FindAll(n => n > 1); // Find all matching elements
int found = numbers.Find(n => n > 2);             // Find first matching element

// Other operations
int count = numbers.Count;                       // Number of elements
numbers.Sort();                                  // Sort list in-place
numbers.Reverse();                               // Reverse list in-place
numbers.ForEach(n => Console.WriteLine(n));      // Perform action on each element
```

## Dictionary

Dictionaries store key-value pairs for fast lookups by key. They are essential when you need to quickly access values based on unique identifiers.

```csharp
using System.Collections.Generic;

// Create a dictionary
Dictionary<string, int> ages = new Dictionary<string, int>();
Dictionary<string, string> capitals = new Dictionary<string, string>
{
    { "USA", "Washington D.C." },
    { "UK", "London" },
    ["France"] = "Paris"              // Alternative initialization syntax
};

// Add entries
ages.Add("Alice", 30);
ages["Bob"] = 25;                     // Add or update using indexer

// Access values
int aliceAge = ages["Alice"];         // Access by key (throws if not found)
bool success = ages.TryGetValue("Charlie", out int charlieAge); // Safe access

// Check existence
bool containsKey = ages.ContainsKey("Alice");
bool containsValue = ages.ContainsValue(25);

// Remove entries
bool removed = ages.Remove("Bob");

// Iterate through dictionary
foreach (KeyValuePair<string, int> pair in ages)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}

// Or using deconstruction (C# 7.0+)
foreach (var (name, age) in ages)
{
    Console.WriteLine($"{name}: {age}");
}
```

**Quick mental model**

- A dictionary is the right tool when key lookup is the primary access pattern.
- The main design question is not "can I store key-value pairs?" but "do I trust key equality and do I need safe missing-key behavior?"
- Prefer `TryGetValue` when absence is expected and exceptional misses should not become control flow.

**Behind the covers**

- Dictionary lookup depends on `GetHashCode()` plus equality comparison, which is why comparer choice and key immutability matter.
- Mutable keys are dangerous because changing a key's equality-relevant state after insertion can make entries effectively unreachable.
- `ContainsKey(key)` followed by `dictionary[key]` usually performs two lookups; `TryGetValue` often expresses the intent better in one step.

## HashSet

HashSets store unique elements with fast lookup, insertion, and deletion. They're ideal for maintaining collections of unique items or performing set operations.

```csharp
using System.Collections.Generic;

// Create a HashSet
HashSet<int> uniqueNumbers = new HashSet<int>();
HashSet<string> fruits = new HashSet<string> { "Apple", "Banana", "Orange" };

// Add elements
uniqueNumbers.Add(1);                 // Returns true if added
uniqueNumbers.Add(1);                 // Returns false (already exists)
uniqueNumbers.UnionWith(new[] { 2, 3, 4 }); // Add multiple elements

// Check membership
bool contains = fruits.Contains("Apple"); // Fast lookup

// Remove elements
bool removed = fruits.Remove("Banana");

// Set operations
HashSet<int> setA = new HashSet<int> { 1, 2, 3 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5 };

setA.UnionWith(setB);                 // Union: { 1, 2, 3, 4, 5 }
setA.IntersectWith(setB);             // Intersection: { 3 }
setA.ExceptWith(setB);                // Difference: { 1, 2 }
setA.SymmetricExceptWith(setB);       // Symmetric difference: { 1, 2, 4, 5 }

bool isSubset = setA.IsSubsetOf(setB);
bool isSuperset = setA.IsSupersetOf(setB);
```

**Quick mental model**

- A `HashSet<T>` is for uniqueness and fast membership testing, not ordering.
- If your main question is "have I seen this before?" or "is this allowed?", a hash set is usually the right fit.
- Use set operations when the domain is naturally about overlap, difference, or membership rather than manual loops.

**Behind the covers**

- A hash set uses the same core hash/equality idea as a dictionary, but stores only keys rather than key-value pairs.
- `Add` returning `false` is not a failure in the exceptional sense; it simply means the element was already present.
- Just like dictionaries, mutable equality-relevant state on elements can break lookup behavior after insertion.

## Queue and Stack

Queues (FIFO - first in, first out) and Stacks (LIFO - last in, first out) are specialized collections that support specific access patterns common in many algorithms and data processing scenarios.

```csharp
using System.Collections.Generic;

// Queue (First In, First Out)
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");               // Add to end
queue.Enqueue("Second");
queue.Enqueue("Third");

string next = queue.Peek();           // View next item without removing
string dequeued = queue.Dequeue();    // Remove and return next item
int count = queue.Count;              // Number of items
bool contains = queue.Contains("Second");

// Stack (Last In, First Out)
Stack<int> stack = new Stack<int>();
stack.Push(1);                        // Add to top
stack.Push(2);
stack.Push(3);

int top = stack.Peek();               // View top item without removing
int popped = stack.Pop();             // Remove and return top item
int stackCount = stack.Count;         // Number of items
bool stackContains = stack.Contains(2);
```

## LINQ (Language Integrated Query)

LINQ provides powerful query capabilities for collections, making it easier to filter, transform, and aggregate data. It brings database-like query operations to in-memory collections.

```csharp
using System.Linq;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filtering
var evens = numbers.Where(n => n % 2 == 0);        // [2, 4, 6, 8, 10]
var greaterThanFive = numbers.Where(n => n > 5);   // [6, 7, 8, 9, 10]

// Transformation
var doubled = numbers.Select(n => n * 2);          // [2, 4, 6, 8, 10, 12, 14, 16, 18, 20]
var numberObjects = numbers.Select(n => new { Value = n, IsEven = n % 2 == 0 });

// Ordering
var ascending = numbers.OrderBy(n => n);           // [1, 2, 3, ...]
var descending = numbers.OrderByDescending(n => n); // [10, 9, 8, ...]
var complex = numbers.OrderBy(n => n % 3).ThenByDescending(n => n); // Multiple criteria

// Aggregation
int sum = numbers.Sum();                           // 55
int min = numbers.Min();                           // 1
int max = numbers.Max();                           // 10
double average = numbers.Average();                // 5.5
int product = numbers.Aggregate((a, b) => a * b);  // 3628800 (factorial of 10)

// Quantifiers
bool allEven = numbers.All(n => n % 2 == 0);       // false
bool anyEven = numbers.Any(n => n % 2 == 0);       // true
bool containsSeven = numbers.Contains(7);          // true

// Partitioning
var firstThree = numbers.Take(3);                  // [1, 2, 3]
var skipFirstThree = numbers.Skip(3);              // [4, 5, 6, 7, 8, 9, 10]
var takeLast = numbers.TakeLast(2);                // [9, 10]
var skipLast = numbers.SkipLast(2);                // [1, 2, 3, 4, 5, 6, 7, 8]

// Element operations
int first = numbers.First();                       // 1
int firstEven = numbers.First(n => n % 2 == 0);    // 2
int lastOdd = numbers.Last(n => n % 2 != 0);       // 9
int single = numbers.Where(n => n == 5).Single();  // 5

// Grouping
var groups = numbers.GroupBy(n => n % 3);          // Groups by remainder when divided by 3
foreach (var group in groups)
{
    Console.WriteLine($"Remainder {group.Key}: {string.Join(", ", group)}");
}

// Query syntax (alternative to method syntax)
var queryResult = from n in numbers
                  where n > 5
                  orderby n descending
                  select n * 2;
```

**Quick mental model**

- LINQ is best when it makes data transformation intent obvious in a few composable steps.
- The right interview answer is not "LINQ is elegant"; it is "LINQ is useful when clarity outweighs hidden execution cost."
- Choose operators that match your invariant: `Any` for existence, `Single` for exactly one, `First` for first match, and materialization only when you truly need it.

**Behind the covers**

- Query syntax is compiled into method-syntax calls such as `Where`, `Select`, and `OrderBy`.
- On `IEnumerable<T>`, most standard LINQ operators run in-process and many are deferred until enumeration begins.
- Re-enumerating a deferred pipeline can repeat computation, side effects, or I/O-like work from the source sequence.

**Additional resources:**

- [Collections overview (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/collections/)
- [Collection expressions (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/collection-expressions)
- [LINQ (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [IEnumerable and IQueryable](https://dotnettutorials.net/lesson/differences-between-ienumerable-and-iqueryable/)
- [Choosing a collection type (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class)
- [System.Collections.Generic Namespace (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic)

### Interview Prep

**Senior Perspective (The "Why")**

- Collection choice should follow access patterns, not habit.
- You should be able to explain why you want indexed access, uniqueness, fast lookup, ordering, streaming, or queue/stack behavior.
- LINQ is most valuable when it makes transformation intent clearer, not when it hides cost.
- Good collection choices improve both correctness and performance.
- `Good opening answer:` "I choose collections from the access pattern first: sequence, lookup, uniqueness, or query pipeline."
- `Then add:` talk about equality and hashing for `Dictionary` / `HashSet`, and deferred execution for LINQ before quoting performance rules.

**Interview Gotchas & Confusion Points**

- `List<T>.Count` and `Capacity` are different concepts.
- Dictionary indexer access throws for missing keys; `TryGetValue` is often safer.
- Hash-based collections depend on correct equality and hash code behavior.
- Many LINQ operators are deferred, so the query often has not executed yet.
- Arrays are fixed-size, but their elements are still mutable.

**Corner Cases**

- Modifying a collection during enumeration usually breaks the enumerator.
- `Single()` throws when there are zero matches and when there are multiple matches.
- `FirstOrDefault()` can hide missing-data bugs if you never validate the result.
- Re-enumerating a LINQ query can repeat expensive work or produce different results.

**Behind the Scenes / Internal Logic**

- `List<T>` is backed by a dynamic array, so appends are usually cheap but occasional resizes copy data into a larger buffer.
- `Dictionary<TKey, TValue>` and `HashSet<T>` use hashing plus bucket-based lookup, which is why comparer quality and hash distribution matter.
- Many LINQ operators are implemented with iterators and deferred execution, so the pipeline often runs only when enumeration starts.

**Must Remember Facts**

- Use `List<T>` for general ordered collections.
- Use `Dictionary<TKey, TValue>` for fast key-based lookup.
- Use `HashSet<T>` when uniqueness matters.
- Materialize LINQ results with `ToList()` / `ToArray()` if you need stable repeated enumeration.

**Question Bank (Common Questions + What to Say)**

- `Q: How do you choose between List<T>, Dictionary<TKey, TValue>, and HashSet<T>?`<br>
  `What to say:` Choose `List<T>` for ordered sequences, `Dictionary<TKey, TValue>` for key-based lookup, and `HashSet<T>` when uniqueness and membership testing matter.<br>
  `Focus on:` access pattern and data semantics.
- `Q: Why is TryGetValue preferred over direct dictionary indexing in many cases?`<br>
  `What to say:` Because the indexer throws if the key is missing, while `TryGetValue` makes absence part of the normal control flow.<br>
  `Focus on:` safe lookup without exception-driven branching.
- `Q: What does deferred execution in LINQ mean?`<br>
  `What to say:` It means the query definition is built first, but execution usually happens only when you enumerate the result. That can be powerful, but it also means repeated enumeration can repeat work.<br>
  `Focus on:` query definition vs query execution.
- `Q: What is the difference between First, FirstOrDefault, and Single?`<br>
  `What to say:` `First` expects at least one match, `FirstOrDefault` tolerates none, and `Single` asserts exactly one match. The right choice depends on the business invariant you want the code to express.<br>
  `Focus on:` semantics and data expectations, not just syntax.
- `Q: Why can modifying a collection during foreach fail?`<br>
  `What to say:` Most enumerators assume the collection stays stable during iteration. A modification usually invalidates the enumerator and leads to runtime failure.<br>
  `Focus on:` enumerator contract.
- `Q: Why can mutable keys break Dictionary or HashSet behavior?`<br>
  `What to say:` Because lookup depends on hash code and equality. If the key's equality-relevant state changes after insertion, the collection may no longer find it in the expected bucket.<br>
  `Focus on:` stable equality and hash semantics.
- `Q: When is LINQ a bad fit?`<br>
  `What to say:` LINQ is a bad fit when it hides expensive repeated enumeration, allocates unnecessarily in a hot path, or makes simple logic harder to debug than a straightforward loop.<br>
  `Focus on:` clarity first, hidden cost second.


---

# 📦 .NET Collections & LINQ: Senior Study Notes

## 1. The Core Collections
Every collection has a specific trade-off between **Lookup Speed** and **Memory Overhead**.

| Collection            | Underlying Structure   | Lookup (Key/Index) | Insertion | Use Case                            |
| :-------------------- | :--------------------- | :----------------- | :-------- | :---------------------------------- |
| **`Array`**           | Contiguous Memory      | $O(1)$             | $O(n)$    | Fixed size, highest performance.    |
| **`List<T>`**         | Dynamic Array          | $O(1)$             | $O(1)$*   | General purpose (Amortized $O(1)$). |
| **`Dictionary<K,V>`** | Hash Table             | $O(1)$             | $O(1)$    | Fast lookups by unique key.         |
| **`HashSet<T>`**      | Hash Table (Keys only) | $O(1)$             | $O(1)$    | Uniqueness checks, Set logic.       |
| **`Stack/Queue`**     | Array/Link-based       | $O(n)$             | $O(1)$    | LIFO / FIFO processing.             |



---

## 2. Advanced Collection Mechanics

### `List<T>` Capacity & Scaling
When a `List` exceeds its capacity, it allocates a **new, larger array** (usually double the size) and copies the old elements. 
* **Senior Tip:** If you know you will store 1,000 items, initialize with `new List<T>(1000)` to avoid multiple re-allocations and GC pressure.

### `Dictionary` Internals
* **Hashing:** Uses `GetHashCode()` to determine the "bucket."
* **Collisions:** .NET uses **Chaining** (via linked lists/entries) to handle hash collisions.
* **Thread Safety:** `Dictionary` is NOT thread-safe for writes. Use `ConcurrentDictionary<K,V>` for multi-threaded scenarios to avoid race conditions.

### `HashSet<T>`
* Excellent for mathematical set operations: `IntersectWith`, `UnionWith`, and `ExceptWith`.
* Faster than `List.Contains()` because it uses a hash look-up instead of a linear scan ($O(1)$ vs $O(n)$).

---

## 3. Collection Expressions (C# 12)
The newest way to initialize collections using the spread operator `..`.
* **Syntax:** `int[] row0 = [1, 2, 3]; List<int> list = [..row0, 4, 5, 6];`
* **Performance:** The compiler is highly optimized here; it can often determine the final size of the collection at compile-time, preventing multiple internal re-allocations.

---

## 4. LINQ (Language Integrated Query)
LINQ is built on **Deferred Execution** and **Iterators**.

### `IEnumerable` vs `IQueryable`
* **`IEnumerable<T>`:** "In-Memory." The data is already in your app's RAM. Filtering happens in C#.
* **`IQueryable<T>`:** "Out-of-Memory" (Database). Translates C# logic into SQL (via a Provider). 

### The "Senior" Performance Pitfalls
1.  **Multiple Enumeration:** If you call `.Count()` and then a `foreach` on the same LINQ query, the logic runs **twice**. Call `.ToList()` to "materialize" the data if you need to use it multiple times.
2.  **`SelectMany`:** Use this to flatten nested collections (e.g., getting all orders for all customers).
3.  **PLINQ:** `AsParallel()` can speed up CPU-bound operations, but it adds overhead. Never use it for I/O-bound tasks (like database calls).



---

## 5. Summary Note for your Markdown

```markdown
### Collections & LINQ
* **Capacity:** Always set initial capacity for `List` and `Dictionary` if the size is known.
* **Lookup:** Use `HashSet` for existence checks, never `List.Contains`.
* **LINQ:** Remember that `.Where()` and `.Select()` don't run until the `foreach` or `.ToList()`.
* **Value vs Reference:** Be careful with `List<MyStruct>`. Accessing an element `myList[0]` returns a **copy** of the struct, not a reference to the one in the list.
* **Thread Safety:** Use `System.Collections.Concurrent` for shared state.
```

---


<div id="pattern-matching"></div>

# Pattern matching

C# supports various pattern matching techniques for more expressive conditional logic.

## Type patterns

**Type patterns** allow you to check the type of an object and cast it in a single operation. This is particularly useful in `is` expressions and switch statements.

```csharp
// Type pattern - check if object is of a specific type
object value = "Hello";

if (value is string text)
{
    // 'text' is the value cast to string, available in this scope
    Console.WriteLine(text.ToUpper());
}

// Switch expression with type patterns (C# 8.0+)
string GetDisplayName(object item) => item switch
{
    Person p => $"Person: {p.Name}",
    DateTime d => $"Date: {d.ToShortDateString()}",
    int i => $"Number: {i}",
    string s => $"Text: {s}",
    null => "Null value",
    _ => "Unknown type" // Default case
};
```

## Property patterns

**Property patterns** allow you to match properties of an object directly in a pattern. This is useful for filtering or extracting data from complex objects.

```csharp
// Property pattern to match object properties
if (person is { Name: "Alice", Age: >= 30 })
{
    Console.WriteLine("Found Alice who is 30 or older");
}

// Switch expression with property patterns
string GetAgeCategory(Person person) => person switch
{
    { Age: < 13 } => "Child",
    { Age: < 20 } => "Teenager",
    { Age: < 65 } => "Adult",
    _ => "Senior"
};

// Nested property patterns
if (order is { Customer: { Name: "Alice" } })
{
    Console.WriteLine("This is Alice's order");
}
```

## Tuple patterns

**Tuple patterns** allow you to match multiple values at once, making it easy to work with data structures that contain multiple related values.

```csharp
// Tuple pattern
(int x, int y) = (5, 10);

string GetQuadrant(int x, int y) => (x, y) switch
{
    (> 0, > 0) => "First quadrant",
    (< 0, > 0) => "Second quadrant",
    (< 0, < 0) => "Third quadrant",
    (> 0, < 0) => "Fourth quadrant",
    (0, 0) => "Origin",
    (_, 0) => "X-axis",
    (0, _) => "Y-axis"
};
```

## Logical patterns

**Logical patterns** allow you to combine multiple conditions using logical operators like `and`, `or`, and `not`. This is useful for creating complex matching conditions.

```csharp
// 'and', 'or', and 'not' patterns (C# 9.0+)
if (person is { Age: > 20 and < 30, Name: "Alice" or "Bob" })
{
    Console.WriteLine("Person is between 20-30 and named Alice or Bob");
}

// In switch expression
string CheckValue(int value) => value switch
{
    > 0 and < 10 => "Single digit positive",
    >= 10 and < 100 => "Double digit positive",
    < 0 and not -1 => "Negative, but not -1",
    0 or -1 => "Zero or negative one",
    _ => "Other"
};
```

## List patterns (C# 11.0+)

**List patterns** allow you to match against the structure of collections, making it easier to work with arrays and lists.

```csharp
// List pattern in C# 11
var numbers = new[] { 1, 2, 3, 4 };

bool IsFirstTwoPositive(int[] numbers) => numbers is [> 0, > 0, ..];

string DescribeArray(int[] arr) => arr switch
{
    [] => "Empty array",
    [var single] => $"Single item: {single}",
    [var first, var second] => $"Two items: {first}, {second}",
    [var first, .. var middle, var last] => $"Multiple items, starts with {first}, ends with {last}",
    _ => "Unknown pattern"
};
```

## Discard pattern

**Discard patterns (underscore `_`)** allow you to ignore specific values in a pattern match. This is useful when you only care about certain values and want to ignore the rest.

```csharp
// Discard pattern (underscore) to ignore values
string GetSign(int number) => number switch
{
    < 0 => "Negative",
    > 0 => "Positive",
    _ => "Zero"
};

// Multiple discards
(string, int) person = ("Alice", 30);
var (name, _) = person; // Discard the age
```

**Quick mental model**

- Pattern matching is about matching shape and intent directly instead of spelling out the same null/type/property checks manually.
- It works best when each arm represents a meaningful business case rather than a clever language trick.
- Prefer patterns when they reduce accidental complexity, especially in validation, branching, and value computation code.

**Behind the covers**

- The compiler decomposes patterns into runtime tests such as null checks, type checks, relational comparisons, and extraction steps.
- A switch expression is evaluated top to bottom, and once one arm matches, later arms are ignored.
- More advanced patterns still obey ordinary control-flow realities: broad arms shadow narrow arms, and expensive guards still cost runtime work.

### Interview Prep

**Senior Perspective (The "Why")**

- Pattern matching is about shape-based reasoning, not just shorter syntax.
- It lets you combine type checks, null checks, extraction, and branching in one readable place.
- Strong answers explain that pattern matching improves maintainability by making control flow more explicit and often more exhaustive.
- It is especially useful when logic depends on structure rather than just one scalar value.
- `Good opening answer:` "Pattern matching is valuable because it lets me branch on shape and extract data in the same place, which makes control flow more explicit."
- `Then add:` explain when it improves readability over manual casts and null checks, and when a simpler `if` is still clearer.

**Interview Gotchas & Confusion Points**

- Switch arm order matters because the first match wins.
- `not`, `and`, and `or` have precedence rules that candidates often forget.
- Property patterns and list patterns fail to match on `null`; they do not dereference it.
- Many candidates treat `_` as a lazy fallback instead of a deliberate exhaustiveness tool.

**Corner Cases**

- A broad pattern can shadow a more specific pattern below it.
- List patterns require a compatible length/count and indexing shape.
- `is not null` is often safer than `!= null` when equality operators are overloaded.
- Pattern-heavy code can become clever instead of clear if too much logic is packed into one expression.

**Behind the Scenes / Internal Logic**

- The compiler lowers pattern matching into combinations of type checks, null checks, comparisons, and extraction logic.
- Switch arms are evaluated top to bottom, so order directly affects which branch wins.
- List patterns work by checking length/count and then matching elements by position.

**Must Remember Facts**

- Switch expressions are ideal when you are computing a value from input shape or state.
- Pattern matching can replace manual casts plus null checks cleanly.
- Exhaustiveness and readability matter more than showing off advanced syntax.
- `_` should be intentional, not automatic.

**Question Bank (Common Questions + What to Say)**

- `Q: Why is pattern matching more than just syntax sugar?`<br>
  `What to say:` Because it combines checking, extraction, and branching into one construct. That often makes the code more explicit, more exhaustive, and easier to review for correctness.<br>
  `Focus on:` readability plus correctness.
- `Q: What is the difference between a type pattern and a property pattern?`<br>
  `What to say:` A type pattern checks the runtime type and can bind a typed variable. A property pattern goes further and matches object structure or property values directly.<br>
  `Focus on:` type identity vs object shape.
- `Q: Why does switch arm order matter?`<br>
  `What to say:` Because switch arms are matched top to bottom, and the first matching arm wins. A broad pattern can accidentally shadow a more specific one below it.<br>
  `Focus on:` evaluation order.
- `Q: What are the precedence rules for not, and, and or?`<br>
  `What to say:` `not` binds first, then `and`, then `or`. If the expression is nontrivial, add parentheses for clarity instead of relying on memory.<br>
  `Focus on:` precedence plus readability.
- `Q: When is a switch expression better than if/else?`<br>
  `What to say:` When you are computing a value from input shape or state and want the mapping to be compact and exhaustive. `if/else` is better when the control flow is less uniform.<br>
  `Focus on:` value mapping and exhaustiveness.

<div id="exceptions"></div>

# Exceptions

Exception handling is a critical aspect of robust C# applications, which allows you to manage errors and unexpected conditions. Well-designed exception handling balances providing useful feedback to users, maintaining application stability, and preserving valuable diagnostic information for developers.

## Try-catch-finally

The try-catch-finally pattern forms the backbone of exception handling in C#. Code that might throw exceptions is placed in the `try` block, specific exception types are caught and handled in `catch` blocks, and cleanup code that should always execute (regardless of exceptions) goes in the `finally` block.

```csharp
try
{
    // Code that might throw an exception
    int result = 10 / 0; // Will throw DivideByZeroException
    File.ReadAllText("nonexistent.txt"); // Will throw FileNotFoundException
}
catch (DivideByZeroException ex)
{
    // Handle specific exception
    Console.WriteLine($"Math error: {ex.Message}");
    // Log the exception details for developers
    Logger.LogError(ex, "Division by zero occurred");
    // Provide user-friendly message
    ShowUserErrorMessage("A calculation error occurred. Please try different input values.");
}
catch (FileNotFoundException ex) when (ex.FileName.Contains("nonexistent"))
{
    // Exception filter (C# 6.0+) allows conditionals to catch blocks
    Console.WriteLine($"File not found: {ex.FileName}");
}
catch (IOException ex)
{
    // Handle another specific exception
    Console.WriteLine($"IO error: {ex.Message}");
}
catch (Exception ex)
{
    // Catch all other exceptions
    Console.WriteLine($"Unexpected error: {ex.Message}");
    throw; // Re-throw the exception to preserve stack trace
}
finally
{
    // Code that always executes, whether an exception occurred or not
    Console.WriteLine("This always runs");
    // Common cleanup operations:
    // - Close file handles
    // - Release database connections
    // - Dispose of unmanaged resources
    // - Return pooled objects
}
```

## When to use different Exception approaches

1. **Specific vs. general Exception catching**:
   - Catch specific exceptions when you can handle them in a meaningful way
   - Only catch `Exception` as a last resort to log unexpected errors or provide generic fallbacks
   - Avoid empty catch blocks that swallow exceptions without handling them

2. **Exception filters**:
   - Use when you only want to catch exceptions that meet certain criteria
   - Helps avoid unnecessary exception handling and maintain more precise control flow

3. **Re-throwing Exceptions**:
   - Use `throw;` (without specified exception) to preserve the original stack trace
   - Only use `throw ex;` when you want to deliberately reset the stack trace (rarely needed)

4. **Exception prevention**:
   - Use `TryParse` patterns and null checking to prevent exceptions when possible
   - Reserve exception handling for truly exceptional conditions, not for normal control flow
   - Consider validation before operations that might throw exceptions

## Throwing Exceptions

Throwing exceptions should be done deliberately and with consideration for the calling code. This includes choosing appropriate exception types, providing meaningful messages, and including relevant context.

```csharp
// Throw exceptions
void ProcessData(string data)
{
    if (data == null)
    {
        throw new ArgumentNullException(nameof(data), "Data cannot be null.");
    }
    
    if (data.Length == 0)
    {
        throw new ArgumentException("Data cannot be empty.", nameof(data));
    }
    
    if (!IsValidFormat(data))
    {
        throw new FormatException($"Data '{data}' is not in the required format.");
    }
    
    // Process valid data...
}

// Rethrowing exceptions
try
{
    ProcessData(null);
}
catch (Exception ex)
{
    // Log the exception
    Console.WriteLine($"Error: {ex.Message}");
    
    // Preserve stack trace when rethrowing
    throw;
    
    // This would reset the stack trace (usually undesirable):
    // throw ex;
}
```

## Guidelines for Exception types:

1. **System.ArgumentException**: Use when a method argument is invalid
2. **System.ArgumentNullException**: Use when an argument is unexpectedly null
3. **System.InvalidOperationException**: Use when the object state doesn't allow the operation 
4. **System.NotImplementedException**: Use for methods that aren't implemented yet
5. **System.NotSupportedException**: Use for operations that won't be implemented
6. **System.IO.IOException**: Use for file system and I/O errors
7. **System.FormatException**: Use when string format is incorrect for the expected type
8. **Custom exceptions**: Create when built-in exceptions don't appropriately describe your error

## Custom Exceptions

Custom exceptions allow you to create domain-specific error types that provide more meaningful context about what went wrong in your application. They should be created when built-in exception types don't adequately capture the specific error condition.

```csharp
// Define custom exception
public class CustomerNotFoundException : Exception
{
    public int CustomerId { get; }
    
    public CustomerNotFoundException(int customerId)
        : base($"Customer with ID {customerId} was not found")
    {
        CustomerId = customerId;
    }
    
    public CustomerNotFoundException(int customerId, Exception innerException)
        : base($"Customer with ID {customerId} was not found", innerException)
    {
        CustomerId = customerId;
    }
    
    // For serialization support (important for distributed applications)
    protected CustomerNotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
        CustomerId = info.GetInt32(nameof(CustomerId));
    }
    
    // Override GetObjectData for proper serialization
    public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(CustomerId), CustomerId);
    }
}

// Usage
void ProcessCustomer(int customerId)
{
    if (!customerDatabase.Exists(customerId))
    {
        throw new CustomerNotFoundException(customerId);
    }
    
    // Process customer...
}
```

**Quick mental model**

- Exceptions communicate that the normal contract could not be honored and the caller must react differently.
- They are best for exceptional failures, violated invariants, and boundary-crossing error propagation with context.
- Catch exceptions where you can add context, translate responsibility, or recover meaningfully, not just where you happen to have a `try` block.

**Behind the covers**

- Throwing stops normal linear execution and starts stack unwinding until a matching handler is found.
- Each layer that wraps an exception should either preserve the original as `InnerException` or rethrow without destroying the stack trace.
- Exception filters decide catch eligibility before the catch body runs, which is why they are cleaner than catching and re-checking inside the block.

## Performance considerations

Exception handling has performance implications that should be considered in your design:

1. The `try` block itself has minimal overhead when no exceptions occur
2. Throwing and catching exceptions is relatively expensive and should not be used for normal control flow
3. Use patterns like `TryParse` and null checking to avoid throwing exceptions in expected scenarios
4. Reserve exceptions for truly exceptional conditions that shouldn't happen in normal operation
5. Consider using status return codes or `Result<T>` pattern for expected error conditions in performance-critical code

**Additional resources:**

- [Exception handling (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)
- [Best practices for Exceptions (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)
- [Creating and throwing Exceptions (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions)
- [IDisposable pattern (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)
- [Exception handling in async code (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/exception-handling-task-asynchronous-pattern)

### Interview Prep

**Senior Perspective (The "Why")**

- Exceptions are for exceptional paths, violated assumptions, and failures that need to cross boundaries with context.
- Strong answers talk about recovery boundaries, observability, logging, and preserving diagnostic value.
- Exception design is part of API design because it shapes how callers react to failure.
- The goal is not just to catch errors, but to fail in a way that is debuggable and intentional.
- `Good opening answer:` "I use exceptions for exceptional failures and violated assumptions, not for expected branch logic."
- `Then add:` say where recovery should happen, why stack traces matter, and when built-in exception types are clearer than custom ones.

**Interview Gotchas & Confusion Points**

- `throw;` preserves the original stack trace; `throw ex;` resets it.
- Catching `Exception` too low in the stack can hide bugs and mix concerns.
- Exception filters run before the catch block handles the exception.
- Candidates often use exceptions for normal control flow when `TryParse`-style patterns would be better.
- Custom exceptions are often overused where built-in types would be clearer.

**Corner Cases**

- `finally` runs even when `return` executes.
- Awaiting a faulted task usually surfaces the original exception directly.
- Wrapping exceptions without preserving the inner exception destroys context.
- Silent catch blocks create debugging blind spots and operational risk.

**Behind the Scenes / Internal Logic**

- Throwing an exception captures stack information and unwinds control flow, which is why throwing is much more expensive than ordinary branching.
- A `try` block by itself is usually cheap; the real cost appears when an exception is actually thrown.
- Exception filters are evaluated before entering the catch body, which helps preserve useful diagnostic context.

**Must Remember Facts**

- Use the `ArgumentException` family for bad caller input.
- Use `InvalidOperationException` for invalid object state.
- Keep exception messages actionable and specific.
- Exceptions should not be the normal branching path for expected failures.

**Question Bank (Common Questions + What to Say)**

- `Q: What is the difference between throw; and throw ex;?`<br>
  `What to say:` `throw;` preserves the original stack trace, while `throw ex;` resets it. In almost all rethrow scenarios, `throw;` is the correct answer.<br>
  `Focus on:` preserving debugging context.
- `Q: When should you catch a specific exception vs Exception?`<br>
  `What to say:` Catch a specific exception when you can actually handle it meaningfully. Catch `Exception` only at broad boundaries for logging, fail-safe handling, or process-level control.<br>
  `Focus on:` meaningful handling, not blanket catching.
- `Q: Why are exceptions bad for normal control flow?`<br>
  `What to say:` Because they are expensive relative to normal branching and they blur the difference between expected business outcomes and exceptional failure.<br>
  `Focus on:` cost plus semantic misuse.
- `Q: When should you create a custom exception?`<br>
  `What to say:` Create one when built-in exception types do not express the domain failure clearly enough and when the custom type adds useful meaning for handling or diagnostics.<br>
  `Focus on:` domain meaning, not class explosion.
- `Q: What is the purpose of finally?`<br>
  `What to say:` `finally` exists to guarantee cleanup logic runs whether the operation succeeds, fails, or returns early.<br>
  `Focus on:` deterministic cleanup.
- `Q: What is the difference between an exception filter and checking inside catch?`<br>
  `What to say:` An exception filter decides whether the catch applies before the catch body runs, which preserves cleaner control flow and better diagnostic behavior. Catching first and then branching is usually noisier and less precise.<br>
  `Focus on:` pre-catch filtering and cleaner handling.



### 1. The Internal Mechanics (How the CLR Handles It)

When an exception is thrown, the CLR doesn't just "jump" to a catch block. It performs a **Two-Pass Search**:

1.  **Pass 1 (Stack Walk):** The CLR searches up the call stack for a matching `catch` block. It looks for a handler that matches the exception type or a `when` filter.
2.  **Pass 2 (Unwinding):** Once a handler is found, the CLR "unwinds" the stack. It executes all `finally` blocks between the point of the throw and the catch block, then passes control to the handler.



---

### 2. Performance Implications
Exceptions are **expensive**. They should never be used for "control flow" (e.g., using an exception to break out of a loop).

* **Allocation:** Throwing an exception allocates a significant amount of memory on the heap to store the `StackTrace`, `Data` dictionary, and message.
* **CPU Overhead:** Capturing the stack trace (the filenames, method names, and line numbers) requires the CLR to pause and inspect the metadata of every frame on the stack.
* **The "Senior" Rule:** Use the **Tester-Doer Pattern** or **Try-Parse Pattern** to avoid exceptions.
    * *Bad:* `try { int.Parse(s); } catch { ... }`
    * *Good:* `if (int.TryParse(s, out var result)) { ... }`

---

### 3. Try-Catch-Finally: The Nuances

* **`catch` Filters (`when`):** Introduced in C# 6. Using `catch (Exception ex) when (ex.HttpCode == 404)` is better than catching and re-throwing inside the block. Why? Because `when` filters happen during **Pass 1**. If the condition isn't met, the stack isn't unwound yet, preserving the original state for debugging.
* **`finally`:** Guaranteed to run unless the process is killed (`Environment.FailFast`) or there is a `StackOverflowException`. Use it for manual resource cleanup if `using` isn't applicable.

---

### 4. Throwing Exceptions: `throw` vs `throw ex`
This is a common interview question:
* **`throw;`**: Re-throws the original exception and **preserves the stack trace**. Use this inside a catch block.
* **`throw ex;`**: Resets the stack trace to the current line. It "hides" where the error actually started. **Avoid this.**

---

### 5. Custom Exceptions
Only create a custom exception if you expect the caller to **handle it differently** than a standard exception.
* **Naming:** Always suffix with `Exception`.
* **Serialization:** If your code runs across AppDomains or Remoting, ensure the exception is `[Serializable]`.
* **Constructors:** Always provide the four standard constructor overloads (empty, message, message+inner, and serialization).

---

### 6. The "Right Way" (Senior Principles)

1.  **Catch only what you can handle:** Don't use `catch (Exception)` unless you are at the very top level of the app (e.g., a global error logger). 
2.  **Throw meaningful types:** Throw `ArgumentNullException` rather than a generic `Exception`.
3.  **Clean up in `finally` or `using`:** Ensure database connections and file handles are closed even if an error occurs.
4.  **Enrich your exceptions:** Use the `.Data` property of an exception to add context (like a UserID or OrderID) that will help in post-mortem debugging.
5.  **Fail Fast:** If the system is in an unrecoverable state (e.g., corrupted configuration), don't try to catch it. Let it crash so it doesn't corrupt data.

---

### 📝 Final Note for your Markdown

```markdown
### Exception Best Practices
* **Performance:** Exceptions cost ~100x more than a simple `if` check. Use them for *Exceptional* cases, not validation.
* **Stack Trace:** Use `throw;` to keep the original error source visible.
* **Catch Filters:** Use `when` to avoid unwinding the stack unnecessarily.
* **Custom Exceptions:** Only create them for specific domain errors that require custom recovery logic.
* **Global Handler:** Use a single global exception handler in ASP.NET Core / WebAPI to log errors and return a clean JSON response to the user.
```

---


<div id="asynchronous-programming"></div>

# Asynchronous Programming

Asynchronous programming in C# allows you to write non-blocking code that can improve responsiveness and throughput, particularly in I/O-bound and network operations. Modern C# provides elegant syntax with async/await that makes asynchronous code almost as straightforward to write as synchronous code, while maintaining the performance benefits.

## When to use asynchronous programming

Understanding when to use async code is crucial. Use async code for **I/O-bound operations**:
- Network requests
- Database operations
- File system operations
- Web API calls
- User input

Don't use it for **CPU-bound operations**. For computationally intensive work, use:
- `Task.Run` to offload work to a background thread
- Parallel processing APIs for data parallelism

## Async and await basics

```csharp
// Async method declaration
public async Task<string> DownloadDataAsync(string url)
{
    // Create HTTP client
    using HttpClient client = new HttpClient();
    
    // Asynchronously wait for the HTTP request
    string result = await client.GetStringAsync(url);
    
    return result;
}

// Calling async methods
public async Task ProcessDataAsync()
{
    Console.WriteLine("Starting data download...");
    
    // Await the asynchronous operation
    string data = await DownloadDataAsync("https://example.com/api/data");
    
    Console.WriteLine($"Downloaded {data.Length} bytes");
}

// Void async methods (event handlers)
public async void Button_Click(object sender, EventArgs e)
{
    try
    {
        await ProcessDataAsync();
        MessageBox.Show("Download complete!");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

## Guidelines for async methods:

1. **Naming convention**: Append "Async" to method names that return Task or Task<T>
2. **Return types**:
    - Use Task<T> for methods that return a value
    - Use Task for methods that don't return a value
    - Avoid async void except for event handlers
3. **Async all the way**: Convert entire call chains to async to avoid blocking
4. **ConfigureAwait**: Use ConfigureAwait(false) in library code to avoid forcing context

## Task-based asynchronous pattern

The Task-based asynchronous pattern (TAP) is the recommended approach for asynchronous programming in C#. It uses `Task` and `Task<T>` to represent ongoing work and provides rich composition capabilities.

```csharp
// Create and return a Task
public Task<int> CalculateAsync(int a, int b)
{
    return Task.Run(() =>
    {
        // Simulate CPU-bound work
        Thread.Sleep(1000);
        return a + b;
    });
}

// Task.WhenAll - run multiple tasks in parallel
public async Task ProcessMultipleAsync()
{
    Task<string> task1 = DownloadDataAsync("https://example.com/api/1");
    Task<string> task2 = DownloadDataAsync("https://example.com/api/2");
    Task<string> task3 = DownloadDataAsync("https://example.com/api/3");
    
    // Wait for all tasks to complete
    string[] results = await Task.WhenAll(task1, task2, task3);
    
    // Process results
    foreach (string result in results)
    {
        Console.WriteLine($"Result length: {result.Length}");
    }
}

// Task.WhenAny - wait for the first task to complete
public async Task<string> GetFastestResponseAsync()
{
    Task<string> task1 = DownloadDataAsync("https://example.com/api/1");
    Task<string> task2 = DownloadDataAsync("https://example.com/api/2");
    
    // Wait for the first task to complete
    Task<string> completedTask = await Task.WhenAny(task1, task2);
    
    // Get the result from the completed task
    return await completedTask;
}
```

When to use different task composition methods:
1. **Task.WhenAll**: Use when you need the results of all operations and they can run concurrently
2. **Task.WhenAny**: Use for implementing timeouts, racing operations, or taking the first available result
3. **Task.Run**: Use for CPU-bound work that needs to be offloaded from the current thread
4. **Task.Delay**: Use for implementing timeouts or periodic operations in async methods

## Exception handling in async code

```csharp
public async Task ExceptionHandlingExampleAsync()
{
    try
    {
        // Multiple awaits in one try block
        string data = await DownloadDataAsync("https://example.com/api/data");
        int result = await ProcessDataAsync(data);
        await SaveResultAsync(result);
    }
    catch (HttpRequestException ex)
    {
        // Handle network-related exceptions
        Console.WriteLine($"Network error: {ex.Message}");
    }
    catch (JsonException ex)
    {
        // Handle JSON parsing exceptions
        Console.WriteLine($"Invalid data format: {ex.Message}");
    }
    catch (Exception ex)
    {
        // Handle all other exceptions
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}

// Aggregate exceptions with Task.WhenAll
public async Task HandleMultipleExceptionsAsync()
{
    var tasks = new List<Task>();
    
    for (int i = 0; i < 5; i++)
    {
        int taskNumber = i;
        tasks.Add(Task.Run(async () =>
        {
            if (taskNumber % 2 == 0)
            {
                await Task.Delay(100);
                throw new Exception($"Task {taskNumber} failed");
            }
        }));
    }
    
    try
    {
        await Task.WhenAll(tasks);
    }
    catch (Exception)
    {
        // Check for all exceptions
        foreach (var task in tasks)
        {
            if (task.Exception != null)
            {
                Console.WriteLine(task.Exception.InnerException.Message);
            }
        }
    }
}
```

## Async exception handling best practices:

1. Always handle exceptions in async methods, especially in async void methods
2. Be aware that awaiting `Task.WhenAll` can surface a single failure even when multiple tasks fault; inspect the returned task or individual tasks when you need the full exception set
3. Use `AggregateException.Flatten()` to simplify handling multiple exceptions
4. Consider using a global exception handler for unhandled exceptions in async code
5. Remember that exceptions in async methods are captured and placed on the returned Task

## Cancellation in async operations

Cancellation allows long-running operations to be stopped gracefully. The `CancellationToken` mechanism provides a standardized way to implement cancellation in async methods.

```csharp
public async Task DemonstrateCancellationAsync()
{
    // Create cancellation token source
    using CancellationTokenSource cts = new CancellationTokenSource();
    
    // Set timeout after 5 seconds
    cts.CancelAfter(TimeSpan.FromSeconds(5));
    
    try
    {
        await LongRunningOperationAsync(cts.Token);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Operation was canceled");
    }
}

public async Task LongRunningOperationAsync(CancellationToken cancellationToken)
{
    for (int i = 0; i < 100; i++)
    {
        // Check cancellation before doing work
        cancellationToken.ThrowIfCancellationRequested();
        
        // Perform some work
        Console.WriteLine($"Working on step {i}");
        
        // Wait with cancellation support
        await Task.Delay(100, cancellationToken);
    }
}

// Example of cancelling a web request
public async Task<string> DownloadWithTimeoutAsync(string url, TimeSpan timeout)
{
    using CancellationTokenSource cts = new CancellationTokenSource(timeout);
    using HttpClient client = new HttpClient();
    
    try
    {
        return await client.GetStringAsync(url, cts.Token);
    }
    catch (OperationCanceledException)
    {
        throw new TimeoutException($"The request to {url} timed out after {timeout.TotalSeconds} seconds");
    }
}
```

## ValueTask and async streams (C# 8.0+)

`ValueTask` and async streams are newer features that enhance async programming in specific scenarios by improving performance and extending the asynchronous model to sequences.

```csharp
// ValueTask for potentially synchronous, high-performance scenarios
public ValueTask<int> GetValueAsync(bool alreadyCached, int cachedValue)
{
    if (alreadyCached)
    {
        // Return immediately without allocating a Task
        return new ValueTask<int>(cachedValue);
    }
    
    // Fall back to async path
    return new ValueTask<int>(GetValueSlowlyAsync());
}

private async Task<int> GetValueSlowlyAsync()
{
    await Task.Delay(100);
    return 42;
}

// Async streams with IAsyncEnumerable
public async IAsyncEnumerable<string> GetDataStreamAsync(
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
{
    for (int i = 0; i < 10; i++)
    {
        // Check cancellation
        cancellationToken.ThrowIfCancellationRequested();
        
        // Simulate work
        await Task.Delay(100, cancellationToken);
        
        // Yield a result
        yield return $"Item {i}";
    }
}

// Consuming async streams
public async Task ConsumeAsyncStreamAsync()
{
    await foreach (string item in GetDataStreamAsync())
    {
        Console.WriteLine(item);
    }
    
    // With cancellation
    using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
    
    try
    {
        await foreach (string item in GetDataStreamAsync().WithCancellation(cts.Token))
        {
            Console.WriteLine(item);
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Stream processing was canceled");
    }
}
```

**Quick mental model**

- Async is about releasing threads while work is waiting, especially for network, file, and database operations.
- A `Task` represents an operation, not a thread; that distinction matters in interviews.
- The strongest async answers talk about end-to-end design: propagation of cancellation, exception flow, context capture, and avoiding sync-over-async.

**Behind the covers**

- The compiler turns `async` methods into state machines that resume after each awaited operation completes.
- An incomplete await registers continuation logic and returns control; a completed await may continue synchronously without extra scheduling.
- `Task.WhenAll` composes completion of multiple tasks, but each underlying task still tracks its own status and exception state.

### Interview Prep

**Senior Perspective (The "Why")**

- Async is mainly about freeing threads during I/O waits, not making everything faster.
- Strong answers connect async to responsiveness, throughput, cancellation, and API design across the full call chain.
- Async boundaries are architecture boundaries because they affect failure handling, resource usage, and caller expectations.
- The best async design is consistent and end-to-end, not half synchronous and half asynchronous.
- `Good opening answer:` "Async is primarily about not blocking threads during I/O waits; a `Task` represents an operation, not a dedicated thread."
- `Then add:` mention end-to-end async flow, cancellation propagation, and avoiding sync-over-async before talking about `ValueTask` or micro-optimizations.

**Interview Gotchas & Confusion Points**

- `.Result` and `.Wait()` can block threads, wrap failures, and contribute to deadlocks.
- `async void` should almost always be limited to event handlers.
- `Task.Run` is for CPU-bound work, not for pretending synchronous I/O became truly async.
- Per-call `HttpClient` creation is fine in simple examples but usually not ideal production design.
- Many candidates say async improves performance without explaining what kind of performance they mean.

**Corner Cases**

- Cancellation is cooperative and only works if the token is checked or forwarded.
- `OperationCanceledException` is the expected cancellation signal.
- `ValueTask` is easy to misuse and is usually for specialized hot-path optimization.
- `await Task.WhenAll(...)` still waits for all tasks even when several fail.

**Behind the Scenes / Internal Logic**

- Async methods are rewritten by the compiler into state machines that track progress across suspension points.
- `await` first checks whether the awaited operation is already complete; if not, it registers a continuation and returns control to the caller.
- True async I/O usually does not keep a thread blocked while waiting; the continuation resumes when the operation completes.
- Async streams (`IAsyncEnumerable<T>`) combine iterator-style state with asynchronous suspension points.

**Must Remember Facts**

- Prefer `Task` / `Task<T>` for most async APIs.
- Pass `CancellationToken` through the call chain.
- Use `ConfigureAwait(false)` in libraries when appropriate.
- Treat `IAsyncEnumerable<T>` as asynchronous streaming, not just async-flavored LINQ.

**Question Bank (Common Questions + What to Say)**

- `Q: What problem does async/await actually solve?`<br>
  `What to say:` It lets the program avoid blocking threads while waiting on I/O, improving responsiveness and throughput in the right workloads.<br>
  `Focus on:` non-blocking waits, not "makes code faster."
- `Q: Why can .Result or .Wait() be dangerous?`<br>
  `What to say:` They block the current thread, can wrap failures awkwardly, and in some environments contribute to deadlocks. Prefer `await` when the API is already asynchronous.<br>
  `Focus on:` blocking and deadlock risk.
- `Q: When is async void acceptable?`<br>
  `What to say:` Almost only for event handlers. For normal async APIs, return `Task` or `Task<T>` so callers can await, compose, and observe failures.<br>
  `Focus on:` awaitability and error propagation.
- `Q: When should you use Task.Run?`<br>
  `What to say:` Use it to offload CPU-bound work from the current thread. Do not use it as a fake wrapper around synchronous I/O and call that real async design.<br>
  `Focus on:` CPU-bound offloading vs I/O-bound async.
- `Q: What is the difference between Task and ValueTask?`<br>
  `What to say:` `Task` is the standard general-purpose async return type. `ValueTask` is a specialized optimization for scenarios where the result is often already available and allocations matter.<br>
  `Focus on:` default choice vs niche optimization.
- `Q: What is the difference between a Task and a thread?`<br>
  `What to say:` A `Task` represents an asynchronous operation and its eventual completion state; it is not the same thing as owning a dedicated thread. The runtime may complete the task with or without tying up a thread the whole time, especially for I/O-bound work.<br>
  `Focus on:` operation abstraction vs execution resource.
- `Q: Why does async need to be "all the way"?`<br>
  `What to say:` Because mixing async calls with blocking waits like `.Result` or `.Wait()` reintroduces thread blocking, complicates exception flow, and can cause deadlocks or throughput issues. The clean design is to preserve asynchronous flow through the whole call chain.<br>
  `Focus on:` avoiding sync-over-async.

  Perfect — for a **5 years experienced .NET interview**, this is **absolutely one of the highest-yield topics**.

What interviewers usually want is **not just syntax** like `async/await`, but whether you truly understand:

* **when async helps**
* **when it hurts**
* **what thread is actually doing what**
* **how deadlocks happen**
* **why Task != Thread**
* **how exceptions/cancellation/parallelism behave in real systems**
* **how to write production-safe async code**

So I’ll cover this like an **interview + production engineering deep dive**, not just a tutorial.

---

# Big Picture: What Interviewers Are Testing

If they ask:

* **“Explain async/await”**
* **“Difference between Task and Thread?”**
* **“What happens under the hood?”**
* **“When would you use ValueTask?”**
* **“Why not use .Result?”**
* **“How do exceptions behave in Task.WhenAll?”**
* **“How do you cancel async work?”**

They are really checking if you understand:

## 1. **Concurrency vs Parallelism**

## 2. **I/O-bound vs CPU-bound**

## 3. **ThreadPool + scheduler behavior**

## 4. **state-machine transformation**

## 5. **SynchronizationContext / deadlocks**

## 6. **production-safe async architecture**

---

# Master Roadmap (What we’ll cover)

I’ll go in this order:

1. **Synchronous Programming**
2. **Threading Internals**
3. **Async/Await Basics**
4. **What Happens Internally**
5. **Task-based Asynchronous Pattern (TAP)**
6. **Exception Handling in Async Code**
7. **Cancellation in Async Operations**
8. **ValueTask**
9. **Async Streams (`IAsyncEnumerable<T>`)**
10. **Real-world coding scenarios**
11. **Interview traps / gotchas**
12. **Production best practices**
13. **5-year experienced interview Q&A**
14. **Practical coding exercises**

---

# 1) Synchronous Programming

---

## Beginner View

In **synchronous programming**, one line waits for the previous line to finish.

```csharp
public string GetData()
{
    Thread.Sleep(3000); // Simulate delay
    return "Done";
}
```

If this method takes 3 seconds, the caller is blocked for 3 seconds.

---

## Professional View

Synchronous programming means:

* caller thread is **occupied**
* execution is **sequential**
* no continuation scheduling
* poor scalability for I/O-heavy server apps

### Example: Bad in Web APIs

```csharp
public string GetCustomer()
{
    var data = httpClient.GetStringAsync("https://api.com/customer").Result;
    return data;
}
```

This is bad because:

* it blocks a thread
* harms throughput
* can deadlock in some environments
* wastes ThreadPool threads

---

## When synchronous is OK

Synchronous code is still fine for:

* very small local operations
* CPU-only quick computations
* startup/bootstrap code (sometimes)
* console utilities (sometimes)

### Example

```csharp
int sum = 0;
for (int i = 0; i < 1000; i++)
    sum += i;
```

No need for async here.

---

# 2) Threading Internals

This is where many candidates become weak.

Interviewers love this topic.

---

# 2.1 Thread vs Task vs Async

This is **must know**.

| Concept         | What it is                       | Important note                      |
| --------------- | -------------------------------- | ----------------------------------- |
| **Thread**      | Actual OS execution unit         | Expensive                           |
| **Task**        | Promise of work/result           | Not necessarily a dedicated thread  |
| **async/await** | Language-level async composition | Usually does **not** create threads |

---

## Key Interview Line

> **Async does not mean multithreading.**
>
> It means **non-blocking asynchronous composition**.

That one sentence alone scores points.

---

# 2.2 What is a Thread?

A thread is an execution path inside a process.

```text
Process
 ├── Thread 1
 ├── Thread 2
 └── Thread 3
```

Each thread has:

* stack
* instruction pointer
* scheduling overhead
* context-switch cost

Threads are **expensive** compared to tasks.

---

# 2.3 Why too many threads is bad

Too many threads cause:

* memory pressure
* context switching
* CPU overhead
* thread starvation

This is why modern .NET prefers:

* **ThreadPool**
* **Tasks**
* **async I/O**

---

# 2.4 ThreadPool Internals

.NET has a **ThreadPool** that reuses worker threads instead of creating new threads every time. The default `TaskScheduler` uses the .NET ThreadPool and supports work-stealing/load-balancing. ([Microsoft Learn][1])

### Why it exists

Creating threads repeatedly is expensive.

So .NET uses a pool of reusable worker threads.

### Example

```csharp
Task.Run(() => Console.WriteLine("Running on ThreadPool"));
```

This usually runs on a ThreadPool thread.

---

## Important Interview Point

### ThreadPool is best for:

* short-lived work
* background work
* task scheduling

### ThreadPool is NOT ideal for:

* long-running dedicated background threads
* blocking forever
* infinite loops without care

---

# 2.5 CPU-bound vs I/O-bound (Very Important)

This is one of the most asked distinctions.

---

## CPU-bound work

Work that uses CPU actively.

Examples:

* image processing
* PDF generation
* encryption
* sorting large arrays
* compression

### Example

```csharp
var result = await Task.Run(() => CalculatePrimeNumbers());
```

Use `Task.Run` **only if you need to offload CPU work** from a request/UI thread.

---

## I/O-bound work

Work that waits on external systems.

Examples:

* database calls
* HTTP requests
* file I/O
* Redis calls
* reading streams

### Example

```csharp
var content = await httpClient.GetStringAsync(url);
```

### Important:

This does **not** need `Task.Run`.

---

## Interview Gold Answer

> **Use async/await for I/O-bound operations. Use Task.Run only for CPU-bound work when you need to free the calling thread.**

That’s a strong senior-level answer.

---

# 2.6 What happens during async I/O?

This is the real internal story.

Suppose:

```csharp
var data = await httpClient.GetStringAsync(url);
```

### What actually happens?

1. Request starts
2. OS/network stack handles I/O
3. Calling thread is **released**
4. No thread sits there “waiting”
5. When I/O completes, continuation is scheduled
6. Method resumes

This is why async is scalable.

---

## Key insight

### Async I/O is not:

> “Use another thread and wait there”

### It is:

> “Start operation, return control, resume later when completed”

That distinction is interview-critical.

---

# 3) Async and Await Basics

---

# 3.1 What is `async`?

`async` allows `await` inside a method.

```csharp
public async Task<string> GetDataAsync()
{
    await Task.Delay(1000);
    return "Done";
}
```

---

## Important Interview Gotcha

### `async` alone does NOTHING

This is extremely important.

```csharp
public async Task FooAsync()
{
    Console.WriteLine("Hello");
}
```

This runs synchronously because there is no `await`.

You may even get a compiler warning.

---

# 3.2 What is `await`?

`await` means:

> “Pause this method here, and continue later when the awaited operation completes.”

It **does not block the thread** like `Thread.Sleep` or `.Wait()`.

---

## Compare

### Blocking

```csharp
Thread.Sleep(2000);
```

### Non-blocking

```csharp
await Task.Delay(2000);
```

Huge interview favorite.

---

# 3.3 Why async/await exists

Before async/await, people wrote async code with:

* callbacks
* ContinueWith
* event-based async

Messy and hard to maintain.

### Ugly old style

```csharp
httpClient.GetStringAsync(url)
    .ContinueWith(t =>
    {
        Console.WriteLine(t.Result);
    });
```

### Modern

```csharp
var data = await httpClient.GetStringAsync(url);
Console.WriteLine(data);
```

Cleaner and safer.

---

# 4) What Happens Internally (Deep but Interview-Friendly)

This is where senior-level candidates stand out.

---

# 4.1 `async` methods become a state machine

This is **very important**.

When you write:

```csharp
public async Task<int> GetNumberAsync()
{
    await Task.Delay(1000);
    return 42;
}
```

The compiler roughly transforms it into:

* a **state machine**
* with states like:

  * start
  * awaiting
  * resumed
  * completed
  * faulted

---

## Conceptual transformation

```text
State 0 -> Start method
State 1 -> Await Task.Delay
State 2 -> Resume after completion
State 3 -> Return 42
```

---

## Why this matters

Because interviewers may ask:

> “How does await work under the hood?”

Strong answer:

> `async/await` is compiler sugar over a generated state machine. When an awaited operation isn’t complete, the method returns to the caller, and the remainder of the method is scheduled as a continuation to run when the awaited operation completes.

That is a **very strong 5-year answer**.

---

# 4.2 Does `await` create a thread?

### No.

This is one of the most common trick questions.

```csharp
await Task.Delay(1000);
```

This does **not** create a thread.

It schedules continuation after delay completion.

---

# 4.3 SynchronizationContext (Very Important)

This is often the hidden cause of deadlocks and “why did it resume there?” behavior.

A `SynchronizationContext` decides **where the continuation runs** (for example, a UI thread). The current context can be used as a scheduler via `TaskScheduler.FromCurrentSynchronizationContext()`, which posts continuations back through that context. ([Microsoft Learn][2])

---

## Typical environments

| Environment     | SynchronizationContext?                  |
| --------------- | ---------------------------------------- |
| WinForms        | Yes                                      |
| WPF             | Yes                                      |
| ASP.NET Classic | Yes                                      |
| ASP.NET Core    | No custom request SynchronizationContext |
| Console App     | Usually no                               |

---

## Why it matters

By default, `await` often captures the current context **where applicable**, then resumes there.

### Example in UI app

```csharp
private async void btn_Click(object sender, EventArgs e)
{
    var data = await httpClient.GetStringAsync(url);
    label1.Text = data; // Safe because resumed on UI context
}
```

---

# 4.4 `ConfigureAwait(false)`

Huge interview topic.

```csharp
var data = await httpClient.GetStringAsync(url).ConfigureAwait(false);
```

This means:

> “Don’t resume on the captured context.”

---

## Why use it?

### In library code:

* improves efficiency
* avoids deadlock risk
* avoids unnecessary context hops

### In ASP.NET Core:

* usually less critical than in classic UI / ASP.NET
* but still okay in reusable library code

---

## Interview Answer

> In reusable library code, I often use `ConfigureAwait(false)` to avoid capturing context unnecessarily. In ASP.NET Core there isn’t the old request SynchronizationContext, so the deadlock risk is much lower than classic ASP.NET, but library code should still avoid assuming a caller context.

That’s a mature answer.

---

# 5) Task-based Asynchronous Pattern (TAP)

This is the official async model in .NET.

---

# 5.1 What is TAP?

TAP means async methods return:

* `Task`
* `Task<T>`
* sometimes `ValueTask<T>`

---

## Good async signatures

```csharp
Task SaveAsync();
Task<Customer> GetCustomerAsync(int id);
ValueTask<bool> ExistsAsync(int id);
IAsyncEnumerable<Order> StreamOrdersAsync();
```

---

# 5.2 Bad async signatures

```csharp
void DoWorkAsync();        // Bad (except event handlers)
int GetDataAsync();        // Bad naming / wrong async contract
Thread StartWork();        // Wrong abstraction for async APIs
```

---

# 5.3 `Task` vs `Task<T>`

### `Task`

No result

```csharp
public async Task SaveAsync()
{
    await dbContext.SaveChangesAsync();
}
```

### `Task<T>`

Returns result

```csharp
public async Task<Customer> GetCustomerAsync(int id)
{
    return await dbContext.Customers.FindAsync(id);
}
```

---

# 5.4 `async void` — dangerous

This is a classic interview trap.

### Bad

```csharp
public async void ProcessAsync()
{
    await Task.Delay(1000);
}
```

### Why bad?

* caller cannot await it
* exceptions are harder to handle
* cannot compose
* cannot track completion

---

## Only valid use

### Event handlers

```csharp
private async void button1_Click(object sender, EventArgs e)
{
    await LoadDataAsync();
}
```

---

# 5.5 Fire-and-forget — dangerous in production

This is **very interview-relevant** for backend roles.

### Bad

```csharp
_ = SendEmailAsync();
```

Why dangerous?

* exceptions may be lost/unobserved
* request may finish before work completes
* scoped services may be disposed
* app may shut down mid-work

---

## Better patterns

Use:

* background queue
* hosted service
* durable messaging (RabbitMQ / Azure Service Bus / Kafka)
* Hangfire / Quartz / worker service

---

# 5.6 `Task.Run` — when to use and when not to use

Huge interview topic.

---

## Good use

CPU-bound work

```csharp
var report = await Task.Run(() => GenerateLargeExcelReport());
```

---

## Bad use

Wrapping async I/O inside `Task.Run`

```csharp
// BAD
await Task.Run(async () => await httpClient.GetStringAsync(url));
```

Why bad?

* wastes ThreadPool thread
* gives no scalability benefit
* unnecessary nesting

---

## Interview Answer

> I use `Task.Run` mainly for CPU-bound work. I don’t wrap naturally asynchronous I/O operations like HTTP, EF Core, or file async APIs inside `Task.Run`, because those already use non-blocking I/O and wrapping them just wastes ThreadPool resources.

Excellent answer.

---

# 5.7 `Task.WhenAll` vs `Task.WhenAny`

---

## `Task.WhenAll`

Wait for all tasks. When you `await Task.WhenAll(...)`, it completes after all tasks finish; if multiple tasks fault, the returned task aggregates them. `await` rethrows one exception, while the task’s `Exception` can contain multiple failures. ([Microsoft Learn][3])

```csharp
var t1 = GetUserAsync();
var t2 = GetOrdersAsync();
var t3 = GetPaymentsAsync();

await Task.WhenAll(t1, t2, t3);

var user = await t1;
var orders = await t2;
var payments = await t3;
```

### Why good?

Parallelizes independent I/O.

---

## `Task.WhenAny`

Wait for first completion.

```csharp
var completed = await Task.WhenAny(task1, task2, task3);
```

Use cases:

* timeout races
* first-response-wins
* failover endpoints

---

# 6) Exception Handling in Async Code

This section is extremely important.

---

# 6.1 Where exceptions are thrown in async methods

Interview trap.

### Example

```csharp
public async Task FooAsync()
{
    throw new Exception("Boom");
}
```

This looks like it throws immediately — but async methods usually store exceptions in the returned task and rethrow on `await` (argument validation is a common exception that may be thrown synchronously). ([Microsoft Learn][4])

```csharp
try
{
    await FooAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

---

# 6.2 Exception before first await

Very important corner case.

```csharp
public Task FooAsync()
{
    throw new InvalidOperationException("Boom before Task exists");
}
```

This throws **synchronously**.

Now compare:

```csharp
public async Task FooAsync()
{
    throw new InvalidOperationException("Boom inside async");
}
```

This usually becomes a **faulted Task**.

---

## Interview gotcha

> Not every method with `Async` in the name throws asynchronously.

---

# 6.3 `try/catch` with async

Correct pattern:

```csharp
try
{
    var data = await httpClient.GetStringAsync(url);
}
catch (HttpRequestException ex)
{
    // handle HTTP failure
}
catch (TaskCanceledException ex)
{
    // timeout or cancellation
}
```

---

# 6.4 `Task.WhenAll` exceptions (must know)

This is a favorite interview question.

```csharp
var tasks = new[]
{
    Task.Run(() => throw new Exception("A")),
    Task.Run(() => throw new Exception("B"))
};

await Task.WhenAll(tasks);
```

### What happens?

* multiple tasks fail
* the resulting task contains aggregated failures
* `await` rethrows one failure, but the underlying task can contain all of them

---

## Best pattern

```csharp
try
{
    await Task.WhenAll(tasks);
}
catch
{
    foreach (var task in tasks.Where(t => t.IsFaulted))
    {
        Console.WriteLine(task.Exception);
    }
}
```

---

# 6.5 Never use `.Wait()` / `.Result` casually

This is one of the most asked async interview topics.

### Bad

```csharp
var result = GetCustomerAsync().Result;
```

### Why dangerous?

* blocks thread
* can deadlock
* wraps exceptions differently
* kills scalability

---

## Interview answer

> I avoid `.Result` and `.Wait()` in async flows because they synchronously block threads, can cause deadlocks in context-bound environments, and reduce throughput on server applications.

Excellent answer.

---

# 7) Cancellation in Async Operations

This is a **very practical senior-level topic**.

Many candidates know async, but not **proper cancellation design**.

---

# 7.1 Why cancellation matters

Without cancellation:

* abandoned requests keep running
* DB/HTTP work continues unnecessarily
* server resources are wasted
* timeouts are ugly

---

# 7.2 Core cancellation pattern

Use `CancellationToken`.

```csharp
public async Task<string> DownloadAsync(string url, CancellationToken cancellationToken)
{
    return await httpClient.GetStringAsync(url, cancellationToken);
}
```

---

# 7.3 Best practice: propagate the token

A very important interview point.

### Bad

```csharp
public async Task ProcessAsync()
{
    await httpClient.GetStringAsync(url); // no token passed
}
```

### Good

```csharp
public async Task ProcessAsync(CancellationToken cancellationToken)
{
    await httpClient.GetStringAsync(url, cancellationToken);
}
```

---

# 7.4 How cancellation works internally

Cancellation in .NET is **cooperative**, not forced. The caller requests cancellation via `CancellationTokenSource.Cancel()`, and the operation must observe the token and stop promptly. To mark a task as **Canceled** (rather than RanToCompletion), code typically throws `OperationCanceledException`/uses `ThrowIfCancellationRequested()`. ([Microsoft Learn][5])

Meaning:

* caller requests cancellation
* your code must check/obey it

---

# 7.5 Proper cancellation example

```csharp
public async Task ProcessItemsAsync(IEnumerable<int> items, CancellationToken ct)
{
    foreach (var item in items)
    {
        ct.ThrowIfCancellationRequested();

        await Task.Delay(500, ct); // simulate work
        Console.WriteLine($"Processed {item}");
    }
}
```

---

# 7.6 `OperationCanceledException` vs real failure

Interviewers ask this a lot.

Cancellation is **not usually an error**.

### Good handling

```csharp
try
{
    await ProcessItemsAsync(items, ct);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation was canceled.");
}
```

Do not log it like a production outage unless it’s unexpected.

---

# 7.7 Timeout vs Cancellation

Very important distinction.

### Timeout

Operation exceeded allowed duration.

### Cancellation

Caller explicitly wants to stop.

Sometimes both surface as `TaskCanceledException` / `OperationCanceledException`, so you need context.

---

# 7.8 `CancelAfter`

A common production pattern is scheduling cancellation with `CancellationTokenSource.CancelAfter(...)`. Microsoft’s docs demonstrate using `CancelAfter` to stop operations that exceed a time limit. ([Microsoft Learn][6])

```csharp
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

await ProcessItemsAsync(items, cts.Token);
```

---

# 7.9 Linked tokens

Very useful in APIs/services.

```csharp
using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
    requestAbortedToken, timeoutCts.Token);

await service.DoWorkAsync(linkedCts.Token);
```

Use case:

* request aborted by client
* OR timeout exceeded

---

# 8) ValueTask

This is a **5-year experience differentiator**.

Many candidates mention it vaguely.
Few can explain it correctly.

---

# 8.1 Why `ValueTask` exists

`Task` is a reference type and may allocate. `ValueTask` is a struct awaitable designed for cases where operations often complete synchronously and allocation reduction matters. But it also adds overhead/complexity, so `Task` should remain the default unless profiling shows a benefit. ([Microsoft Learn][7])

---

## Typical scenario

Imagine a cache lookup:

```csharp
public async Task<string> GetAsync(string key)
{
    if (_cache.TryGetValue(key, out var value))
        return value;

    return await _db.GetValueAsync(key);
}
```

If cache hits are frequent, you may want to avoid unnecessary allocation overhead.

That’s where `ValueTask<T>` can help.

---

# 8.2 Example

```csharp
public ValueTask<string> GetCachedValueAsync(string key)
{
    if (_cache.TryGetValue(key, out var value))
        return ValueTask.FromResult(value);

    return new ValueTask<string>(LoadFromDbAsync(key));
}
```

---

# 8.3 When to use ValueTask

Use `ValueTask` only if:

* method is called **very frequently**
* it often completes **synchronously**
* profiling shows allocations matter

---

# 8.4 When NOT to use ValueTask

Do **not** use it just because it sounds “advanced”.

Avoid when:

* normal app/service methods
* low-frequency APIs
* public APIs where simplicity matters
* team readability is more important

---

# 8.5 ValueTask gotchas (very interview-important)

This is where interviewers trap people.

### Dangerous assumptions:

* you should **not** casually await the same `ValueTask` multiple times
* don’t treat it like a reusable `Task`
* if you need that behavior, convert once or return `Task` instead

### Safe mindset:

> Use `Task` by default. Use `ValueTask` only for measured hot paths.

That is the exact interview-safe answer.

---

# 9) Async Streams (`IAsyncEnumerable<T>`)

This is increasingly important in modern .NET interviews.

---

# 9.1 Why async streams exist

Sometimes you don’t want:

* one big `List<T>`
* waiting for all data first

You want:

* **streaming results gradually**
* async data production over time

That’s what `IAsyncEnumerable<T>` is for. C# async streams let you produce/consume elements asynchronously with `await foreach`, which is useful for chunked or streaming data sources. ([Microsoft Learn][8])

---

# 9.2 Example

```csharp
public async IAsyncEnumerable<int> GenerateNumbersAsync()
{
    for (int i = 1; i <= 5; i++)
    {
        await Task.Delay(500);
        yield return i;
    }
}
```

Consume:

```csharp
await foreach (var number in GenerateNumbersAsync())
{
    Console.WriteLine(number);
}
```

---

# 9.3 Why it’s useful in real systems

Great for:

* streaming DB/API results
* background pipelines
* ETL processing
* chunked file/network reading
* SignalR / live feeds
* paginated APIs

---

# 9.4 Practical API example

```csharp
public async IAsyncEnumerable<OrderDto> StreamOrdersAsync(
    [EnumeratorCancellation] CancellationToken ct = default)
{
    for (int i = 1; i <= 100; i++)
    {
        ct.ThrowIfCancellationRequested();
        await Task.Delay(50, ct);

        yield return new OrderDto(i, $"ORD-{i:000}");
    }
}
```

---

# 9.5 Interview gotcha

### Async streams are not for everything

Bad use cases:

* small fixed data
* data that must be fully materialized anyway
* when caller really needs `List<T>`

---

# 10) Practical Coding Scenarios (Very Important)

Now let’s move from theory to **actual interview-level coding scenarios**.

---

# Scenario 1 — Fan-out HTTP calls in parallel

### Problem

Get customer profile, orders, and invoices.

### Bad version

```csharp
public async Task<CustomerDashboard> GetDashboardAsync(int customerId)
{
    var profile = await _customerClient.GetProfileAsync(customerId);
    var orders = await _orderClient.GetOrdersAsync(customerId);
    var invoices = await _billingClient.GetInvoicesAsync(customerId);

    return new CustomerDashboard(profile, orders, invoices);
}
```

This is **sequential** and slower.

---

## Better version

```csharp
public async Task<CustomerDashboard> GetDashboardAsync(
    int customerId,
    CancellationToken ct = default)
{
    var profileTask = _customerClient.GetProfileAsync(customerId, ct);
    var ordersTask = _orderClient.GetOrdersAsync(customerId, ct);
    var invoicesTask = _billingClient.GetInvoicesAsync(customerId, ct);

    await Task.WhenAll(profileTask, ordersTask, invoicesTask);

    return new CustomerDashboard(
        await profileTask,
        await ordersTask,
        await invoicesTask);
}
```

---

## Interview discussion points

You should say:

* these are **independent I/O calls**
* so parallelizing improves latency
* but you must think about:

  * rate limits
  * downstream load
  * partial failure handling
  * cancellation propagation

That sounds senior.

---

# Scenario 2 — Avoiding `.Result` deadlock / blocking

### Bad

```csharp
public Customer GetCustomer(int id)
{
    return GetCustomerAsync(id).Result;
}
```

---

## Better

```csharp
public async Task<Customer> GetCustomerAsync(int id)
{
    return await _repository.GetByIdAsync(id);
}
```

---

## Interview point

If you are forced to bridge sync and async, treat it as a **boundary smell**, not normal design.

---

# Scenario 3 — Background processing in ASP.NET Core

### Bad

```csharp
[HttpPost]
public IActionResult SendEmail([FromBody] EmailRequest request)
{
    _ = _emailService.SendAsync(request); // dangerous fire-and-forget
    return Ok();
}
```

### Why bad?

* request may end
* scoped services may dispose
* exceptions may vanish

---

## Better

Use:

* queue
* hosted service
* message broker

### Interview answer

> For durable background work in ASP.NET Core, I wouldn’t rely on fire-and-forget tasks inside the request pipeline. I’d use a background queue or messaging infrastructure so work survives request completion and failures can be retried.

That’s strong.

---

# Scenario 4 — Controlled concurrency

Very common in production systems.

Suppose you need to call 500 APIs.

### Bad

```csharp
var tasks = urls.Select(url => httpClient.GetStringAsync(url));
await Task.WhenAll(tasks);
```

This may overload:

* your app
* remote service
* sockets
* DB/API limits

---

## Better — throttling with `SemaphoreSlim`

```csharp
public async Task ProcessUrlsAsync(IEnumerable<string> urls, CancellationToken ct)
{
    using var semaphore = new SemaphoreSlim(10);

    var tasks = urls.Select(async url =>
    {
        await semaphore.WaitAsync(ct);
        try
        {
            var content = await httpClient.GetStringAsync(url, ct);
            Console.WriteLine($"{url} -> {content.Length}");
        }
        finally
        {
            semaphore.Release();
        }
    });

    await Task.WhenAll(tasks);
}
```

---

## Interview point

This is a very practical **senior-level async answer**.

---

# Scenario 5 — CPU-bound work in API

### Problem

Generate a huge PDF/Excel/report.

### Correct approach

If truly CPU-heavy:

```csharp
public async Task<byte[]> GenerateReportAsync(ReportRequest request)
{
    return await Task.Run(() => _reportBuilder.Build(request));
}
```

But say this carefully in interviews:

> I’d only offload CPU-bound work this way if it’s appropriate for the deployment model and request latency expectations. For heavy report generation at scale, I’d often move it to background processing instead of keeping it inline inside a request.

That sounds experienced.

---

# 11) Interview Gotchas / Corner Cases

This is where interviews are won.

---

# 11.1 `Task` does not mean “running now”

```csharp
Task task = SomeAsyncMethod();
```

This means:

* operation may have started
* or may represent deferred/ongoing work depending on API

Don’t assume task == thread.

---

# 11.2 `await` does not guarantee same thread

Very important.

```csharp
await Task.Delay(1000);
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
```

Continuation may resume on:

* same thread
* different thread
* captured context
* ThreadPool

So never write logic that depends on “same thread after await” unless the framework guarantees it.

---

# 11.3 `Task.Delay` vs `Thread.Sleep`

| `Task.Delay`          | `Thread.Sleep`             |
| --------------------- | -------------------------- |
| Non-blocking          | Blocks thread              |
| Async-friendly        | Thread blocking            |
| Good in async methods | Usually bad in async flows |

---

# 11.4 `async` all the way

Huge interview phrase.

### Meaning:

If you start async, don’t force sync in the middle.

### Bad

```csharp
public async Task FooAsync()
{
    var data = GetDataAsync().Result;
}
```

### Good

```csharp
public async Task FooAsync()
{
    var data = await GetDataAsync();
}
```

---

# 11.5 Returning `Task` directly vs `await`

This is subtle and interview-worthy.

### Version A

```csharp
public Task<string> GetAsync()
{
    return httpClient.GetStringAsync(url);
}
```

### Version B

```csharp
public async Task<string> GetAsync()
{
    return await httpClient.GetStringAsync(url);
}
```

---

## Difference?

### Version A

* slightly less overhead
* no local try/catch/finally after await point

### Version B

* easier to add:

  * logging
  * try/catch
  * using/cleanup
  * transformations

### Interview-safe answer

> If I’m just forwarding a task, returning it directly is fine. If I need exception handling, cleanup, or to manipulate the result, I’ll use `await`.

That’s a strong nuanced answer.

---

# 11.6 `using` + async issue

A subtle but important bug.

### Bad

```csharp
public Task<string> ReadAsync()
{
    using var client = new HttpClient();
    return client.GetStringAsync("https://example.com");
}
```

### Why bad?

`client` may be disposed before the async work completes.

---

## Good

```csharp
public async Task<string> ReadAsync()
{
    using var client = new HttpClient();
    return await client.GetStringAsync("https://example.com");
}
```

This is a classic interview gotcha.

---

# 11.7 LINQ + async trap

### Bad

```csharp
var results = users.Select(async user => await ProcessAsync(user)).ToList();
```

This gives:

```csharp
List<Task<Result>>
```

not:

```csharp
List<Result>
```

### Correct

```csharp
var tasks = users.Select(user => ProcessAsync(user));
var results = await Task.WhenAll(tasks);
```

This is **very commonly asked**.

---

# 12) Production Best Practices (What Senior Candidates Should Say)

---

# 12.1 Golden Rules

### Always:

* use async for I/O-bound work
* pass `CancellationToken`
* avoid `.Result` / `.Wait()`
* use `Task.WhenAll` for independent async operations
* throttle concurrency when needed
* use `async void` only for events
* prefer `Task` over `ValueTask` unless measured

---

# 12.2 In ASP.NET Core

### Good practices

* async controller/service/repository methods
* async EF Core calls:

  * `ToListAsync`
  * `FirstOrDefaultAsync`
  * `SaveChangesAsync`
* propagate request cancellation token
* avoid fake async wrappers

---

# 12.3 Avoid “fake async”

### Bad

```csharp
public async Task<string> GetDataAsync()
{
    return await Task.Run(() => File.ReadAllText("data.txt"));
}
```

If async API exists, use it:

### Better

```csharp
public async Task<string> GetDataAsync()
{
    return await File.ReadAllTextAsync("data.txt");
}
```

---

# 13) 60–90 Second Interview Answer

If interviewer says:

## “Explain async/await in C#”

Use this:

> `async/await` in C# is a language feature built on top of the Task-based Asynchronous Pattern. It allows us to write non-blocking asynchronous code in a sequential style. Under the hood, the compiler transforms async methods into state machines. When an awaited I/O operation hasn’t completed yet, the method returns control to the caller instead of blocking a thread, and resumes later as a continuation when the operation completes. I typically use async for I/O-bound operations like database, HTTP, or file access, and I avoid blocking calls like `.Result` or `.Wait()` because they hurt scalability and can cause deadlocks in some environments. For CPU-bound work, I use `Task.Run` selectively, and I also pay attention to cancellation, exception propagation, and concurrency control in production code.

That answer is **interview strong**.

---

# 14) Senior-Level Interview Questions + Model Answers

---

## Q1) What’s the difference between Task and Thread?

### Strong Answer

> A Thread is an OS execution unit, while a Task is an abstraction representing asynchronous work or a future result. A Task may run on a ThreadPool thread, a dedicated thread, or complete without needing a thread to stay blocked, especially for async I/O. Tasks are lighter and composable; threads are lower-level and more expensive.

---

## Q2) Does async/await create a new thread?

### Strong Answer

> No. `async/await` does not automatically create a new thread. It’s primarily about non-blocking continuation-based execution. For I/O-bound operations, no thread is kept waiting. A continuation is scheduled when the operation completes.

---

## Q3) When would you use Task.Run?

### Strong Answer

> Mainly for CPU-bound work when I need to offload that work from the current thread, such as UI responsiveness or isolating heavy computation. I wouldn’t use it to wrap naturally asynchronous I/O like HTTP or EF Core calls.

---

## Q4) Why is `.Result` dangerous?

### Strong Answer

> It synchronously blocks the calling thread, can reduce throughput, may deadlock in context-bound environments, and changes exception behavior compared to `await`.

---

## Q5) When would you use ValueTask?

### Strong Answer

> Only in performance-sensitive hot paths where the operation frequently completes synchronously and profiling shows Task allocations are significant. Otherwise, I default to Task for simplicity and safer consumption semantics.

---

## Q6) How do exceptions behave in Task.WhenAll?

### Strong Answer

> If multiple tasks fail, the resulting task contains all failures. When awaited, one exception is rethrown, but the task itself can expose aggregated exceptions, so for diagnostics I inspect the individual faulted tasks or the task’s Exception property.

---

## Q7) How do you design cancellation properly?

### Strong Answer

> I accept a `CancellationToken` at public async boundaries, propagate it to all cancellable downstream operations, periodically check it in long-running loops, and treat cancellation as a normal control flow outcome rather than an error in most cases.

---

# 15) Practical Interview Coding Scenarios You Should Be Able to Write

These are extremely useful for 5-year interviews.

You should be able to write these **from memory**:

---

## Must be able to code:

1. **Parallel API calls with `Task.WhenAll`**
2. **CancellationToken propagation**
3. **SemaphoreSlim throttling**
4. **Exception-safe async method**
5. **Streaming with `IAsyncEnumerable<T>`**
6. **Timeout with linked cancellation**
7. **CPU-bound offload with `Task.Run`**
8. **Avoiding fire-and-forget in ASP.NET Core**
9. **Difference between sequential await and parallel task creation**
10. **Task vs ValueTask scenario explanation**

---

# 16) Interview Drill: Sequential vs Parallel (Very Important)

This exact thing gets asked a lot.

---

## Sequential

```csharp
var a = await GetAAsync();
var b = await GetBAsync();
var c = await GetCAsync();
```

Total time = roughly:

```text
A + B + C
```

---

## Parallel

```csharp
var aTask = GetAAsync();
var bTask = GetBAsync();
var cTask = GetCAsync();

await Task.WhenAll(aTask, bTask, cTask);

var a = await aTask;
var b = await bTask;
var c = await cTask;
```

Total time = roughly:

```text
max(A, B, C)
```

---

## Interview gotcha

Parallel only makes sense if operations are:

* independent
* safe to run together
* not causing overload

That nuance matters.

---

# 17) Most Common Async Mistakes in Real .NET Projects

This is highly interview-useful.

---

## Mistake 1

Using `Task.Run` around EF Core / HttpClient / file async

## Mistake 2

Not passing `CancellationToken`

## Mistake 3

Fire-and-forget inside controllers/services

## Mistake 4

Using `.Result` / `.Wait()`

## Mistake 5

Overusing `ValueTask`

## Mistake 6

Starting too many parallel tasks without throttling

## Mistake 7

Assuming `await` means “same thread”

## Mistake 8

Using `async void` outside event handlers

## Mistake 9

Forgetting exception handling in background work

## Mistake 10

Writing fake async wrappers

If you can discuss these with examples, you’ll sound experienced.

---

# 18) What Interviewers Expect at 5 Years Experience

At your level, they expect you to be able to answer all of these:

### You should be comfortable explaining:

* `Thread` vs `Task`
* CPU-bound vs I/O-bound
* async state machine
* SynchronizationContext
* `ConfigureAwait(false)`
* `Task.WhenAll`
* cancellation propagation
* `OperationCanceledException`
* deadlock scenarios
* `ValueTask`
* async streams
* throttling
* background processing patterns
* ASP.NET Core async best practices

If you can answer those well, this becomes one of your strongest interview sections.

---

# 19) Best Study Strategy for This Topic

Don’t just read. Practice in layers.

---

## Layer 1 — Concept mastery

Be able to explain in plain English:

* what async is
* why it helps
* what it doesn’t do

## Layer 2 — Internal understanding

Be able to explain:

* state machine
* continuation
* thread pool
* context capture

## Layer 3 — Coding mastery

Be able to code:

* `Task.WhenAll`
* cancellation
* exception handling
* throttling
* async streams

## Layer 4 — Interview storytelling

Be able to say:

> “In a real production API, I would…”

That’s what separates mid-level from senior-ish answers.

---

# 20) Best Next Step (Recommended)

The best next thing is **not more theory**.

The best next thing is this:

## I can give you a **complete interview pack** on this topic with:

### Part A — **Top 30 async/threading interview questions**

with **strong 5-year experience answers**

### Part B — **15 practical coding problems in C#**

like:

* `Task.WhenAll`
* cancellation
* throttling
* deadlock trap
* async repository/service design
* background queue
* async streams

### Part C — **Real interview mock round**

I ask you questions like an interviewer, and you answer.

### Part D — **One-page revision notes**

for quick last-day interview revision.

---

If you want the **best possible prep**, say:

## **“continue with part 2 — practical coding scenarios and interview questions”**

and I’ll give you the **deep interview-focused continuation** with **real .NET coding scenarios in C# (`net10.0`)**.

[1]: https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler?utm_source=chatgpt.com "System.Threading.Tasks.TaskScheduler class - .NET | Microsoft Learn"
[2]: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskscheduler.fromcurrentsynchronizationcontext?view=net-10.0&utm_source=chatgpt.com "TaskScheduler.FromCurrentSynchronizationContext Method (System.Threading.Tasks) | Microsoft Learn"
[3]: https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern?utm_source=chatgpt.com "Consuming the Task-based Asynchronous Pattern - .NET | Microsoft Learn"
[4]: https://learn.microsoft.com/en-us/%20%20dotnet/csharp/asynchronous-programming/?utm_source=chatgpt.com "Asynchronous programming - C# | Microsoft Learn"
[5]: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-cancellation?utm_source=chatgpt.com "Task Cancellation - .NET | Microsoft Learn"
[6]: https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/cancel-async-tasks-after-a-period-of-time?utm_source=chatgpt.com "Cancel async tasks after a period of time\" - C# | Microsoft Learn"
[7]: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask?view=net-10.0&utm_source=chatgpt.com "ValueTask Struct (System.Threading.Tasks) | Microsoft Learn"
[8]: https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-return-types?utm_source=chatgpt.com "Async return types - C# | Microsoft Learn"


<div id="code-organization"></div>

# Code organization

How you organize your C# code significantly impacts its readability, maintainability, and extensibility. Well-organized code follows consistent patterns, respects separation of concerns, and leverages language features to create clear boundaries between components. 

Modern C# includes numerous features that help enforce good code organization principles.

## Namespaces

Namespaces in C# provide a way to organize code into logical groups and prevent naming conflicts. They create a hierarchical structure for your types (yes, they can be nested), making large codebases more manageable and allowing for intuitive navigation.

```csharp
// Namespace declaration
namespace MyApplication.DataAccess
{
    public class Database
    {
        // Class implementation
    }
}

// File-scoped namespaces (C# 10.0+)
namespace MyApplication.Business;

public class Customer
{
    // Class implementation
}
```

### Namespace organization best practices:

1. Structure namespaces to reflect logical organization, not folder structure
2. Consider using a company or project name as the top-level namespace
3. Group related functionality within namespace hierarchies
4. Avoid deeply nested namespaces (more than 3-4 levels)
5. Don't put different functionality in the same namespace just because they're in the same assembly

## Using directives

Using directives specify which namespaces are referenced in your code, allowing you to use types from those namespaces without fully qualifying them. They improve code readability by reducing repetition.

```csharp
// Import namespace
using System;
using System.Collections.Generic;
using System.Linq;

// Alias namespace
using IO = System.IO;

// Static imports (C# 6.0+)
using static System.Math;
using static System.Console;

// Combined with global using (C# 10.0+)
global using System;
global using System.Collections.Generic;

// Using aliases for types (C# 12+)
using Point = (int X, int Y);
using CustomerName = string;
using RGB = (byte Red, byte Green, byte Blue);

// Multiple global using directives in a single file (GlobalUsings.cs)
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
```

**Quick mental model**

- A `using` directive is a compile-time name-resolution convenience, not a runtime import mechanism.
- Use normal `using` directives for local clarity, `global using` for genuinely ubiquitous dependencies, and aliases when collisions or readability justify them.
- `using static` can improve code for math-heavy or DSL-like areas, but it can also hide where APIs come from if overused.

**Behind the covers**

- `using` directives tell the compiler where to search for unqualified type names; they do not load assemblies or change runtime behavior by themselves.
- Alias directives are just alternate compile-time names bound to a namespace or type.
- `global using` directives are applied across the compilation, which is why they reduce repetition but can make per-file dependencies less explicit.

### Using directives best practices:

1. Place `using` directives at the top of the file, outside of namespace declarations
2. Order `using` directives alphabetically, with System namespaces first
3. Use `global using` for commonly used namespaces across many files
4. Use static imports sparingly and only for frequently used static members
5. Consider using aliases to improve readability or avoid ambiguity

## File-scoped types (C# 11+)

File-scoped types are accessible only within the file where they're defined, allowing you to create helper classes, interfaces, or enums that are truly private to their implementation file. This reduces the public API surface and prevents accidental usage.

```csharp
// File: UserService.cs
namespace MyApp.Services;

// File-scoped type - only accessible within this file
file class UserValidator
{
    public bool Validate(User user) => !string.IsNullOrEmpty(user.Name);
}

// Public class that can use the file-scoped type
public class UserService
{
    private readonly UserValidator _validator = new();
    
    public bool RegisterUser(User user)
    {
        if (!_validator.Validate(user))
            return false;
            
        // Register user logic
        return true;
    }
}

// File: Utils.cs
file static class StringExtensions  // Only visible in this file
{
    public static bool IsValidEmail(this string email) =>
        email.Contains('@') && email.Contains('.');
}
```

## Partial classes

Partial classes allow splitting a class, struct, or interface definition across multiple files. This can be useful for separating generated code from hand-written code or dividing large classes by functionality.

```csharp
// File: Customer.cs
public partial class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public void Save()
    {
        // Implementation
    }
}

// File: Customer.Orders.cs
public partial class Customer
{
    public List<Order> Orders { get; } = new List<Order>();
    
    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}

// File: Customer.Validation.cs
public partial class Customer
{
    public bool Validate()
    {
        // Validation logic
        return !string.IsNullOrEmpty(Name);
    }
}
```

## Access modifiers

Access modifiers control the visibility and accessibility of types and type members. Properly applied access modifiers create clear boundaries and enforce encapsulation.

```csharp
// Access modifiers
public class AccessModifierDemo
{
    public int PublicField;                        // Accessible from anywhere
    private int _privateField;                     // Accessible only within the class
    protected int ProtectedField;                  // Accessible within the class and derived classes
    internal int InternalField;                    // Accessible within the same assembly
    protected internal int ProtectedInternalField; // Accessible within the same assembly or derived classes
    private protected int PrivateProtectedField;   // Accessible within the same assembly from derived classes
}
```

**Quick mental model**

- Access modifiers define ownership boundaries: who may depend on this member and who is allowed to change assumptions around it.
- `public` is a compatibility promise, not just a visibility choice.
- `internal` is often the most underrated modifier because it keeps APIs useful inside the assembly without leaking them to consumers.

**Behind the covers**

- Access modifiers are enforced at compile time and represented in metadata, so they affect both source usage and externally visible API shape.
- `protected internal` means same assembly or derived types, while `private protected` means derived types inside the same assembly only.
- Wider visibility increases the number of callers that can break when behavior or signatures change.

### Access modifier guidelines:

1. **public**: Use for types and members that form your public API
2. **internal**: Use for types and members that should be available within your assembly but not externally
3. **private**: Use for implementation details inside a class that shouldn't be accessible elsewhere
4. **protected**: Use for members that should be accessible to derived classes for customization
5. **protected internal**: Use when both derived classes and code within the assembly need access
6. **private protected**: Use when derived classes within the same assembly (but not external ones) need access

## Properties and indexers

Properties provide a way to expose fields while adding validation, computed values, or extra logic during access. They're a fundamental part of C# that enables proper encapsulation in object-oriented design.

```csharp
public class PropertyDemo
{
    // Auto-implemented property
    public string Name { get; set; }
    
    // Property with backing field
    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = value < 0 ? 0 : value; }
    }
    
    // Expression-bodied property (C# 6.0+)
    public bool IsAdult => Age >= 18;
    
    // Property with different access levels
    public string Email { get; private set; }
    
    // Init-only property (C# 9.0+)
    public string Id { get; init; }
    
    // Required property (C# 11.0+)
    public required string Username { get; set; }
    
    // Indexers
    private string[] _data = new string[10];
    
    public string this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
    
    public string this[string key]
    {
        get => key switch
        {
            "first" => _data[0],
            "last" => _data[^1],                               // The “Hat” Operator (^) is used as a prefix to count indexes starting from the end of a list.
            _ => throw new ArgumentException("Invalid key")
        };
    }
}
```

**Quick mental model**

- A property is a method-shaped contract with field-like syntax, which is why it is usually better for public APIs than exposing raw fields.
- Use auto-properties for simple state, custom accessors when invariants or derived values matter, and `init`/`required` when construction-time rules should be explicit.
- An indexer makes sense only when the type naturally behaves like a collection or keyed container.

**Behind the covers**

- A property compiles into getter/setter methods, and auto-properties usually get a compiler-generated backing field.
- `init` restricts assignment to the initialization phase rather than allowing arbitrary later mutation.
- Indexers are just specially named property accessors under the hood, exposed with bracket syntax at the language level.

**Additional resources:**

- [C# coding conventions (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [File-scoped namespaces (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces)
- [Access modifiers (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers)
- [Properties (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)

### Interview Prep

**Senior Perspective (The "Why")**

- Code organization is about boundaries, ownership, and API surface control.
- Namespaces, access modifiers, partial types, file-local types, and properties all communicate intent to future maintainers.
- Strong answers explain not just where code lives, but why certain things should remain hidden or discoverable.
- Good organization reduces accidental coupling and makes change safer.
- `Good opening answer:` "I treat organization features like `using` directives, visibility, and properties as API-surface decisions, not just style preferences."
- `Then add:` explain how narrower visibility, deliberate `global using` usage, and property-based contracts make change safer for maintainers and consumers.

**Interview Gotchas & Confusion Points**

- `global using` reduces noise but can make dependencies less visible.
- Partial classes are useful, but overuse can fragment one concept across too many files.
- File-local types limit visibility; they do not replace real architectural boundaries.
- Overly broad access modifiers quietly expand maintenance cost and accidental usage.
- Candidates often treat folder structure and code organization as the same thing when they are not.

**Corner Cases**

- Namespace structure does not have to exactly mirror folders.
- Aliases can help with collisions, but too many can reduce readability.
- Required properties help initialization but do not replace invariants.
- Indexers only make sense when the type naturally behaves like a keyed container.

**Behind the Scenes / Internal Logic**

- Auto-properties are typically compiled into accessor methods plus a hidden backing field.
- `global using` directives become available across the compilation unit, which is why they reduce per-file noise.
- Access modifiers are part of both compile-time checks and emitted metadata, which is why they shape API surface beyond just editor visibility.
- File-local types let the compiler enforce "only this file can see it" without making the type public to the wider assembly.

**Must Remember Facts**

- Default to the smallest visibility that works.
- Be deliberate about what becomes `public`.
- Prefer properties over public fields for stable contracts.
- Use file-scoped namespaces and file-local types when they reduce ceremony without hiding important design intent.

**Question Bank (Common Questions + What to Say)**

- `Q: Why should visibility default to the narrowest possible level?`<br>
  `What to say:` Because every wider visibility level increases coupling and the chance of accidental usage. Narrow visibility keeps implementation details easier to change safely.<br>
  `Focus on:` API surface control and change safety.
- `Q: When are partial classes a good idea, and when are they a smell?`<br>
  `What to say:` They are useful for generated code separation or clearly split concerns. They become a smell when one concept is scattered so widely that understanding behavior requires jumping through too many files.<br>
  `Focus on:` separation vs fragmentation.
- `Q: What problem do file-local types solve?`<br>
  `What to say:` They let you keep helper types private to one file, reducing exposed surface and preventing accidental reuse in places they were never intended for.<br>
  `Focus on:` visibility narrowing.
- `Q: Why are properties usually preferred over public fields?`<br>
  `What to say:` Properties preserve encapsulation and versioning flexibility. You can later add validation, computed logic, or restricted setters without changing the public shape too drastically.<br>
  `Focus on:` stable contracts and future flexibility.
- `Q: Why is namespace design more than just mirroring folders?`<br>
  `What to say:` Because namespaces describe logical ownership and boundaries, not just physical file layout. Good namespace design communicates architecture, not just storage location.<br>
  `Focus on:` logical structure over filesystem structure.
- `Q: What is the difference between using and global using?`<br>
  `What to say:` A normal `using` applies only within the file, while `global using` applies across the compilation. `global using` reduces repetition, but it should be reserved for namespaces that are truly common across the codebase.<br>
  `Focus on:` local clarity vs project-wide convenience.
- `Q: What is the difference between protected internal and private protected?`<br>
  `What to say:` `protected internal` allows access from the same assembly or from derived types, while `private protected` is narrower and allows access only from derived types within the same assembly.<br>
  `Focus on:` assembly boundary plus inheritance boundary.
- `Q: When is an indexer a better API than a normal method?`<br>
  `What to say:` Use an indexer when the type naturally behaves like a container that is addressed by position or key. If access involves heavy logic or is not conceptually "lookup-like," a named method is usually clearer.<br>
  `Focus on:` natural container semantics.

<div id="end-of-document"></div>

## Wrap Up

If you think the cheatsheet can be improved, please open a PR with any updates and submit any issues. Also, I will continue to improve this, so you should star this repository, too.

## Contribution

- Open a pull request with improvements
- Discuss ideas in issues
- Spread the word

## License

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

## Author

[Dr. Milan Milanović](https://milan.milanovic.org) -  CTO at [3MD](https://3mdinc.com) and Microsoft MVP for Developer Technologies.
