## C#

<details>
  <summary>Explain IDisposable Pattern.</summary>
  <br>
  The `IDisposable` pattern is a widely used pattern in C# for managing the cleanup and release of unmanaged resources in a deterministic manner. Unmanaged resources include objects such as file handles, database connections, network sockets, and other external resources that are not automatically managed by the .NET garbage collector. The `IDisposable` pattern allows developers to explicitly release these resources when they are no longer needed.

The pattern is implemented through the `IDisposable` interface, which declares a single method named `Dispose`. The `Dispose` method is responsible for releasing both managed and unmanaged resources. The pattern often involves implementing a finalizer (destructor) in case the `Dispose` method is not called explicitly.

Here's a typical implementation of the `IDisposable` pattern:

```csharp
public class ResourceHolder : IDisposable
{
    // Managed resources
    private bool disposed = false;

    // Unmanaged resources
    private IntPtr unmanagedResource;

    // Constructor
    public ResourceHolder()
    {
        // Acquire unmanaged resources
        unmanagedResource = AcquireUnmanagedResource();
    }

    // Dispose method
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Destructor (finalizer)
    ~ResourceHolder()
    {
        Dispose(false);
    }

    // Protected Dispose method to be used by both Dispose and the finalizer
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose of managed resources
            }

            // Dispose of unmanaged resources
            ReleaseUnmanagedResource(unmanagedResource);

            disposed = true;
        }
    }

    // Method to acquire unmanaged resources
    private IntPtr AcquireUnmanagedResource()
    {
        // Logic to acquire unmanaged resources
        return IntPtr.Zero;
    }

    // Method to release unmanaged resources
    private void ReleaseUnmanagedResource(IntPtr resource)
    {
        // Logic to release unmanaged resources
    }
}
```

In this example:

- The `ResourceHolder` class implements the `IDisposable` interface.
- The constructor (`ResourceHolder`) acquires unmanaged resources.
- The `Dispose` method is responsible for releasing both managed and unmanaged resources.
- The finalizer (destructor) is used to ensure that resources are released even if the `Dispose` method is not explicitly called. The finalizer calls `Dispose` with `disposing` set to `false` to release unmanaged resources only.

Usage of the `ResourceHolder` class:

```csharp
using (ResourceHolder resourceHolder = new ResourceHolder())
{
    // Use the resourceHolder object
} // Dispose method is automatically called when the object goes out of scope
```

By implementing the `IDisposable` pattern, developers can ensure proper cleanup of resources, leading to more predictable and efficient resource management in their applications. It is important for developers to use `using` statements or call the `Dispose` method explicitly to release resources in a timely manner.
  <br>
</details>

<details>
  <summary>Explain the concept of method overloading and provide an example.</summary>
  <br>
**Method overloading** is a feature in object-oriented programming (OOP) that allows a class to have multiple methods with the same name but different parameter lists. In other words, methods with the same name but different parameter types or numbers of parameters can coexist in the same class. This enables developers to provide multiple ways of calling a method based on the type or number of arguments passed.

### Example of Method Overloading in C#:

```csharp
public class Calculator
{
    // Method with two integer parameters
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Overloaded method with three integer parameters
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // Overloaded method with two double parameters
    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();

        // Using different overloaded methods
        int sumIntegers = calculator.Add(5, 10);
        int sumThreeIntegers = calculator.Add(2, 3, 5);
        double sumDoubles = calculator.Add(2.5, 3.7);

        Console.WriteLine($"Sum of integers: {sumIntegers}");
        Console.WriteLine($"Sum of three integers: {sumThreeIntegers}");
        Console.WriteLine($"Sum of doubles: {sumDoubles}");
    }
}
```

In this example:

- The `Calculator` class has three overloaded `Add` methods.
- The first `Add` method takes two integers, the second takes three integers, and the third takes two doubles.
- The methods have the same name (`Add`) but different parameter lists.
- Depending on the arguments provided when calling the `Add` method, the appropriate overloaded method is selected.

Output:
```
Sum of integers: 15
Sum of three integers: 10
Sum of doubles: 6.2
```

Method overloading provides the following benefits:

1. **Readability and Flexibility:**
   - It enhances code readability by allowing developers to use a common method name for related operations.
   - It provides flexibility in calling methods with different types or numbers of parameters, making the code more user-friendly.

2. **Avoiding Redundant Names:**
   - Instead of creating distinct method names for variations in parameters, overloading allows using a single name for related functionalities.

3. **Default Parameter Values:**
   - With method overloading, you can provide default values for some parameters, allowing users to omit certain arguments when calling the method.

Keep in mind that the compiler determines which overloaded method to invoke based on the number and types of arguments passed during the method call.
  <br>
</details>

<details>
  <summary>What is the 'this' keyword used for in C#?</summary>
  <br>
In C#, the `this` keyword is used to refer to the current instance of the class or structure. It is a reference to the current object on which a method or property is being invoked. The `this` keyword is particularly useful in scenarios where there might be ambiguity between instance variables and parameters with the same name.

Here are common uses of the `this` keyword in C#:

### 1. Differentiating between Instance Variables and Parameters:

```csharp
public class MyClass
{
    private int myField;

    // Constructor with parameter having the same name as the instance variable
    public MyClass(int myField)
    {
        // Use 'this' to refer to the instance variable
        this.myField = myField;
    }

    public void DisplayValue()
    {
        // Use 'this' to refer to the instance variable
        Console.WriteLine($"Value of myField: {this.myField}");
    }
}
```

### 2. Invoking Other Constructors (Constructor Chaining):

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor chaining using 'this'
    public Person(string name) : this(name, 0)
    {
        // Additional initialization logic if needed
    }

    // Main constructor
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
```

### 3. Returning the Current Instance (Fluent Interface):

```csharp
public class Calculator
{
    private int result;

    public Calculator Add(int value)
    {
        this.result += value;
        return this; // Return the current instance for method chaining
    }

    public Calculator Subtract(int value)
    {
        this.result -= value;
        return this; // Return the current instance for method chaining
    }

    public int GetResult()
    {
        return this.result;
    }
}
```

### 4. Using 'this' in Extension Methods:

```csharp
public static class StringExtensions
{
    public static string CustomMethod(this string input)
    {
        // 'this' is used to extend the String class
        return "Custom method result: " + input;
    }
}
```

In the examples above, the `this` keyword helps disambiguate between instance variables and parameters, enables constructor chaining, facilitates the creation of fluent interfaces, and is used in extension methods to extend existing classes.

Keep in mind that while the use of `this` can improve code clarity in certain situations, it is not always required, and its usage is a matter of preference and style.
  <br>
</details>

<details>
  <summary>Differentiate between value types and reference types in C#.</summary>
  <br>

### Differences Between Value Types and Reference Types

| Factors             | Value Types                                   | Reference Types                               |
|---------------------|-----------------------------------------------|-----------------------------------------------|
| Storage             | Stored directly in memory locations            | Stored as a reference to a memory location     |
| Memory Allocation   | Allocated on stack or inline within objects    | Allocated on the managed heap                 |
| Size                | Generally smaller in size                       | Larger in size, due to overhead               |
| Copy Behavior       | Copy contains the actual value (deep copy)     | Copy contains a reference (shallow copy)      |
| Performance         | Faster access due to stack allocation          | Slightly slower due to indirection and heap   |
| Nullability         | Cannot be null                                 | Can be null (reference can point to null)     |
| Examples            | int, float, bool, enum, struct                 | class, interface, delegate, object            |
| Default Value       | Has default values (e.g., 0 for int)           | Null is the default value for reference types |

  <br>
</details>

<details>
  <summary>How does C# handle garbage collection, and why is it important?</summary>
  <br>
**Garbage collection** in C# is an automatic memory management process that involves identifying and reclaiming memory that is no longer in use by the program. Instead of requiring developers to explicitly allocate and deallocate memory, C# relies on the .NET Common Language Runtime (CLR) to perform garbage collection. Here's how garbage collection works in C#:

### Garbage Collection Process:

1. **Memory Allocation:**
   - When objects are created in C#, memory is allocated for them on the managed heap.

2. **Reference Tracking:**
   - The CLR keeps track of references to objects during program execution. A reference is a pointer or handle to an object.

3. **Detecting Unreachable Objects:**
   - Periodically, the garbage collector identifies objects that are no longer reachable or referenced by the program. These are considered garbage.

4. **Mark and Sweep:**
   - The garbage collector performs a process known as "mark and sweep":
     - It marks reachable objects by traversing the object graph starting from known roots (such as global and local variables, static fields, and CPU registers).
     - It sweeps through the heap, reclaiming memory occupied by objects that were not marked as reachable.

5. **Memory Reclamation:**
   - The memory occupied by the unreachable objects is freed, making it available for future allocations.

### Why Garbage Collection is Important:

1. **Automatic Memory Management:**
   - Garbage collection eliminates the need for explicit memory management (e.g., manual allocation and deallocation), reducing the likelihood of memory leaks and memory-related bugs.

2. **Prevention of Dangling Pointers:**
   - Dangling pointers, which point to memory that has been deallocated, can lead to unpredictable behavior. Garbage collection helps prevent issues related to dangling pointers.

3. **Enhanced Productivity:**
   - Developers can focus more on application logic and features rather than manual memory management. This leads to increased productivity and shorter development cycles.

4. **Avoidance of Memory Leaks:**
   - Memory leaks, caused by unreleased memory, can gradually degrade an application's performance. Garbage collection helps prevent memory leaks by automatically reclaiming unused memory.

5. **Dynamic Memory Allocation:**
   - Garbage collection allows for efficient and dynamic memory allocation. Objects can be created and used without concerns about explicitly freeing up memory when they are no longer needed.

6. **Scalability:**
   - Automatic garbage collection is especially beneficial for large-scale applications and systems where manual memory management would be error-prone and impractical.

### Tuning and Optimization:

While garbage collection is automatic, developers can influence and optimize its behavior in certain scenarios. Techniques include:

- **Finalizers and IDisposable:** Developers can implement finalizers (destructors) or implement the `IDisposable` interface for more deterministic resource cleanup. However, relying solely on finalizers can lead to less predictable results due to the non-deterministic nature of finalization.

- **Generations:** The .NET garbage collector uses a generational approach, dividing objects into three generations (young, middle-aged, and old) based on their lifetime. Most objects die quickly, and frequent collections occur in the younger generation. This generational approach enhances garbage collection efficiency.

- **GC.Collect Method:** Developers can manually trigger garbage collection using the `GC.Collect` method. However, this is generally discouraged, and the garbage collector is designed to operate automatically.

Garbage collection is a critical aspect of the .NET runtime, contributing to the reliability, security, and performance of C# applications. It allows developers to build robust and scalable software without the burden of explicit memory management.
  <br>
</details>

<details>
  <summary>What is the purpose of the 'sealed' keyword in C#?</summary>
  <br>
- **Purpose of the `sealed` Keyword in C#:**
    - The `sealed` keyword is used to restrict the inheritance of a class or the overriding of a method by indicating that it cannot be further derived or overridden.
    - It serves as a way to prevent further modification or extension of a class or the overriding of specific methods.

- **Usage Examples:**
    - Sealing a Class:
        ```csharp
        public sealed class SealedClass
        {
            // Class members and methods
        }
        ```
    - Sealing a Method:
        ```csharp
        public class BaseClass
        {
            public sealed override void SomeMethod()
            {
                // Method implementation
            }
        }
        ```

- **Benefits of `sealed`:**
    - **Preventing Further Inheritance:**
        - Ensures that a class cannot serve as a base class for any other class.
    - **Method Stability:**
        - Guarantees that a sealed method cannot be further overridden in derived classes, providing stability in the behavior of the method.
    - **Security and Design Intent:**
        - Clearly communicates the design intent to prevent modification, extension, or overriding, contributing to code security and maintainability.

- **Considerations:**
    - Sealing a class or method should be done thoughtfully, considering the future use and potential extension points of the code.
    - Overuse of sealing may limit the extensibility of the code, so it should be applied judiciously.

- **Notes:**
    - The `sealed` keyword can be applied to classes, methods, properties, and indexers.
    - Attempting to inherit from a sealed class or override a sealed method results in a compilation error.

- **Example Scenario:**
    - Sealing a method in a base class to ensure that it cannot be overridden by derived classes, providing a stable behavior that should not be modified in subclasses.

```csharp
public class BaseClass
{
    public sealed override void SomeMethod()
    {
        // Method implementation
    }
}

public class DerivedClass : BaseClass
{
    // Attempting to override 'SomeMethod' here would result in a compilation error.
}
```

In summary, the `sealed` keyword in C# is used to restrict further inheritance or method overriding, providing a way to communicate design intent, enhance code security, and ensure stability in the behavior of classes and methods. It is applied to classes, methods, properties, or indexers to control the extensibility of code elements.
  <br>
</details>

<details>
  <summary>How does C# support multiple inheritance, or does it? Explain.</summary>
  <br>
In C#, interfaces play a crucial role in achieving a form of multiple inheritance. Multiple inheritance refers to the ability of a class to inherit from more than one class. While C# does not support multiple class inheritance, it allows a class to implement multiple interfaces, achieving a similar outcome. This enables a class to inherit behavior from multiple sources, promoting code reuse and flexibility.

### Role of Interfaces in Achieving Multiple Inheritance:

1. **Definition of a Contract:**
   - An interface in C# defines a contract, specifying a set of method signatures, properties, events, or indexers without providing any implementation.
   - Interfaces declare what a class that implements them must do, creating a common set of functionalities.

   ```csharp
   public interface IDrawable
   {
       void Draw();
   }

   public interface IMovable
   {
       void Move();
   }
   ```

2. **Implementation by Classes:**
   - Classes in C# can implement multiple interfaces by providing concrete implementations for the methods declared in those interfaces.
   - This allows a class to inherit behavior from multiple sources, achieving a form of multiple inheritance.

   ```csharp
   public class Circle : IDrawable, IMovable
   {
       public void Draw() { /* Implementation for drawing a circle */ }
       public void Move() { /* Implementation for moving a circle */ }
   }
   ```

3. **Usage in Class Hierarchy:**
   - A class can implement any number of interfaces, providing a flexible way to extend its behavior beyond the constraints of single class inheritance.

   ```csharp
   public class Square : IDrawable, IMovable
   {
       public void Draw() { /* Implementation for drawing a square */ }
       public void Move() { /* Implementation for moving a square */ }
   }
   ```

4. **Interface Hierarchies:**
   - Interfaces themselves can inherit from other interfaces, creating an interface hierarchy.
   - This enables the definition of common functionalities in base interfaces, which are then inherited by derived interfaces.

   ```csharp
   public interface IShape
   {
       void Draw();
   }

   public interface IMovableShape : IShape
   {
       void Move();
   }
   ```

5. **Polymorphism and Flexibility:**
   - By implementing multiple interfaces, a class can be used polymorphically through any of its interface types.
   - This enhances flexibility and adaptability, allowing a class to conform to various contracts and supporting different types of behavior.

   ```csharp
   IDrawable drawableCircle = new Circle();
   IMovable movableSquare = new Square();
   ```

In the examples above, the interfaces `IDrawable` and `IMovable` define specific behaviors, and classes like `Circle` and `Square` implement these interfaces. This allows instances of these classes to be used wherever the corresponding interface type is expected.

While C# doesn't support multiple class inheritance, the use of interfaces provides a mechanism for achieving a form of multiple inheritance, promoting code reuse, maintainability, and extensibility. It also aligns with the principles of object-oriented design, such as encapsulation and polymorphism.
  <br>
</details>

<details>
  <summary>What is boxing and unboxing?</summary>
  <br>
**Boxing and Unboxing in C#**

**Boxing:**
- **Definition:** Boxing is the process of converting a value type to the type object or any interface type implemented by this value type.
- **Syntax:** `object boxedValue = (object)intValue;`
- **Example:** `int intValue = 42; object boxedValue = intValue;`

**Unboxing:**
- **Definition:** Unboxing is the process of converting the boxed value type back to its original value type.
- **Syntax:** `int unboxedValue = (int)boxedValue;`
- **Example:** `int unboxedValue = (int)boxedValue;`

**Differences:**

| Factor                 | Boxing                                    | Unboxing                                  |
|------------------------|-------------------------------------------|-------------------------------------------|
| **Operation Type**     | Converts a value type to a reference type. | Converts a reference type back to a value type. |
| **Syntax**             | `object boxedValue = (object)intValue;`   | `int unboxedValue = (int)boxedValue;`      |
| **Example**            | `int intValue = 42; object boxedValue = intValue;` | `int unboxedValue = (int)boxedValue;`     |
| **Performance**        | Involves creating a new object on the heap, which may have a performance cost. | Generally faster than boxing, as it directly extracts the value. |
| **Use Cases**          | Commonly used when dealing with collections or scenarios requiring reference types. | Commonly used when retrieving values from collections or objects. |
| **Type Safety**        | Type safety is maintained during boxing.   | Type safety is ensured during unboxing.   |

  <br>
</details>

<details>
  <summary>When to use string and when to use StringBuilder?</summary>
  <br>

| Aspect                     | `string`                                    | `StringBuilder`                                            |
|----------------------------|----------------------------------------------|-------------------------------------------------------------|
| Mutability                 | Immutable (Cannot be modified after creation)| Mutable (Supports modification without creating new objects) |
| Performance                | Concatenation creates new string instances   | Efficient for frequent string modifications                 |
| Memory Allocation          | Creates new strings on every modification    | Modifies existing buffer, reducing memory overhead           |
| Usage                      | Ideal for static or infrequently changing text| Suitable for dynamic or frequently changing text             |
| Efficiency in Concatenation| Inefficient for frequent concatenation       | Efficient due to in-place modification of the buffer        |
| Concurrency                | Thread-safe due to immutability              | Not inherently thread-safe                                   |
| Syntax Clarity             | Straightforward and simple syntax            | More complex syntax for manipulation and appending           |
| Recommended Use Cases      | Static or less frequently changing content   | Frequent string manipulation, concatenation, or editing      |

  <br>
</details>

<details>
  <summary>What is the 'readonly' keyword used for in C#?</summary>
  <br>
In C#, the `readonly` keyword is used to declare a member (usually a field) that can only be assigned a value during its declaration or within the constructor of the containing class. Once a `readonly` member is assigned a value, it cannot be modified. The primary significance of the `readonly` keyword lies in creating immutable fields and promoting better code safety, especially for constants or values that should not be changed after initialization.

Here are the key aspects of the significance of the `readonly` keyword:

1. **Immutable Fields:**
   - `readonly` fields are immutable, meaning that their values cannot be changed once they are set. This is particularly useful for constants or values that should remain constant throughout the lifetime of an object.

   ```csharp
   public class Example
   {
       public readonly int ConstantValue;

       public Example(int value)
       {
           ConstantValue = value; // Can only be assigned in the constructor
       }
   }
   ```

2. **Initialization at Declaration or in Constructor:**
   - A `readonly` field can be assigned a value either at the time of declaration or within the constructor of the containing class. Once assigned, the value cannot be modified.

   ```csharp
   public class Example
   {
       public readonly int ConstantValue = 42; // Initialized at declaration

       public Example(int value)
       {
           ConstantValue = value; // Assigned in the constructor
       }
   }
   ```

3. **Compile-Time Constants:**
   - `readonly` fields are evaluated at compile time, and their values become constants for the lifetime of the object or class. This is in contrast to regular fields, which are evaluated at runtime.

   ```csharp
   public class Constants
   {
       public const int CompileTimeConstant = 100;
       public readonly int RuntimeConstant;

       public Constants(int value)
       {
           RuntimeConstant = value; // Assigned at runtime, but cannot be changed afterward
       }
   }
   ```

4. **Thread Safety:**
   - `readonly` fields contribute to thread safety in scenarios where multiple threads may be accessing an object. Since the value of a `readonly` field cannot be changed after initialization, it reduces the chances of data inconsistencies in a multi-threaded environment.

   ```csharp
   public class ThreadSafeExample
   {
       public readonly int ThreadSafeValue;

       public ThreadSafeExample(int value)
       {
           ThreadSafeValue = value;
       }
   }
   ```

5. **Better Code Clarity:**
   - The use of `readonly` provides clarity in the code, indicating to developers that the value of the field should not be modified after initialization. This can make the code more maintainable and help prevent accidental modifications.

   ```csharp
   public class Constants
   {
       public readonly int MaxValue = 100;
       // ...
   }
   ```

In summary, the `readonly` keyword is significant in C# for creating immutable fields, constants, and values that should remain constant after initialization. It contributes to code safety, thread safety, and better code clarity by explicitly stating the intention that the value of the field should not be modified.
  <br>
</details>

<details>
  <summary>Difference between readonly and const in C# in tabular form.</summary>
  <br>

| Factor                    | `readonly`                            | `const`                                |
|---------------------------|---------------------------------------|----------------------------------------|
| **Type of Value**          | Allows non-primitive types (e.g., class instances, arrays). | Limited to compile-time constants (primitive types, enums, strings). |
| **Initialization**         | Can be initialized at runtime within the constructor.   | Must be initialized at the time of declaration. |
| **Modification**           | Can have different values for each instance and can be modified after object creation. | Has a fixed, unchangeable value for all instances and is implicitly `static`. |
| **Scope**                  | Instance-level. Each instance of the class can have a different value. | Class-level. Same value is shared across all instances and is part of the type itself. |
| **Use with Methods**       | Can be used with methods to perform complex initialization logic. | Cannot be used with methods; intended for simple, constant values. |
| **Compile-Time Constant**  | Evaluated at runtime, and its value can be set in the constructor. | Evaluated at compile time, and its value must be known at compile time. |

**When to Use:**

- **Use `readonly` When:**
  - You need a value that can be determined or initialized at runtime.
  - You want each instance of the class to potentially have a different value.
  - You want the flexibility to initialize the value in the constructor.

- **Use `const` When:**
  - You have a value that is known at compile time and will not change.
  - You want a constant value that is shared across all instances of the class.
  - You want to enforce a compile-time constant, especially for primitive types or simple values.

  <br>
</details>

<details>
  <summary>What is the significance of the 'ref' and 'out' keywords in C#?</summary>
  <br>
Sure, here's the information about the `ref` and `out` keywords in Markdown format:

### **Significance of `ref` and `out` Keywords in C#**

- Both `ref` and `out` are keywords used to pass arguments to methods by reference instead of by value.
  
- **`ref` Keyword:**

    - Used to pass a reference of a variable to a method, allowing the method to modify the variable's value.
    
    - Requires the variable to be initialized before passing it to the method.
    
    - Changes made to the parameter inside the method affect the original variable outside the method.
    
    - Used for both input and output purposes.
    
    - Example:
      ```csharp
      void Increment(ref int number)
      {
          number++;
      }
      
      int value = 5;
      Increment(ref value);
      // 'value' will be 6 after the method call.
      ```

- **`out` Keyword:**

    - Used specifically for output parameters; doesn't require the variable to be initialized before passing it to the method.
    
    - The method is responsible for initializing the output parameter before returning.
    
    - Changes made to the parameter inside the method are reflected in the original variable outside the method.
    
    - Used for output purposes only.
    
    - Example:
      ```csharp
      void GetValues(out int x, out int y)
      {
          x = 10;
          y = 20;
      }
      
      int a, b;
      GetValues(out a, out b);
      // 'a' will be 10 and 'b' will be 20 after the method call.
      ```

- **Differences between `ref` and `out`:**

|                       | `ref`                               | `out`                              |
|-----------------------|-------------------------------------|------------------------------------|
| **Initialization**    | Variable must be initialized before passing. | No need to initialize before passing; method initializes within. |
| **Inside the Method** | Can use the value of the variable passed. | Must initialize the variable within the method before using it. |
| **Usage**             | Used for both input and output purposes. | Used specifically for output parameters. |

Using these keywords allows methods to interact with variables directly, enabling modifications to the original values and facilitating more flexible parameter passing in C#.
  <br>
</details>

<details>
  <summary>Discuss the concept of an abstract class and when to use it.</summary>
  <br>An **abstract class** in C# is a class that cannot be instantiated on its own and is meant to be subclassed by other classes. Abstract classes serve as a blueprint for other classes, providing a common base for related classes while allowing for certain methods to be left abstract (i.e., without implementation). Abstract classes can have both abstract and non-abstract (concrete) members, making them versatile in defining a common structure for derived classes.

### Key Characteristics of Abstract Classes:

1. **Cannot Be Instantiated:**
   - An abstract class cannot be instantiated directly. It exists solely for providing a common base for derived classes.

2. **May Contain Abstract Methods:**
   - Abstract classes can declare abstract methods, which are methods without a body. Subclasses must provide concrete implementations for these abstract methods.

3. **Can Contain Concrete Members:**
   - Abstract classes can also contain non-abstract (concrete) methods, properties, fields, and other members. These members may have an implementation.

4. **Supports Constructors:**
   - Abstract classes can have constructors, and they can be used to initialize common fields or perform other initialization tasks.

### Example of an Abstract Class:

```csharp
public abstract class Shape
{
    // Abstract method - to be implemented by derived classes
    public abstract double CalculateArea();

    // Concrete method
    public void Display()
    {
        Console.WriteLine("This is a shape.");
    }
}
```

### When to Use Abstract Classes:

1. **Common Base Class:**
   - Use an abstract class when you want to provide a common base for multiple related classes. Abstract classes are suitable for situations where a group of classes share common characteristics and behaviors.

2. **Enforce a Contract:**
   - Abstract classes can declare abstract methods, enforcing a contract that derived classes must implement. This helps ensure that certain behaviors are defined consistently across all subclasses.

3. **Partial Implementation:**
   - When you want to provide a partial implementation of a class, where some methods have a common implementation in the base class, and others are left abstract for customization in derived classes.

4. **Code Reusability:**
   - Abstract classes support code reusability by allowing derived classes to inherit common functionality. This helps avoid duplicating code across multiple classes.

5. **Polymorphism:**
   - Abstract classes contribute to polymorphism. Instances of derived classes can be treated as instances of the abstract base class, providing a level of abstraction and flexibility in designing class hierarchies.

### Example Use Case:

```csharp
public class Circle : Shape
{
    private double radius;

    // Constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }

    // Implementation of abstract method
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}
```

In this example, the `Shape` abstract class serves as a common base for various shapes. The `Circle` class inherits from `Shape` and provides a concrete implementation for the abstract method `CalculateArea`.

In summary, use abstract classes when you want to define a common base with both abstract and concrete members for derived classes. They are particularly useful for organizing and structuring related classes in an inheritance hierarchy.
  <br>
</details>

<details>
  <summary>What are delegates in C# and how are they different from events?</summary>
  <br>
In C#, a **delegate** is a type that represents references to methods with a particular signature. Delegates are used to create and manipulate references to methods, allowing for a level of indirection when calling methods. Delegates are particularly useful in scenarios where you want to pass methods as arguments or have callbacks in your code.

On the other hand, an **event** is a special type of delegate that is often used to implement the observer design pattern. Events provide a way for one class (the publisher) to notify other classes (subscribers or listeners) when something of interest happens. Events are built on top of delegates and provide an encapsulated way to handle callbacks without exposing the delegate directly.

Here are key points differentiating delegates from events in C#:

### Delegates:

1. **Declaration:**
   - Delegates are declared using the `delegate` keyword, specifying the method signature that the delegate can reference.

    ```csharp
    public delegate void MyDelegate(int x, int y);
    ```

2. **Instantiation:**
   - Delegates are instantiated by creating an instance of the delegate type and assigning a reference to a method that matches the delegate's signature.

    ```csharp
    MyDelegate delegateInstance = SomeMethod;
    ```

3. **Invocation:**
   - Delegates can be invoked using the `Invoke` method or, more commonly, using the delegate instance as if it were a method call.

    ```csharp
    delegateInstance(10, 20); // Invoking the delegate
    ```

4. **Multicast Delegates:**
   - Delegates support multicast, meaning that a single delegate instance can reference multiple methods, and all of them will be invoked when the delegate is called.

    ```csharp
    MyDelegate multiDelegate = SomeMethod1;
    multiDelegate += SomeMethod2;
    multiDelegate(10, 20); // Both SomeMethod1 and SomeMethod2 are invoked
    ```

### Events:

1. **Declaration:**
   - Events are declared using the `event` keyword along with a delegate type. The delegate type defines the signature of the methods that can be subscribed to the event.

    ```csharp
    public event MyDelegate MyEvent;
    ```

2. **Subscription and Unsubscription:**
   - Events are designed to be subscribed to and unsubscribed from using the `+=` and `-=` operators. This is to ensure that only authorized classes can subscribe or unsubscribe from the event.

    ```csharp
    instance.MyEvent += SomeEventHandler;
    instance.MyEvent -= SomeEventHandler;
    ```

3. **Invocation:**
   - Events can only be invoked from within the class that declares the event. This is to ensure that the class maintains control over when the event is raised.

    ```csharp
    MyEvent?.Invoke(10, 20); // Null-conditional operator used to avoid null reference exception
    ```

4. **Encapsulation:**
   - Events encapsulate the delegate, preventing external classes from directly modifying the delegate or invoking it from outside the declaring class.

### Example:

Here is a simple example demonstrating the use of a delegate and an event:

```csharp
public delegate void MyDelegate(int x, int y);

public class MyClass
{
    public event MyDelegate MyEvent;

    public void InvokeEvent(int x, int y)
    {
        MyEvent?.Invoke(x, y);
    }
}

public class Program
{
    static void Main()
    {
        MyClass instance = new MyClass();
        instance.MyEvent += SomeEventHandler;

        // Using the delegate directly
        MyDelegate delegateInstance = SomeEventHandler;
        delegateInstance(10, 20);

        // Using the event
        instance.InvokeEvent(30, 40);
    }

    static void SomeEventHandler(int x, int y)
    {
        Console.WriteLine($"Event handled: {x}, {y}");
    }
}
```

In this example, `MyDelegate` is a delegate type, and `MyClass` declares an event named `MyEvent` of type `MyDelegate`. The `SomeEventHandler` method is then subscribed to both the delegate and the event, demonstrating the use of both constructs. The key difference lies in the encapsulation and access control provided by events, making them suitable for implementing observer patterns and decoupling components in a more controlled manner.
  <br>
</details>

<details>
  <summary>What is the purpose of the 'yield' keyword in C#?</summary>
  <br>
The `yield` keyword in C# is used in the context of iterator methods to simplify the process of creating and working with sequences of data. It allows developers to create iterators without having to implement the complete logic for generating all elements in advance. Instead, elements are generated on-the-fly as the iterator is iterated.

### Purpose of `yield`:

1. **Lazy Evaluation:**
   - The primary purpose of `yield` is to enable lazy evaluation. Instead of generating an entire sequence of elements upfront and storing them in memory, `yield` allows the elements to be generated one at a time, on-demand, as the iterator is iterated.

2. **Simplified Iterator Implementation:**
   - `yield` simplifies the implementation of iterators by allowing the developer to write code that looks like a regular loop but is processed incrementally. This makes it easier to read and maintain code for iterating over large datasets or generating sequences with complex logic.

3. **Efficient Memory Usage:**
   - By using `yield`, memory consumption is reduced because elements are generated only when needed. This is particularly useful when dealing with large datasets or when generating infinite sequences.

4. **State Preservation:**
   - The `yield` keyword maintains the state of the iterator between calls. When the iterator is paused, it retains its state, allowing it to resume execution where it left off. This is crucial for iterators that involve complex logic or external resources.

5. **Support for Asynchronous Programming:**
   - In addition to its use in synchronous iterator methods, `yield` can be used in asynchronous iterator methods (introduced in C# 8.0) to simplify the asynchronous generation of sequences.

### Basic Usage:

The `yield` keyword is used within an iterator method, which is a method that returns an `IEnumerable<T>` or `IEnumerator<T>`. The method contains one or more `yield` statements that produce elements in the sequence.

```csharp
public IEnumerable<int> GenerateSequence()
{
    yield return 1;
    yield return 2;
    yield return 3;
    // ...
}
```

### Example: Generating Fibonacci Sequence:

```csharp
public IEnumerable<int> GenerateFibonacci(int count)
{
    int a = 0, b = 1;

    for (int i = 0; i < count; i++)
    {
        yield return a;
        int temp = a;
        a = b;
        b = temp + b;
    }
}
```

In this example, the `GenerateFibonacci` method uses `yield` to generate the Fibonacci sequence lazily, only producing the elements as they are requested.

### Use in Asynchronous Programming (C# 8.0 and later):

```csharp
public async IAsyncEnumerable<int> GenerateAsyncSequence()
{
    for (int i = 0; i < 5; i++)
    {
        await Task.Delay(100); // Simulate asynchronous operation
        yield return i;
    }
}
```

In asynchronous iterator methods, `yield return` can be used to asynchronously generate elements, making it easier to work with asynchronous sequences.

In summary, the `yield` keyword in C# is a powerful tool for simplifying the creation of iterators, enabling lazy evaluation, and improving memory efficiency. It is particularly valuable when dealing with large datasets, complex logic, or when implementing generators for sequences.
  <br>
</details>

<details>
  <summary>What is the purpose of the 'async' and 'await' keywords in C#?</summary>
  <br>
The `async` and `await` keywords in C# are used to simplify asynchronous programming by providing a more natural and readable way to work with asynchronous operations. They were introduced in C# 5.0 to make it easier for developers to write code that involves asynchronous operations, such as I/O-bound or CPU-bound tasks, without blocking the execution thread.

### Purpose of `async` and `await`:

1. **Asynchronous Programming:**
   - The primary purpose of `async` and `await` is to enable asynchronous programming in C#. Asynchronous programming allows tasks to run concurrently without blocking the main thread, improving the responsiveness of applications, especially in scenarios involving I/O operations, network requests, or long-running computations.

2. **Non-Blocking Execution:**
   - By using `await`, the control flow is not blocked during the execution of asynchronous operations. This allows the application to remain responsive while waiting for the completion of tasks, avoiding the need for unnecessary thread blocking.

3. **Readability and Maintainability:**
   - `async` and `await` make asynchronous code more readable and maintainable. The code structure resembles synchronous code, making it easier for developers to reason about the flow of execution.

4. **Sequential-Looking Code:**
   - Asynchronous code using `await` appears to be sequential, even though it allows other tasks to execute during periods of waiting. This helps developers write code that looks similar to synchronous code, reducing the cognitive load associated with asynchronous programming.

5. **Exception Handling:**
   - `async` and `await` simplify exception handling in asynchronous code. Exceptions thrown in asynchronous methods are propagated correctly, making it easier to handle errors.

### Basic Usage:

1. **`async` Modifier:**
   - The `async` modifier is used to define asynchronous methods. An asynchronous method is a method that contains one or more `await` expressions.

    ```csharp
    public async Task MyAsyncMethod()
    {
        // Asynchronous operations using await
        await SomeAsyncOperation();
        // ...
    }
    ```

2. **`await` Operator:**
   - The `await` operator is used to asynchronously wait for the completion of a task. It can be applied to tasks returned by asynchronous methods, allowing the code to continue when the awaited task completes.

    ```csharp
    public async Task<int> AddAsync(int a, int b)
    {
        // Asynchronously wait for the result of the addition
        int result = await PerformAdditionAsync(a, b);
        return result;
    }
    ```

### Example: Asynchronous Web Request:

```csharp
public async Task<string> DownloadWebPageAsync(string url)
{
    using (HttpClient httpClient = new HttpClient())
    {
        // Asynchronously send an HTTP request and wait for the response
        HttpResponseMessage response = await httpClient.GetAsync(url);

        // Asynchronously read the content of the response
        string content = await response.Content.ReadAsStringAsync();

        return content;
    }
}
```

In this example, `DownloadWebPageAsync` is an asynchronous method that downloads the content of a web page asynchronously. The `await` keyword is used to wait for the completion of the asynchronous HTTP request and the asynchronous reading of the response content.

In summary, `async` and `await` keywords in C# simplify asynchronous programming, making it more readable and maintainable. They provide a convenient way to work with asynchronous operations, allowing developers to write code that appears sequential while leveraging the benefits of non-blocking execution.
  <br>
</details>

<details>
  <summary>Give basic formats of LINQ keywords.</summary>
  <br>
**Language Integrated Query (LINQ)** is a feature in C# that allows developers to express queries against collections, databases, XML, and other data sources in a language-integrated way. LINQ provides a unified syntax and programming model for querying and manipulating data, making it a powerful tool for working with diverse data sources.

### Key Concepts of LINQ:

1. **Unified Query Syntax:**
   - LINQ provides a consistent and unified query syntax regardless of the data source. This allows developers to use a common set of query operators to retrieve, transform, and filter data.

2. **Strongly Typed Queries:**
   - LINQ enables strongly typed queries, which means that the compiler checks the correctness of queries at compile time. This helps catch errors early in the development process.

3. **Integration with C# Language:**
   - LINQ is integrated into the C# language, allowing developers to write queries directly within C# code. This integration improves code readability and maintainability.

4. **Extensibility:**
   - LINQ is extensible, allowing developers to create custom query operators and providers for different data sources.

5. **Support for Various Data Sources:**
   - LINQ can be used to query a variety of data sources, including in-memory objects (IEnumerable<T>), databases (LINQ to SQL, LINQ to Entities), XML (LINQ to XML), and more.

### Example of LINQ with In-Memory Objects:

Consider a simple example where we have a list of integers, and we want to retrieve all even numbers greater than 5:

```csharp
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 2, 7, 4, 9, 6, 3, 8 };

        // LINQ query to retrieve even numbers greater than 5
        var result = from num in numbers
                     where num > 5 && num % 2 == 0
                     select num;

        // Display the result
        Console.WriteLine("Even numbers greater than 5:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }
}
```

In this example:

- `numbers` is a `List<int>` containing a collection of integers.
- The LINQ query uses the `from`, `where`, and `select` clauses to express the query.
- `where` filters the numbers based on the specified condition (greater than 5 and even).
- `select` projects the filtered numbers.

The output of the program will be:

```
Even numbers greater than 5:
6
8
```

This is a basic example, but LINQ queries can become more complex, involving joins, grouping, ordering, and other operations depending on the data source.

LINQ provides a powerful and expressive way to work with data, making it easier for developers to write queries and manipulate data in a consistent manner across different types of data sources.

LINQ (Language Integrated Query) in C# involves several keywords and clauses that form the syntax for constructing queries. Here are the basic formats of key LINQ keywords and clauses:

### Basic LINQ Query Syntax:

1. **`from` Clause:**
   - Used to specify the data source and the range variable (element variable).

    ```csharp
    from <range-variable> in <data-source>
    ```

    Example:
    ```csharp
    from student in students
    ```

2. **`where` Clause:**
   - Used to filter the data based on a specified condition.

    ```csharp
    where <condition>
    ```

    Example:
    ```csharp
    where student.Age > 18
    ```

3. **`select` Clause:**
   - Used to project or select data from the data source.

    ```csharp
    select <projection>
    ```

    Example:
    ```csharp
    select student.Name
    ```

### Full LINQ Query Syntax:

Putting it all together, a complete LINQ query might look like this:

```csharp
var query = from <range-variable> in <data-source>
            where <condition>
            select <projection>;
```

Example:

```csharp
var query = from student in students
            where student.Age > 18
            select student.Name;
```

### Extension Method Syntax (Method Chaining):

Alternatively, LINQ queries can be written using method chaining with extension methods. Here's the basic format:

```csharp
var query = <data-source>.<extension-methods>
```

Example:

```csharp
var query = students.Where(s => s.Age > 18).Select(s => s.Name);
```

### LINQ Join:

```csharp
var query = from <range-variable1> in <data-source1>
            join <range-variable2> in <data-source2> on <key1> equals <key2>
            select new { <projection> };
```

Example:

```csharp
var query = from student in students
            join course in courses on student.CourseId equals course.Id
            select new { student.Name, course.CourseName };
```

### LINQ Group By:

```csharp
var query = from <range-variable> in <data-source>
            group <range-variable> by <key> into <group-variable>
            select new { Key = <group-key>, Group = <group-variable> };
```

Example:

```csharp
var query = from student in students
            group student by student.Department into departmentGroup
            select new { Department = departmentGroup.Key, Students = departmentGroup };
```

These examples cover some of the fundamental LINQ keywords and clauses. LINQ provides a rich set of operators and methods for querying, filtering, grouping, and projecting data, making it a versatile and expressive language feature in C#.
  <br>
</details>

<details>
  <summary>Discuss the significance of the 'ref' and 'out' keywords in C#.</summary>
  <br>
  The `ref` and `out` keywords in C# are used to modify the behavior of parameters in method signatures. They are particularly useful when you need to pass arguments to methods in a way that allows the method to modify the values of the arguments. However, they are used in different contexts and have distinct purposes.

### `ref` Keyword:

1. **Two-Way Communication:**
   - The `ref` keyword indicates that a parameter is passed by reference, allowing the called method to modify the value of the parameter, and the changes are reflected back in the calling method.

2. **Initialization Requirement:**
   - When using `ref`, the variable being passed must be initialized before it is passed to the method.

3. **Example:**

    ```csharp
    void ModifyValue(ref int x)
    {
        x = x * 2;
    }

    // Usage
    int number = 5;
    ModifyValue(ref number);
    Console.WriteLine(number); // Output: 10
    ```

### `out` Keyword:

1. **Out Parameter:**
   - The `out` keyword is used to declare an output parameter. It is similar to `ref` in that it allows a method to modify the value of the parameter, but unlike `ref`, the parameter is not required to be initialized before being passed to the method. Instead, the called method is expected to assign a value to the parameter.

2. **Initialization Within the Method:**
   - The `out` parameter must be assigned a value within the method before the method exits.

3. **Example:**

    ```csharp
    void GetValues(out int a, out int b)
    {
        a = 10;
        b = 20;
    }

    // Usage
    int x, y;
    GetValues(out x, out y);
    Console.WriteLine(x); // Output: 10
    Console.WriteLine(y); // Output: 20
    ```

### Key Differences:

- **Initialization Requirement:**
   - With `ref`, the variable must be initialized before being passed to the method.
   - With `out`, the variable does not need to be initialized before being passed to the method, but the method must assign a value to the parameter before it exits.

- **Two-Way vs. Output:**
   - `ref` is used for two-way communication; changes made to the parameter within the method are reflected back in the calling method.
   - `out` is used specifically for output parameters; the method is expected to assign a value to the parameter before it exits.

- **Use Cases:**
   - `ref` is commonly used when you need to pass a variable to a method, allow the method to modify the variable, and reflect the changes in the calling method.
   - `out` is often used when a method needs to return multiple values, and those values need to be assigned within the method.

In summary, the `ref` and `out` keywords in C# provide a way to pass arguments to methods with the ability to modify the values of those arguments. `ref` is used for two-way communication, while `out` is used specifically for output parameters where the method assigns a value to the parameter.
  <br>
</details>

<details>
  <summary>Explain the concept of pattern matching in C#.</summary>
  <br>
Pattern matching is a feature introduced in C# 7.0 that allows developers to write more expressive and concise code when working with data structures. It enables you to check the shape or structure of data and conditionally extract information based on its structure. Pattern matching in C# includes several constructs such as switch expressions, the `is` expression, and the `switch` statement.

### Switch Expressions (C# 8.0 and later):

Switch expressions are an enhancement to the traditional switch statement. They provide a concise syntax for pattern matching and can be used to assign values based on patterns.

#### Example:

```csharp
public static string GetDayOfWeekName(DayOfWeek dayOfWeek)
{
    string dayName = dayOfWeek switch
    {
        DayOfWeek.Monday => "Monday",
        DayOfWeek.Tuesday => "Tuesday",
        DayOfWeek.Wednesday => "Wednesday",
        DayOfWeek.Thursday => "Thursday",
        DayOfWeek.Friday => "Friday",
        DayOfWeek.Saturday => "Saturday",
        DayOfWeek.Sunday => "Sunday",
        _ => throw new ArgumentException("Invalid day of week"),
    };

    return dayName;
}
```

In this example, the switch expression checks the value of `dayOfWeek` and returns the corresponding day name.

### `is` Expression:

The `is` expression is used for type checking and pattern matching. It allows you to test whether an expression can be cast to a specific type or matches a certain pattern.

#### Example:

```csharp
public static void DisplayShapeInfo(object shape)
{
    if (shape is Circle circle)
    {
        Console.WriteLine($"Circle with radius {circle.Radius}");
    }
    else if (shape is Rectangle rectangle)
    {
        Console.WriteLine($"Rectangle with dimensions {rectangle.Width}x{rectangle.Height}");
    }
    else
    {
        Console.WriteLine("Unknown shape");
    }
}
```

In this example, the `is` expression checks whether the `shape` object is of type `Circle` or `Rectangle` and performs the corresponding pattern match.

### Switch Statement (C# 7.0 and later):

The traditional switch statement in C# has been enhanced to support pattern matching.

#### Example:

```csharp
public static int GetStringLength(object obj)
{
    switch (obj)
    {
        case string str:
            return str.Length;
        case IEnumerable<char> charSequence:
            return charSequence.Count();
        case null:
            return 0;
        default:
            return -1;
    }
}
```

In this example, the switch statement checks different patterns for the `obj` parameter and returns the length based on the matched pattern.

### Tuple Patterns (C# 7.0 and later):

Tuple patterns allow you to destructure and match patterns within tuples.

#### Example:

```csharp
public static string GetCoordinateQuadrant((int x, int y) point)
{
    return point switch
    {
        (0, 0) => "Origin",
        (var x, var y) when x > 0 && y > 0 => "Quadrant I",
        (var x, var y) when x < 0 && y > 0 => "Quadrant II",
        (var x, var y) when x < 0 && y < 0 => "Quadrant III",
        (var x, var y) when x > 0 && y < 0 => "Quadrant IV",
        (_, _) => "On an axis",
    };
}
```

In this example, the tuple pattern matches different quadrants based on the values of `x` and `y` within the tuple.

Pattern matching in C# provides a more expressive and readable way to handle conditional logic based on the shape or structure of data. It enhances the ability to work with different types and structures in a more concise and type-safe manner.
  <br>
</details>

<details>
  <summary>What is the purpose of the 'virtual' and 'override' keywords in C#?</summary>
  <br>
**Purpose of 'virtual' and 'override' Keywords in C#:**

- The `virtual` keyword is used to declare a method, property, or indexer in a base class that can be overridden by derived classes. It indicates that the method is intended to be overridden in derived classes.

- The `override` keyword is used in a derived class to indicate that the method, property, or indexer being declared in the derived class is intended to override a virtual or abstract member declared in a base class.

**Key Differences:**

| Aspect                | `virtual`                                      | `override`                                        |
|-----------------------|------------------------------------------------|---------------------------------------------------|
| **Declaration**       | Used in a base class to declare a member.       | Used in a derived class to indicate overriding.    |
| **Usage**             | Declares a method, property, or indexer that    | Indicates that a member in the derived class      |
|                       | can be overridden in derived classes.          | is intended to override a virtual or abstract    |
|                       |                                                | member in the base class.                         |
| **Inheritance**       | Inherited by derived classes, but the base      | The overridden member must have the same         |
|                       | class provides a default implementation.       | signature (name, return type, and parameters).   |
| **Keyword Limitation**| Can be used with methods, properties, indexers, | Must be used specifically in derived classes    |
|                       | and events.                                    | to indicate intent to override.                   |
| **Modifier Options**  | Allows additional modifiers like `abstract`,   | Must use the `override` keyword along with       |
|                       | `new`, `override`, and `sealed`.               | the original member's access modifier.           |
| **Base Class Control**| The base class controls the default behavior   | The derived class provides a specific           |
|                       | and may provide a default implementation.      | implementation for the overridden member.       |
| **Compile-Time Check** | Type checking is performed at compile time.     | Type checking is performed at compile time.      |
| **Invocation**        | Invocation is determined at compile time based  | Invocation is determined at runtime based on    |
|                       | on the reference type.                         | the actual type of the object.                   |
| **Dynamic Dispatch**  | Dynamic dispatch is based on the reference     | Dynamic dispatch is based on the actual type    |
|                       | type of the object.                            | of the object.                                  |


In summary, `virtual` and `override` keywords in C# are crucial for achieving polymorphism through method overriding in object-oriented programming. `virtual` is used in a base class to declare a member that can be overridden, while `override` is used in a derived class to indicate the intent to provide a specific implementation for the overridden member. The differences between them lie in their roles during inheritance, compile-time checking, and dynamic dispatch.
  <br>
</details>

<details>
  <summary>What is the purpose of the 'nameof' operator in C#?</summary>
  <br>
In C#, the `nameof` operator is used to obtain the simple (unqualified) string name of a variable, type, or member. Its primary purpose is to provide a way to refer to the name of an entity in a type-safe manner, reducing the likelihood of errors due to changes in code.

Here's a basic example of using `nameof` with a variable:

```csharp
class Program
{
    static void Main()
    {
        int myVariable = 42;

        // Using nameof to get the name of the variable
        string variableName = nameof(myVariable);

        Console.WriteLine(variableName); // Output: myVariable
    }
}
```

One common use case is in scenarios where you want to raise property change notifications in data binding scenarios, especially when implementing the `INotifyPropertyChanged` interface. Instead of hardcoding property names as strings, which can lead to maintenance issues if the property name changes, you can use `nameof` to get the property name dynamically.

```csharp
class MyClass : INotifyPropertyChanged
{
    private string _myProperty;

    public string MyProperty
    {
        get { return _myProperty; }
        set
        {
            if (_myProperty != value)
            {
                _myProperty = value;
                OnPropertyChanged(nameof(MyProperty));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

By using `nameof(MyProperty)` in the `OnPropertyChanged` method, you ensure that the property name is kept in sync with the actual property, making your code more maintainable. If you later rename `MyProperty`, the `nameof` operator will automatically update the string to match the new name.
  <br>
</details>

<details>
  <summary>Explain the differences between 'var' and 'dynamic' in C#.</summary>
  <br>
Certainly! Below is the comparison between `var` and `dynamic` in a markdown format:

### Differences between `var` and `dynamic` in C#

| Factors                  | `var`                                               | `dynamic`                                                  |
|--------------------------|------------------------------------------------------|-------------------------------------------------------------|
| **Usage**                | Used for implicitly typed local variables.            | Used for variables with types resolved at runtime.           |
| **Type Inference**       | Infers the type at compile time.                     | Defers type checking until runtime.                          |
| **Type Resolution**      | Resolved statically at compile time.                  | Resolved dynamically at runtime.                             |
| **Type Safety**          | Provides static typing with compile-time checks.      | Sacrifices compile-time type safety for runtime flexibility.  |
| **Type Changes**         | Type once inferred cannot change.                     | Type can change dynamically during runtime.                  |
| **Compile-Time Checks**  | Provides compile-time type checking.                  | Defers type checking until runtime, leading to runtime errors.|
| **Performance**          | Generally more efficient due to known types.          | May introduce runtime overhead due to late binding.          |
| **Code Readability**     | Promotes explicitness and readability in code.        | May reduce code readability due to dynamic nature.           |
| **Suitable Use Cases**   | Suitable when the type is known and inferred.         | Appropriate for scenarios with unknown or dynamic types.      |

### Example

```csharp
// Using 'var'
var result1 = 10 + 5;       // 'result1' is of type int.
var message = "Hello";      // 'message' is of type string.

// Using 'dynamic'
dynamic result2 = 10 + 5;   // 'result2' is of type dynamic.
dynamic dynamicVar = "Hello"; // 'dynamicVar' is of type dynamic.
```

This table and code example highlight the key differences between `var` and `dynamic` in C#. Choose `var` for statically inferred types at compile time, ensuring type safety, and `dynamic` for scenarios where type resolution is deferred to runtime and flexibility is paramount, though sacrificing some compile-time safety.
  <br>
</details>
