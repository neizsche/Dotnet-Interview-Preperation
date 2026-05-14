# .NET Interview Question Bank

> Question bank with clickable table-of-contents links and answer placeholders for later expansion.

**Status:** Question structure ready · **Total questions:** 391

---

<a id="table-of-contents"></a>

## Table of Contents

---

#### [1. OOPS Fundamentals](#section-1) — 38 questions

| No. | Question |
| --- | -------- |
| 1.1 | [Explain the four OOP principles with real-world examples.](#q-1-1) |
| 1.2 | [What is encapsulation?](#q-1-2) |
| 1.3 | [How do getters and setters support encapsulation and controlled mutation?](#q-1-3) |
| 1.4 | [Show encapsulation with example.](#q-1-4) |
| 1.5 | [What is abstraction?](#q-1-5) |
| 1.6 | [Difference between abstraction and encapsulation?](#q-1-6) |
| 1.7 | [What are access modifiers in C#?](#q-1-7) |
| 1.8 | [Difference between `public`, `private`, `protected`, `internal`, and `protected internal`?](#q-1-8) |
| 1.9 | [How do access modifiers support encapsulation?](#q-1-9) |
| 1.10 | [What is inheritance?](#q-1-10) |
| 1.11 | [Explain inheritance using Animal/Dog example.](#q-1-11) |
| 1.12 | [How do you achieve multiple inheritance in C#?](#q-1-12) |
| 1.13 | [What is polymorphism?](#q-1-13) |
| 1.14 | [Difference between compile-time and runtime polymorphism?](#q-1-14) |
| 1.15 | [What is method overloading?](#q-1-15) |
| 1.16 | [Why is overloading not possible using return type alone?](#q-1-16) |
| 1.17 | [What is method overriding?](#q-1-17) |
| 1.18 | [Difference between method overloading and method overriding](#q-1-18) |
| 1.19 | [What happens when both parent and child define the same method? Explain `virtual`, `override`, and `new`.](#q-1-19) |
| 1.20 | [What is method hiding in C#?](#q-1-20) |
| 1.21 | [Difference between method hiding and method overriding](#q-1-21) |
| 1.22 | [Purpose of the `new` keyword in method hiding](#q-1-22) |
| 1.23 | [What is the difference between `virtual`, `override`, and `abstract`?](#q-1-23) |
| 1.24 | [Difference between `virtual`, `override`, and `new`](#q-1-24) |
| 1.25 | [What is upcasting vs downcasting?](#q-1-25) |
| 1.26 | [What happens during invalid downcasting, and why does it fail?](#q-1-26) |
| 1.27 | [How does method overriding behave during upcasting and downcasting?](#q-1-27) |
| 1.28 | [What is early binding vs late binding?](#q-1-28) |
| 1.29 | [What is virtual method dispatch?](#q-1-29) |
| 1.30 | [What is a virtual method table, and how does the CLR decide which overridden method to execute?](#q-1-30) |
| 1.31 | [How does runtime polymorphism work internally?](#q-1-31) |
| 1.32 | [What happens internally during method overriding?](#q-1-32) |
| 1.33 | [Can static methods participate in polymorphism? Why can’t they be virtual?](#q-1-33) |
| 1.34 | [What are constructors in C#?](#q-1-34) |
| 1.35 | [Difference between instance constructors and static constructors](#q-1-35) |
| 1.36 | [What are primary constructors?](#q-1-36) |
| 1.37 | [What is constructor chaining?](#q-1-37) |
| 1.38 | [How do constructors work during inheritance, and what is the execution flow in an inheritance hierarchy?](#q-1-38) |

---

---
#### [2. Interface and Abstract Class](#section-2) — 22 questions

| No. | Question |
| --- | -------- |
| 2.1 | [What is an interface?](#q-2-1) |
| 2.2 | [What is an abstract class?](#q-2-2) |
| 2.3 | [Difference between interface and abstract class?](#q-2-3) |
| 2.4 | [When would you use interface vs abstract class?](#q-2-4) |
| 2.5 | [When should you use an abstract class?](#q-2-5) |
| 2.6 | [Why use interfaces instead of concrete classes?](#q-2-6) |
| 2.7 | [How do interfaces reduce coupling?](#q-2-7) |
| 2.8 | [Why depend on abstractions instead of implementations?](#q-2-8) |
| 2.9 | [Can interfaces have implementation?](#q-2-9) |
| 2.10 | [Can interfaces contain fields or state?](#q-2-10) |
| 2.11 | [Can interfaces inherit interfaces?](#q-2-11) |
| 2.12 | [What happens if two interfaces have the same method signature?](#q-2-12) |
| 2.13 | [What is explicit interface implementation?](#q-2-13) |
| 2.14 | [Can abstract methods exist in non-abstract classes?](#q-2-14) |
| 2.15 | [Can abstract classes have constructors?](#q-2-15) |
| 2.16 | [Can abstract classes contain fields or state?](#q-2-16) |
| 2.17 | [Can abstract classes implement interfaces?](#q-2-17) |
| 2.18 | [Difference between abstract method and virtual method?](#q-2-18) |
| 2.19 | [Why does C# support multiple inheritance only through interfaces?](#q-2-19) |
| 2.20 | [What is the diamond problem, and how does C# handle it with interfaces and abstract classes?](#q-2-20) |
| 2.21 | [Why not use interfaces everywhere?](#q-2-21) |
| 2.22 | [Why not use abstract classes everywhere?](#q-2-22) |

---

---
#### [3. SOLID Principles and Architecture](#section-3) — 19 questions

| No. | Question |
| --- | -------- |
| 3.1 | [Explain SOLID principles.](#q-3-1) |
| 3.2 | [What do you mean by coupling and cohesion?](#q-3-2) |
| 3.3 | [Explain Single Responsibility Principle.](#q-3-3) |
| 3.4 | [Explain Open Closed Principle.](#q-3-4) |
| 3.5 | [Explain Liskov Substitution Principle.](#q-3-5) |
| 3.6 | [Explain Interface Segregation Principle.](#q-3-6) |
| 3.7 | [Explain Dependency Inversion Principle.](#q-3-7) |
| 3.8 | [What is the difference between SRP and ISP?](#q-3-8) |
| 3.9 | [Which SOLID principle is behavioral?](#q-3-9) |
| 3.10 | [What are the practical benefits of implementing DIP?](#q-3-10) |
| 3.11 | [Why prefer composition over inheritance?](#q-3-11) |
| 3.12 | [How do interfaces improve maintainability?](#q-3-12) |
| 3.13 | [How do abstractions improve scalability?](#q-3-13) |
| 3.14 | [What is layered architecture, and how do you make it decoupled?](#q-3-14) |
| 3.15 | [What is the responsibility of each layer in a layered architecture?](#q-3-15) |
| 3.16 | [What is cyclic dependency, and how do you break it?](#q-3-16) |
| 3.17 | [How would you isolate provider-specific behavior?](#q-3-17) |
| 3.18 | [Give real-world examples of SOLID.](#q-3-18) |
| 3.19 | [How did you apply SOLID in your project?](#q-3-19) |

---
#### [4. Design Patterns](#section-4) — 25 questions

| No. | Question |
| --- | -------- |
| 4.1 | [What are design patterns?](#q-4-1) |
| 4.2 | [Difference between design pattern and architecture pattern?](#q-4-2) |
| 4.3 | [Which design patterns are commonly used in .NET applications?](#q-4-3) |
| 4.4 | [What design patterns have you used in your projects?](#q-4-4) |
| 4.5 | [What is Inversion of Control?](#q-4-5) |
| 4.6 | [What is Dependency Injection pattern?](#q-4-6) |
| 4.7 | [How does dependency injection relate to IoC?](#q-4-7) |
| 4.8 | [What is Singleton pattern?](#q-4-8) |
| 4.9 | [Where would you use Singleton?](#q-4-9) |
| 4.10 | [Problems with Singleton?](#q-4-10) |
| 4.11 | [How would you implement a thread-safe Singleton?](#q-4-11) |
| 4.12 | [Write a thread-safe Singleton implementation](#q-4-12) |
| 4.13 | [What is Factory pattern?](#q-4-13) |
| 4.14 | [Difference between Factory and Abstract Factory?](#q-4-14) |
| 4.15 | [What is Builder pattern?](#q-4-15) |
| 4.16 | [What is Strategy pattern?](#q-4-16) |
| 4.17 | [Real-world example of Strategy pattern?](#q-4-17) |
| 4.18 | [What is Observer pattern?](#q-4-18) |
| 4.19 | [What is Adapter pattern?](#q-4-19) |
| 4.20 | [What is Facade pattern?](#q-4-20) |
| 4.21 | [What is Repository pattern?](#q-4-21) |
| 4.22 | [Why use Repository pattern?](#q-4-22) |
| 4.23 | [What is Unit of Work pattern?](#q-4-23) |
| 4.24 | [Difference between Singleton, Factory, and Repository patterns](#q-4-24) |
| 4.25 | [What is CQRS?](#q-4-25) |

---
#### [5. Dependency Injection](#section-5) — 10 questions

| No. | Question |
| --- | -------- |
| 5.1 | [What is Inversion of Control?](#q-5-1) |
| 5.2 | [What is dependency injection?](#q-5-2) |
| 5.3 | [What problems does dependency injection solve?](#q-5-3) |
| 5.4 | [What happens if you instantiate concrete implementations directly?](#q-5-4) |
| 5.5 | [How is DI implemented in .NET?](#q-5-5) |
| 5.6 | [Explain the three DI service lifetimes: Transient, Scoped, and Singleton.](#q-5-6) |
| 5.7 | [Which lifetime is used for DbContext?](#q-5-7) |
| 5.8 | [What problems happen with Singleton misuse?](#q-5-8) |
| 5.9 | [What is captive dependency?](#q-5-9) |
| 5.10 | [How does DI help in unit testing and mocking?](#q-5-10) |

---
#### [6. C# Core Concepts](#section-6) — 112 questions

| No. | Question |
| --- | -------- |
| 6.1 | [What is a static class?](#q-6-1) |
| 6.2 | [When should you use a static class?](#q-6-2) |
| 6.3 | [What are the limitations of static classes?](#q-6-3) |
| 6.4 | [Difference between static constructor and private constructor](#q-6-4) |
| 6.5 | [How do static members work internally?](#q-6-5) |
| 6.6 | [Why does the CLR provide thread safety for static constructors?](#q-6-6) |
| 6.7 | [Order of execution of static constructors and instance constructors](#q-6-7) |
| 6.8 | [What is a sealed class?](#q-6-8) |
| 6.9 | [Why would you seal a class or method?](#q-6-9) |
| 6.10 | [Difference between class, struct, and record](#q-6-10) |
| 6.11 | [Difference between class and struct](#q-6-11) |
| 6.12 | [When should you use a struct instead of a class?](#q-6-12) |
| 6.13 | [Why are structs value types?](#q-6-13) |
| 6.14 | [What are records in C# and why were they introduced?](#q-6-14) |
| 6.15 | [What problems do records solve?](#q-6-15) |
| 6.16 | [What are extension methods?](#q-6-16) |
| 6.17 | [How are extension methods implemented under the hood?](#q-6-17) |
| 6.18 | [What is Reflection?](#q-6-18) |
| 6.19 | [What are delegates in C#?](#q-6-19) |
| 6.20 | [How do delegates work internally?](#q-6-20) |
| 6.21 | [What are multicast delegates?](#q-6-21) |
| 6.22 | [Difference between delegates and events](#q-6-22) |
| 6.23 | [Why use events over delegates?](#q-6-23) |
| 6.24 | [How are events implemented internally in .NET?](#q-6-24) |
| 6.25 | [When would you use events in real-world applications?](#q-6-25) |
| 6.26 | [What is the practical use of delegates?](#q-6-26) |
| 6.27 | [Difference between Action, Func, and Predicate](#q-6-27) |
| 6.28 | [What are generic classes in C#?](#q-6-28) |
| 6.29 | [Why are generics important?](#q-6-29) |
| 6.30 | [How do generics work internally in .NET?](#q-6-30) |
| 6.31 | [Why are generics type-safe?](#q-6-31) |
| 6.32 | [What are generic constraints?](#q-6-32) |
| 6.33 | [Types of generic constraints in C#](#q-6-33) |
| 6.34 | [Difference between covariance, contravariance, and invariance](#q-6-34) |
| 6.35 | [Where are covariance and contravariance used in .NET?](#q-6-35) |
| 6.36 | [What is boxing and unboxing?](#q-6-36) |
| 6.37 | [What happens internally during boxing and unboxing?](#q-6-37) |
| 6.38 | [Why are boxing and unboxing expensive?](#q-6-38) |
| 6.39 | [What are nullable types in C#?](#q-6-39) |
| 6.40 | [How does `Nullable<T>` work internally?](#q-6-40) |
| 6.41 | [Where are nullable types stored in memory?](#q-6-41) |
| 6.42 | [Difference between `const`, `readonly`, and `static readonly`](#q-6-42) |
| 6.43 | [When should you use `const` vs `readonly`?](#q-6-43) |
| 6.44 | [Difference between `ref`, `out`, and `in` parameters](#q-6-44) |
| 6.45 | [What are method parameters and argument passing mechanisms?](#q-6-45) |
| 6.46 | [How do methods work internally in .NET?](#q-6-46) |
| 6.47 | [What happens under the hood when a method is called?](#q-6-47) |
| 6.48 | [What is the purpose of the `yield` statement?](#q-6-48) |
| 6.49 | [How do iterators work internally in C#?](#q-6-49) |
| 6.50 | [Difference between `==`, `Equals()`, and `String.Compare()` in C#](#q-6-50) |
| 6.51 | [Difference between `String` and `StringBuilder`](#q-6-51) |
| 6.52 | [Why is `string` a reference type but behaves like a value type?](#q-6-52) |
| 6.53 | [Difference between `string.IsNullOrEmpty()` and `string.IsNullOrWhiteSpace()`](#q-6-53) |
| 6.54 | [Why are strings immutable in C#?](#q-6-54) |
| 6.55 | [What are the benefits and drawbacks of immutable strings?](#q-6-55) |
| 6.56 | [Difference between value types and reference types](#q-6-56) |
| 6.57 | [Difference between stack and heap memory](#q-6-57) |
| 6.58 | [Where are value types and reference types stored in memory?](#q-6-58) |
| 6.59 | [How does memory allocation work for structs and classes?](#q-6-59) |
| 6.60 | [What is thread safety?](#q-6-60) |
| 6.61 | [What problems occur in multithreaded applications?](#q-6-61) |
| 6.62 | [Difference between synchronization and thread safety](#q-6-62) |
| 6.63 | [What is the `lock` statement?](#q-6-63) |
| 6.64 | [How does locking work internally in .NET?](#q-6-64) |
| 6.65 | [What problems does locking solve?](#q-6-65) |
| 6.66 | [What is deadlock and how can it be avoided?](#q-6-66) |
| 6.67 | [Difference between synchronous and asynchronous programming](#q-6-67) |
| 6.68 | [What is async/await?](#q-6-68) |
| 6.69 | [How does async/await work internally?](#q-6-69) |
| 6.70 | [What is Task in .NET?](#q-6-70) |
| 6.71 | [What is TAP (Task-based Asynchronous Pattern)?](#q-6-71) |
| 6.72 | [What is the ThreadPool in .NET?](#q-6-72) |
| 6.73 | [Difference between `Task.Run()` and creating threads manually](#q-6-73) |
| 6.74 | [Difference between concurrency and parallelism](#q-6-74) |
| 6.75 | [What is `SynchronizationContext`?](#q-6-75) |
| 6.76 | [What is `ConfigureAwait(false)` and when should you use it?](#q-6-76) |
| 6.77 | [Difference between `Task.WhenAll()` and `Task.WhenAny()`](#q-6-77) |
| 6.78 | [How are exceptions handled in async/await?](#q-6-78) |
| 6.79 | [Why should async methods avoid `async void`?](#q-6-79) |
| 6.80 | [When is `async void` acceptable?](#q-6-80) |
| 6.81 | [What are exceptions in C#?](#q-6-81) |
| 6.82 | [Explain `try`, `catch`, and `finally`](#q-6-82) |
| 6.83 | [What is the purpose of the `finally` block?](#q-6-83) |
| 6.84 | [Difference between `throw` and `throw ex`](#q-6-84) |
| 6.85 | [Why is `throw ex` considered bad practice?](#q-6-85) |
| 6.86 | [What are custom exceptions?](#q-6-86) |
| 6.87 | [How do you create custom exceptions?](#q-6-87) |
| 6.88 | [How does exception handling work internally in .NET?](#q-6-88) |
| 6.89 | [What happens if an exception is not handled?](#q-6-89) |
| 6.90 | [Best practices for exception handling in enterprise applications](#q-6-90) |
| 6.91 | [What is IDisposable?](#q-6-91) |
| 6.92 | [Who calls Dispose()?](#q-6-92) |
| 6.93 | [Difference between managed and unmanaged resources](#q-6-93) |
| 6.94 | [What is managed code?](#q-6-94) |
| 6.95 | [What is unmanaged code?](#q-6-95) |
| 6.96 | [Difference between managed and unmanaged code](#q-6-96) |
| 6.97 | [How does the `using` statement work internally?](#q-6-97) |
| 6.98 | [Difference between `Dispose()` and finalizers](#q-6-98) |
| 6.99 | [What is garbage collection (GC)?](#q-6-99) |
| 6.100 | [How does garbage collection work internally?](#q-6-100) |
| 6.101 | [What are GC generations?](#q-6-101) |
| 6.102 | [Does GC run on a fixed schedule?](#q-6-102) |
| 6.103 | [How does the CLR manage memory?](#q-6-103) |
| 6.104 | [What is CLR (Common Language Runtime)?](#q-6-104) |
| 6.105 | [Responsibilities of the CLR](#q-6-105) |
| 6.106 | [How does the CLR execute C# code?](#q-6-106) |
| 6.107 | [How does the CLR manage application execution?](#q-6-107) |
| 6.108 | [What is JIT compilation?](#q-6-108) |
| 6.109 | [Write a custom delegate and event example](#q-6-109) |
| 6.110 | [Demonstrate the difference between `throw` and `throw ex`](#q-6-110) |
| 6.111 | [Write an example using `Task.WhenAll()`](#q-6-111) |
| 6.112 | [Explain the output of async/await execution flow snippets](#q-6-112) |

---
#### [7. ASP.NET Core and APIs](#section-7) — 23 questions

| No. | Question |
| --- | -------- |
| 7.1 | [What is REST?](#q-7-1) |
| 7.2 | [What are REST principles?](#q-7-2) |
| 7.3 | [Difference between GET, POST, PUT, PATCH, and DELETE?](#q-7-3) |
| 7.4 | [What is IActionResult?](#q-7-4) |
| 7.5 | [Difference between IActionResult and ActionResult?](#q-7-5) |
| 7.6 | [What are common HTTP status codes?](#q-7-6) |
| 7.7 | [Difference between authentication and authorization?](#q-7-7) |
| 7.8 | [What is JWT?](#q-7-8) |
| 7.9 | [Claims-based vs policy-based authorization?](#q-7-9) |
| 7.10 | [What is middleware?](#q-7-10) |
| 7.11 | [How does middleware pipeline work?](#q-7-11) |
| 7.12 | [How do you structure controllers, services, and repositories?](#q-7-12) |
| 7.13 | [What is model binding?](#q-7-13) |
| 7.14 | [What is dependency injection in ASP.NET Core?](#q-7-14) |
| 7.15 | [How do you handle exceptions globally?](#q-7-15) |
| 7.16 | [What is API versioning?](#q-7-16) |
| 7.17 | [What is CORS?](#q-7-17) |
| 7.18 | [What is Swagger/OpenAPI?](#q-7-18) |
| 7.19 | [How do microservices communicate?](#q-7-19) |
| 7.20 | [What is microservice architecture?](#q-7-20) |
| 7.21 | [Difference between `IActionResult` and `ActionResult<T>`](#q-7-21) |
| 7.22 | [When should you use `ActionResult<T>`?](#q-7-22) |
| 7.23 | [Advantages of strongly typed API responses](#q-7-23) |

---
#### [8. LINQ and Collections](#section-8) — 25 questions

| No. | Question |
| --- | -------- |
| 8.1 | [What is LINQ?](#q-8-1) |
| 8.2 | [Difference between LINQ to Objects and LINQ to Entities](#q-8-2) |
| 8.3 | [What LINQ methods have you used?](#q-8-3) |
| 8.4 | [How do joins work in LINQ?](#q-8-4) |
| 8.5 | [What is GroupBy in LINQ?](#q-8-5) |
| 8.6 | [Difference between `Select` and `SelectMany`](#q-8-6) |
| 8.7 | [Difference between `First`, `FirstOrDefault`, and `Single`](#q-8-7) |
| 8.8 | [When should you use `Single` over `FirstOrDefault`?](#q-8-8) |
| 8.9 | [What is deferred execution in LINQ?](#q-8-9) |
| 8.10 | [Advantages and disadvantages of deferred execution](#q-8-10) |
| 8.11 | [When does a LINQ query execute?](#q-8-11) |
| 8.12 | [What does `ToList()` do internally?](#q-8-12) |
| 8.13 | [Difference between `IEnumerable` and `IQueryable`](#q-8-13) |
| 8.14 | [Why is `IEnumerable` preferred in some method signatures?](#q-8-14) |
| 8.15 | [Why should repositories return `IQueryable` carefully?](#q-8-15) |
| 8.16 | [Difference between `IEnumerable` and `List`](#q-8-16) |
| 8.17 | [Difference between arrays and collections](#q-8-17) |
| 8.18 | [Is `List<T>` a value type or reference type? Why?](#q-8-18) |
| 8.19 | [Why do generics improve performance compared to non-generic collections?](#q-8-19) |
| 8.20 | [Difference between `List`, `Dictionary`, and `HashSet`](#q-8-20) |
| 8.21 | [When should you use `HashSet` over `List`?](#q-8-21) |
| 8.22 | [Internal working of `Dictionary<TKey, TValue>`](#q-8-22) |
| 8.23 | [Time complexities of common collection operations](#q-8-23) |
| 8.24 | [What is lazy loading?](#q-8-24) |
| 8.25 | [Write a LINQ query and explain deferred execution](#q-8-25) |

---
#### [9. SQL](#section-9) — 26 questions

| No. | Question |
| --- | -------- |
| 9.1 | [Difference between UNION and UNION ALL?](#q-9-1) |
| 9.2 | [Explain INNER JOIN.](#q-9-2) |
| 9.3 | [Explain LEFT JOIN.](#q-9-3) |
| 9.4 | [Explain RIGHT JOIN.](#q-9-4) |
| 9.5 | [Explain FULL OUTER JOIN.](#q-9-5) |
| 9.6 | [Difference between Primary Key and Unique Key?](#q-9-6) |
| 9.7 | [What are indexes?](#q-9-7) |
| 9.8 | [Difference between clustered and non-clustered index?](#q-9-8) |
| 9.9 | [How many clustered indexes can a table have?](#q-9-9) |
| 9.10 | [What are ranking functions?](#q-9-10) |
| 9.11 | [Difference between ROW_NUMBER, RANK, and DENSE_RANK?](#q-9-11) |
| 9.12 | [What are stored procedures?](#q-9-12) |
| 9.13 | [Difference between procedure and function?](#q-9-13) |
| 9.14 | [What are table-valued functions?](#q-9-14) |
| 9.15 | [What is normalization?](#q-9-15) |
| 9.16 | [What is denormalization?](#q-9-16) |
| 9.17 | [What is a CTE?](#q-9-17) |
| 9.18 | [What are aggregate functions?](#q-9-18) |
| 9.19 | [What is pagination?](#q-9-19) |
| 9.20 | [What causes slow queries?](#q-9-20) |
| 9.21 | [How do you optimize SQL queries?](#q-9-21) |
| 9.22 | [What is index seek vs index scan?](#q-9-22) |
| 9.23 | [Why is SELECT * bad?](#q-9-23) |
| 9.24 | [What is deadlock in SQL?](#q-9-24) |
| 9.25 | [What is transaction?](#q-9-25) |
| 9.26 | [What are ACID properties?](#q-9-26) |

---
#### [10. Frontend: Angular and React](#section-10) — 19 questions

| No. | Question |
| --- | -------- |
| 10.1 | [What is two-way binding?](#q-10-1) |
| 10.2 | [What are components?](#q-10-2) |
| 10.3 | [What are services?](#q-10-3) |
| 10.4 | [What are pipes?](#q-10-4) |
| 10.5 | [What are custom pipes?](#q-10-5) |
| 10.6 | [Difference between template-driven and reactive forms?](#q-10-6) |
| 10.7 | [What are RxJS operators?](#q-10-7) |
| 10.8 | [How does parent-child communication work?](#q-10-8) |
| 10.9 | [How do sibling components communicate?](#q-10-9) |
| 10.10 | [What are observables?](#q-10-10) |
| 10.11 | [Difference between class and functional components?](#q-10-11) |
| 10.12 | [What are hooks?](#q-10-12) |
| 10.13 | [What is useState?](#q-10-13) |
| 10.14 | [What is useEffect?](#q-10-14) |
| 10.15 | [What is useMemo?](#q-10-15) |
| 10.16 | [What are props and state?](#q-10-16) |
| 10.17 | [What is React key?](#q-10-17) |
| 10.18 | [Why is key important in lists?](#q-10-18) |
| 10.19 | [What does map() do in React?](#q-10-19) |

---
#### [11. System Design, Performance, and Scalability](#section-11) — 19 questions

| No. | Question |
| --- | -------- |
| 11.1 | [How did you improve performance in your project?](#q-11-1) |
| 11.2 | [How do you optimize slow APIs?](#q-11-2) |
| 11.3 | [How do you reduce payload size?](#q-11-3) |
| 11.4 | [How does pagination improve performance?](#q-11-4) |
| 11.5 | [What is lazy loading?](#q-11-5) |
| 11.6 | [How do you identify bottlenecks?](#q-11-6) |
| 11.7 | [How do you improve scalability?](#q-11-7) |
| 11.8 | [How do you handle high-volume API responses?](#q-11-8) |
| 11.9 | [How do microservices improve scalability?](#q-11-9) |
| 11.10 | [What causes blocking or waiting issues?](#q-11-10) |
| 11.11 | [How would you debug slow backend response?](#q-11-11) |
| 11.12 | [How would you optimize data-heavy dashboards?](#q-11-12) |
| 11.13 | [Monolith vs microservices?](#q-11-13) |
| 11.14 | [Synchronous vs asynchronous microservice communication?](#q-11-14) |
| 11.15 | [What is API Gateway?](#q-11-15) |
| 11.16 | [What are caching strategies?](#q-11-16) |
| 11.17 | [Redis basics?](#q-11-17) |
| 11.18 | [Horizontal vs vertical scaling?](#q-11-18) |
| 11.19 | [How do you design fault-tolerant systems?](#q-11-19) |

---
#### [12. Testing](#section-12) — 10 questions

| No. | Question |
| --- | -------- |
| 12.1 | [What is unit testing?](#q-12-1) |
| 12.2 | [What is integration testing?](#q-12-2) |
| 12.3 | [Difference between unit testing and integration testing?](#q-12-3) |
| 12.4 | [What is BDD?](#q-12-4) |
| 12.5 | [Difference between BDD and unit testing?](#q-12-5) |
| 12.6 | [What is mocking?](#q-12-6) |
| 12.7 | [Why use mocks?](#q-12-7) |
| 12.8 | [What frameworks have you used?](#q-12-8) |
| 12.9 | [What is testability?](#q-12-9) |
| 12.10 | [How do interfaces help testing?](#q-12-10) |

---
#### [13. Git, DevOps, and Cloud](#section-13) — 10 questions

| No. | Question |
| --- | -------- |
| 13.1 | [Difference between git fetch and git pull?](#q-13-1) |
| 13.2 | [What is merge conflict?](#q-13-2) |
| 13.3 | [What is rebase?](#q-13-3) |
| 13.4 | [What branching strategy do you use?](#q-13-4) |
| 13.5 | [Have you worked with AWS or Azure?](#q-13-5) |
| 13.6 | [What AWS services have you used?](#q-13-6) |
| 13.7 | [What is CI/CD?](#q-13-7) |
| 13.8 | [What is Docker?](#q-13-8) |
| 13.9 | [What is Kubernetes?](#q-13-9) |
| 13.10 | [What is environment configuration management?](#q-13-10) |

---
#### [14. Coding Questions Asked](#section-14) — 7 questions

| No. | Question |
| --- | -------- |
| 14.1 | [Find number closest to zero.](#q-14-1) |
| 14.2 | [FizzBuzz problem.](#q-14-2) |
| 14.3 | [Progressive substring printing.](#q-14-3) |
| 14.4 | [Array or string iteration problems.](#q-14-4) |
| 14.5 | [Divisibility logic problems.](#q-14-5) |
| 14.6 | [Basic loop and condition problems.](#q-14-6) |
| 14.7 | [Simple optimization logic problems.](#q-14-7) |

---

<a id="section-1"></a>
## 1. OOPS Fundamentals

<a id="q-1-1"></a>
> #### 1.1 Explain the four OOP principles with real-world examples.

**Object-Oriented Programming (OOP)** is a paradigm focused on modeling behavior behind contracts. Under the hood in .NET, it leverages **type metadata**, **memory layout**, and **virtual method tables (vtables)** to enforce security, enable reuse, and dispatch method calls at runtime.

**Interview Ready Answer:**

| Principle | Definition & Deep Concept | Real-World Example & Implementation |
|---|---|---|
| **Encapsulation** | **Data Hiding & State Protection**. It binds data and methods together and restricts outside interference. The CLR enforces this at the IL level—private fields cannot be accessed outside the declaring type (without reflection). | **Example:** A `BankAccount` class where `_balance` is private, modified only via `Deposit()` or `Withdraw()`. This allows adding overdraft validation later without breaking consumer code. |
| **Abstraction** | **Behavior Hiding**. Exposes *what* an object does while hiding *how* it does it. It decouples the contract from the implementation, reducing system complexity and coupling. | **Example:** An `IPaymentGateway` interface with a `ProcessPayment()` method. The consumer doesn't need to know if it's hitting Stripe's API or PayPal's API. |
| **Inheritance** | **Reusability & Hierarchy (Is-A)**. Allows a class to inherit behavior from a base class. The CLR copies the parent's method table into the child's type metadata, avoiding IL duplication. *Note: C# supports single class inheritance to avoid the diamond problem.* | **Example:** `SqlRepository : BaseRepository`. Common CRUD methods live in the base class, while SQL-specific overrides or additions exist in the child. |
| **Polymorphism** | **Dynamic Dispatch**. One interface, multiple implementations. Resolved via late binding using the **vtable**. When a virtual method is called, the CLR checks the actual object's type metadata at runtime to execute the correct override. | **Example:** A `List<INotificationService>` containing `EmailService` and `SmsService`. Calling `.Send()` on each executes the specific implementation dynamically. |

**Key Takeaways to Highlight:**
- **Encapsulation** is about protecting internal state, while **Abstraction** is about simplifying the external contract.
- Prefer **Composition over Inheritance** to avoid rigid, tightly coupled hierarchies.
- **Polymorphism** is the enabler for the **Open/Closed Principle (OCP)** and **Dependency Inversion Principle (DIP)**.

<a id="q-1-2"></a>
> #### 1.2 What is encapsulation?

**Encapsulation** is the process of bundling data (state) and the methods that operate on that data into a single unit (class), while restricting direct access to the internal state.

**Interview Ready Answer:**
- **State Protection:** It prevents external code from putting an object into an invalid state by forcing interaction through a defined API.
- **Implementation Hiding:** The internal workings and data structures can change without affecting the external consumers.
- **CLR Level Enforcement:** Access modifiers (`private`, `protected`, etc.) are rigorously enforced by the CLR at the Intermediate Language (IL) level, ensuring memory safety and object isolation.

<a id="q-1-3"></a>
> #### 1.3 How do getters and setters support encapsulation and controlled mutation?

Getters and setters (exposed as **Properties** in C#) act as gatekeepers to the underlying private fields, allowing you to intercept and control how state is read or modified.

**Interview Ready Answer:**
- **Controlled Mutation:** Setters allow you to inject validation logic, fire events (like `INotifyPropertyChanged`), or enforce invariant business rules before the state actually changes.
- **Read-Only State:** By providing only a getter (or an `init` setter in modern C#), you can create immutable or read-only properties, which is crucial for thread safety.
- **Binary Compatibility Safety:** If you expose a public field and later change it to a property to add validation, you break binary compatibility (consumers throw `MissingFieldException`). Properties prevent this because they compile to `get_X()` and `set_X()` methods under the hood from day one.

<a id="q-1-4"></a>
> #### 1.4 Show encapsulation with example.

**Interview Ready Answer:**
```csharp
public class ShoppingCart
{
    // Private state: Hidden from the outside world
    private readonly List<Item> _items = new List<Item>();

    // Controlled getter: Returns a read-only view to prevent external mutation
    public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

    // Controlled mutation: Business logic is enforced here
    public void AddItem(Item item)
    {
        if (item == null) 
            throw new ArgumentNullException(nameof(item));
        
        if (item.Price < 0) 
            throw new InvalidOperationException("Price cannot be negative.");
        
        _items.Add(item);
    }
}
```
**Key Takeaways:** 
- The caller cannot execute `cart.Items.Add()`. They must use `cart.AddItem()`, ensuring all validation logic executes, thus keeping the object in a valid state.

<a id="q-1-5"></a>
> #### 1.5 What is abstraction?

**Abstraction** is the principle of hiding complex implementation details and exposing only the essential features and behaviors of an object.

**Interview Ready Answer:**
- **Contract vs. Implementation:** It separates *what* a system does from *how* it does it. In C#, this is primarily modeled using `interface` and `abstract class`.
- **Decoupling:** Consumers depend on abstractions rather than concrete types. This drastically reduces system coupling and enables unit testing (e.g., via mocking).
- **Extensibility:** New implementations can be introduced seamlessly without modifying the consuming code, perfectly aligning with the **Dependency Inversion Principle (DIP)**.

<a id="q-1-6"></a>
> #### 1.6 Difference between abstraction and encapsulation?

While both deal with hiding information, their intent and mechanism differ significantly.

**Interview Ready Answer:**

| Feature | Abstraction | Encapsulation |
|---|---|---|
| **Core Intent** | **Hides complexity** and shows only essential features. | **Hides internal state** and protects data integrity. |
| **Focus** | Focuses on the **external contract** (What it does). | Focuses on the **internal implementation** (How it manages state). |
| **Mechanism** | Implemented using **Interfaces** and **Abstract Classes**. | Implemented using **Access Modifiers** (`private`, `protected`, properties). |
| **Analogy** | Driving a car: You use the steering wheel and pedals without knowing how the engine works. | The car's engine casing: It protects the pistons and belts from outside interference. |

<a id="q-1-7"></a>
> #### 1.7 What are access modifiers in C#?

**Access modifiers** are keywords used to specify the declared accessibility of a member or a type. They define the scope from which the code can be accessed.

**Interview Ready Answer:**
- **Security & Encapsulation:** They are the primary mechanism for implementing encapsulation, ensuring that objects restrict access to their internal state and expose only a safe, controlled API.
- **CLR Enforcement:** Accessibility is baked into the compiled IL. The JIT compiler and CLR strictly enforce these boundaries at runtime, preventing unauthorized memory or method access.
- **Six Modifiers:** C# provides six access levels: `public`, `private`, `protected`, `internal`, `protected internal`, and `private protected`.

<a id="q-1-8"></a>
> #### 1.8 Difference between `public`, `private`, `protected`, `internal`, and `protected internal`?

These modifiers control visibility at the class and assembly levels.

**Interview Ready Answer:**

| Modifier | Visibility Scope | Deep Concept / Common Use Case |
|---|---|---|
| **public** | Anywhere. | Use for the external API contract of your class or library. |
| **private** | Inside the defining class/struct only. | Default for members. Use for internal state and helper methods. Essential for Encapsulation. |
| **protected** | Inside the defining class and its derived classes. | Use when building base classes where child classes need to access or override core functionality (e.g., `BaseController` or `BaseRepository`). |
| **internal** | Anywhere within the same Assembly (.dll/.exe). | Default for non-nested types. Crucial for Domain-Driven Design (DDD) to hide domain logic from the Presentation layer while keeping it accessible within the Domain assembly. |
| **protected internal**| Within the same Assembly OR derived classes in other assemblies. | Acts as an **OR** condition. Useful for framework development where you want internal access plus extensibility for third-party inheriting classes. |
| **private protected**| Derived classes *only* within the same Assembly. | Acts as an **AND** condition. Very restrictive; perfect for hiding base-class implementation details even from derived classes if they are in an external assembly. |

<a id="q-1-9"></a>
> #### 1.9 How do access modifiers support encapsulation?

Access modifiers are the physical implementation of the encapsulation principle in C#.

**Interview Ready Answer:**
- **Boundary Definition:** They draw a hard boundary between the internal workings of an object (marked `private`) and its external contract (marked `public`).
- **Preventing Invariant Violations:** By hiding fields (`private`) and exposing them via properties or methods (`public`), access modifiers ensure that an object's state cannot be corrupted by external code bypassing validation rules.
- **Reducing Blast Radius:** When internal methods and state are `private` or `internal`, you can freely refactor them without worrying about breaking external consumers.

<a id="q-1-10"></a>
> #### 1.10 What is inheritance?

**Inheritance** is an OOP mechanism where a new class (derived class) inherits the fields, properties, and methods of an existing class (base class), establishing an **"is-a"** relationship.

**Interview Ready Answer:**
- **Code Reuse & Hierarchy:** It allows developers to create a hierarchical classification and reuse base logic without duplication.
- **Vtable & Metadata:** At the CLR level, the derived class's type metadata points to the base class, and it inherits the base class's virtual method table (vtable).
- **Single Class Inheritance:** C# only supports single class inheritance to prevent the "Diamond Problem" (ambiguity when inheriting from two classes with the same method). However, it supports multiple interface inheritance.
- **Tight Coupling:** It is the strongest form of coupling. In modern architecture, you should strongly prefer **Composition over Inheritance** unless you are modeling a genuine, rigid type hierarchy.

<a id="q-1-11"></a>
> #### 1.11 Explain inheritance using Animal/Dog example.

**Interview Ready Answer:**
```csharp
// Base Class
public abstract class Animal 
{
    // Common state and behavior
    public string Name { get; set; }
    
    // Virtual allows child to provide a specific implementation
    public virtual void MakeSound() 
    {
        Console.WriteLine("Generic animal sound");
    }
}

// Derived Class (Dog is-a Animal)
public class Dog : Animal 
{
    // Dog inherits Name property automatically
    
    // Overriding the base behavior
    public override void MakeSound() 
    {
        Console.WriteLine("Bark!");
    }
    
    // Dog-specific behavior
    public void Fetch() 
    {
        Console.WriteLine("Fetching the ball...");
    }
}
```
**Enterprise Analogy:** While `Animal/Dog` is a textbook example, in a real application, you might see `abstract class BaseRepository<T>` and `class UserRepository : BaseRepository<User>`. `UserRepository` inherits `Add()` and `Update()` from the base, but overrides or adds `GetByEmail()`.

<a id="q-1-12"></a>
> #### 1.12 How do you achieve multiple inheritance in C#?

C# **does not support multiple inheritance for classes** (a class cannot have more than one direct base class). It does this to avoid the **Diamond Problem**.

**Interview Ready Answer:**
- **Via Interfaces:** You can implement multiple interfaces. This is multiple inheritance of *contracts*, not implementation.
- **Via Default Interface Methods (C# 8.0+):** You can now provide default implementations in interfaces, which practically introduces a limited form of multiple implementation inheritance.
- **Via Composition (Best Practice):** Instead of trying to inherit from multiple classes, inject the required behaviors as dependencies (Has-A relationship).

**Example of Composition + Interfaces:**
```csharp
public interface ILogger { void Log(); }
public interface IEmailSender { void Send(); }

// Achieving "multiple inheritance" through interfaces and composition
public class UserService : ILogger, IEmailSender
{
    private readonly ILogger _logger;
    private readonly IEmailSender _emailSender;

    public UserService(ILogger logger, IEmailSender emailSender)
    {
        _logger = logger;
        _emailSender = emailSender;
    }

    public void Log() => _logger.Log();
    public void Send() => _emailSender.Send();
}
```

<a id="q-1-13"></a>
> #### 1.13 What is polymorphism?

**Polymorphism** means "many forms." It is the ability of a single interface or base class reference to take on different forms (implementations) depending on the actual object it points to.

**Interview Ready Answer:**
- **Dynamic Dispatch:** At runtime, when a method is called on a base reference, the CLR uses the **virtual method table (vtable)** to look up the exact implementation defined by the derived class.
- **Decoupling:** The caller doesn't need to know the concrete type of the object. It only needs to know the contract (the interface or base class).
- **Enabler for SOLID:** Polymorphism is the physical mechanism that makes the **Open/Closed Principle (OCP)** possible—you add new behavior by introducing new classes that implement an interface, without modifying the caller.

<a id="q-1-14"></a>
> #### 1.14 Difference between compile-time and runtime polymorphism?

Polymorphism can occur during code compilation or while the application is executing.

**Interview Ready Answer:**

| Feature | Compile-Time (Static) Polymorphism | Runtime (Dynamic) Polymorphism |
|---|---|---|
| **Definition** | The compiler determines which method to call based on method signatures. | The CLR determines which method to call at runtime based on the actual object instance. |
| **Mechanism** | Method Overloading, Operator Overloading. | Method Overriding (using `virtual` and `override`). |
| **Binding Type** | **Early Binding** (Static Binding). | **Late Binding** (Dynamic Binding). |
| **Performance** | Slightly faster (resolved at compile time). | Incurs a tiny overhead due to vtable lookup at runtime. |
| **Example** | `Print(int i)` vs `Print(string s)` | `baseRef.Execute()` executing `DerivedClass.Execute()` |

<a id="q-1-15"></a>
> #### 1.15 What is method overloading?

**Method Overloading** is a form of compile-time polymorphism where multiple methods in the same class share the same name but have different parameter lists (signatures).

**Interview Ready Answer:**
- **Signature Differences:** Overloaded methods must differ in the **number**, **type**, or **order** of parameters.
- **Compiler Resolution:** The C# compiler resolves which overload to invoke at compile-time by matching the arguments passed by the caller to the available method signatures.
- **Improved API Design:** It provides a cleaner API by grouping logically identical operations under a single name (e.g., `Console.WriteLine(string)` vs `Console.WriteLine(int)`).

<a id="q-1-16"></a>
> #### 1.16 Why is overloading not possible using return type alone?

The C# compiler **does not include the return type** as part of a method's signature for the purpose of overloading.

**Interview Ready Answer:**
- **Ambiguity during invocation:** If you have `int GetValue()` and `string GetValue()`, and you simply call `GetValue();` without assigning the result to a variable, the compiler has no way to know which method you intended to call.
- **Context Independence:** Method resolution must happen based solely on the arguments provided, independent of how (or if) the return value is used.

<a id="q-1-17"></a>
> #### 1.17 What is method overriding?

**Method Overriding** is a runtime polymorphism feature where a derived class provides a specific implementation for a method that is already defined as `virtual` or `abstract` in its base class.

**Interview Ready Answer:**
- **The `override` Keyword:** The derived method must use the `override` keyword and exactly match the signature (name, parameters, and return type) of the base method.
- **Vtable Modification:** Under the hood, overriding replaces the base class method's memory address with the derived class method's memory address in the virtual method table (vtable).
- **Late Binding:** This guarantees that even if the object is cast to its base type, the derived class's overridden method will be the one executed.

<a id="q-1-18"></a>
> #### 1.18 Difference between method overloading and method overriding

These are the two primary mechanisms for achieving polymorphism, differing fundamentally in when and how they are resolved.

**Interview Ready Answer:**

| Feature | Method Overloading | Method Overriding |
|---|---|---|
| **Polymorphism Type** | Compile-time (Static / Early binding). | Runtime (Dynamic / Late binding). |
| **Location** | Occurs within the **same class**. | Occurs across a **base and derived class**. |
| **Method Signature**| Must have **different** parameters (type, count, order). | Must have the **exact same** signature (including return type). |
| **Keywords Required**| None. | `virtual`/`abstract` on base, `override` on derived. |
| **Purpose** | To perform similar operations on different types/amounts of input. | To change or extend the specific behavior of an inherited method. |

<a id="q-1-19"></a>
> #### 1.19 What happens when both parent and child define the same method? Explain `virtual`, `override`, and `new`.

If both classes define the same method name and signature without any specific keywords, the C# compiler issues a warning because it assumes you unintentionally hid the parent method. You must explicitly define your intent using `virtual`, `override`, or `new`.

**Interview Ready Answer:**
- **`virtual` (Base Class):** Opts-in the method for runtime polymorphism. It tells the CLR, "Derived classes might provide a more specific implementation of this method. Check at runtime."
- **`override` (Derived Class):** Replaces the base class's `virtual` implementation. If a base class reference points to a derived object, calling this method executes the *derived* logic (Dynamic Dispatch).
- **`new` (Derived Class - Method Hiding):** Creates a completely separate method that happens to have the same name. It severs the polymorphic link. If a base class reference points to a derived object, calling this method executes the *base* logic.

<a id="q-1-20"></a>
> #### 1.20 What is method hiding in C#?

**Method Hiding** (also known as shadowing) occurs when a derived class defines a method with the exact same name and signature as a method in its base class, but uses the `new` keyword instead of `override`.

**Interview Ready Answer:**
- **Severed Polymorphism:** Unlike overriding, hiding does not modify the base class's virtual method table. It creates a brand new method on the derived type.
- **Reference Type Matters:** The method executed depends entirely on the **type of the reference variable**, not the actual object instance.
- **Use Case:** It is rarely used in initial design but is useful for versioning—if a 3rd party base class introduces a new method that clashes with an existing method in your derived class, you can use `new` to safely hide theirs without breaking your existing consumers.

<a id="q-1-21"></a>
> #### 1.21 Difference between method hiding and method overriding

This is a classic interview question testing your understanding of early vs. late binding.

**Interview Ready Answer:**

| Feature | Method Overriding (`override`) | Method Hiding (`new`) |
|---|---|---|
| **Polymorphic Link** | Maintains the link. Modifies the vtable. | Severs the link. Creates a distinct method. |
| **Execution Depends On**| The **Actual Object Instance** (Late Binding). | The **Variable Reference Type** (Early Binding). |
| **Base Class Keyword** | Base method must be `virtual` or `abstract`. | Base method can be anything (virtual or regular). |
| **Scenario Example** | Base variable pointing to Derived object calls **Derived** method. | Base variable pointing to Derived object calls **Base** method. |

<a id="q-1-22"></a>
> #### 1.22 Purpose of the `new` keyword in method hiding

The `new` keyword in a method signature explicitly instructs the compiler to hide the inherited member from the base class.

**Interview Ready Answer:**
- **Suppressing Warnings:** If you omit `new`, the compiler issues a warning: `"member hides inherited member; use the new keyword if hiding was intended"`. Using `new` explicitly documents your intent to silence this warning.
- **Backwards Compatibility:** It's an escape hatch. If a framework update adds a `virtual void Process()` to a base class, and you already had a `void Process()` in your derived class, your code would break if C# defaulted to overriding. By defaulting to hiding (and requiring `new` to suppress the warning), C# prevents the "Brittle Base Class" problem.

<a id="q-1-23"></a>
> #### 1.23 What is the difference between `virtual`, `override`, and `abstract`?

These keywords dictate how and if a method participates in inheritance and polymorphism.

**Interview Ready Answer:**

| Keyword | Placement | Meaning & Enforcement |
|---|---|---|
| **`virtual`** | Base Class | **Optional behavior modification.** Provides a default implementation. Derived classes *may* override it, but they don't have to. |
| **`abstract`** | Base Class | **Mandatory behavior modification.** Provides no implementation (no method body). Derived classes *must* override it. (Can only be used in an `abstract` class). |
| **`override`**| Derived Class | **The specific implementation.** Used to replace the behavior of an inherited `virtual` or `abstract` member. |

<a id="q-1-24"></a>
> #### 1.24 Difference between `virtual`, `override`, and `new`

While `virtual` and `override` work together to create polymorphism, `new` actively breaks it.

**Interview Ready Answer:**
- **`virtual`**: Signals that a method *can* be overridden. (Creates a slot in the vtable).
- **`override`**: Signals that a method *is* overriding a base `virtual` method. (Replaces the pointer in the vtable).
- **`new`**: Signals that a method *happens to share the same name* as a base method, but is completely unrelated polymorphically. (Creates a new, separate slot).

**Example:**
```csharp
Animal myDog = new Dog(); // Base reference, Derived instance

// Assuming SpeakVirtual is virtual/override
myDog.SpeakVirtual(); // Outputs: "Bark" (override executes)

// Assuming SpeakHidden is new
myDog.SpeakHidden();  // Outputs: "Animal Noise" (base method executes)
```

<a id="q-1-25"></a>
> #### 1.25 What is upcasting vs downcasting?

These terms refer to converting a reference of one class type to another within the same inheritance hierarchy.

**Interview Ready Answer:**
- **Upcasting:** Converting a derived class reference to a base class reference. This is implicitly safe because a derived class **is-a** base class (it contains all the base class's members).
  - Example: `Animal a = new Dog();`
- **Downcasting:** Converting a base class reference back to a derived class reference. This requires an explicit cast because the base reference might not actually point to the requested derived type at runtime.
  - Example: `Dog d = (Dog)a;` (Explicit cast required)

<a id="q-1-26"></a>
> #### 1.26 What happens during invalid downcasting, and why does it fail?

An invalid downcast occurs when you try to cast a base reference to a derived type, but the actual object in memory is *not* of that derived type (or a type inheriting from it).

**Interview Ready Answer:**
- **The Failure:** If you use explicit casting (e.g., `(Dog)myAnimal`), the CLR throws an `InvalidCastException` at runtime.
- **Why it fails:** The CLR type-safety engine checks the object's actual type metadata (the TypeHandle pointer in the object's memory header). If it doesn't match the cast target, it aborts to prevent memory corruption (e.g., calling a `Bark()` method on a memory block representing a `Cat` object).
- **Safe Alternatives:** Use the `is` operator for pattern matching/checking (`if (myAnimal is Dog myDog)`) or the `as` operator which returns `null` instead of throwing an exception (`var dog = myAnimal as Dog;`).

<a id="q-1-27"></a>
> #### 1.27 How does method overriding behave during upcasting and downcasting?

Method overriding (runtime polymorphism) is completely unaffected by the type of the reference variable used to access the object.

**Interview Ready Answer:**
- **Late Binding Supremacy:** Whether you upcast the object to its base type or downcast it back, if you call an overridden `virtual` method, the CLR *always* executes the derived class's implementation.
- **Why?** The actual object allocated in the heap does not change during casting. Casting only changes the *view* (the reference contract) through which the compiler lets you interact with the object. The object's vtable still permanently points to the overridden methods.
- **Method Hiding Caveat:** If the method was defined with `new` (hiding) instead of `override`, then the reference type *does* strictly dictate which method executes.

<a id="q-1-28"></a>
> #### 1.28 What is early binding vs late binding?

Binding is the process of linking a method call to its actual memory address/implementation.

**Interview Ready Answer:**

| Feature | Early Binding (Static Binding) | Late Binding (Dynamic Binding) |
|---|---|---|
| **When it happens** | Compile time. | Runtime. |
| **How it works** | The compiler knows the exact method address based on the variable's declared type. | The CLR looks up the method address in the actual object's vtable at execution time. |
| **Mechanisms** | Normal methods, overloaded methods, static methods. | `virtual` and `override` methods, interface implementations, `dynamic` keyword. |
| **Performance** | Faster (direct memory jump). | Slight overhead (vtable pointer dereference). |

<a id="q-1-29"></a>
> #### 1.29 What is virtual method dispatch?

**Virtual Method Dispatch** is the internal mechanism the CLR uses to implement late binding.

**Interview Ready Answer:**
- **The Concept:** When a call is made to a `virtual` method, the runtime cannot just jump to a hardcoded memory address (like it does for early-bound methods) because the actual implementation depends on the concrete object type.
- **The Execution:** The CLR must dynamically "dispatch" (route) the call to the correct overridden method implementation belonging to the object currently sitting in memory.
- **The Engine:** It achieves this dynamic routing using the **Virtual Method Table (vtable)**.

<a id="q-1-30"></a>
> #### 1.30 What is a virtual method table, and how does the CLR decide which overridden method to execute?

The **Virtual Method Table (vtable)** is an array of function pointers maintained by the CLR for every class that defines or inherits virtual methods.

**Interview Ready Answer:**
- **Object Header:** Every object in the managed heap contains a hidden pointer (the `TypeHandle`) that points to its specific class's `MethodTable`.
- **The Vtable Structure:** Inside the `MethodTable`, the vtable array holds the memory addresses of the actual method implementations for that specific type.
- **The Lookup Process:**
  1. Code executes `baseRef.Speak()`.
  2. The CLR inspects the actual object in memory that `baseRef` points to.
  3. The CLR follows the object's `TypeHandle` to its specific vtable.
  4. The CLR looks up the memory address for `Speak()` in that vtable.
  5. If the class used `override`, the address points to the derived method. If not, it points to the inherited base method. The CLR jumps to that address.

<a id="q-1-31"></a>
> #### 1.31 How does runtime polymorphism work internally?

Runtime polymorphism relies heavily on the CLR's dynamic memory dispatching mechanisms.

**Interview Ready Answer:**
- **The Setup:** When you compile a class containing `virtual` or `override` methods, the compiler emits IL indicating that calls to these methods must use the `callvirt` instruction (late binding) rather than the `call` instruction (early binding).
- **The Memory Map:** The CLR allocates a **MethodTable** for the class. This table contains a **Virtual Method Table (vtable)**, which is an array of memory pointers pointing to the actual executable machine code for each virtual method.
- **The Execution:** When `baseRef.Method()` executes via `callvirt`, the CLR:
  1. Checks if `baseRef` is null (throws `NullReferenceException` if so).
  2. Reads the `TypeHandle` from the actual object in the heap.
  3. Navigates to that specific type's vtable.
  4. Dispatches the call to the memory address found in the exact slot for that method.

<a id="q-1-32"></a>
> #### 1.32 What happens internally during method overriding?

Method overriding is the act of replacing a function pointer in a derived class's vtable.

**Interview Ready Answer:**
- **Inheriting the Vtable:** When a derived class is created, the CLR initially copies the base class's vtable structure into the derived class's MethodTable.
- **Pointer Replacement:** If the derived class defines a method with the `override` keyword, the CLR updates the specific slot in the derived class's vtable. It replaces the memory address pointing to the base method's JIT-compiled code with the memory address pointing to the derived method's JIT-compiled code.
- **The Result:** Any `callvirt` instruction routed through this derived object's vtable will inevitably land on the derived method's memory address, regardless of what reference type the caller is using.

<a id="q-1-33"></a>
> #### 1.33 Can static methods participate in polymorphism? Why can’t they be virtual?

No, static methods **cannot** participate in polymorphism and **cannot** be marked as `virtual`, `abstract`, or `override` (with the exception of static abstract members in interfaces introduced in C# 11).

**Interview Ready Answer:**
- **Object State vs. Type State:** Polymorphism relies on examining an *instance* at runtime to figure out its actual type. Static methods belong to the *type itself*, not to any specific object instance.
- **Early Binding:** Static methods are resolved via early binding at compile-time. The compiler emits a direct `call` instruction to the method's memory address. There is no `vtable` lookup because there is no object instance to inspect.
- **C# 11 Exception:** C# 11 introduced `static abstract` members in interfaces, primarily to support generic math operations. However, this is still resolved statically through generic type parameters, not through traditional object instance polymorphism.

<a id="q-1-34"></a>
> #### 1.34 What are constructors in C#?

A **constructor** is a special method invoked automatically when an instance of a class or struct is created.

**Interview Ready Answer:**
- **Purpose:** Used to initialize the state of an object, inject dependencies, and ensure the object starts its lifecycle in a valid, ready-to-use state.
- **Characteristics:** They have the exact same name as the class and do not have a return type (not even `void`).
- **Default Constructor:** If you don't define any constructor, the C# compiler automatically provides a parameterless default constructor that initializes all fields to their default values (e.g., `null`, `0`, `false`).
- **Trigger:** They are executed by the CLR immediately after memory is allocated on the managed heap (for classes) or stack (for structs).

<a id="q-1-35"></a>
> #### 1.35 Difference between instance constructors and static constructors

They serve entirely different initialization purposes based on the scope (object vs. type).

**Interview Ready Answer:**

| Feature | Instance Constructor | Static Constructor |
|---|---|---|
| **Purpose** | Initializes state for a **specific object instance**. | Initializes state for the **entire type** (static fields). |
| **Execution Trigger**| Called every time `new MyClass()` is invoked. | Called automatically by the CLR exactly **once** per AppDomain, before the first instance is created or any static member is referenced. |
| **Access Modifiers** | Can be `public`, `private`, `protected`, etc. | **Cannot** have access modifiers (always private implicitly). |
| **Parameters** | Can be overloaded and take parameters. | **Cannot** take parameters. |

<a id="q-1-36"></a>
> #### 1.36 What are primary constructors?

Introduced in C# 12 for classes and structs (and C# 9 for records), **Primary Constructors** allow you to declare constructor parameters directly on the class or struct declaration line.

**Interview Ready Answer:**
- **Reduced Boilerplate:** They eliminate the need to manually declare private readonly fields and write a separate constructor body just to assign them.
- **Capture and Scope:** The parameters passed into a primary constructor are captured and available throughout the entire body of the class/struct.
- **Example:**
```csharp
// Modern C# 12 Primary Constructor (ideal for Dependency Injection)
public class UserService(ILogger<UserService> logger, IUserRepository repo) 
{
    public void Execute() 
    {
        // Parameters 'logger' and 'repo' are accessible everywhere here
        logger.LogInformation("Executing...");
    }
}
```

<a id="q-1-37"></a>
> #### 1.37 What is constructor chaining?

**Constructor chaining** is an approach where one constructor calls another constructor within the same class (using `this()`) or in a base class (using `base()`).

**Interview Ready Answer:**
- **DRY Principle:** It prevents code duplication by centralizing initialization logic in a single "master" constructor.
- **Using `this(...)`:** Routes initialization from a simpler constructor to a more complex one within the same class.
- **Using `base(...)`:** Ensures that the parent class is properly initialized before the child class executes its specific initialization logic.

**Example:**
```csharp
public class Connection 
{
    // Calls the overloaded constructor below using 'this'
    public Connection() : this("default_connection_string") { }
    
    // The master constructor where actual logic lives
    public Connection(string connectionString) { /* init logic */ }
}
```

<a id="q-1-38"></a>
> #### 1.38 How do constructors work during inheritance, and what is the execution flow in an inheritance hierarchy?

Constructors are **not inherited**, but they are heavily intertwined in the execution pipeline when creating derived objects.

**Interview Ready Answer:**
- **Top-Down Execution (Base First):** Before a derived class's constructor body executes, it must implicitly or explicitly call a base class constructor. The execution flows from the ultimate base class (`System.Object`) down to the most derived class.
- **The Implicit `base()`:** If you don't explicitly call `base(...)`, the compiler automatically inserts a call to the parameterless constructor of the base class.
- **Failure Condition:** If the base class does not have a parameterless constructor, the derived class constructor will fail to compile unless it explicitly calls `base(arguments)` matching an available base constructor.
- **Field Initialization Order:** Field initializers run *before* the constructor body, starting from the derived class up to the base class, but the actual constructor bodies execute from base class down to derived class.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-2"></a>
## 2. Interface and Abstract Class

<a id="q-2-1"></a>
> #### 2.1 What is an interface?

An **interface** is a purely abstract contract that defines a set of public members (methods, properties, events, indexers) without providing an implementation (prior to C# 8.0 default implementations).

**Interview Ready Answer:**
- **The "Can-Do" Contract:** It defines *capabilities* rather than *identity*. If a class implements `IDisposable`, it promises the runtime it can dispose resources, regardless of whether it's a `FileStream` or a `DbConnection`.
- **Decoupling Mechanism:** It is the primary tool for achieving the **Dependency Inversion Principle (DIP)**. By depending on an interface instead of a concrete class, you decouple the high-level policy from the low-level implementation details.
- **Multiple Inheritance:** C# classes can implement multiple interfaces, allowing a single class to satisfy multiple orthogonal contracts.

<a id="q-2-2"></a>
> #### 2.2 What is an abstract class?

An **abstract class** is a restricted class that cannot be instantiated on its own and is specifically designed to be used as a base class.

**Interview Ready Answer:**
- **The "Is-A" Hierarchy:** It defines core identity and shared behavior for a family of related classes. For example, `AbstractController` or `Stream`.
- **Shared Implementation:** Unlike an interface, an abstract class can contain fully implemented methods, fields, state, and constructors alongside its abstract (unimplemented) methods.
- **Mandatory Overrides:** Methods marked as `abstract` within the class force any non-abstract derived class to provide a specific implementation.

<a id="q-2-3"></a>
> #### 2.3 Difference between interface and abstract class?

This is one of the most common architecture questions, testing your understanding of contract definition vs. base implementation.

**Interview Ready Answer:**

| Feature | Interface | Abstract Class |
|---|---|---|
| **Core Concept** | Defines a **contract/capability** (Can-Do). | Defines a **core identity/base** (Is-A). |
| **State/Fields** | Cannot contain instance fields or state. | Can contain fields, state, and constants. |
| **Constructors** | Cannot have constructors. | Can have constructors (called during derived class instantiation). |
| **Multiple Inheritance** | A class can implement **multiple** interfaces. | A class can inherit from only **one** abstract class. |
| **Access Modifiers** | Members are implicitly `public`. | Can use any access modifier (`protected`, `private`, etc.). |
| **Evolution** | Historically pure abstract (though C# 8+ allows default implementations). | Always allowed a mix of abstract and concrete methods. |

<a id="q-2-4"></a>
> #### 2.4 When would you use interface vs abstract class?

The choice dictates the structural foundation of your architecture.

**Interview Ready Answer:**
- **Use an Interface when:**
  - You need to define a contract for classes that are otherwise unrelated (e.g., `ILogger` can be implemented by `FileLogger` or `CloudLogger`).
  - You need to support multiple inheritance of behavior.
  - You are building services intended for Dependency Injection and mocking in unit tests.
- **Use an Abstract Class when:**
  - You are creating a family of closely related objects sharing core identity (e.g., `BaseRepository`).
  - You need to share common state (fields) or common implementation logic across all derived classes to adhere to the DRY principle.
  - You want to utilize the **Template Method Design Pattern**, where the base class dictates the algorithm skeleton and derived classes fill in specific steps.

<a id="q-2-5"></a>
> #### 2.5 When should you use an abstract class?

**Interview Ready Answer:**
- **Shared State Management:** When derived classes need to share instance variables. For instance, a `DatabaseConnection` abstract class holding the connection string.
- **Template Method Pattern:** When you want to dictate a specific workflow but let child classes provide the details.
```csharp
public abstract class DataProcessor
{
    // The skeleton is locked down
    public void Process() 
    {
        ReadData();
        TransformData(); // Abstract step
        SaveData();
    }
    
    private void ReadData() { /* Shared implementation */ }
    protected abstract void TransformData(); // Must be provided by child
    private void SaveData() { /* Shared implementation */ }
}
```

<a id="q-2-6"></a>
> #### 2.6 Why use interfaces instead of concrete classes?

Depending on concrete classes leads to tight coupling, making systems rigid, fragile, and hard to test.

**Interview Ready Answer:**
- **Dependency Inversion:** Interfaces allow high-level modules to depend on abstractions rather than low-level details.
- **Swappability:** You can swap out a SQL Server implementation for a Redis implementation at runtime (via DI) without changing a single line of the consumer code.
- **Testability:** Concrete classes are notoriously difficult to mock, especially if they hit databases or networks. Interfaces allow you to easily inject mock objects (e.g., using Moq) during unit testing.

<a id="q-2-7"></a>
> #### 2.7 How do interfaces reduce coupling?

Coupling refers to the degree of direct knowledge one component has of another. Interfaces reduce this by acting as a strictly defined buffer between components.

**Interview Ready Answer:**
- **Hiding Implementation:** A class consuming an interface knows nothing about the underlying database, network calls, or internal state of the concrete class implementing it.
- **Contract-Based Programming:** It forces components to communicate via well-defined contracts rather than concrete types. 
- **Replacing Dependencies:** Because the consumer only relies on the interface, you can completely replace the implementing class (e.g., swapping `SqlEmailSender` with `SendGridEmailSender`) without modifying or recompiling the consumer.

<a id="q-2-8"></a>
> #### 2.8 Why depend on abstractions instead of implementations?

This is the core tenet of the **Dependency Inversion Principle (DIP)** (the 'D' in SOLID).

**Interview Ready Answer:**
- **Stability:** Abstractions (interfaces) are inherently stable. They represent a contract that rarely changes. Implementations (concrete classes) are volatile and change frequently due to bug fixes or new requirements.
- **Direction of Dependency:** Without abstractions, high-level business logic depends on low-level database or UI details. By depending on abstractions, you invert this—both high-level policy and low-level details depend on the abstraction.
- **Unit Testing:** You cannot easily inject mock behaviors into concrete classes. Abstractions allow you to perfectly isolate the code under test.

<a id="q-2-9"></a>
> #### 2.9 Can interfaces have implementation?

Historically, no. But starting with **C# 8.0**, yes, through **Default Interface Methods (DIM)**.

**Interview Ready Answer:**
- **Pre-C# 8.0:** Interfaces were purely abstract contracts. No code bodies were allowed.
- **C# 8.0+ Default Implementations:** You can provide a default body for a method inside an interface.
- **Why was this added?** Primarily for **backward compatibility** (API evolution). If you are a framework author and you add a new method to a widely-used interface, it would break all existing implementations. By providing a default implementation, existing classes don't break.
- **Important Nuance:** To call a default interface method, the object reference *must* be cast to the interface type. The method does not automatically appear on the implementing concrete class's public API.

<a id="q-2-10"></a>
> #### 2.10 Can interfaces contain fields or state?

No, interfaces cannot contain instance fields or instance state.

**Interview Ready Answer:**
- **Contract vs State:** Interfaces define *what* an object can do, not *what data it holds*. State management is the responsibility of the implementing class.
- **Properties vs Fields:** While interfaces can declare properties (e.g., `string Name { get; set; }`), these are not fields. They are simply declarations of `get` and `set` methods that the implementing class must provide the backing state for.
- **C# 8.0+ Exceptions:** With default interface methods, interfaces *can* contain static fields or static constants, but still no instance state.

<a id="q-2-11"></a>
> #### 2.11 Can interfaces inherit interfaces?

Yes, an interface can inherit from one or multiple other interfaces.

**Interview Ready Answer:**
- **Contract Aggregation:** When Interface B inherits from Interface A, any class that implements Interface B must fulfill the contracts of both B and A.
- **Interface Segregation Principle (ISP):** This is highly useful for ISP. You can have granular base interfaces (e.g., `IReader`, `IWriter`) and combine them into broader interfaces (e.g., `IReaderWriter : IReader, IWriter`) for specific use cases.
- **Syntax:** `public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> { }`

<a id="q-2-12"></a>
> #### 2.12 What happens if two interfaces have the same method signature?

If a class implements two interfaces that contain the exact same method signature, the class only needs to implement that method once to satisfy both interfaces.

**Interview Ready Answer:**
- **Implicit Implementation:** Providing one `public void Execute()` in the class satisfies the contract for both interfaces simultaneously.
- **The Conflict Problem:** What if the two interfaces expect `Execute()` to do completely different things?
- **The Solution (Explicit Interface Implementation):** You can provide a different method body for each interface by explicitly naming them.
  - Syntax: `void IInterfaceA.Execute() { ... }` and `void IInterfaceB.Execute() { ... }`
  - **Note:** Explicitly implemented methods are automatically `private` to the class and can only be called by casting the object to the specific interface first.

<a id="q-2-13"></a>
> #### 2.13 What is explicit interface implementation?

**Explicit interface implementation** is a way to implement an interface method such that it is only accessible when the object is explicitly cast to the specific interface type.

**Interview Ready Answer:**
- **Syntax:** You omit the access modifier and prefix the method name with the interface name (e.g., `void ILogger.Log() { }`).
- **Resolving Naming Collisions:** It is primarily used when a class implements two interfaces that have the exact same method signature, but require fundamentally different behaviors.
- **Hiding API Surface:** It can be used to hide methods from the class's default public API. This is common in the .NET framework (e.g., `List<T>` explicitly implements many internal methods from `ICollection<T>` so they don't clutter the `List<T>` public intellisense).

<a id="q-2-14"></a>
> #### 2.14 Can abstract methods exist in non-abstract classes?

No, abstract methods **cannot** exist in a non-abstract (concrete) class.

**Interview Ready Answer:**
- **Compiler Error:** If you try to declare an `abstract` method inside a regular class, the C# compiler throws an error.
- **Why?** An abstract method has no implementation (no body). If a concrete class contained an abstract method, you could instantiate the class and try to call a method that has no executable code, which would crash the runtime. Therefore, any class containing even one abstract method must be marked as `abstract` to physically prevent instantiation.

<a id="q-2-15"></a>
> #### 2.15 Can abstract classes have constructors?

Yes, abstract classes can and frequently do have constructors.

**Interview Ready Answer:**
- **Cannot be Instantiated Directly:** Even though they have constructors, you cannot execute `new MyAbstractClass()`.
- **Purpose of the Constructor:** The constructor exists to initialize the state (fields/properties) defined within the abstract class itself.
- **Execution Flow:** It is called implicitly (or explicitly via `base(...)`) by the constructor of the derived class during instantiation.
- **Access Modifiers:** They are typically marked as `protected` because there is no reason for them to be `public` (since external code cannot instantiate the class anyway).

<a id="q-2-16"></a>
> #### 2.16 Can abstract classes contain fields or state?

Yes, unlike interfaces (prior to C# 8 static fields), abstract classes can contain instance fields and manage state.

**Interview Ready Answer:**
- **Shared State:** This is one of the primary reasons to choose an abstract class over an interface. It allows you to define and manage state that is common to all derived classes in one central place.
- **Encapsulation:** You can define `private` fields in the abstract class and expose them via `protected` properties or methods to derived classes, ensuring state integrity across the hierarchy.

<a id="q-2-17"></a>
> #### 2.17 Can abstract classes implement interfaces?

Yes, an abstract class can implement one or more interfaces.

**Interview Ready Answer:**
- **Two Approaches to Implementation:**
  1. **Concrete Implementation:** The abstract class provides the actual method body for the interface method. All derived classes automatically inherit this implementation.
  2. **Abstract Implementation:** The abstract class can map the interface method to an `abstract` method. This explicitly forces the derived classes to provide the actual implementation.
- **Example:**
```csharp
public interface ILogger { void Log(); }

public abstract class BaseService : ILogger
{
    // Forcing derived classes to implement the interface contract
    public abstract void Log(); 
}
```

<a id="q-2-18"></a>
> #### 2.18 Difference between abstract method and virtual method?

Both methods enable polymorphism, but they dictate different requirements for the derived class.

**Interview Ready Answer:**

| Feature | Abstract Method | Virtual Method |
|---|---|---|
| **Implementation** | Has **no body** (no implementation) in the base class. | Has a **default body** (implementation) in the base class. |
| **Override Requirement**| Derived class **MUST** override it (unless the derived class is also abstract). | Derived class **MAY** override it, but it's optional. |
| **Location** | Can only exist inside an **abstract class**. | Can exist in abstract or concrete classes. |
| **Use Case** | Use when the base class cannot possibly provide a sensible default behavior. | Use when there is a sensible default behavior, but child classes might need to specialize it. |

<a id="q-2-19"></a>
> #### 2.19 Why does C# support multiple inheritance only through interfaces?

C# restricts multiple inheritance of *classes* to avoid the architectural complexity and ambiguity known as the "Diamond Problem".

**Interview Ready Answer:**
- **The Ambiguity:** If a class could inherit from two base classes that both provide an implementation for the exact same method (e.g., `Log()`), the runtime would not know which implementation to execute.
- **Interfaces Solve This:** Because interfaces (traditionally) only define contracts and provide no implementation, there is no ambiguity. The implementing class simply provides a single concrete implementation that satisfies the contract for all inherited interfaces.

<a id="q-2-20"></a>
> #### 2.20 What is the diamond problem, and how does C# handle it with interfaces and abstract classes?

The **Diamond Problem** is an ambiguity that arises in multiple inheritance systems (like C++) when two classes (B and C) inherit from A, and class D inherits from both B and C. If A has a method that both B and C override, which version does D inherit?

**Interview Ready Answer:**
- **C# Prevention:** C# completely prevents this at the class level by strictly enforcing single class inheritance (a class can only have one base class).
- **Interface Diamond:** If an interface `ID` inherits from `IB` and `IC`, and both inherit from `IA` (which has method `DoWork()`), there is no conflict. The concrete class implementing `ID` just provides one implementation of `DoWork()`.
- **C# 8.0 Default Interface Methods:** C# 8 introduced default implementations, which technically reintroduces the diamond problem. If `IB` and `IC` provide different default implementations of `IA.DoWork()`, the compiler will force the concrete class `D` to explicitly provide its own implementation to resolve the ambiguity.

<a id="q-2-21"></a>
> #### 2.21 Why not use interfaces everywhere?

While interfaces provide excellent decoupling, using them exclusively leads to code duplication.

**Interview Ready Answer:**
- **No Shared State/Logic:** Interfaces cannot hold state or share implementation details. If you have 10 classes implementing `IRepository`, and 9 of them use the exact same logic for opening a SQL connection, you will have to copy-paste that logic 9 times.
- **Header Interfaces Anti-pattern:** Creating a 1-to-1 interface for every single class (e.g., `IUserService` and `UserService`) purely for the sake of having an interface is over-engineering. It clutters the codebase if multiple implementations or test mocking aren't actually needed.

<a id="q-2-22"></a>
> #### 2.22 Why not use abstract classes everywhere?

Overusing abstract classes leads to fragile, rigid type hierarchies.

**Interview Ready Answer:**
- **The Single Inheritance Bottleneck:** Because a class can only inherit from one base class, using up that single slot on an abstract class is expensive. If a class later needs to inherit behavior from a different system, it cannot.
- **Tight Coupling:** Inheritance is the strongest form of coupling. Changes in the base abstract class ripple down and can easily break derived classes.
- **Mocking Difficulty:** While you can mock abstract methods, you cannot easily mock the concrete methods inside an abstract class without invoking their actual logic, making unit testing harder compared to pure interfaces.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-3"></a>
## 3. SOLID Principles and Architecture

<a id="q-3-1"></a>
> #### 3.1 Explain SOLID principles.

**SOLID** is an acronym for five design principles intended to make software designs more understandable, flexible, and maintainable.

**Interview Ready Answer:**
- **S - Single Responsibility Principle (SRP):** A class should have one, and only one, reason to change.
- **O - Open/Closed Principle (OCP):** Software entities should be open for extension but closed for modification.
- **L - Liskov Substitution Principle (LSP):** Subtypes must be substitutable for their base types without altering the correctness of the program.
- **I - Interface Segregation Principle (ISP):** Clients should not be forced to depend on methods they do not use (prefer small, focused interfaces).
- **D - Dependency Inversion Principle (DIP):** High-level modules should not depend on low-level modules; both should depend on abstractions.

<a id="q-3-2"></a>
> #### 3.2 What do you mean by coupling and cohesion?

These are metrics used to evaluate software architecture quality. The goal is always **High Cohesion and Low Coupling**.

**Interview Ready Answer:**
- **Cohesion (Internal Focus):** Measures how closely related the responsibilities of a single class/module are.
  - *High Cohesion:* A `UserRepository` that only handles saving/retrieving users from the database.
  - *Low Cohesion:* A `Utility` class that handles database access, string formatting, and sending emails.
- **Coupling (External Focus):** Measures the degree of interdependence between different software modules.
  - *Low (Loose) Coupling:* Components communicate via interfaces. Changes in one don't break the other.
  - *High (Tight) Coupling:* Class A instantiates concrete Class B directly (`new B()`). If Class B's constructor changes, Class A breaks.

<a id="q-3-3"></a>
> #### 3.3 Explain Single Responsibility Principle.

**SRP** states that a class should have only one reason to change, meaning it should have only one primary responsibility or job.

**Interview Ready Answer:**
- **The "Reason to Change" Metric:** If a change in the database schema *and* a change in the email formatting both require modifying the same `UserService` class, SRP is violated.
- **The Fix:** Split the class into smaller, focused classes (e.g., `UserRepository` for DB access, `EmailService` for formatting/sending), and orchestrate them from the `UserService`.
- **Benefit:** Reduces merge conflicts, makes classes easier to unit test, and heavily improves readability.

<a id="q-3-4"></a>
> #### 3.4 Explain Open Closed Principle.

**OCP** states that a system should be **open for extension** (you can add new behavior) but **closed for modification** (you shouldn't have to touch existing, tested code).

**Interview Ready Answer:**
- **The Violation:** A large `switch` statement or `if/else` chain that checks an `enum` (e.g., `PaymentType`) and executes different logic. Every time a new payment type is added, you must modify this existing method.
- **The Fix:** Use Polymorphism. Define an `IPaymentProcessor` interface. Create new classes (`StripeProcessor`, `PaypalProcessor`) that implement the interface. The caller simply relies on the interface and a factory/DI container to execute the right one.
- **Benefit:** You add features by writing *new* code, leaving existing, working code completely untouched and safe from regressions.

<a id="q-3-5"></a>
> #### 3.5 Explain Liskov Substitution Principle.

**LSP** states that objects of a superclass should be replaceable with objects of its subclasses without breaking the application.

**Interview Ready Answer:**
- **The Violation:** If `class Ostrich : Bird`, and `Bird` has a `virtual void Fly()` method. Because an ostrich cannot fly, you throw a `NotImplementedException()` in the override. This violates LSP because the consumer expecting a `Bird` will crash when given an `Ostrich`.
- **The "Is-A" Fallacy:** Just because something is conceptually an "Is-A" relationship in the real world doesn't mean it models well in code. 
- **The Fix:** Break the hierarchy down by capabilities. Create `IFlyingBird` and `INonFlyingBird`. Or, rethink the abstraction entirely. Don't force derived classes to throw exceptions for inherited methods.

<a id="q-3-6"></a>
> #### 3.6 Explain Interface Segregation Principle.

**ISP** states that no client should be forced to depend on methods it does not use. Large, "fat" interfaces should be split into smaller, more specific ones.

**Interview Ready Answer:**
- **The Violation:** An `IRepository<T>` that contains `Add()`, `Update()`, `Delete()`, and `GetAll()`. If a specific service only needs to read data, passing it this interface exposes methods it shouldn't touch, violating the Principle of Least Privilege.
- **The Fix:** Split into `IReadRepository<T>` and `IWriteRepository<T>`. A read-only service injects only the read interface.
- **Benefit:** Keeps the API surface small, reducing the likelihood that a change to an unused method signature breaks consuming code.

<a id="q-3-7"></a>
> #### 3.7 Explain Dependency Inversion Principle.

**DIP** states that high-level modules (business logic) should not depend on low-level modules (database, network). Both should depend on abstractions (interfaces).

**Interview Ready Answer:**
- **The Violation:** `OrderService` (High Level) instantiates `new SqlOrderRepository()` (Low Level) directly inside its methods.
- **The Fix:** `OrderService` should accept an `IOrderRepository` interface via its constructor. The `SqlOrderRepository` implements this interface.
- **Inversion of Control:** The control of *which* concrete repository to use is taken away from the `OrderService` and given to the composition root (the Dependency Injection container in `Program.cs`).
- **Benefit:** Total decoupling. You can test `OrderService` by passing in a mock repository.

<a id="q-3-8"></a>
> #### 3.8 What is the difference between SRP and ISP?

Both principles deal with keeping things small and focused, but they apply to different aspects of class design.

**Interview Ready Answer:**

| Feature | Single Responsibility Principle (SRP) | Interface Segregation Principle (ISP) |
|---|---|---|
| **Focus** | Focuses on the **Implementation** (the Class). | Focuses on the **Abstraction** (the Interface). |
| **Goal** | A class should have only one reason to change. | A client shouldn't be forced to depend on methods it doesn't use. |
| **Violation Sign** | A class has thousands of lines of code and changes frequently. | A class implements an interface but throws `NotImplementedException` for half the methods. |

<a id="q-3-9"></a>
> #### 3.9 Which SOLID principle is behavioral?

The **Liskov Substitution Principle (LSP)** is strictly a behavioral principle.

**Interview Ready Answer:**
- **Why?** The other four principles (SRP, OCP, ISP, DIP) are structural—they guide how you organize files, interfaces, and dependencies. LSP dictates how objects must *behave* at runtime. 
- **The Core Rule:** A derived class cannot change the expected behavior (the invariants or post-conditions) of the base class. If a method in the base class guarantees it will never return null, the overridden method in the child class must also never return null.

<a id="q-3-10"></a>
> #### 3.10 What are the practical benefits of implementing DIP?

**Interview Ready Answer:**
- **Testability:** By injecting interfaces instead of instantiating concrete classes, you can effortlessly pass mock or stub objects into your services during unit testing.
- **Swappability:** You can change entire underlying technologies (e.g., migrating from SQL Server to PostgreSQL) without touching your core business logic, because the business logic only depends on the `IRepository` abstraction.
- **Parallel Development:** Frontend and Backend developers can agree on an interface contract. Once defined, the frontend can develop against mock data using the interface, while the backend implements the concrete class simultaneously.

<a id="q-3-11"></a>
> #### 3.11 Why prefer composition over inheritance?

This is a core architectural guideline promoting loose coupling.

**Interview Ready Answer:**
- **The Problem with Inheritance:** It creates a rigid, deeply coupled "Is-A" hierarchy. Base class changes risk breaking all derived classes (the Fragile Base Class problem). You are also limited to single class inheritance in C#.
- **The Power of Composition:** It creates a flexible "Has-A" relationship. Instead of a `Car` inheriting from `Engine`, a `Car` *has an* `IEngine` injected into it. 
- **Dynamic Behavior:** With composition, you can swap out the behavior at runtime (e.g., swapping a `GasEngine` for an `ElectricEngine` via dependency injection). With inheritance, the behavior is locked in at compile time.

<a id="q-3-12"></a>
> #### 3.12 How do interfaces improve maintainability?

**Interview Ready Answer:**
- **Isolation of Changes:** When you code against an interface, changes to the underlying concrete class implementation do not ripple up to the consuming class, preventing cascading bugs.
- **Self-Documenting Code:** An interface acts as a clean, concise summary of what a component can do, stripped of all internal noise and logic, making it easier for new developers to understand the system boundaries.

<a id="q-3-13"></a>
> #### 3.13 How do abstractions improve scalability?

**Interview Ready Answer:**
- **Plugin Architecture:** Abstractions allow you to scale the *features* of an application without scaling the *complexity* of existing code. You scale by adding new implementations of an interface rather than adding massive `if/else` blocks to existing services (OCP).
- **System Scaling:** If a monolithic service relies on an abstraction (e.g., `IMessageQueue`), you can easily swap out the in-memory queue implementation for an Azure Service Bus implementation when traffic demands it, allowing the system to scale horizontally.

<a id="q-3-14"></a>
> #### 3.14 What is layered architecture, and how do you make it decoupled?

Layered (or N-Tier) architecture separates an application into logical tiers, typically Presentation, Business Logic (Application), and Data Access (Infrastructure).

**Interview Ready Answer:**
- **Traditional (Coupled) Layering:** UI depends on Business, Business depends on Data Access. This violates DIP because Business logic depends on a lower-level concrete implementation.
- **Decoupled Layering (Clean Architecture):** You make it decoupled by placing Interfaces in the Business Logic layer. The Data Access layer implements those interfaces. The dependency arrow points *inward*. The Business layer knows nothing about the Data Access layer.

<a id="q-3-15"></a>
> #### 3.15 What is the responsibility of each layer in a layered architecture?

**Interview Ready Answer:**
- **Presentation Layer (API / UI):** Handles HTTP requests, routing, input validation (DTOs), and returning HTTP responses. It contains *no business rules*.
- **Application/Business Layer:** The heart of the system. Contains business rules, domain entities, use cases, and validation logic. It dictates *what* the system does.
- **Infrastructure/Data Layer:** Handles external concerns. Contains Entity Framework DbContexts, database migrations, third-party API clients, and file system access. It dictates *how* the system communicates with the outside world.

<a id="q-3-16"></a>
> #### 3.16 What is cyclic dependency, and how do you break it?

A **cyclic dependency** occurs when Project A depends on Project B, and Project B depends on Project A, creating an infinite loop that the compiler cannot resolve.

**Interview Ready Answer:**
- **The Problem:** It usually indicates a flaw in the architectural design where responsibilities are blurred.
- **How to Break It (Refactoring):** Extract the common classes that both projects need into a brand new, third project (Project C). Have both A and B reference C.
- **How to Break It (DIP):** Introduce an interface in Project A. Have Project B implement that interface. Now A only depends on its own interface, and B depends on A (to get the interface).

<a id="q-3-17"></a>
> #### 3.17 How would you isolate provider-specific behavior?

**Interview Ready Answer:**
- **The Facade / Adapter Pattern:** Never let provider-specific SDKs (like AWS S3 or Stripe) bleed into your business logic. 
- **Implementation:** Define your own interface modeling the exact behavior your business needs (e.g., `IStorageService`). 
- **Wrapping:** Create an implementation class (e.g., `AwsStorageService`) that wraps the 3rd party SDK. Your application injects `IStorageService`, completely isolating the provider.

<a id="q-3-18"></a>
> #### 3.18 Give real-world examples of SOLID.

**Interview Ready Answer:**
- **SRP:** Splitting an `OrderProcessor` that validates, saves, and emails, into `OrderValidator`, `OrderRepository`, and `EmailSender`.
- **OCP:** Using `IEnumerable<IDiscountStrategy>` to calculate shopping cart discounts. To add a "Black Friday" discount, you just write a new class; you don't touch the cart calculator.
- **LSP:** Ensuring that a `ReadOnlyFileStream` doesn't throw a `NotSupportedException` when a base `Stream` method like `Write()` is called by a consumer. (Better to separate `IReader` and `IWriter`).
- **ISP:** Instead of a massive `IUserInterface` with 50 methods, having `IUserReader`, `IUserWriter`, and `IUserAuthenticator`.
- **DIP:** An ASP.NET Controller injecting `IUserService` via its constructor instead of `new UserService()`.

<a id="q-3-19"></a>
> #### 3.19 How did you apply SOLID in your project?

*(Note: This is subjective. Here is a strong, senior-level template answer.)*

**Interview Ready Answer:**
- "In my recent backend project, I heavily relied on **DIP** and **SRP**. We had a monolithic service handling payments. I applied **SRP** by splitting the validation, gateway communication, and database logging into separate classes."
- "I used **OCP** by introducing an `IPaymentGateway` interface. When the business asked to integrate PayPal alongside Stripe, I didn't have to modify the core payment engine. I simply added a `PayPalGateway` class and registered it in the DI container."

**[⬆ Back to Top](#table-of-contents)**

<a id="section-4"></a>
## 4. Design Patterns

> Important for enterprise-style interviews.

<a id="q-4-1"></a>
> #### 4.1 What are design patterns?

**Design Patterns** are typical, repeatable solutions to commonly occurring problems in software design.

**Interview Ready Answer:**
- **Not Code, but Blueprints:** They are not specific pieces of code or libraries you can copy-paste. They are conceptual templates or descriptions for how to solve a problem that can be used in many different situations.
- **Categorization:** They are generally divided into three main groups (The Gang of Four patterns):
  - **Creational:** Deal with object creation mechanisms (e.g., Singleton, Factory, Builder).
  - **Structural:** Deal with object composition and relationships (e.g., Adapter, Decorator, Facade).
  - **Behavioral:** Deal with communication and assignment of responsibilities between objects (e.g., Strategy, Observer, Command).

<a id="q-4-2"></a>
> #### 4.2 Difference between design pattern and architecture pattern?

**Interview Ready Answer:**

| Feature | Design Pattern | Architecture Pattern |
|---|---|---|
| **Scope** | Micro-level. Solves localized, specific class/object design problems. | Macro-level. Defines the structural layout of the entire application or subsystem. |
| **Examples** | Singleton, Strategy, Factory, Repository. | Microservices, MVC, Clean Architecture, Event-Driven. |
| **Impact** | Affects a single module or feature. | Affects the entire system and dictates how major components communicate. |

<a id="q-4-3"></a>
> #### 4.3 Which design patterns are commonly used in .NET applications?

**Interview Ready Answer:**
- **Dependency Injection (DI):** Baked directly into the core of .NET Core / .NET 5+ (`Microsoft.Extensions.DependencyInjection`).
- **Repository & Unit of Work:** Extensively used with Entity Framework Core to abstract database access.
- **Options Pattern:** A uniquely .NET pattern used to bind strongly-typed classes to configuration settings (`appsettings.json`).
- **Singleton / Scoped / Transient:** While DI manages the lifetimes, the concepts are rooted in Creational patterns.
- **Builder Pattern:** Used extensively in .NET configuration (e.g., `Host.CreateDefaultBuilder()`, `WebApplication.CreateBuilder()`).

<a id="q-4-4"></a>
> #### 4.4 What design patterns have you used in your projects?

*(Note: Subjective answer to tailor to your experience. Here is a senior-level template.)*

**Interview Ready Answer:**
- "I primarily use **Dependency Injection** everywhere to adhere to SOLID principles."
- "I implemented the **Repository Pattern** to abstract EF Core so I could easily write unit tests for my business logic using mock data."
- "I used the **Strategy Pattern** for a payment processing module, allowing the system to seamlessly switch between Stripe and PayPal processors at runtime based on user selection."
- "I used the **Decorator Pattern** to add caching and logging to existing services without modifying their core logic."

<a id="q-4-5"></a>
> #### 4.5 What is Inversion of Control?

**Inversion of Control (IoC)** is a broad architectural principle where the control flow of a program is inverted compared to traditional procedural programming.

**Interview Ready Answer:**
- **Traditional Flow:** Your custom code is in charge. It instantiates objects (`new MyDbConnection()`) and calls functions in external libraries to do work.
- **Inverted Flow (IoC):** A framework or container is in charge. You register your custom code with the framework, and the framework calls *your* code when necessary.
- **The "Hollywood Principle":** "Don't call us, we'll call you."
- **Forms of IoC:** Events, Callbacks, Delegates, and most famously, Dependency Injection.

<a id="q-4-6"></a>
> #### 4.6 What is Dependency Injection pattern?

**Dependency Injection (DI)** is a specific design pattern used to implement Inversion of Control (IoC), specifically regarding how objects obtain their dependencies.

**Interview Ready Answer:**
- **The Core Concept:** Instead of an object creating its own dependencies (using the `new` keyword), those dependencies are created elsewhere (by an IoC Container) and "injected" into the object, usually via its constructor.
- **Constructor Injection:** The most common form. `public OrderService(IOrderRepository repo)` - The class demands its dependencies upfront.
- **Why it matters:** It forces loose coupling (DIP), makes the application highly modular, and allows for trivial unit testing by injecting mocked dependencies.

<a id="q-4-7"></a>
> #### 4.7 How does dependency injection relate to IoC?

DI is a specific technique used to achieve IoC.

**Interview Ready Answer:**
- **The Relationship:** IoC is the broad principle (the "what"), and DI is the specific design pattern (the "how").
- **Analogy:** IoC is like saying "I need a car to get to work." DI is like saying "Uber is the specific service I will use to get that car delivered to me."

<a id="q-4-8"></a>
> #### 4.8 What is Singleton pattern?

The **Singleton Pattern** is a creational design pattern that ensures a class has only one single instance globally and provides a global point of access to that instance.

**Interview Ready Answer:**
- **The Core Rules:**
  1. The class must have a `private` constructor to prevent external instantiation.
  2. The class must hold a `private static` reference to its single instance.
  3. The class must provide a `public static` method or property (e.g., `Instance`) to access that reference.

<a id="q-4-9"></a>
> #### 4.9 Where would you use Singleton?

**Interview Ready Answer:**
- **Shared Resources:** Managing access to a shared resource where multiple instances would cause conflicts or unnecessary overhead (e.g., a connection pool, a hardware interface wrapper).
- **Global State / Configuration:** Storing application-wide settings that are loaded once at startup and read frequently throughout the application's lifecycle.
- **Caching:** An in-memory cache mechanism where all parts of the application need to read/write to the exact same cache dictionary.

<a id="q-4-10"></a>
> #### 4.10 Problems with Singleton?

The classic static Singleton is often considered an anti-pattern in modern C# development.

**Interview Ready Answer:**
- **Hidden Dependencies:** It acts as a global variable. A class consuming a Singleton doesn't declare it in its constructor, making it hard to see what the class actually depends on.
- **Testing Nightmare:** Because it's static and global, it carries state across unit tests. It is extremely difficult to mock a static Singleton for isolated testing.
- **Concurrency Issues:** If not implemented perfectly, it can cause race conditions in multithreaded environments.
- **The Modern Alternative:** Use Dependency Injection. Register the class as `.AddSingleton<T>()` in the DI container. This gives you the lifecycle benefits of a Singleton while avoiding the static/global structural drawbacks.

<a id="q-4-11"></a>
> #### 4.11 How would you implement a thread-safe Singleton?

In modern C#, you should use the `Lazy<T>` type to implement a thread-safe Singleton effortlessly.

**Interview Ready Answer:**
- **The Old Way (Double-Check Locking):** Historically, developers used a `lock` statement with a double `if (instance == null)` check. It's verbose and easy to get wrong.
- **The Modern Way (`Lazy<T>`):** The .NET `Lazy<T>` class handles all the thread-safety and lazy initialization internally. It guarantees that the factory method passed to it is executed exactly once, even if multiple threads access it simultaneously.

<a id="q-4-12"></a>
> #### 4.12 Write a thread-safe Singleton implementation

**Interview Ready Answer:**
```csharp
public sealed class ConfigurationManager
{
    // 1. Create a static, thread-safe Lazy<T> instance.
    private static readonly Lazy<ConfigurationManager> _lazyInstance = 
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    // 2. Private constructor prevents external instantiation.
    private ConfigurationManager()
    {
        // Expensive initialization logic goes here.
    }

    // 3. Public static property to access the instance.
    public static ConfigurationManager Instance => _lazyInstance.Value;
    
    // Example instance method
    public void LoadSettings() { }
}
```

<a id="q-4-13"></a>
> #### 4.13 What is Factory pattern?

The **Factory Method Pattern** is a creational pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

**Interview Ready Answer:**
- **The Problem:** Using `new` directly ties your code to a specific concrete class, violating the Open/Closed Principle if you later need to instantiate different types based on logic.
- **The Solution:** You replace direct object construction calls with calls to a special "factory" method. 
- **Use Case:** When the exact types and dependencies of the objects you need to create are not known until runtime. For example, a `DocumentCreator` factory that returns either a `PdfDocument` or a `WordDocument` depending on the file extension the user uploaded.

<a id="q-4-14"></a>
> #### 4.14 Difference between Factory and Abstract Factory?

**Interview Ready Answer:**

| Feature | Factory Method | Abstract Factory |
|---|---|---|
| **Purpose** | Creates **one** specific type of object (e.g., a Document). | Creates **families** of related or dependent objects (e.g., MacUI vs WindowsUI). |
| **Complexity** | Simple. Usually just one method (`CreateProduct()`). | Complex. Contains multiple factory methods (`CreateButton()`, `CreateCheckbox()`). |
| **Level of Abstraction** | Uses inheritance and relies on derived classes to implement the factory method. | Uses composition. It is an object that contains multiple factory methods. |

<a id="q-4-15"></a>
> #### 4.15 What is Builder pattern?

The **Builder Pattern** is a creational design pattern that lets you construct complex objects step by step.

**Interview Ready Answer:**
- **The Problem:** The "Telescoping Constructor" anti-pattern. You have a class with a constructor that takes 15 parameters, 10 of which are optional, leading to extremely ugly and error-prone instantiation code.
- **The Solution:** You extract the object construction code out of its own class and move it to separate objects called builders.
- **Fluent Interface:** Often implemented via method chaining (e.g., `.SetWheels(4).SetColor("Red").Build()`), which drastically improves readability.
- **.NET Example:** The generic Host Builder (`Host.CreateDefaultBuilder(args).ConfigureServices(...).Build()`) is a classic example.

<a id="q-4-16"></a>
> #### 4.16 What is Strategy pattern?

The **Strategy Pattern** is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable at runtime.

**Interview Ready Answer:**
- **The Problem:** You have a massive class with multiple `if/else` or `switch` statements that alter the behavior of a method based on a flag (e.g., calculating shipping costs for Standard, Express, or Overnight).
- **The Solution:** Extract each shipping calculation algorithm into its own class that implements a common `IShippingStrategy` interface. The main class (the Context) holds a reference to the interface and delegates the work to it.
- **Benefits:** Adheres perfectly to the Open/Closed Principle. Adding a new "Drone Delivery" strategy requires zero changes to the main context class.

<a id="q-4-17"></a>
> #### 4.17 Real-world example of Strategy pattern?

**Interview Ready Answer:**
- **Scenario:** A payment processing system in an e-commerce application.
- **The Interface:** `IPaymentStrategy` with a method `bool ProcessPayment(decimal amount)`.
- **The Concrete Strategies:** `CreditCardStrategy`, `PayPalStrategy`, `CryptoStrategy`.
- **The Context:** The `CheckoutService` receives the selected `IPaymentStrategy` via dependency injection (or a factory) and simply calls `ProcessPayment()`. The `CheckoutService` doesn't care *how* the payment is processed, only that it is.

<a id="q-4-18"></a>
> #### 4.18 What is Observer pattern?

The **Observer Pattern** is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

**Interview Ready Answer:**
- **The Core Components:**
  - **Subject (Publisher):** The object holding the state. It maintains a list of observers.
  - **Observer (Subscriber):** The objects that want to be notified when the Subject's state changes.
- **How it works:** When the Subject changes state, it iterates through its list of registered Observers and calls a specific notification method on them (e.g., `Update()`).
- **.NET Implementation:** While you can build this manually, C# has this pattern fundamentally baked into the language via **Events and Delegates**, and more formally through the `IObservable<T>` and `IObserver<T>` interfaces (often used with Reactive Extensions / Rx.NET).

<a id="q-4-19"></a>
> #### 4.19 What is Adapter pattern?

The **Adapter Pattern** is a structural design pattern that allows objects with incompatible interfaces to collaborate.

**Interview Ready Answer:**
- **The Core Concept:** It acts as a wrapper. It catches calls for one interface and translates them into format and interface recognized by the second object.
- **The Analogy:** Like a travel power adapter. You have a US plug (the Client) and a UK socket (the Service). They are incompatible. The Adapter sits in the middle and translates the interface.
- **Real-World .NET Use Case:** You have a modern `ILogger` interface in your domain, but you are forced to use an older, 3rd-party logging library with a `LogManager` class that has totally different method names. You create a `ThirdPartyLoggerAdapter` that implements `ILogger` and maps the calls internally to the `LogManager`.

<a id="q-4-20"></a>
> #### 4.20 What is Facade pattern?

The **Facade Pattern** is a structural design pattern that provides a simplified, higher-level interface to a complex subsystem of classes, libraries, or frameworks.

**Interview Ready Answer:**
- **The Problem:** Your business logic is heavily coupled to dozens of classes from a 3rd-party video conversion library. The logic is hard to read and brittle.
- **The Solution:** Create a `VideoConverterFacade` class with a single, simple method `ConvertVideo()`. Internally, this facade handles instantiating all the complex subsystems, configuring them, and executing the workflow.
- **Benefits:** It reduces complexity for the client and minimizes dependencies. If the underlying subsystem updates or changes, you only need to update the Facade class, not your entire application.

<a id="q-4-21"></a>
> #### 4.21 What is Repository pattern?

The **Repository Pattern** acts as an abstraction layer between the Data Access Layer (e.g., Entity Framework) and the Business Logic Layer.

**Interview Ready Answer:**
- **The Concept:** It mediates between the domain and data mapping layers using an interface similar to an in-memory collection (e.g., `Add`, `Remove`, `GetById`).
- **Separation of Concerns:** Business logic shouldn't know about SQL queries, `DbSets`, or database contexts. It should just ask a repository for data.
- **A Note on EF Core:** Entity Framework Core *is* already a repository (`DbSet`) and a Unit of Work (`DbContext`). Creating a generic repository over EF Core is often considered an anti-pattern unless you are adding specific domain logic or strictly abstracting away the EF Core dependency for unit testing.

<a id="q-4-22"></a>
> #### 4.22 Why use Repository pattern?

**Interview Ready Answer:**
- **Testability:** It is the easiest way to mock database access. You can inject an `IUserRepository` into your service and provide a mock implementation that returns static lists of users during unit tests.
- **Centralized Query Logic:** It prevents duplicate LINQ queries scattered across hundreds of controllers or services. You define `GetActiveUsers()` once in the repository.
- **Swappability:** In theory, it allows you to swap out your ORM (e.g., from Dapper to EF Core) without altering any business logic, as the logic only relies on the repository interface.

<a id="q-4-23"></a>
> #### 4.23 What is Unit of Work pattern?

The **Unit of Work Pattern** maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.

**Interview Ready Answer:**
- **The Problem with Multiple Repositories:** If you use an `OrderRepository` to save an order, and an `InventoryRepository` to update stock, they might execute as separate database transactions. If the stock update fails, the order is still saved (data corruption).
- **The Solution:** A `UnitOfWork` class manages a single shared database connection/transaction. Both repositories use this shared context. 
- **The Execution:** You make all your changes in memory, and then call `UnitOfWork.Commit()`, which saves everything to the database in one single atomic transaction.
- **EF Core Implementation:** EF's `DbContext.SaveChanges()` is a textbook implementation of the Unit of Work pattern.

<a id="q-4-24"></a>
> #### 4.24 Difference between Singleton, Factory, and Repository patterns

**Interview Ready Answer:**

| Pattern | Category | Purpose | What it hides |
|---|---|---|---|
| **Singleton** | Creational | Ensures only **one instance** of an object exists globally. | Hides the instance state/lifecycle management. |
| **Factory** | Creational | Centralizes **object creation** logic. | Hides the complex logic of *how* an object is instantiated. |
| **Repository** | Architectural | Abstracts **data access**. | Hides the database, SQL, or ORM details from the domain logic. |

<a id="q-4-25"></a>
> #### 4.25 What is CQRS?

**CQRS (Command Query Responsibility Segregation)** is an architectural pattern that strictly separates the operations that read data (Queries) from the operations that mutate data (Commands).

**Interview Ready Answer:**
- **The Core Rule:** A method should either change state and return nothing (Command), or return data and not change state (Query). Never both.
- **Why use it?** 
  - **Asymmetric Scaling:** In most applications, reads outnumber writes 100 to 1. CQRS allows you to scale the read infrastructure independently from the write infrastructure.
  - **Optimized Models:** The write model can be highly normalized (to enforce business rules and data integrity), while the read model can be heavily denormalized (e.g., flattened views in Elasticsearch or Redis) for lightning-fast queries.
- **Implementation:** Often paired with MediatR in .NET, where `IRequest` represents a Command or Query, and the Handlers execute the isolated logic.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-5"></a>
## 5. Dependency Injection

<a id="q-5-1"></a>
> #### 5.1 What is Inversion of Control?

**Inversion of Control (IoC)** is a design principle where the control flow of a program is inverted: instead of custom code calling into library functions, a framework calls into custom code.

**Interview Ready Answer:**
- **The "Hollywood Principle":** "Don't call us, we'll call you."
- **In .NET:** The ASP.NET Core generic host (the `WebApplicationBuilder`) is the ultimate IoC container. It controls the application lifecycle, instantiates your controllers, and injects the dependencies *you* requested, completely removing the burden of manual object creation from your code.

<a id="q-5-2"></a>
> #### 5.2 What is dependency injection?

**Dependency Injection (DI)** is the implementation of IoC used specifically to manage and provide the required dependencies to an object.

**Interview Ready Answer:**
- **The Core Mechanic:** Instead of a class `OrderService` using the `new` keyword to create an `SqlRepository`, the `OrderService` simply declares that it *needs* an `IRepository` via its constructor. The DI container provides the concrete instance at runtime.
- **Why it’s a standard:** It is a first-class citizen in .NET via the `Microsoft.Extensions.DependencyInjection` namespace, making it the default way to build scalable applications.

<a id="q-5-3"></a>
> #### 5.3 What problems does dependency injection solve?

**Interview Ready Answer:**
- **Tight Coupling:** It breaks the hard-coded link between high-level logic and low-level data access implementations (DIP).
- **Hard to Test Code:** It allows developers to pass lightweight mock objects into services during unit testing without hitting real databases or APIs.
- **Lifecycle Mismanagement:** It centralizes the memory management of objects. Instead of the developer guessing when to dispose of a database connection, the DI container automatically creates and disposes of the connection based on the defined scope.

<a id="q-5-4"></a>
> #### 5.4 What happens if you instantiate concrete implementations directly?

**Interview Ready Answer:**
- **Violation of DIP:** Your code becomes rigidly tied to that specific implementation. If you type `new SqlUserRepository()`, you can never reuse that code with a `MongoUserRepository`.
- **Testing Impossibility:** You cannot mock the dependency. If `OrderService` calls `new EmailSender()`, your unit tests will actually try to send real emails, which is disastrous.
- **Cascade of Changes:** If the constructor of `EmailSender` changes to require a new `SmtpSettings` object, you have to find and modify every single class in your application that called `new EmailSender()`. With DI, you only update the registration in `Program.cs`.

<a id="q-5-5"></a>
> #### 5.5 How is DI implemented in .NET?

.NET provides a built-in, lightweight IoC container.

**Interview Ready Answer:**
- **The Service Collection:** You register your dependencies in `Program.cs` using the `IServiceCollection` (e.g., `builder.Services.AddScoped<IInterface, Implementation>()`).
- **The Service Provider:** Once the app is built, the collection is compiled into an `IServiceProvider`.
- **The Resolution:** When an HTTP request hits a Controller, the framework looks at the Controller's constructor, asks the `IServiceProvider` for instances of the required interfaces, and injects them automatically.

<a id="q-5-6"></a>
> #### 5.6 Explain the three DI service lifetimes: Transient, Scoped, and Singleton.

This is arguably the most critical DI interview question in .NET.

**Interview Ready Answer:**

| Lifetime | Registration | Behavior | Typical Use Case |
|---|---|---|---|
| **Transient** | `AddTransient()` | A new instance is created **every single time** it is requested by the container. | Lightweight, stateless services (e.g., a utility hashing service). |
| **Scoped** | `AddScoped()` | A new instance is created **once per HTTP request**. All classes requesting it during that same HTTP request get the exact same instance. | State tied to the current user request (e.g., `DbContext`, CurrentUser context). |
| **Singleton** | `AddSingleton()` | A single instance is created the first time it is requested (or at startup) and is shared globally for the entire lifetime of the application. | Shared caching, configuration, hardware interfaces, or connection pools. |

<a id="q-5-7"></a>
> #### 5.7 Which lifetime is used for DbContext?

By default, `DbContext` in Entity Framework Core is registered as **Scoped**.

**Interview Ready Answer:**
- **Why Scoped?** A `DbContext` tracks changes to entities in memory and holds an active database connection. If it were `Singleton`, multiple concurrent HTTP requests would try to use the same connection, causing threading exceptions and data corruption.
- **Why not Transient?** If it were `Transient`, a single HTTP request that uses an `OrderRepository` and an `InventoryRepository` would get two different `DbContext` instances. If the order is saved, but the inventory fails, you couldn't roll back the transaction cleanly. `Scoped` ensures the entire HTTP request shares one context, acting as a Unit of Work.

<a id="q-5-8"></a>
> #### 5.8 What problems happen with Singleton misuse?

**Interview Ready Answer:**
- **Memory Leaks:** Because Singletons live forever, any objects they hold references to (like large lists or event subscriptions) will never be garbage collected.
- **Concurrency/Race Conditions:** If a Singleton holds mutable state (like a `Counter` or `Dictionary`), multiple HTTP requests hitting it simultaneously will cause race conditions unless strictly synchronized with `lock` statements.
- **Captive Dependencies:** Injecting a short-lived service into a long-lived Singleton causes the short-lived service to become trapped forever.

<a id="q-5-9"></a>
> #### 5.9 What is captive dependency?

A **Captive Dependency** is a severe architectural bug that occurs when a service with a longer lifetime holds a reference to a service with a shorter lifetime.

**Interview Ready Answer:**
- **The Scenario:** You register a `Singleton` service (e.g., `CacheManager`). In its constructor, you inject a `Scoped` service (e.g., `DbContext`).
- **The Problem:** The `Singleton` is created once. It receives the `DbContext` and holds onto it forever. That specific `DbContext` instance is now "captive". It will never be disposed at the end of the HTTP request.
- **The Consequence:** The database connection remains open forever, and the EF Core change tracker grows infinitely large until the application runs out of memory and crashes.
- **The Fix:** .NET Core has built-in scope validation (`ValidateScopes = true` in development) that will throw an exception at startup if it detects this exact scenario.

<a id="q-5-10"></a>
> #### 5.10 How does DI help in unit testing and mocking?

**Interview Ready Answer:**
- **Isolation:** Unit tests must test a single class in isolation. If your class uses DI, you control exactly what implementations it receives.
- **Mock Frameworks:** Instead of injecting a real `SqlOrderRepository` during testing, you use a framework like **Moq** or **NSubstitute** to create a fake `IOrderRepository`. 
- **Predictability:** You configure the mock object to return exactly what the test needs (e.g., `mockRepo.Setup(x => x.GetId()).Returns(1);`). This ensures the test is evaluating the business logic of the service, not the connectivity of the database.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-6"></a>
## 6. C# Core Concepts

<a id="q-6-1"></a>
> #### 6.1 What is a static class?

A **static class** is a class that cannot be instantiated.

**Interview Ready Answer:**
- **No Objects:** You cannot use the `new` keyword to create a variable of the class type.
- **Access:** You access its members directly via the class name itself (e.g., `Math.Round()`).
- **Contents:** A static class can only contain static members (methods, fields, properties, events). It cannot contain instance members.
- **Sealed by Default:** Internally, the C# compiler marks a static class as `abstract sealed` in IL, ensuring it can neither be instantiated nor inherited.

<a id="q-6-2"></a>
> #### 6.2 When should you use a static class?

**Interview Ready Answer:**
- **Utility / Helper Methods:** When you have a collection of related methods that do not depend on object state (e.g., `System.Math`, `System.Console`).
- **Extension Methods:** Extension methods in C# *must* be defined inside a static class.
- **Global Constants:** Storing application-wide constants that never change.
- **Caution:** Avoid using static classes to hold mutable state (global variables), as this leads to tight coupling, threading issues, and makes unit testing incredibly difficult.

<a id="q-6-3"></a>
> #### 6.3 What are the limitations of static classes?

**Interview Ready Answer:**
- **No Interfaces:** A static class cannot implement an interface. This makes them impossible to use with standard Dependency Injection and mocking frameworks.
- **No Inheritance:** Static classes cannot inherit from any other class (except `System.Object`), and no class can inherit from a static class.
- **No State Isolation:** Any state (static fields) held within a static class is shared across the entire AppDomain. If thread A modifies a static field, thread B instantly sees that modification.

<a id="q-6-4"></a>
> #### 6.4 Difference between static constructor and private constructor

**Interview Ready Answer:**

| Feature | Static Constructor | Private Constructor |
|---|---|---|
| **Purpose** | Initializes **static state** (runs once per type). | Prevents external **instance creation** (used in Singletons or Factory methods). |
| **Trigger** | Called automatically by the CLR right before the first instance is created or the first static member is accessed. | Called explicitly by code *inside* the class using the `new` keyword. |
| **Parameters**| Cannot take parameters. | Can take parameters. |
| **Access Modifier**| Has no access modifiers (implicitly private). | Explicitly marked as `private`. |

<a id="q-6-5"></a>
> #### 6.5 How do static members work internally?

**Interview Ready Answer:**
- **Memory Allocation:** Unlike instance members which are allocated on the heap inside specific object instances, static fields are allocated in a special memory area called the **High-Frequency Heap** (part of the AppDomain's loader heap).
- **Lifetime:** The memory for static fields is allocated when the type is loaded by the CLR and lives until the AppDomain is unloaded (usually when the application shuts down). They are not subject to normal Garbage Collection.
- **Method Dispatch:** The compiler resolves static method calls using early binding (direct memory addresses). There is no vtable lookup required.

<a id="q-6-6"></a>
> #### 6.6 Why does the CLR provide thread safety for static constructors?

**Interview Ready Answer:**
- **The Guarantee:** The CLR guarantees that a static constructor is executed exactly **once** per AppDomain, and it handles the thread-safety locks internally.
- **The Reason:** Static constructors are often used to initialize critical global state (like a Singleton instance or connection strings). If two threads tried to access a static member at the exact same millisecond at startup, without CLR locks, the static constructor would run twice, potentially corrupting global memory or creating duplicate instances.

<a id="q-6-7"></a>
> #### 6.7 Order of execution of static constructors and instance constructors

**Interview Ready Answer:**
- **The Flow:** When you create the *very first* instance of a class:
  1. Base class static fields are initialized.
  2. Derived class static fields are initialized.
  3. Base class static constructor executes.
  4. Derived class static constructor executes.
  5. Base class instance fields are initialized.
  6. Derived class instance fields are initialized.
  7. Base class instance constructor executes.
  8. Derived class instance constructor executes.
- **Subsequent Instances:** Steps 1-4 are skipped entirely. Only steps 5-8 execute.

<a id="q-6-8"></a>
> #### 6.8 What is a sealed class?

A **sealed class** is a class that cannot be inherited by any other class.

**Interview Ready Answer:**
- **The Keyword:** You apply the `sealed` keyword to the class declaration (e.g., `public sealed class Configuration`).
- **Compiler Enforcement:** If any other class attempts to derive from a sealed class (e.g., `public class MyConfig : Configuration`), the C# compiler throws an error.
- **Intrinsic Example:** Many fundamental .NET types, like `System.String`, are sealed to ensure their behavior cannot be altered or broken by derived implementations.

<a id="q-6-9"></a>
> #### 6.9 Why would you seal a class or method?

You seal classes or methods for security, performance, and API design stability.

**Interview Ready Answer:**
- **Security & Predictability:** If a class handles sensitive operations (e.g., cryptography or password hashing), sealing it prevents a malicious or careless developer from extending it and accidentally exposing or overriding secure logic.
- **Performance (Devirtualization):** When the JIT compiler sees a `sealed` class or method, it knows no derived types can override it. It can aggressively inline the method calls, resulting in minor performance gains.
- **Sealing a Method:** You can seal an *overridden* virtual method in a derived class (`public sealed override void DoWork()`). This stops any further classes down the inheritance chain from overriding it again.

<a id="q-6-10"></a>
> #### 6.10 Difference between class, struct, and record

These are the three primary ways to define complex data types in C#.

**Interview Ready Answer:**

| Feature | Class | Struct | Record |
|---|---|---|---|
| **Type** | Reference Type (Heap). | Value Type (Stack/Inline). | Reference Type (usually) or Value Type (`record struct`). |
| **Inheritance** | Supports full inheritance. | No inheritance (except from interfaces). | Supports inheritance (only from other records). |
| **Equality Check** | By default, checks **Reference Equality** (do they point to the exact same memory address?). | Checks **Value Equality** (do all fields match?). | Checks **Value Equality** automatically. |
| **Primary Use Case**| Complex business logic, state mutation, large objects. | Small, lightweight, mathematically focused data holding. | Immutable DTOs, configurations, and data models where value equality is critical. |

<a id="q-6-11"></a>
> #### 6.11 Difference between class and struct

This is a fundamental CLR question testing your knowledge of memory allocation.

**Interview Ready Answer:**
- **Memory Allocation:** Classes are allocated on the **Managed Heap** and are subject to Garbage Collection. Structs are allocated on the **Thread Stack** (or inline within a heap object) and are cleaned up immediately when they go out of scope.
- **Passing by Value/Reference:** When you pass a Class to a method, you pass a *reference pointer* (modifying it alters the original). When you pass a Struct, you pass a *full copy* of the data (modifying it does not affect the original unless you use `ref`).
- **Nullability:** Classes can be `null`. Standard structs cannot be `null` (unless explicitly boxed as `Nullable<T>` / `T?`).

<a id="q-6-12"></a>
> #### 6.12 When should you use a struct instead of a class?

Microsoft provides strict guidelines on when to use a struct. You should only use a struct if it meets **all** of the following criteria:

**Interview Ready Answer:**
1. **Logically represents a single value:** Like primitive types (`int`, `double`) or mathematical concepts (`Point`, `Vector3`, `Color`).
2. **Small Size:** The instance size is under 16 bytes. If it's larger, the cost of copying the struct on every method call outweighs the benefit of avoiding the heap.
3. **Immutable:** It should be completely immutable. Modifying state inside a value type leads to confusing bugs because you are often modifying a *copy*, not the original.
4. **Not Boxed:** It will not have to be boxed frequently (e.g., cast to `object` or an interface), as boxing allocates memory on the heap anyway, defeating the purpose.

<a id="q-6-13"></a>
> #### 6.13 Why are structs value types?

Structs are value types because they directly contain their data in memory, rather than containing a pointer to the data.

**Interview Ready Answer:**
- **The Design Goal:** Structs exist to provide high-performance, low-overhead memory operations. By placing them on the stack (or inline in arrays/classes), the CLR avoids the overhead of updating pointers, allocating heap memory, and triggering Garbage Collection cycles.
- **The Array Benefit:** An array of 10,000 reference type classes requires 10,000 heap allocations plus an array of 10,000 pointers. An array of 10,000 structs is allocated as one single, contiguous, densely-packed block of memory, which is incredibly efficient for CPU cache lines.

<a id="q-6-14"></a>
> #### 6.14 What are records in C# and why were they introduced?

A **record** is a reference type that provides built-in functionality for encapsulating data with value-based equality.

**Interview Ready Answer:**
- **The Concept:** Introduced in C# 9, records are essentially classes that are optimized for acting as immutable data models.
- **Syntactic Sugar:** You can declare a record with a single line: `public record Person(string FirstName, string LastName);` This automatically generates properties, constructors, and equality methods.
- **Why introduced?** Before records, developers had to write hundreds of lines of boilerplate code to create truly immutable classes that could be compared by their values (overriding `Equals`, `GetHashCode`, `==`, `!=`). Records do this automatically.

<a id="q-6-15"></a>
> #### 6.15 What problems do records solve?

**Interview Ready Answer:**
- **Value Equality:** Two different record instances with the exact same data are considered equal (`person1 == person2` is true). With normal classes, this would be false because they have different memory addresses.
- **Non-Destructive Mutation:** Records introduce the `with` expression. If you want to change one property of an immutable record, you create a copy: `var olderPerson = person with { Age = 30 };`.
- **Ideal for Functional Programming:** They make it extremely easy to pass DTOs (Data Transfer Objects) and CQRS Commands/Queries around the system safely, guaranteeing the data cannot be altered in transit.

<a id="q-6-16"></a>
> #### 6.16 What are extension methods?

**Extension methods** allow you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

**Interview Ready Answer:**
- **The Syntax:** They are static methods defined inside a static class. The first parameter specifies the type being extended and is preceded by the `this` modifier (e.g., `public static int WordCount(this string str)`).
- **The Magic of LINQ:** The entire LINQ library (`.Where()`, `.Select()`) is built entirely on extension methods extending `IEnumerable<T>`.
- **Usage:** They look and feel exactly like native instance methods to the developer calling them (`myString.WordCount()`).

<a id="q-6-17"></a>
> #### 6.17 How are extension methods implemented under the hood?

**Interview Ready Answer:**
- **Syntactic Sugar:** The CLR does not know what an extension method is. It is purely a C# compiler trick.
- **The Translation:** When the C# compiler sees you calling `myString.WordCount()`, it immediately translates that line of code into a standard static method call: `StringUtilities.WordCount(myString)`.
- **No Private Access:** Because they are just static methods living in a different class, extension methods cannot access private or protected members of the class they are extending.

<a id="q-6-18"></a>
> #### 6.18 What is Reflection?

**Reflection** is the ability of a program to inspect its own metadata and interact with its own structure at runtime.

**Interview Ready Answer:**
- **The Concept:** You use the `System.Reflection` namespace to dynamically read the compiled assembly, modules, and types.
- **What can it do?** You can find all classes that implement an interface, read custom Attributes placed on properties, or dynamically invoke a method whose name you only know as a string.
- **The Cost:** Reflection is extremely slow compared to early-bound, strongly-typed code. It bypasses compile-time checks and requires heavy dictionary lookups and security checks by the CLR. It should be used sparingly (e.g., during application startup for DI registration, not inside a tight loop).

<a id="q-6-19"></a>
> #### 6.19 What are delegates in C#?

A **delegate** is a type that safely encapsulates a method, similar to a function pointer in C or C++.

**Interview Ready Answer:**
- **The Concept:** It is an object that knows how to call a method. You can assign a method to a delegate, pass the delegate around as a parameter, and then invoke the delegate later.
- **Type Safety:** Unlike C++ function pointers, delegates are fully object-oriented, type-safe, and secure. A delegate must match the exact signature (return type and parameters) of the method it encapsulates.
- **Primary Use Cases:** Used extensively for designing event architectures, callback methods, and passing LINQ expressions (`Func`, `Action`).

<a id="q-6-20"></a>
> #### 6.20 How do delegates work internally?

**Interview Ready Answer:**
- **Compiler Generation:** When you declare a delegate, the C# compiler automatically generates a sealed class that inherits from `System.MulticastDelegate`.
- **The Internals:** This generated class contains three vital pieces of information:
  1. A reference to the target object (if it's an instance method).
  2. A reference to the method to invoke (an `IntPtr` pointing to the memory address).
  3. An `Invoke()` method that synchronously calls the target method.
- **Invocation:** When you call `myDelegate()`, the CLR actually executes `myDelegate.Invoke()`.

<a id="q-6-21"></a>
> #### 6.21 What are multicast delegates?

A **multicast delegate** is a delegate that holds references to more than one method.

**Interview Ready Answer:**
- **The Concept:** When you invoke a multicast delegate, all the methods in its invocation list are called synchronously, in the order they were added.
- **The Syntax:** You add methods to a delegate's invocation list using the `+=` operator, and remove them using the `-=` operator.
- **Return Values:** If a multicast delegate has a return type, invoking it will only return the value of the *last* method executed in the list. This is why delegates used for events typically have a `void` return type.

<a id="q-6-22"></a>
> #### 6.22 Difference between delegates and events

**Interview Ready Answer:**

| Feature | Delegate | Event |
|---|---|---|
| **Nature** | A base type (class) that holds references to methods. | A modifier/wrapper built *on top* of a delegate to restrict access. |
| **Invocation** | Can be invoked by any class that has access to the delegate instance. | Can **only** be invoked by the class that declares the event. |
| **Assignment** | Can be completely reassigned using `=`. | Can only be subscribed/unsubscribed using `+=` and `-=`. |
| **Analogy** | Like an open list of phone numbers anyone can call. | Like a PA system where only the announcer can speak, but anyone can listen. |

<a id="q-6-23"></a>
> #### 6.23 Why use events over delegates?

Events enforce encapsulation and the Publish-Subscribe pattern safely.

**Interview Ready Answer:**
- **The Danger of Raw Delegates:** If you expose a public delegate `public Action OnClick;`, an external class could do `button.OnClick = null;` (wiping out all other subscribers) or `button.OnClick();` (faking a click from the outside).
- **The Event Shield:** By changing it to `public event Action OnClick;`, the C# compiler strictly enforces that outside classes can only use `+=` and `-=`. They cannot wipe the list, and they cannot invoke the event. Only the `Button` class can invoke its own event.

<a id="q-6-24"></a>
> #### 6.24 How are events implemented internally in .NET?

**Interview Ready Answer:**
- **Compiler Generation:** When you declare an event, the compiler actually generates a private backing delegate field.
- **Accessor Methods:** It also generates two hidden methods: an `add_MyEvent` method and a `remove_MyEvent` method (similar to the `get` and `set` methods of a property).
- **Thread Safety:** In modern C#, these generated `add` and `remove` methods use `Interlocked.CompareExchange` internally to ensure that multiple threads can safely subscribe to or unsubscribe from the event at the same exact time without corrupting the delegate's invocation list.

<a id="q-6-25"></a>
> #### 6.25 When would you use events in real-world applications?

**Interview Ready Answer:**
- **UI Frameworks:** Button clicks, text changes, or window resizing in WPF, WinForms, or MAUI.
- **Asynchronous Completion:** Notifying a UI component when a long-running background file download finishes.
- **Domain Events (DDD):** In Domain-Driven Design, raising an `OrderPlacedEvent` so that a separate `EmailService` and `InventoryService` can react to it without the `OrderService` knowing about them (decoupling).

<a id="q-6-26"></a>
> #### 6.26 What is the practical use of delegates?

**Interview Ready Answer:**
- **LINQ:** Every time you write `.Where(x => x.Age > 18)`, you are passing an inline method (a Lambda expression) as a delegate to the LINQ engine.
- **Callbacks:** Passing a "success" or "failure" method to an HTTP request engine so it knows what to execute when the network request completes.
- **Strategy Pattern (Lightweight):** Instead of creating a whole interface and class hierarchy for a Strategy pattern, you can just inject a `Func<T, TResult>` delegate that dictates the algorithm to use.

<a id="q-6-27"></a>
> #### 6.27 Difference between Action, Func, and Predicate

These are built-in generic delegates provided by .NET so you rarely have to define your own custom delegates.

**Interview Ready Answer:**

| Delegate Type | Signature | Purpose | Example |
|---|---|---|---|
| **`Action`** | Takes 0 to 16 parameters. Returns `void`. | Used when you want to execute code but don't need a result back. | `Action<string> print = Console.WriteLine;` |
| **`Func`** | Takes 0 to 16 parameters. **Must return a value.** | Used when you need to calculate and return a result. The *last* generic parameter is the return type. | `Func<int, int, string> addStr = (a,b) => (a+b).ToString();` |
| **`Predicate`** | Takes 1 parameter. Returns a `bool`. | Used specifically to test if an item meets a certain condition. | `Predicate<int> isEven = x => x % 2 == 0;` |

<a id="q-6-28"></a>
> #### 6.28 What are generic classes in C#?

**Generics** allow you to define classes, methods, and interfaces with a placeholder for the type of data they store or use.

**Interview Ready Answer:**
- **The Concept:** Instead of writing `class IntList` and `class StringList`, you write `class List<T>`. The `<T>` is a type parameter that is replaced with the actual type (like `int` or `string`) when the class is instantiated.
- **Usage:** Found everywhere in modern C#, particularly in the `System.Collections.Generic` namespace (`List<T>`, `Dictionary<TKey, TValue>`).

<a id="q-6-29"></a>
> #### 6.29 Why are generics important?

**Interview Ready Answer:**
- **Type Safety:** You get compile-time errors if you try to put a `string` into a `List<int>`. Before generics (using `ArrayList`), errors were only caught at runtime.
- **Performance (No Boxing):** Before generics, collections stored `object`. If you stored an `int`, it had to be boxed (moved to the heap) and then unboxed when retrieved. Generics eliminate this overhead for value types.
- **Code Reuse:** Write the algorithm once. A single `Repository<T>` can handle `User`, `Order`, and `Product` entities without duplicating code.

<a id="q-6-30"></a>
> #### 6.30 How do generics work internally in .NET?

This is an advanced CLR topic known as "Reification".

**Interview Ready Answer:**
- **At Compile Time:** The C# compiler emits the IL (Intermediate Language) with generic placeholders (e.g., `List\`1`). It does *not* generate separate classes for `int` and `string` yet.
- **At Runtime (JIT Compilation):** 
  - For **Value Types** (e.g., `List<int>`, `List<double>`), the JIT compiler generates a completely separate, specialized native code class for each value type to ensure maximum performance and exact memory layouts.
  - For **Reference Types** (e.g., `List<string>`, `List<User>`), the JIT compiler generates the native code *once* and shares it among all reference types. Because all reference types are just 64-bit memory pointers under the hood, they can safely share the same underlying machine code.

<a id="q-6-31"></a>
> #### 6.31 Why are generics type-safe?

**Interview Ready Answer:**
- **Compile-Time Enforcement:** The compiler knows the exact type `T` that was specified upon instantiation. 
- **No Implicit Casts:** If you have an `IEnumerable<object>`, the compiler will absolutely refuse to let you pass it to a method expecting an `IEnumerable<string>`.
- **IntelliSense:** Because the type is known, your IDE provides exact autocomplete for the properties of `T`, rather than just the base `object` methods.

<a id="q-6-32"></a>
> #### 6.32 What are generic constraints?

Generic constraints restrict the types that can be substituted for a type parameter `<T>`.

**Interview Ready Answer:**
- **The Problem:** If you write a generic method `void PrintId<T>(T item)`, you cannot call `item.Id` because the compiler assumes `T` is a base `object`.
- **The Solution:** You use the `where` keyword to tell the compiler what `T` must be.
- **Example:** `where T : IEntity`. Now the compiler guarantees that whatever `T` is, it implements `IEntity`, allowing you to safely call `item.Id`.

<a id="q-6-33"></a>
> #### 6.33 Types of generic constraints in C#

**Interview Ready Answer:**

| Constraint | Syntax | Meaning |
|---|---|---|
| **Class (Reference Type)** | `where T : class` | `T` must be a class, interface, delegate, or array. Cannot be an `int` or `struct`. |
| **Struct (Value Type)** | `where T : struct` | `T` must be a non-nullable value type. |
| **Interface/Base Class** | `where T : IMyInterface` | `T` must implement the specified interface or derive from the specific base class. |
| **Parameterless Constructor**| `where T : new()` | `T` must have a public parameterless constructor (allows you to do `new T()`). |
| **Not Null** (C# 8.0) | `where T : notnull` | `T` cannot be a nullable reference type or `Nullable<T>`. |

<a id="q-6-34"></a>
> #### 6.34 Difference between covariance, contravariance, and invariance

These concepts dictate how generic types with inheritance hierarchies behave.

**Interview Ready Answer:**
- **Invariance:** You must use the *exact* generic type. A `List<string>` is **not** a `List<object>`. You cannot assign one to the other.
- **Covariance (`out`):** Preserves assignment compatibility. You can assign a generic of a *derived* type to a generic of a *base* type. 
  - *Example:* `IEnumerable<object> list = new List<string>();`. Allowed because `IEnumerable` only *outputs* data (`out T`).
- **Contravariance (`in`):** Reverses assignment compatibility. You can assign a generic of a *base* type to a generic of a *derived* type.
  - *Example:* `Action<string> action = new Action<object>(...);`. Allowed because `Action` only *inputs* data (`in T`).

<a id="q-6-35"></a>
> #### 6.35 Where are covariance and contravariance used in .NET?

**Interview Ready Answer:**
- **Covariance (`out T`):** Used primarily in interfaces that *return* data. The most famous example is `IEnumerable<out T>`. You can safely iterate over a list of strings as if they were a list of objects.
- **Contravariance (`in T`):** Used primarily in interfaces/delegates that *consume* data. `IComparer<in T>` or `Action<in T>`. If you have a comparer that can compare any `object`, it can certainly be used to compare a `string`.

<a id="q-6-36"></a>
> #### 6.36 What is boxing and unboxing?

**Boxing** is the process of converting a value type (like an `int` or `struct`) to a reference type (`object` or an interface). **Unboxing** is the reverse process: extracting the value type from the object.

**Interview Ready Answer:**
- **Boxing Example:** `int i = 123; object o = i;` (Implicit cast). The CLR takes the integer from the stack and wraps it inside a new `System.Object` on the managed heap.
- **Unboxing Example:** `int j = (int)o;` (Explicit cast). The CLR verifies the type inside the object, extracts the integer value from the heap, and pushes it back onto the stack.

<a id="q-6-37"></a>
> #### 6.37 What happens internally during boxing and unboxing?

**Interview Ready Answer:**
- **Internals of Boxing:**
  1. The CLR allocates memory on the Managed Heap. The size allocated is the size of the value type *plus* two reference type overhead pointers (a sync block index and a type object pointer).
  2. The value on the stack is bit-wise copied into the newly allocated heap memory.
  3. The memory address (reference) of the heap object is returned and stored on the stack.
- **Internals of Unboxing:**
  1. The CLR checks if the object reference is null (throws `NullReferenceException` if so).
  2. The CLR checks if the boxed object actually matches the type you are trying to unbox it into (throws `InvalidCastException` if it doesn't match perfectly).
  3. The data is copied from the heap back to the local stack variable.

<a id="q-6-38"></a>
> #### 6.38 Why are boxing and unboxing expensive?

**Interview Ready Answer:**
- **Heap Allocation:** Boxing forces the CLR to allocate memory on the heap. Heap allocation is significantly slower than stack allocation.
- **Garbage Collection:** Creating short-lived objects on the heap creates GC pressure. If boxing happens inside a tight loop (e.g., thousands of times a second), it can trigger Gen0 garbage collections, causing application pauses.
- **CPU Overhead:** The bit-wise copying of memory and the type-checking mechanisms required during unboxing consume CPU cycles.
- **The Solution:** Always use Generics (`List<int>`) instead of legacy collections (`ArrayList`) to prevent implicit boxing.

<a id="q-6-39"></a>
> #### 6.39 What are nullable types in C#?

Value types (like `int`, `bool`, `DateTime`) cannot be null because they must contain actual data on the stack. **Nullable types** allow you to assign `null` to a value type.

**Interview Ready Answer:**
- **Syntax:** You append a `?` to the value type (e.g., `int? age = null;`).
- **Database Mapping:** They are absolutely essential for mapping database columns that allow NULL values to C# properties (e.g., a `DATETIME NULL` column maps to `DateTime?`).

<a id="q-6-40"></a>
> #### 6.40 How does `Nullable<T>` work internally?

**Interview Ready Answer:**
- **It's Just a Struct:** `int?` is syntactic sugar for the generic `Nullable<int>` struct.
- **The Core Fields:** Under the hood, `Nullable<T>` is a struct that contains exactly two fields:
  1. `bool HasValue` (Is it null or not?)
  2. `T Value` (The actual data, if it exists).
- **Behavior:** When you check `if (age.HasValue)`, you are just checking the boolean. If you try to access `age.Value` when `HasValue` is false, it throws an `InvalidOperationException`.

<a id="q-6-41"></a>
> #### 6.41 Where are nullable types stored in memory?

This is a very common trick question in senior interviews.

**Interview Ready Answer:**
- **The Stack:** Because `Nullable<T>` is fundamentally a `struct` (a value type), **it is stored on the stack** (or inline within a heap object).
- **The Illusion:** Even though it can equal `null` in code, there is no actual "null reference pointer" pointing nowhere. The memory is fully allocated on the stack; the `HasValue` boolean is just set to `false`.

<a id="q-6-42"></a>
> #### 6.42 Difference between `const`, `readonly`, and `static readonly`

**Interview Ready Answer:**

| Feature | `const` | `readonly` | `static readonly` |
|---|---|---|---|
| **Evaluation Time** | Compile-time. | Run-time (when instantiated). | Run-time (when type is loaded). |
| **Assignment** | Must be assigned exactly at the point of declaration. | Can be assigned at declaration OR in the constructor. | Can be assigned at declaration OR in the static constructor. |
| **Memory Allocation**| No memory allocated. The compiler replaces the variable with the raw value everywhere it is used. | Stored on the heap as part of the object instance. | Stored on the High-Frequency Heap once per AppDomain. |
| **Versioning Issue** | If a `const` in Assembly A is used in Assembly B, and Assembly A updates the value and is recompiled (but not B), B will still use the *old* hardcoded value. | No versioning issues. | No versioning issues. Safe for cross-assembly public constants. |

<a id="q-6-43"></a>
> #### 6.43 When should you use `const` vs `readonly`?

**Interview Ready Answer:**
- **Use `const` for:** Values that are absolutely, universally unchanging and will never, ever change in future versions (e.g., `Math.PI`, `DaysInAWeek = 7`).
- **Use `readonly` for:** Values that are constant for the life of an application run, but might change between deployments, or values that require complex initialization (e.g., configuration settings loaded at startup, instances of `HttpClient`, or injected dependencies).
- **Rule of Thumb:** If you are exposing a public constant from a library, almost always use `static readonly` to avoid assembly versioning bugs.

<a id="q-6-44"></a>
> #### 6.44 Difference between `ref`, `out`, and `in` parameters

By default, method arguments are passed by value. These keywords allow them to be passed by reference.

**Interview Ready Answer:**

| Keyword | Initialization Rule | Purpose | Memory Mechanism |
|---|---|---|---|
| **`ref`** | Must be initialized **before** being passed. | Two-way data transfer. The method can read the original variable and modify it. | Passes a pointer to the original memory address on the stack. |
| **`out`** | Does **not** need to be initialized before passing. | One-way data transfer out of the method. The method **must** assign a value before returning. | Passes a pointer. Often used to return multiple values (e.g., `TryParse`). |
| **`in`** | Must be initialized **before** passing. | Read-only reference. The method can read the original variable but **cannot** modify it. | Passes a pointer. Used to improve performance when passing huge structs without copying them. |

<a id="q-6-45"></a>
> #### 6.45 What are method parameters and argument passing mechanisms?

**Interview Ready Answer:**
- **Pass by Value (Default):** The CLR creates a copy of the variable.
  - *Value Types:* A full bit-wise copy of the data is placed on the stack. Changing the parameter inside the method does not affect the original.
  - *Reference Types:* A copy of the *reference pointer* is placed on the stack. Changing the *properties* of the object affects the original, but reassigning the variable to a `new` object does not affect the original pointer.
- **Pass by Reference (`ref`/`out`):** The CLR passes the exact memory address of the original variable. Reassigning a reference type variable to a `new` object *will* change the caller's pointer.

<a id="q-6-46"></a>
> #### 6.46 How do methods work internally in .NET?

**Interview Ready Answer:**
- **IL Code:** When compiled, methods become blocks of Intermediate Language (IL) instructions stored in the assembly's metadata.
- **Method Table:** Every type has a Method Table created by the CLR. It contains an array of memory addresses pointing to the executable code for each method the type defines.
- **JIT Compilation:** The first time a method is called, the JIT compiler reads the IL, compiles it into native CPU machine instructions, and updates the Method Table to point to this new native code.

<a id="q-6-47"></a>
> #### 6.47 What happens under the hood when a method is called?

**Interview Ready Answer:**
1. **Prologue:** The CPU pushes the current execution address (the return address) onto the Thread Stack.
2. **Arguments:** The caller pushes the method arguments onto the stack (or into CPU registers). If it's an instance method, a hidden `this` pointer is also pushed.
3. **Jump:** The CPU instruction pointer jumps to the memory address found in the Method Table for that specific method.
4. **Execution:** Local variables are allocated on the stack. The method executes.
5. **Epilogue:** The method places the return value in a specific CPU register, pops the local variables off the stack, and jumps back to the original return address.

<a id="q-6-48"></a>
> #### 6.48 What is the purpose of the `yield` statement?

The `yield` keyword allows you to perform custom, stateful iteration over a collection without having to create a temporary list in memory.

**Interview Ready Answer:**
- **`yield return`:** Returns one element at a time to the caller and pauses the method's execution. When the caller requests the next element (e.g., in a `foreach` loop), the method resumes execution exactly where it left off.
- **`yield break`:** Immediately terminates the iteration.
- **Memory Efficiency:** It prevents loading millions of records into memory at once. If you need to search a massive log file line-by-line, `yield` allows you to read and return one line at a time.

<a id="q-6-49"></a>
> #### 6.49 How do iterators work internally in C#?

The CLR does not natively understand `yield`. It is syntactic sugar provided by the C# compiler.

**Interview Ready Answer:**
- **The State Machine:** When the compiler sees a method returning `IEnumerable<T>` and containing `yield`, it completely rewrites the method into a hidden, private class that implements `IEnumerator<T>`.
- **State Tracking:** This hidden class contains an integer `_state` variable. 
- **Execution:** Every time `MoveNext()` is called by the `foreach` loop, the state machine uses a `switch` statement based on `_state` to jump to the correct block of code, execute until the next `yield return`, update the `_state`, and pause again.

<a id="q-6-50"></a>
> #### 6.50 Difference between `==`, `Equals()`, and `String.Compare()` in C#

**Interview Ready Answer:**

| Method | Behavior | Primary Use Case |
|---|---|---|
| **`==` operator** | For strings, it checks **Value Equality** (calls `Equals` under the hood). For other reference types, checks **Reference Equality**. | Quick equality checks in business logic (`if (status == "Open")`). |
| **`Equals()`** | Virtual method inherited from `object`. Usually overridden to check **Value Equality** (like in strings and records). | Determining if two objects represent the same data. |
| **`String.Compare()`** | Returns an integer (-1, 0, 1) indicating relative position in the sort order. Allows specifying culture and case sensitivity. | Sorting algorithms or culturally-aware alphabetizing. |

<a id="q-6-51"></a>
> #### 6.51 Difference between `String` and `StringBuilder`

**Interview Ready Answer:**
- **`String`:** Immutable. Every time you concatenate or modify a string (`str += "a"`), the CLR allocates a brand new memory block on the heap, copies the old string, adds the new character, and abandons the old memory to the Garbage Collector.
- **`StringBuilder`:** Mutable. It maintains an internal character array buffer. When you call `.Append()`, it simply inserts characters into the existing buffer. It only allocates new heap memory when the buffer fills up and needs to be resized.
- **When to use:** Use `StringBuilder` when performing multiple (usually >3) concatenations in a tight loop. Use standard `string` operations for simple, one-off concatenations.

<a id="q-6-52"></a>
> #### 6.52 Why is `string` a reference type but behaves like a value type?

It is a reference type allocated on the heap, but it features "Value Semantics" designed to make it safe and predictable.

**Interview Ready Answer:**
- **The Behavior:** When you pass a string to a method and modify it, the original string does not change. When you use `==`, it compares the text, not the memory address.
- **The Reason:** This behavior exists solely because strings are **immutable** and the `==` operator is explicitly overloaded by Microsoft. 
- **The Process:** When you "modify" the passed string, you aren't actually mutating the original heap object; you are creating a *new* heap object and pointing your local variable to it, leaving the original caller's string untouched.

<a id="q-6-53"></a>
> #### 6.53 Difference between `string.IsNullOrEmpty()` and `string.IsNullOrWhiteSpace()`

**Interview Ready Answer:**
- **`IsNullOrEmpty()`:** Returns true only if the string is `null` or exactly `""` (Length == 0). A string containing `"   "` (spaces) will return **false**.
- **`IsNullOrWhiteSpace()`:** Returns true if the string is `null`, `""`, or contains *only* whitespace characters (spaces, tabs, newlines).
- **Best Practice:** In 99% of web applications (like validating user input from a text box), you should use `IsNullOrWhiteSpace()` to prevent users from bypassing validation by hitting the spacebar.

<a id="q-6-54"></a>
> #### 6.54 Why are strings immutable in C#?

Strings are immutable for performance, security, and thread-safety.

**Interview Ready Answer:**
- **String Interning:** Because they are immutable, the CLR can safely cache identical strings in a global "Intern Pool" to save memory. If you declare `"hello"` in ten different places, only one `"hello"` object exists in memory.
- **Thread Safety:** You can pass a string across hundreds of threads simultaneously without ever needing a `lock` statement. It is impossible for one thread to corrupt the string while another is reading it.
- **Security & Hashing:** Strings are often used as Dictionary keys or database connection strings. If a string were mutable, a malicious thread could change the connection string *after* security checks had passed, but *before* the connection opened.

<a id="q-6-55"></a>
> #### 6.55 What are the benefits and drawbacks of immutable strings?

**Interview Ready Answer:**
- **Benefits:** Thread-safe by default, secure, allows memory optimization (Interning), and provides predictable behavior when passed as arguments.
- **Drawbacks:** Severe performance penalties and Garbage Collection pressure during heavy string manipulation. Constructing a long XML document via `string +=` will generate thousands of orphaned string objects on the managed heap, destroying application throughput.

<a id="q-6-56"></a>
> #### 6.56 Difference between value types and reference types

This is the most fundamental concept of CLR memory management.

**Interview Ready Answer:**

| Feature | Value Types | Reference Types |
|---|---|---|
| **Memory Location** | Allocated on the **Stack** (or inline within another object). | Allocated on the **Managed Heap**. |
| **Data Storage** | The variable holds the **actual data**. | The variable holds a **pointer** (memory address) to the data on the heap. |
| **Copy Behavior** | When assigned to a new variable, the actual data is duplicated bit-by-bit. | When assigned to a new variable, only the pointer is copied. Both variables point to the same object. |
| **Base Type** | Inherit from `System.ValueType`. | Inherit directly from `System.Object`. |
| **Examples** | `int`, `bool`, `double`, `struct`, `enum`. | `class`, `interface`, `delegate`, `string`, `object`. |

<a id="q-6-57"></a>
> #### 6.57 Difference between stack and heap memory

**Interview Ready Answer:**

| Feature | Thread Stack | Managed Heap |
|---|---|---|
| **Purpose** | Keeps track of executing code, method calls, and local variables. | Stores objects that need to outlive the method that created them. |
| **Structure** | LIFO (Last In, First Out). Highly structured. | Unstructured pool of memory. |
| **Speed** | Extremely fast allocation and deallocation (just moving a stack pointer). | Slower allocation. Requires finding free space and updating references. |
| **Management** | Self-maintaining. Memory is freed instantly when the method returns. | Managed by the **Garbage Collector** which periodically freezes the app to clean up unreferenced objects. |

<a id="q-6-58"></a>
> #### 6.58 Where are value types and reference types stored in memory?

**Interview Ready Answer:**
- **The "Rule":** Value types go on the Stack, Reference types go on the Heap. **(Warning: This is an oversimplification and often false).**
- **The Truth:** 
  - **Reference Types** are *always* stored on the Heap. The variable holding the pointer to them is stored on the Stack.
  - **Value Types** are stored *wherever they are declared*. 
    - If a struct `Point` is a local variable inside a method, it is on the Stack.
    - If a struct `Point` is a property inside a `class User`, it is stored inline within the `User` object on the **Heap**.

<a id="q-6-59"></a>
> #### 6.59 How does memory allocation work for structs and classes?

**Interview Ready Answer:**
- **Classes (Heap Allocation):** The CLR calculates the total size of the class, plus 8 bytes of overhead (Sync Block Index and Type Handle). It finds a contiguous block of memory on the Managed Heap, initializes the memory to zero, calls the constructor, and returns the memory address to the stack pointer.
- **Structs (Stack Allocation):** The CLR simply increments the Stack Pointer by the exact byte size of the struct. There is zero object overhead. The memory is immediately available and is discarded the exact moment the stack frame pops (method returns).

<a id="q-6-60"></a>
> #### 6.60 What is thread safety?

**Thread safety** is the guarantee that a piece of code or an object will behave correctly and maintain data integrity when accessed by multiple threads simultaneously.

**Interview Ready Answer:**
- **The Goal:** Preventing race conditions, data corruption, and deadlocks.
- **How to Achieve It:**
  - **Immutability:** The easiest way. If state cannot be changed, any number of threads can read it safely (e.g., `string`).
  - **Statelessness:** Methods that only operate on local variables passed into them (like most static utility methods).
  - **Synchronization:** Using locks (`lock`, `SemaphoreSlim`, `Mutex`) to force threads to queue up and access shared mutable state one at a time.

<a id="q-6-61"></a>
> #### 6.61 What problems occur in multithreaded applications?

**Interview Ready Answer:**
- **Race Conditions:** Two threads try to read, modify, and write the same variable at the exact same millisecond. Thread A overwrites Thread B's work, causing data loss (e.g., a counter incrementing by 1 instead of 2).
- **Deadlocks:** Thread A locks Resource X and waits for Resource Y. Thread B locks Resource Y and waits for Resource X. Both freeze forever.
- **Starvation:** A low-priority thread never gets CPU time because high-priority threads constantly monopolize the lock or the processor.

<a id="q-6-62"></a>
> #### 6.62 Difference between synchronization and thread safety

**Interview Ready Answer:**
- **Thread Safety** is the *end goal* or the *characteristic* of the code. (e.g., "This class is thread-safe").
- **Synchronization** is the *mechanism* used to achieve thread safety. (e.g., "I used synchronization primitives like `lock` to make this class thread-safe"). Not all thread-safe code requires synchronization (e.g., immutable objects are thread-safe without synchronization).

<a id="q-6-63"></a>
> #### 6.63 What is the `lock` statement?

The `lock` statement in C# is a synchronization mechanism that ensures only one thread can execute a specific block of code at a time.

**Interview Ready Answer:**
- **The Syntax:** `lock (_syncObject) { // Critical Section }`
- **The Concept:** It defines a "Critical Section". When Thread A reaches the `lock`, it acquires exclusive access to `_syncObject`. If Thread B arrives, it is blocked and put to sleep by the OS until Thread A releases the lock.
- **Syntactic Sugar:** Under the hood, `lock` is compiled into a `try...finally` block using `System.Threading.Monitor.Enter()` and `Monitor.Exit()`, ensuring the lock is always released even if an exception is thrown.

<a id="q-6-64"></a>
> #### 6.64 How does locking work internally in .NET?

**Interview Ready Answer:**
- **The Sync Block Index:** Every object allocated on the Managed Heap contains a hidden 4-byte header called the Sync Block Index.
- **The Monitor:** When you call `lock(obj)`, the CLR looks at `obj`'s Sync Block Index. If it's zero, it points it to a free Sync Block structure in an internal CLR table. 
- **The Lock:** The Sync Block records which Thread ID currently owns the object. Any other thread checking that Sync Block will see it is owned and will yield its CPU time until the owning thread clears the Sync Block.

<a id="q-6-65"></a>
> #### 6.65 What problems does locking solve?

**Interview Ready Answer:**
- **Solves Race Conditions:** By ensuring atomicity. If updating an account balance takes 3 CPU instructions (Read, Add, Write), a lock ensures all 3 instructions execute uninterrupted by other threads.
- **Prevents Dirty Reads:** Ensures that a thread reading a complex object doesn't read it while it's in a partially-updated, invalid state.

<a id="q-6-66"></a>
> #### 6.66 What is deadlock and how can it be avoided?

A **deadlock** occurs when two or more threads are permanently blocked, each waiting for a lock held by the other.

**Interview Ready Answer:**
- **The Scenario:** Thread 1 locks object A, needs object B. Thread 2 locks object B, needs object A. Both wait indefinitely.
- **How to Avoid It:**
  1. **Lock Ordering:** Always acquire locks in the exact same predefined order across the entire application.
  2. **Timeouts:** Never wait infinitely. Use `Monitor.TryEnter(obj, TimeSpan)` to attempt a lock. If it fails after 5 seconds, back off, release your current locks, and try again later.
  3. **Avoid Nested Locks:** Try to design the architecture so a thread only ever needs to hold one lock at a time.

<a id="q-6-67"></a>
> #### 6.67 Difference between synchronous and asynchronous programming

**Interview Ready Answer:**
- **Synchronous:** Code executes top-to-bottom. If a line of code initiates a network request, the entire thread stops (blocks) and waits, doing absolutely nothing until the response arrives.
- **Asynchronous:** When an I/O operation (like a network request) is initiated, the thread does *not* wait. The thread is immediately released back to the application to handle other tasks (like processing other HTTP requests). Once the I/O operation finishes, a thread is notified to resume executing the rest of the code.

<a id="q-6-68"></a>
> #### 6.68 What is async/await?

`async` and `await` are C# keywords introduced to make writing asynchronous code look and feel exactly like writing synchronous code.

**Interview Ready Answer:**
- **`async` Keyword:** Used in a method signature. It does *not* magically make the method run on a background thread. Its only purpose is to enable the use of the `await` keyword inside that method, and to tell the compiler to build a state machine.
- **`await` Keyword:** This is where the magic happens. It tells the compiler: "Initiate this asynchronous task. Do *not* block the current thread. Return control to the caller. When the task finishes, pick up where you left off right here."

<a id="q-6-69"></a>
> #### 6.69 How does async/await work internally?

This is one of the most important concepts to understand for senior .NET roles.

**Interview Ready Answer:**
- **The State Machine:** Just like `yield`, the CLR has no concept of `async/await`. The C# compiler rewrites your async method into a private struct that implements `IAsyncStateMachine`.
- **The Process:**
  1. The state machine begins execution synchronously until it hits the first `await`.
  2. The `await` initiates the I/O bound task (e.g., sending an HTTP request). 
  3. Crucially, the method *returns* immediately. The thread that was executing the method goes back to the ThreadPool.
  4. When the OS finishes the network request, an I/O Completion Port (IOCP) signals the .NET ThreadPool.
  5. The ThreadPool grabs a free thread, restores the state machine's local variables, and executes the remainder of the method.

<a id="q-6-70"></a>
> #### 6.70 What is Task in .NET?

A **`Task`** represents an asynchronous operation that may or may not have completed yet. It is the core of the Task Parallel Library (TPL).

**Interview Ready Answer:**
- **Concept:** It is essentially a "promise" or a "future". It is an object that encapsulates the state of the operation (Running, RanToCompletion, Faulted), any exceptions that occurred, and the eventual return value (`Task<T>`).
- **Memory:** `Task` is a class, meaning it is allocated on the managed heap. (In high-performance scenarios, .NET provides `ValueTask` to avoid this heap allocation for methods that often complete synchronously).

<a id="q-6-71"></a>
> #### 6.71 What is TAP (Task-based Asynchronous Pattern)?

**TAP** is the standard Microsoft pattern for writing asynchronous code in modern .NET.

**Interview Ready Answer:**
- **The Rules of TAP:**
  1. Asynchronous methods must return a `Task` or `Task<T>`.
  2. Method names must be suffixed with the word "Async" (e.g., `GetUserDataAsync`).
  3. Methods should accept a `CancellationToken` to support graceful cancellation.
- **Why it matters:** It unifies all asynchronous programming in .NET under one predictable API, replacing older legacy patterns like APM (IAsyncResult/Begin/End) and EAP (Event-based).

<a id="q-6-72"></a>
> #### 6.72 What is the ThreadPool in .NET?

The **ThreadPool** is a background process manager that maintains a pool of pre-created worker threads ready to execute tasks.

**Interview Ready Answer:**
- **The Problem it Solves:** Creating a new OS thread is extremely slow and expensive (allocating ~1MB of memory per thread). If a web server created a brand new thread for every incoming HTTP request, it would crash instantly under load.
- **How it Works:** The ThreadPool creates a set number of threads. When a task arrives (e.g., an incoming HTTP request or a `Task.Run`), the ThreadPool assigns it to an idle thread. When the task finishes, the thread is *not* destroyed; it is returned to the pool to be reused.

<a id="q-6-73"></a>
> #### 6.73 Difference between `Task.Run()` and creating threads manually

**Interview Ready Answer:**
- **Manual Threads (`new Thread()`)**: Forces the OS to allocate a brand new dedicated thread. Takes time and memory. You must manually start it and join it.
- **`Task.Run()`**: Queues the work to the **ThreadPool**. It tells the pool: "Whenever a worker thread is free, execute this code." It is vastly more efficient, faster to start, and returns a `Task` object so you can `await` its completion. You should almost never use `new Thread()` in modern C#.

<a id="q-6-74"></a>
> #### 6.74 Difference between concurrency and parallelism

**Interview Ready Answer:**
- **Concurrency:** Dealing with multiple things at once. It's about structure. Using `async/await` allows a single thread to handle hundreds of concurrent web requests by switching between them while waiting for I/O.
- **Parallelism:** Doing multiple things at the exact same physical time. It requires multiple CPU cores. Using `Parallel.ForEach` to calculate millions of prime numbers spread across 8 CPU cores is parallelism.

<a id="q-6-75"></a>
> #### 6.75 What is `SynchronizationContext`?

The `SynchronizationContext` is an abstraction that represents the environment or "context" in which code is currently running (e.g., a UI thread, an ASP.NET request context, or a thread pool thread).

**Interview Ready Answer:**
- **The Concept:** When you `await` a task, the default behavior is to capture the current `SynchronizationContext`. When the task finishes, the continuation (the rest of the method) is posted back to that exact same context.
- **UI Frameworks:** In WPF or WinForms, the context is the single UI thread. If you `await` a network call, the rest of the method *must* resume on the UI thread, otherwise you cannot update text boxes.
- **ASP.NET Core:** Modern ASP.NET Core **does not** have a `SynchronizationContext`. This means continuations just run on whatever random ThreadPool thread is available, massively improving performance.

<a id="q-6-76"></a>
> #### 6.76 What is `ConfigureAwait(false)` and when should you use it?

**Interview Ready Answer:**
- **The Purpose:** `ConfigureAwait(false)` explicitly tells the `await` keyword *not* to capture the current `SynchronizationContext`. It tells the system: "When this task finishes, just resume the rest of the method on any random background thread."
- **When to use it:** You should use it on almost every single `await` call inside **Class Libraries** or background services.
- **Why use it:** 
  1. **Performance:** It avoids the overhead of queueing the continuation back onto the original context.
  2. **Deadlock Prevention:** In older ASP.NET (Framework) or UI apps, if the calling code blocks synchronously (`.Result` or `.Wait()`), capturing the context will cause a permanent deadlock.

<a id="q-6-77"></a>
> #### 6.77 Difference between `Task.WhenAll()` and `Task.WhenAny()`

**Interview Ready Answer:**
- **`Task.WhenAll()`:** Takes an array of Tasks. It returns a new Task that completes only when **all** the provided tasks have finished. It is the primary way to execute multiple asynchronous operations in parallel (e.g., fetching data from 3 different APIs simultaneously).
- **`Task.WhenAny()`:** Takes an array of Tasks. It returns a new Task that completes the exact millisecond that the **fastest** of the provided tasks finishes. Often used for redundancy (querying 3 servers and taking the first response) or implementing timeouts.

<a id="q-6-78"></a>
> #### 6.78 How are exceptions handled in async/await?

**Interview Ready Answer:**
- **Standard Try/Catch:** You handle them exactly like synchronous code by wrapping the `await` call in a `try/catch` block.
- **The Magic:** When an exception is thrown inside an async method, it is caught by the compiler-generated state machine and placed inside the returned `Task` object (setting its state to `Faulted`). When you `await` that `Task`, the state machine unpacks the exception and re-throws it, preserving the original stack trace.
- **`Task.WhenAll` Exceptions:** If multiple tasks throw exceptions, `WhenAll` bundles them into an `AggregateException`. However, if you `await Task.WhenAll()`, it will only unwrap and throw the *first* exception.

<a id="q-6-79"></a>
> #### 6.79 Why should async methods avoid `async void`?

**Interview Ready Answer:**
- **The Core Rule:** Async methods must almost always return `Task` or `Task<T>`. Returning `void` breaks the asynchronous flow.
- **Exception Swallowing:** If an exception is thrown inside an `async void` method, it cannot be caught by a calling `try/catch` block because there is no `Task` object returned to hold the exception. It will crash the entire application process immediately.
- **No Tracking:** The caller has no way to know when the `async void` method has finished. You cannot `await` it.

<a id="q-6-80"></a>
> #### 6.80 When is `async void` acceptable?

**Interview Ready Answer:**
- **The Only Exception:** The **only** valid use case for `async void` is **Event Handlers** (like a button click event in a UI application). 
- **Reason:** Event handler delegates (like `EventHandler`) have a signature that strictly requires a `void` return type. Therefore, you must use `async void Button_Click(object sender, EventArgs e)` to use `await` inside the click handler.

<a id="q-6-81"></a>
> #### 6.81 What are exceptions in C#?

**Exceptions** are objects that represent an error or unexpected behavior that occurs during application execution.

**Interview Ready Answer:**
- **The Hierarchy:** All exceptions inherit from `System.Exception`. 
- **The Disruption:** When an exception is thrown, the normal top-to-bottom flow of execution stops instantly. The CLR searches up the call stack to find the nearest `catch` block that can handle that specific type of exception.
- **The Cost:** Throwing an exception is computationally expensive because the CLR has to freeze the thread and capture the stack trace.

<a id="q-6-82"></a>
> #### 6.82 Explain `try`, `catch`, and `finally`

**Interview Ready Answer:**
- **`try` block:** Contains the code that might throw an exception.
- **`catch` block:** Contains the code that executes if (and only if) an exception of a matching type is thrown inside the `try` block. You can have multiple catch blocks to handle different types of errors.
- **`finally` block:** Contains code that is **guaranteed** to execute regardless of whether an exception was thrown or not. It is primarily used to clean up and release unmanaged resources (closing file streams or database connections).

<a id="q-6-83"></a>
> #### 6.83 What is the purpose of the `finally` block?

**Interview Ready Answer:**
- **Guaranteed Execution:** Code inside a `finally` block will run whether the `try` block succeeds, or a `catch` block catches an exception. (The only exception is if the process is hard-killed via `Environment.FailFast` or a power outage).
- **Resource Cleanup:** Its primary and most critical use case is to ensure that unmanaged resources (database connections, network sockets, file handles) are properly closed and released back to the OS, preventing severe memory and resource leaks.
- **Relationship to `using`:** The `using` statement in C# is literally just syntactic sugar that the compiler translates into a `try...finally` block that calls `.Dispose()` in the `finally`.

<a id="q-6-84"></a>
> #### 6.84 Difference between `throw` and `throw ex`

**Interview Ready Answer:**
- **`throw`:** Re-throws the exact exception that was caught. It strictly preserves the original stack trace, meaning you can see exactly which line of code deep in the application caused the error.
- **`throw ex`:** Throws a *new* exception object using the `ex` variable. This completely wipes out the original stack trace. The CLR treats the line containing `throw ex;` as the origin of the error.

<a id="q-6-85"></a>
> #### 6.85 Why is `throw ex` considered bad practice?

**Interview Ready Answer:**
- **Lost Telemetry:** It destroys the stack trace. When you check your application logs in production (e.g., Datadog, Application Insights), you will see the error originating from the `catch` block, rather than the actual line of business logic that failed. This makes debugging nearly impossible.
- **The Solution:** Always use `throw;` to re-throw, or wrap the exception inside a new, more meaningful custom exception (e.g., `throw new DomainException("Order failed", ex);`) using the inner exception parameter.

<a id="q-6-86"></a>
> #### 6.86 What are custom exceptions?

**Interview Ready Answer:**
- **Concept:** Classes you create that inherit from `System.Exception` to represent specific business or domain errors unique to your application (e.g., `InsufficientFundsException`, `UserNotFoundException`).
- **Why Use Them:** They allow calling code to write specific `catch (InsufficientFundsException)` blocks and handle business logic errors differently than systemic errors (like `SqlException` or `NullReferenceException`).

<a id="q-6-87"></a>
> #### 6.87 How do you create custom exceptions?

**Interview Ready Answer:**
- **Inheritance:** Create a class and inherit from `System.Exception`.
- **Constructors:** By convention, you should implement three constructors:
  1. A parameterless constructor.
  2. A constructor taking a `string message`.
  3. A constructor taking a `string message` and an `Exception innerException` (crucial for wrapping lower-level errors).
- **Example:** `public class InvalidOrderException : Exception { public InvalidOrderException(string msg) : base(msg) {} }`

<a id="q-6-88"></a>
> #### 6.88 How does exception handling work internally in .NET?

**Interview Ready Answer:**
- **Two-Pass System:** When an exception occurs, the CLR uses a two-pass process.
- **First Pass (Discovery):** The CLR halts execution and walks up the call stack, looking for a `catch` block whose filter matches the exception type. If it reaches the top of the stack without finding one, the application crashes.
- **Second Pass (Unwinding):** If a match is found, the CLR walks the stack a second time, executing all `finally` blocks between the point of the throw and the matching `catch` block. This guarantees all resources are cleaned up before the error is actually handled.

<a id="q-6-89"></a>
> #### 6.89 What happens if an exception is not handled?

**Interview Ready Answer:**
- **Unhandled Exception:** It bubbles all the way up to the top of the Thread Stack.
- **App Crash:** The CLR catches it at the global level, logs it (usually to the Windows Event Viewer or console), and then immediately terminates the entire application process to prevent state corruption.
- **Global Handlers:** To prevent immediate crashes or log the fatal error gracefully, frameworks provide global catch-all events (e.g., `AppDomain.CurrentDomain.UnhandledException` or ASP.NET Core's Global Exception Handling Middleware).

<a id="q-6-90"></a>
> #### 6.90 Best practices for exception handling in enterprise applications

**Interview Ready Answer:**
1. **Catch specific, not general:** Avoid `catch (Exception ex)` unless it's at the very top level (Global Middleware). Catch specific exceptions like `SqlException` so you don't accidentally swallow `OutOfMemoryException`.
2. **Never swallow exceptions:** Never write an empty `catch` block. Always log it.
3. **Use Global Middleware:** In ASP.NET Core, centralize exception logging and HTTP 500 response generation in one single Middleware class rather than scattering `try/catch` blocks in every controller.
4. **Use Result Pattern for Logic:** Don't use exceptions for normal control flow (e.g., validating a password). Use a `Result<T>` object instead. Exceptions should be for *exceptional*, unexpected systemic failures.

<a id="q-6-91"></a>
> #### 6.91 What is IDisposable?

`IDisposable` is an interface that provides a deterministic mechanism for releasing unmanaged resources.

**Interview Ready Answer:**
- **The Contract:** It contains a single method: `void Dispose()`.
- **The Purpose:** The .NET Garbage Collector (GC) is non-deterministic; you never know exactly when it will run to clean up memory. If your class holds onto a database connection or a file handle, you cannot wait for the GC. You implement `IDisposable` to allow developers to explicitly release that resource the exact moment they are done with it.

<a id="q-6-92"></a>
> #### 6.92 Who calls Dispose()?

**Interview Ready Answer:**
- **The Developer:** It is the responsibility of the developer using the class to call `.Dispose()` when they are finished with the object.
- **The `using` Statement:** The most common way to ensure it gets called is wrapping the object in a `using` statement, which automatically calls `.Dispose()` at the end of the block.
- **Dependency Injection Container:** In modern ASP.NET Core, if an `IDisposable` object is registered as Scoped or Transient, the DI container automatically calls `.Dispose()` when the HTTP request ends.

<a id="q-6-93"></a>
> #### 6.93 Difference between managed and unmanaged resources

**Interview Ready Answer:**

| Feature | Managed Resources | Unmanaged Resources |
|---|---|---|
| **Definition** | Memory and objects created and managed directly by the .NET CLR. | Resources provided by the Operating System (Windows/Linux) outside the CLR's control. |
| **Cleanup** | Cleaned up automatically by the Garbage Collector. | **Must** be cleaned up manually via `Dispose()` or a finalizer. |
| **Examples** | `string`, `List<T>`, custom business objects (`User`). | File handles, Database connections (`SqlConnection`), Network Sockets, COM objects, Window handles. |

<a id="q-6-94"></a>
> #### 6.94 What is managed code?

**Interview Ready Answer:**
- **Definition:** Code whose execution is strictly managed by the Common Language Runtime (CLR). 
- **Features:** It benefits from automatic memory management (Garbage Collection), type safety, bounds checking (preventing array overflow), and exception handling. C#, F#, and VB.NET all compile down to managed IL code.

<a id="q-6-95"></a>
> #### 6.95 What is unmanaged code?

**Interview Ready Answer:**
- **Definition:** Code that executes directly on the CPU, outside the control of the CLR.
- **Features:** It does not have built-in Garbage Collection or strict type safety. The programmer is 100% responsible for allocating and freeing memory (e.g., using `malloc` and `free` in C/C++).

<a id="q-6-96"></a>
> #### 6.96 Difference between managed and unmanaged code

**Interview Ready Answer:**
- **Execution:** Managed code is executed by the CLR (via JIT compilation). Unmanaged code is executed directly by the operating system.
- **Security:** Managed code is heavily verified for security and type-safety before running. Unmanaged code runs with raw pointers, making it susceptible to buffer overflows and memory leaks if written poorly.
- **Interop:** You can call unmanaged code (like legacy C++ DLLs or Windows API functions) from managed C# code using `P/Invoke` (Platform Invocation Services) and the `[DllImport]` attribute.

<a id="q-6-97"></a>
> #### 6.97 How does the `using` statement work internally?

**Interview Ready Answer:**
- **Syntactic Sugar:** The `using` keyword is purely a compiler trick. The CLR doesn't know what it is.
- **The Translation:** When the compiler sees `using (var stream = new FileStream(...)) { ... }`, it rewrites the code into:
  ```csharp
  var stream = new FileStream(...);
  try {
      // Your code
  } finally {
      if (stream != null) {
          ((IDisposable)stream).Dispose();
      }
  }
  ```
- **The Guarantee:** This ensures `.Dispose()` is called even if a catastrophic exception is thrown inside the block.

<a id="q-6-98"></a>
> #### 6.98 Difference between `Dispose()` and finalizers

**Interview Ready Answer:**

| Feature | `Dispose()` | Finalizer (`~MyClass()`) |
|---|---|---|
| **Invocation** | Called explicitly by the developer (or via `using`). | Called implicitly and unpredictably by the Garbage Collector before destroying the object. |
| **Purpose** | Deterministic, immediate cleanup of resources. | A safety net. A "last resort" cleanup if the developer forgot to call `Dispose()`. |
| **Performance Impact**| Extremely fast. | Severe. Objects with finalizers require two full GC cycles to be removed from memory (they are moved to the Finalization Queue). |

<a id="q-6-99"></a>
> #### 6.99 What is garbage collection (GC)?

Garbage Collection (GC) is the automatic memory management system in .NET.

**Interview Ready Answer:**
- **The Concept:** Instead of developers manually freeing memory (like `free()` in C or `delete` in C++), the GC runs in the background, tracks object usage, and automatically deletes objects from the Managed Heap when they are no longer needed.
- **The Goal:** To prevent memory leaks, dangling pointers, and to drastically simplify development.

<a id="q-6-100"></a>
> #### 6.100 How does garbage collection work internally?

**Interview Ready Answer:**
- **The Mark and Sweep Algorithm:**
  1. **Pause:** The GC suspends all executing threads in the application (unless using Background/Concurrent GC).
  2. **Mark (Tracing):** It builds a graph starting from "GC Roots" (active local variables on thread stacks, static fields, CPU registers). It traverses all object references and "marks" them as in-use.
  3. **Sweep:** Any object on the heap that was *not* marked is considered garbage.
  4. **Compact:** The GC deletes the garbage and shifts the remaining surviving objects together to prevent memory fragmentation.
  5. **Resume:** Application threads are resumed.

<a id="q-6-101"></a>
> #### 6.101 What are GC generations?

To optimize performance, the Managed Heap is divided into three Generations based on the premise that "new objects die quickly, old objects live forever."

**Interview Ready Answer:**
- **Generation 0 (Gen 0):** Where all newly allocated objects go (except very large ones). The GC collects Gen 0 frequently. It is extremely fast. If an object survives a Gen 0 collection, it is promoted to Gen 1.
- **Generation 1 (Gen 1):** A buffer between short-lived and long-lived objects. Collected less frequently. Survivors are promoted to Gen 2.
- **Generation 2 (Gen 2):** Contains long-lived objects (like Singletons, static data, or cached collections). Collecting Gen 2 is a "Full GC" and is very expensive/slow.
- **Large Object Heap (LOH):** Objects larger than 85,000 bytes go straight here (effectively Gen 2). The LOH is rarely compacted because moving massive arrays in memory takes too much CPU time.

<a id="q-6-102"></a>
> #### 6.102 Does GC run on a fixed schedule?

**Interview Ready Answer:**
- **No Schedule:** The GC is completely non-deterministic. It does not run on a timer.
- **Triggers:** It runs primarily when memory pressure demands it:
  1. When Gen 0 reaches its allocation threshold.
  2. When the OS signals low system memory.
  3. When a developer explicitly calls `GC.Collect()` (which is almost always a terrible idea in production).

<a id="q-6-103"></a>
> #### 6.103 How does the CLR manage memory?

**Interview Ready Answer:**
- **The Process:** 
  1. **Allocation:** The CLR manages a single contiguous block of memory for the Managed Heap. It maintains a pointer to the next available address. Allocating memory is as fast as adding the object size to the pointer.
  2. **Virtual Memory:** The CLR interacts with the Windows Virtual Memory manager, reserving large segments of address space and only committing physical RAM when actually needed.
  3. **Reclamation:** Handled entirely by the Garbage Collector's generational mark-and-compact algorithm.

<a id="q-6-104"></a>
> #### 6.104 What is CLR (Common Language Runtime)?

The CLR is the virtual machine component of the .NET framework that manages the execution of .NET programs.

**Interview Ready Answer:**
- **The Concept:** It is the execution engine. Just like Java has the JVM, .NET has the CLR. 
- **Language Agnostic:** C#, F#, and VB.NET all compile into the same Intermediate Language (IL). The CLR doesn't care what language you wrote in; it only understands and executes IL.

<a id="q-6-105"></a>
> #### 6.105 Responsibilities of the CLR

**Interview Ready Answer:**
- **JIT Compilation:** Converting IL to machine code.
- **Memory Management:** Managing the Stack, Heap, and Garbage Collection.
- **Type Safety:** Enforcing strict type casting rules.
- **Exception Handling:** Managing the structured `try/catch/finally` blocks and unwinding the stack.
- **Thread Management:** Managing the ThreadPool and OS thread mapping.
- **Security:** Code Access Security (CAS) and assembly signing verification.

<a id="q-6-106"></a>
> #### 6.106 How does the CLR execute C# code?

**Interview Ready Answer:**
1. **Source Code:** You write C# code.
2. **Roslyn Compiler:** When you hit build, the C# compiler (Roslyn) converts your code into an assembly (.dll or .exe) containing **Intermediate Language (IL)** and Metadata.
3. **App Startup:** You run the app. The OS loads the CLR.
4. **JIT Compilation:** As the app runs, the CLR's Just-In-Time (JIT) compiler intercepts method calls, translates the IL into native machine code (specific to your Intel/AMD/ARM processor), and caches it.
5. **Execution:** The CPU executes the native machine code.

<a id="q-6-107"></a>
> #### 6.107 How does the CLR manage application execution?

**Interview Ready Answer:**
- **AppDomains (Legacy .NET Framework):** Historically, the CLR used AppDomains to isolate applications running within the same process. One AppDomain crashing wouldn't affect others.
- **AssemblyLoadContexts (Modern .NET Core/5+):** AppDomains were deprecated. Modern .NET uses `AssemblyLoadContext` to provide isolation for dynamically loading and unloading plugins and dependencies without strict boundaries, resulting in much faster, cross-platform execution.
- **Execution Engine:** It handles the continuous cycle of JIT compilation, method execution, thread switching, and periodic Garbage Collection pauses.

<a id="q-6-108"></a>
> #### 6.108 What is JIT compilation?

**Just-In-Time (JIT)** compilation is the process of translating Intermediate Language (IL) into native CPU machine code exactly at the moment it is needed, rather than before the application runs.

**Interview Ready Answer:**
- **The Process:** When a method is called for the very first time, the JIT compiler analyzes the IL, optimizes it for the specific hardware architecture (e.g., x64 vs ARM64), compiles it to native code, and stores the native code in memory.
- **The Benefit:** Subsequent calls to that method skip the compilation step and jump directly to the native code, making execution extremely fast. It allows the exact same .dll file to run optimally on a Windows Server and a Linux Raspberry Pi without recompilation.
- **Tiered Compilation:** Modern .NET uses Tiered JIT. It compiles code very quickly at low quality for fast app startup, and then slowly recompiles frequently used methods in the background with high-quality, heavy optimizations.

<a id="q-6-109"></a>
> #### 6.109 Write a custom delegate and event example

**Interview Ready Answer:**
```csharp
// 1. Define the Delegate (The Signature)
public delegate void OrderProcessedHandler(int orderId);

public class OrderService
{
    // 2. Define the Event based on the Delegate
    public event OrderProcessedHandler OnOrderProcessed;

    public void ProcessOrder(int orderId)
    {
        Console.WriteLine($"Processing Order {orderId}...");
        
        // 3. Raise the Event safely
        OnOrderProcessed?.Invoke(orderId);
    }
}

public class EmailService
{
    public void Subscribe(OrderService service)
    {
        // 4. Subscribe to the Event
        service.OnOrderProcessed += SendEmail;
    }

    private void SendEmail(int orderId)
    {
        Console.WriteLine($"Email sent for Order {orderId}");
    }
}
```

<a id="q-6-110"></a>
> #### 6.110 Demonstrate the difference between `throw` and `throw ex`

**Interview Ready Answer:**
```csharp
public void MethodA()
{
    try 
    {
        MethodB();
    } 
    catch (Exception ex) 
    {
        // BAD PRACTICE: Wipes out MethodB from the stack trace
        throw ex; 

        // GOOD PRACTICE: Preserves the entire stack trace
        throw; 
    }
}

public void MethodB()
{
    // The actual source of the error
    throw new DivideByZeroException("Oops");
}
```

<a id="q-6-111"></a>
> #### 6.111 Write an example using `Task.WhenAll()`

**Interview Ready Answer:**
```csharp
public async Task ProcessMultipleUsersAsync()
{
    var userIds = new List<int> { 1, 2, 3 };
    var downloadTasks = new List<Task<string>>();

    foreach (var id in userIds)
    {
        // Initiate the tasks, but do NOT await them inside the loop
        downloadTasks.Add(DownloadUserDataAsync(id));
    }

    // Await all of them simultaneously in parallel
    string[] results = await Task.WhenAll(downloadTasks);
    
    Console.WriteLine($"Downloaded {results.Length} users.");
}

private async Task<string> DownloadUserDataAsync(int id)
{
    await Task.Delay(1000); // Simulate network call
    return $"Data for {id}";
}
```

<a id="q-6-112"></a>
> #### 6.112 Explain the output of async/await execution flow snippets

**Interview Ready Answer:**
*(Interviewers often show a snippet with mixed synchronous and asynchronous code. The key is to remember that `await` yields control back to the caller).*

```csharp
public async Task RunSnippets()
{
    Console.WriteLine("1. Start");
    await DoWorkAsync();
    Console.WriteLine("4. End");
}

public async Task DoWorkAsync()
{
    Console.WriteLine("2. Before Await");
    await Task.Delay(1000); // Returns control to RunSnippets caller here
    Console.WriteLine("3. After Await");
}
```
**Output Order:**
1. Start
2. Before Await
*(Thread yields, UI remains responsive for 1000ms)*
3. After Await
4. End

**[⬆ Back to Top](#table-of-contents)**

<a id="section-7"></a>
## 7. ASP.NET Core and APIs

<a id="q-7-1"></a>
> #### 7.1 What is REST?

**REST (Representational State Transfer)** is an architectural style for designing networked applications, most commonly web APIs.

**Interview Ready Answer:**
- **The Concept:** REST relies on a stateless, client-server, cacheable communications protocol — almost always HTTP. 
- **Resource-Based:** Instead of viewing the API as a collection of functions (e.g., `GetUserData()`), REST views the API as a collection of **Resources** (e.g., `/users/123`), manipulated via standard HTTP methods.

<a id="q-7-2"></a>
> #### 7.2 What are REST principles?

**Interview Ready Answer:**
To be considered truly "RESTful", an API must adhere to six architectural constraints:
1. **Client-Server:** Separation of concerns between the UI/frontend and the data storage/backend.
2. **Stateless:** Every HTTP request from the client must contain all information necessary to understand and process the request. The server cannot rely on stored session state.
3. **Cacheable:** Responses must implicitly or explicitly define themselves as cacheable or not to improve performance.
4. **Uniform Interface:** A standardized way of communicating (e.g., using standard HTTP verbs and URIs).
5. **Layered System:** The client shouldn't know if it's connected directly to the end server or to an intermediary (like a load balancer or proxy).
6. **Code on Demand (Optional):** The server can temporarily extend the client's functionality by transferring executable code (e.g., JavaScript).

<a id="q-7-3"></a>
> #### 7.3 Difference between GET, POST, PUT, PATCH, and DELETE?

**Interview Ready Answer:**
| Verb | Purpose | Idempotent |
|---|---|---|
| **GET** | Retrieves a resource without modifying anything. | Yes |
| **POST** | Creates a **new** resource. (e.g., creating a new user). | No |
| **PUT** | **Replaces** an entire existing resource. If it doesn't exist, it might create it. | Yes |
| **PATCH** | **Partially updates** an existing resource (e.g., updating just the user's email). | No (typically) |
| **DELETE**| Removes a resource. | Yes |

*(Note: "Idempotent" means making the exact same request multiple times has the exact same effect as making it once).*

<a id="q-7-4"></a>
> #### 7.4 What is IActionResult?

**Interview Ready Answer:**
- **Definition:** `IActionResult` is an interface in ASP.NET Core that represents the result of an HTTP request.
- **Flexibility:** It allows a single controller method to return multiple different types of HTTP responses depending on business logic. For example, returning `Ok()` (200), `NotFound()` (404), or `BadRequest()` (400) from the exact same method.

<a id="q-7-5"></a>
> #### 7.5 Difference between IActionResult and ActionResult?

**Interview Ready Answer:**
- **`IActionResult` (Interface):** Used when the method needs to return different HTTP status codes, but the *type* of data returned isn't explicitly defined in the signature. (e.g., `public IActionResult GetUser()`). This makes Swagger documentation harder.
- **`ActionResult<T>` (Class):** Introduced in ASP.NET Core 2.1. It combines the flexibility of returning HTTP status codes with a strongly-typed payload (e.g., `public ActionResult<User> GetUser()`). This allows Swagger to automatically infer that this endpoint returns a `User` object, while still allowing you to return `NotFound()`.

<a id="q-7-6"></a>
> #### 7.6 What are common HTTP status codes?

**Interview Ready Answer:**
- **2xx (Success):** 
  - `200 OK`: Standard success.
  - `201 Created`: Resource successfully created (usually from POST).
  - `204 No Content`: Success, but no data returned (often from DELETE or PUT).
- **4xx (Client Error - The caller messed up):**
  - `400 Bad Request`: Invalid JSON, missing parameters.
  - `401 Unauthorized`: Missing or invalid authentication token.
  - `403 Forbidden`: Authenticated, but lacking permissions to access the resource.
  - `404 Not Found`: Resource does not exist.
- **5xx (Server Error - The API messed up):**
  - `500 Internal Server Error`: Unhandled exception in the backend code.
  - `502 Bad Gateway`: Proxy/load balancer couldn't reach the backend server.

<a id="q-7-7"></a>
> #### 7.7 Difference between authentication and authorization?

**Interview Ready Answer:**
- **Authentication (AuthN):** Proving **who you are**. (e.g., Logging in with a username/password to get a JWT token). "I am User 123."
- **Authorization (AuthZ):** Proving **what you are allowed to do**. (e.g., Checking if User 123 has the "Admin" role before allowing them to delete a record). "Do I have permission to do this?"

<a id="q-7-8"></a>
> #### 7.8 What is JWT?

**JSON Web Token (JWT)** is an open standard for securely transmitting information between parties as a JSON object.

**Interview Ready Answer:**
- **Structure:** It consists of three parts separated by dots: `Header.Payload.Signature`.
  - **Header:** Algorithm and token type.
  - **Payload:** The "Claims" (e.g., User ID, Roles, Expiration Time). **Note:** This is base64 encoded, *not encrypted*. Anyone can read it.
  - **Signature:** A cryptographic hash created using a secret key held only by the server. 
- **Validation:** When the client sends the JWT, the server recalculates the signature. If it matches, the server knows the token is valid and hasn't been tampered with. It enables stateless authentication because the server doesn't need to query a database to verify the user; all the proof is in the token itself.

<a id="q-7-9"></a>
> #### 7.9 Claims-based vs policy-based authorization?

**Interview Ready Answer:**
- **Claims-based Authorization:** You check if the user has a specific piece of information (a "claim"). For example, `[Authorize(Roles = "Admin")]` or checking if the user has a "DateOfBirth" claim.
- **Policy-based Authorization:** A more modern, flexible approach. You define a "Policy" at startup (e.g., "MustBeOver18AndAdmin") which encapsulates multiple claim checks or custom logic. You then apply the policy to the controller: `[Authorize(Policy = "MustBeOver18AndAdmin")]`. It centralizes authorization logic.

<a id="q-7-10"></a>
> #### 7.10 What is middleware?

**Interview Ready Answer:**
- **Definition:** Middleware is software assembled into the application pipeline to handle HTTP requests and responses. 
- **Purpose:** Each piece of middleware can choose to pass the request to the next component in the pipeline or short-circuit it. It is used for cross-cutting concerns like Authentication, Error Handling, CORS, and Routing.

<a id="q-7-11"></a>
> #### 7.11 How does middleware pipeline work?

**Interview Ready Answer:**
- **The Pipeline:** It operates on the "Russian Doll" or "Chain of Responsibility" model. 
- **The Flow:**
  1. A request enters the pipeline.
  2. The first middleware executes. It can perform logic, then call `await next()` to invoke the next middleware.
  3. The request hits the controller (the center of the doll), generates a response.
  4. The response travels back *out* through the middleware pipeline in the reverse order.
- **Short-circuiting:** If a middleware (like Authentication) fails, it can immediately return a 401 response *without* calling `next()`, blocking the rest of the pipeline.

<a id="q-7-12"></a>
> #### 7.12 How do you structure controllers, services, and repositories?

**Interview Ready Answer:**
This is the classic N-Tier or Clean Architecture pattern:
1. **Controllers (Presentation Layer):** Only responsible for HTTP concerns. Routing, reading parameters, and returning HTTP status codes. *No business logic.*
2. **Services (Business Layer):** Contains the core business rules. It is injected into the controller. It validates data, calculates things, and decides what to save.
3. **Repositories (Data Access Layer):** Only responsible for database interactions. Injected into the Service. It hides the ORM (like Entity Framework) or SQL queries from the rest of the app.

<a id="q-7-13"></a>
> #### 7.13 What is model binding?

**Interview Ready Answer:**
- **The Concept:** Model binding is the process where ASP.NET Core automatically extracts data from an incoming HTTP request (from the URL route, query string, or JSON body) and maps it to C# objects (parameters in your controller action).
- **Example:** If a client sends JSON `{ "Name": "John" }`, and your controller takes a `User` object, model binding automatically instantiates the `User` class and sets `User.Name = "John"`.

<a id="q-7-14"></a>
> #### 7.14 What is dependency injection in ASP.NET Core?

**Interview Ready Answer:**
- **Built-In:** ASP.NET Core has a built-in Inversion of Control (IoC) container.
- **The Concept:** Instead of a class creating its own dependencies (e.g., `var repo = new SqlRepository()`), it asks for them in its constructor (`public MyService(IRepository repo)`). The DI container automatically creates and supplies the `SqlRepository` when `MyService` is requested.
- **Lifetimes:** Dependencies are registered as `Transient` (new instance every time), `Scoped` (one instance per HTTP request), or `Singleton` (one instance forever).

<a id="q-7-15"></a>
> #### 7.15 How do you handle exceptions globally?

**Interview Ready Answer:**
- **The Old Way:** Using global exception filters (like `IExceptionFilter`).
- **The Modern Way (Middleware):** We use **Global Exception Handling Middleware**. 
  - Why? Middleware catches exceptions thrown *anywhere* in the application (even outside of controllers).
  - How? You register `app.UseExceptionHandler()` or write custom middleware that wraps the `await next()` in a `try/catch`. If an error is caught, it logs the error, hides the stack trace from the user, and standardizes the response to a `ProblemDetails` JSON object with a 500 status code.

<a id="q-7-16"></a>
> #### 7.16 What is API versioning?

**Interview Ready Answer:**
- **The Concept:** Managing changes to your API over time without breaking existing client applications.
- **How to Implement:** 
  1. **URL Path:** `/api/v1/users` vs `/api/v2/users` (Most common and visible).
  2. **Query String:** `/api/users?version=2.0`.
  3. **Custom Header:** `X-API-Version: 2.0`.
  4. **Accept Header (Content Negotiation):** `Accept: application/vnd.myapi.v2+json`.

<a id="q-7-17"></a>
> #### 7.17 What is CORS?

**CORS (Cross-Origin Resource Sharing)** is a browser security mechanism.

**Interview Ready Answer:**
- **The Problem:** By default, web browsers enforce the Same-Origin Policy. If your frontend is hosted at `frontend.com` and tries to make an AJAX request to your API at `backend.com`, the browser will block the request.
- **The Solution:** CORS allows the backend server to explicitly tell the browser, "It is safe to let `frontend.com` read my data." 
- **Implementation:** In ASP.NET Core, you configure CORS middleware in `Startup.cs` (or `Program.cs`) to add specific `Access-Control-Allow-Origin` HTTP headers to the responses.

<a id="q-7-18"></a>
> #### 7.18 What is Swagger/OpenAPI?

**Interview Ready Answer:**
- **OpenAPI:** A language-agnostic specification for describing RESTful APIs. It defines how to write a JSON/YAML file that explains exactly what endpoints exist, what parameters they take, and what they return.
- **Swagger:** A suite of tools (like Swashbuckle in .NET) that automatically generates the OpenAPI JSON specification directly from your C# controller code and XML comments. It also provides a built-in UI page to test the endpoints without using Postman.

<a id="q-7-19"></a>
> #### 7.19 How do microservices communicate?

**Interview Ready Answer:**
- **Synchronous Communication:** Services call each other directly, waiting for a response. Usually done via HTTP/REST or **gRPC** (which is much faster and uses protocol buffers).
- **Asynchronous Communication (Event-Driven):** Services do not call each other directly. Instead, Service A publishes an event to a Message Broker (like RabbitMQ, Kafka, or Azure Service Bus). Service B listens to that broker, picks up the message, and processes it later. This prevents the entire system from crashing if one service goes down.

<a id="q-7-20"></a>
> #### 7.20 What is microservice architecture?

**Interview Ready Answer:**
- **The Concept:** Breaking down a large, monolithic application into small, independent, loosely coupled services. 
- **Characteristics:**
  - Each service owns its own database (Database per Service pattern).
  - Each service is responsible for exactly one business domain (e.g., Orders Service, Inventory Service).
  - Services can be written in different languages and scaled independently.
- **The Trade-off:** It drastically increases deployment complexity, debugging difficulty, and network latency compared to a monolith.

<a id="q-7-21"></a>
> #### 7.21 Difference between `IActionResult` and `ActionResult<T>`

**Interview Ready Answer:**
*(Note: Similar to Q7.5, but worth reiterating from a type-safety perspective).*
- **`IActionResult`:** Requires you to use the `[ProducesResponseType]` attribute on the controller method to tell Swagger what type of object is actually returned, because the method signature doesn't say.
- **`ActionResult<T>`:** Implicitly tells the compiler and Swagger exactly what data type is returned (`T`). You don't need `[ProducesResponseType]` for the 200 OK success case anymore, keeping the code much cleaner.

<a id="q-7-22"></a>
> #### 7.22 When should you use `ActionResult<T>`?

**Interview Ready Answer:**
- You should use `ActionResult<T>` by default for almost all modern ASP.NET Core API endpoints. 
- It provides the perfect balance: the flexibility to return a `404 NotFound()` when data is missing, while also providing compile-time type safety and automatic OpenAPI documentation for the success payload.

<a id="q-7-23"></a>
> #### 7.23 Advantages of strongly typed API responses

**Interview Ready Answer:**
- **Automated Documentation:** Swagger can accurately generate schemas for the frontend teams.
- **Client Generation:** Tools like NSwag or AutoRest can read the API and automatically generate strongly typed C# or TypeScript client SDKs.
- **Refactoring:** If you change the shape of the return object, the compiler will catch mismatched types immediately, whereas returning generic `Ok(someAnonymousObject)` will fail silently until runtime.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-8"></a>
## 8. LINQ and Collections

<a id="q-8-1"></a>
> #### 8.1 What is LINQ?

**LINQ (Language Integrated Query)** is a set of features in C# that provides powerful query capabilities directly into the language syntax.

**Interview Ready Answer:**
- **The Concept:** It allows developers to query strongly-typed collections of data (like Lists, XML, or SQL Databases) using a standardized, SQL-like declarative syntax directly in C#.
- **Why it matters:** Before LINQ, querying a `List<User>` required writing manual `foreach` loops with `if` statements. LINQ condenses this into highly readable, declarative, and chainable extension methods (e.g., `users.Where(u => u.Age > 18).OrderBy(u => u.Name)`).

<a id="q-8-2"></a>
> #### 8.2 Difference between LINQ to Objects and LINQ to Entities

**Interview Ready Answer:**
- **LINQ to Objects (`IEnumerable<T>`):** Used for querying in-memory collections (like `List` or `Array`). The C# compiler executes the queries locally in memory using .NET's `System.Linq` extension methods (which are usually backed by state machines and delegates).
- **LINQ to Entities (`IQueryable<T>`):** Used with Entity Framework. The query is *not* executed in memory immediately. Instead, the expression tree is translated into an optimized native SQL string (e.g., `SELECT * FROM ...`) and executed directly on the SQL Server.

<a id="q-8-3"></a>
> #### 8.3 What LINQ methods have you used?

**Interview Ready Answer:**
*(Be prepared to mention standard extension methods and what they do).*
- **Filtering:** `Where()`, `OfType()`
- **Projection:** `Select()`, `SelectMany()`
- **Aggregation:** `Count()`, `Sum()`, `Average()`, `Min()`, `Max()`
- **Sorting:** `OrderBy()`, `OrderByDescending()`, `ThenBy()`
- **Partitioning:** `Take()`, `Skip()` (Crucial for pagination).
- **Element Operators:** `First()`, `FirstOrDefault()`, `Single()`, `SingleOrDefault()`

<a id="q-8-4"></a>
> #### 8.4 How do joins work in LINQ?

**Interview Ready Answer:**
- **Inner Join:** The standard `Join()` method correlates elements of two sequences based on matching keys. It returns a flat sequence containing only the elements that have matches in both collections.
- **Group Join:** The `GroupJoin()` method correlates elements but groups the results. It is essentially a "Left Outer Join". It returns a hierarchical sequence where each element from the first collection is paired with a collection of matching elements from the second (even if that collection is empty).

<a id="q-8-5"></a>
> #### 8.5 What is GroupBy in LINQ?

**Interview Ready Answer:**
- **The Concept:** `GroupBy()` takes a flat sequence and organizes it into groups based on a specified key.
- **Return Type:** It returns an `IEnumerable<IGrouping<TKey, TElement>>`. Each `IGrouping` acts like a list that also possesses a `Key` property.
- **Example:** `users.GroupBy(u => u.Country)` will group users by their country. You can then iterate over the groups, using the `Key` (Country Name) and iterating through the specific users in that group.

<a id="q-8-6"></a>
> #### 8.6 Difference between `Select` and `SelectMany`

**Interview Ready Answer:**
- **`Select` (Map):** A 1-to-1 projection. If you have 10 Users, `Select(u => u.Name)` returns exactly 10 strings. If you use `Select(u => u.PhoneNumbers)`, it returns a "List of Lists".
- **`SelectMany` (Flatten):** A 1-to-Many projection that flattens nested collections. If 10 Users each have 3 PhoneNumbers, `SelectMany(u => u.PhoneNumbers)` flattens the hierarchy and returns exactly 30 individual PhoneNumbers in a single, flat 1-dimensional list.

<a id="q-8-7"></a>
> #### 8.7 Difference between `First`, `FirstOrDefault`, and `Single`

**Interview Ready Answer:**
| Method | If sequence is empty | If exactly 1 match | If > 1 matches | Use Case |
|---|---|---|---|---|
| **`First()`** | Throws Exception | Returns element | Returns first element | When you *expect* at least one item to exist. |
| **`FirstOrDefault()`**| Returns `null` (or default) | Returns element | Returns first element | Safe retrieval. You don't know if the item exists. |
| **`Single()`** | Throws Exception | Returns element | **Throws Exception** | When there *must* be exactly one strictly unique item. |

<a id="q-8-8"></a>
> #### 8.8 When should you use `Single` over `FirstOrDefault`?

**Interview Ready Answer:**
- **The Core Reason:** Use `Single()` or `SingleOrDefault()` when business logic strictly dictates that a collection **must not** contain duplicates for the given criteria. 
- **Example:** Querying a database by a unique `UserId` or `EmailAddress`. If the database somehow returns two rows for the same `UserId`, your data is catastrophically corrupted. `Single()` will instantly throw an exception and halt the application, alerting you to the data corruption. `FirstOrDefault()` would silently hide the corruption by just grabbing the first row.

<a id="q-8-9"></a>
> #### 8.9 What is deferred execution in LINQ?

**Interview Ready Answer:**
- **The Concept:** Deferred execution means that the query is **not** executed at the point where it is defined. Instead, the query variable only stores the *logic* of the command.
- **How it works:** When you write `var query = users.Where(u => u.Active);`, no filtering actually happens yet. The query is only executed when you actually start iterating over the results (e.g., in a `foreach` loop).

<a id="q-8-10"></a>
> #### 8.10 Advantages and disadvantages of deferred execution

**Interview Ready Answer:**
- **Advantages:**
  - **Efficiency:** You can build complex, multi-step queries without executing them until the final result is needed.
  - **Always Fresh Data:** Since the query executes at the moment of iteration, it will include any items added to the underlying collection *after* the query was defined but *before* it was iterated.
- **Disadvantages:**
  - **Side Effects:** If the underlying collection changes unexpectedly before iteration, you might get results you didn't anticipate.
  - **Performance Gotchas:** If you iterate over the same query variable three times, the entire filtering logic runs three times.

<a id="q-8-11"></a>
> #### 8.11 When does a LINQ query execute?

**Interview Ready Answer:**
A LINQ query executes in two main scenarios:
1. **Iterating over the query:** Using a `foreach` loop.
2. **Calling a conversion/element operator:** Methods like `ToList()`, `ToArray()`, `ToDictionary()`, `First()`, `Count()`, or `Any()`. These methods force the query to execute immediately to produce a result.

<a id="q-8-12"></a>
> #### 8.12 What does `ToList()` do internally?

**Interview Ready Answer:**
- **Execution:** It forces the immediate execution of a deferred LINQ query.
- **Caching:** It iterates through the entire source collection, evaluates all filters/projections, and stores the resulting elements into a **new** `List<T>` object in memory. 
- **Snapshot:** Once `ToList()` is called, the data is "snapshotted." Changes to the original source collection will no longer be reflected in the list.

<a id="q-8-13"></a>
> #### 8.13 Difference between `IEnumerable` and `IQueryable`

**Interview Ready Answer:**
- **`IEnumerable<T>` (Client-Side):** Used for in-memory collections. When you filter an `IEnumerable`, the data is loaded into memory first, and the filtering happens on the app server using delegates.
- **`IQueryable<T>` (Server-Side):** Used for out-of-memory data (like a SQL database). It stores the query as an **Expression Tree**. When executed, the provider translates this tree into a single, optimized SQL query that runs on the database server.
- **The Big Difference:** `IEnumerable` brings the whole table to the app and filters it. `IQueryable` filters the data on the database and only brings the results to the app.

<a id="q-8-14"></a>
> #### 8.14 Why is `IEnumerable` preferred in some method signatures?

**Interview Ready Answer:**
- **Abstraction:** It is the most basic interface for a collection. Using `IEnumerable<T>` allows your method to accept a `List<T>`, `Array`, `HashSet<T>`, or even the results of a LINQ query without caring about the underlying implementation.
- **Read-Only Intent:** It signals to the caller that the method only intends to iterate over the data, not modify, add, or remove items from the original collection.

<a id="q-8-15"></a>
> #### 8.15 Why should repositories return `IQueryable` carefully?

**Interview Ready Answer:**
- **The "Leaky Abstraction" Problem:** If a repository returns `IQueryable`, it gives the Service layer the power to add more filters (like `.Where()` or `.Include()`). This might result in generating extremely inefficient SQL that the repository author never intended.
- **Unit of Work Issues:** A query might fail late in the Service layer after the database context has already been disposed, leading to "ObjectDisposedException".
- **Best Practice:** Many architects prefer repositories to return `IEnumerable` or a materialized `List` to ensure the repository has full control over the query execution and performance.

<a id="q-8-16"></a>
> #### 8.16 Difference between `IEnumerable` and `List`

**Interview Ready Answer:**
- **`IEnumerable<T>`:** An interface that only supports one-way, forward-only iteration. It is **Lazy**. It doesn't store the data; it only knows how to get it.
- **`List<T>`:** A concrete class that stores data in memory. it is **Eager**. It supports random access (indexing), adding, removing, and sorting.
- **Comparison:** Think of `IEnumerable` as a "recipe" to make a cake, and `List` as the "actual cake" sitting on the table.

<a id="q-8-17"></a>
> #### 8.17 Difference between arrays and collections

**Interview Ready Answer:**
- **Arrays (`T[]`):** Fixed size upon creation. Once you create an array of 5 items, you cannot make it 6. It is a lower-level construct and slightly more memory-efficient.
- **Collections (`List<T>`, etc.):** Dynamic size. You can add or remove items as needed. Internally, a `List<T>` uses an array that it automatically resizes (doubles in size) when it reaches capacity.

<a id="q-8-18"></a>
> #### 8.18 Is `List<T>` a value type or reference type? Why?

**Interview Ready Answer:**
- **Reference Type:** `List<T>` is a **class**.
- **Reason:** It is stored on the Managed Heap. When you pass a list to a method, you are passing a reference (memory address) to that list, not a copy of the list itself. If the method modifies the list, the caller sees those changes.

<a id="q-8-19"></a>
> #### 8.19 Why do generics improve performance compared to non-generic collections?

**Interview Ready Answer:**
- **Eliminates Boxing/Unboxing:** In non-generic collections (like `ArrayList`), every value type (like `int`) must be boxed into an `object` to be stored, and unboxed when retrieved. This is extremely slow and causes heavy GC pressure. Generics allow the CLR to store value types directly.
- **Eliminates Casting:** Non-generic collections return `object`, requiring an explicit cast to the actual type (e.g., `(User)list[0]`). Generics are strongly typed, so no casting is needed.

<a id="q-8-20"></a>
> #### 8.20 Difference between `List`, `Dictionary`, and `HashSet`

**Interview Ready Answer:**
- **`List<T>`:** An ordered collection of items. Allows duplicates. Accessed by index (e.g., `list[0]`).
- **`Dictionary<TKey, TValue>`:** A collection of Key-Value pairs. Keys must be unique. Optimized for extremely fast lookups by key.
- **`HashSet<T>`:** An unordered collection of unique items. Optimized for checking if an item exists and performing set operations (Union, Intersect).

<a id="q-8-21"></a>
> #### 8.21 When should you use `HashSet` over `List`?

**Interview Ready Answer:**
- **Uniqueness:** Use `HashSet` when you need to ensure every item in the collection is strictly unique.
- **Performance:** Use `HashSet` when you frequently need to check if an item exists (`.Contains()`). 
  - `List.Contains()` is **O(N)** (it has to check every item one by one).
  - `HashSet.Contains()` is **O(1)** (it uses a hash code to jump directly to the item).

<a id="q-8-22"></a>
> #### 8.22 Internal working of `Dictionary<TKey, TValue>`

**Interview Ready Answer:**
- **Hashing:** When you add a key, the dictionary calls `key.GetHashCode()`.
- **Buckets:** It applies a modulo operation to the hash code to determine which "bucket" the value belongs in.
- **Collision Handling:** If two keys land in the same bucket (a collision), the dictionary uses a linked list (or a similar structure) within that bucket and uses `key.Equals()` to find the exact matching key.

<a id="q-8-23"></a>
> #### 8.23 Time complexities of common collection operations

**Interview Ready Answer:**
| Operation | `List<T>` | `Dictionary<TKey, TValue>` | `HashSet<T>` |
|---|---|---|---|
| **Add** | O(1) average / O(N) if resize | O(1) | O(1) |
| **Lookup by Index/Key** | O(1) | O(1) | N/A |
| **Contains (Lookup by Value)**| **O(N)** | N/A | **O(1)** |
| **Remove** | O(N) | O(1) | O(1) |

<a id="q-8-24"></a>
> #### 8.24 What is lazy loading?

**Interview Ready Answer:**
- **Definition:** Lazy loading is a design pattern that delays the initialization of an object or the loading of data until the exact moment it is actually needed.
- **In .NET:** Often implemented using the `Lazy<T>` class or via `IEnumerable` deferred execution.
- **In EF Core:** It means that "Navigation Properties" (like `User.Orders`) are not loaded from the database until you actually try to access the `Orders` property in your code.

<a id="q-8-25"></a>
> #### 8.25 Write a LINQ query and explain deferred execution

**Interview Ready Answer:**
```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };

// 1. Query Definition (Nothing happens here yet)
var query = numbers.Where(n => n > 3);

// 2. Modify source after query definition
numbers.Add(6);

// 3. Execution (Iterating)
// This will output 4, 5, 6 because the query 
// only executes right now.
foreach(var n in query) {
    Console.WriteLine(n);
}
```

**[⬆ Back to Top](#table-of-contents)**

<a id="section-9"></a>
## 9. SQL

<a id="q-9-1"></a>
> #### 9.1 Difference between UNION and UNION ALL?

**Interview Ready Answer:**
- **`UNION`:** Combines the result sets of two or more SELECT statements and **removes duplicate rows**. It is slower because the database must perform a distinct sort operation to identify and delete duplicates.
- **`UNION ALL`:** Combines the result sets and **includes duplicates**. it is significantly faster because the database simply appends the results together without any extra processing.

<a id="q-9-2"></a>
> #### 9.2 Explain INNER JOIN.

**Interview Ready Answer:**
- **Definition:** The most common type of join. It returns only the rows where there is a **match in both tables**.
- **Example:** If you join `Orders` and `Customers`, an INNER JOIN will only return orders that have a valid customer associated with them, and only customers who have placed at least one order.

<a id="q-9-3"></a>
> #### 9.3 Explain LEFT JOIN.

**Interview Ready Answer:**
- **Definition:** Returns **all rows from the left table**, and the matched rows from the right table. 
- **Missing Data:** If there is no match in the right table, the result set will contain `NULL` for every column coming from the right table.
- **Example:** A `Customers` LEFT JOIN `Orders` will return every single customer in your database, even if they have never placed an order.

<a id="q-9-4"></a>
> #### 9.4 Explain RIGHT JOIN.

**Interview Ready Answer:**
- **Definition:** The exact opposite of a LEFT JOIN. It returns **all rows from the right table**, and the matched rows from the left table.
- **Missing Data:** If there is no match in the left table, the result will contain `NULL` for the left table's columns.
- **Note:** In practice, most developers stick to LEFT JOINs and simply swap the table order for better readability.

<a id="q-9-5"></a>
> #### 9.5 Explain FULL OUTER JOIN.

**Interview Ready Answer:**
- **Definition:** Returns a row when there is a match in **either** the left or the right table. 
- **Result:** It is essentially a combination of a LEFT JOIN and a RIGHT JOIN. It contains every record from both tables, filling in `NULL`s wherever a match is missing on either side.

<a id="q-9-6"></a>
> #### 9.6 Difference between Primary Key and Unique Key?

**Interview Ready Answer:**
| Feature | Primary Key | Unique Key |
|---|---|---|
| **Purpose** | Uniquely identifies a row in a table. | Ensures data in a column is unique. |
| **NULL values** | **Strictly not allowed.** | Allows exactly one `NULL` value (in SQL Server). |
| **Limit** | Exactly one per table. | Multiple unique keys allowed per table. |
| **Index** | Automatically creates a Clustered Index. | Automatically creates a Non-Clustered Index. |

<a id="q-9-7"></a>
> #### 9.7 What are indexes?

**Interview Ready Answer:**
- **Definition:** A database index is a data structure (usually a B-Tree) that improves the speed of data retrieval operations on a table at the cost of additional storage space and slower write operations.
- **Analogy:** Think of an index like the **Index at the back of a textbook**. instead of reading every single page to find "Garbage Collection," you look at the index, find the page number, and jump directly there.

<a id="q-9-8"></a>
> #### 9.8 Difference between clustered and non-clustered index?

**Interview Ready Answer:**
- **Clustered Index:** Physically reorders the rows in the table to match the index. The leaf nodes of a clustered index contain the **actual data rows**. 
- **Non-Clustered Index:** Does not change the physical order of the rows. It creates a separate structure that contains a pointer (a row locator) to the actual data.

<a id="q-9-9"></a>
> #### 9.9 How many clustered indexes can a table have?

**Interview Ready Answer:**
- **Exactly One.**
- **Reason:** Since a clustered index determines the physical order of the data on the disk, a table can only be physically sorted in one way.

<a id="q-9-10"></a>
> #### 9.10 What are ranking functions?

**Interview Ready Answer:**
- **Definition:** Ranking functions are window functions in SQL that assign a rank (a number) to each row within a partition of a result set.
- **Syntax:** They are used with the `OVER()` clause, which specifies the ordering and optional partitioning of the data (e.g., `ROW_NUMBER() OVER (ORDER BY Salary DESC)`).

<a id="q-9-11"></a>
> #### 9.11 Difference between ROW_NUMBER, RANK, and DENSE_RANK?

**Interview Ready Answer:**
*(Imagine three employees with salaries: 100, 100, 50).*
- **`ROW_NUMBER()`:** Always unique. Assigns a unique, sequential number to every row (e.g., 1, 2, 3).
- **`RANK()`:** Skips ranks for ties. If two people tie for 1st, the next person is 3rd (e.g., 1, 1, 3).
- **`DENSE_RANK()`:** Does not skip ranks for ties. If two people tie for 1st, the next person is 2nd (e.g., 1, 1, 2).

<a id="q-9-12"></a>
> #### 9.12 What are stored procedures?

**Interview Ready Answer:**
- **Definition:** A stored procedure is a group of one or more SQL statements that are compiled and stored on the database server.
- **Advantages:** 
  - **Performance:** They are pre-compiled, reducing parsing and execution time.
  - **Security:** They prevent SQL Injection by forcing the use of parameters.
  - **Network Traffic:** You only send the name of the procedure and parameters over the network, not the entire long SQL script.

<a id="q-9-13"></a>
> #### 9.13 Difference between procedure and function?

**Interview Ready Answer:**
| Feature | Stored Procedure | Function (UDF) |
|---|---|---|
| **Return Value** | Can return multiple values (via `OUT` parameters) or none. | **Must** return exactly one value (or a table). |
| **Parameters** | Supports `IN` and `OUT` parameters. | Supports only `IN` parameters. |
| **Side Effects** | Can modify database state (INSERT, UPDATE, DELETE). | **Cannot** modify database state. |
| **Usage** | Called using `EXEC`. | Can be called directly inside a `SELECT` statement. |

<a id="q-9-14"></a>
> #### 9.14 What are table-valued functions?

**Interview Ready Answer:**
- **Definition:** A user-defined function that returns a result set in the form of a table.
- **Types:** 
  - **Inline TVF:** Contains a single `SELECT` statement. It is extremely fast because the SQL optimizer treats it like a View.
  - **Multi-statement TVF:** Contains multiple logic blocks and manual table population. Slower but more flexible.

<a id="q-9-15"></a>
> #### 9.15 What is normalization?

**Interview Ready Answer:**
- **Definition:** The process of organizing data in a database to reduce redundancy and improve data integrity.
- **Goals:** 
  - Eliminating duplicate data (storing "Customer Name" once in a Customers table, not in every Order row).
  - Ensuring data dependencies make sense (storing data where it logically belongs).
- **Stages:** Typically achieved through "Normal Forms" (1NF, 2NF, 3NF).

<a id="q-9-16"></a>
> #### 9.16 What is denormalization?

**Interview Ready Answer:**
- **Definition:** The intentional process of adding redundant data back into a database.
- **Purpose:** To **improve read performance**. By storing pre-calculated data or combining tables, you can avoid expensive `JOIN` operations.
- **Trade-off:** It makes writes slower and more complex because you have to update the same piece of data in multiple places to maintain consistency.

<a id="q-9-17"></a>
> #### 9.17 What is a CTE?

**Common Table Expression (CTE)** is a temporary result set that you can reference within another SELECT, INSERT, UPDATE, or DELETE statement.

**Interview Ready Answer:**
- **Syntax:** Defined using the `WITH` keyword.
- **Advantage:** Unlike subqueries, CTEs make the code significantly more readable. They can also be **Recursive**, allowing you to query hierarchical data like organizational charts or folder structures.

<a id="q-9-18"></a>
> #### 9.18 What are aggregate functions?

**Interview Ready Answer:**
- **Definition:** Functions that perform a calculation on a set of values and return a single scalar value.
- **Examples:** `COUNT()`, `SUM()`, `AVG()`, `MIN()`, `MAX()`.
- **Usage:** They are almost always used with the `GROUP BY` clause to calculate values across different categories.

<a id="q-9-19"></a>
> #### 9.19 What is pagination?

**Interview Ready Answer:**
- **Definition:** The process of dividing a large result set into smaller, manageable "pages" to improve application performance and user experience.
- **Implementation (SQL Server):** Usually achieved using the `OFFSET` and `FETCH NEXT` clauses.
- **Example:** `SELECT * FROM Users ORDER BY Id OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;` (This skips the first 10 rows and takes the next 10, effectively getting Page 2).

<a id="q-9-20"></a>
> #### 9.20 What causes slow queries?

**Interview Ready Answer:**
- **Missing Indexes:** The database has to perform a full table scan.
- **Large Joins:** Joining massive tables without proper filtering or indexed columns.
- **Data Volume:** Tables growing so large that standard queries become inefficient.
- **Blocking/Deadlocks:** Other queries holding locks on the data you need.
- **Inefficient SQL:** Using `SELECT *`, non-SARGable queries (e.g., using functions in the `WHERE` clause like `WHERE YEAR(Date) = 2023`), or unnecessary subqueries.

<a id="q-9-21"></a>
> #### 9.21 How do you optimize SQL queries?

**Interview Ready Answer:**
1. **Execution Plan:** Use `EXPLAIN` or "Display Estimated Execution Plan" to see how the database is actually retrieving data.
2. **Indexing:** Add missing indexes (Clustered/Non-Clustered/Filtered).
3. **Avoid SELECT *:** Retrieve only the specific columns you need to reduce network traffic and memory usage.
4. **SARGable Queries:** Avoid functions on the left side of the `WHERE` clause so the database can use an index.
5. **Use CTEs/Temp Tables:** Break complex logic into smaller, more readable steps.
6. **Update Statistics:** Ensure the database optimizer has accurate information about the data distribution.

<a id="q-9-22"></a>
> #### 9.22 What is index seek vs index scan?

**Interview Ready Answer:**
- **Index Seek (Good):** The database uses the B-Tree structure of the index to jump directly to the specific rows it needs. It is very fast.
- **Index Scan (Bad/Slower):** The database has to read the *entire* index from beginning to end because it couldn't find a direct way to the data (often caused by non-SARGable queries).  

<a id="q-9-23"></a>
> #### 9.23 Why is SELECT * bad?

**Interview Ready Answer:**
- **Performance:** It retrieves more data than necessary, increasing I/O, memory usage, and network latency.
- **Index Usage:** It can prevent the database from using a "Covering Index" (where all requested columns are already in the index).
- **Brittleness:** If a column is added or renamed in the database, your application code might break if it expects a specific column count or order.

<a id="q-9-24"></a>
> #### 9.24 What is deadlock in SQL?

**Interview Ready Answer:**
- **Definition:** A situation where two or more transactions are waiting for each other to release locks, creating a circular dependency where nobody can proceed.
- **Example:** 
  - Transaction A locks Table 1 and wants Table 2.
  - Transaction B locks Table 2 and wants Table 1.
- **Resolution:** The SQL Server "Deadlock Monitor" detects the cycle, chooses one transaction as a "Deadlock Victim," kills it, and rolls back its changes so the other can finish.

<a id="q-9-25"></a>
> #### 9.25 What is transaction?

**Interview Ready Answer:**
- **Definition:** A single unit of work that contains one or more SQL statements.
- **All or Nothing:** It ensures that either all the statements succeed and are "Committed" to the database, or if any fail, the entire sequence is "Rolled Back" to its original state, leaving no partial data.

<a id="q-9-26"></a>
> #### 9.26 What are ACID properties?

**ACID** is a set of properties that guarantee database transactions are processed reliably.

**Interview Ready Answer:**
- **Atomicity:** "All or nothing." If one part of the transaction fails, the whole thing is aborted.
- **Consistency:** A transaction takes the database from one valid state to another valid state, ensuring all constraints (like Foreign Keys) are maintained.
- **Isolation:** Transactions happen independently. One transaction cannot see the intermediate, uncommitted data of another.
- **Durability:** Once a transaction is committed, it stays committed even in the event of a power failure or system crash.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-10"></a>
## 10. Frontend: Angular and React

### Angular

<a id="q-10-1"></a>
> #### 10.1 What is two-way binding?

**Interview Ready Answer:**
- **The Concept:** Two-way data binding means that any changes made to the Model (the TypeScript class variable) are automatically reflected in the View (the HTML template), and vice-versa.
- **Syntax:** In Angular, this is achieved using the "Banana-in-a-box" syntax: `[(ngModel)]`.

<a id="q-10-2"></a>
> #### 10.2 What are components?

**Interview Ready Answer:**
- **Definition:** Components are the basic building blocks of an Angular application. 
- **Structure:** Every component consists of:
  - An **HTML template** for the UI.
  - A **TypeScript class** for logic.
  - A **CSS file** for styling.
  - A **Decorator** (`@Component`) that links these files together and defines the selector.

<a id="q-10-3"></a>
> #### 10.3 What are services?

**Interview Ready Answer:**
- **Definition:** A class used to share data or logic across multiple components.
- **Purpose:** Services follow the Single Responsibility Principle. They are used for tasks like fetching data from an API, logging, or shared business logic, keeping the components focused only on the UI.
- **DI:** Services are typically injected into components using Angular's built-in Dependency Injection.

<a id="q-10-4"></a>
> #### 10.4 What are pipes?

**Interview Ready Answer:**
- **Definition:** Pipes are simple functions used in Angular templates to transform and format data before it is displayed to the user.
- **Built-in Examples:** `date`, `uppercase`, `currency`, `json`.
- **Usage:** `{{ birthday | date:'shortDate' }}`.

<a id="q-10-5"></a>
> #### 10.5 What are custom pipes?

**Interview Ready Answer:**
- **The Concept:** You can create your own pipe by implementing the `PipeTransform` interface and using the `@Pipe` decorator.
- **Purpose:** Useful for reusable UI logic like "Shortening a long description" or "Filtering a list based on user input".

<a id="q-10-6"></a>
> #### 10.6 Difference between template-driven and reactive forms?

**Interview Ready Answer:**
- **Template-driven Forms:** Logic is mostly in the HTML. Easier to use for simple forms. Uses `[(ngModel)]`.
- **Reactive Forms:** Logic is mostly in the TypeScript class. More powerful, easier to test, and better for complex forms with dynamic validation. Uses `FormGroup` and `FormControl`.

<a id="q-10-7"></a>
> #### 10.7 What are RxJS operators?

**Interview Ready Answer:**
- **Definition:** Pure functions that allow you to transform, filter, and combine asynchronous data streams (Observables).
- **Common Operators:** 
  - `map`: Transforms each value.
  - `filter`: Only passes values that meet a condition.
  - `switchMap`: Cancels the previous inner observable and switches to a new one (great for search suggestions).
  - `catchError`: Handles errors in the stream gracefully.

<a id="q-10-8"></a>
> #### 10.8 How does parent-child communication work?

**Interview Ready Answer:**
- **Parent to Child:** The parent passes data using the **`@Input()`** decorator on the child component.
- **Child to Parent:** The child sends notifications or data back to the parent using the **`@Output()`** decorator and an `EventEmitter`.

<a id="q-10-9"></a>
> #### 10.9 How do sibling components communicate?

**Interview Ready Answer:**
- **Shared Service:** The most common way. Both components inject the same service which holds a shared `Subject` or `BehaviorSubject`. One component pushes a new value, and the other component subscribes to it.
- **Parent Mediator:** The components pass data through their common parent using `@Input` and `@Output` (often too complex for deeply nested siblings).

<a id="q-10-10"></a>
> #### 10.10 What are observables?

**Interview Ready Answer:**
- **Definition:** Part of the RxJS library, an Observable is a blueprint for a stream of data that can arrive over time.
- **How they work:** Unlike a Promise (which returns a single value once), an Observable can return multiple values over time. It is **Lazy**; it doesn't do anything until someone calls `.subscribe()` on it.

### React

<a id="q-10-11"></a>
> #### 10.11 Difference between class and functional components?

**Interview Ready Answer:**
- **Class Components:** The older way of writing React. They use ES6 classes, require `this` keyword, and have lifecycle methods like `componentDidMount`.
- **Functional Components:** The modern, standard way. They are just JavaScript functions. With the introduction of **Hooks**, they can now do everything class components can do, but with much less boilerplate code and better readability.

<a id="q-10-12"></a>
> #### 10.12 What are hooks?

**Interview Ready Answer:**
- **Definition:** Hooks are special functions that let you "hook into" React features (like state and lifecycle methods) from functional components.
- **Rule of Hooks:** They must only be called at the top level of your component (not inside loops or conditions) and only from React functional components or custom hooks.

<a id="q-10-13"></a>
> #### 10.13 What is useState?

**Interview Ready Answer:**
- **Definition:** A Hook that allows you to add state (data that changes over time) to a functional component.
- **Usage:** It returns an array with two elements: the current state value and a function to update it.
- **Example:** `const [count, setCount] = useState(0);`

<a id="q-10-14"></a>
> #### 10.14 What is useEffect?

**Interview Ready Answer:**
- **Definition:** A Hook used for performing "side effects" in your components, such as fetching data from an API, manually changing the DOM, or setting up a subscription.
- **Dependency Array:** It takes a second argument (an array). 
  - If empty `[]`, it runs only once (similar to `componentDidMount`).
  - If it contains variables `[id]`, it runs every time those variables change.

<a id="q-10-15"></a>
> #### 10.15 What is useMemo?

**Interview Ready Answer:**
- **Definition:** A Hook used for **memoization** (caching).
- **Purpose:** It recalculates a value only when one of its dependencies has changed. This is used to optimize performance by avoiding expensive calculations on every single render.

<a id="q-10-16"></a>
> #### 10.16 What are props and state?

**Interview Ready Answer:**
- **Props (Properties):** Data passed **into** a component from its parent. Props are **read-only** (immutable) from the child's perspective.
- **State:** Data managed **inside** the component. State is **mutable** (can be changed using a setter function) and determines what the component renders at any given time.

<a id="q-10-17"></a>
> #### 10.17 What is React key?

**Interview Ready Answer:**
- **Definition:** A unique string attribute you must include when creating lists of elements in React.

<a id="q-10-18"></a>
> #### 10.18 Why is key important in lists?

**Interview Ready Answer:**
- **Performance (Reconciliation):** Keys help React identify which items in a list have changed, been added, or been removed. Without unique keys, if you reorder a list, React might re-render every single item from scratch instead of just moving them in the DOM, which is very slow.

<a id="q-10-19"></a>
> #### 10.19 What does map() do in React?

**Interview Ready Answer:**
- **The Concept:** `map()` is a standard JavaScript array method used in React to iterate through an array of data and return an array of JSX elements (like `<li>` or custom components). It is the standard way to render lists in React.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-11"></a>
## 11. System Design, Performance, and Scalability

<a id="q-11-1"></a>
> #### 11.1 How did you improve performance in your project?

**Interview Ready Answer:**
*(Answer this by mentioning specific architectural improvements).*
- **Database Optimization:** Added missing indexes and replaced `SELECT *` with specific columns.
- **Caching:** Implemented **Redis** to store frequently accessed, static data (like configuration or product categories), reducing database hits by 80%.
- **Async Processing:** Moved heavy, non-blocking tasks (like sending emails or generating PDFs) to a background worker using **Hangfire** or **RabbitMQ**.
- **Payload Reduction:** Enabled Gzip/Brotli compression and implemented Pagination for large data lists.

<a id="q-11-2"></a>
> #### 11.2 How do you optimize slow APIs?

**Interview Ready Answer:**
1. **Identify the Bottleneck:** Use a profiler or Application Insights to see if the delay is in the Database, the Network, or the C# code itself.
2. **Database:** Review the execution plan, add indexes, or simplify complex joins.
3. **Caching:** Use Response Caching (browser-level) or Distributed Caching (server-level).
4. **I/O Bound:** Ensure all database and external API calls are using **`async/await`** to free up thread pool threads.
5. **N+1 Problem:** Ensure Entity Framework is using `.Include()` (Eager Loading) instead of making 100 separate database calls for related data.

<a id="q-11-3"></a>
> #### 11.3 How do you reduce payload size?

**Interview Ready Answer:**
- **DTOs:** Instead of returning the full Database Entity, return a lightweight Data Transfer Object (DTO) containing only the fields the frontend actually needs.
- **Compression:** Enable Gzip or Brotli middleware in ASP.NET Core.
- **JSON Serialization:** Use `JsonIgnore` to exclude unnecessary fields.
- **Pagination:** Never return 10,000 rows at once; return 20 at a time.

<a id="q-11-4"></a>
> #### 11.4 How does pagination improve performance?

**Interview Ready Answer:**
- **Lower Memory Usage:** The server doesn't have to load a massive dataset into RAM.
- **Faster Database Retrieval:** The database engine retrieves only a small subset of rows.
- **Reduced Network Latency:** The JSON payload is significantly smaller, leading to faster download times for the client.

<a id="q-11-5"></a>
> #### 11.5 What is lazy loading?

**Interview Ready Answer:**
- **Definition:** Delaying the loading of related data until the moment it is specifically requested in code.
- **Trade-off:** While it saves memory initially, it often leads to the **N+1 Select Problem**, where a simple loop causes hundreds of small database calls, significantly slowing down the application.

<a id="q-11-6"></a>
> #### 11.6 How do you identify bottlenecks?

**Interview Ready Answer:**
- **Logging & Monitoring:** Tools like **Azure Application Insights**, **New Relic**, or **Prometheus/Grafana**.
- **Profiling:** Using **Visual Studio Profiler** or **dotTrace** to find CPU-intensive methods or memory leaks.
- **Database Profiling:** Using **SQL Server Profiler** to find slow-running queries.

<a id="q-11-7"></a>
> #### 11.7 How do you improve scalability?

**Interview Ready Answer:**
- **Horizontal Scaling:** Adding more server instances behind a Load Balancer (Scaling Out).
- **Statelessness:** Ensure the API doesn't store session data in memory so any server can handle any request.
- **Microservices:** Breaking the monolith into smaller services that can be scaled independently based on their specific demand.
- **Database Read Replicas:** Routing read-only queries to secondary database nodes to reduce the load on the primary write node.

<a id="q-11-8"></a>
> #### 11.8 How do you handle high-volume API responses?

**Interview Ready Answer:**
- **Streaming:** Use `IAsyncEnumerable` to stream data to the client as it is read from the database, rather than waiting for the entire list to be loaded into memory.
- **Batch Processing:** Processing and returning data in chunks.
- **Message Queues:** For write-heavy high-volume, accept the request, put it in a queue, and return an immediate `202 Accepted`.

<a id="q-11-9"></a>
> #### 11.9 How do microservices improve scalability?

**Interview Ready Answer:**
- **Independent Scaling:** If the "Order Processing" service is under high load but the "User Profile" service is idle, you only need to scale the Order service, saving significant cloud costs.
- **Resource Specialization:** You can host a memory-intensive service on a high-RAM instance and a CPU-intensive service on a high-CPU instance.

<a id="q-11-10"></a>
> #### 11.10 What causes blocking or waiting issues?

**Interview Ready Answer:**
- **Thread Pool Starvation:** Caused by "Sync-over-Async" (calling `.Result` or `.Wait()` on an async task), which ties up threads needlessly.
- **Database Locks:** Long-running transactions blocking other queries.
- **Slow External APIs:** Waiting for a third-party response without a timeout or asynchronous handling.

<a id="q-11-11"></a>
> #### 11.11 How would you debug slow backend response?

**Interview Ready Answer:**
1. **Check the Network:** Use Browser DevTools (Network tab) to see if it's high latency or a large payload.
2. **Review Logs:** Look at structured logs (Serilog/ELK) for errors or slow transaction timings.
3. **Trace the Request:** Use Distributed Tracing (like **OpenTelemetry**) to see where the time is being spent across different microservices.
4. **Inspect the Database:** Run the query manually with `SET STATISTICS IO, TIME ON` to see disk I/O and CPU time.

<a id="q-11-12"></a>
> #### 11.12 How would you optimize data-heavy dashboards?

**Interview Ready Answer:**
- **Data Aggregation:** Use "Summary Tables" or "Materialized Views" in the database so the dashboard doesn't have to calculate sums/averages on millions of rows every time it loads.
- **Polling vs WebSockets:** Instead of refreshing the whole page, use **SignalR** to push only the small changed data points to the UI.
- **Frontend Optimization:** Use "Virtual Scrolling" to render only the visible rows in a large data table.
- **Cache at the Edge:** Use a CDN or Redis to store the pre-calculated dashboard JSON for a few minutes.

<a id="q-11-13"></a>
> #### 11.13 Monolith vs microservices?

**Interview Ready Answer:**
- **Monolith:** Single codebase, single deployment unit. **Pros:** Simple to develop, test, and deploy. **Cons:** Hard to scale parts independently; a single bug can crash the whole app.
- **Microservices:** Multiple small, independent services. **Pros:** Highly scalable, technology-independent, fault-isolated. **Cons:** Extremely high operational complexity, eventual consistency issues, and higher network latency.

<a id="q-11-14"></a>
> #### 11.14 Synchronous vs asynchronous microservice communication?

**Interview Ready Answer:**
- **Synchronous (REST/gRPC):** Service A calls Service B and waits. **Best for:** Immediate data needs (e.g., getting a user's current balance). **Risk:** Cascading failures if Service B is slow.
- **Asynchronous (Message Queues):** Service A sends a message to a broker and continues. **Best for:** Long-running tasks or decoupling services (e.g., Order placed -> Notify Shipping). **Risk:** Complex to debug and handle failures.

<a id="q-11-15"></a>
> #### 11.15 What is API Gateway?

**Interview Ready Answer:**
- **Definition:** A single entry point for all client requests in a microservices architecture.
- **Responsibilities:** 
  - **Routing:** Forwarding requests to the correct internal service.
  - **Authentication:** Checking JWT tokens at the edge before the request reaches internal services.
  - **Rate Limiting:** Preventing a single client from overwhelming the system.
  - **Protocol Translation:** Converting external HTTP/REST calls to internal gRPC calls.

<a id="q-11-16"></a>
> #### 11.16 What are caching strategies?

**Interview Ready Answer:**
- **Cache-Aside:** The application checks the cache first. If it's a "Miss," it fetches from the DB and manually updates the cache. (Most common).
- **Read-Through:** The application asks the cache for data; if missing, the cache itself fetches from the DB.
- **Write-Through:** Every time data is written to the DB, it is automatically written to the cache as well.
- **Write-Behind:** Data is written only to the cache, and the cache syncs it to the DB later in the background.

<a id="q-11-17"></a>
> #### 11.17 Redis basics?

**Interview Ready Answer:**
- **Definition:** An open-source, in-memory key-value data store used as a database, cache, and message broker.
- **Performance:** Since it's in-memory, it provides sub-millisecond latency.
- **Data Types:** Supports Strings, Hashes, Lists, Sets, and Sorted Sets.

<a id="q-11-18"></a>
> #### 11.18 Horizontal vs vertical scaling?

**Interview Ready Answer:**
- **Vertical Scaling (Scaling Up):** Adding more power (CPU, RAM) to an existing server. **Limit:** There's a physical limit to how much you can upgrade one machine.
- **Horizontal Scaling (Scaling Out):** Adding more server instances to your pool. **Limit:** Virtually unlimited, but requires a load balancer and a stateless application design.

<a id="q-11-19"></a>
> #### 11.19 How do you design fault-tolerant systems?

**Interview Ready Answer:**
- **Circuit Breaker Pattern:** Automatically stops calling a failing service for a certain period to allow it to recover (implemented using **Polly** in .NET).
- **Retry Pattern:** Automatically retrying a failed request (e.g., if it was a temporary network glitch).
- **Redundancy:** Running multiple instances of every service across different availability zones.
- **Graceful Degradation:** If a non-essential service (like "Product Recommendations") fails, the main page should still load without it.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-12"></a>
## 12. Testing

<a id="q-12-1"></a>
> #### 12.1 What is unit testing?

**Interview Ready Answer:**
- **Definition:** Testing the smallest possible piece of code (usually a single method or a single class) in complete isolation from the rest of the system.
- **Characteristics:** Unit tests are extremely fast, run in memory, and never talk to the database, file system, or network.

<a id="q-12-2"></a>
> #### 12.2 What is integration testing?

**Interview Ready Answer:**
- **Definition:** Testing how multiple components of the application work together. 
- **Characteristics:** Integration tests verify the connection between your code and external dependencies, like the Database, a Web API, or a Message Broker.

<a id="q-12-3"></a>
> #### 12.3 Difference between unit testing and integration testing?

**Interview Ready Answer:**
- **Isolation:** Unit tests are isolated; Integration tests are not.
- **Speed:** Unit tests are near-instant (milliseconds); Integration tests are slower (seconds) because they involve I/O.
- **Dependencies:** Unit tests use **Mocks** for dependencies; Integration tests use the **real** dependencies (e.g., a real SQL Server or a TestContainers instance).

<a id="q-12-4"></a>
> #### 12.4 What is BDD?

**Behavior-Driven Development (BDD)** is an agile software development process that encourages collaboration between developers, QA, and non-technical business stakeholders.

**Interview Ready Answer:**
- **The Concept:** BDD focuses on the **behavior** of the application from the user's perspective rather than the implementation details. 
- **Syntax:** Tests are written in plain English using the **Gherkin** syntax: **Given** (context), **When** (action), **Then** (expected result).

<a id="q-12-5"></a>
> #### 12.5 Difference between BDD and unit testing?

**Interview Ready Answer:**
- **Audience:** Unit tests are written *by* developers *for* developers. BDD is written to be understood by business stakeholders (Product Owners).
- **Scope:** Unit tests verify that a function works correctly. BDD verifies that a business feature (e.g., "User can checkout") works as expected.

<a id="q-12-6"></a>
> #### 12.6 What is mocking?

**Interview Ready Answer:**
- **Definition:** Creating a "fake" object that mimics the behavior of a real dependency (like a database repository or an email service).
- **Purpose:** It allows you to isolate the code you are testing. You can tell the mock exactly what to return (e.g., "When `GetPrice()` is called, return 100") so you don't need a real database.

<a id="q-12-7"></a>
> #### 12.7 Why use mocks?

**Interview Ready Answer:**
- **Reliability:** Real databases might be down or have inconsistent data; mocks always behave exactly as programmed.
- **Speed:** Talking to a mock in memory is thousands of times faster than talking to a physical database.
- **Cost:** You don't need to pay for cloud resources just to run a test.

<a id="q-12-8"></a>
> #### 12.8 What frameworks have you used?

**Interview Ready Answer:**
- **Testing Runners:** **xUnit** (modern standard for .NET Core), NUnit, or MSTest.
- **Mocking Libraries:** **Moq** or **NSubstitute**.
- **Assertion Libraries:** **FluentAssertions** (makes tests much more readable).
- **BDD:** **SpecFlow**.

<a id="q-12-9"></a>
> #### 12.9 What is testability?

**Interview Ready Answer:**
- **Definition:** The degree to which a piece of software supports being tested in an automated way. 
- **Signs of High Testability:** High use of interfaces, Dependency Injection, and the absence of "Hard Dependencies" (like `new SqlConnection()` inside a constructor).

<a id="q-12-10"></a>
> #### 12.10 How do interfaces help testing?

**Interview Ready Answer:**
- **Substitution:** Interfaces allow you to swap the real implementation (e.g., `SqlRepository`) for a mock implementation (e.g., `MockRepository`) at test-time. 
- **The Contract:** Since your code depends on the `IRepository` interface, it doesn't care if the object it's calling is talking to a real database or just a fake object in memory. This is the foundation of unit testing.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-13"></a>
## 13. Git, DevOps, and Cloud

<a id="q-13-1"></a>
> #### 13.1 Difference between git fetch and git pull?

**Interview Ready Answer:**
- **`git fetch`:** Downloads the latest changes from the remote server but **does not modify your local code**. It only updates your "Remote Tracking Branches" (like `origin/main`). It is safe.
- **`git pull`:** A combination of two commands: `git fetch` followed immediately by `git merge`. It downloads the changes and tries to automatically merge them into your current working branch.

<a id="q-13-2"></a>
> #### 13.2 What is merge conflict?

**Interview Ready Answer:**
- **Definition:** An event that occurs when Git is unable to automatically resolve differences in code between two commits. 
- **Causes:** This usually happens when two people edit the **same line** in the same file, or one person deletes a file that another person is currently editing.
- **Resolution:** You must manually open the file, look at the "conflict markers" (<<<<<<<, =======, >>>>>>>), choose which version of the code to keep, and then commit the resolved file.

<a id="q-13-3"></a>
> #### 13.3 What is rebase?

**Interview Ready Answer:**
- **The Concept:** Rebase is the process of moving or combining a sequence of commits to a new base commit.
- **Analogy:** Imagine you branched off `main` to work on a feature. While you were working, `main` moved forward with 3 new commits. `git rebase main` takes your work, lifts it up, and puts it **on top** of the latest `main` commit.
- **Advantage:** It results in a perfectly linear, clean project history without "noise" from merge commits.

<a id="q-13-4"></a>
> #### 13.4 What branching strategy do you use?

**Interview Ready Answer:**
- **GitFlow:** A structured strategy with separate branches for `master` (production), `develop` (integration), `feature/`, `release/`, and `hotfix/`. (Best for large enterprises).
- **GitHub Flow:** A simpler, modern strategy where you only have `main` and short-lived `feature/` branches. Once a feature is done and reviewed, it's merged into `main` and deployed immediately. (Best for CI/CD).
- **Trunk-Based Development:** Developers commit small changes directly to `main` multiple times a day, using "Feature Flags" to hide unfinished work. (Fastest velocity).

<a id="q-13-5"></a>
> #### 13.5 Have you worked with AWS or Azure?

**Interview Ready Answer:**
*(Pick one or mention both).*
- **Azure:** Being a .NET developer, I have extensive experience with Azure. I've used Azure App Services for hosting APIs, Azure SQL Database, and Azure Key Vault for managing secrets.
- **AWS:** I've worked with AWS services like EC2 for virtual servers, S3 for file storage, and RDS for managed databases.

<a id="q-13-6"></a>
> #### 13.6 What AWS services have you used?

**Interview Ready Answer:**
- **Compute:** EC2 (Virtual Machines), Lambda (Serverless Functions), ECS/EKS (Containers).
- **Storage:** S3 (Object Storage), EBS (Block Storage).
- **Database:** RDS (SQL), DynamoDB (NoSQL).
- **Networking:** VPC, Route 53 (DNS), CloudFront (CDN).
- **Security:** IAM, Secrets Manager.

<a id="q-13-7"></a>
> #### 13.7 What is CI/CD?

**Interview Ready Answer:**
- **CI (Continuous Integration):** The practice of automatically building and testing your code every single time a developer pushes to the repository. This catches bugs early.
- **CD (Continuous Deployment/Delivery):** The practice of automatically deploying the successfully tested code to a production (or staging) environment. This ensures the software is always in a releasable state.

<a id="q-13-8"></a>
> #### 13.8 What is Docker?

**Interview Ready Answer:**
- **Definition:** A platform that allows you to package an application and all its dependencies (runtime, libraries, configs) into a single, standardized unit called a **Container**.
- **Benefit:** "It works on my machine" becomes "It works everywhere." A Docker container will run exactly the same way on a developer's laptop, a staging server, or a production cloud environment.

<a id="q-13-9"></a>
> #### 13.9 What is Kubernetes?

**Interview Ready Answer:**
- **Definition:** An open-source **Orchestration** platform for managing containerized applications at scale.
- **Purpose:** If you have 100 Docker containers running, Kubernetes handles:
  - **Self-healing:** Automatically restarting containers that crash.
  - **Auto-scaling:** Adding more instances during high traffic.
  - **Load Balancing:** Distributing traffic across healthy containers.

<a id="q-13-10"></a>
> #### 13.10 What is environment configuration management?

**Interview Ready Answer:**
- **The Principle:** You should build your application code **once** and deploy it to Dev, Staging, and Prod without changing the binaries.
- **Implementation:** Use **Environment Variables** or configuration files (like `appsettings.json`) to store environment-specific data (like database connection strings). Sensitive data should never be in the code; it should be stored in a secure vault like **Azure Key Vault** or **AWS Secrets Manager**.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-14"></a>
## 14. Coding Questions Asked

<a id="q-14-1"></a>
> #### 14.1 Find number closest to zero.

**Interview Ready Answer:**
Given an array of integers, find the number that is closest to zero. If two numbers are equally close (e.g., -5 and 5), return the positive one.

```csharp
public static int ClosestToZero(int[] ts) {
    if (ts.Length == 0) return 0;
    
    int closest = ts[0];
    foreach (int x in ts) {
        if (Math.Abs(x) < Math.Abs(closest)) {
            closest = x;
        } else if (Math.Abs(x) == Math.Abs(closest)) {
            closest = Math.Max(closest, x);
        }
    }
    return closest;
}
```

<a id="q-14-2"></a>
> #### 14.2 FizzBuzz problem.

**Interview Ready Answer:**
Write a program that prints numbers from 1 to 100. For multiples of 3, print "Fizz"; for multiples of 5, print "Buzz"; for multiples of both, print "FizzBuzz".

```csharp
for (int i = 1; i <= 100; i++) {
    string output = "";
    if (i % 3 == 0) output += "Fizz";
    if (i % 5 == 0) output += "Buzz";
    
    Console.WriteLine(string.IsNullOrEmpty(output) ? i.ToString() : output);
}
```

<a id="q-14-3"></a>
> #### 14.3 Progressive substring printing.

**Interview Ready Answer:**
Given a string "CODE", print:
C
CO
COD
CODE

```csharp
string s = "CODE";
for (int i = 1; i <= s.Length; i++) {
    Console.WriteLine(s.Substring(0, i));
}
```

<a id="q-14-4"></a>
> #### 14.4 Array or string iteration problems.

**Interview Ready Answer:**
*(Common scenario: Find duplicates in an array).*
```csharp
// Using HashSet for O(N) performance
var seen = new HashSet<int>();
var duplicates = new List<int>();
foreach(var x in arr) {
    if(!seen.Add(x)) duplicates.Add(x);
}
```

<a id="q-14-5"></a>
> #### 14.5 Divisibility logic problems.

**Interview Ready Answer:**
*(Common scenario: Check if a number is Prime).*
```csharp
public bool IsPrime(int n) {
    if (n <= 1) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;
    
    for (int i = 3; i <= Math.Sqrt(n); i += 2) {
        if (n % i == 0) return false;
    }
    return true;
}
```

<a id="q-14-6"></a>
> #### 14.6 Basic loop and condition problems.

**Interview Ready Answer:**
*(Common scenario: Reverse a string without using built-in Reverse()).*
```csharp
public string Reverse(string s) {
    char[] charArray = s.ToCharArray();
    int left = 0;
    int right = s.Length - 1;
    while (left < right) {
        char temp = charArray[left];
        charArray[left] = charArray[right];
        charArray[right] = temp;
        left++;
        right--;
    }
    return new string(charArray);
}
```

<a id="q-14-7"></a>
> #### 14.7 Simple optimization logic problems.

**Interview Ready Answer:**
*(Common scenario: Two Sum problem - find two numbers that add up to a target).*
```csharp
// Optimized O(N) using a Dictionary
public int[] TwoSum(int[] nums, int target) {
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        if (dict.ContainsKey(complement)) {
            return new int[] { dict[complement], i };
        }
        dict[nums[i]] = i;
    }
    return null;
}
```

**[⬆ Back to Top](#table-of-contents)**

## Maintainer Guide

Use these rules whenever you or an AI agent updates this file.

### How to Add a New Question

1. Find the target section.
2. Use the next available question number in that section.
3. Add the question link inside that section's table-of-contents block.
4. Add the matching question block inside the content section.
5. Update the section question count in the `<summary>`.
6. Update `Total questions` at the top.

**Example: add question `3.17`**

Add this inside section `3` in the table of contents:

```md
- [3.17 Your new question here?](#q-3-17)
```

Add this inside the main content under section `3`:

```md
<a id="q-3-17"></a>
> #### 3.17 Your new question here?

**Answer:** To be added.
```

### How to Add an Answer

Replace:

```md
**Answer:** To be added.
```

With something like:

````md
**Answer:** Short direct answer.

- Key point 1
- Key point 2

```csharp
// Optional example
```
````

Keep answers short, interview-focused, and easy to revise.

### How the Linking Works

- Section links use `#section-N`
- Question links use `#q-sectionNumber-questionNumber`
- The table-of-contents link and the question anchor must match exactly

**Example**

- TOC link: `(#q-5-3)`
- Content anchor: `<a id="q-5-3"></a>`
- Question heading: `> #### 5.3 How is DI implemented in .NET?`

### Safe Editing Rules

- Prefer adding new questions at the end of a section to avoid renumbering everything.
- If you insert a question in the middle, you must renumber all later questions in that section.
- If you renumber questions, also update the TOC links, anchors, headings, section count, and top total count.
- Keep the `Back to Top` links unchanged.

### How to Add a New Section

1. Add a new `` block in the table of contents.
2. Create a matching section anchor like `<a id="section-15"></a>`.
3. Add question links in the TOC.
4. Add matching question blocks in the content.
5. Update `Total questions`.

### Prompt Template for an AI Agent

Use a prompt like this:

```text
Update /Users/nevinjoshy/code/Dotnet-Interview-Preperation/Qrevision/01-oops.md.

Add [N] new questions to section [section number].
Append them at the end of the section.
For each new question:
- add a clickable TOC link
- add a matching anchor in the content
- add an answer placeholder as: `> #### [number] [question text]` followed by **Answer:** To be added.

Also update:
- the section question count
- the total question count at the top

Do not break existing numbering or links.
```
