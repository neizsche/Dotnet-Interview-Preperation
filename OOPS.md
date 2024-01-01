## Object-Oriented Programming (OOP)

<details>
  <summary>What is Object-Oriented Programming (OOP)?</summary>
  <br>
  OOP is a programming paradigm that revolves around the concept of objects, which can encapsulate data and behavior. It promotes the organization of code into modular units and emphasizes concepts like encapsulation, inheritance, and polymorphism to enhance code reusability and maintainability.
  <br>
</details>

<details>
  <summary>Describe encapsulation and how it is implemented in C#.</summary>
  <br>
  Encapsulation is the bundling of data and methods that operate on that data within a single unit, i.e., an object. In C#, encapsulation is achieved using access modifiers like public, private, and protected to control the visibility of members within a class, ensuring data integrity and security.
  <br>
</details>

<details>
  <summary>What is inheritance, and how does it support code reuse in C#?</summary>
  <br>
  Inheritance is a mechanism in OOP that allows a class to inherit properties and behaviors from another class. In C#, it promotes code reuse by allowing a derived class to inherit members (fields, properties, and methods) from a base class. This helps in creating a hierarchy of classes, reducing redundancy and improving maintainability.
  <br>
</details>

<details>
  <summary>How does polymorphism enhance flexibility in OOP? Provide an example in C#.</summary>
  <br>
  Polymorphism allows objects of different types to be treated as objects of a common base type. In C#, polymorphism is achieved through method overriding and interfaces. For example, consider a base class "Shape" with a method "Draw." Derived classes like "Circle" and "Square" can override the "Draw" method to provide their specific implementation while being treated as "Shape" objects.
  <br>
</details>

<details>
  <summary>How can we call the parent function from the main program while overriding, and explain overloading?</summary>
  <br>
  To call the parent function from the main program while overriding in C#, you can use the `base` keyword. It allows you to invoke the overridden method from the base class. Overloading, on the other hand, involves defining multiple methods in the same class with the same name but different parameter lists, providing flexibility in method usage.
  <br>
</details>

<details>
  <summary>Explain the difference between abstract classes and interfaces in C#.</summary>
  <br>
  Abstract classes in C# can have both abstract (unimplemented) and concrete (implemented) members, while interfaces can only have abstract members. A class can inherit from a single abstract class but implement multiple interfaces. Abstract classes can have constructors, but interfaces cannot. Both abstract classes and interfaces support achieving abstraction and multiple inheritances.
  <br>
</details>

<details>
  <summary>Discuss the importance of constructors and destructors in OOP.</summary>
  <br>
  Constructors are special methods used to initialize objects, setting their initial state. In C#, constructors are invoked when an object is created using the `new` keyword. Destructors, on the other hand, are used for cleanup operations before an object is destroyed. While C# has automatic memory management through garbage collection, destructors can be useful for releasing non-memory resources.
  <br>
</details>

<details>
  <summary>Discuss the concept of an abstract class and when to use it.</summary>
  <br>
  An abstract class in C# is a class marked with the `abstract` keyword, and it may contain abstract and non-abstract members. It cannot be instantiated on its own and serves as a blueprint for derived classes. Abstract classes are useful when you want to provide a common base implementation for multiple related classes while enforcing certain methods to be implemented by derived classes.
  <br>
</details>

<details>
  <summary>What are the limitations of OOP?</summary>
  <br>
  OOP has limitations, such as difficulty in modeling real-world systems that don't naturally fit into an object-oriented paradigm, potential for overuse of inheritance leading to complex hierarchies, and challenges in handling mutable state in a concurrent environment. Additionally, OOP may not be the most suitable paradigm for certain types of programming tasks, such as low-level system programming.
  <br>
</details>
