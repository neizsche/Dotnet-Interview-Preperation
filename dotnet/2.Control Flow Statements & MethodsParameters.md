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
