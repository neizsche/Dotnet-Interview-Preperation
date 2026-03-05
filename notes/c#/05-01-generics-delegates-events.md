# Generics, Delegates & Events - Complete Guide

## 🎯 **Generics - Deep Dive**

### **1. Generic Classes and Methods**

#### **Surface Level Knowledge**
Generics allow you to define type-safe data structures without committing to actual data types.

```csharp
// Generic class
public class Repository<T>
{
    private List<T> _items = new List<T>();
    
    public void Add(T item) => _items.Add(item);
    public T Get(int index) => _items[index];
}

// Generic method
public T FindMax<T>(T[] array) where T : IComparable<T>
{
    T max = array[0];
    foreach (T item in array)
        if (item.CompareTo(max) > 0) max = item;
    return max;
}
```

#### **Deep Technical Details**

**Type Erasure and Reification:**
- **.NET Generics are reified** - type information is available at runtime
- **Java Generics use type erasure** - type information is lost at runtime
- This enables reflection on generic types in .NET

```csharp
// Runtime type information is preserved
var list = new List<int>();
Console.WriteLine(list.GetType().GetGenericArguments()[0].Name); // Outputs: Int32
```

**Performance Benefits:**
- **No boxing/unboxing** for value types
- **No runtime casts** needed
- **Better CPU cache utilization** due to type-specific code generation

```csharp
// Without generics - boxing occurs
ArrayList list = new ArrayList();
list.Add(42); // Boxing - int to object
int value = (int)list[0]; // Unboxing - object to int

// With generics - no boxing
List<int> genericList = new List<int>();
genericList.Add(42); // No boxing
int value = genericList[0]; // No unboxing
```

### **2. Generic Constraints**

#### **Constraints Reference Table**

| Constraint | Syntax | Usage | Example |
|------------|--------|--------|---------|
| **Class** | `where T : class` | T must be reference type | `T Create<T>() where T : class, new()` |
| **Struct** | `where T : struct` | T must be value type | `T? Parse<T>(string s) where T : struct` |
| **new()** | `where T : new()` | T must have parameterless constructor | `T CreateInstance<T>() where T : new()` |
| **Base Class** | `where T : BaseClass` | T must derive from BaseClass | `void Process<T>(T obj) where T : Stream` |
| **Interface** | `where T : IInterface` | T must implement interface | `T Clone<T>(T obj) where T : ICloneable` |
| **Naked** | `where T : U` | T must be or derive from U | `T Convert<T, U>(U source) where T : U` |

#### **When to Use Which Constraint**

```csharp
// Use 'class' when you need reference semantics
public class ReferenceRepository<T> where T : class
{
    public bool IsNull(T item) => item == null;
}

// Use 'struct' when you need value semantics
public struct Point<T> where T : struct
{
    public T X, Y;
}

// Use 'new()' when you need to create instances
public T CreateDefault<T>() where T : new()
{
    return new T(); // Only possible with new() constraint
}

// Use base class/interface constraints for specific functionality
public void Serialize<T>(T obj) where T : ISerializable
{
    obj.Serialize(); // Can call interface methods
}
```

### **3. Covariance and Contravariance**

#### **Variance Reference Table**

| Variance Type | Keyword | Direction | Example | Usage |
|---------------|---------|-----------|---------|--------|
| **Covariance** | `out` | Preserves inheritance | `IEnumerable<Derived>` → `IEnumerable<Base>` | Output positions only |
| **Contravariance** | `in` | Reverses inheritance | `Action<Base>` → `Action<Derived>` | Input positions only |
| **Invariance** | (none) | No conversion | `List<Base>` ≠ `List<Derived>` | Both input and output |

#### **Deep Technical Implementation**

```csharp
// Covariant interface - T can only be in output positions
public interface IReadOnlyRepository<out T>
{
    T GetById(int id); // ✅ Valid - T in output position
    // void Add(T item); // ❌ Invalid - T in input position
}

// Contravariant interface - T can only be in input positions  
public interface IWriteOnlyRepository<in T>
{
    void Add(T item); // ✅ Valid - T in input position
    // T GetById(int id); // ❌ Invalid - T in output position
}

// Real-world example with inheritance
class Animal { }
class Dog : Animal { }

IEnumerable<Dog> dogs = new List<Dog>();
IEnumerable<Animal> animals = dogs; // ✅ Covariance works

Action<Animal> animalAction = (a) => Console.WriteLine(a.GetType());
Action<Dog> dogAction = animalAction; // ✅ Contravariance works
dogAction(new Dog()); // Calls animalAction with Dog
```

### **4. Generic Type Inference**

#### **How Type Inference Works**
The compiler deduces type arguments based on method arguments.

```csharp
public static TOutput Process<TInput, TOutput>(TInput input, Func<TInput, TOutput> converter)
{
    return converter(input);
}

// Type inference in action
var result = Process(42, x => x.ToString()); 
// TInput inferred as int, TOutput inferred as string
// Equivalent to: Process<int, string>(42, x => x.ToString());
```

#### **Inference Limitations**
```csharp
// Cannot infer from return type alone
public static T Create<T>() where T : new() => new T();

// var item = Create(); // ❌ Error - cannot infer T
var item = Create<List<int>>(); // ✅ Explicit type needed

// Sometimes inference fails with complex scenarios
public static void Method<T>(T a, T b) { }
Method(10, 10.5); // ❌ Error - cannot infer T (int vs double)
Method<int>(10, 10); // ✅ Explicit type needed
```

---

## 🎯 **Delegates & Events - Deep Dive**

### **1. Delegate Types and Declarations**

#### **Delegate Evolution in C#**

```csharp
// 1. Delegate declaration (C# 1.0)
public delegate void SimpleDelegate(string message);
public delegate int CalculatorDelegate(int x, int y);

// 2. Generic delegates (C# 2.0+)
public delegate TResult Func<in T, out TResult>(T arg);
public delegate void Action<in T>(T arg);

// Usage examples
SimpleDelegate del1 = new SimpleDelegate(Method1);
SimpleDelegate del2 = Method1; // Simplified syntax

// Multicast delegate
SimpleDelegate multiDel = Method1;
multiDel += Method2; // Combines delegates
```

#### **Delegate Internals**
Delegates are actually classes that inherit from `System.MulticastDelegate`.

```csharp
// What the compiler actually generates
[System.Serializable]
public class SimpleDelegate : System.MulticastDelegate
{
    public SimpleDelegate(object target, IntPtr method);
    public virtual void Invoke(string message);
    public virtual IAsyncResult BeginInvoke(string message, AsyncCallback callback, object state);
    public virtual void EndInvoke(IAsyncResult result);
}
```

### **2. Action, Func, Predicate Delegates**

#### **Built-in Delegate Comparison Table**

| Delegate | Signature | Purpose | Example Usage |
|----------|-----------|---------|---------------|
| **Action** | `void Action()` | No parameters, no return | `Action action = () => Console.WriteLine();` |
| **Action<T>** | `void Action<T>(T arg)` | One parameter, no return | `Action<string> action = s => Console.WriteLine(s);` |
| **Action<T1,T2>** | `void Action<T1,T2>(T1 arg1, T2 arg2)` | Multiple parameters, no return | `Action<int,string> action = (i,s) => Console.WriteLine(i+s);` |
| **Func<TResult>** | `TResult Func<TResult>()` | No parameters, with return | `Func<int> func = () => 42;` |
| **Func<T,TResult>** | `TResult Func<T,TResult>(T arg)` | One parameter, with return | `Func<string,int> func = s => s.Length;` |
| **Predicate<T>** | `bool Predicate<T>(T obj)` | One parameter, returns bool | `Predicate<int> pred = x => x > 0;` |

#### **When to Use Which**

```csharp
// Use Action for void methods
public void ProcessData(Action<string> logger)
{
    logger("Processing started");
    // ... processing
    logger("Processing completed");
}

// Use Func for methods with return values
public T Transform<T>(T input, Func<T, T> transformer)
{
    return transformer(input);
}

// Use Predicate specifically for boolean conditions
public List<T> Filter<T>(List<T> list, Predicate<T> condition)
{
    return list.FindAll(condition);
}

// Real-world usage
var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Using Predicate (specific intent)
var evens = numbers.FindAll(x => x % 2 == 0);

// Using Func (more general)
var evensFunc = numbers.Where(x => x % 2 == 0).ToList();
```

### **3. Anonymous Methods and Lambda Expressions**

#### **Evolution of Anonymous Functions**

```csharp
// C# 1.0 - Named methods only
void NamedMethod(string s) { Console.WriteLine(s); }
Action<string> del = NamedMethod;

// C# 2.0 - Anonymous methods
Action<string> anonymousDel = delegate(string s) 
{ 
    Console.WriteLine(s); 
};

// C# 3.0 - Lambda expressions
Action<string> lambdaDel = s => Console.WriteLine(s);

// Expression lambdas vs Statement lambdas
Func<int, int> square = x => x * x; // Expression lambda
Func<int, int> squareBlock = x => 
{ 
    return x * x; // Statement lambda
};
```

#### **Lambda Expression Trees**
Lambda expressions can be compiled to executable code or expression trees.

```csharp
// Compiles to executable code
Func<int, int> square = x => x * x;
int result = square(5); // 25

// Compiles to expression tree (can be analyzed)
Expression<Func<int, int>> squareExpr = x => x * x;
// Can inspect: squareExpr.Body is BinaryExpression

// Usage in LINQ providers
var query = db.Users.Where(u => u.Age > 18);
// Entity Framework converts lambda to SQL
```

### **4. Multicast Delegates and Event Patterns**

#### **Multicast Delegate Behavior**

```csharp
public delegate void ProgressDelegate(int percentage);

class Processor
{
    public void Process(ProgressDelegate progress)
    {
        for (int i = 0; i <= 100; i += 10)
        {
            progress(i); // Calls all registered methods
            Thread.Sleep(100);
        }
    }
}

// Usage
var processor = new Processor();
ProgressDelegate multi = null;
multi += p => Console.WriteLine($"Progress: {p}%");
multi += p => Console.WriteLine($"Working... {p}%");

processor.Process(multi);
```

#### **Events vs Delegates**

| Aspect | Delegate | Event |
|--------|----------|-------|
| **Declaration** | `public delegate void Handler()` | `public event EventHandler MyEvent` |
| **Invocation** | Can be called by anyone | Can only be raised by declaring class |
| **Subscription** | `handler = method` or `handler += method` | `event += method` only |
| **Encapsulation** | No protection | Protected invocation |
| **Null checking** | Required before invocation | Built-in thread-safe null check |

```csharp
// Proper event pattern
public class Button
{
    public event EventHandler Click;
    
    protected virtual void OnClick()
    {
        Click?.Invoke(this, EventArgs.Empty); // Thread-safe null check
    }
}

// Custom event args
public class PriceChangedEventArgs : EventArgs
{
    public decimal OldPrice { get; }
    public decimal NewPrice { get; }
    
    public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }
}

public class Stock
{
    public event EventHandler<PriceChangedEventArgs> PriceChanged;
    
    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                var oldPrice = _price;
                _price = value;
                PriceChanged?.Invoke(this, new PriceChangedEventArgs(oldPrice, value));
            }
        }
    }
}
```

---

## ❓ **Probable Interview Questions & Answers**

### **Generics Questions**

#### **Q1: What are the performance benefits of generics?**
**Answer:** 
- **Eliminates boxing/unboxing** for value types
- **Provides type safety** at compile time
- **No runtime casts** needed
- **Better performance** due to specialized IL generation
- **Reduces code bloat** compared to multiple specific implementations

**Reasoning:** Without generics, you'd use `object` which requires boxing for value types and casting when retrieving values.

#### **Q2: Why can't you use arithmetic operators in generic methods?**
**Answer:** Because the compiler doesn't know if `T` supports arithmetic operations. You need constraints:

```csharp
// ❌ This doesn't work
public T Add<T>(T a, T b) => a + b;

// ✅ Use constraints or dynamic
public T Add<T>(T a, T b) where T : INumber<T> => a + b;
// Or use dynamic (with performance cost)
public T Add<T>(T a, T b) => (dynamic)a + (dynamic)b;
```

#### **Q3: What's the difference between `default(T)` and `new T()`?**
**Answer:**
- `default(T)` returns `null` for reference types, `0` for numeric value types
- `new T()` requires `where T : new()` constraint and calls parameterless constructor
- `default(T)` works for all types, `new T()` only for types with parameterless constructors

#### **Tricky Q4: Why can't you have a `where T : enum` constraint?**
**Answer:** This constraint doesn't exist in C#. Workaround:
```csharp
public static T ParseEnum<T>(string value) where T : struct, Enum
{
    return Enum.Parse<T>(value);
}
```

### **Delegate & Events Questions**

#### **Q1: What happens when you invoke a null delegate vs a null event?**
**Answer:**
```csharp
MyDelegate del = null;
del(); // ❌ NullReferenceException

// Events are safer
public event EventHandler MyEvent;
MyEvent?.Invoke(this, EventArgs.Empty); // ✅ No exception
```

**Reasoning:** Events provide built-in thread-safe null checking.

#### **Q2: What's the difference between `Action` and `Func`?**
**Answer:** 
- `Action` represents void methods (no return value)
- `Func` represents methods with return values (last type parameter is return type)

```csharp
Action<int> action = x => Console.WriteLine(x); // void
Func<int, string> func = x => x.ToString(); // returns string
```

#### **Tricky Q3: Why can't you use covariance with `List<T>`?**
**Answer:** `List<T>` is invariant for safety reasons:

```csharp
List<string> strings = new List<string>();
// List<object> objects = strings; // ❌ Compiler error

// Why? This would allow type-unsafe operations:
// objects.Add(123); // Adding int to List<string>!
```

#### **Q4: What's the difference between events and delegates?**
**Answer:**
- **Encapsulation:** Events protect the invocation list
- **Access:** Outside code can only subscribe/unsubscribe to events
- **Null safety:** Events have built-in thread-safe invocation
- **Intent:** Events signal that something happened, delegates are general-purpose

### **Advanced/Tricky Questions**

#### **Q1: Why can't you use `out` parameters in lambda expressions?**
**Answer:** Lambda expressions cannot capture `out` or `ref` parameters due to lifetime and safety concerns:

```csharp
// ❌ This doesn't work
void Method(out int x)
{
    Action action = () => x = 10; // Error
}

// ✅ Workaround: use local variable
void Method(out int x)
{
    int temp = 0;
    Action action = () => temp = 10;
    action();
    x = temp;
}
```

#### **Q2: What happens when a multicast delegate throws an exception?**
**Answer:** The invocation stops at the method that throws:

```csharp
Action multi = () => Console.WriteLine("First");
multi += () => throw new Exception("Error");
multi += () => Console.WriteLine("Third");

try { multi(); } catch { }
// Output: "First" then exception - "Third" never executes
```

#### **Q3: Can you explain covariance/contravariance with real examples?**
**Answer:** 

**Covariance (out):** You can use a more derived type where a base type is expected
```csharp
IEnumerable<Dog> dogs = new List<Dog>();
IEnumerable<Animal> animals = dogs; // ✅ Covariant
```

**Contravariance (in):** You can use a more general type where a specific type is expected
```csharp
Action<Animal> actAnimal = a => a.Feed();
Action<Dog> actDog = actAnimal; // ✅ Contravariant
actDog(new Dog()); // Feeds the dog
```

#### **Q4: What's the performance impact of using `dynamic` with generics?**
**Answer:** Using `dynamic` bypasses compile-time type checking and can be 10-100x slower due to:
- Runtime type resolution
- Reflection overhead
- Lack of optimization opportunities

```csharp
// Slow - dynamic
public T AddDynamic<T>(T a, T b) => (dynamic)a + (dynamic)b;

// Fast - constrained
public T AddConstrained<T>(T a, T b) where T : INumber<T> => a + b;
```

### **Follow-up Questions Interviewers Love**

#### **"Can you give me a real-world example where you'd use..."**

**Generic constraints:**
```csharp
// Repository pattern with entity constraint
public interface IRepository<T> where T : class, IEntity
{
    T GetById(int id);
    void Save(T entity);
}
```

**Covariance:**
```csharp
// Factory that returns specific types but can be treated generally
interface IFactory<out T> where T : Vehicle
{
    T Create();
}

IFactory<Car> carFactory = new CarFactory();
IFactory<Vehicle> vehicleFactory = carFactory; // Covariant
```

**Events:**
```csharp
// Observer pattern for price monitoring
public class StockTicker
{
    public event EventHandler<PriceChangedEventArgs> PriceChanged;
    
    public void UpdatePrice(string symbol, decimal price)
    {
        PriceChanged?.Invoke(this, new PriceChangedEventArgs(symbol, price));
    }
}
```

This comprehensive guide covers both surface-level knowledge for quick recall and deep technical understanding for advanced interviews. The key is understanding not just **how** these features work, but **why** they were designed that way and **when** to use each appropriately.
