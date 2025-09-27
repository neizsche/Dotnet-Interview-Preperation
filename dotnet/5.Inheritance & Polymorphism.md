# Inheritance & Polymorphism - Complete Guide

## 📚 **Detailed Knowledge Wiki**

### **1. Base and Derived Classes**

**Surface Level:**
Inheritance allows a class (derived) to inherit members from another class (base). This creates an "is-a" relationship.

**Deep Dive:**
```csharp
public class Vehicle  // Base class
{
    public string Make { get; set; }
    public string Model { get; set; }
    
    public Vehicle(string make, string model)
    {
        Make = make;
        Model = model;
    }
    
    public virtual void Start() => Console.WriteLine("Vehicle starting...");
}

public class Car : Vehicle  // Derived class
{
    public int Doors { get; set; }
    
    // Constructor chaining to base class
    public Car(string make, string model, int doors) : base(make, model)
    {
        Doors = doors;
    }
    
    public override void Start() => Console.WriteLine("Car starting with ignition...");
}
```

**Key Concepts:**
- **Accessibility**: Derived classes can access public and protected members of base class
- **Constructor Execution**: Base constructor runs before derived constructor
- **Member Inheritance**: All non-private members are inherited
- **Single Inheritance**: C# supports single class inheritance (multiple interface inheritance)

### **2. sealed keyword**

**Surface Level:**
Prevents other classes from inheriting from a class or overriding a method.

**Deep Dive:**
```csharp
public sealed class FinalClass  // Cannot be inherited
{
    public void Method() => Console.WriteLine("Final method");
}

// This would cause COMPILER ERROR:
// public class DerivedClass : FinalClass { }

public class BaseClass
{
    public virtual void VirtualMethod() { }
    
    public sealed override void VirtualMethod()  // Cannot be overridden further
    {
        Console.WriteLine("This implementation is sealed");
    }
}
```

**Key Concepts:**
- **Class Level**: Prevents any inheritance from the class
- **Method Level**: Prevents further overriding in derived classes
- **Performance**: Sealed classes/methods can be optimized by JIT compiler
- **Design Intent**: Indicates the class/method is complete and shouldn't be extended

### **3. base keyword usage**

**Surface Level:**
Used to access base class members from a derived class.

**Deep Dive:**
```csharp
public class Animal
{
    protected string _name;
    
    public Animal(string name) => _name = name;
    
    public virtual void Speak() => Console.WriteLine("Animal sound");
    
    protected void InternalMethod() => Console.WriteLine("Internal base method");
}

public class Dog : Animal
{
    public Dog(string name) : base(name)  // Calling base constructor
    {
    }
    
    public override void Speak()
    {
        base.Speak();  // Calling base method
        Console.WriteLine("Woof! Woof!");
    }
    
    public void AccessBaseMethod() => base.InternalMethod();  // Accessing protected member
}
```

**Key Concepts:**
- **Constructor Chaining**: Must be first statement in derived constructor
- **Method Access**: Can call base implementation even when overridden
- **Protected Access**: Can access protected members of base class
- **Static Context**: Cannot use `base` in static methods

### **4. Constructor Chaining**

**Surface Level:**
Calling one constructor from another within the same class or base class.

**Deep Dive:**
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Primary constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Primary constructor called");
    }
    
    // Constructor chaining to primary constructor
    public Person(string name) : this(name, 0)  // 'this' for same class
    {
        Console.WriteLine("Secondary constructor called");
    }
}

public class Employee : Person
{
    public string Department { get; set; }
    
    public Employee(string name, int age, string department) : base(name, age)  // 'base' for base class
    {
        Department = department;
        Console.WriteLine("Employee constructor called");
    }
}
```

**Execution Order:**
1. Base class constructor
2. Derived class constructor
3. Constructor chaining within same class

### **5. Method Overriding (virtual/override)**

**Surface Level:**
Allows derived classes to provide specific implementation of base class methods.

**Deep Dive:**
```csharp
public class Shape
{
    public virtual void Draw()  // Virtual method - can be overridden
    {
        Console.WriteLine("Drawing a shape");
    }
    
    public virtual double CalculateArea() => 0;
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public override void Draw()  // Override base implementation
    {
        Console.WriteLine($"Drawing circle with radius {Radius}");
    }
    
    public override double CalculateArea() => Math.PI * Radius * Radius;
    
    // This would cause COMPILER ERROR - method must be virtual to override:
    // public override void SomeMethod() { }
}
```

**Key Concepts:**
- **Virtual Methods**: Must be explicitly marked as `virtual`
- **Override Requirement**: Must match signature exactly
- **Accessibility**: Cannot reduce accessibility (public virtual → public override ✓)
- **Sealed Overrides**: Can seal an override to prevent further overriding

### **6. Method Hiding (new keyword)**

**Surface Level:**
Creates a new method that hides the base class method instead of overriding it.

**Deep Dive:**
```csharp
public class BaseClass
{
    public void Method() => Console.WriteLine("Base method");
    
    public virtual void VirtualMethod() => Console.WriteLine("Base virtual method");
}

public class DerivedClass : BaseClass
{
    // Method hiding - creates NEW method, doesn't override
    public new void Method() => Console.WriteLine("Derived method (hiding)");
    
    // This hides the virtual method - DANGEROUS!
    public new void VirtualMethod() => Console.WriteLine("Derived method (hiding virtual)");
}

// Usage example:
BaseClass obj = new DerivedClass();
obj.Method();  // Calls BASE method (not hidden due to reference type)
obj.VirtualMethod();  // Calls BASE virtual method

DerivedClass derivedObj = new DerivedClass();
derivedObj.Method();  // Calls DERIVED method
```

**Key Concepts:**
- **Compile-time Binding**: Resolution based on reference type, not object type
- **Warning Suppression**: `new` keyword suppresses compiler warning
- **Polymorphism Break**: Hiding breaks polymorphism - avoid with virtual methods
- **Explicit Intent**: Clearly indicates hiding is intentional

### **7. Abstract Classes and Methods**

**Surface Level:**
Classes that cannot be instantiated and may contain abstract methods that must be implemented by derived classes.

**Deep Dive:**
```csharp
public abstract class DatabaseConnection  // Abstract class
{
    protected string ConnectionString { get; set; }
    
    // Abstract method - MUST be implemented by derived classes
    public abstract void Connect();
    public abstract void Disconnect();
    
    // Concrete method - has implementation
    public virtual void TestConnection() => Console.WriteLine("Testing connection...");
    
    // Constructor in abstract class - called by derived classes
    protected DatabaseConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}

public class SqlConnection : DatabaseConnection
{
    public SqlConnection(string connectionString) : base(connectionString) { }
    
    // MUST implement abstract methods
    public override void Connect() => Console.WriteLine("SQL Connection established");
    public override void Disconnect() => Console.WriteLine("SQL Connection closed");
    
    // Can override virtual methods
    public override void TestConnection()
    {
        base.TestConnection();
        Console.WriteLine("SQL-specific connection test");
    }
}
```

**Key Concepts:**
- **Instantiation**: Cannot create instance of abstract class
- **Implementation Requirement**: Derived classes MUST implement all abstract methods
- **Constructor Usage**: Can have constructors for initialization
- **Partial Implementation**: Can mix abstract and concrete methods

### **8. Runtime vs Compile-time Polymorphism**

**Surface Level:**
Compile-time polymorphism (method overloading) vs Runtime polymorphism (method overriding).

**Deep Dive:**
```csharp
// COMPILE-TIME POLYMORPHISM (Method Overloading)
public class Calculator
{
    public int Add(int a, int b) => a + b;                    // Version 1
    public double Add(double a, double b) => a + b;           // Version 2
    public string Add(string a, string b) => a + b;           // Version 3
    
    // Resolution at COMPILE TIME based on parameter types
}

// RUNTIME POLYMORPHISM (Method Overriding)
public class Animal
{
    public virtual void MakeSound() => Console.WriteLine("Animal sound");
}

public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine("Woof!");
}

public class Cat : Animal  
{
    public override void MakeSound() => Console.WriteLine("Meow!");
}

// Usage:
Animal myAnimal = new Dog();
myAnimal.MakeSound();  // "Woof!" - resolved at RUNTIME based on object type

myAnimal = new Cat();
myAnimal.MakeSound();  // "Meow!" - resolved at RUNTIME
```

**Key Differences:**
| Aspect | Compile-time (Overloading) | Runtime (Overriding) |
|--------|---------------------------|---------------------|
| **Resolution** | Compile-time based on signature | Runtime based on object type |
| **Performance** | Faster (resolved early) | Slower (virtual table lookup) |
| **Flexibility** | Limited to compile-time types | Dynamic based on actual object |
| **Keywords** | None needed | `virtual`, `override` |

---

## ❓ **Probable Interview Questions & Answers**

### **Question 1: What's the difference between `virtual` and `abstract` methods?**

**Answer:**
```csharp
public class Example 
{
    public virtual void VirtualMethod() { }     // Has implementation, can be overridden
    public abstract void AbstractMethod();      // No implementation, MUST be overridden
}
```

**Reasoning:**
- **Virtual methods** provide a default implementation that can be optionally overridden
- **Abstract methods** define a contract that must be implemented by derived classes
- **Abstract methods** can only exist in abstract classes
- **Virtual methods** can be in any class

**Tricky Follow-up: Can an abstract method be virtual?**
```csharp
public abstract class Base 
{
    public abstract virtual void Method();  // COMPILER ERROR!
}
```
**No!** Abstract methods are implicitly virtual. Adding `virtual` is redundant and causes error.

---

### **Question 2: When would you use `new` keyword instead of `override`?**

**Answer:**
Use `new` when you want to hide a base class method without participating in polymorphism.

**Example:**
```csharp
public class Base 
{
    public void Method() => Console.WriteLine("Base");
}

public class Derived : Base 
{
    public new void Method() => Console.WriteLine("Derived");
}

Base obj = new Derived();
obj.Method();  // Output: "Base" (not polymorphic)
```

**Reasoning:**
- `override` changes behavior polymorphically
- `new` creates a separate method that doesn't affect base class calls
- Use `new` sparingly - it can lead to confusing behavior

**Tricky Follow-up: What happens with virtual methods and new?**
```csharp
public class Base 
{
    public virtual void Method() => Console.WriteLine("Base");
}

public class Derived : Base 
{
    public new void Method() => Console.WriteLine("Derived");
}

Base obj = new Derived();
obj.Method();  // "Base" - new keyword breaks polymorphism!
```

---

### **Question 3: Explain constructor execution order in inheritance**

**Answer:**
Constructors execute from the base class to the most derived class.

**Example:**
```csharp
public class A 
{
    public A() => Console.WriteLine("A constructor");
}

public class B : A 
{
    public B() => Console.WriteLine("B constructor");
}

public class C : B 
{
    public C() => Console.WriteLine("C constructor");
}

new C();  // Output: A → B → C
```

**Reasoning:**
- Base class must be fully constructed before derived class
- Ensures derived class can safely use base class members
- Constructor chaining with `base()` controls which base constructor runs

**Tricky Follow-up: What if base class doesn't have parameterless constructor?**
```csharp
public class Base 
{
    public Base(int x) { }
}

public class Derived : Base 
{
    public Derived() : base(42) { }  // MUST call base constructor explicitly
}
```

---

### **Question 4: Difference between method overriding and method hiding**

**Answer:**
```csharp
public class Base 
{
    public virtual void VirtualMethod() => Console.WriteLine("Base Virtual");
    public void NormalMethod() => Console.WriteLine("Base Normal");
}

public class Derived : Base 
{
    public override void VirtualMethod() => Console.WriteLine("Derived Override");
    public new void NormalMethod() => Console.WriteLine("Derived New");
}

Base obj = new Derived();
obj.VirtualMethod();  // "Derived Override" - polymorphism works
obj.NormalMethod();   // "Base Normal" - hiding, no polymorphism
```

**Reasoning:**
- **Overriding**: Runtime resolution based on object type
- **Hiding**: Compile-time resolution based on reference type
- **Override** participates in polymorphism, **new** does not

---

### **Question 5: Can you call a base class method from an overridden method?**

**Answer:**
Yes, using `base` keyword.

**Example:**
```csharp
public class Base 
{
    public virtual void Method() => Console.WriteLine("Base implementation");
}

public class Derived : Base 
{
    public override void Method() 
    {
        base.Method();  // Call base implementation
        Console.WriteLine("Derived additional logic");
    }
}
```

**Reasoning:**
- `base.Method()` calls the base class implementation
- Useful for extending rather than replacing functionality
- Can only call immediate base class, not higher ancestors

---

### **Question 6: What is the "fragile base class" problem?**

**Answer:**
When changes to a base class break derived classes unexpectedly.

**Example:**
```csharp
public class Base 
{
    public void Method() { /* original implementation */ }
}

public class Derived : Base 
{
    // Relies on Base.Method() behavior
}

// If Base.Method() changes, Derived might break unexpectedly
```

**Mitigation Strategies:**
- Make classes `sealed` unless designed for inheritance
- Document inheritance expectations clearly
- Use composition over inheritance when appropriate

---

### **Question 7: When should you seal a class or method?**

**Answer:**
Seal when:
1. Class is not designed for inheritance
2. Method implementation should not be changed
3. Performance optimization is needed
4. Security reasons (preventing malicious overrides)

**Example:**
```csharp
public sealed class SecurityToken  // Cannot be tampered with via inheritance
{
    public sealed override string ToString()  // Cannot change string representation
    {
        return "SecureToken";
    }
}
```

---

## 🎯 **Tricky Scenario Questions**

### **Scenario 1: The Diamond Problem (Multiple Inheritance)**
```csharp
// C# doesn't allow this:
public class A { public void Method() { } }
public class B : A { }
public class C : A { }
public class D : B, C { }  // COMPILER ERROR - multiple inheritance not allowed

// Solution: Use interfaces
public interface IA { void Method(); }
public interface IB { void Method(); }
public class D : IA, IB 
{
    void IA.Method() { }  // Explicit interface implementation
    void IB.Method() { }
}
```

### **Scenario 2: Constructor Exception Handling**
```csharp
public class Base 
{
    public Base() 
    {
        throw new Exception("Base constructor failed");
    }
}

public class Derived : Base 
{
    public Derived()  // This will ALSO fail
    {
        Console.WriteLine("This never executes");
    }
}

// Derived class constructor cannot handle base class constructor exceptions
```

### **Scenario 3: Private Inheritance Simulation**
```csharp
// C# doesn't have private inheritance, but you can simulate with composition:
public class Base 
{
    public void UsefulMethod() { }
}

public class Derived 
{
    private Base _base = new Base();
    public void UseBaseMethod() => _base.UsefulMethod();  // Controlled exposure
}
```

This comprehensive guide covers all aspects of inheritance and polymorphism with practical examples and interview-focused explanations!
