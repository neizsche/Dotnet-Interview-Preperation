# Classes and Objects - Deep Dive with Interview Questions

## 1. Constructors

### Deep Understanding

**Constructors** are special methods that initialize objects when they're created. They have the same name as the class and no return type.

#### Types of Constructors:

```csharp
public class Employee
{
    private string _name;
    private int _age;
    private static int _employeeCount;
    
    // 1. Default Constructor (parameterless)
    public Employee()
    {
        _name = "Unknown";
        _age = 0;
        _employeeCount++;
    }
    
    // 2. Parameterized Constructor
    public Employee(string name, int age)
    {
        _name = name;
        _age = age;
        _employeeCount++;
    }
    
    // 3. Static Constructor
    static Employee()
    {
        _employeeCount = 0;
        Console.WriteLine("Static constructor called");
    }
    
    // 4. Private Constructor (Singleton pattern)
    private Employee(string name)
    {
        _name = name;
        _employeeCount++;
    }
    
    // 5. Copy Constructor
    public Employee(Employee other)
    {
        _name = other._name;
        _age = other._age;
        _employeeCount++;
    }
    
    // 6. Constructor Chaining
    public Employee(string name) : this(name, 0) { }
}
```

#### Constructor Execution Order:
1. Static fields initialization
2. Static constructor
3. Instance fields initialization
4. Instance constructor

### Interview Questions & Answers

**Q1: What is the difference between static constructor and instance constructor?**
```csharp
// Static Constructor
static MyClass()
{
    // Called once per application domain
    // Initializes static members
    // No access modifiers allowed
    // Cannot be called directly
}

// Instance Constructor
public MyClass()
{
    // Called each time object is created
    // Initializes instance members
    // Can have access modifiers
}
```

**Q2: When is a static constructor called?**
**Answer:** Static constructor is called:
- Before first instance is created
- Before any static members are referenced
- Only once per application domain

**Q3: Can a constructor be private? When would you use it?**
**Answer:** Yes, private constructors are used for:
- Singleton pattern
- Factory methods
- Preventing instantiation

```csharp
public class Singleton
{
    private static Singleton _instance;
    
    private Singleton() { } // Private constructor
    
    public static Singleton Instance => _instance ??= new Singleton();
}
```

**Q4: What is constructor chaining?**
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person() : this("Unknown", 0) { } // Chains to parameterized constructor
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

**Tricky Q5: What happens if you don't define any constructor?**
**Answer:** C# provides a default public parameterless constructor. But if you define any constructor, the default one is not provided.

---

## 2. Properties

### Deep Understanding

**Properties** provide controlled access to class fields through getters and setters.

#### Property Types:

```csharp
public class Product
{
    private string _name;
    private decimal _price;
    private DateTime _createdDate;
    
    // 1. Auto-implemented Property
    public int Id { get; set; }
    
    // 2. Computed Property (read-only)
    public string DisplayName => $"{Id} - {_name}";
    
    // 3. Full Property with backing field
    public string Name
    {
        get { return _name; }
        set 
        { 
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            _name = value; 
        }
    }
    
    // 4. Expression-bodied Property (C# 6+)
    public decimal Price
    {
        get => _price;
        set => _price = value >= 0 ? value : throw new ArgumentException("Price cannot be negative");
    }
    
    // 5. Getter-only auto property (C# 6+)
    public DateTime CreatedDate { get; } = DateTime.Now;
    
    // 6. Property with different access modifiers
    public string SecretCode { get; private set; }
    
    // 7. Init-only properties (C# 9+)
    public string Category { get; init; }
}
```

### Interview Questions & Answers

**Q1: What's the difference between a field and a property?**
```csharp
public class Example
{
    // Field - direct access, no validation
    public string Field;
    
    // Property - controlled access with validation
    private string _property;
    public string Property
    {
        get => _property;
        set => _property = value ?? throw new ArgumentNullException();
    }
}
```

**Q2: When would you use an auto-implemented property vs full property?**
**Answer:** Use auto-implemented when:
- No validation needed
- No additional logic required
- Use full property when you need validation, logging, or other logic

**Q3: What are init-only properties and when to use them?**
```csharp
public class Person
{
    public string Name { get; init; }  // Can only be set during initialization
    public int Age { get; set; }
}

// Usage:
var person = new Person { Name = "John", Age = 25 }; // OK
// person.Name = "Jane"; // Compile error!
```

**Tricky Q4: What is the output of this code?**
```csharp
public class Test
{
    public int Value { get; set; } = 10;
    
    public Test()
    {
        Console.WriteLine(Value); // What gets printed?
        Value = 20;
    }
}

var test = new Test(); // Output: 10
```

**Q5: Can properties be static?**
**Answer:** Yes, properties can be static:
```csharp
public class Configuration
{
    public static string AppName { get; set; }
    public static int MaxConnections { get; private set; } = 100;
}
```

---

## 3. Fields vs Properties

### Deep Understanding

**Fields** are variables declared directly in a class, while **properties** are members that provide flexible mechanisms to read, write, or compute values.

#### Key Differences:

```csharp
public class BankAccount
{
    // FIELD - Direct storage
    private decimal _balance;
    
    // PROPERTY - Controlled access
    public decimal Balance
    {
        get => _balance;
        private set 
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative");
            _balance = value;
        }
    }
    
    // AUTO-PROPERTY - Compiler creates backing field
    public string AccountNumber { get; set; }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive");
        Balance += amount;  // Uses property setter with validation
        // _balance += amount; // This would bypass validation - BAD!
    }
}
```

### Interview Questions & Answers

**Q1: Why use properties instead of public fields?**
**Answer:** Properties provide:
- Data validation
- Encapsulation
- Ability to change implementation later
- Data binding support
- Interface implementation

**Q2: When would you use a public field instead of a property?**
**Answer:** Almost never in production code. Only in specific scenarios like:
- Private nested classes
- Performance-critical code (measured and proven)
- Simple data transfer objects (though properties are still preferred)

**Q3: What's the performance difference between fields and properties?**
**Answer:** Properties have minimal overhead (usually inlined by JIT). The performance difference is negligible in most cases.

**Tricky Q4: What's wrong with this code?**
```csharp
public class Circle
{
    private double _radius;
    
    public double Radius
    {
        get => _radius;
        set => _radius = value;
    }
    
    public double Area => 3.14 * _radius * _radius; // BUG!
}
```
**Answer:** The Area property uses the backing field directly. If Radius validation is added later, Area won't benefit from it. Should use:
```csharp
public double Area => 3.14 * Radius * Radius; // Uses property, gets validation
```

---

## 4. Access Modifiers

### Deep Understanding

Access modifiers control the visibility and accessibility of class members.

#### Access Levels:

```csharp
public class AccessExample
{
    public string PublicMember = "Anyone can access";
    private string PrivateMember = "Only this class";
    protected string ProtectedMember = "This class and derived classes";
    internal string InternalMember = "Same assembly";
    protected internal string ProtectedInternalMember = "Same assembly OR derived classes";
    private protected string PrivateProtectedMember = "Same assembly AND derived classes";
}

public class DerivedClass : AccessExample
{
    public void TestAccess()
    {
        Console.WriteLine(PublicMember);        // ✓ Accessible
        // Console.WriteLine(PrivateMember);    // ✗ Not accessible
        Console.WriteLine(ProtectedMember);     // ✓ Accessible (derived class)
        Console.WriteLine(InternalMember);      // ✓ If same assembly
        Console.WriteLine(ProtectedInternalMember); // ✓ Accessible
        Console.WriteLine(PrivateProtectedMember); // ✓ If same assembly
    }
}
```

### Interview Questions & Answers

**Q1: What's the difference between protected and private?**
```csharp
public class Base
{
    private string _private = "Only Base can access";
    protected string _protected = "Base and derived classes can access";
}

public class Derived : Base
{
    public void Test()
    {
        // Console.WriteLine(_private);   // ✗ Compile error
        Console.WriteLine(_protected);    // ✓ Allowed
    }
}
```

**Q2: Explain protected internal vs private protected**
**Answer:** 
- `protected internal`: Accessible from same assembly OR derived classes (any assembly)
- `private protected`: Accessible from same assembly AND derived classes

**Tricky Q3: What access level does this property have?**
```csharp
class MyClass
{
    string DefaultAccess { get; set; }  // What's the access level?
}
```
**Answer:** `private` - class members default to private access

**Q4: Can you change access level when overriding?**
**Answer:** You can make it more accessible, but not less:
```csharp
public class Base
{
    protected virtual void Method() { }
}

public class Derived : Base
{
    public override void Method() { }  // ✓ OK - more accessible
    // private override void Method() { } // ✗ Error - less accessible
}
```

---

## 5. Partial Classes and Methods

### Deep Understanding

**Partial classes** allow a class definition to be split across multiple files. **Partial methods** provide lightweight event-handling-like functionality.

#### Partial Classes:

```csharp
// File: Employee.Generated.cs (auto-generated)
public partial class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
}

// File: Employee.Custom.cs (developer code)
public partial class Employee
{
    private string _name;
    
    public new string Name
    {
        get => _name;
        set
        {
            OnNameChanging(value);  // Partial method call
            _name = value;
            OnNameChanged();        // Partial method call
        }
    }
    
    // Implementation of partial methods
    partial void OnNameChanging(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty");
    }
    
    partial void OnNameChanged()
    {
        Console.WriteLine($"Name changed to: {Name}");
    }
}
```

#### Partial Methods Rules:
- Must return void
- Can be static or instance
- Can have ref parameters but not out parameters
- Implicitly private
- If not implemented, calls are removed by compiler

### Interview Questions & Answers

**Q1: Why use partial classes?**
**Answer:** Main uses:
- Separating auto-generated code from custom code
- Multiple developers working on same class
- Organizing large classes logically

**Q2: What happens if a partial method is declared but not implemented?**
**Answer:** The compiler removes all calls to that method. No runtime overhead.

**Q3: Can partial classes span different assemblies?**
**Answer:** No, all parts must be in the same assembly.

**Tricky Q4: What's the output of this code?**
```csharp
public partial class Test
{
    partial void Method();  // Declaration only
    
    public void CallMethod()
    {
        Method();  // This call will be removed if Method not implemented
        Console.WriteLine("Called");
    }
}

// No implementation of Method provided
var test = new Test();
test.CallMethod();  // Output: "Called" (Method call was removed)
```

**Q5: Can you have partial constructors or properties?**
**Answer:** No, only classes, methods, and interfaces can be partial.

---

## Advanced/Tricky Interview Questions

### Q1: Constructor Inheritance Puzzle
```csharp
public class Base
{
    public Base() { Console.WriteLine("Base()"); }
    public Base(int x) { Console.WriteLine($"Base({x})"); }
}

public class Derived : Base
{
    public Derived() { Console.WriteLine("Derived()"); }
    public Derived(int x) : base(x) { Console.WriteLine($"Derived({x})"); }
}

new Derived(5);
// Output: Base(5), Derived(5)
```

### Q2: Property Initialization Order
```csharp
public class Test
{
    public int A { get; set; } = InitA();
    public int B { get; set; } = 10;
    
    public Test() { Console.WriteLine($"Constructor: A={A}, B={B}"); }
    
    private static int InitA() { Console.WriteLine("InitA()"); return 5; }
}

// Output: InitA(), Constructor: A=5, B=10
```

### Q3: Access Modifier Scenarios
```csharp
public class Base
{
    protected virtual void Method() { }
}

public class Derived : Base
{
    protected override void Method() { }  // ✓ Valid
    
    // private override void Method() { }  // ✗ Invalid - cannot reduce accessibility
}
```

### Q4: Partial Class Compilation
```csharp
// File1.cs
public partial class MyClass
{
    private int _value;
    public void SetValue(int v) => _value = v;
}

// File2.cs  
public partial class MyClass
{
    public int GetValue() => _value;  // ✓ Can access private field from other part
}
```

This comprehensive coverage should prepare you for any Classes and Objects questions in your .NET interview!
