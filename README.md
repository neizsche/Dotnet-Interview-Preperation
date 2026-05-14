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
### 1.1 Explain the four OOP principles with real-world examples.
**Answer:** To be added.

<a id="q-1-2"></a>
### 1.2 What is encapsulation?
**Answer:** To be added.

<a id="q-1-3"></a>
### 1.3 How do getters and setters support encapsulation and controlled mutation?
**Answer:** To be added.

<a id="q-1-4"></a>
### 1.4 Show encapsulation with example.
**Answer:** To be added.

<a id="q-1-5"></a>
### 1.5 What is abstraction?
**Answer:** To be added.

<a id="q-1-6"></a>
### 1.6 Difference between abstraction and encapsulation?
**Answer:** To be added.

<a id="q-1-7"></a>
### 1.7 What are access modifiers in C#?
**Answer:** To be added.

<a id="q-1-8"></a>
### 1.8 Difference between `public`, `private`, `protected`, `internal`, and `protected internal`?
**Answer:** To be added.

<a id="q-1-9"></a>
### 1.9 How do access modifiers support encapsulation?
**Answer:** To be added.

<a id="q-1-10"></a>
### 1.10 What is inheritance?
**Answer:** To be added.

<a id="q-1-11"></a>
### 1.11 Explain inheritance using Animal/Dog example.
**Answer:** To be added.

<a id="q-1-12"></a>
### 1.12 How do you achieve multiple inheritance in C#?
**Answer:** To be added.

<a id="q-1-13"></a>
### 1.13 What is polymorphism?
**Answer:** To be added.

<a id="q-1-14"></a>
### 1.14 Difference between compile-time and runtime polymorphism?
**Answer:** To be added.

<a id="q-1-15"></a>
### 1.15 What is method overloading?
**Answer:** To be added.

<a id="q-1-16"></a>
### 1.16 Why is overloading not possible using return type alone?
**Answer:** To be added.

<a id="q-1-17"></a>
### 1.17 What is method overriding?
**Answer:** To be added.

<a id="q-1-18"></a>
### 1.18 Difference between method overloading and method overriding
**Answer:** To be added.

<a id="q-1-19"></a>
### 1.19 What happens when both parent and child define the same method? Explain `virtual`, `override`, and `new`.
**Answer:** To be added.

<a id="q-1-20"></a>
### 1.20 What is method hiding in C#?
**Answer:** To be added.

<a id="q-1-21"></a>
### 1.21 Difference between method hiding and method overriding
**Answer:** To be added.

<a id="q-1-22"></a>
### 1.22 Purpose of the `new` keyword in method hiding
**Answer:** To be added.

<a id="q-1-23"></a>
### 1.23 What is the difference between `virtual`, `override`, and `abstract`?
**Answer:** To be added.

<a id="q-1-24"></a>
### 1.24 Difference between `virtual`, `override`, and `new`
**Answer:** To be added.

<a id="q-1-25"></a>
### 1.25 What is upcasting vs downcasting?
**Answer:** To be added.

<a id="q-1-26"></a>
### 1.26 What happens during invalid downcasting, and why does it fail?
**Answer:** To be added.

<a id="q-1-27"></a>
### 1.27 How does method overriding behave during upcasting and downcasting?
**Answer:** To be added.

<a id="q-1-28"></a>
### 1.28 What is early binding vs late binding?
**Answer:** To be added.

<a id="q-1-29"></a>
### 1.29 What is virtual method dispatch?
**Answer:** To be added.

<a id="q-1-30"></a>
### 1.30 What is a virtual method table, and how does the CLR decide which overridden method to execute?
**Answer:** To be added.

<a id="q-1-31"></a>
### 1.31 How does runtime polymorphism work internally?
**Answer:** To be added.

<a id="q-1-32"></a>
### 1.32 What happens internally during method overriding?
**Answer:** To be added.

<a id="q-1-33"></a>
### 1.33 Can static methods participate in polymorphism? Why can’t they be virtual?
**Answer:** To be added.

<a id="q-1-34"></a>
### 1.34 What are constructors in C#?
**Answer:** To be added.

<a id="q-1-35"></a>
### 1.35 Difference between instance constructors and static constructors
**Answer:** To be added.

<a id="q-1-36"></a>
### 1.36 What are primary constructors?
**Answer:** To be added.

<a id="q-1-37"></a>
### 1.37 What is constructor chaining?
**Answer:** To be added.

<a id="q-1-38"></a>
### 1.38 How do constructors work during inheritance, and what is the execution flow in an inheritance hierarchy?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-2"></a>
## 2. Interface and Abstract Class

<a id="q-2-1"></a>
### 2.1 What is an interface?
**Answer:** To be added.

<a id="q-2-2"></a>
### 2.2 What is an abstract class?
**Answer:** To be added.

<a id="q-2-3"></a>
### 2.3 Difference between interface and abstract class?
**Answer:** To be added.

<a id="q-2-4"></a>
### 2.4 When would you use interface vs abstract class?
**Answer:** To be added.

<a id="q-2-5"></a>
### 2.5 When should you use an abstract class?
**Answer:** To be added.

<a id="q-2-6"></a>
### 2.6 Why use interfaces instead of concrete classes?
**Answer:** To be added.

<a id="q-2-7"></a>
### 2.7 How do interfaces reduce coupling?
**Answer:** To be added.

<a id="q-2-8"></a>
### 2.8 Why depend on abstractions instead of implementations?
**Answer:** To be added.

<a id="q-2-9"></a>
### 2.9 Can interfaces have implementation?
**Answer:** To be added.

<a id="q-2-10"></a>
### 2.10 Can interfaces contain fields or state?
**Answer:** To be added.

<a id="q-2-11"></a>
### 2.11 Can interfaces inherit interfaces?
**Answer:** To be added.

<a id="q-2-12"></a>
### 2.12 What happens if two interfaces have the same method signature?
**Answer:** To be added.

<a id="q-2-13"></a>
### 2.13 What is explicit interface implementation?
**Answer:** To be added.

<a id="q-2-14"></a>
### 2.14 Can abstract methods exist in non-abstract classes?
**Answer:** To be added.

<a id="q-2-15"></a>
### 2.15 Can abstract classes have constructors?
**Answer:** To be added.

<a id="q-2-16"></a>
### 2.16 Can abstract classes contain fields or state?
**Answer:** To be added.

<a id="q-2-17"></a>
### 2.17 Can abstract classes implement interfaces?
**Answer:** To be added.

<a id="q-2-18"></a>
### 2.18 Difference between abstract method and virtual method?
**Answer:** To be added.

<a id="q-2-19"></a>
### 2.19 Why does C# support multiple inheritance only through interfaces?
**Answer:** To be added.

<a id="q-2-20"></a>
### 2.20 What is the diamond problem, and how does C# handle it with interfaces and abstract classes?
**Answer:** To be added.

<a id="q-2-21"></a>
### 2.21 Why not use interfaces everywhere?
**Answer:** To be added.

<a id="q-2-22"></a>
### 2.22 Why not use abstract classes everywhere?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-3"></a>
## 3. SOLID Principles and Architecture

<a id="q-3-1"></a>
### 3.1 Explain SOLID principles.
**Answer:** To be added.

<a id="q-3-2"></a>
### 3.2 What do you mean by coupling and cohesion?
**Answer:** To be added.

<a id="q-3-3"></a>
### 3.3 Explain Single Responsibility Principle.
**Answer:** To be added.

<a id="q-3-4"></a>
### 3.4 Explain Open Closed Principle.
**Answer:** To be added.

<a id="q-3-5"></a>
### 3.5 Explain Liskov Substitution Principle.
**Answer:** To be added.

<a id="q-3-6"></a>
### 3.6 Explain Interface Segregation Principle.
**Answer:** To be added.

<a id="q-3-7"></a>
### 3.7 Explain Dependency Inversion Principle.
**Answer:** To be added.

<a id="q-3-8"></a>
### 3.8 What is the difference between SRP and ISP?
**Answer:** To be added.

<a id="q-3-9"></a>
### 3.9 Which SOLID principle is behavioral?
**Answer:** To be added.

<a id="q-3-10"></a>
### 3.10 What are the practical benefits of implementing DIP?
**Answer:** To be added.

<a id="q-3-11"></a>
### 3.11 Why prefer composition over inheritance?
**Answer:** To be added.

<a id="q-3-12"></a>
### 3.12 How do interfaces improve maintainability?
**Answer:** To be added.

<a id="q-3-13"></a>
### 3.13 How do abstractions improve scalability?
**Answer:** To be added.

<a id="q-3-14"></a>
### 3.14 What is layered architecture, and how do you make it decoupled?
**Answer:** To be added.

<a id="q-3-15"></a>
### 3.15 What is the responsibility of each layer in a layered architecture?
**Answer:** To be added.

<a id="q-3-16"></a>
### 3.16 What is cyclic dependency, and how do you break it?
**Answer:** To be added.

<a id="q-3-17"></a>
### 3.17 How would you isolate provider-specific behavior?
**Answer:** To be added.

<a id="q-3-18"></a>
### 3.18 Give real-world examples of SOLID.
**Answer:** To be added.

<a id="q-3-19"></a>
### 3.19 How did you apply SOLID in your project?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-4"></a>
## 4. Design Patterns

> Important for enterprise-style interviews.

<a id="q-4-1"></a>
### 4.1 What are design patterns?
**Answer:** To be added.

<a id="q-4-2"></a>
### 4.2 Difference between design pattern and architecture pattern?
**Answer:** To be added.

<a id="q-4-3"></a>
### 4.3 Which design patterns are commonly used in .NET applications?
**Answer:** To be added.

<a id="q-4-4"></a>
### 4.4 What design patterns have you used in your projects?
**Answer:** To be added.

<a id="q-4-5"></a>
### 4.5 What is Inversion of Control?
**Answer:** To be added.

<a id="q-4-6"></a>
### 4.6 What is Dependency Injection pattern?
**Answer:** To be added.

<a id="q-4-7"></a>
### 4.7 How does dependency injection relate to IoC?
**Answer:** To be added.

<a id="q-4-8"></a>
### 4.8 What is Singleton pattern?
**Answer:** To be added.

<a id="q-4-9"></a>
### 4.9 Where would you use Singleton?
**Answer:** To be added.

<a id="q-4-10"></a>
### 4.10 Problems with Singleton?
**Answer:** To be added.

<a id="q-4-11"></a>
### 4.11 How would you implement a thread-safe Singleton?
**Answer:** To be added.

<a id="q-4-12"></a>
### 4.12 Write a thread-safe Singleton implementation
**Answer:** To be added.

<a id="q-4-13"></a>
### 4.13 What is Factory pattern?
**Answer:** To be added.

<a id="q-4-14"></a>
### 4.14 Difference between Factory and Abstract Factory?
**Answer:** To be added.

<a id="q-4-15"></a>
### 4.15 What is Builder pattern?
**Answer:** To be added.

<a id="q-4-16"></a>
### 4.16 What is Strategy pattern?
**Answer:** To be added.

<a id="q-4-17"></a>
### 4.17 Real-world example of Strategy pattern?
**Answer:** To be added.

<a id="q-4-18"></a>
### 4.18 What is Observer pattern?
**Answer:** To be added.

<a id="q-4-19"></a>
### 4.19 What is Adapter pattern?
**Answer:** To be added.

<a id="q-4-20"></a>
### 4.20 What is Facade pattern?
**Answer:** To be added.

<a id="q-4-21"></a>
### 4.21 What is Repository pattern?
**Answer:** To be added.

<a id="q-4-22"></a>
### 4.22 Why use Repository pattern?
**Answer:** To be added.

<a id="q-4-23"></a>
### 4.23 What is Unit of Work pattern?
**Answer:** To be added.

<a id="q-4-24"></a>
### 4.24 Difference between Singleton, Factory, and Repository patterns
**Answer:** To be added.

<a id="q-4-25"></a>
### 4.25 What is CQRS?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-5"></a>
## 5. Dependency Injection

<a id="q-5-1"></a>
### 5.1 What is Inversion of Control?
**Answer:** To be added.

<a id="q-5-2"></a>
### 5.2 What is dependency injection?
**Answer:** To be added.

<a id="q-5-3"></a>
### 5.3 What problems does dependency injection solve?
**Answer:** To be added.

<a id="q-5-4"></a>
### 5.4 What happens if you instantiate concrete implementations directly?
**Answer:** To be added.

<a id="q-5-5"></a>
### 5.5 How is DI implemented in .NET?
**Answer:** To be added.

<a id="q-5-6"></a>
### 5.6 Explain the three DI service lifetimes: Transient, Scoped, and Singleton.
**Answer:** To be added.

<a id="q-5-7"></a>
### 5.7 Which lifetime is used for DbContext?
**Answer:** To be added.

<a id="q-5-8"></a>
### 5.8 What problems happen with Singleton misuse?
**Answer:** To be added.

<a id="q-5-9"></a>
### 5.9 What is captive dependency?
**Answer:** To be added.

<a id="q-5-10"></a>
### 5.10 How does DI help in unit testing and mocking?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-6"></a>
## 6. C# Core Concepts

<a id="q-6-1"></a>
### 6.1 What is a static class?
**Answer:** To be added.

<a id="q-6-2"></a>
### 6.2 When should you use a static class?
**Answer:** To be added.

<a id="q-6-3"></a>
### 6.3 What are the limitations of static classes?
**Answer:** To be added.

<a id="q-6-4"></a>
### 6.4 Difference between static constructor and private constructor
**Answer:** To be added.

<a id="q-6-5"></a>
### 6.5 How do static members work internally?
**Answer:** To be added.

<a id="q-6-6"></a>
### 6.6 Why does the CLR provide thread safety for static constructors?
**Answer:** To be added.

<a id="q-6-7"></a>
### 6.7 Order of execution of static constructors and instance constructors
**Answer:** To be added.

<a id="q-6-8"></a>
### 6.8 What is a sealed class?
**Answer:** To be added.

<a id="q-6-9"></a>
### 6.9 Why would you seal a class or method?
**Answer:** To be added.

<a id="q-6-10"></a>
### 6.10 Difference between class, struct, and record
**Answer:** To be added.

<a id="q-6-11"></a>
### 6.11 Difference between class and struct
**Answer:** To be added.

<a id="q-6-12"></a>
### 6.12 When should you use a struct instead of a class?
**Answer:** To be added.

<a id="q-6-13"></a>
### 6.13 Why are structs value types?
**Answer:** To be added.

<a id="q-6-14"></a>
### 6.14 What are records in C# and why were they introduced?
**Answer:** To be added.

<a id="q-6-15"></a>
### 6.15 What problems do records solve?
**Answer:** To be added.

<a id="q-6-16"></a>
### 6.16 What are extension methods?
**Answer:** To be added.

<a id="q-6-17"></a>
### 6.17 How are extension methods implemented under the hood?
**Answer:** To be added.

<a id="q-6-18"></a>
### 6.18 What is Reflection?
**Answer:** To be added.

<a id="q-6-19"></a>
### 6.19 What are delegates in C#?
**Answer:** To be added.

<a id="q-6-20"></a>
### 6.20 How do delegates work internally?
**Answer:** To be added.

<a id="q-6-21"></a>
### 6.21 What are multicast delegates?
**Answer:** To be added.

<a id="q-6-22"></a>
### 6.22 Difference between delegates and events
**Answer:** To be added.

<a id="q-6-23"></a>
### 6.23 Why use events over delegates?
**Answer:** To be added.

<a id="q-6-24"></a>
### 6.24 How are events implemented internally in .NET?
**Answer:** To be added.

<a id="q-6-25"></a>
### 6.25 When would you use events in real-world applications?
**Answer:** To be added.

<a id="q-6-26"></a>
### 6.26 What is the practical use of delegates?
**Answer:** To be added.

<a id="q-6-27"></a>
### 6.27 Difference between Action, Func, and Predicate
**Answer:** To be added.

<a id="q-6-28"></a>
### 6.28 What are generic classes in C#?
**Answer:** To be added.

<a id="q-6-29"></a>
### 6.29 Why are generics important?
**Answer:** To be added.

<a id="q-6-30"></a>
### 6.30 How do generics work internally in .NET?
**Answer:** To be added.

<a id="q-6-31"></a>
### 6.31 Why are generics type-safe?
**Answer:** To be added.

<a id="q-6-32"></a>
### 6.32 What are generic constraints?
**Answer:** To be added.

<a id="q-6-33"></a>
### 6.33 Types of generic constraints in C#
**Answer:** To be added.

<a id="q-6-34"></a>
### 6.34 Difference between covariance, contravariance, and invariance
**Answer:** To be added.

<a id="q-6-35"></a>
### 6.35 Where are covariance and contravariance used in .NET?
**Answer:** To be added.

<a id="q-6-36"></a>
### 6.36 What is boxing and unboxing?
**Answer:** To be added.

<a id="q-6-37"></a>
### 6.37 What happens internally during boxing and unboxing?
**Answer:** To be added.

<a id="q-6-38"></a>
### 6.38 Why are boxing and unboxing expensive?
**Answer:** To be added.

<a id="q-6-39"></a>
### 6.39 What are nullable types in C#?
**Answer:** To be added.

<a id="q-6-40"></a>
### 6.40 How does `Nullable<T>` work internally?
**Answer:** To be added.

<a id="q-6-41"></a>
### 6.41 Where are nullable types stored in memory?
**Answer:** To be added.

<a id="q-6-42"></a>
### 6.42 Difference between `const`, `readonly`, and `static readonly`
**Answer:** To be added.

<a id="q-6-43"></a>
### 6.43 When should you use `const` vs `readonly`?
**Answer:** To be added.

<a id="q-6-44"></a>
### 6.44 Difference between `ref`, `out`, and `in` parameters
**Answer:** To be added.

<a id="q-6-45"></a>
### 6.45 What are method parameters and argument passing mechanisms?
**Answer:** To be added.

<a id="q-6-46"></a>
### 6.46 How do methods work internally in .NET?
**Answer:** To be added.

<a id="q-6-47"></a>
### 6.47 What happens under the hood when a method is called?
**Answer:** To be added.

<a id="q-6-48"></a>
### 6.48 What is the purpose of the `yield` statement?
**Answer:** To be added.

<a id="q-6-49"></a>
### 6.49 How do iterators work internally in C#?
**Answer:** To be added.

<a id="q-6-50"></a>
### 6.50 Difference between `==`, `Equals()`, and `String.Compare()` in C#
**Answer:** To be added.

<a id="q-6-51"></a>
### 6.51 Difference between `String` and `StringBuilder`
**Answer:** To be added.

<a id="q-6-52"></a>
### 6.52 Why is `string` a reference type but behaves like a value type?
**Answer:** To be added.

<a id="q-6-53"></a>
### 6.53 Difference between `string.IsNullOrEmpty()` and `string.IsNullOrWhiteSpace()`
**Answer:** To be added.

<a id="q-6-54"></a>
### 6.54 Why are strings immutable in C#?
**Answer:** To be added.

<a id="q-6-55"></a>
### 6.55 What are the benefits and drawbacks of immutable strings?
**Answer:** To be added.

<a id="q-6-56"></a>
### 6.56 Difference between value types and reference types
**Answer:** To be added.

<a id="q-6-57"></a>
### 6.57 Difference between stack and heap memory
**Answer:** To be added.

<a id="q-6-58"></a>
### 6.58 Where are value types and reference types stored in memory?
**Answer:** To be added.

<a id="q-6-59"></a>
### 6.59 How does memory allocation work for structs and classes?
**Answer:** To be added.

<a id="q-6-60"></a>
### 6.60 What is thread safety?
**Answer:** To be added.

<a id="q-6-61"></a>
### 6.61 What problems occur in multithreaded applications?
**Answer:** To be added.

<a id="q-6-62"></a>
### 6.62 Difference between synchronization and thread safety
**Answer:** To be added.

<a id="q-6-63"></a>
### 6.63 What is the `lock` statement?
**Answer:** To be added.

<a id="q-6-64"></a>
### 6.64 How does locking work internally in .NET?
**Answer:** To be added.

<a id="q-6-65"></a>
### 6.65 What problems does locking solve?
**Answer:** To be added.

<a id="q-6-66"></a>
### 6.66 What is deadlock and how can it be avoided?
**Answer:** To be added.

<a id="q-6-67"></a>
### 6.67 Difference between synchronous and asynchronous programming
**Answer:** To be added.

<a id="q-6-68"></a>
### 6.68 What is async/await?
**Answer:** To be added.

<a id="q-6-69"></a>
### 6.69 How does async/await work internally?
**Answer:** To be added.

<a id="q-6-70"></a>
### 6.70 What is Task in .NET?
**Answer:** To be added.

<a id="q-6-71"></a>
### 6.71 What is TAP (Task-based Asynchronous Pattern)?
**Answer:** To be added.

<a id="q-6-72"></a>
### 6.72 What is the ThreadPool in .NET?
**Answer:** To be added.

<a id="q-6-73"></a>
### 6.73 Difference between `Task.Run()` and creating threads manually
**Answer:** To be added.

<a id="q-6-74"></a>
### 6.74 Difference between concurrency and parallelism
**Answer:** To be added.

<a id="q-6-75"></a>
### 6.75 What is `SynchronizationContext`?
**Answer:** To be added.

<a id="q-6-76"></a>
### 6.76 What is `ConfigureAwait(false)` and when should you use it?
**Answer:** To be added.

<a id="q-6-77"></a>
### 6.77 Difference between `Task.WhenAll()` and `Task.WhenAny()`
**Answer:** To be added.

<a id="q-6-78"></a>
### 6.78 How are exceptions handled in async/await?
**Answer:** To be added.

<a id="q-6-79"></a>
### 6.79 Why should async methods avoid `async void`?
**Answer:** To be added.

<a id="q-6-80"></a>
### 6.80 When is `async void` acceptable?
**Answer:** To be added.

<a id="q-6-81"></a>
### 6.81 What are exceptions in C#?
**Answer:** To be added.

<a id="q-6-82"></a>
### 6.82 Explain `try`, `catch`, and `finally`
**Answer:** To be added.

<a id="q-6-83"></a>
### 6.83 What is the purpose of the `finally` block?
**Answer:** To be added.

<a id="q-6-84"></a>
### 6.84 Difference between `throw` and `throw ex`
**Answer:** To be added.

<a id="q-6-85"></a>
### 6.85 Why is `throw ex` considered bad practice?
**Answer:** To be added.

<a id="q-6-86"></a>
### 6.86 What are custom exceptions?
**Answer:** To be added.

<a id="q-6-87"></a>
### 6.87 How do you create custom exceptions?
**Answer:** To be added.

<a id="q-6-88"></a>
### 6.88 How does exception handling work internally in .NET?
**Answer:** To be added.

<a id="q-6-89"></a>
### 6.89 What happens if an exception is not handled?
**Answer:** To be added.

<a id="q-6-90"></a>
### 6.90 Best practices for exception handling in enterprise applications
**Answer:** To be added.

<a id="q-6-91"></a>
### 6.91 What is IDisposable?
**Answer:** To be added.

<a id="q-6-92"></a>
### 6.92 Who calls Dispose()?
**Answer:** To be added.

<a id="q-6-93"></a>
### 6.93 Difference between managed and unmanaged resources
**Answer:** To be added.

<a id="q-6-94"></a>
### 6.94 What is managed code?
**Answer:** To be added.

<a id="q-6-95"></a>
### 6.95 What is unmanaged code?
**Answer:** To be added.

<a id="q-6-96"></a>
### 6.96 Difference between managed and unmanaged code
**Answer:** To be added.

<a id="q-6-97"></a>
### 6.97 How does the `using` statement work internally?
**Answer:** To be added.

<a id="q-6-98"></a>
### 6.98 Difference between `Dispose()` and finalizers
**Answer:** To be added.

<a id="q-6-99"></a>
### 6.99 What is garbage collection (GC)?
**Answer:** To be added.

<a id="q-6-100"></a>
### 6.100 How does garbage collection work internally?
**Answer:** To be added.

<a id="q-6-101"></a>
### 6.101 What are GC generations?
**Answer:** To be added.

<a id="q-6-102"></a>
### 6.102 Does GC run on a fixed schedule?
**Answer:** To be added.

<a id="q-6-103"></a>
### 6.103 How does the CLR manage memory?
**Answer:** To be added.

<a id="q-6-104"></a>
### 6.104 What is CLR (Common Language Runtime)?
**Answer:** To be added.

<a id="q-6-105"></a>
### 6.105 Responsibilities of the CLR
**Answer:** To be added.

<a id="q-6-106"></a>
### 6.106 How does the CLR execute C# code?
**Answer:** To be added.

<a id="q-6-107"></a>
### 6.107 How does the CLR manage application execution?
**Answer:** To be added.

<a id="q-6-108"></a>
### 6.108 What is JIT compilation?
**Answer:** To be added.

<a id="q-6-109"></a>
### 6.109 Write a custom delegate and event example
**Answer:** To be added.

<a id="q-6-110"></a>
### 6.110 Demonstrate the difference between `throw` and `throw ex`
**Answer:** To be added.

<a id="q-6-111"></a>
### 6.111 Write an example using `Task.WhenAll()`
**Answer:** To be added.

<a id="q-6-112"></a>
### 6.112 Explain the output of async/await execution flow snippets
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-7"></a>
## 7. ASP.NET Core and APIs

<a id="q-7-1"></a>
### 7.1 What is REST?
**Answer:** To be added.

<a id="q-7-2"></a>
### 7.2 What are REST principles?
**Answer:** To be added.

<a id="q-7-3"></a>
### 7.3 Difference between GET, POST, PUT, PATCH, and DELETE?
**Answer:** To be added.

<a id="q-7-4"></a>
### 7.4 What is IActionResult?
**Answer:** To be added.

<a id="q-7-5"></a>
### 7.5 Difference between IActionResult and ActionResult?
**Answer:** To be added.

<a id="q-7-6"></a>
### 7.6 What are common HTTP status codes?
**Answer:** To be added.

<a id="q-7-7"></a>
### 7.7 Difference between authentication and authorization?
**Answer:** To be added.

<a id="q-7-8"></a>
### 7.8 What is JWT?
**Answer:** To be added.

<a id="q-7-9"></a>
### 7.9 Claims-based vs policy-based authorization?
**Answer:** To be added.

<a id="q-7-10"></a>
### 7.10 What is middleware?
**Answer:** To be added.

<a id="q-7-11"></a>
### 7.11 How does middleware pipeline work?
**Answer:** To be added.

<a id="q-7-12"></a>
### 7.12 How do you structure controllers, services, and repositories?
**Answer:** To be added.

<a id="q-7-13"></a>
### 7.13 What is model binding?
**Answer:** To be added.

<a id="q-7-14"></a>
### 7.14 What is dependency injection in ASP.NET Core?
**Answer:** To be added.

<a id="q-7-15"></a>
### 7.15 How do you handle exceptions globally?
**Answer:** To be added.

<a id="q-7-16"></a>
### 7.16 What is API versioning?
**Answer:** To be added.

<a id="q-7-17"></a>
### 7.17 What is CORS?
**Answer:** To be added.

<a id="q-7-18"></a>
### 7.18 What is Swagger/OpenAPI?
**Answer:** To be added.

<a id="q-7-19"></a>
### 7.19 How do microservices communicate?
**Answer:** To be added.

<a id="q-7-20"></a>
### 7.20 What is microservice architecture?
**Answer:** To be added.

<a id="q-7-21"></a>
### 7.21 Difference between `IActionResult` and `ActionResult<T>`
**Answer:** To be added.

<a id="q-7-22"></a>
### 7.22 When should you use `ActionResult<T>`?
**Answer:** To be added.

<a id="q-7-23"></a>
### 7.23 Advantages of strongly typed API responses
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-8"></a>
## 8. LINQ and Collections

<a id="q-8-1"></a>
### 8.1 What is LINQ?
**Answer:** To be added.

<a id="q-8-2"></a>
### 8.2 Difference between LINQ to Objects and LINQ to Entities
**Answer:** To be added.

<a id="q-8-3"></a>
### 8.3 What LINQ methods have you used?
**Answer:** To be added.

<a id="q-8-4"></a>
### 8.4 How do joins work in LINQ?
**Answer:** To be added.

<a id="q-8-5"></a>
### 8.5 What is GroupBy in LINQ?
**Answer:** To be added.

<a id="q-8-6"></a>
### 8.6 Difference between `Select` and `SelectMany`
**Answer:** To be added.

<a id="q-8-7"></a>
### 8.7 Difference between `First`, `FirstOrDefault`, and `Single`
**Answer:** To be added.

<a id="q-8-8"></a>
### 8.8 When should you use `Single` over `FirstOrDefault`?
**Answer:** To be added.

<a id="q-8-9"></a>
### 8.9 What is deferred execution in LINQ?
**Answer:** To be added.

<a id="q-8-10"></a>
### 8.10 Advantages and disadvantages of deferred execution
**Answer:** To be added.

<a id="q-8-11"></a>
### 8.11 When does a LINQ query execute?
**Answer:** To be added.

<a id="q-8-12"></a>
### 8.12 What does `ToList()` do internally?
**Answer:** To be added.

<a id="q-8-13"></a>
### 8.13 Difference between `IEnumerable` and `IQueryable`
**Answer:** To be added.

<a id="q-8-14"></a>
### 8.14 Why is `IEnumerable` preferred in some method signatures?
**Answer:** To be added.

<a id="q-8-15"></a>
### 8.15 Why should repositories return `IQueryable` carefully?
**Answer:** To be added.

<a id="q-8-16"></a>
### 8.16 Difference between `IEnumerable` and `List`
**Answer:** To be added.

<a id="q-8-17"></a>
### 8.17 Difference between arrays and collections
**Answer:** To be added.

<a id="q-8-18"></a>
### 8.18 Is `List<T>` a value type or reference type? Why?
**Answer:** To be added.

<a id="q-8-19"></a>
### 8.19 Why do generics improve performance compared to non-generic collections?
**Answer:** To be added.

<a id="q-8-20"></a>
### 8.20 Difference between `List`, `Dictionary`, and `HashSet`
**Answer:** To be added.

<a id="q-8-21"></a>
### 8.21 When should you use `HashSet` over `List`?
**Answer:** To be added.

<a id="q-8-22"></a>
### 8.22 Internal working of `Dictionary<TKey, TValue>`
**Answer:** To be added.

<a id="q-8-23"></a>
### 8.23 Time complexities of common collection operations
**Answer:** To be added.

<a id="q-8-24"></a>
### 8.24 What is lazy loading?
**Answer:** To be added.

<a id="q-8-25"></a>
### 8.25 Write a LINQ query and explain deferred execution
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-9"></a>
## 9. SQL

<a id="q-9-1"></a>
### 9.1 Difference between UNION and UNION ALL?
**Answer:** To be added.

<a id="q-9-2"></a>
### 9.2 Explain INNER JOIN.
**Answer:** To be added.

<a id="q-9-3"></a>
### 9.3 Explain LEFT JOIN.
**Answer:** To be added.

<a id="q-9-4"></a>
### 9.4 Explain RIGHT JOIN.
**Answer:** To be added.

<a id="q-9-5"></a>
### 9.5 Explain FULL OUTER JOIN.
**Answer:** To be added.

<a id="q-9-6"></a>
### 9.6 Difference between Primary Key and Unique Key?
**Answer:** To be added.

<a id="q-9-7"></a>
### 9.7 What are indexes?
**Answer:** To be added.

<a id="q-9-8"></a>
### 9.8 Difference between clustered and non-clustered index?
**Answer:** To be added.

<a id="q-9-9"></a>
### 9.9 How many clustered indexes can a table have?
**Answer:** To be added.

<a id="q-9-10"></a>
### 9.10 What are ranking functions?
**Answer:** To be added.

<a id="q-9-11"></a>
### 9.11 Difference between ROW_NUMBER, RANK, and DENSE_RANK?
**Answer:** To be added.

<a id="q-9-12"></a>
### 9.12 What are stored procedures?
**Answer:** To be added.

<a id="q-9-13"></a>
### 9.13 Difference between procedure and function?
**Answer:** To be added.

<a id="q-9-14"></a>
### 9.14 What are table-valued functions?
**Answer:** To be added.

<a id="q-9-15"></a>
### 9.15 What is normalization?
**Answer:** To be added.

<a id="q-9-16"></a>
### 9.16 What is denormalization?
**Answer:** To be added.

<a id="q-9-17"></a>
### 9.17 What is a CTE?
**Answer:** To be added.

<a id="q-9-18"></a>
### 9.18 What are aggregate functions?
**Answer:** To be added.

<a id="q-9-19"></a>
### 9.19 What is pagination?
**Answer:** To be added.

<a id="q-9-20"></a>
### 9.20 What causes slow queries?
**Answer:** To be added.

<a id="q-9-21"></a>
### 9.21 How do you optimize SQL queries?
**Answer:** To be added.

<a id="q-9-22"></a>
### 9.22 What is index seek vs index scan?
**Answer:** To be added.

<a id="q-9-23"></a>
### 9.23 Why is SELECT * bad?
**Answer:** To be added.

<a id="q-9-24"></a>
### 9.24 What is deadlock in SQL?
**Answer:** To be added.

<a id="q-9-25"></a>
### 9.25 What is transaction?
**Answer:** To be added.

<a id="q-9-26"></a>
### 9.26 What are ACID properties?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-10"></a>
## 10. Frontend: Angular and React

### Angular

<a id="q-10-1"></a>
### 10.1 What is two-way binding?
**Answer:** To be added.

<a id="q-10-2"></a>
### 10.2 What are components?
**Answer:** To be added.

<a id="q-10-3"></a>
### 10.3 What are services?
**Answer:** To be added.

<a id="q-10-4"></a>
### 10.4 What are pipes?
**Answer:** To be added.

<a id="q-10-5"></a>
### 10.5 What are custom pipes?
**Answer:** To be added.

<a id="q-10-6"></a>
### 10.6 Difference between template-driven and reactive forms?
**Answer:** To be added.

<a id="q-10-7"></a>
### 10.7 What are RxJS operators?
**Answer:** To be added.

<a id="q-10-8"></a>
### 10.8 How does parent-child communication work?
**Answer:** To be added.

<a id="q-10-9"></a>
### 10.9 How do sibling components communicate?
**Answer:** To be added.

<a id="q-10-10"></a>
### 10.10 What are observables?
**Answer:** To be added.

### React

<a id="q-10-11"></a>
### 10.11 Difference between class and functional components?
**Answer:** To be added.

<a id="q-10-12"></a>
### 10.12 What are hooks?
**Answer:** To be added.

<a id="q-10-13"></a>
### 10.13 What is useState?
**Answer:** To be added.

<a id="q-10-14"></a>
### 10.14 What is useEffect?
**Answer:** To be added.

<a id="q-10-15"></a>
### 10.15 What is useMemo?
**Answer:** To be added.

<a id="q-10-16"></a>
### 10.16 What are props and state?
**Answer:** To be added.

<a id="q-10-17"></a>
### 10.17 What is React key?
**Answer:** To be added.

<a id="q-10-18"></a>
### 10.18 Why is key important in lists?
**Answer:** To be added.

<a id="q-10-19"></a>
### 10.19 What does map() do in React?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-11"></a>
## 11. System Design, Performance, and Scalability

<a id="q-11-1"></a>
### 11.1 How did you improve performance in your project?
**Answer:** To be added.

<a id="q-11-2"></a>
### 11.2 How do you optimize slow APIs?
**Answer:** To be added.

<a id="q-11-3"></a>
### 11.3 How do you reduce payload size?
**Answer:** To be added.

<a id="q-11-4"></a>
### 11.4 How does pagination improve performance?
**Answer:** To be added.

<a id="q-11-5"></a>
### 11.5 What is lazy loading?
**Answer:** To be added.

<a id="q-11-6"></a>
### 11.6 How do you identify bottlenecks?
**Answer:** To be added.

<a id="q-11-7"></a>
### 11.7 How do you improve scalability?
**Answer:** To be added.

<a id="q-11-8"></a>
### 11.8 How do you handle high-volume API responses?
**Answer:** To be added.

<a id="q-11-9"></a>
### 11.9 How do microservices improve scalability?
**Answer:** To be added.

<a id="q-11-10"></a>
### 11.10 What causes blocking or waiting issues?
**Answer:** To be added.

<a id="q-11-11"></a>
### 11.11 How would you debug slow backend response?
**Answer:** To be added.

<a id="q-11-12"></a>
### 11.12 How would you optimize data-heavy dashboards?
**Answer:** To be added.

<a id="q-11-13"></a>
### 11.13 Monolith vs microservices?
**Answer:** To be added.

<a id="q-11-14"></a>
### 11.14 Synchronous vs asynchronous microservice communication?
**Answer:** To be added.

<a id="q-11-15"></a>
### 11.15 What is API Gateway?
**Answer:** To be added.

<a id="q-11-16"></a>
### 11.16 What are caching strategies?
**Answer:** To be added.

<a id="q-11-17"></a>
### 11.17 Redis basics?
**Answer:** To be added.

<a id="q-11-18"></a>
### 11.18 Horizontal vs vertical scaling?
**Answer:** To be added.

<a id="q-11-19"></a>
### 11.19 How do you design fault-tolerant systems?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-12"></a>
## 12. Testing

<a id="q-12-1"></a>
### 12.1 What is unit testing?
**Answer:** To be added.

<a id="q-12-2"></a>
### 12.2 What is integration testing?
**Answer:** To be added.

<a id="q-12-3"></a>
### 12.3 Difference between unit testing and integration testing?
**Answer:** To be added.

<a id="q-12-4"></a>
### 12.4 What is BDD?
**Answer:** To be added.

<a id="q-12-5"></a>
### 12.5 Difference between BDD and unit testing?
**Answer:** To be added.

<a id="q-12-6"></a>
### 12.6 What is mocking?
**Answer:** To be added.

<a id="q-12-7"></a>
### 12.7 Why use mocks?
**Answer:** To be added.

<a id="q-12-8"></a>
### 12.8 What frameworks have you used?
**Answer:** To be added.

<a id="q-12-9"></a>
### 12.9 What is testability?
**Answer:** To be added.

<a id="q-12-10"></a>
### 12.10 How do interfaces help testing?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-13"></a>
## 13. Git, DevOps, and Cloud

<a id="q-13-1"></a>
### 13.1 Difference between git fetch and git pull?
**Answer:** To be added.

<a id="q-13-2"></a>
### 13.2 What is merge conflict?
**Answer:** To be added.

<a id="q-13-3"></a>
### 13.3 What is rebase?
**Answer:** To be added.

<a id="q-13-4"></a>
### 13.4 What branching strategy do you use?
**Answer:** To be added.

<a id="q-13-5"></a>
### 13.5 Have you worked with AWS or Azure?
**Answer:** To be added.

<a id="q-13-6"></a>
### 13.6 What AWS services have you used?
**Answer:** To be added.

<a id="q-13-7"></a>
### 13.7 What is CI/CD?
**Answer:** To be added.

<a id="q-13-8"></a>
### 13.8 What is Docker?
**Answer:** To be added.

<a id="q-13-9"></a>
### 13.9 What is Kubernetes?
**Answer:** To be added.

<a id="q-13-10"></a>
### 13.10 What is environment configuration management?
**Answer:** To be added.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-14"></a>
## 14. Coding Questions Asked

<a id="q-14-1"></a>
### 14.1 Find number closest to zero.
**Answer:** To be added.

<a id="q-14-2"></a>
### 14.2 FizzBuzz problem.
**Answer:** To be added.

<a id="q-14-3"></a>
### 14.3 Progressive substring printing.
**Answer:** To be added.

<a id="q-14-4"></a>
### 14.4 Array or string iteration problems.
**Answer:** To be added.

<a id="q-14-5"></a>
### 14.5 Divisibility logic problems.
**Answer:** To be added.

<a id="q-14-6"></a>
### 14.6 Basic loop and condition problems.
**Answer:** To be added.

<a id="q-14-7"></a>
### 14.7 Simple optimization logic problems.
**Answer:** To be added.

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
### 3.17 Your new question here?
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
- Question heading: `### 5.3 How is DI implemented in .NET?`

### Safe Editing Rules

- Prefer adding new questions at the end of a section to avoid renumbering everything.
- If you insert a question in the middle, you must renumber all later questions in that section.
- If you renumber questions, also update the TOC links, anchors, headings, section count, and top total count.
- Keep the `Back to Top` links unchanged.

### How to Add a New Section

1. Add a new `<details>` block in the table of contents.
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
- add an answer placeholder as: **Answer:** To be added.

Also update:
- the section question count
- the total question count at the top

Do not break existing numbering or links.
```
