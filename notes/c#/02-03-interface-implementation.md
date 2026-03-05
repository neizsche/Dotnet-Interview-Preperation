# Interface Implementation - Complete Guide

## 📚 Deep Knowledge Wiki

### **1. Interface Implementation**

#### **Surface Level:**
An interface defines a contract that classes must implement. It contains method signatures, properties, events, and indexers without implementation.

#### **Deep Understanding:**
```csharp
// Basic interface implementation
public interface ILogger
{
    void Log(string message);
    string Level { get; set; }
}

public class FileLogger : ILogger
{
    public string Level { get; set; }
    
    public void Log(string message)
    {
        File.AppendAllText("log.txt", $"{Level}: {message}");
    }
}
```

**Key Points:**
- Interfaces cannot be instantiated directly
- A class can implement multiple interfaces
- Interface members are implicitly public
- Implementation must match exactly in signature

### **2. Explicit Interface Implementation**

#### **Surface Level:**
When a class implements multiple interfaces with conflicting member names, explicit implementation resolves the conflict.

#### **Deep Understanding:**
```csharp
public interface IDatabase
{
    void Connect();
}

public interface IWebService
{
    void Connect();
}

public class DataService : IDatabase, IWebService
{
    // Explicit implementation - no access modifier
    void IDatabase.Connect() 
    {
        Console.WriteLine("Database connected");
    }
    
    void IWebService.Connect()
    {
        Console.WriteLine("Web service connected");
    }
    
    // Regular method (not part of interface)
    public void Connect()
    {
        Console.WriteLine("Generic connection");
    }
}

// Usage:
DataService service = new DataService();
service.Connect(); // Calls the public method

IDatabase db = service;
db.Connect(); // Calls explicit implementation

IWebService ws = service;
ws.Connect(); // Calls explicit implementation
```

**Key Points:**
- Explicit members are not accessible through class instance
- Required when interfaces have naming conflicts
- No access modifiers allowed on explicit implementations
- Can be used for "hidden" functionality

### **3. Interface Inheritance**

#### **Surface Level:**
Interfaces can inherit from other interfaces, creating interface hierarchies.

#### **Deep Understanding:**
```csharp
public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
}

public interface IReadableRepository<T> : IRepository<T>
{
    IEnumerable<T> GetAll();
    T Find(Func<T, bool> predicate);
}

public interface IWritableRepository<T> : IRepository<T>
{
    void Update(T entity);
    void Delete(int id);
}

public interface IFullRepository<T> : IReadableRepository<T>, IWritableRepository<T>
{
    // Multiple interface inheritance
    int Count { get; }
}

public class CustomerRepository : IFullRepository<Customer>
{
    // Must implement all members from the entire hierarchy
    public void Add(Customer entity) { }
    public Customer GetById(int id) { return null; }
    public IEnumerable<Customer> GetAll() { yield break; }
    public Customer Find(Func<Customer, bool> predicate) { return null; }
    public void Update(Customer entity) { }
    public void Delete(int id) { }
    public int Count => 0;
}
```

**Key Points:**
- Interfaces support multiple inheritance
- Implementing class must satisfy entire hierarchy
- Diamond problem doesn't exist with interfaces
- Great for creating specialized contracts

### **4. Default Interface Methods (C# 8.0+)**

#### **Surface Level:**
Interfaces can now provide default implementations for methods.

#### **Deep Understanding:**
```csharp
public interface IOrderProcessor
{
    // Traditional interface member
    void ProcessOrder(Order order);
    
    // Default implementation
    void ValidateOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));
            
        if (order.Total <= 0)
            throw new ArgumentException("Order total must be positive");
    }
    
    // Static method in interface (C# 8.0+)
    static decimal CalculateTax(decimal amount) => amount * 0.1m;
}

public class BasicOrderProcessor : IOrderProcessor
{
    // Only need to implement non-default members
    public void ProcessOrder(Order order)
    {
        // Can use default implementation
        ((IOrderProcessor)this).ValidateOrder(order);
        // Process order...
    }
}

public class AdvancedOrderProcessor : IOrderProcessor
{
    public void ProcessOrder(Order order) { }
    
    // Can override default implementation
    public void ValidateOrder(Order order)
    {
        // Custom validation logic
        IOrderProcessor.CalculateTax(order.Total); // Static method call
    }
}
```

**Key Points:**
- Default methods enable interface evolution
- Avoid breaking existing implementations
- Static methods allowed in interfaces
- Default methods are virtual (can be overridden)

### **5. Interface Segregation Principle (ISP)**

#### **Surface Level:**
Clients should not be forced to depend on interfaces they don't use.

#### **Deep Understanding:**
```csharp
// ❌ Violates ISP - too large interface
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
    void Code();
    void Test();
    void Deploy();
}

// ✅ Following ISP - segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface IProgrammer : IWorkable
{
    void Code();
    void Test();
}

public interface IDevOps : IWorkable
{
    void Deploy();
}

public class Programmer : IProgrammer, IEatable
{
    public void Work() { }
    public void Code() { }
    public void Test() { }
    public void Eat() { }
    // Doesn't need to implement Deploy()
}

public class Robot : IWorkable
{
    public void Work() { }
    // Doesn't need Eat() or Sleep()
}
```

**Key Points:**
- Prevents "fat" interfaces
- Reduces coupling between classes
- Improves testability and maintainability
- Enables more focused abstractions

### **6. Property Accessors (get, set, init)**

#### **Deep Understanding:**
```csharp
public class Person
{
    // Traditional property with backing field
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    // Auto-implemented property
    public int Age { get; set; }
    
    // Read-only auto property (setter private)
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    // Init-only property (C# 9.0+)
    public DateTime Created { get; init; }
    
    // Expression-bodied property
    public string DisplayName => $"{Name} ({Age})";
    
    // Property with different access levels
    public string Secret { get; protected internal set; }
}

// Usage with init:
var person = new Person 
{ 
    Name = "John", 
    Age = 30,
    Created = DateTime.Now  // Can only set during initialization
};
// person.Created = DateTime.Today; // ❌ Compile error - init-only
```

**Key Points:**
- `init` allows setting only during object initialization
- Different access modifiers for get/set
- Auto-properties generate backing fields automatically
- Expression-bodied properties for simple computations

### **7. Readonly Fields and Structs**

#### **Deep Understanding:**
```csharp
public struct Point
{
    // Readonly field - can only be assigned in constructor
    public readonly int X;
    public readonly int Y;
    
    // Readonly struct (C# 7.2+) - all fields must be readonly
    public readonly double Distance => Math.Sqrt(X * X + Y * Y);
    
    public Point(int x, int y)
    {
        X = x;  // ✅ Allowed in constructor
        Y = y;
    }
    
    // ❌ Cannot modify readonly fields in methods
    // public void Move(int newX) { X = newX; }
}

public class Configuration
{
    // Readonly field for immutable data
    public static readonly string DatabaseConnection;
    
    // Static constructor for readonly field initialization
    static Configuration()
    {
        DatabaseConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
    }
    
    // Readonly instance field
    private readonly List<string> _immutableList;
    
    public Configuration()
    {
        _immutableList = new List<string> { "item1", "item2" };
    }
    
    public void AddItem(string item)
    {
        // _immutableList = new List<string>(); ❌ Cannot reassign
        _immutableList.Add(item); // ✅ Can modify the object itself
    }
}
```

**Key Points:**
- `readonly` fields can only be assigned in constructor
- `readonly struct` ensures complete immutability
- Reference types with `readonly` can still have their content modified
- `static readonly` for shared immutable data

### **8. Constants vs Readonly**

#### **Deep Understanding:**
```csharp
public class MathConstants
{
    // const: compile-time constant, must be primitive or string
    public const double PI = 3.14159;
    public const string AppName = "MyApp";
    
    // readonly: runtime constant, can be any type
    public static readonly DateTime AppStartTime = DateTime.Now;
    public readonly List<string> SupportedLanguages;
    
    // const limitations:
    // public const DateTime CreationDate = DateTime.Now; ❌ Not compile-time constant
    // public const MyClass Instance = new MyClass(); ❌ Not primitive type
    
    public MathConstants()
    {
        SupportedLanguages = new List<string> { "EN", "ES", "FR" };
        // PI = 3.14; ❌ const cannot be changed
        // AppStartTime = DateTime.Today; ❌ static readonly cannot be changed
    }
}

public class Calculator
{
    // const values are replaced at compile-time
    public double CalculateArea(double radius)
    {
        return MathConstants.PI * radius * radius;
    }
    
    // This compiles to: return 3.14159 * radius * radius;
}

// Usage differences:
double area = MathConstants.PI * 10 * 10; // ✅ const usage

// DateTime start = MathConstants.AppStartTime; ✅ readonly usage
```

**Key Points:**
- `const`: compile-time, must be primitive, embedded in IL
- `readonly`: runtime, can be any type, evaluated at runtime
- `const` values are static by nature
- `readonly` can be instance or static members

### **9. Accessor Accessibility Levels**

#### **Deep Understanding:**
```csharp
public class BankAccount
{
    private decimal _balance;
    
    // Different accessibility for getter and setter
    public decimal Balance 
    { 
        get => _balance;
        private set => _balance = value >= 0 ? value : throw new ArgumentException("Balance cannot be negative");
    }
    
    // Protected get, public set (uncommon but possible)
    public string AccountNumber { protected get; set; }
    
    // Internal setter
    public DateTime LastActivity { get; internal set; }
    
    // Private setter with public get - most common pattern
    public int TransactionCount { get; private set; }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive");
        Balance += amount;  // ✅ Can set because we're in the class
        TransactionCount++;
    }
    
    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive");
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
        Balance -= amount;
        TransactionCount++;
    }
}

public class Bank
{
    public void UpdateAccount(BankAccount account)
    {
        // account.Balance = 1000; ❌ private set
        // account.TransactionCount = 0; ❌ private set
        account.LastActivity = DateTime.Now; // ✅ internal set
    }
}
```

**Key Points:**
- Accessor accessibility must be more restrictive than property
- Useful for encapsulation and controlled modification
- Common pattern: public get, private/internal set
- Ensures business rules are enforced

---

## ❓ Probable Interview Questions & Answers

### **Q1: What's the difference between implicit and explicit interface implementation?**

**Answer:**
```csharp
public interface IWorker { void Work(); }
public interface IEater { void Work(); } // Same method name!

public class Employee : IWorker, IEater
{
    // Implicit implementation
    public void Work() => Console.WriteLine("General work");
    
    // Explicit implementations
    void IWorker.Work() => Console.WriteLine("IWorker work");
    void IEater.Work() => Console.WriteLine("IEater work");
}

// Usage:
var emp = new Employee();
emp.Work(); // "General work" - calls implicit implementation

IWorker worker = emp;
worker.Work(); // "IWorker work" - calls explicit implementation

IEater eater = emp;
eater.Work(); // "IEater work" - calls explicit implementation
```

**Reasoning:** Explicit implementation resolves naming conflicts and allows "hiding" interface-specific behavior. The class can provide its own default implementation while still satisfying interface contracts.

---

### **Q2: When would you use default interface methods?**

**Answer:**
```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default method - won't break existing implementations
    void LogError(string message) => Log($"ERROR: {message}");
    
    // Static helper method
    static string FormatMessage(string level, string message) => $"[{level}] {message}";
}

// Existing class doesn't need to change
public class FileLogger : ILogger
{
    public void Log(string message) => File.AppendAllText("log.txt", message);
}

// New class can override default behavior
public class AdvancedLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
    public void LogError(string message) => Log($"[CRITICAL] {message}");
}
```

**Reasoning:** Default interface methods enable interface evolution without breaking existing implementations. They're perfect for adding helper methods or providing common functionality that implementers can override if needed.

---

### **Q3: How does interface inheritance differ from class inheritance?**

**Answer:**
```csharp
public interface IA { void MethodA(); }
public interface IB { void MethodB(); }
public interface IC : IA, IB { void MethodC(); } // Multiple inheritance!

public class BaseClass { public void BaseMethod() { } }

public class MyClass : BaseClass, IC // Single class inheritance, multiple interface implementation
{
    public void MethodA() { }
    public void MethodB() { }
    public void MethodC() { }
}

// ❌ This is illegal:
// public class Derived : BaseClass, AnotherClass { }
```

**Reasoning:** Interfaces support multiple inheritance, while classes only support single inheritance. This allows a class to have multiple "contracts" but only one "implementation heritage." Interface inheritance is about satisfying contracts, class inheritance is about code reuse.

---

### **Q4: What's the practical difference between const and readonly?**

**Answer:**
```csharp
public class ConstantsExample
{
    public const int MAX_USERS = 100; // Compile-time constant
    public static readonly DateTime APP_START = DateTime.Now; // Runtime constant
    
    public readonly string DatabaseName; // Instance readonly
    
    public ConstantsExample(string dbName)
    {
        DatabaseName = dbName; // Can only set in constructor
    }
    
    public void UseConstants()
    {
        int limit = MAX_USERS; // Literal value embedded in IL
        DateTime start = APP_START; // Value resolved at runtime
        
        // MAX_USERS = 200; ❌ Compile error
        // APP_START = DateTime.Today; ❌ Compile error
        // DatabaseName = "NewName"; ❌ Compile error
    }
}
```

**Reasoning:** `const` values are resolved at compile-time and must be primitive types. `readonly` values are resolved at runtime and can be any type. Use `const` for true mathematical constants, `readonly` for values that might change between deployments or require computation.

---

### **Q5: When would you use init-only properties vs readonly fields?**

**Answer:**
```csharp
public class ImmutablePerson
{
    // Readonly field - more restrictive
    public readonly Guid Id = Guid.NewGuid();
    
    // Init-only property - flexible initialization
    public string Name { get; init; }
    public int Age { get; init; }
    
    // Computed property
    public string Description => $"{Name} ({Age})";
    
    public ImmutablePerson() { }
    
    public ImmutablePerson(string name, int age)
    {
        Name = name;
        Age = age;
        // Id = Guid.NewGuid(); // ✅ Can set readonly field in constructor
    }
}

// Usage:
var person1 = new ImmutablePerson { Name = "John", Age = 30 }; // Object initializer
var person2 = new ImmutablePerson("Jane", 25); // Constructor

// person1.Name = "Bob"; ❌ Init-only can't be changed after initialization
// person1.Id = Guid.NewGuid(); ❌ Readonly field can't be changed
```

**Reasoning:** Use `readonly` fields for true immutability that never changes after construction. Use `init` properties for objects that should be immutable after initialization but need flexible construction patterns (like object initializers).

---

### **Q6: Tricky Scenario - Interface with default method and class inheritance**

**Question:** What happens when a class inherits from a base class and implements an interface with default methods?

**Answer:**
```csharp
public interface IService
{
    void Execute() => Console.WriteLine("Interface default");
}

public class BaseService
{
    public void Execute() => Console.WriteLine("Base class method");
}

public class MyService : BaseService, IService
{
    // No need to implement Execute() - inherits from BaseService
    // But which Execute() gets called?
}

// Usage:
var service = new MyService();
service.Execute(); // "Base class method" - class members win

IService iservice = service;
iservice.Execute(); // "Interface default" - interface default is used when viewed as interface
```

**Reasoning:** Class members always take precedence over interface default methods. However, when the object is treated as the interface type, the interface default method is used if the class doesn't explicitly implement the interface member.

---

### **Q7: Advanced - Interface segregation with generic constraints**

**Question:** How would you apply ISP with generic repositories?

**Answer:**
```csharp
// Segregated interfaces
public interface IReadableRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}

public interface IWritableRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}

public interface ISearchableRepository<T>
{
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}

// Combined interface for convenience
public interface IRepository<T> : IReadableRepository<T>, IWritableRepository<T>, ISearchableRepository<T>
{
}

// Generic constraints example
public interface IAuditable
{
    DateTime Created { get; set; }
    string CreatedBy { get; set; }
}

public interface IAuditableRepository<T> : IRepository<T> where T : IAuditable
{
    IEnumerable<T> GetCreatedBy(string user);
    IEnumerable<T> GetRecent(DateTime since);
}
```

**Reasoning:** This demonstrates ISP by separating concerns and using generic constraints to create specialized interfaces. Clients can depend only on what they need, and the design remains flexible and testable.

---

### **Q8: Tricky - Readonly struct with property mutation**

**Question:** Can you modify properties in a readonly struct?

**Answer:**
```csharp
public readonly struct Point
{
    public int X { get; }
    public int Y { get; }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // This is illegal in readonly struct:
    // public void Move(int newX) { X = newX; } ❌ Cannot modify
    
    // But you can create new instances:
    public Point WithX(int newX) => new Point(newX, Y);
    public Point WithY(int newY) => new Point(X, newY);
}

// Usage:
var point = new Point(10, 20);
var movedPoint = point.WithX(30); // Returns new instance
```

**Reasoning:** In a `readonly struct`, all fields must be readonly, and properties cannot have setters. However, you can create methods that return new instances with modified values, following functional programming principles.

---

## 🎯 Key Takeaways for Interviews

1. **Always mention the "why"** - not just what something does, but when and why you'd use it
2. **Understand the performance implications** - `readonly struct` vs classes, `const` vs `readonly`
3. **Know the versioning aspects** - default interface methods for backward compatibility
4. **Practice the tricky scenarios** - explicit implementation conflicts, inheritance hierarchies
5. **Relate to principles** - how these features support SOLID principles, especially ISP

This comprehensive coverage should prepare you for any interface-related questions in your .NET interviews!
