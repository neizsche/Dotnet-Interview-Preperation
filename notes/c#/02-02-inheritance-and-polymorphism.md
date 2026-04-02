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
| Aspect          | Compile-time (Overloading)      | Runtime (Overriding)           |
| --------------- | ------------------------------- | ------------------------------ |
| **Resolution**  | Compile-time based on signature | Runtime based on object type   |
| **Performance** | Faster (resolved early)         | Slower (virtual table lookup)  |
| **Flexibility** | Limited to compile-time types   | Dynamic based on actual object |
| **Keywords**    | None needed                     | `virtual`, `override`          |

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


Beyond method hiding and overriding, C# has several "trap" topics that frequently appear in senior-level interviews because they deal with how memory and the lifecycle of a class actually work.

Here are the most common "confining" practical scenarios:

---

### 1. The Constructor Execution Order (Virtual Method Trap)
**The Question:** What happens if you call a `virtual` method inside a constructor?

```csharp
public class Base {
    public Base() => OnCreate();
    public virtual void OnCreate() => Console.WriteLine("Base Created");
}

public class Derived : Base {
    private string _name = "Gemini";
    public override void OnCreate() => Console.WriteLine($"Derived Created: {_name}");
}

// Result: new Derived();
// Output: "Derived Created: " (Wait, where is "Gemini"?)
```

**The Internal Detail:** In C#, the **Base constructor runs before the Derived constructor**. However, because the method is `virtual`, the runtime still calls the `Derived` version. At that moment, the `Derived` fields (like `_name`) haven't been initialized yet.
**Interview Tip:** "Never call virtual methods in a constructor. It's a 'half-baked' object state."



---

### 2. `static` Constructors and Inheritance
**The Question:** Does a child class trigger the parent's `static` constructor?

```csharp
public class Parent {
    static Parent() => Console.WriteLine("Parent Static");
}
public class Child : Parent {
    static Child() => Console.WriteLine("Child Static");
}

// Result: new Child();
```

**The Internal Detail:** Static constructors are **not inherited**. They are called by the CLR only when the specific class is first accessed. When you create a `Child`, the `Child` static constructor runs first, then the `Parent` static constructor runs (because the `Child` needs its parent to exist).
**Interview Tip:** "Static constructors are thread-safe and guaranteed to run only once per AppDomain, but they don't follow the same 'Top-Down' rule as instance constructors."

---

### 3. Abstract vs. Interface (The "Diamond" Problem)
**The Question:** Can a class inherit from multiple sources that have the same method name?

* **Abstract Classes:** You can only inherit from **one**.
* **Interfaces:** You can implement **many**.

**The Confusing Part:** What if two interfaces have the same method?
```csharp
interface ILeft { void Move(); }
interface IRight { void Move(); }

public class Player : ILeft, IRight {
    // How do you differentiate them?
    void ILeft.Move() => Console.WriteLine("Left");
    void IRight.Move() => Console.WriteLine("Right");
}
```
**The Internal Detail:** This is called **Explicit Interface Implementation**. The methods are "hidden" and can only be seen if you cast the object to that specific interface. 
**Interview Tip:** "Explicit implementation is used to resolve name collisions and to hide 'internal-only' interface methods from the public class API."



---

### 4. `sealed` Methods
**The Question:** Can you stop someone from overriding your override?

```csharp
public class A { public virtual void Go() {} }
public class B : A { public sealed override void Go() {} }
public class C : B { /* public override void Go() results in ERROR */ }
```
**The Internal Detail:** `sealed` combined with `override` locks the vTable slot. It says: "I have provided the final version of this logic; no further children can touch it."
**Interview Tip:** "Use `sealed` for security or performance. It allows the JIT compiler to potentially inline the method because it knows no one else can change it."

---

### 5. Summary Cheat Sheet for these Topics

| Topic                      | The "Gotcha"                              | Mental Rule                                   |
| :------------------------- | :---------------------------------------- | :-------------------------------------------- |
| **Virtual in Constructor** | Accesses uninitialized fields.            | **Instance fields aren't ready yet.**         |
| **Static Constructors**    | Run in reverse order (Child then Parent). | **Static is about the Type, not the object.** |
| **Explicit Interface**     | Methods disappear from the class.         | **Cast to the Interface to see the method.**  |
| **Abstract vs Interface**  | Logic vs. Contract.                       | **Abstract = "is a", Interface = "can do".**  |



Which of these scenarios would you like to see a "Laboratory" code sample for next?


```csharp
using System;

public class Program
{
    /* INTERNAL CONCEPT: The vTable (Virtual Method Table)
       - Every class with 'virtual' methods has a vTable in memory.
       - 'override' replaces a slot in the PARENT'S vTable.
       - 'new' creates a BRAND NEW slot that the Parent doesn't know about.
    */

    // --- CASE 1 & 2: METHOD HIDING (Static Binding) ---
    // INTERNAL: There is NO vTable entry for 'Go'. 
    // The compiler links the call directly to the Method Address of the Variable Type.
    public class Base1 { public void Go() => Console.WriteLine("Base1"); }
    public class Child1 : Base1 { public new void Go() => Console.WriteLine("Child1"); }

    // --- CASE 3: METHOD OVERRIDING (Dynamic Binding) ---
    // INTERNAL: Both Base and Child share the SAME vTable slot for 'Go'.
    // Child3 'overwrites' that slot. At runtime, the CPU looks at the slot and sees Child3.
    public class Base3 { public virtual void Go() => Console.WriteLine("Base3"); }
    public class Child3 : Base3 { public override void Go() => Console.WriteLine("Child3"); }

    // --- CASE 4: THE RESET (Hiding the Virtual Slot) ---
    // INTERNAL: Child4 ignores the Base4 vTable slot and creates its own separate, 
    // non-virtual method. The original vTable slot still points to Base4 code.
    public class Base4 { public virtual void Go() => Console.WriteLine("Base4"); }
    public class Child4 : Base4 { public new void Go() => Console.WriteLine("Child4"); }

    // --- CASE 5: THE NEW CHAIN (vTable Forking) ---
    // INTERNAL: This is the "Split Personality." The object now has TWO vTable slots:
    // 1. The original 'Base5' slot (still points to Base5).
    // 2. A brand new 'Child5' virtual slot (overridden by GrandChild5).
    public class Base5 { public virtual void Go() => Console.WriteLine("Base5"); }
    public class Child5 : Base5 { public new virtual void Go() => Console.WriteLine("Child5"); }
    public class GrandChild5 : Child5 { public override void Go() => Console.WriteLine("GrandChild5"); }

    public static void Main()
    {
        Console.WriteLine("--- INTERVIEW LAB ---");

        // SCENARIO A: The "Lens" Test (Hiding)
        Base1 b1 = new Child1(); 
        b1.Go(); // Output: Base1
        // INTERNAL: Compiler says: "b1 is type Base1. Base1.Go is not virtual. 
        // Jump to the hardcoded memory address of Base1.Go()."

        // SCENARIO B: The "Object" Test (Overriding)
        Base3 b3 = new Child3();
        b3.Go(); // Output: Child3
        // INTERNAL: Compiler says: "b3.Go is virtual. Look at the object's vTable. 
        // The slot for 'Go' has been overridden by Child3. Jump there."

        // SCENARIO C: The "Forced Lens" (Casting)
        var a4 = new Child4(); 
        ((Base4)a4).Go(); // Output: Base4
        // INTERNAL: By casting, you tell the compiler to look at the Base4 vTable slot. 
        // Since Child4 used 'new', it never touched the Base4 slot. It's still 'Base4'.
		Base4 b4 = new Child4();
		b4.Go(); // Output: Base4
        // INTERNAL: By casting, you tell the compiler to look at the Base4 vTable slot. 
        // Since Child4 used 'new', it never touched the Base4 slot. It's still 'Base4'.
		Child4 c4 = new Child4();
		c4.Go(); // Output: Child4

        // SCENARIO D: The "Double Identity" (Chain Reset)
        Base5 b5 = new GrandChild5();
        b5.Go(); // Output: Base5
        // INTERNAL: GrandChild5 overrode Child5, but Child5 hid Base5. 
        // Thus, GrandChild5 is only connected to the 'Child5' slot, not the 'Base5' slot.
        
        Child5 mid5 = new GrandChild5();
        mid5.Go(); // Output: GrandChild5
    }
}
```


```csharp
using System;

public class Program
{
	
	
	//If you ever get stuck in an interview, remember this hierarchy of "Power":
	//Override Methods: The Object is the boss.
	//Everything Else (Fields, Hidden Methods, Extensions): The Variable Type (The Lens) is the boss.
	
	
    // --- 1. THE CONSTRUCTOR TRAP ---
    public class BaseCtor {
        public BaseCtor() => Test();
        public virtual void Test() => Console.WriteLine("Base Ctor Logic");
    }
    public class DerivedCtor : BaseCtor {
        private string _status = "Initialized";
        public override void Test() => Console.WriteLine($"Derived Status: {_status}");
    }

    // --- 2. FIELD HIDING (No vTable) ---
    public class ParentField { public string Info = "Parent"; }
    public class ChildField : ParentField { public new string Info = "Child"; }

    // --- 3. EXTENSION VS INSTANCE ---
    public class User { public void Action() => Console.WriteLine("Instance Method"); }

    // --- 4. COVARIANT RETURNS ---
    public class Animal { }
    public class Dog : Animal { }
    public abstract class Shelter { public abstract Animal GetAnimal(); }
    public class DogShelter : Shelter { 
        public override Dog GetAnimal() => new Dog(); // Returns Dog instead of Animal
    }

    public static void Main()
    {
        Console.WriteLine("--- 1. Constructor Trap ---");
        // Problem: Base ctor calls virtual method before Derived fields are set.
        var trap = new DerivedCtor(); 
        // Output: Derived Status: (Empty/Null)

        Console.WriteLine("\n--- 2. Field Hiding ---");
        // Problem: Fields are bound to the Variable Type (Lens), never the object.
        ParentField p = new ChildField();
        Console.WriteLine(p.Info); 
        // Output: Parent

        Console.WriteLine("\n--- 3. Extension Precedence ---");
        // Problem: If an instance method exists, the extension method is ignored.
        var u = new User();
        u.Action(); 
        // Output: Instance Method

        Console.WriteLine("\n--- 4. Covariant Returns ---");
        // Benefit: We get a Dog object directly without needing to cast from Animal.
        DogShelter shelter = new DogShelter();
        Dog myDog = shelter.GetAnimal(); 
        Console.WriteLine($"Got a: {myDog.GetType().Name}");
        // Output: Got a: Dog
    }
}

// Extension method for Section 3
public static class Extensions {
    public static void Action(this Program.User u) => Console.WriteLine("Extension Method");
}
```
```csharp
using System;

public class Program
{
    public class Base
    {
        // 4. Base Static Field
        public static int BaseStaticField = Tracker.Log("4. Base: Static Field Initialized");

        // 5. Base Static Constructor
        static Base() => Console.WriteLine("5. Base: Static Constructor Executed");

        // 7. Base Instance Field
        public int BaseInstanceField = Tracker.Log("7. Base: Instance Field Initialized");

        // 8. Base Instance Constructor
        public Base() => Console.WriteLine("8. Base: Instance Constructor Executed");
    }

    public class Derived : Base
    {
        // 1. Derived Static Field (Triggers first because this is the type we called)
        public static int DerivedStaticField = Tracker.Log("1. Derived: Static Field Initialized");

        // 2. Derived Static Constructor
        static Derived() => Console.WriteLine("2. Derived: Static Constructor Executed");

        // 3. Derived Instance Field (Initializes before the Base logic starts)
        public int DerivedInstanceField = Tracker.Log("3. Derived: Instance Field Initialized");

        // 6. (Hidden Step) The Runtime now ensures Base is initialized before continuing

        // 9. Derived Instance Constructor
        public Derived() => Console.WriteLine("9. Derived: Instance Constructor Executed");
    }

    public static void Main()
    {
        Console.WriteLine("--- Starting Main ---");
        new Derived();
        Console.WriteLine("--- End Main ---");

		//--- Starting Main ---
		//1. Derived: Static Field Initialized
		//2. Derived: Static Constructor Executed
		//3. Derived: Instance Field Initialized
		//4. Base: Static Field Initialized
		//5. Base: Static Constructor Executed
		//7. Base: Instance Field Initialized
		//8. Base: Instance Constructor Executed
		//9. Derived: Instance Constructor Executed
		//--- End Main ---
    }
}

public static class Tracker
{
    public static int Log(string message)
    {
        Console.WriteLine(message);
        return 0;
    }
}
```
```csharp

```
```csharp

```
```csharp

```

