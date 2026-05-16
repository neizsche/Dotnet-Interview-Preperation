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

<table>
<tr><th align="left">1.1 Explain the four OOP principles with real-world examples.</th></tr>
<tr><td>



In production .NET systems, the four OOP principles aren't just theory — they're the foundation of how I structure services, isolate concerns, and keep systems maintainable at scale. Here's how I think about each one:

**Encapsulation** — I treat this as state protection. A class owns its data, and nothing outside should be able to put it into an invalid state. In practice, this means private backing fields exposed through properties with validation, or returning `IReadOnlyCollection<T>` instead of a raw `List<T>`. In a payment service, for example, `_balance` is never publicly settable — mutations go through `Debit()` or `Credit()`, which enforce overdraft rules. The CLR enforces this at the IL level: access modifiers are baked into metadata, and the JIT will reject illegal access attempts.

**Abstraction** — This is about exposing *what* something does while hiding *how*. I rely heavily on interfaces to model this — an `IPaymentGateway` with `ChargeAsync()` lets the order service process payments without knowing whether it's hitting Stripe, Razorpay, or a mock in tests. The key architectural value is that abstraction decouples the contract from the provider, which is exactly what makes DI and the Open/Closed Principle work in practice.

**Inheritance** — I use this sparingly and only for genuine "is-a" hierarchies. The classic example in enterprise code is `abstract class BaseRepository<T>` where common CRUD logic lives in the base, and `UserRepository : BaseRepository<User>` adds domain-specific queries like `GetByEmailAsync()`. At the CLR level, the derived class's MethodTable inherits the base's vtable slots. But inheritance creates the tightest coupling in OOP — if the base changes, every derived class is affected. That's why I default to composition and only reach for inheritance when there's shared state and a genuine type hierarchy.

**Polymorphism** — This is the runtime mechanism that makes extensible architectures possible. When I have a `List<INotificationChannel>` containing `EmailChannel`, `SmsChannel`, and `PushChannel`, calling `SendAsync()` on each dispatches to the correct implementation via the vtable. The CLR reads the object's `TypeHandle`, navigates to its MethodTable, and jumps to the overridden method's JIT-compiled address. This is what powers the Strategy pattern, plugin architectures, and any system where behavior varies by type without `if/else` chains.

**Performance & Tradeoffs:**

- **Virtual dispatch overhead** is real but negligible in most business applications — a vtable lookup is a single pointer dereference. The JIT can even devirtualize calls when it detects only one implementation (guarded devirtualization in .NET 7+).
- **Inheritance hierarchies deeper than 2-3 levels** become a maintenance burden — constructor chaining, fragile base class problems, and difficulty reasoning about behavior.
- **Over-abstraction** is a real anti-pattern. Creating an interface for every class when there's only ever one implementation adds indirection without value. Abstract when you have a genuine need to swap, test, or extend.

**What Interviewers Are Actually Testing:**

They want to see if you can move beyond textbook definitions. Can you explain *why* encapsulation matters when a junior developer exposes a `List<T>` publicly? Can you articulate when inheritance is the wrong choice? Do you understand that polymorphism is the physical mechanism behind SOLID, not just a concept?

**Follow-Up Questions They May Ask:**

- "How does the CLR resolve which overridden method to call?" → vtable dispatch via TypeHandle
- "When would you choose composition over inheritance?" → When there's no genuine type hierarchy, or when you need to combine behaviors from multiple sources
- "What's the difference between encapsulation and abstraction?" → State protection vs. contract simplification (covered in detail in Q1.6)
- "How does polymorphism enable the Open/Closed Principle?" → New behavior via new implementations, not by modifying existing code

**Key Terminologies to Use:**

vtable, TypeHandle, MethodTable, dynamic dispatch, callvirt IL instruction, state protection, contract-based design, guarded devirtualization, composition over inheritance

</td></tr>
</table>

<a id="q-1-2"></a>

<table>
<tr><th align="left">1.2 What is encapsulation?</th></tr>
<tr><td>



Encapsulation is bundling data and the methods that operate on it into a single unit, while restricting direct access to internal state. But in practice, it's really about **invariant enforcement** — ensuring that no external code can put your object into an invalid or inconsistent state.

The production-level reason this matters: if you expose a `List<OrderItem>` publicly on an `Order` class, any consumer can call `.Clear()` and wipe out order items without triggering recalculation of totals, tax, or shipping. Encapsulation forces mutations through controlled methods like `AddItem()` where you can enforce business rules, emit domain events, and maintain consistency.

At the CLR level, access modifiers aren't just suggestions — they're compiled into IL metadata and enforced by the JIT. A `private` field literally cannot be accessed from outside the declaring type without resorting to reflection (which bypasses the type system intentionally). This is what makes encapsulation a **compile-time and runtime guarantee**, not just a convention.

**Performance & Tradeoffs:**

- Properties compile to `get_X()` / `set_X()` method calls, but the JIT inlines trivial getters and setters, so there's zero overhead compared to direct field access in release builds.
- Overly aggressive encapsulation (e.g., making everything `private` and requiring method calls for every read) can hurt readability. Balance is key — expose `IReadOnlyCollection<T>` for reads, control writes through methods.
- In DDD, encapsulation is non-negotiable for aggregate roots — the aggregate must own its consistency boundary.

**What Interviewers Are Actually Testing:**

Whether you understand encapsulation as more than "making fields private." They want to hear about invariant protection, controlled mutation, and real consequences of breaking encapsulation (corrupted state, race conditions with exposed mutable collections, untraceable bugs).

**Key Terminologies to Use:**

invariant enforcement, state protection, controlled mutation, IL metadata, aggregate consistency boundary, IReadOnlyCollection

</td></tr>
</table>

<a id="q-1-3"></a>

<table>
<tr><th align="left">1.3 How do getters and setters support encapsulation and controlled mutation?</th></tr>
<tr><td>



Properties in C# are the primary mechanism for controlled state access. Under the hood, they compile to `get_X()` and `set_X()` IL methods, which means they're method calls — not direct memory access. This distinction has real consequences.

**Why properties over public fields:**
The critical production reason is **binary compatibility**. If you ship a library with a public field `public string Name;` and later need to add validation (say, trimming whitespace or enforcing max length), changing it to a property breaks binary compatibility — consuming assemblies compiled against the field will throw `MissingFieldException` at runtime without recompilation. Properties avoid this entirely because the method signature never changes even when you add logic inside.

**Controlled mutation patterns I use regularly:**
- **Validation in setters** — e.g., a `Price` setter that rejects negative values before persisting to the backing field.
- **Computed/derived properties** — `public decimal Total => Items.Sum(i => i.Price * i.Quantity);` — no backing field at all, always consistent.
- **`init` accessors (C# 9+)** — allow setting only during object initialization, which is perfect for immutable DTOs and record-like types. This matters for thread safety since the object can't be mutated after construction.
- **`INotifyPropertyChanged`** — in MVVM/Blazor scenarios, setters fire change notifications to trigger UI re-renders.

**Internal Runtime Behavior:**

The JIT inlines trivial property accessors (simple get/set with no logic), so there's zero performance penalty compared to direct field access in optimized builds. Auto-properties like `public string Name { get; set; }` generate a hidden `<Name>k__BackingField` in IL — the compiler handles the plumbing.

**What Interviewers Are Actually Testing:**

Whether you know *why* C# conventions strongly prefer properties over fields, and whether you've dealt with the binary compatibility issue in practice. They may also probe whether you understand `init` vs `set` and when to use each.

**Key Terminologies to Use:**

binary compatibility, MissingFieldException, init-only setter, computed property, auto-property backing field, JIT inlining

</td></tr>
</table>

<a id="q-1-4"></a>

<table>
<tr><th align="left">1.4 Show encapsulation with example.</th></tr>
<tr><td>



Here's a realistic example from a fintech domain — a `Wallet` aggregate that protects its balance invariant:

**❌ Without encapsulation (the bug waiting to happen):**
```csharp
public class Wallet
{
    public decimal Balance { get; set; }  // Anyone can set this to -1000
    public List<Transaction> Transactions { get; set; } = new();  // Anyone can .Clear() this
}
```
A junior developer could write `wallet.Balance -= amount;` anywhere in the codebase, bypassing overdraft checks, audit logging, and domain event publishing.

**✅ With encapsulation (production-ready):**
```csharp
public class Wallet
{
    private decimal _balance;
    private readonly List<Transaction> _transactions = new();

    public decimal Balance => _balance;  // Read-only projection
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    public void Debit(decimal amount, string reason)
    {
        if (amount <= 0)
            throw new ArgumentException("Debit amount must be positive.");

        if (_balance - amount < 0)
            throw new InsufficientFundsException(_balance, amount);

        _balance -= amount;
        _transactions.Add(new Transaction(-amount, reason, DateTime.UtcNow));
        // Could also raise a domain event here: DomainEvents.Raise(new WalletDebited(...))
    }
}
```

**Why this matters in production:**
- Every mutation goes through `Debit()` — overdraft rules, audit trails, and event publishing are guaranteed to execute.
- External code cannot call `wallet.Transactions.Add()` because `IReadOnlyCollection<T>` doesn't expose mutation methods.
- If requirements change (e.g., adding daily withdrawal limits), you modify one method — not every call site across the codebase.

**What Interviewers Are Actually Testing:**

Can you demonstrate encapsulation with a domain-relevant example that shows *consequences* of breaking it? The ShoppingCart example is overused — pick something that naturally implies business rules and invariants.

</td></tr>
</table>

<a id="q-1-5"></a>

<table>
<tr><th align="left">1.5 What is abstraction?</th></tr>
<tr><td>



Abstraction is about exposing *what* an object does while hiding *how* it does it. But more practically, it's the mechanism that lets you swap implementations without touching consumer code.

Consider a document storage service. The business logic calls `IDocumentStore.SaveAsync(doc)`. Behind that interface, you might have `AzureBlobDocumentStore` in production, `LocalFileDocumentStore` in development, and `InMemoryDocumentStore` in tests. The service layer doesn't know or care — it operates against the contract. That's abstraction doing its job.

In C#, abstraction is modeled through **interfaces** (contract-only, no state) and **abstract classes** (contract + shared implementation + state). The key architectural decision is which to use — interfaces when you're defining capabilities across unrelated types, abstract classes when you're modeling a genuine type family with shared behavior.

**Where abstraction earns its keep in production:**
- **Provider integrations** — wrapping third-party SDKs (payment gateways, SMS providers, cloud storage) behind your own interface so you can swap vendors without a codebase-wide refactor.
- **Testability** — you can't easily mock `HttpClient` directly, but you can mock `IHttpClientFactory` or your own `IExternalApiClient`.
- **Feature flags** — an `IFeatureEvaluator` abstracted over LaunchDarkly, AppConfig, or a simple in-memory dictionary.

**Performance & Tradeoffs:**

- Abstraction adds a level of indirection. Interface method dispatch involves a lookup through the interface map (slightly more expensive than virtual dispatch, but the JIT aggressively optimizes common paths).
- **Over-abstraction** is a real trap — if there will only ever be one implementation of `IOrderService`, the interface exists solely as ceremony. Abstract when there's a genuine reason to swap, mock, or extend.

**What Interviewers Are Actually Testing:**

Whether you can distinguish abstraction (simplifying the external contract) from encapsulation (protecting internal state). They also want to see if you've used abstraction to solve real problems — not just as a DI formality.

**Key Terminologies to Use:**

contract-based design, provider isolation, interface map, implementation swapping, testability seam

</td></tr>
</table>

<a id="q-1-6"></a>

<table>
<tr><th align="left">1.6 Difference between abstraction and encapsulation?</th></tr>
<tr><td>



This is a common trap question because candidates often conflate the two. The simplest way I distinguish them:

**Abstraction** answers: *"What does this thing do?"* — it simplifies the external contract. An `IEmailSender` with `SendAsync()` hides whether it's using SMTP, SendGrid, or a queue-backed approach.

**Encapsulation** answers: *"How does this thing protect its data?"* — it controls access to internal state. The `SmtpEmailSender` class keeps its `_smtpClient` private and validates recipients in `SendAsync()` before actually transmitting.

**Both principles in one class:**
```csharp
// Abstraction: the interface hides the "how"
public interface IOrderPricer { decimal CalculateTotal(Order order); }

// Encapsulation: the implementation protects its internal state
public class OrderPricer : IOrderPricer
{
    private readonly Dictionary<string, decimal> _discountCache;  // Hidden state

    public decimal CalculateTotal(Order order)
    {
        // Consumers see a simple method. Internally, it manages caching,
        // applies tiered discounts, and handles tax calculation — all hidden.
    }
}
```

| Dimension | Abstraction | Encapsulation |
|---|---|---|
| **Scope** | Operates at the **design/architecture** level | Operates at the **class/object** level |
| **Mechanism** | Interfaces, abstract classes | Access modifiers, properties, readonly fields |
| **What it hides** | Implementation complexity | Internal state and data |
| **Changes independently** | Implementations can vary | Internal structure can evolve without breaking consumers |

**What Interviewers Are Actually Testing:**

Whether you can articulate the *direction* of hiding. Abstraction hides complexity from the consumer outward. Encapsulation hides state from the outside inward. If you can say this crisply with an example, you've nailed it.

</td></tr>
</table>

<a id="q-1-7"></a>

<table>
<tr><th align="left">1.7 What are access modifiers in C#?</th></tr>
<tr><td>



Access modifiers are keywords that control the visibility scope of types and members. But beyond the definition, they're the **enforcement mechanism** for encapsulation — the CLR compiles them into IL metadata and the JIT strictly validates access at runtime, not just compile time.

C# provides six access levels: `public`, `private`, `protected`, `internal`, `protected internal`, and `private protected`. The important defaults to know:
- **Members** default to `private` (most restrictive).
- **Top-level types** default to `internal` (assembly-scoped).

In a well-architected solution, `internal` is arguably the most underused modifier. In a layered architecture with separate assemblies (e.g., `Domain.dll`, `Infrastructure.dll`, `Api.dll`), marking domain services as `internal` prevents the API layer from bypassing the service layer and accessing domain logic directly. You then expose only what's needed via `public` interfaces. For unit testing `internal` members, use `[InternalsVisibleTo("YourProject.Tests")]` in `AssemblyInfo` — this is a standard practice, not a hack.

**What Interviewers Are Actually Testing:**

Whether you know the defaults (members → private, types → internal), can explain `protected internal` vs `private protected` without confusing the OR/AND semantics, and understand how `internal` supports multi-assembly architecture.

</td></tr>
</table>

<a id="q-1-8"></a>

<table>
<tr><th align="left">1.8 Difference between `public`, `private`, `protected`, `internal`, and `protected internal`?</th></tr>
<tr><td>



| Modifier | Scope | When I Use It |
|---|---|---|
| **`public`** | Anywhere | External-facing API surface — controller methods, interface contracts, DTOs. |
| **`private`** | Declaring type only | Default for fields and helper methods. The backbone of encapsulation. |
| **`protected`** | Declaring type + derived types | Base class members that child classes need to access or override — e.g., `protected virtual Task<T> ExecuteQueryAsync()` in a `BaseRepository`. |
| **`internal`** | Same assembly | Domain services, repositories, and infrastructure classes that shouldn't leak into the API layer. Combined with `InternalsVisibleTo` for test projects. |
| **`protected internal`** | Same assembly **OR** derived types (even cross-assembly) | Framework extensibility — the ASP.NET Core source uses this for methods that need both internal and inheritance-based access. Think of it as the **union** (OR). |
| **`private protected`** | Derived types **AND** same assembly only | The most restrictive compound modifier. Use when you want to allow inheritance within your assembly but prevent third-party assemblies from accessing base class internals even through derivation. Think of it as the **intersection** (AND). |

**The interview gotcha:** Candidates frequently confuse `protected internal` (OR — more permissive) with `private protected` (AND — more restrictive). Remembering "protected internal = union, private protected = intersection" is the key.

</td></tr>
</table>

<a id="q-1-9"></a>

<table>
<tr><th align="left">1.9 How do access modifiers support encapsulation?</th></tr>
<tr><td>



Access modifiers are the physical enforcement of encapsulation — they're not just conventions, they're compiled into IL and validated by the CLR. But the architectural value I focus on is **blast radius control**.

When a field is `private`, I can rename it, change its type, or remove it entirely without any risk of breaking code outside the class. When a method is `internal`, I can refactor it freely without worrying about consumers in other assemblies. The moment something becomes `public`, it's a **contract** — any change is a potential breaking change for every consumer.

In practice, this means I default to the most restrictive modifier and widen only when necessary:
- Start with `private` for everything.
- Promote to `protected` only if a derived class genuinely needs access.
- Use `internal` when cross-class access is needed within the same assembly.
- Only use `public` for the intentional API surface.

This discipline directly reduces the surface area for bugs. If a `_connectionString` field is `private`, exactly one class can misuse it. If it's `public`, the entire codebase can.

**What Interviewers Are Actually Testing:**

Whether you approach access modifiers as a design decision (minimizing public surface area) rather than just defaulting everything to `public` because it's easier. The "blast radius" framing shows architectural maturity.

</td></tr>
</table>

<a id="q-1-10"></a>

<table>
<tr><th align="left">1.10 What is inheritance?</th></tr>
<tr><td>



Inheritance establishes an "is-a" relationship where a derived class acquires the fields, properties, and methods of a base class. At the CLR level, the derived type's MethodTable inherits the base's vtable slots, and type metadata maintains a parent pointer for the runtime to walk the hierarchy.

But here's what I emphasize in practice: **inheritance is the strongest form of coupling in OOP**. When a base class changes — adding a required constructor parameter, modifying a protected method's behavior, or introducing a new virtual method — every derived class is affected. This is the "fragile base class" problem.

I use inheritance when:
- There's a genuine, stable type hierarchy (e.g., `Stream` → `FileStream`, `MemoryStream`)
- I need to share both state and behavior across related types (the Template Method pattern)
- The base class is under my control and unlikely to change frequently

I avoid inheritance when:
- The relationship is behavioral rather than hierarchical — use interfaces + composition instead
- The hierarchy would go deeper than 2-3 levels
- I'm tempted to inherit just for code reuse (that's what composition is for)

**What Interviewers Are Actually Testing:**

Whether you can articulate the tradeoffs. A senior who says "I use inheritance sparingly because of tight coupling and the fragile base class problem" signals more maturity than one who just explains the is-a relationship.

</td></tr>
</table>

<a id="q-1-11"></a>

<table>
<tr><th align="left">1.11 Explain inheritance using Animal/Dog example.</th></tr>
<tr><td>



The `Animal/Dog` example is a textbook staple, but I'll provide it alongside the enterprise parallel:

```csharp
public abstract class Animal
{
    public string Name { get; set; }
    public virtual void MakeSound() => Console.WriteLine("...");
}

public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine("Bark!");
    public void Fetch() => Console.WriteLine("Fetching...");
}
```

**What this demonstrates:** `Dog` inherits `Name` without redeclaring it, overrides `MakeSound()` for specialized behavior, and adds `Fetch()` as its own capability.

**Enterprise equivalent:** The same pattern appears in production as:
```csharp
public abstract class BaseNotificationHandler
{
    protected readonly ILogger _logger;
    protected BaseNotificationHandler(ILogger logger) => _logger = logger;

    public async Task HandleAsync(Notification n)
    {
        _logger.LogInformation("Processing {Type}", n.Type);
        await SendAsync(n);  // Template Method — child provides the specifics
    }

    protected abstract Task SendAsync(Notification n);
}

public class SlackNotificationHandler : BaseNotificationHandler
{
    protected override Task SendAsync(Notification n) => _slackClient.PostAsync(n.Message);
}
```
This is the **Template Method** pattern — the base class defines the workflow skeleton (`HandleAsync`), the derived class fills in the provider-specific step (`SendAsync`).

</td></tr>
</table>

<a id="q-1-12"></a>

<table>
<tr><th align="left">1.12 How do you achieve multiple inheritance in C#?</th></tr>
<tr><td>



C# deliberately blocks multiple class inheritance to avoid the Diamond Problem (ambiguity when two base classes provide conflicting implementations of the same method). Instead, C# offers three practical approaches:

**1. Multiple interface implementation** — inherit contracts, not behavior:
```csharp
public class OrderService : IOrderProcessor, IAuditable, IDisposable { ... }
```
The class satisfies three orthogonal contracts without any implementation ambiguity.

**2. Composition + delegation (preferred in production):**
```csharp
public class NotificationService
{
    private readonly IEmailSender _email;
    private readonly ISmsSender _sms;
    private readonly IPushSender _push;

    public NotificationService(IEmailSender email, ISmsSender sms, IPushSender push)
    {
        _email = email; _sms = sms; _push = push;
    }

    public async Task NotifyAsync(User user, string message)
    {
        await _email.SendAsync(user.Email, message);
        if (user.PhoneVerified) await _sms.SendAsync(user.Phone, message);
    }
}
```
This is how you combine behaviors from multiple sources without inheritance — inject capabilities as dependencies.

**3. Default Interface Methods (C# 8+)** — limited multiple implementation inheritance through interfaces. Useful for API evolution, but not a replacement for composition in application code.

**What Interviewers Are Actually Testing:**

Whether you default to composition over inheritance, and whether you understand why C# made this design decision. Bonus points for mentioning the Diamond Problem by name.

</td></tr>
</table>

<a id="q-1-13"></a>

<table>
<tr><th align="left">1.13 What is polymorphism?</th></tr>
<tr><td>



Polymorphism is the ability to treat different types uniformly through a shared interface or base class, with each type providing its own behavior. In .NET, this is what eliminates `if/else` and `switch` chains for type-specific behavior.

Consider a trading system that needs to calculate fees differently for stocks, options, and futures. Without polymorphism, you'd have a growing `switch(instrumentType)` block. With polymorphism:

```csharp
public interface IFeeCalculator { decimal Calculate(Trade trade); }

public class StockFeeCalculator : IFeeCalculator { ... }
public class OptionsFeeCalculator : IFeeCalculator { ... }
public class FuturesFeeCalculator : IFeeCalculator { ... }
```

The trade processing service calls `calculator.Calculate(trade)` — the CLR dispatches to the correct implementation via the vtable (for virtual methods) or interface map (for interface dispatch). Adding a new instrument type means adding a new class — zero changes to existing code. That's the Open/Closed Principle in action, powered by polymorphism.

Polymorphism comes in two forms in C#:
- **Compile-time** (method overloading) — resolved by the compiler based on argument types
- **Runtime** (method overriding / interface dispatch) — resolved by the CLR based on the actual object instance

Runtime polymorphism is architecturally significant because it enables DI, Strategy pattern, and plugin-based designs.

**What Interviewers Are Actually Testing:**

Whether you see polymorphism as an architecture tool (eliminating conditionals, enabling extensibility) rather than just a language feature. Reference the vtable briefly — deep internals are covered in Q1.29-Q1.32.

</td></tr>
</table>

<a id="q-1-14"></a>

<table>
<tr><th align="left">1.14 Difference between compile-time and runtime polymorphism?</th></tr>
<tr><td>



| Aspect | Compile-Time (Static) | Runtime (Dynamic) |
|---|---|---|
| **Resolution** | Compiler picks the method based on parameter signatures | CLR picks the method based on the actual object's type at runtime |
| **Mechanism** | Method overloading, operator overloading | Method overriding (`virtual`/`override`), interface dispatch |
| **IL Instruction** | `call` — direct jump to a known address | `callvirt` — indirect jump via vtable/interface map lookup |
| **Performance** | Zero overhead (resolved at compile time, can be inlined) | Negligible overhead — one pointer dereference through the vtable |
| **Architectural Impact** | Convenience (same method name for different parameter sets) | Enables DI, Strategy, Plugin, and every SOLID-driven pattern |

**The key distinction:** Compile-time polymorphism is syntactic sugar — it doesn't change program architecture. Runtime polymorphism is what makes systems extensible. When a senior talks about polymorphism in the context of architecture, they almost always mean runtime polymorphism.

**IL-level insight:** The C# compiler emits `callvirt` even for non-virtual instance methods (for null-check safety). The JIT optimizer may devirtualize the call if it can prove the concrete type at compile time (sealed classes, or when there's only one implementation).

</td></tr>
</table>

<a id="q-1-15"></a>

<table>
<tr><th align="left">1.15 What is method overloading?</th></tr>
<tr><td>



Method overloading is compile-time polymorphism — multiple methods share the same name but differ in parameter count, types, or order. The compiler resolves which overload to call based on the arguments at the call site.

In production, I see this most commonly in:
- **Builder/fluent APIs** — `AddPolicy(string name)` vs `AddPolicy(string name, Action<PolicyBuilder> configure)`
- **Extension methods** — LINQ's `Where(Func<T, bool>)` vs `Where(Func<T, int, bool>)` (the second provides the element index)
- **Constructor overloads** — allowing flexible object creation with sensible defaults

**Gotcha to mention in interviews:** Overloading interacts poorly with **optional parameters**. If you have `Process(int x, int y = 0)` and `Process(int x)`, the compiler throws an ambiguity error when you call `Process(5)`. This is a real source of bugs in evolving APIs.

**What Interviewers Are Actually Testing:**

Whether you know that overloading is resolved at compile time (not runtime), and whether you can distinguish it from overriding. The optional parameter conflict is a bonus point.

</td></tr>
</table>

<a id="q-1-16"></a>

<table>
<tr><th align="left">1.16 Why is overloading not possible using return type alone?</th></tr>
<tr><td>



The C# compiler uses only the **method name and parameter list** as the method signature for overload resolution. The return type is explicitly excluded.

The reason is straightforward: if you have `int GetValue()` and `string GetValue()`, a call like `GetValue();` (where the return value is discarded or assigned to `var`) gives the compiler zero information to disambiguate. Method resolution must be deterministic based solely on the call-site arguments, not on how the caller uses the result.

**Note:** At the IL level, return type *is* part of the method's full metadata signature. This is why two methods can coexist in IL with the same name and parameters but different return types (used in covariant return types in C# 9+). But the C# language specification still prohibits overloading on return type alone for the ambiguity reason above.

</td></tr>
</table>

<a id="q-1-17"></a>

<table>
<tr><th align="left">1.17 What is method overriding?</th></tr>
<tr><td>



Method overriding is how a derived class replaces a base class's behavior while maintaining the polymorphic contract. The base method must be `virtual` or `abstract`, and the derived method uses `override` with an identical signature.

What makes overriding powerful is the **late binding guarantee**: even if the object is referenced through a base type variable (`Animal a = new Dog()`), calling `a.MakeSound()` executes `Dog.MakeSound()`. The CLR achieves this by replacing the method pointer in the derived class's vtable slot — as discussed in Q1.30-Q1.32.

In production, I use overriding for:
- **Template Method implementations** — `BaseHandler.ProcessAsync()` calls `abstract ValidateAsync()` which each derived handler overrides
- **Framework extension points** — overriding `OnActionExecuting()` in a custom `ActionFilterAttribute`
- **EF Core configurations** — overriding `OnModelCreating()` in `DbContext`

**What Interviewers Are Actually Testing:**

That you understand overriding replaces vtable entries (late binding), not just that it "changes behavior." They may test this by asking what happens when you upcast — the overridden method still executes.

</td></tr>
</table>

<a id="q-1-18"></a>

<table>
<tr><th align="left">1.18 Difference between method overloading and method overriding</th></tr>
<tr><td>



| Aspect | Overloading | Overriding |
|---|---|---|
| **When resolved** | Compile time | Runtime |
| **Where it happens** | Same class (or extension methods) | Base → derived class |
| **Signature** | Must differ (parameter types/count) | Must be identical |
| **Keywords** | None required | `virtual`/`abstract` + `override` |
| **IL instruction** | `call` (direct dispatch) | `callvirt` (vtable lookup) |
| **Binding** | Early/static | Late/dynamic |

The architectural difference: overloading is API convenience (same name, different inputs). Overriding is behavioral substitution (same contract, different implementation). Only overriding participates in runtime polymorphism and enables patterns like Strategy, Template Method, and DI-based dispatch.

</td></tr>
</table>

<a id="q-1-19"></a>

<table>
<tr><th align="left">1.19 What happens when both parent and child define the same method? Explain `virtual`, `override`, and `new`.</th></tr>
<tr><td>



Without explicit keywords, the C# compiler warns: *"member hides inherited member; use the new keyword if hiding was intended."* You must declare your intent:

```csharp
public class Base
{
    public virtual void Execute() => Console.WriteLine("Base");
}

public class DerivedOverride : Base
{
    public override void Execute() => Console.WriteLine("Override");
}

public class DerivedHide : Base
{
    public new void Execute() => Console.WriteLine("Hidden");
}

// The critical behavioral difference:
Base a = new DerivedOverride();
a.Execute();  // Output: "Override" — vtable dispatch to derived method

Base b = new DerivedHide();
b.Execute();  // Output: "Base" — polymorphic link is severed
```

**Summary:**
- `virtual` — *"This method can be overridden"* (creates a vtable slot)
- `override` — *"I'm replacing the vtable entry"* (late binding preserved)
- `new` — *"I'm creating a completely separate method that shares the name"* (early binding based on reference type)

**What Interviewers Are Actually Testing:**

They want to see if you can predict the output of `Base ref = new Derived()` scenarios. The code example above is essentially what they'll put on a whiteboard.

</td></tr>
</table>

<a id="q-1-20"></a>

<table>
<tr><th align="left">1.20 What is method hiding in C#?</th></tr>
<tr><td>



Method hiding occurs when a derived class defines a method with the exact same signature as a base class method, but uses the `new` keyword instead of `override`.

In production code, **method hiding is generally considered an anti-pattern** if used intentionally in new designs. It severs the polymorphic link. The method that gets executed depends entirely on the type of the variable referencing the object (early binding), not the actual type of the object in memory (late binding).

**The only real production use case (The Brittle Base Class Problem):**
You inherit from a third-party framework class `BaseController`. You write a method `public void Process()`. Six months later, the framework vendor updates `BaseController` and adds their own `public virtual void Process()`. Suddenly, your method signature clashes with the base class. By adding `new` to your method, you hide the framework's method, preventing your existing consumers from breaking while acknowledging the collision.

**What Interviewers Are Actually Testing:**

They want to know if you understand that `new` breaks polymorphism and enforces early binding. If you say "I use it all the time to change base class behavior," that's a red flag. A senior knows it's an escape hatch for versioning, not a design tool.

</td></tr>
</table>

<a id="q-1-21"></a>

<table>
<tr><th align="left">1.21 Difference between method hiding and method overriding</th></tr>
<tr><td>



This is a fundamental test of understanding how the CLR resolves method calls.

| Aspect | Overriding (`override`) | Hiding (`new`) |
|---|---|---|
| **Polymorphic Link** | Preserved. Modifies the vtable. | Severed. Creates a separate method slot. |
| **Execution depends on** | The **actual object instance** (Late Binding) | The **variable reference type** (Early Binding) |
| **Base method requirement** | Must be `virtual` or `abstract` | Can be anything (virtual, regular, etc.) |
| **Architectural Role** | The core of extensible, SOLID design | A versioning escape hatch; otherwise an anti-pattern |

If you have `Base ref = new Derived();`, calling an overridden method executes the `Derived` logic. Calling a hidden method executes the `Base` logic.

</td></tr>
</table>

<a id="q-1-22"></a>

<table>
<tr><th align="left">1.22 Purpose of the `new` keyword in method hiding</th></tr>
<tr><td>



The `new` keyword explicitly tells the compiler: *"I know a base class method has the same name, and I am intentionally hiding it. Don't warn me."*

Without the `new` keyword, the compiler issues a warning (CS0108), but it still compiles and **defaults to hiding**. The keyword itself doesn't change the execution behavior; it's an explicit declaration of developer intent to suppress the warning.

As mentioned, its primary architectural purpose is defending against the **Brittle Base Class** problem. If a base class is updated in a newer version of a library to include a method signature that you already happen to be using in your derived class, you use `new` to tell the compiler that your method is completely unrelated to the new base method, preventing accidental polymorphic overrides that could break your application's logic.

</td></tr>
</table>

<a id="q-1-23"></a>

<table>
<tr><th align="left">1.23 What is the difference between `virtual`, `override`, and `abstract`?</th></tr>
<tr><td>



These keywords dictate the contract between a base class and its inheritors regarding polymorphic behavior.

| Keyword | Used In | Meaning & Enforcement |
|---|---|---|
| **`abstract`** | Base Class | **Mandatory.** Defines a contract with no implementation. Derived classes *must* provide an `override` body (unless they are also abstract). Used when there's no sensible default behavior. |
| **`virtual`** | Base Class | **Optional.** Provides a default implementation and opens a slot in the vtable. Derived classes *may* override it to specialize behavior, but they don't have to. |
| **`override`** | Derived Class | **Implementation.** Replaces the base class's `virtual` or `abstract` vtable entry with the derived method's JIT-compiled address. |

**Production Context:** I make base methods `abstract` when the step is crucial to the workflow but highly specific (like `SaveToDatabase()`). I make them `virtual` when there is a perfectly good default, but a specific subclass might need to optimize it (like `CalculateShipping()`). I never make a method `virtual` "just in case" — it breaks encapsulation and makes the base class harder to reason about.

</td></tr>
</table>

<a id="q-1-24"></a>

<table>
<tr><th align="left">1.24 Difference between `virtual`, `override`, and `new`</th></tr>
<tr><td>



While `virtual` and `override` work together to *enable* polymorphism, `new` actively *breaks* it.

- **`virtual`**: Signals that a method *can* be overridden. (Creates a slot in the vtable).
- **`override`**: Signals that a method *is* overriding a base `virtual` method. (Replaces the pointer in the vtable).
- **`new`**: Signals that a method *happens to share the same name* as a base method, but is completely unrelated polymorphically. (Creates a new, separate slot).

**The Whiteboard Test:**
```csharp
Animal myDog = new Dog(); // Base reference, Derived instance

// Scenario A: SpeakVirtual is marked 'override' in Dog
myDog.SpeakVirtual(); 
// Outputs: "Bark" (Late binding via vtable dispatch looks at the actual object)

// Scenario B: SpeakHidden is marked 'new' in Dog
myDog.SpeakHidden();  
// Outputs: "Generic Animal Noise" (Early binding looks at the variable type 'Animal')
```

**What Interviewers Are Actually Testing:**

They want to see if you intuitively grasp the difference between late binding (checking the object in memory) and early binding (checking the variable declaration).

</td></tr>
</table>

<a id="q-1-25"></a>

<table>
<tr><th align="left">1.25 What is upcasting vs downcasting?</th></tr>
<tr><td>



Upcasting and downcasting are about changing the *reference type* (the lens through which you view the object), not the object itself in memory.

**Upcasting (Derived → Base):** 
- It is implicitly safe. A `Dog` *is a* `Animal`. It's guaranteed to have all the base class members.
- **Production Use:** Used everywhere in DI and API design. E.g., returning a `List<T>` as an `IEnumerable<T>`.

**Downcasting (Base → Derived):**
- It is intrinsically unsafe. An `Animal` might be a `Dog`, but it might be a `Cat`. The compiler forces you to make an explicit cast to acknowledge the risk.
- **Production Use:** You receive a generic `object` from an event handler or weakly-typed legacy API (e.g., `EventArgs e`) and need to access its specific properties.

**What Interviewers Are Actually Testing:**

They want to see if you understand that casting **does not mutate the object**. The object on the heap remains exactly what it was instantiated as. Casting only changes the contract the compiler allows you to use to interact with it.

</td></tr>
</table>

<a id="q-1-26"></a>

<table>
<tr><th align="left">1.26 What happens during invalid downcasting, and why does it fail?</th></tr>
<tr><td>



If you attempt a hard downcast (`(Dog)myAnimal`) and the object in memory isn't actually a `Dog` (or a type derived from `Dog`), the CLR throws an `InvalidCastException`.

**Why it fails internally:** Every object on the managed heap has a hidden header containing a `TypeHandle` pointer. When you attempt a hard cast, the CLR type-safety engine inspects this `TypeHandle` to see the actual concrete type. If it doesn't match the cast target, it aggressively aborts. If it didn't, you'd be able to call `Fetch()` on an object that only allocated memory for `Meow()`, leading to critical memory corruption and security vulnerabilities.

**Production Best Practices for Safe Downcasting:**
Never use a hard cast unless you are 100% mathematically certain of the type (e.g., you just instantiated it). Instead, use modern C# pattern matching:

```csharp
// The modern, safe way (C# 7+)
if (myAnimal is Dog myDog)
{
    myDog.Fetch(); // myDog is scoped and safely cast here
}

// The older, safe way using 'as' (useful if you need the variable outside an if block)
var myDog = myAnimal as Dog;
if (myDog != null)
{
    myDog.Fetch();
}
```

</td></tr>
</table>

<a id="q-1-27"></a>

<table>
<tr><th align="left">1.27 How does method overriding behave during upcasting and downcasting?</th></tr>
<tr><td>



This is the golden rule of late binding: **Method overriding is completely immune to the reference type.**

Whether you upcast an object to its base class or an interface, if you invoke a `virtual` method that has been `override`n, the CLR *always* executes the most derived implementation.

**Why?** Because the actual object allocated on the heap never changes, and neither does its `TypeHandle` or its `MethodTable` (vtable). When the compiler emits the `callvirt` IL instruction, it tells the CLR: *"Don't look at the variable type. Go out to the heap, find the object, look at its actual vtable, and execute the pointer in that specific slot."*

*Caveat:* If the derived class used `new` instead of `override` (method hiding), the polymorphic link is broken. The compiler emits a standard `call` instruction based on the variable's reference type, bypassing the dynamic vtable lookup entirely.

</td></tr>
</table>

<a id="q-1-28"></a>

<table>
<tr><th align="left">1.28 What is early binding vs late binding?</th></tr>
<tr><td>



Binding is the process of linking a method call in code to the actual memory address of the executable instructions.

| Feature | Early Binding (Static Binding) | Late Binding (Dynamic Binding) |
|---|---|---|
| **When it happens** | Compile time | Runtime |
| **How it works** | The compiler hardcodes the exact method address (or metadata token) based on the variable's declared type. | The CLR dynamically looks up the method address in the actual object's vtable at execution time. |
| **Mechanisms** | Normal methods, overloaded methods, static methods, hidden (`new`) methods | Overridden methods (`virtual`/`override`), interface implementations, `dynamic` keyword |
| **Performance** | Faster (direct execution) | Slight overhead (pointer dereference) |
| **Flexibility** | Rigid | Extensible |

In senior engineering, you use **early binding** for predictable, high-performance, internal logic (static helpers, private methods), and **late binding** at the seams of your architecture (interfaces, base classes) where you need extensibility and testability.

</td></tr>
</table>

<a id="q-1-29"></a>

<table>
<tr><th align="left">1.29 What is virtual method dispatch?</th></tr>
<tr><td>



Virtual method dispatch is the internal CLR mechanism that powers late binding and polymorphism.

When you call a normal (non-virtual) method, the compiler knows exactly where the code lives. But when you call `repository.SaveAsync()` and `repository` is an interface or base class, the runtime cannot hardcode the jump address — it might be a `SqlRepository` or a `MockRepository` at runtime.

The CLR must dynamically "dispatch" (route) the call to the correct implementation. It does this by emitting a special IL instruction called `callvirt`. At runtime, `callvirt` forces the CLR to pause, inspect the actual object sitting in heap memory, read its type metadata, and look up the correct method address in that type's **vtable** (Virtual Method Table) before jumping to the executable code.

</td></tr>
</table>

<a id="q-1-30"></a>

<table>
<tr><th align="left">1.30 What is a virtual method table, and how does the CLR decide which overridden method to execute?</th></tr>
<tr><td>



The **vtable** (Virtual Method Table) is a hidden array of function pointers maintained by the CLR for any class that defines or inherits virtual methods. It maps method signatures to the actual JIT-compiled memory addresses of their implementations.

**The Lookup Process (How the CLR decides):**
1. **The Call:** Your code executes `baseRef.Execute()`. The compiler has emitted a `callvirt` IL instruction.
2. **Null Check:** `callvirt` implicitly checks if `baseRef` is null (throwing `NullReferenceException` if so).
3. **The Object Header:** The CLR goes to the heap memory where the actual object lives. It reads the hidden `TypeHandle` pointer in the object's header.
4. **The MethodTable:** The `TypeHandle` points to the class's `MethodTable` data structure in the AppDomain.
5. **The Vtable Slot:** Inside the `MethodTable` is the vtable. The CLR knows `Execute()` is at a specific offset (e.g., slot #4).
6. **The Jump:** The CLR reads the memory address stored in slot #4 and jumps the CPU instruction pointer to that exact address to execute the method.

If the class used `override`, slot #4 contains the address of the derived method. If it didn't, slot #4 contains the inherited base method's address.

</td></tr>
</table>

<a id="q-1-31"></a>

<table>
<tr><th align="left">1.31 How does runtime polymorphism work internally?</th></tr>
<tr><td>



Internally, runtime polymorphism is the coordination of three CLR features: **the `callvirt` instruction, the object header, and the vtable.**

When a class is loaded into an AppDomain, the CLR builds a `MethodTable` for it. If `ClassB` inherits from `ClassA`, the CLR copies `ClassA`'s vtable structure into `ClassB`'s `MethodTable`.

If `ClassB` declares an `override` for a virtual method, the CLR updates that specific slot in `ClassB`'s vtable. It replaces the memory address pointing to the base method's JIT-compiled code with the address pointing to the derived method's JIT-compiled code.

When you execute code against a base reference, the `callvirt` instruction forces the runtime to ignore the reference type, follow the object's `TypeHandle` in heap memory to its specific `MethodTable`, and pull the pointer from the overridden slot. 

This means polymorphism isn't magic; it's just dynamic pointer replacement at type-load time, followed by dynamic pointer dereferencing at execution time.

**What Interviewers Are Actually Testing:**

If they ask this deeply, they are looking for terms like `TypeHandle`, `MethodTable`, `vtable slot replacement`, and `callvirt`. Answering this fluently proves you understand the physical machine costs of abstractions.

</td></tr>
</table>

<a id="q-1-32"></a>

<table>
<tr><th align="left">1.32 What happens internally during method overriding?</th></tr>
<tr><td>

Method overriding is the act of replacing a function pointer in a derived class's vtable.

**Interview Ready Answer:**
- **Inheriting the Vtable:** When a derived class is created, the CLR initially copies the base class's vtable structure into the derived class's MethodTable.
- **Pointer Replacement:** If the derived class defines a method with the `override` keyword, the CLR updates the specific slot in the derived class's vtable. It replaces the memory address pointing to the base method's JIT-compiled code with the memory address pointing to the derived method's JIT-compiled code.
- **The Result:** Any `callvirt` instruction routed through this derived object's vtable will inevitably land on the derived method's memory address, regardless of what reference type the caller is using.

</td></tr>
</table>

<a id="q-1-33"></a>

<table>
<tr><th align="left">1.33 Can static methods participate in polymorphism? Why can’t they be virtual?</th></tr>
<tr><td>



No, static methods cannot participate in instance-based polymorphism and cannot be marked as `virtual` or `override`.

Polymorphism relies on examining an object's instance state (its `TypeHandle`) at runtime. Static methods belong to the type itself, not any instance. Therefore, the compiler uses early binding for static methods — it emits a `call` instruction pointing directly to a hardcoded memory address, bypassing the vtable entirely.

**The C# 11 Exception:** C# 11 introduced `static abstract` and `static virtual` members in interfaces. This allows you to define contracts for operators and static factories:
```csharp
public interface IParsable<T> { static abstract T Parse(string s); }
```
However, this is resolved via **generic type parameters** at compile time/JIT time, not through traditional object instance polymorphism. It enables generic math, but it doesn't change how `virtual` works on instances.

</td></tr>
</table>

<a id="q-1-34"></a>

<table>
<tr><th align="left">1.34 What are constructors in C#?</th></tr>
<tr><td>



A constructor is a special method invoked immediately after the CLR allocates memory for an object. Its sole architectural purpose is to establish the object's invariants and guarantee it starts its lifecycle in a valid, ready-to-use state.

In modern .NET development (especially with Dependency Injection), constructors have become the primary seam for **Constructor Injection**.
```csharp
public class OrderService
{
    private readonly IOrderRepository _repo;

    // The constructor defines the exact dependencies required for this object to exist
    public OrderService(IOrderRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));
}
```

**Key Behaviors:**
- If you don't define a constructor, the compiler generates a parameterless default constructor.
- The moment you define *any* constructor, the compiler removes the default one.
- Constructors do not allocate memory (the `new` keyword and the CLR's GC handle that). Constructors only initialize the allocated memory.

</td></tr>
</table>

<a id="q-1-35"></a>

<table>
<tr><th align="left">1.35 Difference between instance constructors and static constructors</th></tr>
<tr><td>



| Aspect | Instance Constructor | Static Constructor |
|---|---|---|
| **Purpose** | Initializes state for a specific object instance | Initializes static fields for the entire type |
| **Trigger** | Called explicitly via `new MyClass()` | Called automatically by the CLR exactly once per AppDomain |
| **Timing** | After memory allocation | Immediately before the first instance is created OR any static member is accessed |
| **Modifiers/Params** | Can be `public`/`private`, can be overloaded | Parameterless and inherently `private` (no access modifiers allowed) |

**Performance Insight:** Having a static constructor removes the `beforefieldinit` flag from the compiled IL. Without this flag, the JIT compiler must inject type-initialization checks before *every* access to a static field in your code to ensure the static constructor has run. If performance is critical, favor static field initializers (`static int x = 5;`) over explicit static constructors.

</td></tr>
</table>

<a id="q-1-36"></a>

<table>
<tr><th align="left">1.36 What are primary constructors?</th></tr>
<tr><td>



Introduced in C# 12 (for classes) and C# 9 (for records), primary constructors allow you to define parameters directly on the type declaration line. Their primary architectural benefit is dramatically reducing the boilerplate associated with Dependency Injection.

**Before:**
```csharp
public class UserService 
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _repo;

    public UserService(ILogger<UserService> logger, IUserRepository repo) 
    {
        _logger = logger;
        _repo = repo;
    }
}
```

**After (C# 12):**
```csharp
public class UserService(ILogger<UserService> logger, IUserRepository repo) 
{
    public void Execute() 
    {
        // Parameters are captured and accessible throughout the class body
        logger.LogInformation("Executing...");
        var user = repo.Get();
    }
}
```

**Under the hood:** The compiler captures these parameters and generates hidden, private backing fields for them behind the scenes *only if* they are used in the class body. Note that unlike records, primary constructor parameters on `class`es do not automatically become public properties.

</td></tr>
</table>

<a id="q-1-37"></a>

<table>
<tr><th align="left">1.37 What is constructor chaining?</th></tr>
<tr><td>



Constructor chaining is the practice of having one constructor call another to centralize initialization logic and avoid code duplication (the DRY principle). 

In C#, we use `this()` to chain within the same class, and `base()` to chain to the parent class.

```csharp
public class DbConnection : BaseConnection
{
    // 1. Consumer calls parameterless constructor. It chains to the parameterized one using 'this'
    public DbConnection() : this("Server=localhost;Integrated Security=true") 
    { }
    
    // 2. The "master" constructor receives the call. It immediately chains to the base class using 'base'
    public DbConnection(string connectionString) : base(connectionString) 
    { 
        // 3. Execution returns here after base constructor finishes.
        Timeout = 30;
    }
}
```

By designating a "master" constructor, if you ever need to add a new initialization rule (like setting up a default logger), you only add it in one place.

</td></tr>
</table>

<a id="q-1-38"></a>

<table>
<tr><th align="left">1.38 How do constructors work during inheritance, and what is the execution flow in an inheritance hierarchy?</th></tr>
<tr><td>



Constructors are not inherited. When you instantiate a derived class, the CLR guarantees that every class in the inheritance chain has a chance to initialize its own state. 

The most common mistake candidates make is getting the initialization order wrong. Here is the exact, guaranteed execution sequence when you run `new Child()`:

1. **Child Field Initializers** (e.g., `private int x = 5;` inside Child)
2. **Parent Field Initializers** (e.g., `private int y = 10;` inside Parent)
3. **Parent Constructor Body**
4. **Child Constructor Body**

**Why this order?**
The CLR initializes fields starting from the most derived type up to the base type to ensure memory is zeroed and ready. But the actual constructor *bodies* execute **Top-Down** (from `System.Object` down to `Child`). 

This ensures that the base class is fully constructed and stable before the derived class constructor runs, because the derived constructor might rely on base class state.

**The Implicit `base()`:** 
If you don't explicitly declare `: base()`, the compiler injects a call to the parent's parameterless constructor. If the parent lacks a parameterless constructor, the child class won't compile until you explicitly call a valid `base(...)` constructor.

**What Interviewers Are Actually Testing:**

They are looking for the exact order of execution. Knowing that **field initializers run before constructor bodies**, and that constructor bodies execute **base-first, derived-last**, is a classic senior-level filter question.

</td></tr>
</table>

**[⬆ Back to Top](#table-of-contents)**

<a id="section-2"></a>
## 2. Interface and Abstract Class

<a id="q-2-1"></a>

<table>
<tr><th align="left">2.1 What is an interface?</th></tr>
<tr><td>

An interface is a purely abstract contract that defines *what* a class can do, without dictating *how* it does it. In modern .NET architecture, interfaces are the fundamental building blocks of **Dependency Inversion** and **loose coupling**.

By programming against interfaces (`ILogger`, `IPaymentGateway`), the high-level policy of your application remains completely ignorant of the low-level implementation details (e.g., whether the logger writes to the console, a file, or Application Insights).

**Internal Runtime Behavior:**
When you call a method through an interface reference, the CLR uses **Interface Dispatch**. It looks up the object's `MethodTable`, finds the specific `InterfaceMap` for that interface, and resolves the correct method address. This is slightly slower than a standard virtual method call, but the cost is negligible compared to the architectural flexibility it provides.

**What Interviewers Are Actually Testing:**
They want to know if you see interfaces as just "a list of methods" or as architectural boundaries. Mentioning Dependency Injection (DI) and testability here is an immediate green flag.

</td></tr>
</table>

<a id="q-2-2"></a>

<table>
<tr><th align="left">2.2 What is an abstract class?</th></tr>
<tr><td>

An abstract class serves as a partially implemented blueprint. It defines the core identity (an "is-a" relationship) for a family of related classes and allows you to share state (fields) and common logic, while forcing derived classes to implement specific missing pieces via `abstract` methods.

Unlike interfaces, an abstract class represents a strict structural hierarchy. A `SqlRepository` *is a* `BaseRepository`. Because C# only supports single class inheritance, choosing to use an abstract class consumes the single inheritance slot of the derived type.

**Performance & Tradeoffs:**
Abstract classes perform slightly better than interfaces because method dispatch uses standard virtual method resolution (direct vtable lookup) rather than the slightly more complex interface dispatch map. However, the tradeoff is rigid tight coupling. If you change the base class, you risk breaking all derived classes (the Fragile Base Class problem).

**What Interviewers Are Actually Testing:**
They want to see if you understand that abstract classes share *implementation and state*, whereas interfaces only share *contracts*.

</td></tr>
</table>

<a id="q-2-3"></a>

<table>
<tr><th align="left">2.3 Difference between interface and abstract class?</th></tr>
<tr><td>

| Feature | Interface | Abstract Class |
|---|---|---|
| **Core Concept** | Defines a **capability/contract** (Can-Do). | Defines a **core identity** (Is-A). |
| **State/Fields** | Cannot contain instance fields or state. | Can contain fields, state, and constants. |
| **Constructors** | Cannot have constructors. | Can have constructors (executed during derived instantiation). |
| **Multiple Inheritance** | A class can implement **multiple** interfaces. | A class can inherit from only **one** base/abstract class. |
| **Access Modifiers** | Members are implicitly `public`. | Can use any access modifier (`protected`, `private`, etc.). |
| **Evolution** | Historically pure abstract (though C# 8+ allows Default Interface Methods for versioning). | Always allowed a mix of abstract and concrete methods. |

**What Interviewers Are Actually Testing:**
This is a filtering question. Junior developers memorize the table above. Senior developers explain *why* it matters — specifically, that interfaces enable Dependency Injection and mocking by creating completely decoupled seams, while abstract classes provide code reuse within a strictly coupled hierarchy.

</td></tr>
</table>

<a id="q-2-4"></a>

<table>
<tr><th align="left">2.4 When would you use interface vs abstract class?</th></tr>
<tr><td>

In enterprise applications, **default to interfaces** (e.g., `IUserRepository`) for almost everything that spans across application layers. They are the backbone of Dependency Injection and make unit testing via mocking frameworks (like Moq or NSubstitute) trivial.

**Use an Abstract Class only when:**
1. You have a family of tightly related objects that absolutely must share internal state (fields).
2. You are implementing the **Template Method Pattern**, where the base class orchestrates a complex algorithm but leaves specific steps abstract for the child to implement.

**Tradeoffs/Pitfalls:**
If you start your design with an abstract base class just to share a few helper methods, you are falling into the "inheritance for code reuse" trap. This leads to rigid, brittle hierarchies. Code reuse should usually be achieved via Composition (injecting a helper class), saving your single inheritance slot for true "is-a" relationships.

</td></tr>
</table>

<a id="q-2-5"></a>

<table>
<tr><th align="left">2.5 When should you use an abstract class?</th></tr>
<tr><td>

The primary production use case for an abstract class is the **Template Method Pattern**. 

Imagine a backend service processing payments. The overall workflow (validating the request, logging the attempt, saving to the database) is identical for all payments, but the actual gateway communication differs between Stripe and PayPal.

```csharp
public abstract class PaymentProcessor
{
    // The skeleton is locked down (early binding, predictable)
    public void ProcessPayment(PaymentRequest request) 
    {
        Validate(request);
        var result = CallGateway(request); // Abstract step (late binding)
        SaveToDatabase(result);
    }
    
    private void Validate(PaymentRequest req) { /* Shared logic */ }
    
    // Forced implementation by child classes
    protected abstract PaymentResult CallGateway(PaymentRequest req);
    
    private void SaveToDatabase(PaymentResult res) { /* Shared logic */ }
}
```

**What Interviewers Are Actually Testing:**
They want to see if you can provide a concrete, real-world architectural pattern rather than just saying "to share code." Bringing up the Template Method Pattern demonstrates mature design thinking.

</td></tr>
</table>

<a id="q-2-6"></a>

<table>
<tr><th align="left">2.6 Why use interfaces instead of concrete classes?</th></tr>
<tr><td>

While the textbook answer is "loose coupling," the pragmatic production answer is **Testability**.

Concrete classes that perform I/O (database queries, HTTP calls, file system access) cannot be easily isolated. If your `OrderService` directly instantiates `new SqlCustomerRepository()`, you cannot write a fast, reliable unit test for `OrderService` without spinning up a real SQL database.

By depending on `ICustomerRepository` instead, you create a "seam" in your architecture. During unit testing, you can inject a mock implementation (using libraries like Moq or NSubstitute) that returns predictable data instantly, perfectly isolating the business logic under test.

</td></tr>
</table>

<a id="q-2-7"></a>

<table>
<tr><th align="left">2.7 How do interfaces reduce coupling?</th></tr>
<tr><td>

Coupling is a measure of how much one module knows about the internal workings of another. Interfaces reduce coupling by strictly limiting that knowledge to a predefined contract.

If a consumer relies on an interface, it is completely blind to:
- What database is being used.
- What external nuget packages the implementation requires.
- Whether the implementation is a local singleton or a distributed gRPC client.

**Architectural Benefit:**
This blindness minimizes the **blast radius** of changes. You can completely rip out a `SendGridEmailProvider` and replace it with an `AwsSesEmailProvider` without modifying or even recompiling the business logic that calls `IEmailProvider.SendAsync()`. This enables true plug-in architectures.

</td></tr>
</table>

<a id="q-2-8"></a>

<table>
<tr><th align="left">2.8 Why depend on abstractions instead of implementations?</th></tr>
<tr><td>

This is the definition of the **Dependency Inversion Principle (DIP)** (the 'D' in SOLID).

In traditional, naive architectures, high-level policy (e.g., calculating taxes) depends directly on low-level details (e.g., saving to SQL). This is a structural flaw because high-level rules are naturally stable, while low-level I/O details are highly volatile.

By introducing an abstraction (an interface) between them, you invert the dependency. 
- The high-level module defines the interface it needs (`ITaxRepository`).
- The low-level module implements that interface.

Now, both the high-level policy and the low-level details depend on the abstraction. The stable business logic is protected from the volatility of infrastructure changes.

</td></tr>
</table>

<a id="q-2-9"></a>

<table>
<tr><th align="left">2.9 Can interfaces have implementation?</th></tr>
<tr><td>

Historically, no. But starting with **C# 8.0**, yes, through **Default Interface Methods (DIM)**.

```csharp
public interface ILogger
{
    void Log(string message);
    
    // Default Interface Method (C# 8+)
    void LogError(string message) => Log($"[ERROR] {message}"); 
}
```

**Why was this added?**
It was introduced specifically to solve the **API Versioning Problem**. Before C# 8, interfaces were immutable contracts; adding a new method to a widely published interface (like inside the .NET BCL) was a breaking change that shattered all downstream implementations. Default implementations allow framework authors to safely evolve interfaces without breaking backwards compatibility.

**Important Nuance:** 
A class implementing `ILogger` does *not* automatically inherit the `LogError` method on its public API. The method only exists when the object is explicitly cast to the `ILogger` interface type.

</td></tr>
</table>

<a id="q-2-10"></a>

<table>
<tr><th align="left">2.10 Can interfaces contain fields or state?</th></tr>
<tr><td>

No, interfaces cannot contain instance fields or instance state.

An interface dictates *what* an object can do, not the memory it requires to do it. Managing state is strictly the responsibility of the implementing concrete class.

While you can define properties in an interface (`string ConnectionString { get; set; }`), these are not fields. They are simply declarations for `get_ConnectionString()` and `set_ConnectionString()` methods that the implementing class must wire up to its own backing fields.

*(Note: C# 8+ Default Interface Methods do allow interfaces to contain `static` fields, but instance state remains strictly prohibited).*

</td></tr>
</table>

<a id="q-2-11"></a>

<table>
<tr><th align="left">2.11 Can interfaces inherit interfaces?</th></tr>
<tr><td>

Yes, interfaces can inherit from one or multiple other interfaces.

This is a powerful technique for adhering to the **Interface Segregation Principle (ISP)**. Instead of creating one massive "god interface" that forces clients to implement methods they don't need, you define granular, focused interfaces and compose them.

```csharp
public interface IReader { void Read(); }
public interface IWriter { void Write(); }

// Composing smaller interfaces into a larger capability
public interface IStorageRepository : IReader, IWriter 
{ 
    void Initialize(); 
}
```

**What Interviewers Are Actually Testing:**
They want to see if you understand interface composition. A senior engineer builds small, highly cohesive interfaces (ISP) and groups them together, rather than building massive `IService` interfaces that violate single responsibility.

</td></tr>
</table>

<a id="q-2-12"></a>

<table>
<tr><th align="left">2.12 What happens if two interfaces have the same method signature?</th></tr>
<tr><td>

By default, if a class implements two interfaces containing the exact same method signature, providing a single `public` implementation in the class will implicitly satisfy both interfaces.

However, if those two methods are supposed to do completely different things depending on which interface contract the caller is expecting, you have a collision. You solve this using **Explicit Interface Implementation**.

```csharp
public class FileProcessor : IReader, ILogger
{
    // Resolving the collision:
    void IReader.Process() { /* Read a file */ }
    void ILogger.Process() { /* Log a message */ }
}
```

</td></tr>
</table>

<a id="q-2-13"></a>

<table>
<tr><th align="left">2.13 What is explicit interface implementation?</th></tr>
<tr><td>

Explicit interface implementation allows a class to fulfill an interface contract *without* exposing those methods on the class's default public API. You do this by omitting the access modifier and prefixing the method name with the interface name.

**Primary Use Cases:**
1. **Resolving Method Collisions:** When two interfaces share the same method signature but require different behavior (as seen in the previous question).
2. **API Surface Hiding:** Framework authors use this to hide methods that would otherwise clutter IntelliSense for consumers. 
   - *Example:* The standard `List<T>` explicitly implements many methods from `ICollection<T>` and `IList<T>`. If you declare `var list = new List<int>();`, you don't see `list.IsReadOnly`. You only see it if you cast it: `((ICollection<int>)list).IsReadOnly`.

</td></tr>
</table>

<a id="q-2-14"></a>

<table>
<tr><th align="left">2.14 Can abstract methods exist in non-abstract classes?</th></tr>
<tr><td>

No, abstract methods cannot exist in a non-abstract class. 

If a class contains even one abstract method, the C# compiler forces you to mark the entire class as `abstract`.

**Internal Runtime Behavior:**
An abstract method has no implementation body. If the CLR allowed a concrete class to contain an abstract method, you could instantiate it and invoke that method. The CPU instruction pointer would attempt to jump to a memory address that doesn't contain executable code, causing a fatal runtime exception. By forcing the class to be `abstract`, the compiler physically prevents instantiation, ensuring type safety.

</td></tr>
</table>

<a id="q-2-15"></a>

<table>
<tr><th align="left">2.15 Can abstract classes have constructors?</th></tr>
<tr><td>

Yes, they can and frequently do. 

Even though you cannot instantiate an abstract class directly (`new MyAbstractClass()`), the constructor is critical for initializing the shared state (fields or properties) defined within the base class.

**Architectural Reasoning:**
Abstract class constructors should almost always be marked as `protected`, not `public`. A `public` constructor on a class that cannot be instantiated makes no logical sense. The constructor is called implicitly (or explicitly via `base(...)`) from the derived class's constructor during the instantiation pipeline.

**Example:**
If `BaseRepository` requires a database connection string, its constructor demands it. `SqlUserRepository` must call `base(connectionString)` to ensure the parent is valid before the child finishes initializing.

</td></tr>
</table>

<a id="q-2-16"></a>

<table>
<tr><th align="left">2.16 Can abstract classes contain fields or state?</th></tr>
<tr><td>

Yes, they can. This is actually the primary structural difference between an abstract class and an interface.

**Architectural Benefit:**
Interfaces only define behavior. Abstract classes define behavior *and* manage state. This allows you to encapsulate shared variables (like a cached connection pool, a logger instance, or an internal counter) inside the abstract class. 

By marking these fields as `private` and exposing them only via `protected` methods to the derived classes, you guarantee that the state invariants are protected across the entire inheritance hierarchy.

</td></tr>
</table>

<a id="q-2-17"></a>

<table>
<tr><th align="left">2.17 Can abstract classes implement interfaces?</th></tr>
<tr><td>

Yes, an abstract class can implement interfaces. This is a very common enterprise pattern used to provide a default skeletal implementation of a contract.

There are two ways an abstract class can handle the interface methods:
1. **Concrete Implementation:** The abstract class provides the actual body for the interface method. Derived classes simply inherit it and don't have to worry about it.
2. **Abstract Re-mapping:** The abstract class can map the interface method to an `abstract` method. This forces the derived classes to provide the implementation, but keeps the class tied to the interface contract.

**Example:**
```csharp
public interface ICache { void Set(); void Invalidate(); }

public abstract class BaseCache : ICache
{
    // 1. Concrete implementation (shared by all derived classes)
    public void Set() { /* core logic */ }
    
    // 2. Abstract re-mapping (forces child to figure out how to invalidate)
    public abstract void Invalidate(); 
}
```

</td></tr>
</table>

<a id="q-2-18"></a>

<table>
<tr><th align="left">2.18 Difference between abstract method and virtual method?</th></tr>
<tr><td>

Both enable polymorphism via late binding and vtable dispatch, but their architectural intent is entirely different.

| Feature | Abstract Method | Virtual Method |
|---|---|---|
| **Implementation** | Has **no body**. Cannot contain code. | Has a **default body**. Must contain executable code. |
| **Override Requirement**| Derived class **MUST** override it. | Derived class **MAY** override it, but it's optional. |
| **Location** | Only allowed inside an `abstract` class. | Allowed in both concrete and abstract classes. |

**Architectural Reasoning:**
Use an `abstract` method when the base class simply cannot provide a sensible default behavior (e.g., `Shape.CalculateArea()`). Use a `virtual` method when the base class *can* provide a perfectly fine default behavior, but you want to leave an "override hook" open for specialized children (e.g., `FileHandler.CloseStream()`).

</td></tr>
</table>

<a id="q-2-19"></a>

<table>
<tr><th align="left">2.19 Why does C# support multiple inheritance only through interfaces?</th></tr>
<tr><td>

C# enforces single-class inheritance to completely avoid the **Diamond Problem** — an architectural ambiguity common in C++.

**The Diamond Problem Explained:**
If a class `D` inherited from both `Class B` and `Class C`, and both `B` and `C` inherited a virtual method `DoWork()` from `Class A` and overrode it, what happens when `D` calls `base.DoWork()`? The compiler wouldn't know whether to execute `B`'s version or `C`'s version. 

**Why Interfaces Solve This:**
Because interfaces (traditionally) only define contracts and hold no implementation or state, there is no ambiguity. If `Class D` implements `IB` and `IC`, and both require a `DoWork()` method, `Class D` just provides a single implementation that satisfies both contracts simultaneously. 

*(Note: C# 8 introduced Default Interface Methods. If `IB` and `IC` provide conflicting default implementations, the compiler throws an error, forcing `D` to explicitly implement the method to resolve the ambiguity).*

</td></tr>
</table>

<a id="q-2-21"></a>

<table>
<tr><th align="left">2.21 Why not use interfaces everywhere?</th></tr>
<tr><td>

If decoupling is so great, why don't we create an interface for every single class? This is an anti-pattern known as **Header Interfaces**.

**Tradeoffs/Pitfalls:**
1. **Clutter:** Creating an `IUserService` exclusively for a single `UserService` with no intent to ever swap implementations or mock it (e.g., in a simple internal domain service) just doubles the file count and increases navigation friction.
2. **Maintenance:** Every time you add a method, you have to update two files.
3. **No Logic Sharing:** Interfaces cannot share implementation code. If 10 classes implement `IRepository` and 9 of them use the exact same EF Core setup logic, you will have massive code duplication.

Use interfaces at architectural boundaries (API to Business Logic, Business Logic to Database), not blindly on every internal helper class.

</td></tr>
</table>

<a id="q-2-22"></a>

<table>
<tr><th align="left">2.22 Why not use abstract classes everywhere?</th></tr>
<tr><td>

Overusing abstract classes leads to the **Fragile Base Class Problem** and rigid taxonomies.

**Tradeoffs/Pitfalls:**
1. **The Single Inheritance Bottleneck:** A class can only inherit from one base class. If you burn that single slot on a utility abstract class, you block the class from inheriting true domain behavior later.
2. **Tight Coupling:** Inheritance is the tightest form of coupling in OOP. A small change in the base abstract class automatically ripples down to all derived classes, potentially breaking them in unpredictable ways.
3. **Mocking Friction:** It is very difficult to inject a mock of an abstract class into a service for unit testing without inadvertently invoking the base class's actual state/constructors.

Modern architecture favors **Composition over Inheritance**. Inject behaviors via interfaces rather than inheriting them from abstract classes.

</td></tr>
</table>

**[⬆ Back to Top](#table-of-contents)**

<a id="section-3"></a>
## 3. SOLID Principles and Architecture
</table>

<a id="q-3-1"></a>

<table>
<tr><th align="left">3.1 Explain SOLID principles.</th></tr>
<tr><td>

SOLID is a suite of five architectural principles designed to mitigate the rot of aging codebases—specifically rigidity, fragility, and immobility. 

In production .NET systems, these aren't just academic rules; they are the exact guidelines used to build microservices, establish Dependency Injection boundaries, and ensure that adding a new feature doesn't break a completely unrelated part of the system.

- **S - Single Responsibility Principle (SRP):** A class should have only one reason to change (controls the blast radius of modifications).
- **O - Open/Closed Principle (OCP):** A class should be open for extension but closed for modification (enables plugin architectures).
- **L - Liskov Substitution Principle (LSP):** Derived classes must be perfectly substitutable for their base classes (guarantees polymorphic safety at runtime).
- **I - Interface Segregation Principle (ISP):** Clients should not be forced to depend on methods they don't use (prevents fat "god" interfaces).
- **D - Dependency Inversion Principle (DIP):** High-level modules should depend on abstractions, not concrete implementations (the backbone of Dependency Injection).

**What Interviewers Are Actually Testing:**
They use this as a baseline filter. A junior recites the acronym. A senior explains that SOLID is ultimately about **dependency management** and **controlling the blast radius** of changes.

</td></tr>
</table>

<a id="q-3-2"></a>

<table>
<tr><th align="left">3.2 What do you mean by coupling and cohesion?</th></tr>
<tr><td>

These are the two primary metrics I use to evaluate the health of an architecture. The universal goal is **High Cohesion and Low Coupling**.

**Cohesion (Internal Focus):**
Cohesion measures how closely the methods and state inside a single module relate to one another. 
- *High Cohesion (Good):* A `JwtTokenGenerator` where every field and method is dedicated exclusively to cryptography and token signing.
- *Low Cohesion (Bad):* A `UtilityHelper` class that formats dates, connects to the database, and sends SMS messages. 

**Coupling (External Focus):**
Coupling measures the degree of interdependence between *different* modules.
- *Low Coupling (Good):* A service communicates with a database purely through an `IRepository` interface. You can replace the entire database provider without the service knowing.
- *Tight Coupling (Bad):* A business layer method directly instantiates `new SqlTransaction()` inside a `using` block. The business logic is now permanently fused to the SQL Server SDK.

</td></tr>
</table>

<a id="q-3-3"></a>

<table>
<tr><th align="left">3.3 Explain Single Responsibility Principle.</th></tr>
<tr><td>

SRP states that a class should have only one reason to change. In enterprise architecture, this translates directly to **Blast Radius Management**.

If a `UserService` contains logic to validate a user's age, generate an auth token, and format a welcome email, it has three reasons to change. If the marketing team requests a change to the email formatting, a developer has to open the `UserService` file. If they accidentally introduce a syntax error, the authentication system breaks. That is a massive blast radius.

**The Fix:**
You split the behaviors into highly cohesive, single-purpose classes: `UserValidator`, `TokenGenerator`, and `WelcomeEmailBuilder`. The `UserService` now becomes a simple orchestrator that coordinates these injected dependencies. 

**Performance & Tradeoffs:**
Strict adherence to SRP leads to a high number of small classes. This slightly increases the pressure on the DI container and the GC (more object allocations per request), but the massive gains in testability and merge-conflict reduction make it absolutely worth it in a microservice or enterprise web app.

</td></tr>
</table>

<a id="q-3-4"></a>

<table>
<tr><th align="left">3.4 Explain Open Closed Principle.</th></tr>
<tr><td>

OCP states that a system should be **open for extension** (you can add new behavior) but **closed for modification** (you shouldn't have to edit existing, tested code to do so).

**The Production Scenario:**
Imagine an `OrderCalculator` with a large `switch` statement checking `CustomerType` (Standard, Premium, VIP) to apply discounts. When the business adds a new "Platinum" tier, you have to open the core calculator and modify the switch statement. You risk breaking the existing tiers.

**The Architectural Fix (Plugin Architecture):**
You introduce polymorphism. You define an `IDiscountStrategy` interface. You implement `StandardDiscount`, `PremiumDiscount`, etc. When "Platinum" is required, you simply write a *brand new class* `PlatinumDiscount` that implements the interface, and register it in the DI container. 

You added a major feature without touching a single line of existing business logic. You literally cannot introduce a regression into the existing code if you didn't edit it.

</td></tr>
</table>

<a id="q-3-5"></a>

<table>
<tr><th align="left">3.5 Explain Liskov Substitution Principle.</th></tr>
<tr><td>

LSP states that any derived class must be perfectly substitutable for its base class without altering the correctness of the program. It is the rule that guarantees **runtime polymorphic safety**.

**The Production Scenario:**
If a method expects an `IEnumerable<Task>`, and you pass it a `List<Task>`, the method assumes it can safely iterate over it. If your custom list implementation throws a `NotImplementedException` when `GetEnumerator()` is called, the application crashes at runtime. You violated LSP.

**The "Is-A" Fallacy:**
In the real world, a Square is a Rectangle. But if you model `class Square : Rectangle` and override the `Width` setter to also change the `Height` (to keep it a square), you violate LSP. A client consuming a `Rectangle` expects that changing the Width leaves the Height alone. When it behaves differently, the client logic breaks.

**What Interviewers Are Actually Testing:**
They want to see if you understand that inheritance is not just about sharing fields; it is about honoring behavioral contracts. If a child class throws an unexpected exception for an inherited method, it fails LSP.

</td></tr>
</table>

<a id="q-3-6"></a>

<table>
<tr><th align="left">3.6 Explain Interface Segregation Principle.</th></tr>
<tr><td>

ISP states that no client should be forced to depend on methods it does not use. Large, "fat" interfaces should be split into smaller, hyper-focused ones.

**The Production Scenario:**
You have a massive `IRepository<T>` interface containing `Get()`, `Add()`, `Delete()`, and `BulkUpsert()`. You inject this into a `NotificationService` that only needs to read user preferences. 

By passing the fat interface, you've granted the `NotificationService` the ability to delete users. You've violated the Principle of Least Privilege. Furthermore, if you modify the signature of `BulkUpsert()`, the `NotificationService` is forced to recompile, even though it doesn't use that method.

**The Architectural Fix:**
Segregate the interface. Break it into `IReadRepository<T>` and `IWriteRepository<T>`. A concrete class like `SqlUserRepository` can implement both, but the `NotificationService` only asks the DI container for `IReadRepository<T>`.

</td></tr>
</table>

<a id="q-3-7"></a>

<table>
<tr><th align="left">3.7 Explain Dependency Inversion Principle.</th></tr>
<tr><td>

DIP states that high-level modules (the core business rules) should not depend on low-level modules (database calls, file systems, HTTP clients). Both should depend on abstractions.

**The Production Scenario:**
If `InvoiceGenerator` (high-level) directly instantiates `new StripePaymentGateway()` (low-level), the invoice logic is permanently shackled to Stripe. If Stripe's API changes, the invoice logic breaks. 

**The Architectural Fix:**
You define an `IPaymentGateway` interface in the high-level project. `InvoiceGenerator` depends only on that interface. The low-level infrastructure project implements `StripePaymentGateway : IPaymentGateway`. 

The dependency arrow has been inverted: the infrastructure now depends on the business layer's abstractions, not the other way around. 

**Internal Runtime Behavior:**
This is the principle that makes **Inversion of Control (IoC) containers** (like the built-in `IServiceCollection` in .NET) possible. The DI container resolves the concrete type at runtime and injects it into the constructor, ensuring the classes remain blissfully ignorant of their concrete dependencies.

</td></tr>
</table>

<a id="q-3-8"></a>

<table>
<tr><th align="left">3.8 What is the difference between SRP and ISP?</th></tr>
<tr><td>

While both principles deal with keeping things small and focused, they apply to entirely different sides of the dependency boundary.

| Feature | Single Responsibility Principle (SRP) | Interface Segregation Principle (ISP) |
|---|---|---|
| **Boundary** | Applies to the **Implementation** (the concrete class). | Applies to the **Abstraction** (the interface contract). |
| **Focus** | Internal cohesion and logic separation. | External consumption and API surface reduction. |
| **Violation Symptom** | A massive class with thousands of lines, constant merge conflicts, and bugs that ripple across features. | A class implementing an interface but throwing `NotImplementedException` for half of the required methods. |

**Architectural Reasoning:**
You can have a system that perfectly follows SRP (every class does one tiny thing) but violates ISP (they all implement a single, massive `IUniversalHelper` interface). Conversely, you can have perfect ISP (tiny, focused interfaces) but violate SRP (one massive "God Class" implements all 50 of them).

</td></tr>
</table>

<a id="q-3-9"></a>

<table>
<tr><th align="left">3.9 Which SOLID principle is behavioral?</th></tr>
<tr><td>

The **Liskov Substitution Principle (LSP)** is strictly a behavioral principle.

**Architectural Reasoning:**
The other four principles (SRP, OCP, ISP, DIP) are purely structural—they dictate how you organize files, define interfaces, and wire up dependencies in your DI container. 

LSP is the only principle that dictates how objects must *behave* at runtime. It enforces the "Contract of Expectations." If a base class method guarantees it will never return `null`, the overridden method in the child class is structurally allowed to return `null` by the compiler, but doing so violates the behavioral contract (LSP) and will cause runtime crashes for the consumer.

</td></tr>
</table>

<a id="q-3-10"></a>

<table>
<tr><th align="left">3.10 What are the practical benefits of implementing DIP?</th></tr>
<tr><td>

DIP is the foundation of modern decoupled architecture. Its practical benefits in production include:

1. **Testability:** You cannot unit test business logic if it directly news up a `SqlConnection`. DIP allows you to effortlessly inject mocked abstractions (e.g., via Moq) to test the logic in complete isolation and in milliseconds.
2. **Provider Swappability:** You can migrate an entire application from Azure Table Storage to PostgreSQL without touching a single line of business logic. You just write a new concrete repository and swap the binding in the DI container.
3. **Parallel Team Development:** Frontend and Backend (or two microservice teams) can agree on an interface contract on day one. Team A can develop against a mock implementation of the interface, while Team B builds the real concrete implementation. Neither team is blocked.

</td></tr>
</table>

<a id="q-3-11"></a>

<table>
<tr><th align="left">3.11 Why prefer composition over inheritance?</th></tr>
<tr><td>

"Favor Composition over Inheritance" is perhaps the most important architectural guideline in OOP, designed to prevent the **Fragile Base Class Problem**.

**The Problem with Inheritance (Is-A):**
Inheritance is the tightest form of coupling available in C#. A child class is permanently bound to its parent. If you change a method in the base `BaseController`, you risk breaking 50 derived controllers. Furthermore, because C# only supports single inheritance, burning that slot on a generic utility base class prevents the class from inheriting true domain behavior later.

**The Power of Composition (Has-A):**
Instead of a `Car` inheriting from `Engine`, a `Car` *has an* `IEngine` injected into its constructor. 
- **Flexibility:** You can swap out the behavior at runtime (e.g., injecting an `ElectricEngine` instead of a `GasEngine`). Inheritance locks the behavior at compile time.
- **Testing:** You can easily inject a mock engine to test the car. You cannot mock a base class's internals easily.

</td></tr>
</table>

<a id="q-3-12"></a>

<table>
<tr><th align="left">3.12 How do interfaces improve maintainability?</th></tr>
<tr><td>

Maintainability is about how easily a codebase can be understood, modified, and fixed without introducing regressions.

1. **Isolation of Changes (No Ripple Effect):** When you code against an interface, changes to the underlying concrete class's private methods or constructor dependencies do not force the consumer to change or recompile. 
2. **Self-Documenting Code:** Concrete classes are often cluttered with dependency injection boilerplate, logging, and complex algorithms. An interface acts as a clean, concise summary of exactly *what* a component can do, stripped of all internal noise. This makes onboarding new engineers significantly faster.

</td></tr>
</table>

<a id="q-3-13"></a>

<table>
<tr><th align="left">3.13 How do abstractions improve scalability?</th></tr>
<tr><td>

Abstractions are the key to scaling both software architecture and development teams.

**Scaling the Architecture (Plugin Model):**
Abstractions allow you to scale the *features* of an application without scaling the *complexity* of existing code (OCP). If you need to add five new ways to calculate shipping, you don't add 500 lines to a `switch` statement in `ShippingCalculator`. You add five new classes that implement `IShippingStrategy`.

**Scaling Infrastructure:**
If a monolithic service directly writes to memory, it cannot be horizontally scaled across servers. By relying on an abstraction (e.g., `IMessageQueue`), you can easily swap the in-memory queue implementation for an Azure Service Bus implementation when traffic demands it, enabling horizontal scaling without rewriting the domain logic.

</td></tr>
</table>

<a id="q-3-14"></a>

<table>
<tr><th align="left">3.14 What is layered architecture, and how do you make it decoupled?</th></tr>
<tr><td>

Traditional Layered (N-Tier) architecture separates an application into Presentation (UI/API), Business Logic (Domain), and Data Access (Infrastructure). 

However, in **Traditional N-Tier**, the Business Logic layer references the Data Access layer. This violates the Dependency Inversion Principle, tying your core domain to a specific database technology (like EF Core or SQL Server).

**Decoupled Layering (Clean / Onion Architecture):**
To decouple it, you invert the dependency. You define `IRepository` interfaces entirely inside the Business Logic layer. The Data Access layer references the Business Logic layer to implement those interfaces. 
Now, the dependency arrow points *inward*. The Business layer is completely ignorant of the database, making it inherently testable and portable.

</td></tr>
</table>

<a id="q-3-15"></a>

<table>
<tr><th align="left">3.15 What is the responsibility of each layer in a layered architecture?</th></tr>
<tr><td>

In a modern Clean Architecture approach:

**Presentation Layer (API / Controllers):**
Strictly responsible for HTTP concerns. It parses incoming JSON, validates structural integrity (DTOs), routes to the correct Application use-case, and formats the HTTP response (200 OK, 404 Not Found). It contains **zero** business rules.

**Application / Domain Layer (Core):**
The heart of the system. Contains the pure business logic, Domain Entities, and the Interfaces defining what infrastructure is required (`IUserRepository`). It has **zero dependencies** on external SDKs or databases.

**Infrastructure / Data Layer:**
The plumbing. This is where Entity Framework `DbContexts`, AWS SDK clients, and SendGrid email formatters live. It implements the interfaces defined by the Domain layer to interact with the outside world.

</td></tr>
</table>

<a id="q-3-16"></a>

<table>
<tr><th align="left">3.16 What is cyclic dependency, and how do you break it?</th></tr>
<tr><td>

A cyclic dependency occurs when Project A depends on Project B, and Project B depends back on Project A. The compiler will block this because it cannot determine which project to build first.

**Architectural Flaw:**
Cycles almost always indicate a violation of the Single Responsibility Principle or poorly defined domain boundaries. If two projects intimately need each other's internals, they either belong in the same project, or a shared concept is trapped inside one of them.

**How to Break It:**
1. **Refactoring (Shared Kernel):** Extract the common classes (usually Models, DTOs, or Enums) that both projects need into a new "Shared" Project C. Both A and B now reference C.
2. **Dependency Inversion:** Introduce an interface in Project A. Have Project B implement that interface. Now A depends only on its own interface, and B depends on A to fulfill the contract.

</td></tr>
</table>

<a id="q-3-17"></a>

<table>
<tr><th align="left">3.17 How would you isolate provider-specific behavior?</th></tr>
<tr><td>

You must prevent 3rd-party SDKs (like AWS S3, Stripe, or Twilio) from bleeding into your core domain logic using the **Adapter / Facade Pattern**.

**The Anti-Pattern:**
Injecting `AmazonS3Client` directly into your `UserService` to save profile pictures. If AWS changes their SDK, or you migrate to Azure Blob Storage, your `UserService` breaks.

**The Architectural Fix:**
Define a domain interface based on *what the business needs to achieve*, not how the provider works: `IImageStorageService.SaveProfilePictureAsync()`. 
Then, create an `AwsImageStorageAdapter` class in the Infrastructure layer that implements this interface and wraps the AWS SDK. The business logic remains pure and provider-agnostic.

</td></tr>
</table>

<a id="q-3-18"></a>

<table>
<tr><th align="left">3.18 Give real-world examples of SOLID.</th></tr>
<tr><td>

*(Rapid-fire summary of enterprise applications):*

- **SRP:** Splitting a massive `OrderProcessor` class into `OrderValidator`, `OrderRepository`, and `EmailSender`.
- **OCP:** Using an `IEnumerable<IDiscountStrategy>` to calculate shopping cart discounts. To add a "Black Friday" discount, you write a new class rather than modifying a massive `switch` statement in the calculator.
- **LSP:** Ensuring a custom `ReadOnlyFileStream` doesn't throw a `NotImplementedException` when a consumer calls `Write()`. If it can't write, it shouldn't inherit a `Write()` contract.
- **ISP:** Breaking down a massive `IUserInterface` into `IUserReader`, `IUserWriter`, and `IUserAuthenticator` so the notification service doesn't have access to delete users.
- **DIP:** An ASP.NET Controller accepting `IUserService` via its constructor (Dependency Injection) instead of running `new UserService()`.

</td></tr>
</table>

<a id="q-3-19"></a>

<table>
<tr><th align="left">3.19 How did you apply SOLID in your project?</th></tr>
<tr><td>

*(Note: This is subjective. Here is a strong, senior-level narrative template.)*

"In my last major microservice build, SOLID was the backbone of our architecture. We had a monolithic payment processor that was violating **SRP** and **OCP**—every time we added a new payment gateway or validation rule, we had merge conflicts in this massive 3,000-line class. 

I led the refactor to apply **Dependency Inversion**. I extracted the core rules into a domain layer and created an `IPaymentGateway` interface. We then moved the Stripe and PayPal implementations into separate infrastructure adapters. Because we relied on **OCP**, when the business later requested Apple Pay integration, we just wrote a new class implementing the interface and registered it in the DI container. The core engine wasn't touched, which completely eliminated regression bugs during that release."

</td></tr>
</table>

**[⬆ Back to Top](#table-of-contents)**

<a id="section-4"></a>
## 4. Design Patterns

> Important for enterprise-style interviews.

<a id="q-4-1"></a>

<table>
<tr><th align="left">4.1 What are design patterns?</th></tr>
<tr><td>

Design Patterns are universally recognized architectural blueprints used to solve recurring problems in software engineering.

They are not libraries you can install or specific pieces of code you can copy-paste. They are conceptual templates that provide a shared vocabulary for engineers. If a senior engineer says, "Let's use a Strategy pattern here," the entire team instantly understands the structural intent.

**Categorization (The Gang of Four):**
- **Creational:** Abstracts the instantiation process (e.g., Singleton, Factory, Builder).
- **Structural:** Deals with how objects and classes are composed to form larger structures (e.g., Adapter, Decorator, Facade).
- **Behavioral:** Focuses on communication and the assignment of responsibilities between objects (e.g., Strategy, Observer, Command).

</td></tr>
</table>

<a id="q-4-2"></a>

<table>
<tr><th align="left">4.2 Difference between design pattern and architecture pattern?</th></tr>
<tr><td>

The difference lies entirely in **Scale and Abstraction**.

| Feature | Design Pattern | Architecture Pattern |
|---|---|---|
| **Scope** | **Micro-level.** Solves localized, specific class/object design problems. | **Macro-level.** Defines the structural layout and boundary definitions of the entire system. |
| **Examples** | Singleton, Strategy, Factory, Repository. | Microservices, Event-Driven, Clean Architecture, CQRS. |
| **Impact** | Affects a single module or feature. Refactoring a pattern is usually isolated. | Affects the entire system and dictates how major services communicate. Refactoring architecture is a massive undertaking. |

</td></tr>
</table>

<a id="q-4-3"></a>

<table>
<tr><th align="left">4.3 Which design patterns are commonly used in .NET applications?</th></tr>
<tr><td>

Modern .NET development heavily leans on a few core patterns that are baked directly into the framework.

- **Dependency Injection (DI):** The absolute foundation of modern .NET. The `Microsoft.Extensions.DependencyInjection` container manages the entire lifecycle of your application's objects.
- **Options Pattern:** A uniquely .NET pattern used to bind strongly-typed classes to configuration settings (like `appsettings.json`) via `IOptions<T>`, adhering strictly to ISP.
- **Repository & Unit of Work:** Extensively used with Entity Framework Core to abstract data access and manage transactional boundaries.
- **Builder Pattern:** Used extensively in application bootstrapping (e.g., `WebApplication.CreateBuilder(args)`).
- **Chain of Responsibility (Middleware):** The ASP.NET Core HTTP request pipeline is a textbook implementation of this pattern, where each middleware component either handles the request or passes it to the next link in the chain.

</td></tr>
</table>

<a id="q-4-4"></a>

<table>
<tr><th align="left">4.4 What design patterns have you used in your projects?</th></tr>
<tr><td>

*(Note: Tailor this to your experience. Here is a senior-level architectural narrative.)*

"Beyond the mandatory **Dependency Injection** pattern, I frequently use the **Strategy Pattern** to eliminate complex branching logic. For example, in a recent e-commerce project, instead of a massive `switch` statement for shipping calculations, I created an `IShippingStrategy` interface with `FedExStrategy` and `UpsStrategy` implementations, allowing us to add new couriers without modifying the core checkout logic.

I also heavily utilize the **Decorator Pattern**. We had an existing, heavily-tested third-party API client. Instead of modifying its internal code to add Redis caching and Serilog logging, I created a decorator class that implemented the same interface, wrapped the client, and injected the cross-cutting concerns."

</td></tr>
</table>

<a id="q-4-5"></a>

<table>
<tr><th align="left">4.5 What is Inversion of Control?</th></tr>
<tr><td>

**Inversion of Control (IoC)** is a broad architectural principle where the control flow of a program is inverted compared to traditional procedural programming.

**The Traditional Flow (Libraries):**
Your custom code is the master. It instantiates objects (`new MyDbConnection()`) and calls functions in external libraries to do work. Your code dictates the flow.

**The Inverted Flow (Frameworks):**
A framework or container is the master. You register your custom code with the framework, and the framework calls *your* code when necessary. This is famously known as the **"Hollywood Principle"**: *"Don't call us, we'll call you."*

**Architectural Benefit:**
It decouples the execution of a task from implementation. In ASP.NET Core, the framework handles the HTTP socket, the routing, and the security checks (the IoC container at work). It only calls your Controller method at the exact right moment. 

</td></tr>
</table>

<a id="q-4-6"></a>

<table>
<tr><th align="left">4.6 What is Dependency Injection pattern?</th></tr>
<tr><td>

**Dependency Injection (DI)** is the specific design pattern used to achieve Inversion of Control for object creation.

**The Core Concept:**
Instead of a class instantiating its own dependencies using the `new` keyword (which tightly couples them), those dependencies are created externally by an IoC Container and "injected" into the class, almost always via its constructor.

```csharp
// BAD: Tightly coupled
public class OrderService {
    private readonly SqlRepository _repo = new SqlRepository();
}

// GOOD: Dependency Injection
public class OrderService {
    private readonly IRepository _repo;
    public OrderService(IRepository repo) { _repo = repo; }
}
```

This simple shift is the cornerstone of modern testability. It allows you to inject mock repositories during unit tests, ensuring the `OrderService` is tested in total isolation.

</td></tr>
</table>

<a id="q-4-7"></a>

<table>
<tr><th align="left">4.7 How does dependency injection relate to IoC?</th></tr>
<tr><td>

IoC is the broad architectural principle (the "What"), and DI is the specific design pattern used to achieve it (the "How").

**Analogy:**
IoC is deciding "I am not going to drive myself to the airport; I am giving control to someone else." 
Dependency Injection is the specific act of "Hiring an Uber driver to come pick me up." (Other forms of IoC might include taking a train or having a friend drive you, akin to Events or Callbacks in code).

</td></tr>
</table>

<a id="q-4-8"></a>

<table>
<tr><th align="left">4.8 What is Singleton pattern?</th></tr>
<tr><td>

The **Singleton Pattern** is a Creational design pattern that guarantees a class has one, and only one, instance globally, while providing a single point of access to it.

**Classic Implementation Requirements:**
1. A `private` constructor (prevents anyone from calling `new`).
2. A `private static` field to hold the single instance.
3. A `public static` property (usually called `Instance`) to return that exact field to any caller.

*(Note: While you must know this definition for interviews, the classic static implementation is largely considered an anti-pattern in modern .NET).*

</td></tr>
</table>

<a id="q-4-9"></a>

<table>
<tr><th align="left">4.9 Where would you use Singleton?</th></tr>
<tr><td>

You use a Singleton when you have a component that holds shared state or manages a shared resource where multiple instances would cause conflicts, high memory overhead, or logical bugs.

**Production Examples:**
- **Connection Pools:** Managing a fixed pool of connections to a Redis cluster or a database.
- **In-Memory Caching:** An `MemoryCache` where all parts of the application must read and write to the exact same underlying dictionary.
- **Global Configuration:** Reading `appsettings.json` from the disk once at startup, and holding those settings in memory for the lifetime of the application.

</td></tr>
</table>

<a id="q-4-10"></a>

<table>
<tr><th align="left">4.10 Problems with Singleton?</th></tr>
<tr><td>

The classic static implementation (`MySingleton.Instance`) is an architectural anti-pattern in modern C# for three major reasons:

1. **Hidden Dependencies:** It acts as a global variable. A class consuming `Logger.Instance` doesn't declare it in its constructor, meaning you don't actually know what the class depends on just by looking at its signature.
2. **Testing Nightmare:** Because it is static, it carries state across unit tests. Furthermore, it is impossible to inject a mock version of a static class, making it incredibly difficult to isolate the code under test.
3. **Concurrency:** Writing a truly thread-safe static Singleton without introducing locking bottlenecks is notoriously difficult.

**The Modern Solution:**
You simply register a normal, non-static class in your Dependency Injection container using `builder.Services.AddSingleton<ICache, RedisCache>()`. The DI container enforces the single-instance rule for you, but you still inject it via interfaces, completely solving the testing and hidden dependency problems.

</td></tr>
</table>

<a id="q-4-11"></a>

<table>
<tr><th align="left">4.11 How would you implement a thread-safe Singleton?</th></tr>
<tr><td>

If you absolutely must write a manual static Singleton (perhaps in a legacy system without DI), the only modern, acceptable way to do it in C# is by using `Lazy<T>`.

**The Legacy Way (Double-Check Locking):**
Historically, developers used a `lock` block with a double `if (instance == null)` check. It was verbose, prone to race conditions if implemented incorrectly, and caused locking overhead.

**The Modern Way (`Lazy<T>`):**
```csharp
public class SafeSingleton
{
    // Lazy<T> handles all thread-safety and lazy initialization internally
    private static readonly Lazy<SafeSingleton> _lazy = 
        new Lazy<SafeSingleton>(() => new SafeSingleton());

    public static SafeSingleton Instance => _lazy.Value;

    private SafeSingleton() { }
}
```
`Lazy<T>` guarantees that the instantiation lambda is executed exactly once, safely, even if thousands of threads hit `Instance` simultaneously.

</td></tr>
</table>

<a id="q-4-12"></a>

<table>
<tr><th align="left">4.12 Write a thread-safe Singleton implementation</th></tr>
<tr><td>

*(If forced to write one on a whiteboard, don't just write a generic `ConfigurationManager`. Write something that actually requires a Singleton, like a heavy resource pool).*

```csharp
public sealed class RedisConnectionPool
{
    // Lazy<T> ensures thread-safe, exactly-once initialization without locks
    private static readonly Lazy<RedisConnectionPool> _instance = 
        new Lazy<RedisConnectionPool>(() => new RedisConnectionPool());

    // Public access point
    public static RedisConnectionPool Instance => _instance.Value;

    private readonly ConnectionMultiplexer _multiplexer;

    // Private constructor prevents external 'new'
    private RedisConnectionPool()
    {
        // Expensive connection logic that should only happen once globally
        _multiplexer = ConnectionMultiplexer.Connect("localhost:6379");
    }

    public IDatabase GetDatabase() => _multiplexer.GetDatabase();
}
```

</td></tr>
</table>

<a id="q-4-13"></a>

<table>
<tr><th align="left">4.13 What is Factory pattern?</th></tr>
<tr><td>

The **Factory Method Pattern** is a creational pattern that provides an interface for creating objects in a superclass, but allows subclasses or implementing classes to alter the type of objects that will be created.

**Architectural Reasoning ("New is Glue"):**
Using the `new` keyword tightly couples your code to a specific concrete implementation. If your `ReportGenerator` calls `new PdfWriter()`, it is permanently glued to PDF generation. 

By delegating the creation to an `IDocumentFactory`, you adhere to the **Open/Closed Principle**. The `ReportGenerator` asks the factory for an `IDocumentWriter`. At runtime, the factory might return a `PdfWriter`, an `ExcelWriter`, or a `CsvWriter`. You can add new formats without ever touching the `ReportGenerator` code.

</td></tr>
</table>

<a id="q-4-14"></a>

<table>
<tr><th align="left">4.14 Difference between Factory and Abstract Factory?</th></tr>
<tr><td>

The difference comes down to the **scale of creation**.

| Feature | Factory Method | Abstract Factory |
|---|---|---|
| **Purpose** | Creates **one** specific product (e.g., an `IDocument`). | Creates entire **families** of related products (e.g., an `IThemeFactory` that creates an `IButton`, `ITextBox`, and `IScrollBar`). |
| **Complexity** | Simple. Usually involves a single method signature like `Create()`. | Complex. The interface contains multiple creation methods for the different family members. |
| **Guarantee** | Decouples instantiation of a single type. | Guarantees that all created objects are compatible with each other (e.g., you won't accidentally mix MacOS buttons with Windows scrollbars). |

</td></tr>
</table>

<a id="q-4-15"></a>

<table>
<tr><th align="left">4.15 What is Builder pattern?</th></tr>
<tr><td>

The **Builder Pattern** is a creational pattern used to construct complex objects step by step.

**The Anti-Pattern (Telescoping Constructor):**
When an object has a dozen properties, you often see constructors with massive parameter lists (`new User("John", "Doe", null, 25, true, null)`). This is unreadable and highly error-prone because it's easy to swap two variables of the same type (like two strings).

**The Architectural Fix:**
You separate the construction logic into a Builder class. It is frequently paired with a **Fluent Interface** to make the code highly readable, and it is the premier way to instantiate **Immutable Objects**.

```csharp
// The object is immutable, completely safe to pass around
var user = new UserBuilder()
    .WithFirstName("John")
    .WithLastName("Doe")
    .WithAge(25)
    .Build(); 
```
*(Note: In C# 11+, the `required` keyword and `init` properties have largely replaced the need for custom Builder classes for basic DTOs, but Builders remain heavily used for complex configuration setups, like `WebApplication.CreateBuilder()`).*

</td></tr>
</table>

<a id="q-4-16"></a>

<table>
<tr><th align="left">4.16 What is Strategy pattern?</th></tr>
<tr><td>

The **Strategy Pattern** is a behavioral pattern that allows you to define a family of algorithms, encapsulate each one inside a separate class, and make them interchangeable at runtime.

It is the ultimate implementation of the **Open/Closed Principle**.

**The Anti-Pattern:**
A massive class with multiple `if/else` or `switch` statements that alter behavior based on a flag (e.g., `if (type == "CreditCard") { ... } else if (type == "PayPal") { ... }`).

**The Fix:**
You extract each specific block of logic into its own class that implements a common interface (`IPaymentStrategy`). The main class (the Context) holds a reference to the interface and delegates the work to it. When the business needs a new algorithm, you write a new class; you don't edit the existing context.

</td></tr>
</table>

<a id="q-4-17"></a>

<table>
<tr><th align="left">4.17 Real-world example of Strategy pattern?</th></tr>
<tr><td>

A modern .NET production example often combines the Strategy Pattern with Dependency Injection.

Imagine an e-commerce checkout needing to calculate shipping.

1. **The Interface:** `IShippingStrategy` with a method `decimal Calculate(Order order)`.
2. **The Concrete Strategies:** `FedExStrategy`, `UpsStrategy`, and `PostalServiceStrategy`.
3. **The Context:** The `CheckoutService` injects an `IEnumerable<IShippingStrategy>`. 

When calculating the cost, the `CheckoutService` doesn't use a switch statement. It simply looks through the injected collection for the strategy that matches the user's selected courier, and calls `.Calculate()`. The `CheckoutService` doesn't care *how* the math is done, only that it gets a decimal back.

</td></tr>
</table>

<a id="q-4-18"></a>

<table>
<tr><th align="left">4.18 What is Observer pattern?</th></tr>
<tr><td>

The **Observer Pattern** is a behavioral pattern that defines a one-to-many subscription mechanism to notify multiple objects about events happening to the object they're observing.

**The Core Components:**
- **Subject (Publisher):** The object holding the state. It maintains a list of subscribers.
- **Observer (Subscriber):** The objects that want to be notified when the Subject's state changes.

**.NET Implementations:**
While you can build this manually, C# and the .NET ecosystem have this concept fundamentally baked in at multiple levels:
1. **Language Level:** Standard `event` and `delegate` structures.
2. **Framework Level:** The `IObservable<T>` and `IObserver<T>` interfaces, heavily utilized by **Reactive Extensions (Rx.NET)** for handling asynchronous data streams.
3. **Architecture Level:** In distributed microservices, this pattern evolves into Pub/Sub architectures using message brokers like RabbitMQ or Azure Service Bus.

</td></tr>
</table>

<a id="q-4-19"></a>

<table>
<tr><th align="left">4.19 What is Adapter pattern?</th></tr>
<tr><td>

The **Adapter Pattern** is a structural pattern that allows objects with incompatible interfaces to collaborate.

**The Analogy:**
It acts exactly like a travel power adapter. You have a US plug (the Client) and a UK socket (the Service). They are incompatible. The Adapter sits in the middle and translates the interface.

**Production .NET Use Case (Anti-Corruption Layer):**
You have a modern `ILogger` interface in your domain, but you are forced to use an archaic, heavily-coupled 3rd-party logging SDK in the infrastructure layer. If you use the SDK directly, your domain is corrupted. Instead, you create a `LegacyLoggerAdapter` class that implements *your* `ILogger` interface, but internally translates those calls into the ugly syntax required by the 3rd-party SDK. The adapter shields your core domain from external changes.

</td></tr>
</table>

<a id="q-4-20"></a>

<table>
<tr><th align="left">4.20 What is Facade pattern?</th></tr>
<tr><td>

The **Facade Pattern** is a structural pattern that provides a simplified, higher-level interface to a complex subsystem of classes, libraries, or frameworks.

**The Problem:**
Your business logic is heavily coupled to dozens of classes from a complex 3rd-party video conversion library. The controller method is 200 lines long, orchestrating codecs, bitrates, and file streams. The logic is unreadable and brittle.

**The Solution:**
Create a `VideoConverterFacade` class with a single, simple method: `ConvertVideoToMp4()`. Internally, this facade handles instantiating all the complex subsystems and configuring them. The controller only depends on the Facade.

**Architectural Benefit:**
It drastically reduces the learning curve for consumers and minimizes dependency mapping. If the underlying subsystem updates, you only fix the Facade class, not the entire application.

</td></tr>
</table>

<a id="q-4-21"></a>

<table>
<tr><th align="left">4.21 What is Repository pattern?</th></tr>
<tr><td>

The **Repository Pattern** is an architectural abstraction that mediates between the domain/business logic and data mapping layers. It presents data access as if it were a simple in-memory collection (`Add`, `Remove`, `GetById`).

**Why Use It in Production?**
1. **Mocking & Testability:** You cannot unit test a service that creates a raw `SqlConnection`. Injecting an `IUserRepository` allows you to mock the database entirely, returning static lists of users in milliseconds.
2. **Query Centralization:** It prevents the nightmare of duplicate LINQ queries scattered across 50 different controllers. A complex `GetActiveUsersWithDebts()` query is written once in the repository and reused everywhere.

**The Entity Framework Core Controversy:**
In modern .NET, `DbSet<T>` *is* a generic repository, and `DbContext` *is* a Unit of Work. Creating a generic wrapper like `IRepository<T>` over EF Core is widely considered an **anti-pattern** by senior architects today. It adds a useless layer of abstraction that destroys the power of `IQueryable` and Entity Framework's built-in features. You should only use the Repository pattern if you are defining specific, highly-tailored domain queries (e.g., `IOrderRepository.GetPendingOrders()`), not generic CRUD operations.

</td></tr>
</table>

<a id="q-4-23"></a>

<table>
<tr><th align="left">4.23 What is Unit of Work pattern?</th></tr>
<tr><td>

The **Unit of Work Pattern** coordinates the writing out of changes to a database, ensuring that all actions within a business transaction are treated as a single atomic unit.

**The Problem with Isolated Repositories:**
If an e-commerce checkout uses an `OrderRepository.Add()` and an `InventoryRepository.Update()`, they might execute as separate database transactions. If the stock update fails, the order is still saved. This causes severe data corruption.

**The Solution:**
A `UnitOfWork` class manages a single, shared database connection/transaction. Both repositories are injected with this shared context. The business logic calls the repositories, making changes purely in memory. Finally, the service calls `UnitOfWork.Commit()`, which flushes all changes to the database in one single, atomic SQL transaction. If anything fails, it all rolls back.

**EF Core Implementation:**
Entity Framework's `DbContext` inherently implements this pattern. When you modify objects attached to the context, nothing hits the database until you call `.SaveChanges()`, which wraps all statements in a single transaction.

</td></tr>
</table>

<a id="q-4-24"></a>

<table>
<tr><th align="left">4.24 Difference between Singleton, Factory, and Repository patterns</th></tr>
<tr><td>

| Pattern | Category | Architectural Purpose | What it Abstracts |
|---|---|---|---|
| **Singleton** | Creational | Ensures only **one instance** of an object exists globally to manage shared state or expensive resources. | Hides the instance state and lifecycle management. |
| **Factory** | Creational | Centralizes **object creation** logic to prevent "new is glue" coupling. | Hides the complex logic of *how* an object is instantiated. |
| **Repository** | Structural | Abstracts **data access** so the domain can treat storage like an in-memory collection. | Hides the database, SQL, or ORM details from the domain logic. |

</td></tr>
</table>

<a id="q-4-25"></a>

<table>
<tr><th align="left">4.25 What is CQRS?</th></tr>
<tr><td>

**CQRS (Command Query Responsibility Segregation)** is a high-performance architectural pattern that strictly separates the operations that read data (Queries) from the operations that mutate data (Commands).

**The Core Rule:**
A method should either change state and return a success/fail DTO (Command), or return data without changing any state (Query). It should never do both.

**Why Use It in Production?**
1. **Asymmetric Scaling:** In most enterprise applications, read requests outnumber write requests 100-to-1. CQRS allows you to scale the read infrastructure independently from the write infrastructure.
2. **Optimized Data Models:** The write database model can be highly normalized (3NF) to enforce strict business rules and data integrity. The read database model can be heavily denormalized (e.g., flattened JSON views in Elasticsearch or Redis) so queries execute in single-digit milliseconds without massive SQL joins.

**.NET Implementation (MediatR):**
In .NET, CQRS is overwhelmingly implemented using the **MediatR** library. You define `IRequest` records for Commands and Queries, and create isolated `IRequestHandler` classes to execute the specific logic. This creates massive vertical slices that are incredibly easy to test and maintain.

</td></tr>
</table>

**[⬆ Back to Top](#table-of-contents)**

<a id="section-5"></a>
## 5. Dependency Injection

<a id="q-5-1"></a>

<table>
<tr><th align="left">5.1 What is Inversion of Control?</th></tr>
<tr><td>

**Inversion of Control (IoC)** is a design principle where the control flow of a program is inverted: instead of custom code calling into library functions, a framework calls into custom code.

**The .NET Implementation:**
In modern .NET, the ASP.NET Core generic host (the `WebApplicationBuilder`) is the ultimate IoC container. It controls the entire application lifecycle, establishes the Kestrel server, instantiates your controllers, and injects the dependencies *you* requested. It completely removes the burden of manual object creation and routing from your application code.

*(See Question 4.5 for the "Hollywood Principle" analogy).*

</td></tr>
</table>

<a id="q-5-2"></a>

<table>
<tr><th align="left">5.2 What is dependency injection?</th></tr>
<tr><td>

**Dependency Injection (DI)** is the implementation of IoC used specifically to manage and provide the required dependencies to an object at runtime.

**The .NET Mechanic:**
Instead of a class `OrderService` using the `new` keyword to create an `SqlRepository`, the `OrderService` simply declares that it *needs* an `IRepository` via its constructor. The built-in `.NET DI container` (`Microsoft.Extensions.DependencyInjection`) intercepts the creation of `OrderService` and automatically provides the concrete instance of the repository.

</td></tr>
</table>

<a id="q-5-3"></a>

<table>
<tr><th align="left">5.3 What problems does dependency injection solve?</th></tr>
<tr><td>

While decoupling (DIP) and testability are the most commonly cited benefits, DI solves a massive production problem: **Lifecycle and Memory Management**.

**Centralized IDisposable Management:**
Before DI, developers had to manually instantiate and `Dispose()` of database connections, HTTP clients, and file streams using `using` blocks. If you forgot, you created a memory leak. 

The .NET DI container acts as a centralized memory manager. If you register a class as `Scoped`, the container automatically tracks it. When the HTTP request finishes, the framework automatically calls `Dispose()` on every single object injected during that request. You never have to manually track lifecycle state again.

</td></tr>
</table>

<a id="q-5-4"></a>

<table>
<tr><th align="left">5.4 What happens if you instantiate concrete implementations directly?</th></tr>
<tr><td>

Using the `new` keyword directly in your business logic creates "Glue".

1. **Violation of DIP:** Your code becomes rigidly tied to that specific implementation. If you type `new SqlUserRepository()`, you can never reuse that code with a `MongoUserRepository`.
2. **Testing Impossibility:** You cannot mock the dependency. If `OrderService` calls `new EmailSender()`, your unit tests will actually try to send real emails to real customers, which is disastrous.
3. **Cascade of Changes:** If the constructor of `EmailSender` changes to require a new `SmtpSettings` object, you have to find and modify every single class in your entire application that called `new EmailSender()`. With DI, you only update the single registration in `Program.cs`.

</td></tr>
</table>

<a id="q-5-5"></a>

<table>
<tr><th align="left">5.5 How is DI implemented in .NET?</th></tr>
<tr><td>

.NET provides a built-in, highly optimized IoC container split into two distinct phases.

**1. The Registration Phase (`IServiceCollection`):**
In `Program.cs`, you register your interfaces and their concrete implementations into a dictionary-like collection. 
`builder.Services.AddScoped<IInterface, Implementation>();`

**2. The Resolution Phase (`IServiceProvider`):**
Once the app calls `builder.Build()`, the collection is locked and compiled into the `IServiceProvider`. When an HTTP request hits a Controller, the framework looks at the Controller's constructor, asks the `IServiceProvider` for instances of the required interfaces, and injects them automatically.

</td></tr>
</table>

<a id="q-5-6"></a>

<table>
<tr><th align="left">5.6 Explain the three DI service lifetimes: Transient, Scoped, and Singleton.</th></tr>
<tr><td>

This is arguably the most critical Dependency Injection concept in .NET.

| Lifetime | Registration | Behavior | Production Use Case |
|---|---|---|---|
| **Transient** | `AddTransient()` | A new instance is created **every single time** it is requested by the container. | Lightweight, stateless utilities (e.g., a simple password hasher or math calculator). |
| **Scoped** | `AddScoped()` | A new instance is created **once per HTTP request**. All classes requesting it during that exact same HTTP request get the exact same instance. | State tied to the current user's request (e.g., `DbContext`, `CurrentUserContext`). |
| **Singleton** | `AddSingleton()` | A single instance is created the first time it is requested and is shared globally for the entire lifetime of the application. | Shared thread-safe resources: caching, configuration (`IOptions`), or connection pools. |

</td></tr>
</table>

<a id="q-5-7"></a>

<table>
<tr><th align="left">5.7 Which lifetime is used for DbContext?</th></tr>
<tr><td>

By default, `DbContext` in Entity Framework Core is registered as **Scoped**.

**Why Scoped? (The Unit of Work)**
If it were `Transient`, a single HTTP request that uses both an `OrderRepository` and an `InventoryRepository` would receive two completely different `DbContext` instances. If the order saves but the inventory fails, you couldn't roll back the transaction cleanly. `Scoped` guarantees that every repository in that specific HTTP request shares the exact same database transaction.

**Why not Singleton?**
A `DbContext` is not thread-safe. It tracks entities in memory. If it were a `Singleton`, 500 concurrent users hitting your API would all try to write to the exact same `DbContext` concurrently, causing immediate threading exceptions and data corruption.

</td></tr>
</table>

<a id="q-5-8"></a>

<table>
<tr><th align="left">5.8 What problems happen with Singleton misuse?</th></tr>
<tr><td>

Registering a class as a Singleton when it shouldn't be introduces catastrophic bugs that only appear under load.

1. **Memory Leaks:** Singletons live forever. If a Singleton holds references to objects (like adding items to a `List<T>` on every request), those objects are never garbage collected. The application will eventually crash with an `OutOfMemoryException`.
2. **Race Conditions:** If a Singleton holds mutable state (like a `Dictionary`), multiple HTTP requests will attempt to read and write to it simultaneously. Unless strictly synchronized with `lock` statements or `ConcurrentDictionary`, the application will crash.
3. **Captive Dependencies:** The most dangerous DI error in .NET, where a Singleton traps a short-lived service.

</td></tr>
</table>

<a id="q-5-9"></a>

<table>
<tr><th align="left">5.9 What is captive dependency?</th></tr>
<tr><td>

A **Captive Dependency** is a severe architectural bug that occurs when a service with a longer lifetime holds a reference to a service with a shorter lifetime (e.g., a Singleton injecting a Scoped service).

**The Disaster Scenario:**
1. You register `CacheManager` as `Singleton`.
2. You register `AppDbContext` as `Scoped`.
3. You inject `AppDbContext` into the constructor of `CacheManager`.

Because the `Singleton` is only created once, its constructor runs once. It receives a `DbContext` instance and holds onto it forever. That specific `DbContext` is now "captive". It will never be disposed at the end of the HTTP request. 

**The Consequence:**
The database connection remains open indefinitely, and the EF Core change tracker grows infinitely large until the application crashes. *(Note: ASP.NET Core has built-in scope validation (`ValidateScopes = true`) that throws a runtime exception at startup if it detects this).*

</td></tr>
</table>

<a id="q-5-10"></a>

<table>
<tr><th align="left">5.10 How does DI help in unit testing and mocking?</th></tr>
<tr><td>

Unit tests must test a single class in complete isolation. If your class does not use Dependency Injection, it creates its own dependencies, making isolation impossible.

**The Mocking Flow:**
1. Your `OrderService` requires an `IOrderRepository`. 
2. During production, the DI container injects the real `SqlOrderRepository`.
3. During a unit test, you do not use the DI container. Instead, you manually pass a "Fake" or "Mock" object into the constructor using a library like **Moq** or **NSubstitute**.

```csharp
// Arrange
var mockRepo = new Mock<IOrderRepository>();
mockRepo.Setup(x => x.GetOrder(1)).Returns(new Order { Id = 1 });

var service = new OrderService(mockRepo.Object); // Injecting the mock

// Act
var result = service.ProcessOrder(1);
```
By using DI, you ensure the unit test evaluates the business logic inside `OrderService`, not the network connectivity of the SQL database.

</td></tr>
</table>

**[⬆ Back to Top](#table-of-contents)**

<a id="section-6"></a>
## 6. C# Core Concepts

<a id="q-6-1"></a>

<table>
<tr><th align="left">6.1 What is a static class?</th></tr>
<tr><td>

A **static class** is a class that cannot be instantiated and acts purely as a container for stateless utility methods or global state.

- **No Objects:** You cannot use the `new` keyword to create a variable of the class type.
- **Access:** You access its members directly via the class name itself (e.g., `Math.Round()`).
- **Contents:** A static class can only contain static members (methods, fields, properties, events). It cannot contain instance members.
- **Sealed by Default:** Internally, the C# compiler marks a static class as `abstract sealed` in IL, ensuring it can neither be instantiated nor inherited.

</td></tr>
</table>

<a id="q-6-2"></a>

<table>
<tr><th align="left">6.2 When should you use a static class?</th></tr>
<tr><td>

Static classes should be used sparingly in enterprise architecture due to testability concerns, but they have three specific use cases:

1. **Extension Methods:** In C#, an extension method (e.g., `public static bool IsValid(this string str)`) *must* be defined inside a static class.
2. **Stateless Utility Helpers:** Collections of pure functions that take inputs, perform calculations, and return outputs without touching external resources or maintaining state (e.g., `System.Math`).
3. **Global Constants:** Storing application-wide constants (`public static readonly string AppName = "MyApp"`).

**The Anti-Pattern:**
Never use static classes to hold mutable state (global variables) or to execute logic that touches databases or HTTP clients. This leads to tight coupling, race conditions, and makes unit testing impossible.

</td></tr>
</table>

<a id="q-6-3"></a>

<table>
<tr><th align="left">6.3 What are the limitations of static classes?</th></tr>
<tr><td>

In modern architecture, the limitations of static classes revolve entirely around **Testability and Concurrency**.

1. **No Interfaces:** A static class cannot implement an interface. Because it lacks an interface, you cannot register it in the .NET Dependency Injection container, and you cannot inject a mock version using frameworks like Moq.
2. **Shared State (Concurrency):** Any state (static fields) held within a static class is shared across the entire AppDomain. If Request A modifies a static field, Request B instantly sees that modification. Without strict `lock` statements, this guarantees race conditions.
3. **No Inheritance:** Static classes cannot inherit from any other class (except `System.Object`), and no class can inherit from them.

</td></tr>
</table>

<a id="q-6-4"></a>

<table>
<tr><th align="left">6.4 Difference between static constructor and private constructor</th></tr>
<tr><td>

| Feature | Static Constructor | Private Constructor |
|---|---|---|
| **Architectural Purpose** | Initializes **global static state** exactly once per application lifecycle. | Prevents external **instance creation** (often used to force the use of Factory methods or Singletons). |
| **Execution Trigger** | Called automatically by the CLR immediately before the first instance is created or the first static member is accessed. | Called explicitly by code *inside* the class using the `new` keyword. |
| **Parameters**| Cannot take parameters (the CLR wouldn't know what to pass). | Can take parameters. |
| **Access Modifier**| Has no access modifiers (implicitly private). | Explicitly marked as `private`. |

</td></tr>
</table>

<a id="q-6-5"></a>

<table>
<tr><th align="left">6.5 How do static members work internally?</th></tr>
<tr><td>

**Memory Allocation (The High-Frequency Heap):**
Unlike standard instance members which are allocated on the Managed Heap and tracked by the Garbage Collector, static fields are allocated in a special memory area called the **High-Frequency Heap** (part of the AppDomain's loader heap).

**Lifetime:**
The memory for static fields is allocated the exact moment the type is loaded by the CLR. It lives permanently until the AppDomain is unloaded (usually when the application shuts down or the IIS application pool recycles). Because they are rooted, static fields are never subject to normal Garbage Collection.

**Method Dispatch:**
The compiler resolves static method calls using early binding (direct memory addresses). There is no vtable (virtual method table) lookup required at runtime, making static method execution slightly faster than virtual instance methods.

</td></tr>
</table>

<a id="q-6-6"></a>

<table>
<tr><th align="left">6.6 Why does the CLR provide thread safety for static constructors?</th></tr>
<tr><td>

**The Guarantee:**
The CLR guarantees that a static constructor is executed exactly **once** per AppDomain, and it handles all the required thread-safety locks internally. You do not need to write `lock` statements inside a static constructor.

**The Reason:**
Static constructors are often used to initialize critical global state (like a connection string or a static dictionary). If two HTTP requests hit a service at the exact same millisecond at application startup, without CLR locks, the static constructor would run twice on two different threads, causing massive memory corruption. The CLR pauses the second thread until the first thread finishes the static constructor.

</td></tr>
</table>

<a id="q-6-7"></a>

<table>
<tr><th align="left">6.7 Order of execution of static constructors and instance constructors</th></tr>
<tr><td>

If you instantiate a derived class for the *very first time* in an application, the execution order is strictly top-down (Statics first, then Instances; Base first, then Derived).

**The Flow (First Instance):**
1. Derived class **static fields** are initialized.
2. Base class **static fields** are initialized.
3. Base class **static constructor** executes.
4. Derived class **static constructor** executes.
5. Derived class **instance fields** are initialized.
6. Base class **instance fields** are initialized.
7. Base class **instance constructor** executes.
8. Derived class **instance constructor** executes.

*(Note: On the second instance created, steps 1-4 are completely skipped because statics only run once).*

</td></tr>
</table>

<a id="q-6-8"></a>

<table>
<tr><th align="left">6.8 What is a sealed class?</th></tr>
<tr><td>

A **sealed class** is a class that completely restricts inheritance. 

- **The Keyword:** You apply the `sealed` keyword to the class declaration (e.g., `public sealed class Configuration`).
- **Compiler Enforcement:** If any other class attempts to derive from it (`public class MyConfig : Configuration`), the C# compiler throws a build error.
- **Intrinsic Example:** Many fundamental .NET types, like `System.String`, are sealed to ensure their behavior cannot be altered or broken by derived implementations.

</td></tr>
</table>

<a id="q-6-9"></a>

<table>
<tr><th align="left">6.9 Why would you seal a class or method?</th></tr>
<tr><td>

You seal classes for two primary reasons in enterprise code: **Security/Predictability** and **Performance**.

**1. Security & Predictability:**
If a class handles highly sensitive operations (e.g., a `PasswordHasher`), sealing it prevents a junior developer from extending it and accidentally overriding a secure virtual method with insecure logic. It guarantees the behavior of the class is final.

**2. Performance (Devirtualization):**
When the JIT (Just-In-Time) compiler sees a `sealed` class, it knows mathematically that no derived types can exist to override its methods. It can then aggressively inline the method calls directly into the CPU registers (removing the vtable lookup overhead). In high-performance loops, this results in measurable speed gains.

**Sealing Methods:**
You don't just seal classes. You can seal an *overridden* virtual method in a derived class (`public sealed override void DoWork()`). This stops any further classes further down the inheritance chain from overriding it again.

</td></tr>
</table>

<a id="q-6-10"></a>

<table>
<tr><th align="left">6.10 Difference between class, struct, and record</th></tr>
<tr><td>

These are the three primary mechanisms to define complex data types in C#. Knowing exactly when to use each is a core senior architectural skill.

| Feature | Class | Struct | Record |
|---|---|---|---|
| **Type** | Reference Type (Heap allocated). | Value Type (Stack/Inline allocated). | Reference Type (usually) or Value Type (`record struct`). |
| **Inheritance** | Supports full inheritance. | No inheritance (except from interfaces). | Supports inheritance (only from other records). |
| **Equality Check** | By default, checks **Reference Equality** (do they point to the exact same memory address?). | Checks **Value Equality** (do all fields match?). | Checks **Value Equality** automatically. |
| **Primary Use Case**| Services, Controllers, complex business logic, large stateful objects. | Small, lightweight, mathematically focused data holding (`Point`, `Vector`). | Immutable DTOs, API Requests/Responses, Configurations. |

</td></tr>
</table>

<a id="q-6-11"></a>

<table>
<tr><th align="left">6.11 Difference between class and struct</th></tr>
<tr><td>

This is a fundamental CLR question testing your knowledge of memory allocation.

- **Memory Allocation:** Classes are allocated on the **Managed Heap** and are subject to Garbage Collection. Structs are allocated on the **Thread Stack** (or inline within a heap object) and are cleaned up immediately and deterministically when they go out of scope.
- **Passing by Value vs Reference:** When you pass a Class to a method, you pass a *reference pointer* (modifying the parameter alters the original object). When you pass a Struct, you pass a *full byte-for-byte copy* of the data (modifying it does not affect the original unless you explicitly use `ref`).
- **Nullability:** Classes can naturally be `null`. Standard structs cannot be `null` because they directly hold value data, not pointers (unless explicitly boxed as `Nullable<T>` / `T?`).

</td></tr>
</table>

<a id="q-6-12"></a>

<table>
<tr><th align="left">6.12 When should you use a struct instead of a class?</th></tr>
<tr><td>

Microsoft provides strict architectural guidelines on when to use a struct. You should only use a struct if it meets **all four** of the following criteria:

1. **Logically represents a single value:** Like primitive types (`int`, `double`) or mathematical concepts (`Point`, `Vector3`, `Color`).
2. **Small Size:** The instance size is under 16 bytes. If it's larger, the CPU cost of copying the struct over and over on every method call outweighs the benefit of avoiding heap allocation.
3. **Immutable:** It should be completely immutable. Modifying state inside a value type leads to confusing bugs because you are often accidentally modifying a *copy*, not the original.
4. **Not Boxed:** It will not have to be boxed frequently (e.g., cast to `object` or an interface). Boxing forces the CLR to allocate a wrapper object on the heap anyway, completely defeating the performance purpose of the struct.

</td></tr>
</table>

<a id="q-6-13"></a>

<table>
<tr><th align="left">6.13 Why are structs value types?</th></tr>
<tr><td>

Structs are value types because they directly contain their data in memory, rather than containing a pointer to a location on the heap.

**The Design Goal:**
Structs exist to provide high-performance, low-overhead memory operations. By placing them on the stack (or inline in arrays/classes), the CLR completely avoids the overhead of updating pointers, allocating heap memory, and eventually triggering CPU-intensive Garbage Collection cycles.

**The Array Benefit (Cache Line Efficiency):**
An array of 10,000 reference type classes requires 10,000 heap allocations, plus an array of 10,000 pointers. When iterating, the CPU has to jump all over the heap. 
An array of 10,000 structs is allocated as one single, contiguous, densely-packed block of memory. This is incredibly efficient for CPU cache lines, making iteration exponentially faster.

</td></tr>
</table>

<a id="q-6-14"></a>

<table>
<tr><th align="left">6.14 What are records in C# and why were they introduced?</th></tr>
<tr><td>

A **record** is a reference type that provides built-in functionality for encapsulating data with value-based equality.

**The Concept:**
Introduced in C# 9, records are essentially classes that the compiler automatically optimizes to act as immutable data models.

**The Boilerplate Solution:**
Before records, if developers wanted to create truly immutable classes that could be compared by their values, they had to write hundreds of lines of boilerplate code (overriding `Equals`, `GetHashCode`, `==`, `!=`, and writing cloning constructors). 
Records solve this with syntactic sugar:
`public record Person(string FirstName, string LastName);`
This single line automatically generates all the immutable properties, constructors, and value-equality methods during compilation.

</td></tr>
</table>

<a id="q-6-15"></a>

<table>
<tr><th align="left">6.15 What problems do records solve?</th></tr>
<tr><td>

Records solve the problem of safely moving data around a complex system.

- **Value Equality:** Two different record instances with the exact same data are considered completely equal (`person1 == person2` returns `true`). With normal classes, this would return `false` because they have different heap memory addresses.
- **Non-Destructive Mutation:** Records introduce the `with` expression. If you want to change one property of an immutable record, you create a copy with the altered data: `var olderPerson = person with { Age = 30 };`. The original record remains untouched.
- **Production Use Case:** They are the gold standard for DTOs (Data Transfer Objects), API Request/Response models, and CQRS Commands/Queries (e.g., MediatR `IRequest` models), guaranteeing that data cannot be accidentally altered in transit.

</td></tr>
</table>

<a id="q-6-16"></a>

<table>
<tr><td>

**Extension methods** allow you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

- **The Syntax:** They are static methods defined inside a static class. The first parameter specifies the type being extended and is preceded by the `this` modifier (e.g., `public static int WordCount(this string str)`).
- **The Magic of LINQ:** The entire LINQ library (`.Where()`, `.Select()`) is built completely on extension methods extending the `IEnumerable<T>` interface.
- **Usage:** They look and feel exactly like native instance methods to the developer calling them (`myString.WordCount()`).

</td></tr>
</table>

<a id="q-6-17"></a>

<table>
<tr><th align="left">6.17 How are extension methods implemented under the hood?</th></tr>
<tr><td>

- **Syntactic Sugar:** The CLR (Common Language Runtime) actually has no concept of an "extension method". It is purely a trick of the C# compiler.
- **The Translation:** When the C# compiler sees you calling `myString.WordCount()`, it immediately rewrites that line of code into a standard static method call: `StringUtilities.WordCount(myString)`.
- **No Private Access:** Because they are compiled as normal static methods living in a completely different class, extension methods cannot access private or protected members of the class they are extending.

</td></tr>
</table>

<a id="q-6-18"></a>

<table>
<tr><th align="left">6.18 What is Reflection?</th></tr>
<tr><td>

**Reflection** (`System.Reflection`) is the ability of a program to dynamically inspect its own metadata and interact with its own structure at runtime.

- **Capabilities:** You can find all classes that implement an interface, read custom Attributes placed on properties, dynamically instantiate objects without using `new`, or invoke a method whose name you only know as a string.
- **The Performance Cost:** Reflection is extremely slow compared to early-bound, strongly-typed code. It bypasses compile-time checks and requires heavy dictionary lookups and security checks by the CLR. 
- **The Modern Alternative (Source Generators):** In modern .NET, much of what used to require Reflection (like JSON serialization or DI registration) is now done via **Source Generators**. These read your code during *compilation* and generate hard-coded C# classes, giving you the flexibility of Reflection with zero runtime performance cost.

</td></tr>
</table>

<a id="q-6-19"></a>

<table>
<tr><th align="left">6.19 What are delegates in C#?</th></tr>
<tr><td>

A **delegate** is a type that safely encapsulates a method, similar to a function pointer in C or C++.

- **The Concept:** It is an object that knows how to call a method. You can assign a method to a delegate, pass the delegate around as a parameter (e.g., as a callback), and then invoke the delegate later.
- **Type Safety:** Unlike C++ function pointers, delegates are fully object-oriented, type-safe, and secure. A delegate must exactly match the signature (return type and parameters) of the method it encapsulates.
- **Primary Use Cases:** Used extensively for designing event architectures, callback methods, and passing LINQ expressions (`Func`, `Action`).

</td></tr>
</table>

<a id="q-6-20"></a>

<table>
<tr><th align="left">6.20 How do delegates work internally?</th></tr>
<tr><td>

- **Compiler Generation:** When you declare a delegate, the C# compiler automatically generates a sealed class that inherits from `System.MulticastDelegate`.
- **The Internals:** This generated class contains three vital pieces of information:
  1. A reference to the target object (if it's an instance method, to provide the `this` context).
  2. A reference to the method to invoke (an `IntPtr` pointing to the memory address).
  3. An `Invoke()` method that synchronously calls the target method.
- **Invocation:** When you call `myDelegate()`, the CLR actually executes `myDelegate.Invoke()`.

</td></tr>
</table>

<a id="q-6-21"></a>

<table>
<tr><th align="left">6.21 What are multicast delegates?</th></tr>
<tr><td>

A **multicast delegate** is a delegate that holds references to more than one method.

- **The Concept:** When you invoke a multicast delegate, all the methods in its invocation list are called synchronously, in the exact order they were added.
- **The Syntax:** You add methods to a delegate's invocation list using the `+=` operator, and remove them using the `-=` operator.
- **Return Values:** If a multicast delegate has a return type, invoking it will only return the value of the *last* method executed in the list. This is why delegates used for events almost always have a `void` return type.

</td></tr>
</table>

<a id="q-6-22"></a>

<table>
<tr><th align="left">6.22 Difference between delegates and events</th></tr>
<tr><td>

| Feature | Delegate | Event |
|---|---|---|
| **Nature** | A base data type (class) that holds references to methods. | A modifier/wrapper built *on top* of a delegate to restrict external access. |
| **Invocation** | Can be invoked by any class that holds a reference to the delegate. | Can **only** be invoked by the class that declares the event. |
| **Assignment** | Can be completely reassigned/wiped out using `=`. | Can only be subscribed/unsubscribed using `+=` and `-=`. |
| **Analogy** | Like an open list of phone numbers anyone can call or erase. | Like a PA system where only the central announcer can speak, but anyone can listen. |

</td></tr>
</table>

<a id="q-6-23"></a>

<table>
<tr><th align="left">6.23 Why use events over delegates?</th></tr>
<tr><td>

Events enforce encapsulation and implement the Publish-Subscribe pattern safely.

**The Danger of Raw Delegates:**
If you expose a public delegate `public Action OnClick;`, an external class could do `button.OnClick = null;` (wiping out all other subscribers) or `button.OnClick();` (faking a click from the outside).

**The Event Shield:**
By changing it to `public event Action OnClick;`, the C# compiler applies a strict encapsulation shield. It ensures that outside classes can only use `+=` and `-=`. They cannot wipe the list using `=`, and they cannot invoke the event. Only the `Button` class itself is allowed to trigger the event.

</td></tr>
</table>

<a id="q-6-24"></a>

<table>
<tr><th align="left">6.24 How are events implemented internally in .NET?</th></tr>
<tr><td>

- **Compiler Generation:** When you declare an event, the compiler actually generates a private backing delegate field.
- **Accessor Methods:** It also generates two hidden methods: an `add_MyEvent` method and a `remove_MyEvent` method (very similar to the hidden `get` and `set` methods of an auto-property).
- **Thread Safety:** In modern C#, these generated `add` and `remove` methods use `Interlocked.CompareExchange` internally to ensure that multiple threads can safely subscribe to or unsubscribe from the event simultaneously without corrupting the delegate's invocation list.

</td></tr>
</table>

<a id="q-6-25"></a>

<table>
<tr><th align="left">6.25 When would you use events in real-world applications?</th></tr>
<tr><td>

While native C# `event` keywords are heavily used in UI Frameworks (WPF, WinForms, MAUI), they are less common in modern REST APIs because they require objects to exist in the exact same memory space.

**Modern Enterprise Evolution (Domain Events):**
In modern distributed systems and Domain-Driven Design, the "Event" concept is abstracted out to **Message Brokers** (RabbitMQ) or **In-Memory Buses** (MediatR `INotification`). 
When an `OrderService` finishes saving an order, it publishes an `OrderPlacedEvent`. The `EmailService` and `InventoryService` subscribe to this event and react independently. This achieves extreme architectural decoupling, as the publisher and subscribers don't even need to be running on the same server.

</td></tr>
</table>

<a id="q-6-26"></a>

<table>
<tr><th align="left">6.26 What is the practical use of delegates?</th></tr>
<tr><td>

- **LINQ Operations:** Every time you write `.Where(x => x.Age > 18)`, you are passing an inline anonymous method (a Lambda expression) as a delegate to the LINQ engine.
- **Asynchronous Callbacks:** Passing a "success" or "failure" method to an I/O engine so it knows what to execute when a network request completes asynchronously.
- **Lightweight Strategy Pattern:** Instead of creating a heavy object-oriented interface and class hierarchy for the Strategy pattern, you can simply inject a `Func<T, TResult>` delegate that dictates the algorithm to use on the fly.

</td></tr>
</table>

<a id="q-6-27"></a>

<table>
<tr><th align="left">6.27 Difference between Action, Func, and Predicate</th></tr>
<tr><td>

These are the built-in generic delegates provided by .NET. Because of these, you rarely have to define your own custom delegates.

| Delegate Type | Signature | Purpose | Code Example |
|---|---|---|---|
| **`Action`** | Takes 0 to 16 parameters. Returns `void`. | Used when you want to execute code but don't need a result back. | `Action<string> print = Console.WriteLine;` |
| **`Func`** | Takes 0 to 16 parameters. **Must return a value.** | Used when you need to calculate and return a result. The *last* generic parameter is always the return type. | `Func<int, int, string> addStr = (a,b) => (a+b).ToString();` |
| **`Predicate`** | Takes 1 parameter. Returns a `bool`. | Used specifically to test if an item meets a certain condition (heavily used in `List<T>.Find()`). | `Predicate<int> isEven = x => x % 2 == 0;` |

</td></tr>
</table>

<a id="q-6-28"></a>

<table>
<tr><th align="left">6.28 What are generic classes in C#?</th></tr>
<tr><td>

**Generics** allow you to define classes, methods, and interfaces with a placeholder for the type of data they store or operate on.

- **The Concept:** Instead of writing duplicate `class IntList` and `class StringList`, you write one `class List<T>`. The `<T>` is a type parameter that is replaced with the actual type (`int` or `string`) when the class is instantiated.
- **Architectural Usage:** Found everywhere in modern C#, particularly in the `System.Collections.Generic` namespace (`List<T>`, `Dictionary<TKey, TValue>`) and the EF Core `DbSet<T>`.

</td></tr>
</table>

<a id="q-6-29"></a>

<table>
<tr><th align="left">6.29 Why are generics important?</th></tr>
<tr><td>

- **Compile-Time Type Safety:** You get instant compiler errors if you try to put a `string` into a `List<int>`. Before generics (using the old `ArrayList`), collections stored `object`, meaning errors were only discovered at runtime as `InvalidCastException` crashes.
- **Massive Performance Gains (No Boxing):** Because pre-generic collections stored `object`, storing a value type like an `int` forced the CLR to "box" it (allocate it on the heap), and "unbox" it when retrieved. Generics eliminate this severe overhead entirely.
- **Code Reuse:** You write an algorithm once. A single `Repository<T>` can handle `User`, `Order`, and `Product` entities without duplicating the CRUD logic.

</td></tr>
</table>

<a id="q-6-30"></a>

<table>
<tr><th align="left">6.30 How do generics work internally in .NET?</th></tr>
<tr><td>

This involves an advanced CLR topic known as **Reification**.

- **At Compile Time:** The C# compiler emits the Intermediate Language (IL) with generic placeholders (e.g., `List\`1`). It does *not* generate separate classes for `int` and `string` yet.
- **At Runtime (JIT Compilation):** 
  - For **Value Types** (e.g., `List<int>`, `List<double>`), the JIT compiler generates a completely separate, specialized native code class for each value type. It *must* do this because different value types require different amounts of memory on the stack (4 bytes for `int`, 8 bytes for `double`).
  - For **Reference Types** (e.g., `List<string>`, `List<User>`), the JIT compiler generates the native code *exactly once* and shares it among all reference types. Because all reference types are just 64-bit memory pointers under the hood, they can safely share the same underlying machine code layout.

</td></tr>
</table>

<a id="q-6-31"></a>

<table>
<tr><th align="left">6.31 Why are generics type-safe?</th></tr>
<tr><td>

- **Compile-Time Enforcement:** The compiler knows the exact type `T` that was specified upon instantiation. 
- **No Implicit Casts:** If you have a method expecting `IEnumerable<string>`, the compiler will absolutely refuse to let you pass an `IEnumerable<object>`, completely preventing runtime cast exceptions.
- **IntelliSense:** Because the type is explicitly known at compile time, your IDE provides exact autocomplete for the properties of `T`, rather than just exposing the base `object` methods.

</td></tr>
</table>

<a id="q-6-32"></a>

<table>
<tr><th align="left">6.32 What are generic constraints?</th></tr>
<tr><td>

Generic constraints restrict the specific types that a developer can substitute for a generic type parameter `<T>`.

- **The Problem:** If you write a generic method `void PrintId<T>(T item)`, you cannot call `item.Id`. The compiler has no idea what `T` is, so it assumes `T` is a base `System.Object`, which has no `Id` property.
- **The Solution:** You use the `where` keyword to enforce a contract on `T`.
- **Example:** `public void PrintId<T>(T item) where T : IEntity`. Now the compiler mathematically guarantees that whatever `T` is passed in, it implements the `IEntity` interface, allowing you to safely call `item.Id`.

</td></tr>
</table>

<a id="q-6-33"></a>

<table>
<tr><th align="left">6.33 Types of generic constraints in C#</th></tr>
<tr><td>

| Constraint | Syntax | Architectural Meaning |
|---|---|---|
| **Class (Reference Type)** | `where T : class` | `T` must be a class, interface, delegate, or array. It cannot be an `int` or `struct`. |
| **Struct (Value Type)** | `where T : struct` | `T` must be a non-nullable value type. |
| **Interface/Base Class** | `where T : IMyInterface` | `T` must implement the specified interface or derive from the specified base class. |
| **Parameterless Constructor**| `where T : new()` | `T` must have a public parameterless constructor (allowing the generic class to call `new T()`). |
| **Not Null** (C# 8.0) | `where T : notnull` | `T` cannot be a nullable reference type or `Nullable<T>`. |

</td></tr>
</table>

<a id="q-6-34"></a>

<table>
<tr><th align="left">6.34 Difference between covariance, contravariance, and invariance</th></tr>
<tr><td>

These concepts dictate how generic types handle inheritance hierarchies.

- **Invariance (Exact Match):** You must use the *exact* generic type. A `List<string>` is **not** a `List<object>`. You cannot assign one to the other, even though string inherits from object.
- **Covariance (`out`):** Preserves assignment compatibility. You can assign a generic of a *derived* type to a generic of a *base* type. 
  - *Example:* `IEnumerable<object> list = new List<string>();`. This is allowed because the `IEnumerable` interface is marked with the `out` keyword (`IEnumerable<out T>`), meaning it only *outputs* data. If you ask for an object, and it gives you a string, that is perfectly safe.
- **Contravariance (`in`):** Reverses assignment compatibility. You can assign a generic of a *base* type to a generic of a *derived* type.
  - *Example:* `Action<string> action = new Action<object>(...);`. This is allowed because `Action` is marked with the `in` keyword (`Action<in T>`), meaning it only *inputs/consumes* data. If the original action knows how to consume any `object`, it can certainly consume a `string`.

</td></tr>
</table>

<a id="q-6-35"></a>

<table>
<tr><th align="left">6.35 Where are covariance and contravariance used in .NET?</th></tr>
<tr><td>

- **Covariance (`out T`):** Used exclusively in interfaces that *return* data. The most famous example is `IEnumerable<out T>`. You can safely iterate over a list of strings and assign them to an `object` variable.
- **Contravariance (`in T`):** Used exclusively in interfaces/delegates that *consume* data. `IComparer<in T>` or `Action<in T>`. If you have a custom comparer that can compare any `object`, it can safely be passed into a method that sorts a `string` array.

</td></tr>
</table>

<a id="q-6-36"></a>

<table>
<tr><th align="left">6.36 What is boxing and unboxing?</th></tr>
<tr><td>

**Boxing** is the process of converting a value type (like an `int` or `struct` on the Stack) to a reference type (`object` or an interface on the Heap). **Unboxing** is the reverse process: extracting the value type from the object.

- **Boxing Example:** `int i = 123; object o = i;` (Implicit cast). The CLR takes the integer from the stack and wraps it inside a newly allocated `System.Object` on the managed heap.
- **Unboxing Example:** `int j = (int)o;` (Explicit cast). The CLR verifies the type inside the object, extracts the raw integer value from the heap, and pushes it back onto the stack.

</td></tr>
</table>

<a id="q-6-37"></a>

<table>
<tr><th align="left">6.37 What happens internally during boxing and unboxing?</th></tr>
<tr><td>

Understanding this process exposes why legacy APIs (`ArrayList`, `DataRow`) cause massive performance issues.

**Internals of Boxing:**
1. The CLR allocates memory on the Managed Heap. The size allocated is the size of the value type *plus* two reference type overhead pointers (a sync block index and a type object pointer).
2. The value on the stack is bit-wise copied into the newly allocated heap memory.
3. The memory address (reference) of the heap object is returned and stored on the stack.

**Internals of Unboxing:**
1. The CLR checks if the object reference is null (throws `NullReferenceException` if so).
2. The CLR checks if the boxed object actually matches the type you are trying to unbox it into (throws `InvalidCastException` if it doesn't match perfectly).
3. The data is copied from the heap back to the local stack variable.

</td></tr>
</table>

<a id="q-6-38"></a>

<table>
<tr><th align="left">6.38 Why are boxing and unboxing expensive?</th></tr>
<tr><td>

**The Performance Impact:**
Boxing forces heap allocation. If boxing happens inside a tight data-processing loop (e.g., thousands of times a second), it creates intense **Garbage Collection (GC) pressure**. The GC has to frequently freeze the application to clean up these thousands of short-lived boxed objects, causing micro-stutters and severe CPU overhead. Always use Generics (`List<int>`) to completely prevent boxing.

</td></tr>
</table>

<a id="q-6-39"></a>

<table>
<tr><th align="left">6.39 What are nullable types in C#?</th></tr>
<tr><td>

Value types (like `int`, `bool`, `DateTime`) inherently cannot be null because they must contain actual data on the stack. **Nullable types** allow you to assign a `null` state to a value type.

- **Syntax:** You append a `?` to the value type (e.g., `int? age = null;`).
- **Database Mapping:** They are absolutely essential for mapping database columns that allow NULL values to C# properties (e.g., a `DATETIME NULL` column maps directly to `DateTime?`).

</td></tr>
</table>

<a id="q-6-40"></a>

<table>
<tr><th align="left">6.40 How does `Nullable<T>` work internally?</th></tr>
<tr><td>

- **It's Just a Struct:** `int?` is syntactic sugar for the generic `System.Nullable<int>` struct.
- **The Core Fields:** Under the hood, `Nullable<T>` is a struct that contains exactly two fields:
  1. `bool HasValue` (Is it logically null or not?)
  2. `T Value` (The actual data, if it exists).
- **Behavior:** When you check `if (age.HasValue)`, you are simply checking the boolean. If you try to access `age.Value` when `HasValue` is false, the CLR throws an `InvalidOperationException`.

</td></tr>
</table>

<a id="q-6-41"></a>

<table>
<tr><th align="left">6.41 Where are nullable types stored in memory?</th></tr>
<tr><td>

This is a very common trick question in senior interviews to test your understanding of memory.

- **The Stack:** Because `Nullable<T>` is fundamentally a `struct` (a value type), **it is stored entirely on the stack** (or inline within a heap object).
- **The Illusion:** Even though it can logically equal `null` in code, there is no actual "null reference pointer" pointing nowhere. The memory block is fully allocated on the stack; the `HasValue` boolean is just set to `false`.

</td></tr>
</table>

<a id="q-6-42"></a>

<table>
<tr><th align="left">6.42 Difference between `const`, `readonly`, and `static readonly`</th></tr>
<tr><td>

| Feature | `const` | `readonly` | `static readonly` |
|---|---|---|---|
| **Evaluation Time** | Compile-time. | Run-time (when the instance is constructed). | Run-time (when the type is loaded into the AppDomain). |
| **Assignment** | Must be hardcoded exactly at the point of declaration. | Can be assigned at declaration OR inside the instance constructor. | Can be assigned at declaration OR inside the static constructor. |
| **Memory Allocation**| No memory allocated at runtime. The compiler literally hardcodes the raw value everywhere it is referenced. | Stored on the Heap as part of the object instance. | Stored on the High-Frequency Heap once per AppDomain. |
| **The Versioning Trap** | If a `const` in Assembly A is used by Assembly B, the compiler hardcodes A's value into B. If A is updated and recompiled (but B is not), B will still execute using the *old* hardcoded value. | No versioning issues. Safe. | No versioning issues. The gold standard for cross-assembly public constants. |

</td></tr>
</table>

<a id="q-6-43"></a>

<table>
<tr><th align="left">6.43 When should you use `const` vs `readonly`?</th></tr>
<tr><td>

- **Use `const` exclusively for:** Mathematical absolutes that will never change in the history of the universe (e.g., `Math.PI`, `DaysInAWeek = 7`).
- **Use `readonly` for:** Values that are constant for the life of an application run, but might change between deployments, or values that require complex initialization (e.g., configuration settings, instances of `HttpClient`, or injected DI dependencies).
- **Architectural Rule:** If you are exposing a public constant from a library, almost always use `static readonly` to avoid the severe assembly versioning trap of `const`.

</td></tr>
</table>

<a id="q-6-44"></a>

<table>
<tr><th align="left">6.44 Difference between `ref`, `out`, and `in` parameters</th></tr>
<tr><td>

By default, method arguments are passed by value. These keywords forcefully alter the CLR memory mechanics, forcing them to be passed by reference pointer.

| Keyword | Initialization Rule | Architectural Purpose | Memory Mechanism |
|---|---|---|---|
| **`ref`** | Must be initialized **before** being passed. | Two-way data mutation. The method reads the original variable and modifies it. | Passes a direct memory pointer to the original stack variable. |
| **`out`** | Does **not** need to be initialized before passing. | One-way data output. The method **must** assign a value before returning. | Passes a direct memory pointer. Extensively used in `TryParse` patterns to return a boolean status and the parsed value simultaneously. |
| **`in`** | Must be initialized **before** passing. | Read-only reference optimization. The method reads the variable but **cannot** modify it. | Passes a memory pointer. Used strictly for extreme performance optimization to prevent copying massive structs on the stack. |

</td></tr>
</table>

<a id="q-6-45"></a>

<table>
<tr><th align="left">6.45 What are method parameters and argument passing mechanisms?</th></tr>
<tr><td>

- **Pass by Value (The Default):** The CLR pushes a *copy* of the variable onto the stack for the method to use.
  - *Value Types:* A full bit-wise copy of the data is placed on the stack. Changing the parameter inside the method has zero effect on the caller's original data.
  - *Reference Types:* A copy of the *reference pointer* is placed on the stack. Changing the *properties* of the object affects the original. However, if you reassign the variable to a entirely `new` object, you only overwrite the local copy of the pointer; the caller's original pointer remains unchanged.
- **Pass by Reference (`ref`/`out`):** The CLR passes the exact memory address of the original variable. Reassigning a reference type variable to a `new` object *will* forcibly alter the caller's pointer.

</td></tr>
</table>

<a id="q-6-46"></a>

<table>
<tr><th align="left">6.46 How do methods work internally in .NET?</th></tr>
<tr><td>

- **IL Code:** When compiled, methods become blocks of Intermediate Language (IL) instructions stored in the assembly's metadata.
- **The Method Table:** Every type loaded into the AppDomain has a Method Table created by the CLR. It contains an array of memory addresses pointing to the executable code for each method the type defines.
- **JIT Compilation:** The first time a method is called, the JIT (Just-In-Time) compiler reads the IL, compiles it into native CPU machine instructions, and updates the Method Table to point directly to this new native machine code. Subsequent calls bypass the JIT entirely and execute the native code directly.

</td></tr>
</table>

<a id="q-6-47"></a>

<table>
<tr><th align="left">6.47 What happens under the hood when a method is called?</th></tr>
<tr><td>

1. **Prologue:** The CPU pushes the current execution address (the return address) onto the Thread Stack.
2. **Arguments:** The caller pushes the method arguments onto the stack (or into CPU registers). If it's an instance method, a hidden `this` pointer is also silently pushed.
3. **Jump:** The CPU instruction pointer reads the native code address from the type's Method Table and jumps to it.
4. **Execution:** Local variables are allocated on the stack. The method executes.
5. **Epilogue:** The method places the return value in a specific CPU register, pops the local variables off the stack, and jumps back to the original return address saved in Step 1.

</td></tr>
</table>

<a id="q-6-48"></a>

<table>
<tr><th align="left">6.48 What is the purpose of the `yield` statement?</th></tr>
<tr><td>

The `yield` keyword allows you to perform custom, stateful iteration over a collection without having to create a temporary list in memory. This is the cornerstone of **Deferred Execution** in LINQ.

- **`yield return`:** Returns one element at a time to the caller and pauses the method's execution. When the caller requests the next element (e.g., in a `foreach` loop), the method resumes execution exactly where it left off.
- **`yield break`:** Immediately terminates the iteration.
- **Architectural Benefit (Memory Efficiency):** It prevents loading millions of records into the heap at once. If you need to search a massive 5GB log file, `yield` allows you to read, process, and garbage-collect one single line at a time, keeping your application's memory footprint near zero.

</td></tr>
</table>

<a id="q-6-49"></a>

<table>
<tr><th align="left">6.49 How do iterators work internally in C#?</th></tr>
<tr><td>

The CLR does not natively understand `yield`. It is purely syntactic sugar provided by the C# compiler.

- **The State Machine:** When the compiler sees a method returning `IEnumerable<T>` and containing `yield`, it completely rewrites the method into a hidden, private class that implements the `IEnumerator<T>` interface.
- **State Tracking:** This hidden class contains an integer `_state` variable and holds all the local variables of the method as class fields (so they survive between iterations).
- **Execution:** Every time `MoveNext()` is called by the `foreach` loop, the state machine uses a `switch` statement based on `_state` to jump to the correct block of code, execute until the next `yield return`, update the `_state`, and pause again.

</td></tr>
</table>

<a id="q-6-50"></a>

<table>
<tr><th align="left">6.50 Difference between `==`, `Equals()`, and `String.Compare()` in C#</th></tr>
<tr><td>

| Method | Behavior | Primary Use Case |
|---|---|---|
| **`==` operator** | For strings, it checks **Value Equality** (calls `Equals` under the hood). For other reference types, checks **Reference Equality**. | Quick equality checks in business logic (`if (status == "Open")`). |
| **`Equals()`** | Virtual method inherited from `System.Object`. Usually overridden to check **Value Equality** (like in strings and records). | Determining if two distinct objects represent the exact same data. |
| **`String.Compare()`** | Returns an integer (-1, 0, 1) indicating relative position in the sort order. Allows specifying culture and case sensitivity. | Sorting algorithms or culturally-aware alphabetizing. |

</td></tr>
</table>

<a id="q-6-51"></a>

<table>
<tr><th align="left">6.51 Difference between `String` and `StringBuilder`</th></tr>
<tr><td>

- **`String`:** Immutable. Every time you concatenate or modify a string (`str += "a"`), the CLR allocates a brand new memory block on the heap, copies the old string, adds the new character, and abandons the old memory to the Garbage Collector.
- **`StringBuilder`:** Mutable. It maintains an internal character array buffer. When you call `.Append()`, it simply inserts characters into the existing buffer. It only allocates new heap memory when the buffer fills up and needs to be resized (doubling the capacity each time).
- **Architectural Rule:** Use `StringBuilder` when performing multiple (usually >3) concatenations in a tight loop or when constructing long documents (like HTML/XML). Use standard `string` operations for simple, one-off concatenations.

</td></tr>
</table>

<a id="q-6-52"></a>

<table>
<tr><th align="left">6.52 Why is `string` a reference type but behaves like a value type?</th></tr>
<tr><td>

It is natively a reference type allocated on the Managed Heap, but Microsoft engineered it with "Value Semantics" to make it safe and predictable.

- **The Behavior:** When you pass a string to a method and modify the parameter, the original caller's string does not change. When you use the `==` operator, it compares the actual text characters, not the underlying heap memory addresses.
- **The Reason:** This behavior exists solely because strings are mathematically **immutable** and the `==` operator is explicitly overloaded by Microsoft's framework code to compare characters. 
- **The Process:** When you "modify" the passed string parameter, you aren't actually mutating the original heap object; you are instantly creating a *brand new* heap object and pointing your local variable to it, leaving the original caller's string untouched.

</td></tr>
</table>

<a id="q-6-53"></a>

<table>
<tr><th align="left">6.53 Difference between `string.IsNullOrEmpty()` and `string.IsNullOrWhiteSpace()`</th></tr>
<tr><td>

- **`IsNullOrEmpty()`:** Returns true only if the string reference is `null` or exactly `""` (Length == 0). A string containing `"   "` (three spaces) will return **false**.
- **`IsNullOrWhiteSpace()`:** Returns true if the string is `null`, `""`, or contains *only* whitespace characters (spaces, tabs, newlines).
- **Architectural Best Practice:** In 99% of web applications (like validating user input from a text box or API payload), you should default to `IsNullOrWhiteSpace()` to prevent users from bypassing validation logic simply by hitting the spacebar.

</td></tr>
</table>

<a id="q-6-54"></a>

<table>
<tr><th align="left">6.54 Why are strings immutable in C#?</th></tr>
<tr><td>

Strings are immutable for extreme memory performance, security, and thread-safety.

- **String Interning (Memory):** Because they are immutable, the CLR can safely cache identical strings in a global memory map called the "Intern Pool". If you declare `"hello"` in ten different places in your codebase, only *one* `"hello"` object actually exists on the heap. All ten variables point to the exact same memory address.
- **Thread Safety:** You can pass a string across hundreds of concurrent background threads simultaneously without ever needing a `lock` statement. It is physically impossible for one thread to corrupt the string while another is reading it.
- **Security & Hashing:** Strings are extensively used as Dictionary keys or Database Connection Strings. If a string were mutable, a malicious thread could theoretically alter a connection string *after* security checks had passed, but *before* the SQL connection opened.

</td></tr>
</table>

<a id="q-6-55"></a>

<table>
<tr><th align="left">6.55 What are the benefits and drawbacks of immutable strings?</th></tr>
<tr><td>

- **Benefits:** Guaranteed thread-safety by default, strict security, allows massive memory optimization (via the Intern Pool), and provides highly predictable behavior when passed as method arguments.
- **Drawbacks:** Severe performance penalties and extreme Garbage Collection pressure during heavy string manipulation. Constructing a long XML document via `string +=` will generate thousands of orphaned string objects on the managed heap, destroying application throughput (which is why `StringBuilder` exists).

</td></tr>
</table>

<a id="q-6-56"></a>

<table>
<tr><th align="left">6.56 Difference between value types and reference types</th></tr>
<tr><td>

This is the most fundamental concept of CLR memory management.

| Feature | Value Types | Reference Types |
|---|---|---|
| **Memory Location** | Allocated on the **Stack** (or inline within another object). | Allocated on the **Managed Heap**. |
| **Data Storage** | The variable holds the **actual raw data**. | The variable holds a **pointer** (memory address) to the data on the heap. |
| **Copy Behavior** | When assigned to a new variable, the actual data is duplicated bit-by-bit. | When assigned to a new variable, only the pointer is copied. Both variables now point to the exact same object. |
| **Base Type** | Inherit from `System.ValueType`. | Inherit directly from `System.Object`. |
| **Examples** | `int`, `bool`, `double`, `struct`, `enum`. | `class`, `interface`, `delegate`, `string`, `object`, `record`. |

</td></tr>
</table>

<a id="q-6-57"></a>

<table>
<tr><th align="left">6.57 Difference between stack and heap memory</th></tr>
<tr><td>

| Feature | Thread Stack | Managed Heap |
|---|---|---|
| **Purpose** | Keeps track of executing code, method calls, and local variables. | Stores objects that need to outlive the method that created them. |
| **Structure** | LIFO (Last In, First Out). Highly structured and densely packed. | Unstructured pool of memory fragmented across RAM. |
| **Speed** | Extremely fast allocation and deallocation (literally just adding or subtracting from a CPU stack pointer register). | Slower allocation. Requires finding free space, zeroing memory, and updating sync blocks. |
| **Management** | Self-maintaining. Memory is freed instantly the millisecond the method returns. | Managed by the **Garbage Collector** which periodically freezes the app to scan for and clean up unreferenced objects. |

</td></tr>
</table>

<a id="q-6-58"></a>

<table>
<tr><th align="left">6.58 Where are value types and reference types stored in memory?</th></tr>
<tr><td>

- **The "Rule" (Junior Level):** Value types go on the Stack, Reference types go on the Heap. **(Warning: This is an oversimplification and often false).**
- **The Truth (Senior Level):** 
  - **Reference Types** are *always* stored on the Heap. The variable holding the pointer to them is stored on the Stack.
  - **Value Types** are stored *wherever they are declared*. 
    - If a struct `Point` is a local variable inside a method, it is allocated on the Stack.
    - If a struct `Point` is a property inside a `class User`, it is stored completely **inline** within the `User` object's memory block on the **Heap**.

</td></tr>
</table>

<a id="q-6-59"></a>

<table>
<tr><th align="left">6.59 How does memory allocation work for structs and classes?</th></tr>
<tr><td>

- **Classes (Heap Allocation):** The CLR calculates the total size of the class fields, plus an unavoidable **8 bytes of overhead** (the Sync Block Index and the Type Handle). It finds a free, contiguous block of memory on the Managed Heap, initializes all bytes to zero, calls the constructor, and returns the pointer to the stack.
- **Structs (Stack/Inline Allocation):** The CLR simply increments the Stack Pointer by the exact byte size of the struct. There is **zero object overhead**. The memory is immediately available and is discarded deterministically the exact moment the stack frame pops (when the method returns).

</td></tr>
</table>

<a id="q-6-60"></a>

<table>
<tr><th align="left">6.60 What is thread safety?</th></tr>
<tr><td>

**Thread safety** is the architectural guarantee that a piece of code or an object will behave correctly and maintain absolute data integrity when accessed by multiple threads simultaneously.

- **The Goal:** Preventing race conditions, data corruption, and deadlocks.
- **How to Achieve It:**
  - **Immutability:** The easiest and safest way. If state literally cannot be changed, any number of threads can read it safely without locks (e.g., `string`, `record`).
  - **Statelessness:** Methods that only operate on local variables passed directly into them (like most pure static utility methods).
  - **Synchronization:** Using primitive locks (`lock`, `SemaphoreSlim`, `Mutex`) to force threads to queue up and access shared mutable state sequentially.

</td></tr>
</table>

<a id="q-6-61"></a>

<table>
<tr><th align="left">6.61 What problems occur in multithreaded applications?</th></tr>
<tr><td>

- **Race Conditions:** Two threads try to read, modify, and write the same variable at the exact same millisecond. Thread A overwrites Thread B's work, causing silent data loss (e.g., an e-commerce inventory counter decrementing by 1 instead of 2).
- **Deadlocks:** Thread A locks Resource X and waits for Resource Y. Thread B locks Resource Y and waits for Resource X. Both threads freeze forever, eventually bringing the server to a halt.
- **Starvation:** A low-priority thread never gets CPU time because high-priority threads constantly monopolize the lock or the processor.

</td></tr>
</table>

<a id="q-6-62"></a>

<table>
<tr><th align="left">6.62 Difference between synchronization and thread safety</th></tr>
<tr><td>

- **Thread Safety** is the *end goal* or the *characteristic* of the code architecture (e.g., "This connection pool class is thread-safe").
- **Synchronization** is the *mechanical tool* used to achieve thread safety (e.g., "I used synchronization primitives like a `lock` statement to make this class thread-safe"). Not all thread-safe code requires synchronization (e.g., immutable objects are thread-safe inherently).

</td></tr>
</table>

<a id="q-6-63"></a>

<table>
<tr><th align="left">6.63 What is the `lock` statement?</th></tr>
<tr><td>

The `lock` statement in C# is a synchronization mechanism that ensures only one thread can execute a specific "Critical Section" of code at a time.

- **The Syntax:** `lock (_syncObject) { // Critical Section }`
- **The Concept:** When Thread A reaches the `lock`, it acquires exclusive access to `_syncObject`. If Thread B arrives, it is blocked and put to sleep by the OS until Thread A releases the lock, preventing race conditions.
- **Syntactic Sugar:** Under the hood, `lock` is compiled into a strict `try...finally` block using `System.Threading.Monitor.Enter()` and `Monitor.Exit()`, absolutely ensuring the lock is always released even if an unhandled exception is thrown inside the block.

</td></tr>
</table>

<a id="q-6-64"></a>

<table>
<tr><th align="left">6.64 How does locking work internally in .NET?</th></tr>
<tr><td>

- **The Sync Block Index:** Every single object allocated on the Managed Heap contains a hidden 4-byte header called the Sync Block Index.
- **The Monitor:** When you call `lock(obj)`, the CLR looks at `obj`'s Sync Block Index. If it's zero, the CLR points it to a free Sync Block structure in an internal thread-tracking table. 
- **The Lock:** The Sync Block records which exact Thread ID currently owns the object. Any other thread checking that Sync Block will see it is "owned" and will yield its CPU time until the owning thread clears the Sync Block.

</td></tr>
</table>

<a id="q-6-65"></a>

<table>
<tr><th align="left">6.65 What problems does locking solve?</th></tr>
<tr><td>

- **Solves Race Conditions:** By ensuring atomicity. If updating a bank account balance takes 3 CPU instructions (Read, Add, Write), a lock ensures all 3 instructions execute completely uninterrupted by other threads.
- **Prevents Dirty Reads:** Ensures that a thread attempting to read a complex object doesn't read it while it's in a partially-updated, invalid state.

</td></tr>
</table>

<a id="q-6-66"></a>

<table>
<tr><th align="left">6.66 What is deadlock and how can it be avoided?</th></tr>
<tr><td>

A **deadlock** occurs when two or more threads are permanently blocked, each waiting for a lock currently held by the other.

- **The Scenario:** Thread 1 locks object A, needs object B. Thread 2 locks object B, needs object A. Both wait indefinitely.
- **How to Avoid It (Architectural Rules):**
  1. **Lock Ordering:** Always acquire locks in the exact same predefined hierarchical order across the entire application.
  2. **Timeouts:** Never wait infinitely. Use `Monitor.TryEnter(obj, TimeSpan)` to attempt a lock. If it fails after 5 seconds, back off, release your current locks, and try again later.
  3. **Avoid Nested Locks:** Design the architecture so a thread only ever needs to hold one single lock at a time.

</td></tr>
</table>

<a id="q-6-67"></a>

<table>
<tr><th align="left">6.67 Difference between synchronous and asynchronous programming</th></tr>
<tr><td>

- **Synchronous:** Code executes top-to-bottom. If a line of code initiates a network request, the entire Thread stops (blocks) and waits, doing absolutely nothing until the response arrives. In a web server, this burns a valuable ThreadPool thread for no reason.
- **Asynchronous:** When an I/O operation (like a database query) is initiated, the thread does *not* wait. The thread is immediately released back to the ThreadPool to handle other incoming web requests. Once the network hardware finishes the request, an I/O Completion Port (IOCP) signals the ThreadPool to grab a free thread and resume executing the rest of the code.

</td></tr>
</table>

<a id="q-6-68"></a>

<table>
<tr><th align="left">6.68 What is async/await?</th></tr>
<tr><td>

`async` and `await` are C# keywords introduced to make writing asynchronous code look and feel exactly like writing synchronous code, hiding the complex callback logic.

- **`async` Keyword:** Used in a method signature. It does *not* magically make the method run on a background thread. Its only purpose is to enable the use of the `await` keyword inside that method, and to tell the compiler to build a state machine.
- **`await` Keyword:** This is where the magic happens. It tells the compiler: "Initiate this asynchronous task. Do *not* block the current thread. Return control to the caller. When the task finishes, pick up where you left off right here."

</td></tr>
</table>

<a id="q-6-69"></a>

<table>
<tr><th align="left">6.69 How does async/await work internally?</th></tr>
<tr><td>

This is one of the most important concepts to master for senior .NET roles.

- **The State Machine:** Just like `yield`, the CLR has no concept of `async/await`. The C# compiler rewrites your async method into a private struct that implements `IAsyncStateMachine`.
- **The Process:**
  1. The state machine begins execution synchronously until it hits the first `await`.
  2. The `await` initiates the I/O-bound task (e.g., sending an HTTP request). 
  3. Crucially, the method *returns* immediately. The thread that was executing the method goes back to the ThreadPool.
  4. When the OS finishes the network request, an I/O Completion Port (IOCP) interrupts the CPU and signals the .NET ThreadPool.
  5. The ThreadPool grabs any free thread, restores the state machine's local variables, and executes the remainder of the method.

</td></tr>
</table>

<a id="q-6-70"></a>

<table>
<tr><th align="left">6.70 What is Task in .NET?</th></tr>
<tr><td>

A **`Task`** represents an asynchronous operation that may or may not have completed yet. It is the core of the Task Parallel Library (TPL).

- **Concept:** It is essentially a "promise" or a "future". It is an object that encapsulates the state of the operation (Running, RanToCompletion, Faulted), any exceptions that occurred, and the eventual return value (`Task<T>`).
- **Memory Impact (`Task` vs `ValueTask`):** `Task` is a class, meaning it is allocated on the managed heap. If you have an async method that frequently returns synchronously (e.g., checking a cache before making an HTTP call), allocating a new `Task` object on the heap every time creates severe GC pressure. In high-performance scenarios, .NET provides `ValueTask` (a struct) to avoid this heap allocation completely.

</td></tr>
</table>

<a id="q-6-71"></a>

<table>
<tr><th align="left">6.71 What is TAP (Task-based Asynchronous Pattern)?</th></tr>
<tr><td>

**TAP** is the standard Microsoft architectural pattern for writing asynchronous code in modern .NET.

- **The Rules of TAP:**
  1. Asynchronous methods must return a `Task`, `Task<T>`, `ValueTask`, or `ValueTask<T>`.
  2. Method names must be explicitly suffixed with the word "Async" (e.g., `GetUserDataAsync`).
  3. Methods should accept a `CancellationToken` as their final parameter to support graceful timeouts and cancellation.
- **Why it matters:** It unifies all asynchronous programming in .NET under one highly predictable API, completely replacing older legacy patterns like APM (`IAsyncResult`/`Begin`/`End`) and EAP (Event-based).

</td></tr>
</table>

<a id="q-6-72"></a>

<table>
<tr><th align="left">6.72 What is the ThreadPool in .NET?</th></tr>
<tr><td>

The **ThreadPool** is a background process manager that maintains a pool of pre-created, idle worker threads ready to execute tasks instantly.

- **The Problem it Solves:** Creating a brand new OS thread is extremely slow and violently expensive (allocating ~1MB of memory for the thread's stack, plus severe CPU Context Switching overhead). If a web server created a new physical thread for every incoming HTTP request, it would crash via `OutOfMemoryException` instantly under load.
- **How it Works:** The ThreadPool creates a small baseline of threads. When a task arrives, the ThreadPool assigns it to an idle thread. When the task finishes, the thread is *not* destroyed; it is wiped clean and returned to the pool to be reused immediately.

</td></tr>
</table>

<a id="q-6-73"></a>

<table>
<tr><th align="left">6.73 Difference between `Task.Run()` and creating threads manually</th></tr>
<tr><td>

- **Manual Threads (`new Thread()`):** Forces the OS to allocate a brand new dedicated thread and 1MB stack immediately. It is slow to start, cannot return a value easily, and requires manual `.Join()` blocking. **Architectural Rule:** You should almost never use `new Thread()` in modern C#.
- **`Task.Run()`:** Queues the work to the managed **ThreadPool**. It tells the pool: "Whenever a worker thread is free, execute this code." It is vastly more efficient, starts almost instantly, and returns a `Task` object so you can gracefully `await` its completion.

</td></tr>
</table>

<a id="q-6-74"></a>

<table>
<tr><th align="left">6.74 Difference between concurrency and parallelism</th></tr>
<tr><td>

- **Concurrency:** Dealing with multiple tasks at once through interleaved execution. Using `async/await` allows a *single* ThreadPool thread to concurrently handle hundreds of web requests by rapidly switching between them while waiting for database queries to return.
- **Parallelism:** Doing multiple tasks at the exact same physical millisecond. It strictly requires multiple CPU cores. Using `Parallel.ForEach` to calculate millions of prime numbers spread evenly across 8 physical CPU cores is true parallelism.

</td></tr>
</table>

<a id="q-6-75"></a>

<table>
<tr><th align="left">6.75 What is `SynchronizationContext`?</th></tr>
<tr><td>

The `SynchronizationContext` is an abstraction that represents the environment or "context" in which code is currently running.

- **The Concept:** When you `await` a task, the default behavior is to explicitly capture the current `SynchronizationContext`. When the task finishes, the state machine forces the continuation (the remainder of the method) to be posted back to that exact same context.
- **UI Frameworks:** In WPF or WinForms, the context is the single UI thread. If you `await` a network call, the rest of the method *must* resume on the UI thread, otherwise it is physically impossible to update UI controls (like a text box) without throwing a cross-thread exception.
- **ASP.NET Core (The Game Changer):** Modern ASP.NET Core **completely removed** the `SynchronizationContext`. This means continuations just run on whatever random ThreadPool thread is available next. This architectural decision massively improved web server throughput and eliminated thousands of legacy deadlock scenarios.

</td></tr>
</table>

<a id="q-6-76"></a>

<table>
<tr><th align="left">6.76 What is `ConfigureAwait(false)` and when should you use it?</th></tr>
<tr><td>

- **The Purpose:** `ConfigureAwait(false)` explicitly commands the `await` keyword *not* to capture the current `SynchronizationContext`. It tells the state machine: "When this task finishes, just resume the rest of the method on any random ThreadPool thread."
- **When to use it:** You must use it on almost every single `await` call inside reusable **Class Libraries** or background infrastructure services.
- **Why use it:** 
  1. **Performance:** It avoids the CPU overhead of queueing the continuation back onto the original locked context.
  2. **Deadlock Prevention:** In older ASP.NET (Framework) or UI apps, if the calling code blocks synchronously (via `.Result` or `.Wait()`), capturing the context will cause a permanent application deadlock.

</td></tr>
</table>

<a id="q-6-77"></a>

<table>
<tr><th align="left">6.77 Difference between `Task.WhenAll()` and `Task.WhenAny()`</th></tr>
<tr><td>

- **`Task.WhenAll()` (Fan-Out/Fan-In):** Takes an array of Tasks. It returns a single new Task that completes only when **all** the provided tasks have finished. It is the primary architectural pattern to execute multiple asynchronous I/O operations concurrently (e.g., fetching data from 3 different microservices simultaneously).
- **`Task.WhenAny()` (Redundancy):** Takes an array of Tasks. It returns a single new Task that completes the exact millisecond that the **fastest** of the provided tasks finishes. Often used for redundancy (querying 3 mirrored servers and taking the first response to arrive) or implementing custom timeouts.

</td></tr>
</table>

<a id="q-6-78"></a>

<table>
<tr><th align="left">6.78 How are exceptions handled in async/await?</th></tr>
<tr><td>

- **Standard Try/Catch:** You handle them exactly like synchronous code by wrapping the `await` call in a standard `try/catch` block.
- **The State Machine Magic:** When an exception is thrown inside an async method, it is caught by the compiler-generated state machine and placed inside the returned `Task` object (setting its state to `Faulted`). When you `await` that `Task`, the state machine unpacks the exception and re-throws it, perfectly preserving the original stack trace.
- **`Task.WhenAll` Exceptions:** If multiple tasks throw exceptions concurrently, `WhenAll` bundles them into an `AggregateException`. However, if you `await Task.WhenAll()`, the `await` keyword will only unwrap and throw the *first* exception it encounters. To see all of them, you must catch `Exception` and manually inspect `task.Exception.InnerExceptions`.

</td></tr>
</table>

<a id="q-6-79"></a>

<table>
<tr><th align="left">6.79 Why should async methods avoid `async void`?</th></tr>
<tr><td>

- **The Core Rule:** Async methods must almost always return `Task`, `Task<T>`, or `ValueTask`. Returning `void` completely breaks the asynchronous flow.
- **Process Crashing:** If an exception is thrown inside an `async void` method, it cannot be caught by a calling `try/catch` block because there is no `Task` object returned to hold the exception. It escapes the call stack and will immediately crash the entire application AppDomain.
- **No Tracking:** The caller has absolutely no way to know when the `async void` method has finished executing. You cannot `await` it.

</td></tr>
</table>

<a id="q-6-80"></a>

<table>
<tr><th align="left">6.80 When is `async void` acceptable?</th></tr>
<tr><td>

- **The Only Exception:** The **only** valid architectural use case for `async void` is **Event Handlers** (like a button click event in a WPF UI application). 
- **The Reason:** Event handler delegates (like `EventHandler`) have a rigid signature that strictly requires a `void` return type. Therefore, you are forced to use `async void Button_Click(object sender, EventArgs e)` to use `await` inside the click handler.

</td></tr>
</table>

<a id="q-6-81"></a>

<table>
<tr><th align="left">6.81 What are exceptions in C#?</th></tr>
<tr><td>

**Exceptions** are objects that represent an unexpected error or violation of rules that occurs during application execution.

- **The Hierarchy:** All exceptions inherit from the base `System.Exception` class. 
- **The Disruption:** When an exception is thrown, the normal top-to-bottom flow of execution stops instantly. The CLR searches up the Thread Stack to find the nearest `catch` block that can handle that specific type of exception.
- **The Cost:** Throwing an exception is computationally expensive because the CLR has to freeze the thread, capture the stack trace, and instantiate an exception object on the heap.

</td></tr>
</table>

<a id="q-6-82"></a>

<table>
<tr><th align="left">6.82 Explain `try`, `catch`, and `finally`</th></tr>
<tr><td>

- **`try` block:** Contains the "risky" code that might throw an exception.
- **`catch` block:** Contains the code that executes if (and only if) an exception of a matching type is thrown inside the `try` block. You can stack multiple `catch` blocks to handle different types of errors sequentially.
- **`finally` block:** Contains cleanup code that is **absolutely guaranteed** to execute regardless of whether an exception was thrown or if the method exited cleanly. It is primarily used to release unmanaged resources (closing database connections).

</td></tr>
</table>

<a id="q-6-83"></a>

<table>
<tr><th align="left">6.83 What is the purpose of the `finally` block?</th></tr>
<tr><td>

- **Guaranteed Execution:** Code inside a `finally` block will run whether the `try` block succeeds, or a `catch` block intercepts an error, or even if the method `returns` early. (The only scenario where it skips is if the process is hard-killed via `Environment.FailFast`).
- **Resource Cleanup:** Its primary and most critical use case is to ensure that unmanaged resources (database connections, network sockets, file handles) are properly closed and released back to the OS, preventing severe memory and resource leaks.
- **Relationship to `using`:** The `using` statement in C# is literally just syntactic sugar that the compiler translates into a `try...finally` block that calls `.Dispose()` inside the `finally`.

</td></tr>
</table>

<a id="q-6-84"></a>

<table>
<tr><th align="left">6.84 Difference between `throw` and `throw ex`</th></tr>
<tr><td>

- **`throw;`** Re-throws the exact exception that was caught. It strictly preserves the original stack trace, meaning you can see exactly which line of code deep in the application initially caused the error.
- **`throw ex;`** Throws a *brand new* exception object using the `ex` variable. This completely wipes out the original stack trace. The CLR treats the line containing `throw ex;` as the absolute origin of the error.

</td></tr>
</table>

<a id="q-6-85"></a>

<table>
<tr><th align="left">6.85 Why is `throw ex` considered bad practice?</th></tr>
<tr><td>

- **Lost Telemetry:** It permanently destroys the stack trace. When you check your application logs in production (e.g., Datadog, Application Insights), you will see the error originating from the `catch` block, rather than the actual line of business logic that failed. This makes debugging nearly impossible.
- **The Solution:** Always use `throw;` to re-throw, or explicitly wrap the exception inside a new, more meaningful custom exception (e.g., `throw new DomainException("Order failed", ex);`) using the inner exception parameter.

</td></tr>
</table>

<a id="q-6-86"></a>

<table>
<tr><th align="left">6.86 What are custom exceptions?</th></tr>
<tr><td>

- **Concept:** Classes you create that inherit from `System.Exception` to represent specific business or domain errors unique to your application architecture (e.g., `InsufficientFundsException`, `UserNotFoundException`).
- **Why Use Them:** They allow calling code to write specific `catch (InsufficientFundsException)` blocks and handle business logic errors completely differently than systemic runtime errors (like `SqlException` or `NullReferenceException`).

</td></tr>
</table>

<a id="q-6-87"></a>

<table>
<tr><th align="left">6.87 How do you create custom exceptions?</th></tr>
<tr><td>

- **Inheritance:** Create a class and inherit from `System.Exception`.
- **Constructors:** By standard convention, you must implement three constructors:
  1. A parameterless constructor.
  2. A constructor taking a `string message`.
  3. A constructor taking a `string message` and an `Exception innerException` (crucial for wrapping lower-level errors).
- **Example:** `public class InvalidOrderException : Exception { public InvalidOrderException(string msg) : base(msg) {} }`

</td></tr>
</table>

<a id="q-6-88"></a>

<table>
<tr><th align="left">6.88 How does exception handling work internally in .NET?</th></tr>
<tr><td>

- **Two-Pass System:** When an exception occurs, the CLR uses a sophisticated two-pass process.
- **First Pass (Discovery):** The CLR halts execution and walks up the Thread Stack, looking for a `catch` block whose filter perfectly matches the exception type. If it reaches the top of the stack without finding one, the application is scheduled to crash.
- **Second Pass (Unwinding):** If a match is found, the CLR walks the stack a second time, systematically executing all `finally` blocks situated between the point of the throw and the matching `catch` block. This guarantees all resources are cleaned up before the error is actually handled.

</td></tr>
</table>

<a id="q-6-89"></a>

<table>
<tr><th align="left">6.89 What happens if an exception is not handled?</th></tr>
<tr><td>

- **Unhandled Exception:** It bubbles all the way up to the top of the Thread Stack.
- **AppDomain Crash:** The CLR catches it at the global level, logs it (usually to the Windows Event Viewer or console), and then immediately forcefully terminates the entire application process to prevent state corruption.
- **Global Handlers:** To prevent immediate process crashes or to log the fatal error gracefully, frameworks provide global catch-all events (e.g., `AppDomain.CurrentDomain.UnhandledException` or ASP.NET Core's Global Exception Handling Middleware).

</td></tr>
</table>

<a id="q-6-90"></a>

<table>
<tr><th align="left">6.90 Best practices for exception handling in enterprise applications</th></tr>
<tr><td>

1. **Catch Specific, Not General:** Avoid `catch (Exception ex)` unless it's at the very top architectural level (Global Middleware). Catch specific exceptions like `SqlException` so you don't accidentally swallow critical crashes like `OutOfMemoryException`.
2. **Never Swallow Exceptions:** Never write an empty `catch` block. If you catch it, you must log it or throw it.
3. **Use Global Middleware:** In ASP.NET Core APIs, centralize exception logging and HTTP 500 response generation in one single Middleware class rather than scattering redundant `try/catch` blocks in every controller.
4. **Use Result Pattern for Logic:** Do not use exceptions for normal control flow (e.g., validating a bad password or "User Not Found"). Use a `Result<T>` object or Domain Events instead. Exceptions should be strictly reserved for *exceptional*, unexpected systemic failures.

</td></tr>
</table>

<a id="q-6-91"></a>

<table>
<tr><th align="left">6.91 What is IDisposable?</th></tr>
<tr><td>

`IDisposable` is a framework interface that provides a deterministic mechanism for explicitly releasing unmanaged resources.

- **The Contract:** It contains exactly one single method: `void Dispose()`.
- **The Architectural Purpose:** The .NET Garbage Collector (GC) is non-deterministic; you never know exactly when it will wake up to clean memory. If your class holds onto a finite OS resource (like a database connection, network socket, or file handle), you cannot afford to wait for the GC. You implement `IDisposable` to allow developers to explicitly sever and release that OS resource the exact millisecond they are done with it.

</td></tr>
</table>

<a id="q-6-92"></a>

<table>
<tr><th align="left">6.92 Who calls Dispose()?</th></tr>
<tr><td>

- **The Developer:** It is the strict responsibility of the developer consuming the class to call `.Dispose()` when they are finished with the object.
- **The `using` Statement:** The safest and most common way to ensure it gets called is wrapping the object in a `using` statement, which automatically injects a `finally` block that calls `.Dispose()`.
- **Dependency Injection Container:** In modern ASP.NET Core, if an `IDisposable` object is registered as Scoped or Transient, the built-in DI container automatically calls `.Dispose()` for you the moment the HTTP request completes.

</td></tr>
</table>

<a id="q-6-93"></a>

<table>
<tr><th align="left">6.93 Difference between managed and unmanaged resources</th></tr>
<tr><td>

| Feature | Managed Resources | Unmanaged Resources |
|---|---|---|
| **Definition** | Memory and objects allocated and tracked directly by the .NET CLR. | Raw resources provided directly by the Operating System (Windows/Linux) entirely outside the CLR's control. |
| **Cleanup** | Cleaned up automatically by the Garbage Collector. | **Must** be cleaned up manually via `Dispose()` or a finalizer. |
| **Examples** | `string`, `List<T>`, custom business objects (`Order`, `User`). | File handles, Database connections (`SqlConnection`), TCP/IP Network Sockets, COM objects, Window handles. |

</td></tr>
</table>

<a id="q-6-94"></a>

<table>
<tr><th align="left">6.94 What is managed code?</th></tr>
<tr><td>

- **Definition:** Code whose entire execution lifecycle is strictly managed by the Common Language Runtime (CLR). 
- **Features:** It benefits from automatic memory management (Garbage Collection), strict type safety, automatic bounds checking (preventing buffer overflow hacks), and structured exception handling. C#, F#, and VB.NET all compile down to managed IL code.

</td></tr>
</table>

<a id="q-6-95"></a>

<table>
<tr><th align="left">6.95 What is unmanaged code?</th></tr>
<tr><td>

- **Definition:** Code that executes natively and directly on the CPU, completely outside the control and safety net of the CLR.
- **Features:** It does not have built-in Garbage Collection or strict type safety. The programmer is 100% responsible for manually allocating and freeing RAM (e.g., using `malloc` and `free` in C/C++). Memory leaks and segmentation faults are common if not handled perfectly.

</td></tr>
</table>

<a id="q-6-96"></a>

<table>
<tr><th align="left">6.96 Difference between managed and unmanaged code</th></tr>
<tr><td>

- **Execution Engine:** Managed code is executed by the CLR (via JIT compilation). Unmanaged code is executed directly by the operating system processor.
- **Security & Safety:** Managed code is heavily verified for security and type-safety before running. Unmanaged code runs with raw memory pointers, making it highly susceptible to buffer overflows and memory leaks if written poorly.
- **Interop:** You can bridge the gap and call unmanaged code (like legacy C++ DLLs or low-level Windows API functions) from managed C# code using `P/Invoke` (Platform Invocation Services) and the `[DllImport]` attribute.

</td></tr>
</table>

<a id="q-6-97"></a>

<table>
<tr><th align="left">6.97 How does the `using` statement work internally?</th></tr>
<tr><td>

- **Syntactic Sugar:** The `using` keyword is purely a C# compiler trick. The CLR runtime doesn't actually know what it is.
- **The Translation:** When the compiler sees `using (var stream = new FileStream(...)) { ... }`, it fundamentally rewrites the IL code into:
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
- **The Architectural Guarantee:** This ensures `.Dispose()` is called and the OS resource is freed even if a catastrophic exception is thrown inside the block, or a `return` statement is hit early.

</td></tr>
</table>

<a id="q-6-98"></a>

<table>
<tr><th align="left">6.98 Difference between `Dispose()` and finalizers</th></tr>
<tr><td>

| Feature | `Dispose()` | Finalizer (`~MyClass()`) |
|---|---|---|
| **Invocation** | Called explicitly and deterministically by the developer (or via the `using` statement). | Called implicitly and unpredictably by the Garbage Collector's dedicated finalizer thread before destroying the object. |
| **Architectural Purpose** | Deterministic, immediate cleanup of unmanaged resources. | A strict safety net. A "last resort" cleanup in case the developer forgot to call `Dispose()`. |
| **Performance Impact**| Extremely fast and efficient. | Severe. Objects with finalizers require **two full GC cycles** to be removed from memory (they are moved to the Finalization Queue first), temporarily keeping their entire object graph alive in memory. |

</td></tr>
</table>

<a id="q-6-99"></a>

<table>
<tr><th align="left">6.99 What is garbage collection (GC)?</th></tr>
<tr><td>

Garbage Collection (GC) is the highly-optimized automatic memory management engine in .NET.

- **The Concept:** Instead of developers manually tracking and freeing heap memory (like `free()` in C or `delete` in C++), the GC runs dynamically in the background, tracks object usage graphs, and automatically deletes objects from the Managed Heap when they are totally unreachable.
- **The Goal:** To completely eliminate memory leaks, dangling pointers, and to drastically simplify application development.

</td></tr>
</table>

<a id="q-6-100"></a>

<table>
<tr><th align="left">6.100 How does garbage collection work internally?</th></tr>
<tr><td>

- **The Generational Mark-and-Compact Algorithm:**
  1. **Pause (Stop The World):** The GC suspends all executing threads in the application (unless using Concurrent GC optimizations).
  2. **Mark (Tracing):** It builds an object graph starting from "GC Roots" (active local variables on thread stacks, static fields, and CPU registers). It traverses all active object references and "marks" them as in-use.
  3. **Sweep:** Any object sitting on the heap that was *not* marked is mathematically considered dead garbage.
  4. **Compact:** The GC deletes the dead garbage and physically shifts the surviving objects together, updating all memory pointers, to prevent memory fragmentation and ensure fast future allocations.
  5. **Resume:** Application threads are un-paused and resume execution.

</td></tr>
</table>

<a id="q-6-101"></a>

<table>
<tr><th align="left">6.101 What are GC generations?</th></tr>
<tr><td>

To optimize performance and minimize CPU pausing, the Managed Heap is divided into three Generations based on the proven premise that "new objects die quickly, and old objects live forever."

- **Generation 0 (Gen 0):** Where all newly allocated objects go (except massive arrays). The GC collects Gen 0 very frequently. It is extremely fast. If an object survives a Gen 0 collection, it is promoted to Gen 1.
- **Generation 1 (Gen 1):** A buffer between short-lived and long-lived objects. Collected less frequently. Survivors are promoted to Gen 2.
- **Generation 2 (Gen 2):** Contains long-lived objects (like DI Singletons, static data, or cached collections). Collecting Gen 2 is considered a "Full GC" and is very expensive/slow.
- **Large Object Heap (LOH):** Objects larger than 85,000 bytes bypass Gen 0 and go straight here (effectively acting as Gen 2). The LOH is rarely compacted because moving massive memory blocks takes too much CPU time.

</td></tr>
</table>

<a id="q-6-102"></a>

<table>
<tr><th align="left">6.102 Does GC run on a fixed schedule?</th></tr>
<tr><td>

- **No Schedule:** The GC is completely non-deterministic. It absolutely does not run on a timer.
- **Triggers:** It runs primarily when memory pressure demands it:
  1. When Gen 0 reaches its allocation threshold limit.
  2. When the OS signals that the machine is running low on physical RAM.
  3. When a developer explicitly calls `GC.Collect()` (which is almost always a terrible anti-pattern in production environments).

</td></tr>
</table>

<a id="q-6-103"></a>

<table>
<tr><th align="left">6.103 How does the CLR manage memory?</th></tr>
<tr><td>

- **The Process:** 
  1. **Allocation:** The CLR manages a single contiguous block of virtual memory for the Managed Heap. It maintains a NextObject pointer to the next available address. Allocating memory is blazing fast—it's essentially just adding the object byte size to the pointer.
  2. **Virtual Memory Integration:** The CLR tightly interacts with the Windows/Linux Virtual Memory manager, reserving massive segments of logical address space and only committing physical RAM hardware when actually needed.
  3. **Reclamation:** Handled entirely by the Garbage Collector's generational mark-and-compact algorithms.

</td></tr>
</table>

<a id="q-6-104"></a>

<table>
<tr><th align="left">6.104 What is CLR (Common Language Runtime)?</th></tr>
<tr><td>

The CLR is the highly-optimized virtual machine component of the .NET framework that actually manages and executes .NET programs.

- **The Concept:** It is the execution engine. Just like Java has the JVM, .NET has the CLR. 
- **Language Agnostic:** C#, F#, and VB.NET all compile down into the exact same common Intermediate Language (IL). The CLR doesn't care what language you wrote in; it only understands, optimizes, and executes IL.

</td></tr>
</table>

<a id="q-6-105"></a>

<table>
<tr><th align="left">6.105 Responsibilities of the CLR</th></tr>
<tr><td>

- **JIT Compilation:** Converting hardware-agnostic IL to highly optimized native CPU machine code dynamically.
- **Memory Management:** Managing the Thread Stacks, Managed Heap, and executing Garbage Collection.
- **Type Safety:** Enforcing strict memory boundaries and type casting rules (preventing buffer overflows).
- **Exception Handling:** Managing the structured `try/catch/finally` blocks and unwinding thread stacks during a crash.
- **Thread Management:** Managing the .NET ThreadPool and its mapping to physical OS threads.

</td></tr>
</table>

<a id="q-6-106"></a>

<table>
<tr><th align="left">6.106 How does the CLR execute C# code?</th></tr>
<tr><td>

1. **Source Code:** You write high-level C# code.
2. **Roslyn Compiler:** When you build the app, the C# compiler (Roslyn) converts your syntax into an assembly (.dll) containing **Intermediate Language (IL)** and Metadata.
3. **App Startup:** You run the app. The OS spins up a process and loads the CLR execution engine.
4. **JIT Compilation:** As the app runs, the CLR's Just-In-Time (JIT) compiler intercepts method calls, translates the IL into native machine code (highly optimized for your specific Intel/AMD/ARM processor architecture), and caches it in memory.
5. **Execution:** The CPU executes the raw native machine code.

</td></tr>
</table>

<a id="q-6-107"></a>

<table>
<tr><th align="left">6.107 How does the CLR manage application execution?</th></tr>
<tr><td>

- **AppDomains (Legacy .NET Framework):** Historically, the CLR used AppDomains to isolate multiple applications running within the exact same OS process. One AppDomain crashing theoretically wouldn't affect others.
- **AssemblyLoadContexts (Modern .NET Core/5+):** AppDomains were completely deprecated. Modern cross-platform .NET uses `AssemblyLoadContext` to provide isolation specifically for dynamically loading and unloading plugins and dependencies without the massive overhead of strict process boundaries.

</td></tr>
</table>

<a id="q-6-108"></a>

<table>
<tr><th align="left">6.108 What is JIT compilation?</th></tr>
<tr><td>

**Just-In-Time (JIT)** compilation is the process of dynamically translating Intermediate Language (IL) into native CPU machine code exactly at the millisecond it is first needed, rather than Ahead-Of-Time (AOT).

- **The Process:** When a method is called for the very first time, the JIT compiler analyzes the IL, optimizes it for the specific hardware architecture (e.g., x64 vs ARM64), compiles it to native code, and stores the native code pointer in the Method Table.
- **The Benefit:** Subsequent calls to that method bypass the JIT compiler entirely and jump directly to the native code, making execution extremely fast. It allows the exact same compiled `.dll` file to run optimally on both a Windows Server and a Linux Raspberry Pi.
- **Tiered Compilation:** Modern .NET uses Tiered JIT. It compiles code extremely quickly at low quality ("Tier 0") for fast app startup, and then slowly recompiles frequently used "hot" methods in the background ("Tier 1") with heavy, aggressive CPU optimizations.

</td></tr>
</table>

<a id="q-6-109"></a>

<table>
<tr><th align="left">6.109 Write a custom delegate and event example</th></tr>
<tr><td>

Delegates and events are the backbone of the **Observer Pattern** in .NET, allowing for loose coupling between components. Modern .NET strictly favors `EventHandler<T>` to maintain consistency.

```csharp
// 1. Define custom event data
public class OrderEventArgs : EventArgs 
{ 
    public int OrderId { get; set; } 
}

public class OrderService
{
    // 2. Use the standard EventHandler<T> delegate
    public event EventHandler<OrderEventArgs> OrderProcessed;

    public void ProcessOrder(int orderId)
    {
        Console.WriteLine($"[OrderService] Processing {orderId}...");
        
        // 3. Raise the event safely using the null-conditional operator
        // and following the 'On[EventName]' naming convention.
        OnOrderProcessed(new OrderEventArgs { OrderId = orderId });
    }

    protected virtual void OnOrderProcessed(OrderEventArgs e)
    {
        OrderProcessed?.Invoke(this, e);
    }
}

public class EmailService
{
    public void Subscribe(OrderService service)
    {
        // 4. Subscribe with a handler method
        service.OrderProcessed += HandleOrderProcessed;
    }

    private void HandleOrderProcessed(object sender, OrderEventArgs e)
    {
        Console.WriteLine($"[EmailService] Sending confirmation for {e.OrderId}");
    }
}
```

- **Architectural Reasoning:** Events provide a "publisher-subscriber" model. `OrderService` doesn't need to know `EmailService` exists; it simply broadcasts that an order was processed. This adheres to the **Open/Closed Principle**.

</td></tr>
</table>

<a id="q-6-110"></a>

<table>
<tr><th align="left">6.110 Demonstrate the difference between `throw` and `throw ex`</th></tr>
<tr><td>

Understanding the impact of re-throwing exceptions is critical for production telemetry and debugging.

```csharp
public void ProcessData()
{
    try 
    {
        PerformDatabaseOperation();
    } 
    catch (Exception ex) 
    {
        // LOGGING: Always log before re-throwing
        _logger.LogError(ex, "Database operation failed");

        // ANTI-PATTERN: Wipes the original stack trace. 
        // Production logs will show the error originated HERE, not at the actual failure line.
        // throw ex; 

        // BEST PRACTICE: Preserves the original stack trace.
        // Telemetry will correctly point to the exact line in PerformDatabaseOperation().
        throw; 
    }
}
```

- **Runtime Behavior:** `throw;` preserves the `StackTrace` property of the exception object. `throw ex;` resets the stack trace starting from the current method, making it significantly harder to find the root cause in complex call stacks.

</td></tr>
</table>

<a id="q-6-111"></a>

<table>
<tr><th align="left">6.111 Write an example using `Task.WhenAll()`</th></tr>
<tr><td>

`Task.WhenAll` is the standard for managing concurrency in I/O-bound operations. Avoid sequential execution where parallel throughput can be achieved without blocking the thread pool.

```csharp
public async Task<string[]> FetchDashboardDataAsync(IEnumerable<int> ids)
{
    // Fan-out: Create a collection of tasks without awaiting them immediately.
    // They are queued for execution (IOCP/ThreadPool) concurrently.
    var tasks = ids.Select(id => GetApiDataAsync(id));

    // Fan-in: Asynchronously wait for the completion of all tasks. 
    // If any task fails, the returned task will transition to a Faulted state.
    string[] results = await Task.WhenAll(tasks);
    
    return results;
}

private async Task<string> GetApiDataAsync(int id)
{
    await Task.Delay(500); // Simulate network latency
    return $"Data for {id}";
}
```

- **Performance Implication:** Sequential awaiting creates unnecessary latency ($T_1 + T_2 + T_n$). `Task.WhenAll` allows the runtime to manage multiple I/O requests concurrently, reducing the total time to roughly the duration of the longest task ($\max(T_1, T_2, T_n)$).

</td></tr>
</table>

<a id="q-6-112"></a>

<table>
<tr><th align="left">6.112 Explain the output of async/await execution flow snippets</th></tr>
<tr><td>

Senior engineers must understand that `await` does not stop execution—it yields it.

```csharp
public async Task EntryPoint()
{
    Console.WriteLine("1. Start");
    await ExecuteAsync();
    Console.WriteLine("4. End");
}

public async Task ExecuteAsync()
{
    Console.WriteLine("2. Inside Method");
    
    // Control returns to the caller of EntryPoint() right here
    await Task.Delay(100); 
    
    Console.WriteLine("3. After Delay");
}
```

- **Step-by-Step Flow:**
  1. **"1. Start"** prints.
  2. **ExecuteAsync** is called. **"2. Inside Method"** prints.
  3. `Task.Delay` is hit. The state machine captures local variables and returns an uncompleted Task.
  4. The thread is released to the ThreadPool. The calling thread (e.g., UI thread) remains responsive.
  5. Once the delay timer expires, a thread picks up the continuation: **"3. After Delay"** prints.
  6. The Task returned to `EntryPoint` completes, allowing it to resume: **"4. End"** prints.

**[⬆ Back to Top](#table-of-contents)**

</td></tr>
</table>

<a id="section-7"></a>
## 7. ASP.NET Core and APIs

<a id="q-7-1"></a>

<table>
<tr><th align="left">7.1 What is REST?</th></tr>
<tr><td>

**REST (Representational State Transfer)** is an architectural style for designing networked applications, most commonly web APIs.

**Interview Ready Answer:**
- **The Concept:** REST relies on a stateless, client-server, cacheable communications protocol — almost always HTTP. 
- **Resource-Based:** Instead of viewing the API as a collection of functions (e.g., `GetUserData()`), REST views the API as a collection of **Resources** (e.g., `/users/123`), manipulated via standard HTTP methods.

</td></tr>
</table>

<a id="q-7-2"></a>

<table>
<tr><th align="left">7.2 What are REST principles?</th></tr>
<tr><td>

**Interview Ready Answer:**
To be considered truly "RESTful", an API must adhere to six architectural constraints:
1. **Client-Server:** Separation of concerns between the UI/frontend and the data storage/backend.
2. **Stateless:** Every HTTP request from the client must contain all information necessary to understand and process the request. The server cannot rely on stored session state.
3. **Cacheable:** Responses must implicitly or explicitly define themselves as cacheable or not to improve performance.
4. **Uniform Interface:** A standardized way of communicating (e.g., using standard HTTP verbs and URIs).
5. **Layered System:** The client shouldn't know if it's connected directly to the end server or to an intermediary (like a load balancer or proxy).
6. **Code on Demand (Optional):** The server can temporarily extend the client's functionality by transferring executable code (e.g., JavaScript).

</td></tr>
</table>

<a id="q-7-3"></a>

<table>
<tr><th align="left">7.3 Difference between GET, POST, PUT, PATCH, and DELETE?</th></tr>
<tr><td>

**Interview Ready Answer:**
| Verb | Purpose | Idempotent |
|---|---|---|
| **GET** | Retrieves a resource without modifying anything. | Yes |
| **POST** | Creates a **new** resource. (e.g., creating a new user). | No |
| **PUT** | **Replaces** an entire existing resource. If it doesn't exist, it might create it. | Yes |
| **PATCH** | **Partially updates** an existing resource (e.g., updating just the user's email). | No (typically) |
| **DELETE**| Removes a resource. | Yes |

*(Note: "Idempotent" means making the exact same request multiple times has the exact same effect as making it once).*

</td></tr>
</table>

<a id="q-7-4"></a>

<table>
<tr><th align="left">7.4 What is IActionResult?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** `IActionResult` is an interface in ASP.NET Core that represents the result of an HTTP request.
- **Flexibility:** It allows a single controller method to return multiple different types of HTTP responses depending on business logic. For example, returning `Ok()` (200), `NotFound()` (404), or `BadRequest()` (400) from the exact same method.

</td></tr>
</table>

<a id="q-7-5"></a>

<table>
<tr><th align="left">7.5 Difference between IActionResult and ActionResult?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`IActionResult` (Interface):** Used when the method needs to return different HTTP status codes, but the *type* of data returned isn't explicitly defined in the signature. (e.g., `public IActionResult GetUser()`). This makes Swagger documentation harder.
- **`ActionResult<T>` (Class):** Introduced in ASP.NET Core 2.1. It combines the flexibility of returning HTTP status codes with a strongly-typed payload (e.g., `public ActionResult<User> GetUser()`). This allows Swagger to automatically infer that this endpoint returns a `User` object, while still allowing you to return `NotFound()`.

</td></tr>
</table>

<a id="q-7-6"></a>

<table>
<tr><th align="left">7.6 What are common HTTP status codes?</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-7-7"></a>

<table>
<tr><th align="left">7.7 Difference between authentication and authorization?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Authentication (AuthN):** Proving **who you are**. (e.g., Logging in with a username/password to get a JWT token). "I am User 123."
- **Authorization (AuthZ):** Proving **what you are allowed to do**. (e.g., Checking if User 123 has the "Admin" role before allowing them to delete a record). "Do I have permission to do this?"

</td></tr>
</table>

<a id="q-7-8"></a>

<table>
<tr><th align="left">7.8 What is JWT?</th></tr>
<tr><td>

**JSON Web Token (JWT)** is an open standard for securely transmitting information between parties as a JSON object.

**Interview Ready Answer:**
- **Structure:** It consists of three parts separated by dots: `Header.Payload.Signature`.
  - **Header:** Algorithm and token type.
  - **Payload:** The "Claims" (e.g., User ID, Roles, Expiration Time). **Note:** This is base64 encoded, *not encrypted*. Anyone can read it.
  - **Signature:** A cryptographic hash created using a secret key held only by the server. 
- **Validation:** When the client sends the JWT, the server recalculates the signature. If it matches, the server knows the token is valid and hasn't been tampered with. It enables stateless authentication because the server doesn't need to query a database to verify the user; all the proof is in the token itself.

</td></tr>
</table>

<a id="q-7-9"></a>

<table>
<tr><th align="left">7.9 Claims-based vs policy-based authorization?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Claims-based Authorization:** You check if the user has a specific piece of information (a "claim"). For example, `[Authorize(Roles = "Admin")]` or checking if the user has a "DateOfBirth" claim.
- **Policy-based Authorization:** A more modern, flexible approach. You define a "Policy" at startup (e.g., "MustBeOver18AndAdmin") which encapsulates multiple claim checks or custom logic. You then apply the policy to the controller: `[Authorize(Policy = "MustBeOver18AndAdmin")]`. It centralizes authorization logic.

</td></tr>
</table>

<a id="q-7-10"></a>

<table>
<tr><th align="left">7.10 What is middleware?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Middleware is software assembled into the application pipeline to handle HTTP requests and responses. 
- **Purpose:** Each piece of middleware can choose to pass the request to the next component in the pipeline or short-circuit it. It is used for cross-cutting concerns like Authentication, Error Handling, CORS, and Routing.

</td></tr>
</table>

<a id="q-7-11"></a>

<table>
<tr><th align="left">7.11 How does middleware pipeline work?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Pipeline:** It operates on the "Russian Doll" or "Chain of Responsibility" model. 
- **The Flow:**
  1. A request enters the pipeline.
  2. The first middleware executes. It can perform logic, then call `await next()` to invoke the next middleware.
  3. The request hits the controller (the center of the doll), generates a response.
  4. The response travels back *out* through the middleware pipeline in the reverse order.
- **Short-circuiting:** If a middleware (like Authentication) fails, it can immediately return a 401 response *without* calling `next()`, blocking the rest of the pipeline.

</td></tr>
</table>

<a id="q-7-12"></a>

<table>
<tr><th align="left">7.12 How do you structure controllers, services, and repositories?</th></tr>
<tr><td>

**Interview Ready Answer:**
This is the classic N-Tier or Clean Architecture pattern:
1. **Controllers (Presentation Layer):** Only responsible for HTTP concerns. Routing, reading parameters, and returning HTTP status codes. *No business logic.*
2. **Services (Business Layer):** Contains the core business rules. It is injected into the controller. It validates data, calculates things, and decides what to save.
3. **Repositories (Data Access Layer):** Only responsible for database interactions. Injected into the Service. It hides the ORM (like Entity Framework) or SQL queries from the rest of the app.

</td></tr>
</table>

<a id="q-7-13"></a>

<table>
<tr><th align="left">7.13 What is model binding?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Model binding is the process where ASP.NET Core automatically extracts data from an incoming HTTP request (from the URL route, query string, or JSON body) and maps it to C# objects (parameters in your controller action).
- **Example:** If a client sends JSON `{ "Name": "John" }`, and your controller takes a `User` object, model binding automatically instantiates the `User` class and sets `User.Name = "John"`.

</td></tr>
</table>

<a id="q-7-14"></a>

<table>
<tr><th align="left">7.14 What is dependency injection in ASP.NET Core?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Built-In:** ASP.NET Core has a built-in Inversion of Control (IoC) container.
- **The Concept:** Instead of a class creating its own dependencies (e.g., `var repo = new SqlRepository()`), it asks for them in its constructor (`public MyService(IRepository repo)`). The DI container automatically creates and supplies the `SqlRepository` when `MyService` is requested.
- **Lifetimes:** Dependencies are registered as `Transient` (new instance every time), `Scoped` (one instance per HTTP request), or `Singleton` (one instance forever).

</td></tr>
</table>

<a id="q-7-15"></a>

<table>
<tr><th align="left">7.15 How do you handle exceptions globally?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Old Way:** Using global exception filters (like `IExceptionFilter`).
- **The Modern Way (Middleware):** We use **Global Exception Handling Middleware**. 
  - Why? Middleware catches exceptions thrown *anywhere* in the application (even outside of controllers).
  - How? You register `app.UseExceptionHandler()` or write custom middleware that wraps the `await next()` in a `try/catch`. If an error is caught, it logs the error, hides the stack trace from the user, and standardizes the response to a `ProblemDetails` JSON object with a 500 status code.

</td></tr>
</table>

<a id="q-7-16"></a>

<table>
<tr><th align="left">7.16 What is API versioning?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Managing changes to your API over time without breaking existing client applications.
- **How to Implement:** 
  1. **URL Path:** `/api/v1/users` vs `/api/v2/users` (Most common and visible).
  2. **Query String:** `/api/users?version=2.0`.
  3. **Custom Header:** `X-API-Version: 2.0`.
  4. **Accept Header (Content Negotiation):** `Accept: application/vnd.myapi.v2+json`.

</td></tr>
</table>

<a id="q-7-17"></a>

<table>
<tr><th align="left">7.17 What is CORS?</th></tr>
<tr><td>

**CORS (Cross-Origin Resource Sharing)** is a browser security mechanism.

**Interview Ready Answer:**
- **The Problem:** By default, web browsers enforce the Same-Origin Policy. If your frontend is hosted at `frontend.com` and tries to make an AJAX request to your API at `backend.com`, the browser will block the request.
- **The Solution:** CORS allows the backend server to explicitly tell the browser, "It is safe to let `frontend.com` read my data." 
- **Implementation:** In ASP.NET Core, you configure CORS middleware in `Startup.cs` (or `Program.cs`) to add specific `Access-Control-Allow-Origin` HTTP headers to the responses.

</td></tr>
</table>

<a id="q-7-18"></a>

<table>
<tr><th align="left">7.18 What is Swagger/OpenAPI?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **OpenAPI:** A language-agnostic specification for describing RESTful APIs. It defines how to write a JSON/YAML file that explains exactly what endpoints exist, what parameters they take, and what they return.
- **Swagger:** A suite of tools (like Swashbuckle in .NET) that automatically generates the OpenAPI JSON specification directly from your C# controller code and XML comments. It also provides a built-in UI page to test the endpoints without using Postman.

</td></tr>
</table>

<a id="q-7-19"></a>

<table>
<tr><th align="left">7.19 How do microservices communicate?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Synchronous Communication:** Services call each other directly, waiting for a response. Usually done via HTTP/REST or **gRPC** (which is much faster and uses protocol buffers).
- **Asynchronous Communication (Event-Driven):** Services do not call each other directly. Instead, Service A publishes an event to a Message Broker (like RabbitMQ, Kafka, or Azure Service Bus). Service B listens to that broker, picks up the message, and processes it later. This prevents the entire system from crashing if one service goes down.

</td></tr>
</table>

<a id="q-7-20"></a>

<table>
<tr><th align="left">7.20 What is microservice architecture?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Breaking down a large, monolithic application into small, independent, loosely coupled services. 
- **Characteristics:**
  - Each service owns its own database (Database per Service pattern).
  - Each service is responsible for exactly one business domain (e.g., Orders Service, Inventory Service).
  - Services can be written in different languages and scaled independently.
- **The Trade-off:** It drastically increases deployment complexity, debugging difficulty, and network latency compared to a monolith.

</td></tr>
</table>

<a id="q-7-21"></a>

<table>
<tr><th align="left">7.21 Difference between `IActionResult` and `ActionResult<T>`</th></tr>
<tr><td>

**Interview Ready Answer:**
*(Note: Similar to Q7.5, but worth reiterating from a type-safety perspective).*
- **`IActionResult`:** Requires you to use the `[ProducesResponseType]` attribute on the controller method to tell Swagger what type of object is actually returned, because the method signature doesn't say.
- **`ActionResult<T>`:** Implicitly tells the compiler and Swagger exactly what data type is returned (`T`). You don't need `[ProducesResponseType]` for the 200 OK success case anymore, keeping the code much cleaner.

</td></tr>
</table>

<a id="q-7-22"></a>

<table>
<tr><th align="left">7.22 When should you use `ActionResult<T>`?</th></tr>
<tr><td>

**Interview Ready Answer:**
- You should use `ActionResult<T>` by default for almost all modern ASP.NET Core API endpoints. 
- It provides the perfect balance: the flexibility to return a `404 NotFound()` when data is missing, while also providing compile-time type safety and automatic OpenAPI documentation for the success payload.

</td></tr>
</table>

<a id="q-7-23"></a>

<table>
<tr><th align="left">7.23 Advantages of strongly typed API responses</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Automated Documentation:** Swagger can accurately generate schemas for the frontend teams.
- **Client Generation:** Tools like NSwag or AutoRest can read the API and automatically generate strongly typed C# or TypeScript client SDKs.
- **Refactoring:** If you change the shape of the return object, the compiler will catch mismatched types immediately, whereas returning generic `Ok(someAnonymousObject)` will fail silently until runtime.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-8"></a>
## 8. LINQ and Collections

</td></tr>
</table>

<a id="q-8-1"></a>

<table>
<tr><th align="left">8.1 What is LINQ?</th></tr>
<tr><td>

**LINQ (Language Integrated Query)** is a set of features in C# that provides powerful query capabilities directly into the language syntax.

**Interview Ready Answer:**
- **The Concept:** It allows developers to query strongly-typed collections of data (like Lists, XML, or SQL Databases) using a standardized, SQL-like declarative syntax directly in C#.
- **Why it matters:** Before LINQ, querying a `List<User>` required writing manual `foreach` loops with `if` statements. LINQ condenses this into highly readable, declarative, and chainable extension methods (e.g., `users.Where(u => u.Age > 18).OrderBy(u => u.Name)`).

</td></tr>
</table>

<a id="q-8-2"></a>

<table>
<tr><th align="left">8.2 Difference between LINQ to Objects and LINQ to Entities</th></tr>
<tr><td>

**Interview Ready Answer:**
- **LINQ to Objects (`IEnumerable<T>`):** Used for querying in-memory collections (like `List` or `Array`). The C# compiler executes the queries locally in memory using .NET's `System.Linq` extension methods (which are usually backed by state machines and delegates).
- **LINQ to Entities (`IQueryable<T>`):** Used with Entity Framework. The query is *not* executed in memory immediately. Instead, the expression tree is translated into an optimized native SQL string (e.g., `SELECT * FROM ...`) and executed directly on the SQL Server.

</td></tr>
</table>

<a id="q-8-3"></a>

<table>
<tr><th align="left">8.3 What LINQ methods have you used?</th></tr>
<tr><td>

**Interview Ready Answer:**
*(Be prepared to mention standard extension methods and what they do).*
- **Filtering:** `Where()`, `OfType()`
- **Projection:** `Select()`, `SelectMany()`
- **Aggregation:** `Count()`, `Sum()`, `Average()`, `Min()`, `Max()`
- **Sorting:** `OrderBy()`, `OrderByDescending()`, `ThenBy()`
- **Partitioning:** `Take()`, `Skip()` (Crucial for pagination).
- **Element Operators:** `First()`, `FirstOrDefault()`, `Single()`, `SingleOrDefault()`

</td></tr>
</table>

<a id="q-8-4"></a>

<table>
<tr><th align="left">8.4 How do joins work in LINQ?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Inner Join:** The standard `Join()` method correlates elements of two sequences based on matching keys. It returns a flat sequence containing only the elements that have matches in both collections.
- **Group Join:** The `GroupJoin()` method correlates elements but groups the results. It is essentially a "Left Outer Join". It returns a hierarchical sequence where each element from the first collection is paired with a collection of matching elements from the second (even if that collection is empty).

</td></tr>
</table>

<a id="q-8-5"></a>

<table>
<tr><th align="left">8.5 What is GroupBy in LINQ?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** `GroupBy()` takes a flat sequence and organizes it into groups based on a specified key.
- **Return Type:** It returns an `IEnumerable<IGrouping<TKey, TElement>>`. Each `IGrouping` acts like a list that also possesses a `Key` property.
- **Example:** `users.GroupBy(u => u.Country)` will group users by their country. You can then iterate over the groups, using the `Key` (Country Name) and iterating through the specific users in that group.

</td></tr>
</table>

<a id="q-8-6"></a>

<table>
<tr><th align="left">8.6 Difference between `Select` and `SelectMany`</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`Select` (Map):** A 1-to-1 projection. If you have 10 Users, `Select(u => u.Name)` returns exactly 10 strings. If you use `Select(u => u.PhoneNumbers)`, it returns a "List of Lists".
- **`SelectMany` (Flatten):** A 1-to-Many projection that flattens nested collections. If 10 Users each have 3 PhoneNumbers, `SelectMany(u => u.PhoneNumbers)` flattens the hierarchy and returns exactly 30 individual PhoneNumbers in a single, flat 1-dimensional list.

</td></tr>
</table>

<a id="q-8-7"></a>

<table>
<tr><th align="left">8.7 Difference between `First`, `FirstOrDefault`, and `Single`</th></tr>
<tr><td>

**Interview Ready Answer:**
| Method | If sequence is empty | If exactly 1 match | If > 1 matches | Use Case |
|---|---|---|---|---|
| **`First()`** | Throws Exception | Returns element | Returns first element | When you *expect* at least one item to exist. |
| **`FirstOrDefault()`**| Returns `null` (or default) | Returns element | Returns first element | Safe retrieval. You don't know if the item exists. |
| **`Single()`** | Throws Exception | Returns element | **Throws Exception** | When there *must* be exactly one strictly unique item. |

</td></tr>
</table>

<a id="q-8-8"></a>

<table>
<tr><th align="left">8.8 When should you use `Single` over `FirstOrDefault`?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Core Reason:** Use `Single()` or `SingleOrDefault()` when business logic strictly dictates that a collection **must not** contain duplicates for the given criteria. 
- **Example:** Querying a database by a unique `UserId` or `EmailAddress`. If the database somehow returns two rows for the same `UserId`, your data is catastrophically corrupted. `Single()` will instantly throw an exception and halt the application, alerting you to the data corruption. `FirstOrDefault()` would silently hide the corruption by just grabbing the first row.

</td></tr>
</table>

<a id="q-8-9"></a>

<table>
<tr><th align="left">8.9 What is deferred execution in LINQ?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Deferred execution means that the query is **not** executed at the point where it is defined. Instead, the query variable only stores the *logic* of the command.
- **How it works:** When you write `var query = users.Where(u => u.Active);`, no filtering actually happens yet. The query is only executed when you actually start iterating over the results (e.g., in a `foreach` loop).

</td></tr>
</table>

<a id="q-8-10"></a>

<table>
<tr><th align="left">8.10 Advantages and disadvantages of deferred execution</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Advantages:**
  - **Efficiency:** You can build complex, multi-step queries without executing them until the final result is needed.
  - **Always Fresh Data:** Since the query executes at the moment of iteration, it will include any items added to the underlying collection *after* the query was defined but *before* it was iterated.
- **Disadvantages:**
  - **Side Effects:** If the underlying collection changes unexpectedly before iteration, you might get results you didn't anticipate.
  - **Performance Gotchas:** If you iterate over the same query variable three times, the entire filtering logic runs three times.

</td></tr>
</table>

<a id="q-8-11"></a>

<table>
<tr><th align="left">8.11 When does a LINQ query execute?</th></tr>
<tr><td>

**Interview Ready Answer:**
A LINQ query executes in two main scenarios:
1. **Iterating over the query:** Using a `foreach` loop.
2. **Calling a conversion/element operator:** Methods like `ToList()`, `ToArray()`, `ToDictionary()`, `First()`, `Count()`, or `Any()`. These methods force the query to execute immediately to produce a result.

</td></tr>
</table>

<a id="q-8-12"></a>

<table>
<tr><th align="left">8.12 What does `ToList()` do internally?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Execution:** It forces the immediate execution of a deferred LINQ query.
- **Caching:** It iterates through the entire source collection, evaluates all filters/projections, and stores the resulting elements into a **new** `List<T>` object in memory. 
- **Snapshot:** Once `ToList()` is called, the data is "snapshotted." Changes to the original source collection will no longer be reflected in the list.

</td></tr>
</table>

<a id="q-8-13"></a>

<table>
<tr><th align="left">8.13 Difference between `IEnumerable` and `IQueryable`</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`IEnumerable<T>` (Client-Side):** Used for in-memory collections. When you filter an `IEnumerable`, the data is loaded into memory first, and the filtering happens on the app server using delegates.
- **`IQueryable<T>` (Server-Side):** Used for out-of-memory data (like a SQL database). It stores the query as an **Expression Tree**. When executed, the provider translates this tree into a single, optimized SQL query that runs on the database server.
- **The Big Difference:** `IEnumerable` brings the whole table to the app and filters it. `IQueryable` filters the data on the database and only brings the results to the app.

</td></tr>
</table>

<a id="q-8-14"></a>

<table>
<tr><th align="left">8.14 Why is `IEnumerable` preferred in some method signatures?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Abstraction:** It is the most basic interface for a collection. Using `IEnumerable<T>` allows your method to accept a `List<T>`, `Array`, `HashSet<T>`, or even the results of a LINQ query without caring about the underlying implementation.
- **Read-Only Intent:** It signals to the caller that the method only intends to iterate over the data, not modify, add, or remove items from the original collection.

</td></tr>
</table>

<a id="q-8-15"></a>

<table>
<tr><th align="left">8.15 Why should repositories return `IQueryable` carefully?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The "Leaky Abstraction" Problem:** If a repository returns `IQueryable`, it gives the Service layer the power to add more filters (like `.Where()` or `.Include()`). This might result in generating extremely inefficient SQL that the repository author never intended.
- **Unit of Work Issues:** A query might fail late in the Service layer after the database context has already been disposed, leading to "ObjectDisposedException".
- **Best Practice:** Many architects prefer repositories to return `IEnumerable` or a materialized `List` to ensure the repository has full control over the query execution and performance.

</td></tr>
</table>

<a id="q-8-16"></a>

<table>
<tr><th align="left">8.16 Difference between `IEnumerable` and `List`</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`IEnumerable<T>`:** An interface that only supports one-way, forward-only iteration. It is **Lazy**. It doesn't store the data; it only knows how to get it.
- **`List<T>`:** A concrete class that stores data in memory. it is **Eager**. It supports random access (indexing), adding, removing, and sorting.
- **Comparison:** Think of `IEnumerable` as a "recipe" to make a cake, and `List` as the "actual cake" sitting on the table.

</td></tr>
</table>

<a id="q-8-17"></a>

<table>
<tr><th align="left">8.17 Difference between arrays and collections</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Arrays (`T[]`):** Fixed size upon creation. Once you create an array of 5 items, you cannot make it 6. It is a lower-level construct and slightly more memory-efficient.
- **Collections (`List<T>`, etc.):** Dynamic size. You can add or remove items as needed. Internally, a `List<T>` uses an array that it automatically resizes (doubles in size) when it reaches capacity.

</td></tr>
</table>

<a id="q-8-18"></a>

<table>
<tr><th align="left">8.18 Is `List<T>` a value type or reference type? Why?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Reference Type:** `List<T>` is a **class**.
- **Reason:** It is stored on the Managed Heap. When you pass a list to a method, you are passing a reference (memory address) to that list, not a copy of the list itself. If the method modifies the list, the caller sees those changes.

</td></tr>
</table>

<a id="q-8-19"></a>

<table>
<tr><th align="left">8.19 Why do generics improve performance compared to non-generic collections?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Eliminates Boxing/Unboxing:** In non-generic collections (like `ArrayList`), every value type (like `int`) must be boxed into an `object` to be stored, and unboxed when retrieved. This is extremely slow and causes heavy GC pressure. Generics allow the CLR to store value types directly.
- **Eliminates Casting:** Non-generic collections return `object`, requiring an explicit cast to the actual type (e.g., `(User)list[0]`). Generics are strongly typed, so no casting is needed.

</td></tr>
</table>

<a id="q-8-20"></a>

<table>
<tr><th align="left">8.20 Difference between `List`, `Dictionary`, and `HashSet`</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`List<T>`:** An ordered collection of items. Allows duplicates. Accessed by index (e.g., `list[0]`).
- **`Dictionary<TKey, TValue>`:** A collection of Key-Value pairs. Keys must be unique. Optimized for extremely fast lookups by key.
- **`HashSet<T>`:** An unordered collection of unique items. Optimized for checking if an item exists and performing set operations (Union, Intersect).

</td></tr>
</table>

<a id="q-8-21"></a>

<table>
<tr><th align="left">8.21 When should you use `HashSet` over `List`?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Uniqueness:** Use `HashSet` when you need to ensure every item in the collection is strictly unique.
- **Performance:** Use `HashSet` when you frequently need to check if an item exists (`.Contains()`). 
  - `List.Contains()` is **O(N)** (it has to check every item one by one).
  - `HashSet.Contains()` is **O(1)** (it uses a hash code to jump directly to the item).

</td></tr>
</table>

<a id="q-8-22"></a>

<table>
<tr><th align="left">8.22 Internal working of `Dictionary<TKey, TValue>`</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Hashing:** When you add a key, the dictionary calls `key.GetHashCode()`.
- **Buckets:** It applies a modulo operation to the hash code to determine which "bucket" the value belongs in.
- **Collision Handling:** If two keys land in the same bucket (a collision), the dictionary uses a linked list (or a similar structure) within that bucket and uses `key.Equals()` to find the exact matching key.

</td></tr>
</table>

<a id="q-8-23"></a>

<table>
<tr><th align="left">8.23 Time complexities of common collection operations</th></tr>
<tr><td>

**Interview Ready Answer:**
| Operation | `List<T>` | `Dictionary<TKey, TValue>` | `HashSet<T>` |
|---|---|---|---|
| **Add** | O(1) average / O(N) if resize | O(1) | O(1) |
| **Lookup by Index/Key** | O(1) | O(1) | N/A |
| **Contains (Lookup by Value)**| **O(N)** | N/A | **O(1)** |
| **Remove** | O(N) | O(1) | O(1) |

</td></tr>
</table>

<a id="q-8-24"></a>

<table>
<tr><th align="left">8.24 What is lazy loading?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Lazy loading is a design pattern that delays the initialization of an object or the loading of data until the exact moment it is actually needed.
- **In .NET:** Often implemented using the `Lazy<T>` class or via `IEnumerable` deferred execution.
- **In EF Core:** It means that "Navigation Properties" (like `User.Orders`) are not loaded from the database until you actually try to access the `Orders` property in your code.

</td></tr>
</table>

<a id="q-8-25"></a>

<table>
<tr><th align="left">8.25 Write a LINQ query and explain deferred execution</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-9-1"></a>

<table>
<tr><th align="left">9.1 Difference between UNION and UNION ALL?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`UNION`:** Combines the result sets of two or more SELECT statements and **removes duplicate rows**. It is slower because the database must perform a distinct sort operation to identify and delete duplicates.
- **`UNION ALL`:** Combines the result sets and **includes duplicates**. it is significantly faster because the database simply appends the results together without any extra processing.

</td></tr>
</table>

<a id="q-9-2"></a>

<table>
<tr><th align="left">9.2 Explain INNER JOIN.</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The most common type of join. It returns only the rows where there is a **match in both tables**.
- **Example:** If you join `Orders` and `Customers`, an INNER JOIN will only return orders that have a valid customer associated with them, and only customers who have placed at least one order.

</td></tr>
</table>

<a id="q-9-3"></a>

<table>
<tr><th align="left">9.3 Explain LEFT JOIN.</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Returns **all rows from the left table**, and the matched rows from the right table. 
- **Missing Data:** If there is no match in the right table, the result set will contain `NULL` for every column coming from the right table.
- **Example:** A `Customers` LEFT JOIN `Orders` will return every single customer in your database, even if they have never placed an order.

</td></tr>
</table>

<a id="q-9-4"></a>

<table>
<tr><th align="left">9.4 Explain RIGHT JOIN.</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The exact opposite of a LEFT JOIN. It returns **all rows from the right table**, and the matched rows from the left table.
- **Missing Data:** If there is no match in the left table, the result will contain `NULL` for the left table's columns.
- **Note:** In practice, most developers stick to LEFT JOINs and simply swap the table order for better readability.

</td></tr>
</table>

<a id="q-9-5"></a>

<table>
<tr><th align="left">9.5 Explain FULL OUTER JOIN.</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Returns a row when there is a match in **either** the left or the right table. 
- **Result:** It is essentially a combination of a LEFT JOIN and a RIGHT JOIN. It contains every record from both tables, filling in `NULL`s wherever a match is missing on either side.

</td></tr>
</table>

<a id="q-9-6"></a>

<table>
<tr><th align="left">9.6 Difference between Primary Key and Unique Key?</th></tr>
<tr><td>

**Interview Ready Answer:**
| Feature | Primary Key | Unique Key |
|---|---|---|
| **Purpose** | Uniquely identifies a row in a table. | Ensures data in a column is unique. |
| **NULL values** | **Strictly not allowed.** | Allows exactly one `NULL` value (in SQL Server). |
| **Limit** | Exactly one per table. | Multiple unique keys allowed per table. |
| **Index** | Automatically creates a Clustered Index. | Automatically creates a Non-Clustered Index. |

</td></tr>
</table>

<a id="q-9-7"></a>

<table>
<tr><th align="left">9.7 What are indexes?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A database index is a data structure (usually a B-Tree) that improves the speed of data retrieval operations on a table at the cost of additional storage space and slower write operations.
- **Analogy:** Think of an index like the **Index at the back of a textbook**. instead of reading every single page to find "Garbage Collection," you look at the index, find the page number, and jump directly there.

</td></tr>
</table>

<a id="q-9-8"></a>

<table>
<tr><th align="left">9.8 Difference between clustered and non-clustered index?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Clustered Index:** Physically reorders the rows in the table to match the index. The leaf nodes of a clustered index contain the **actual data rows**. 
- **Non-Clustered Index:** Does not change the physical order of the rows. It creates a separate structure that contains a pointer (a row locator) to the actual data.

</td></tr>
</table>

<a id="q-9-9"></a>

<table>
<tr><th align="left">9.9 How many clustered indexes can a table have?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Exactly One.**
- **Reason:** Since a clustered index determines the physical order of the data on the disk, a table can only be physically sorted in one way.

</td></tr>
</table>

<a id="q-9-10"></a>

<table>
<tr><th align="left">9.10 What are ranking functions?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Ranking functions are window functions in SQL that assign a rank (a number) to each row within a partition of a result set.
- **Syntax:** They are used with the `OVER()` clause, which specifies the ordering and optional partitioning of the data (e.g., `ROW_NUMBER() OVER (ORDER BY Salary DESC)`).

</td></tr>
</table>

<a id="q-9-11"></a>

<table>
<tr><th align="left">9.11 Difference between ROW_NUMBER, RANK, and DENSE_RANK?</th></tr>
<tr><td>

**Interview Ready Answer:**
*(Imagine three employees with salaries: 100, 100, 50).*
- **`ROW_NUMBER()`:** Always unique. Assigns a unique, sequential number to every row (e.g., 1, 2, 3).
- **`RANK()`:** Skips ranks for ties. If two people tie for 1st, the next person is 3rd (e.g., 1, 1, 3).
- **`DENSE_RANK()`:** Does not skip ranks for ties. If two people tie for 1st, the next person is 2nd (e.g., 1, 1, 2).

</td></tr>
</table>

<a id="q-9-12"></a>

<table>
<tr><th align="left">9.12 What are stored procedures?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A stored procedure is a group of one or more SQL statements that are compiled and stored on the database server.
- **Advantages:** 
  - **Performance:** They are pre-compiled, reducing parsing and execution time.
  - **Security:** They prevent SQL Injection by forcing the use of parameters.
  - **Network Traffic:** You only send the name of the procedure and parameters over the network, not the entire long SQL script.

</td></tr>
</table>

<a id="q-9-13"></a>

<table>
<tr><th align="left">9.13 Difference between procedure and function?</th></tr>
<tr><td>

**Interview Ready Answer:**
| Feature | Stored Procedure | Function (UDF) |
|---|---|---|
| **Return Value** | Can return multiple values (via `OUT` parameters) or none. | **Must** return exactly one value (or a table). |
| **Parameters** | Supports `IN` and `OUT` parameters. | Supports only `IN` parameters. |
| **Side Effects** | Can modify database state (INSERT, UPDATE, DELETE). | **Cannot** modify database state. |
| **Usage** | Called using `EXEC`. | Can be called directly inside a `SELECT` statement. |

</td></tr>
</table>

<a id="q-9-14"></a>

<table>
<tr><th align="left">9.14 What are table-valued functions?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A user-defined function that returns a result set in the form of a table.
- **Types:** 
  - **Inline TVF:** Contains a single `SELECT` statement. It is extremely fast because the SQL optimizer treats it like a View.
  - **Multi-statement TVF:** Contains multiple logic blocks and manual table population. Slower but more flexible.

</td></tr>
</table>

<a id="q-9-15"></a>

<table>
<tr><th align="left">9.15 What is normalization?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The process of organizing data in a database to reduce redundancy and improve data integrity.
- **Goals:** 
  - Eliminating duplicate data (storing "Customer Name" once in a Customers table, not in every Order row).
  - Ensuring data dependencies make sense (storing data where it logically belongs).
- **Stages:** Typically achieved through "Normal Forms" (1NF, 2NF, 3NF).

</td></tr>
</table>

<a id="q-9-16"></a>

<table>
<tr><th align="left">9.16 What is denormalization?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The intentional process of adding redundant data back into a database.
- **Purpose:** To **improve read performance**. By storing pre-calculated data or combining tables, you can avoid expensive `JOIN` operations.
- **Trade-off:** It makes writes slower and more complex because you have to update the same piece of data in multiple places to maintain consistency.

</td></tr>
</table>

<a id="q-9-17"></a>

<table>
<tr><th align="left">9.17 What is a CTE?</th></tr>
<tr><td>

**Common Table Expression (CTE)** is a temporary result set that you can reference within another SELECT, INSERT, UPDATE, or DELETE statement.

**Interview Ready Answer:**
- **Syntax:** Defined using the `WITH` keyword.
- **Advantage:** Unlike subqueries, CTEs make the code significantly more readable. They can also be **Recursive**, allowing you to query hierarchical data like organizational charts or folder structures.

</td></tr>
</table>

<a id="q-9-18"></a>

<table>
<tr><th align="left">9.18 What are aggregate functions?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Functions that perform a calculation on a set of values and return a single scalar value.
- **Examples:** `COUNT()`, `SUM()`, `AVG()`, `MIN()`, `MAX()`.
- **Usage:** They are almost always used with the `GROUP BY` clause to calculate values across different categories.

</td></tr>
</table>

<a id="q-9-19"></a>

<table>
<tr><th align="left">9.19 What is pagination?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The process of dividing a large result set into smaller, manageable "pages" to improve application performance and user experience.
- **Implementation (SQL Server):** Usually achieved using the `OFFSET` and `FETCH NEXT` clauses.
- **Example:** `SELECT * FROM Users ORDER BY Id OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;` (This skips the first 10 rows and takes the next 10, effectively getting Page 2).

</td></tr>
</table>

<a id="q-9-20"></a>

<table>
<tr><th align="left">9.20 What causes slow queries?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Missing Indexes:** The database has to perform a full table scan.
- **Large Joins:** Joining massive tables without proper filtering or indexed columns.
- **Data Volume:** Tables growing so large that standard queries become inefficient.
- **Blocking/Deadlocks:** Other queries holding locks on the data you need.
- **Inefficient SQL:** Using `SELECT *`, non-SARGable queries (e.g., using functions in the `WHERE` clause like `WHERE YEAR(Date) = 2023`), or unnecessary subqueries.

</td></tr>
</table>

<a id="q-9-21"></a>

<table>
<tr><th align="left">9.21 How do you optimize SQL queries?</th></tr>
<tr><td>

**Interview Ready Answer:**
1. **Execution Plan:** Use `EXPLAIN` or "Display Estimated Execution Plan" to see how the database is actually retrieving data.
2. **Indexing:** Add missing indexes (Clustered/Non-Clustered/Filtered).
3. **Avoid SELECT *:** Retrieve only the specific columns you need to reduce network traffic and memory usage.
4. **SARGable Queries:** Avoid functions on the left side of the `WHERE` clause so the database can use an index.
5. **Use CTEs/Temp Tables:** Break complex logic into smaller, more readable steps.
6. **Update Statistics:** Ensure the database optimizer has accurate information about the data distribution.

</td></tr>
</table>

<a id="q-9-22"></a>

<table>
<tr><th align="left">9.22 What is index seek vs index scan?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Index Seek (Good):** The database uses the B-Tree structure of the index to jump directly to the specific rows it needs. It is very fast.
- **Index Scan (Bad/Slower):** The database has to read the *entire* index from beginning to end because it couldn't find a direct way to the data (often caused by non-SARGable queries).  

</td></tr>
</table>

<a id="q-9-23"></a>

<table>
<tr><th align="left">9.23 Why is SELECT * bad?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Performance:** It retrieves more data than necessary, increasing I/O, memory usage, and network latency.
- **Index Usage:** It can prevent the database from using a "Covering Index" (where all requested columns are already in the index).
- **Brittleness:** If a column is added or renamed in the database, your application code might break if it expects a specific column count or order.

</td></tr>
</table>

<a id="q-9-24"></a>

<table>
<tr><th align="left">9.24 What is deadlock in SQL?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A situation where two or more transactions are waiting for each other to release locks, creating a circular dependency where nobody can proceed.
- **Example:** 
  - Transaction A locks Table 1 and wants Table 2.
  - Transaction B locks Table 2 and wants Table 1.
- **Resolution:** The SQL Server "Deadlock Monitor" detects the cycle, chooses one transaction as a "Deadlock Victim," kills it, and rolls back its changes so the other can finish.

</td></tr>
</table>

<a id="q-9-25"></a>

<table>
<tr><th align="left">9.25 What is transaction?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A single unit of work that contains one or more SQL statements.
- **All or Nothing:** It ensures that either all the statements succeed and are "Committed" to the database, or if any fail, the entire sequence is "Rolled Back" to its original state, leaving no partial data.

</td></tr>
</table>

<a id="q-9-26"></a>

<table>
<tr><th align="left">9.26 What are ACID properties?</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-10-1"></a>

<table>
<tr><th align="left">10.1 What is two-way binding?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Two-way data binding means that any changes made to the Model (the TypeScript class variable) are automatically reflected in the View (the HTML template), and vice-versa.
- **Syntax:** In Angular, this is achieved using the "Banana-in-a-box" syntax: `[(ngModel)]`.

</td></tr>
</table>

<a id="q-10-2"></a>

<table>
<tr><th align="left">10.2 What are components?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Components are the basic building blocks of an Angular application. 
- **Structure:** Every component consists of:
  - An **HTML template** for the UI.
  - A **TypeScript class** for logic.
  - A **CSS file** for styling.
  - A **Decorator** (`@Component`) that links these files together and defines the selector.

</td></tr>
</table>

<a id="q-10-3"></a>

<table>
<tr><th align="left">10.3 What are services?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A class used to share data or logic across multiple components.
- **Purpose:** Services follow the Single Responsibility Principle. They are used for tasks like fetching data from an API, logging, or shared business logic, keeping the components focused only on the UI.
- **DI:** Services are typically injected into components using Angular's built-in Dependency Injection.

</td></tr>
</table>

<a id="q-10-4"></a>

<table>
<tr><th align="left">10.4 What are pipes?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Pipes are simple functions used in Angular templates to transform and format data before it is displayed to the user.
- **Built-in Examples:** `date`, `uppercase`, `currency`, `json`.
- **Usage:** `{{ birthday | date:'shortDate' }}`.

</td></tr>
</table>

<a id="q-10-5"></a>

<table>
<tr><th align="left">10.5 What are custom pipes?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** You can create your own pipe by implementing the `PipeTransform` interface and using the `@Pipe` decorator.
- **Purpose:** Useful for reusable UI logic like "Shortening a long description" or "Filtering a list based on user input".

</td></tr>
</table>

<a id="q-10-6"></a>

<table>
<tr><th align="left">10.6 Difference between template-driven and reactive forms?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Template-driven Forms:** Logic is mostly in the HTML. Easier to use for simple forms. Uses `[(ngModel)]`.
- **Reactive Forms:** Logic is mostly in the TypeScript class. More powerful, easier to test, and better for complex forms with dynamic validation. Uses `FormGroup` and `FormControl`.

</td></tr>
</table>

<a id="q-10-7"></a>

<table>
<tr><th align="left">10.7 What are RxJS operators?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Pure functions that allow you to transform, filter, and combine asynchronous data streams (Observables).
- **Common Operators:** 
  - `map`: Transforms each value.
  - `filter`: Only passes values that meet a condition.
  - `switchMap`: Cancels the previous inner observable and switches to a new one (great for search suggestions).
  - `catchError`: Handles errors in the stream gracefully.

</td></tr>
</table>

<a id="q-10-8"></a>

<table>
<tr><th align="left">10.8 How does parent-child communication work?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Parent to Child:** The parent passes data using the **`@Input()`** decorator on the child component.
- **Child to Parent:** The child sends notifications or data back to the parent using the **`@Output()`** decorator and an `EventEmitter`.

</td></tr>
</table>

<a id="q-10-9"></a>

<table>
<tr><th align="left">10.9 How do sibling components communicate?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Shared Service:** The most common way. Both components inject the same service which holds a shared `Subject` or `BehaviorSubject`. One component pushes a new value, and the other component subscribes to it.
- **Parent Mediator:** The components pass data through their common parent using `@Input` and `@Output` (often too complex for deeply nested siblings).

</td></tr>
</table>

<a id="q-10-10"></a>

<table>
<tr><th align="left">10.10 What are observables?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Part of the RxJS library, an Observable is a blueprint for a stream of data that can arrive over time.
- **How they work:** Unlike a Promise (which returns a single value once), an Observable can return multiple values over time. It is **Lazy**; it doesn't do anything until someone calls `.subscribe()` on it.

### React

</td></tr>
</table>

<a id="q-10-11"></a>

<table>
<tr><th align="left">10.11 Difference between class and functional components?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Class Components:** The older way of writing React. They use ES6 classes, require `this` keyword, and have lifecycle methods like `componentDidMount`.
- **Functional Components:** The modern, standard way. They are just JavaScript functions. With the introduction of **Hooks**, they can now do everything class components can do, but with much less boilerplate code and better readability.

</td></tr>
</table>

<a id="q-10-12"></a>

<table>
<tr><th align="left">10.12 What are hooks?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Hooks are special functions that let you "hook into" React features (like state and lifecycle methods) from functional components.
- **Rule of Hooks:** They must only be called at the top level of your component (not inside loops or conditions) and only from React functional components or custom hooks.

</td></tr>
</table>

<a id="q-10-13"></a>

<table>
<tr><th align="left">10.13 What is useState?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A Hook that allows you to add state (data that changes over time) to a functional component.
- **Usage:** It returns an array with two elements: the current state value and a function to update it.
- **Example:** `const [count, setCount] = useState(0);`

</td></tr>
</table>

<a id="q-10-14"></a>

<table>
<tr><th align="left">10.14 What is useEffect?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A Hook used for performing "side effects" in your components, such as fetching data from an API, manually changing the DOM, or setting up a subscription.
- **Dependency Array:** It takes a second argument (an array). 
  - If empty `[]`, it runs only once (similar to `componentDidMount`).
  - If it contains variables `[id]`, it runs every time those variables change.

</td></tr>
</table>

<a id="q-10-15"></a>

<table>
<tr><th align="left">10.15 What is useMemo?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A Hook used for **memoization** (caching).
- **Purpose:** It recalculates a value only when one of its dependencies has changed. This is used to optimize performance by avoiding expensive calculations on every single render.

</td></tr>
</table>

<a id="q-10-16"></a>

<table>
<tr><th align="left">10.16 What are props and state?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Props (Properties):** Data passed **into** a component from its parent. Props are **read-only** (immutable) from the child's perspective.
- **State:** Data managed **inside** the component. State is **mutable** (can be changed using a setter function) and determines what the component renders at any given time.

</td></tr>
</table>

<a id="q-10-17"></a>

<table>
<tr><th align="left">10.17 What is React key?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A unique string attribute you must include when creating lists of elements in React.

</td></tr>
</table>

<a id="q-10-18"></a>

<table>
<tr><th align="left">10.18 Why is key important in lists?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Performance (Reconciliation):** Keys help React identify which items in a list have changed, been added, or been removed. Without unique keys, if you reorder a list, React might re-render every single item from scratch instead of just moving them in the DOM, which is very slow.

</td></tr>
</table>

<a id="q-10-19"></a>

<table>
<tr><th align="left">10.19 What does map() do in React?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** `map()` is a standard JavaScript array method used in React to iterate through an array of data and return an array of JSX elements (like `<li>` or custom components). It is the standard way to render lists in React.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-11"></a>
## 11. System Design, Performance, and Scalability

</td></tr>
</table>

<a id="q-11-1"></a>

<table>
<tr><th align="left">11.1 How did you improve performance in your project?</th></tr>
<tr><td>

**Interview Ready Answer:**
*(Answer this by mentioning specific architectural improvements).*
- **Database Optimization:** Added missing indexes and replaced `SELECT *` with specific columns.
- **Caching:** Implemented **Redis** to store frequently accessed, static data (like configuration or product categories), reducing database hits by 80%.
- **Async Processing:** Moved heavy, non-blocking tasks (like sending emails or generating PDFs) to a background worker using **Hangfire** or **RabbitMQ**.
- **Payload Reduction:** Enabled Gzip/Brotli compression and implemented Pagination for large data lists.

</td></tr>
</table>

<a id="q-11-2"></a>

<table>
<tr><th align="left">11.2 How do you optimize slow APIs?</th></tr>
<tr><td>

**Interview Ready Answer:**
1. **Identify the Bottleneck:** Use a profiler or Application Insights to see if the delay is in the Database, the Network, or the C# code itself.
2. **Database:** Review the execution plan, add indexes, or simplify complex joins.
3. **Caching:** Use Response Caching (browser-level) or Distributed Caching (server-level).
4. **I/O Bound:** Ensure all database and external API calls are using **`async/await`** to free up thread pool threads.
5. **N+1 Problem:** Ensure Entity Framework is using `.Include()` (Eager Loading) instead of making 100 separate database calls for related data.

</td></tr>
</table>

<a id="q-11-3"></a>

<table>
<tr><th align="left">11.3 How do you reduce payload size?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **DTOs:** Instead of returning the full Database Entity, return a lightweight Data Transfer Object (DTO) containing only the fields the frontend actually needs.
- **Compression:** Enable Gzip or Brotli middleware in ASP.NET Core.
- **JSON Serialization:** Use `JsonIgnore` to exclude unnecessary fields.
- **Pagination:** Never return 10,000 rows at once; return 20 at a time.

</td></tr>
</table>

<a id="q-11-4"></a>

<table>
<tr><th align="left">11.4 How does pagination improve performance?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Lower Memory Usage:** The server doesn't have to load a massive dataset into RAM.
- **Faster Database Retrieval:** The database engine retrieves only a small subset of rows.
- **Reduced Network Latency:** The JSON payload is significantly smaller, leading to faster download times for the client.

</td></tr>
</table>

<a id="q-11-5"></a>

<table>
<tr><th align="left">11.5 What is lazy loading?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Delaying the loading of related data until the moment it is specifically requested in code.
- **Trade-off:** While it saves memory initially, it often leads to the **N+1 Select Problem**, where a simple loop causes hundreds of small database calls, significantly slowing down the application.

</td></tr>
</table>

<a id="q-11-6"></a>

<table>
<tr><th align="left">11.6 How do you identify bottlenecks?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Logging & Monitoring:** Tools like **Azure Application Insights**, **New Relic**, or **Prometheus/Grafana**.
- **Profiling:** Using **Visual Studio Profiler** or **dotTrace** to find CPU-intensive methods or memory leaks.
- **Database Profiling:** Using **SQL Server Profiler** to find slow-running queries.

</td></tr>
</table>

<a id="q-11-7"></a>

<table>
<tr><th align="left">11.7 How do you improve scalability?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Horizontal Scaling:** Adding more server instances behind a Load Balancer (Scaling Out).
- **Statelessness:** Ensure the API doesn't store session data in memory so any server can handle any request.
- **Microservices:** Breaking the monolith into smaller services that can be scaled independently based on their specific demand.
- **Database Read Replicas:** Routing read-only queries to secondary database nodes to reduce the load on the primary write node.

</td></tr>
</table>

<a id="q-11-8"></a>

<table>
<tr><th align="left">11.8 How do you handle high-volume API responses?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Streaming:** Use `IAsyncEnumerable` to stream data to the client as it is read from the database, rather than waiting for the entire list to be loaded into memory.
- **Batch Processing:** Processing and returning data in chunks.
- **Message Queues:** For write-heavy high-volume, accept the request, put it in a queue, and return an immediate `202 Accepted`.

</td></tr>
</table>

<a id="q-11-9"></a>

<table>
<tr><th align="left">11.9 How do microservices improve scalability?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Independent Scaling:** If the "Order Processing" service is under high load but the "User Profile" service is idle, you only need to scale the Order service, saving significant cloud costs.
- **Resource Specialization:** You can host a memory-intensive service on a high-RAM instance and a CPU-intensive service on a high-CPU instance.

</td></tr>
</table>

<a id="q-11-10"></a>

<table>
<tr><th align="left">11.10 What causes blocking or waiting issues?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Thread Pool Starvation:** Caused by "Sync-over-Async" (calling `.Result` or `.Wait()` on an async task), which ties up threads needlessly.
- **Database Locks:** Long-running transactions blocking other queries.
- **Slow External APIs:** Waiting for a third-party response without a timeout or asynchronous handling.

</td></tr>
</table>

<a id="q-11-11"></a>

<table>
<tr><th align="left">11.11 How would you debug slow backend response?</th></tr>
<tr><td>

**Interview Ready Answer:**
1. **Check the Network:** Use Browser DevTools (Network tab) to see if it's high latency or a large payload.
2. **Review Logs:** Look at structured logs (Serilog/ELK) for errors or slow transaction timings.
3. **Trace the Request:** Use Distributed Tracing (like **OpenTelemetry**) to see where the time is being spent across different microservices.
4. **Inspect the Database:** Run the query manually with `SET STATISTICS IO, TIME ON` to see disk I/O and CPU time.

</td></tr>
</table>

<a id="q-11-12"></a>

<table>
<tr><th align="left">11.12 How would you optimize data-heavy dashboards?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Data Aggregation:** Use "Summary Tables" or "Materialized Views" in the database so the dashboard doesn't have to calculate sums/averages on millions of rows every time it loads.
- **Polling vs WebSockets:** Instead of refreshing the whole page, use **SignalR** to push only the small changed data points to the UI.
- **Frontend Optimization:** Use "Virtual Scrolling" to render only the visible rows in a large data table.
- **Cache at the Edge:** Use a CDN or Redis to store the pre-calculated dashboard JSON for a few minutes.

</td></tr>
</table>

<a id="q-11-13"></a>

<table>
<tr><th align="left">11.13 Monolith vs microservices?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Monolith:** Single codebase, single deployment unit. **Pros:** Simple to develop, test, and deploy. **Cons:** Hard to scale parts independently; a single bug can crash the whole app.
- **Microservices:** Multiple small, independent services. **Pros:** Highly scalable, technology-independent, fault-isolated. **Cons:** Extremely high operational complexity, eventual consistency issues, and higher network latency.

</td></tr>
</table>

<a id="q-11-14"></a>

<table>
<tr><th align="left">11.14 Synchronous vs asynchronous microservice communication?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Synchronous (REST/gRPC):** Service A calls Service B and waits. **Best for:** Immediate data needs (e.g., getting a user's current balance). **Risk:** Cascading failures if Service B is slow.
- **Asynchronous (Message Queues):** Service A sends a message to a broker and continues. **Best for:** Long-running tasks or decoupling services (e.g., Order placed -> Notify Shipping). **Risk:** Complex to debug and handle failures.

</td></tr>
</table>

<a id="q-11-15"></a>

<table>
<tr><th align="left">11.15 What is API Gateway?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A single entry point for all client requests in a microservices architecture.
- **Responsibilities:** 
  - **Routing:** Forwarding requests to the correct internal service.
  - **Authentication:** Checking JWT tokens at the edge before the request reaches internal services.
  - **Rate Limiting:** Preventing a single client from overwhelming the system.
  - **Protocol Translation:** Converting external HTTP/REST calls to internal gRPC calls.

</td></tr>
</table>

<a id="q-11-16"></a>

<table>
<tr><th align="left">11.16 What are caching strategies?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Cache-Aside:** The application checks the cache first. If it's a "Miss," it fetches from the DB and manually updates the cache. (Most common).
- **Read-Through:** The application asks the cache for data; if missing, the cache itself fetches from the DB.
- **Write-Through:** Every time data is written to the DB, it is automatically written to the cache as well.
- **Write-Behind:** Data is written only to the cache, and the cache syncs it to the DB later in the background.

</td></tr>
</table>

<a id="q-11-17"></a>

<table>
<tr><th align="left">11.17 Redis basics?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** An open-source, in-memory key-value data store used as a database, cache, and message broker.
- **Performance:** Since it's in-memory, it provides sub-millisecond latency.
- **Data Types:** Supports Strings, Hashes, Lists, Sets, and Sorted Sets.

</td></tr>
</table>

<a id="q-11-18"></a>

<table>
<tr><th align="left">11.18 Horizontal vs vertical scaling?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Vertical Scaling (Scaling Up):** Adding more power (CPU, RAM) to an existing server. **Limit:** There's a physical limit to how much you can upgrade one machine.
- **Horizontal Scaling (Scaling Out):** Adding more server instances to your pool. **Limit:** Virtually unlimited, but requires a load balancer and a stateless application design.

</td></tr>
</table>

<a id="q-11-19"></a>

<table>
<tr><th align="left">11.19 How do you design fault-tolerant systems?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Circuit Breaker Pattern:** Automatically stops calling a failing service for a certain period to allow it to recover (implemented using **Polly** in .NET).
- **Retry Pattern:** Automatically retrying a failed request (e.g., if it was a temporary network glitch).
- **Redundancy:** Running multiple instances of every service across different availability zones.
- **Graceful Degradation:** If a non-essential service (like "Product Recommendations") fails, the main page should still load without it.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-12"></a>
## 12. Testing

</td></tr>
</table>

<a id="q-12-1"></a>

<table>
<tr><th align="left">12.1 What is unit testing?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Testing the smallest possible piece of code (usually a single method or a single class) in complete isolation from the rest of the system.
- **Characteristics:** Unit tests are extremely fast, run in memory, and never talk to the database, file system, or network.

</td></tr>
</table>

<a id="q-12-2"></a>

<table>
<tr><th align="left">12.2 What is integration testing?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Testing how multiple components of the application work together. 
- **Characteristics:** Integration tests verify the connection between your code and external dependencies, like the Database, a Web API, or a Message Broker.

</td></tr>
</table>

<a id="q-12-3"></a>

<table>
<tr><th align="left">12.3 Difference between unit testing and integration testing?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Isolation:** Unit tests are isolated; Integration tests are not.
- **Speed:** Unit tests are near-instant (milliseconds); Integration tests are slower (seconds) because they involve I/O.
- **Dependencies:** Unit tests use **Mocks** for dependencies; Integration tests use the **real** dependencies (e.g., a real SQL Server or a TestContainers instance).

</td></tr>
</table>

<a id="q-12-4"></a>

<table>
<tr><th align="left">12.4 What is BDD?</th></tr>
<tr><td>

**Behavior-Driven Development (BDD)** is an agile software development process that encourages collaboration between developers, QA, and non-technical business stakeholders.

**Interview Ready Answer:**
- **The Concept:** BDD focuses on the **behavior** of the application from the user's perspective rather than the implementation details. 
- **Syntax:** Tests are written in plain English using the **Gherkin** syntax: **Given** (context), **When** (action), **Then** (expected result).

</td></tr>
</table>

<a id="q-12-5"></a>

<table>
<tr><th align="left">12.5 Difference between BDD and unit testing?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Audience:** Unit tests are written *by* developers *for* developers. BDD is written to be understood by business stakeholders (Product Owners).
- **Scope:** Unit tests verify that a function works correctly. BDD verifies that a business feature (e.g., "User can checkout") works as expected.

</td></tr>
</table>

<a id="q-12-6"></a>

<table>
<tr><th align="left">12.6 What is mocking?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** Creating a "fake" object that mimics the behavior of a real dependency (like a database repository or an email service).
- **Purpose:** It allows you to isolate the code you are testing. You can tell the mock exactly what to return (e.g., "When `GetPrice()` is called, return 100") so you don't need a real database.

</td></tr>
</table>

<a id="q-12-7"></a>

<table>
<tr><th align="left">12.7 Why use mocks?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Reliability:** Real databases might be down or have inconsistent data; mocks always behave exactly as programmed.
- **Speed:** Talking to a mock in memory is thousands of times faster than talking to a physical database.
- **Cost:** You don't need to pay for cloud resources just to run a test.

</td></tr>
</table>

<a id="q-12-8"></a>

<table>
<tr><th align="left">12.8 What frameworks have you used?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Testing Runners:** **xUnit** (modern standard for .NET Core), NUnit, or MSTest.
- **Mocking Libraries:** **Moq** or **NSubstitute**.
- **Assertion Libraries:** **FluentAssertions** (makes tests much more readable).
- **BDD:** **SpecFlow**.

</td></tr>
</table>

<a id="q-12-9"></a>

<table>
<tr><th align="left">12.9 What is testability?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** The degree to which a piece of software supports being tested in an automated way. 
- **Signs of High Testability:** High use of interfaces, Dependency Injection, and the absence of "Hard Dependencies" (like `new SqlConnection()` inside a constructor).

</td></tr>
</table>

<a id="q-12-10"></a>

<table>
<tr><th align="left">12.10 How do interfaces help testing?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Substitution:** Interfaces allow you to swap the real implementation (e.g., `SqlRepository`) for a mock implementation (e.g., `MockRepository`) at test-time. 
- **The Contract:** Since your code depends on the `IRepository` interface, it doesn't care if the object it's calling is talking to a real database or just a fake object in memory. This is the foundation of unit testing.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-13"></a>
## 13. Git, DevOps, and Cloud

</td></tr>
</table>

<a id="q-13-1"></a>

<table>
<tr><th align="left">13.1 Difference between git fetch and git pull?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **`git fetch`:** Downloads the latest changes from the remote server but **does not modify your local code**. It only updates your "Remote Tracking Branches" (like `origin/main`). It is safe.
- **`git pull`:** A combination of two commands: `git fetch` followed immediately by `git merge`. It downloads the changes and tries to automatically merge them into your current working branch.

</td></tr>
</table>

<a id="q-13-2"></a>

<table>
<tr><th align="left">13.2 What is merge conflict?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** An event that occurs when Git is unable to automatically resolve differences in code between two commits. 
- **Causes:** This usually happens when two people edit the **same line** in the same file, or one person deletes a file that another person is currently editing.
- **Resolution:** You must manually open the file, look at the "conflict markers" (<<<<<<<, =======, >>>>>>>), choose which version of the code to keep, and then commit the resolved file.

</td></tr>
</table>

<a id="q-13-3"></a>

<table>
<tr><th align="left">13.3 What is rebase?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Concept:** Rebase is the process of moving or combining a sequence of commits to a new base commit.
- **Analogy:** Imagine you branched off `main` to work on a feature. While you were working, `main` moved forward with 3 new commits. `git rebase main` takes your work, lifts it up, and puts it **on top** of the latest `main` commit.
- **Advantage:** It results in a perfectly linear, clean project history without "noise" from merge commits.

</td></tr>
</table>

<a id="q-13-4"></a>

<table>
<tr><th align="left">13.4 What branching strategy do you use?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **GitFlow:** A structured strategy with separate branches for `master` (production), `develop` (integration), `feature/`, `release/`, and `hotfix/`. (Best for large enterprises).
- **GitHub Flow:** A simpler, modern strategy where you only have `main` and short-lived `feature/` branches. Once a feature is done and reviewed, it's merged into `main` and deployed immediately. (Best for CI/CD).
- **Trunk-Based Development:** Developers commit small changes directly to `main` multiple times a day, using "Feature Flags" to hide unfinished work. (Fastest velocity).

</td></tr>
</table>

<a id="q-13-5"></a>

<table>
<tr><th align="left">13.5 Have you worked with AWS or Azure?</th></tr>
<tr><td>

**Interview Ready Answer:**
*(Pick one or mention both).*
- **Azure:** Being a .NET developer, I have extensive experience with Azure. I've used Azure App Services for hosting APIs, Azure SQL Database, and Azure Key Vault for managing secrets.
- **AWS:** I've worked with AWS services like EC2 for virtual servers, S3 for file storage, and RDS for managed databases.

</td></tr>
</table>

<a id="q-13-6"></a>

<table>
<tr><th align="left">13.6 What AWS services have you used?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Compute:** EC2 (Virtual Machines), Lambda (Serverless Functions), ECS/EKS (Containers).
- **Storage:** S3 (Object Storage), EBS (Block Storage).
- **Database:** RDS (SQL), DynamoDB (NoSQL).
- **Networking:** VPC, Route 53 (DNS), CloudFront (CDN).
- **Security:** IAM, Secrets Manager.

</td></tr>
</table>

<a id="q-13-7"></a>

<table>
<tr><th align="left">13.7 What is CI/CD?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **CI (Continuous Integration):** The practice of automatically building and testing your code every single time a developer pushes to the repository. This catches bugs early.
- **CD (Continuous Deployment/Delivery):** The practice of automatically deploying the successfully tested code to a production (or staging) environment. This ensures the software is always in a releasable state.

</td></tr>
</table>

<a id="q-13-8"></a>

<table>
<tr><th align="left">13.8 What is Docker?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** A platform that allows you to package an application and all its dependencies (runtime, libraries, configs) into a single, standardized unit called a **Container**.
- **Benefit:** "It works on my machine" becomes "It works everywhere." A Docker container will run exactly the same way on a developer's laptop, a staging server, or a production cloud environment.

</td></tr>
</table>

<a id="q-13-9"></a>

<table>
<tr><th align="left">13.9 What is Kubernetes?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **Definition:** An open-source **Orchestration** platform for managing containerized applications at scale.
- **Purpose:** If you have 100 Docker containers running, Kubernetes handles:
  - **Self-healing:** Automatically restarting containers that crash.
  - **Auto-scaling:** Adding more instances during high traffic.
  - **Load Balancing:** Distributing traffic across healthy containers.

</td></tr>
</table>

<a id="q-13-10"></a>

<table>
<tr><th align="left">13.10 What is environment configuration management?</th></tr>
<tr><td>

**Interview Ready Answer:**
- **The Principle:** You should build your application code **once** and deploy it to Dev, Staging, and Prod without changing the binaries.
- **Implementation:** Use **Environment Variables** or configuration files (like `appsettings.json`) to store environment-specific data (like database connection strings). Sensitive data should never be in the code; it should be stored in a secure vault like **Azure Key Vault** or **AWS Secrets Manager**.

**[⬆ Back to Top](#table-of-contents)**

<a id="section-14"></a>
## 14. Coding Questions Asked

</td></tr>
</table>

<a id="q-14-1"></a>

<table>
<tr><th align="left">14.1 Find number closest to zero.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-2"></a>

<table>
<tr><th align="left">14.2 FizzBuzz problem.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-3"></a>

<table>
<tr><th align="left">14.3 Progressive substring printing.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-4"></a>

<table>
<tr><th align="left">14.4 Array or string iteration problems.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-5"></a>

<table>
<tr><th align="left">14.5 Divisibility logic problems.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-6"></a>

<table>
<tr><th align="left">14.6 Basic loop and condition problems.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-14-7"></a>

<table>
<tr><th align="left">14.7 Simple optimization logic problems.</th></tr>
<tr><td>

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

</td></tr>
</table>

<a id="q-3-17"></a>

<table>
<tr><th align="left">3.17 Your new question here?</th></tr>
<tr><td>

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

</td></tr>
</table>
