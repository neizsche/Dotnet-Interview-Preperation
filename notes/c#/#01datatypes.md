# C# Data Types Study Guide

## Table of contents

- [Strings](#strings)
- [Basic types and literals](#basic-types-and-literals)
  - [Value types vs reference types](#value-types-vs-reference-types)
  - [Built-in types and precision](#built-in-types-and-precision)
  - [Nullable value types](#nullable-value-types)
  - [Type inference with var](#type-inference-with-var)
  - [Dynamic typing with dynamic](#dynamic-typing-with-dynamic)
  - [Operators and expressions](#operators-and-expressions)
  - [Quick reference comparisons](#quick-reference-comparisons)
  - [Constants and readonly](#constants-and-readonly)
- [Data types](#data-types)
  - [Classes](#classes)
  - [Structs](#structs)
  - [Records](#records-c-90)
  - [Record structs](#record-structs-c-100)
  - [Interfaces](#interfaces)
  - [Enums](#enums)
  - [Tuples](#tuples)
  - [Nullable types](#nullable-types)

## Strings

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

### Core architecture
* **Immutability:** Strings cannot be changed once created. Any "modification" creates a new object on the managed heap.
* **Memory Layout (64-bit):** * Sync Block Index (8 bytes)
    * Type Handle (8 bytes)
    * Length (4 bytes)
    * Char array + Null Terminator (2 bytes per char)
* **UTF-16 Encoding:** Every `char` is 2 bytes. Loading a 1GB UTF-8 file results in a ~2GB `System.String` object.

---

### Equality vs. comparison
| Feature           | `string.Equals`                | `string.Compare`                      |
| :---------------- | :----------------------------- | :------------------------------------ |
| **Return**        | `bool`                         | `int` (-1, 0, 1)                      |
| **Purpose**       | Identity/Validation            | Sorting/Ordering                      |
| **Best Practice** | Use `StringComparison.Ordinal` | Use for `IComparable` implementations |

---

### High-performance patterns
#### `ReadOnlySpan<char>`
* **What:** A `ref struct` representing a contiguous region of memory.
* **Why:** Allows slicing strings (e.g., `s.AsSpan(0, 5)`) without allocating a new string object on the heap.
* **Benefit:** Zero Garbage Collection (GC) pressure.

#### `string.Create<TState>`
* **What:** Allocates the string first, then provides a `Span` to write data into it.
* **Why:** Avoids the overhead and intermediate copies of `StringBuilder` when the final length is known.

#### `Rune` vs `char`
* A `char` is 16-bit and cannot represent all Unicode characters (e.g., Emojis).
* `Rune` represents a **Unicode Scalar Value**. Always use `Rune` for linguistically correct text processing.

---

### The "Intern Pool" and LOH
* **Interning:** `string.Intern()` stores a string in a process-wide table. 
    * **Trap:** Interning dynamic data (like GUIDs) causes a **permanent memory leak** because the pool is not GC'd.
* **Large Object Heap (LOH):** Strings > 85,000 bytes go to the LOH. 
    * **Risk:** The LOH is not compacted by default, leading to **Memory Fragmentation**.

---

### Interview gotchas

#### 🚩 The `ToUpper()` Comparison Trap
* **Bad:** `if (a.ToUpper() == b.ToUpper())` — Allocates two temporary strings.
* **Good:** `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` — Allocation-free comparison.

#### 🚩 `const` vs `static readonly`
* `const` values are baked into the **calling** assembly at compile-time. If the library changes the constant, the caller must be recompiled.
* `static readonly` is resolved at runtime.

#### 🚩 `GetHashCode()` Persistence
* **Never** store `string.GetHashCode()` in a database. It is non-deterministic across .NET versions and app domains to prevent **Hash Flooding DoS attacks**.

#### 🚩 The "Turkish I" Problem
* Linguistic comparisons (e.g., `CurrentCulture`) behave differently based on the OS locale (e.g., "i" vs "İ").
* **Always** use `StringComparison.Ordinal` for system-level strings (paths, keys, headers).

---

### Performance ranking
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

### Interview prep

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

## Basic types and literals

C# is a strongly-typed language with a comprehensive type system that forms the foundation of all C# programs. Understanding these basic types is essential for writing efficient and type-safe code. 

C# types are categorized as **value types** and **reference types**. The important difference is semantics and copy behavior, not a guaranteed stack-vs-heap rule: value types store their data directly, while reference types store a reference to an object.

### Overview examples

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

### Value types vs reference types

#### Deep dive

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

#### Probable questions and answers

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

#### Additional value/reference notes gathered later

##### Repeated question set

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

##### Advanced value/reference comparison

| Feature              | Value Types (`struct`, `enum`, primitives)           | Reference Types (`class`, `interface`, `delegate`, `string`) |
| :------------------- | :--------------------------------------------------- | :----------------------------------------------------------- |
| **Storage Location** | Typically the **Stack** (or inline in a heap object) | **Managed Heap** (variable stores a pointer)                 |
| **Assignment**       | **Copy by Value:** Creates a full independent copy.  | **Copy by Reference:** Copies the memory address.            |
| **Memory Overhead**  | Low (only the data itself).                          | High (8-byte pointer + 16-byte object header).               |
| **Default Value**    | A "Zeroed" instance (e.g., `0` or `false`).          | `null`.                                                      |
| **Inheritance**      | None (they are implicitly `sealed`).                 | Full support for inheritance/polymorphism.                   |

##### Senior deep dive concepts

###### A. Memory Locality & CPU Cache
Value types are "cache-friendly." If you have an array of structs (`Point[]`), the data is stored contiguously in memory. When the CPU loads one `Point`, it likely loads the next few into the L1 cache.
With an array of classes, the array only contains **pointers**. To get the actual data, the CPU has to "jump" to different locations on the heap (a Cache Miss), which is significantly slower.

###### B. The Boxing/Unboxing Performance Hit
Boxing happens when a value type is converted to a reference type (e.g., casting an `int` to an `object`).
* **The Cost:** A new object is allocated on the heap, the value is copied into it, and a pointer is returned.
* **The Senior Fix:** Use **Generics** (`List<T>`) to ensure the type stays as a value type throughout its lifecycle, avoiding GC pressure.

###### C. `ref struct` (The Ultra-Fast Value Type)
Introduced in modern .NET (like `Span<T>`), a `ref struct` is a value type that is **guaranteed** to never leave the stack. It cannot be boxed, cannot be a field in a class, and cannot be used in `async` methods. This allows for high-performance, allocation-free code.

##### Common interview gotchas

**Q: Are value types ALWAYS on the stack?**
**A: No.** This is a common junior mistake. Value types live wherever they are declared. If a `struct` is a field inside a `class`, that struct lives on the **Heap** as part of the class object. If a value type is part of an array, it lives on the Heap.

**Q: Why is `string` a reference type if it behaves like a value type?**
**A: For memory efficiency.** Strings can be massive. If they were value types, passing them to a method would involve copying the entire character array. By making them **immutable reference types**, .NET can safely pass pointers around without worrying about the original data being changed.

##### Study guide note

###### Value vs. Reference Types
* **Value Types:** Best for small, short-lived data. They reduce GC pressure because they are cleaned up immediately when the stack frame pops.
* **Reference Types:** Best for complex objects with identity and long lifecycles.
* **Architecture Tip:** Use `readonly struct` for small data structures to ensure the compiler doesn't make "defensive copies," which can slow down your code.

---

### Built-in types and precision

#### Numeric types precision
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

#### Date and time deep dive
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

#### Probable questions and answers

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

### Nullable value types

#### Deep implementation
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

#### Advanced patterns
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

#### Probable questions and answers

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

### Type inference with var

#### Compiler implementation
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

#### Advanced scenarios
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

#### Probable questions and answers

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

### Dynamic typing with dynamic

#### DLR (Dynamic Language Runtime) integration
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

#### Advanced dynamic scenarios
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

#### Performance implications
```csharp
// DLR CACHING MECHANISM
// First call to a dynamic member: slow (resolution + cache)
// Subsequent calls: faster (using cache)

// BOXING WITH DYNAMIC
dynamic number = 42;        // int boxed to object
int result = number + 10;   // Unboxing + operation
```

#### Probable questions and answers

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

### Operators and expressions

#### Operator precedence deep dive
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

#### Custom operator overloading
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

#### Tricky operator questions

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

### Quick reference comparisons

#### `var` vs `dynamic`

These are both used when declaring variables in C#, but they behave very differently.

| Feature         | `var`                                        | `dynamic`                              |
| --------------- | -------------------------------------------- | -------------------------------------- |
| Type resolution | At compile time                              | At runtime                             |
| IntelliSense    | Full support                                 | Limited                                |
| Error detection | Compile time                                 | Runtime                                |
| Best use case   | When the type is obvious from the assignment | When the type is unknown until runtime |

##### `var`

- Type-safe: the compiler infers the real type from the right-hand side.
- Compile-time checking: you get IntelliSense, validation, and early errors.
- Must be initialized so the compiler can infer the type.

```csharp
var name = "Alice";  // inferred as string
var age = 30;        // inferred as int

// var something = null; // Compile-time error
```

##### `dynamic`

- Runtime-bound: member access and method resolution happen at runtime.
- Flexible, but unsafe compared to `var`.
- Useful with COM interop, reflection-heavy APIs, or dynamic JSON-like structures.

```csharp
dynamic something = "Hello";
Console.WriteLine(something.Length);  // OK

something = 123;
Console.WriteLine(something.Length);  // RuntimeBinderException at runtime
```

##### When to use each

- Use `var` when the type is known or easily inferred and you want safety.
- Use `dynamic` only when you intentionally want runtime binding.

##### Key point

- `var` is compiler syntax sugar. The actual type is fixed at compile time.
- `dynamic` participates in runtime binding and skips normal compile-time member checks.

---

#### `object` vs `dynamic`

Both can hold values of any type, but they differ in how member access is validated.

| Feature         | `object`                | `dynamic`                                     |
| --------------- | ----------------------- | --------------------------------------------- |
| Type checking   | Compile time            | Runtime                                       |
| Member access   | Requires cast           | No cast required                              |
| Error detection | Compile time            | Runtime                                       |
| Performance     | Faster                  | Slower due to runtime binding                 |
| Best use case   | General-purpose storage | Dynamic APIs, COM, reflection-heavy scenarios |

##### `object`

- Base type of all .NET types.
- You can store anything in it, but you usually need to cast before using members.

```csharp
object obj = "hello";

// Console.WriteLine(obj.Length); // Compile-time error
Console.WriteLine(((string)obj).Length); // Must cast
```

##### `dynamic`

- Internally works like a general reference, but member resolution is deferred to runtime.
- Convenient, but easier to break at execution time.

```csharp
dynamic d = "hello";
Console.WriteLine(d.Length);  // Works

d = 10;
Console.WriteLine(d.Length);  // RuntimeBinderException
```

##### Illustrated difference

```csharp
object obj = "hello";
// Console.WriteLine(obj.Length); // Compile-time error

dynamic dyn = "hello";
Console.WriteLine(dyn.Length); // Checked at runtime
```

##### Guidance

- Use `object` when you want compiler safety and explicit casts.
- Use `dynamic` when the shape of the data is genuinely unknown until runtime.

---

#### `&` vs `&&`

These operators look similar but behave differently.

| Operator | Meaning                    | Works with            | Short-circuits | Common use                                              |
| -------- | -------------------------- | --------------------- | -------------- | ------------------------------------------------------- |
| `&`      | Bitwise AND or logical AND | Integers and booleans | No             | Bitwise work or forcing both boolean expressions to run |
| `&&`     | Logical AND                | Booleans only         | Yes            | Conditional checks in `if`, `while`, and guards         |

##### `&&`

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

##### `&`

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

##### Use case tip

- Use `&&` for regular boolean logic.
- Use `&` for bitwise operations or rare cases where both boolean expressions must run.

---

#### `|` vs `||`

These are the OR equivalents of `&` and `&&`.

| Operator | Meaning | Works with | Short-circuits | Common use |
| --- | --- | --- | --- | --- |
| `|` | Bitwise OR or logical OR | Integers and booleans | No | Bit flags or forcing both boolean expressions to run |
| `||` | Logical OR | Booleans only | Yes | Conditional checks where one true condition is enough |

##### `||`

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

##### `|`

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

##### Use case tip

- Use `||` for normal boolean logic.
- Use `|` for bitwise operations, flags, or rare cases where both expressions must run.

##### Bit flags example

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

### Constants and readonly
* **Use `const` for:** True immutable constants that will NEVER change (e.g., `Math.PI`, `DaysInWeek`).
* **Use `static readonly` for:** Configuration values, calculated values, or reference types that should be shared across the app but resolved at runtime.
* **The Difference:** `const` is a "Search and Replace" by the compiler; `static readonly` is a "Look up in memory" by the CPU.
* **`static` with `readonly`:** Moves the field from the object instance to the Type definition in the Loader Heap.

#### Summary of constants
* **Implicit Static:** `const` is always static. You never write `static const`.
* **The "Magic Number" Rule:** Use `const` only for values that are physically/mathematically impossible to change (e.g., `MinutesInHour = 60`).
* **The "Config" Rule:** Use `static readonly` for anything that might change between environments (e.g., `BaseUrl`, `MaxTimeout`) or requires an object instance.

#### 📊 C# Constants & Static Modifiers Comparison

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

#### 💡 Senior-Level Context for the Table

* **The "Versioning Trap":** If you change a `const` in a DLL, any project referencing that DLL **must** be recompiled to see the new value. With `static readonly`, the change is picked up at runtime without a recompile of the calling app.
* **Implicit Statics:** You never write `static const`. By definition, a compile-time constant cannot belong to an instance; it belongs to the Type.
* **Memory Efficiency:** `const` is the "cheapest" because it doesn't occupy a memory slot at runtime—the value is literally swapped into the instruction stream by the compiler.
* **Thread Safety:** The CLR guarantees that the Static Constructor (where `static readonly` fields are often set) is executed in a thread-safe manner.



---

#### 📝 Final Note for your Study Guide

##### Quick Decision Logic
1. Is it a math/physical constant (e.g., `PI`, `DaysInWeek`)? → Use **const**.
2. Is it a reference type (e.g., `new List<int>()`)? → Use **static readonly**.
3. Does the value come from a Config file or Database at startup? → Use **static readonly**.
4. Does each object instance need its own unique fixed ID? → Use **readonly**.

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

### Interview prep

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


**Additional resources:**

- [Built-in types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Value types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)
- [Reference types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)
- [Constants (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const)
- [DateOnly and timeOnly types (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6#dateonly-and-timeonly)

## Data types

C# supports a variety of composite data types to organize and represent data.

### Classes

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

### Structs

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

### Records (C# 9.0+)

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

### Record structs (C# 10.0+)

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

#### Comparison snapshot: class vs. struct vs. record

| Feature         | `class`                | `struct`                | `record` (class)        | `record struct`          |
| :-------------- | :--------------------- | :---------------------- | :---------------------- | :----------------------- |
| **Type**        | Reference              | Value                   | Reference               | Value                    |
| **Identity**    | By Reference (Pointer) | By Value (Data)         | **By Value** (Equality) | **By Value**             |
| **Inheritance** | Full Support           | None                    | Full Support            | None                     |
| **Use Case**    | Complex logic/State    | Small, short-lived data | **DTOs / API Models**   | High-perf Immutable data |
| **Mutation**    | Mutable by default     | Mutable (Avoid!)        | Immutable (`with`)      | Both available           |

> **The "Senior" Nuance:** Use `record` for DTOs because they provide **Value-based Equality** out of the box. Two different record objects with the same data will return `true` for `Equals()`, which is a lifesaver for unit testing and caching.

### Interfaces

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

#### Additional interface design reminders
* **Senior Perspective:** Interfaces define **contracts**, not behavior.
* **Default Interface Methods (C# 8.0+):** You can now add a body to an interface method. This allows you to update an interface without breaking every class that implements it.
* **Explicit Implementation:** Used to hide methods that aren't relevant to the general consumer but are required for the internal contract.

### Enums

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

#### Additional enum reminders
* **Best Practice:** Always use the `[Flags]` attribute if the enum represents a bitmask (e.g., `Permissions.Read | Permissions.Write`).
* **Senior Trap:** Never use an Enum as a database Primary Key. If the order of the Enum changes in code, your database logic breaks. Always map Enums to `int` or `string` explicitly.

### Tuples

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

#### Additional tuple design reminders
* **Evolution:** We used `System.Tuple` (Reference type, clunky). Now we use **ValueTuples** (Value type, lightweight).
* **Use Case:** Returning multiple values from a private/internal method.
* **The "Senior" Rule:** **Do not expose Tuples in public APIs.** Use a `Record` or `Class` instead. Tuples lack semantic meaning (even with named elements) and make breaking changes harder.

### Nullable types

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

#### Additional nullable reminders
* **Value Types (`int?`):** A wrapper around `Nullable<T>`. It adds a `bool HasValue` flag.
* **Reference Types (`string?`):** This is **Reference Type Nullable Context** (C# 8.0+). It doesn't change the runtime behavior; it provides **compiler warnings** to help you avoid `NullReferenceException`.
* **The "Senior" Nuance:** Treat "Nullable Warnings" as Errors. It forces the team to handle nulls at the boundaries of the application.

### Interview prep

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

#### Related note: Delegates and Events
* **Delegates:** Type-safe function pointers. Use `Action`, `Func`, and `Predicate` instead of custom delegates whenever possible to keep the API standard.
* **Events:** A wrapper around delegates that provides **encapsulation**. 
    * **The Trap:** External classes can only "Subscribe" (`+=`) or "Unsubscribe" (`-=`). They cannot clear the invocation list or trigger the event. 
    * **Memory Leak Alert:** If a long-lived object subscribes to an event in a short-lived object, the short-lived object **cannot be GC'd**. Always unsubscribe in `Dispose()`.

---

#### 📊 Summary Note for Markdown

##### Type System Strategy
* **Classes:** Use for Service logic, Repositories, and objects with a long lifecycle.
* **Structs:** Use for tiny data (<= 16 bytes) that is copied frequently.
* **Records:** The default choice for Data Transfer Objects (DTOs) and "Value Objects" in DDD.
* **Nullable Context:** Enable `<Nullable>enable</Nullable>` in your `.csproj` to eliminate 80% of production bugs.
* **Events:** Great for decoupling, but must be managed carefully to avoid memory leaks (the "Lapsed Listener" problem).

---

### 🏆 Mock interview
You have all the "Senior" knowledge now. Are you ready for a **Quick Fire Interview**? 

I will give you **3 Scenarios**, and you tell me which C# feature you would use and **why**. 

**Scenario 1:** You are building a high-performance math library that processes millions of 3D coordinates $(x, y, z)$ per second. Which type do you use: `class`, `struct`, or `record`?
**Scenario 2:** You need to return an Error Message and an Integer Code from a private validation method. What is the most efficient return type?
**Scenario 3:** You want to allow users to subscribe to a "PriceChanged" notification in a Stock trading app. What mechanism do you use?

**Write your answers and I'll grade your "Seniority"!**

#### Question Bank (Common Questions + What to Say)

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
