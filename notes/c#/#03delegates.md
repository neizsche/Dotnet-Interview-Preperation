
# Delegates and events

**Delegates** are type-safe pointers to methods, enabling flexible method invocation. They are often used for callbacks, event handling, and implementing the observer pattern. Delegates can point to static or instance methods and can be multicast (pointing to multiple methods).

```csharp
public delegate int Operation(int x, int y);

public int Add(int a, int b) => a + b;
public int Multiply(int a, int b) => a * b;

// Usage
Operation op = Add;
int result = op(3, 4); // 7
op += Multiply; // Multicast delegate
```

**Events** are built on delegates and provide a way for classes to notify subscribers when something happens. Events are typically used in GUI applications and other scenarios where you want to decouple the event source from the event handler.

```csharp:
public class Button
{
    public event EventHandler Clicked;

    protected virtual void OnClicked() =>
        Clicked?.Invoke(this, EventArgs.Empty);
}

// Usage
var button = new Button();
button.Clicked += (sender, args) => Console.WriteLine("Clicked!");
```

**Quick mental model**

- Delegates represent behavior you can call; events represent notifications other code may observe.
- Reach for delegates when you need callback-style composition and events when you need publisher/subscriber ownership boundaries.
- If you expose a delegate directly, outside code can replace or invoke it; if you expose an event, outside code is intentionally more constrained.

**Behind the covers**

- A delegate instance usually stores a target object reference plus a method pointer.
- Multicast delegates maintain an invocation list, so adding handlers effectively creates a new delegate chain.
- Event syntax typically compiles to controlled `add` and `remove` accessors around a backing delegate field.

**Additional resources**:

- [Delegates (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)
- [Events (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/events-overview)

### Interview Prep

**Senior Perspective (The "Why")**

- Delegates model behavior; events model controlled notification.
- That distinction matters because delegates are callable references, while events deliberately restrict who can trigger or replace the invocation list.
- Strong answers connect this topic to callbacks, observer-style design, and ownership boundaries.
- `Good opening answer:` "A delegate is a callable behavior reference; an event is the restricted publication surface built on top of that idea."
- `Then add:` mention ownership, subscription lifetime, and why unsubscribe strategy matters in long-lived publishers.

**Interview Gotchas & Confusion Points**

- Multicast delegates execute handlers in order, but only the last return value is preserved when the delegate returns a value.
- Events are built on delegates, but outside code cannot raise the event directly.
- Event subscriptions can create memory leaks when long-lived publishers keep subscribers alive.
- Candidates often describe delegates and events as the same thing, which sounds shallow in interviews.

**Corner Cases**

- Anonymous lambdas are hard to unsubscribe unless you retain the exact delegate reference.
- One failing event handler can prevent later handlers from running.
- Event invocation in multithreaded code still needs care because subscribers can change during execution.
- Custom delegate types can improve readability when `Func<>` or `Action<>` becomes too generic.

**Behind the Scenes / Internal Logic**

- A delegate instance conceptually stores both the target object and the method to call.
- A multicast delegate keeps an invocation list, which is why multiple handlers can be attached to a single delegate or event.
- An event usually exposes controlled `add` / `remove` accessors so only the declaring type can trigger it directly.

**Must Remember Facts**

- `Action`, `Func`, and `Predicate` cover many common delegate scenarios.
- Delegates are immutable objects.
- `EventHandler` and `EventHandler<TEventArgs>` are the conventional .NET event patterns.
- Events are a constrained, encapsulated delegate-based notification mechanism.

**Question Bank (Common Questions + What to Say)**

- `Q: What is the difference between a delegate and an event?`<br>
  `What to say:` A delegate is a callable reference to methods. An event is a restricted publication mechanism built on delegates, where outside code can usually subscribe and unsubscribe but cannot raise the event directly.<br>
  `Focus on:` behavior pointer vs controlled notification boundary.
- `Q: What is a multicast delegate, and how does its return value behave?`<br>
  `What to say:` A multicast delegate has an invocation list and calls handlers in order. If it has a return type, only the last handler's return value is preserved.<br>
  `Focus on:` invocation list plus last-return-value rule.
- `Q: Why can event subscriptions cause memory leaks?`<br>
  `What to say:` Because the publisher can keep a reference to the subscriber through the delegate. If the publisher lives longer, the subscriber may never be collected unless it unsubscribes.<br>
  `Focus on:` object lifetime and retained references.
- `Q: Why can code subscribe to an event but not invoke it directly?`<br>
  `What to say:` Because events intentionally restrict invocation to the declaring type. That preserves ownership and prevents outside code from arbitrarily firing lifecycle notifications.<br>
  `Focus on:` encapsulation and controlled publication.
- `Q: When would you use a custom delegate type instead of Func<> or Action<>?`<br>
  `What to say:` Use `Func<>` and `Action<>` for generic callback shapes. Use a custom delegate when the signature deserves domain meaning or clearer readability in the API.<br>
  `Focus on:` semantic clarity over raw convenience.

  ### What is a delegate in C#? How is it different from a function pointer in C++?

**Answer:**
### Delegate in C#:
1. **Definition** :
- A delegate in C# is a type that represents references to methods with a particular parameter list and return type. It essentially acts as a function pointer in C#. 
2. **Syntax** :

```csharp
delegate returnType DelegateName(parameters);
```
3. **Usage** :
- Delegates are used to define callback methods and implement event handling, among other things.
- They allow methods to be passed as parameters to other methods.
- They enable defining and using anonymous methods and lambda expressions. 
4. **Example** :

```csharp
delegate int MathOperation(int a, int b);

class Calculator {
    public int Add(int a, int b) {
        return a + b;
    }

    public int Multiply(int a, int b) {
        return a * b;
    }
}

class Program {
    static void Main(string[] args) {
        Calculator calc = new Calculator();
        MathOperation operation = calc.Add;
        int result = operation(5, 3); // result will be 8
    }
}
```
5. **Multicast Delegates** :
- Delegates in C# support multicast, meaning they can reference multiple methods. 
6. **Event Handling** :
- Delegates are widely used in C# for implementing event handling mechanism, where they serve as a way to encapsulate and manage methods that are called when events occur.
### Difference from Function Pointers in C++:
1. **Type Safety** :
- Delegates in C# are type-safe, meaning they are bound to a specific method signature. Attempts to assign a method with a different signature will result in a compile-time error. In contrast, function pointers in C++ are not inherently type-safe. 
2. **Object-Oriented** :
- Delegates in C# are object-oriented and can be associated with instances of classes. They are thus compatible with object-oriented programming principles. Function pointers in C++ are more low-level constructs and lack the object-oriented features of delegates. 
3. **Event Handling** :
- Delegates in C# are often used for event handling, providing a higher level of abstraction and encapsulation compared to function pointers in C++, which are typically used for more low-level operations. 
4. **Syntax** :
- The syntax for declaring and using delegates in C# is different from function pointers in C++. C# provides a more streamlined syntax for defining delegates and working with them, making them easier to use and understand in many cases.

In summary, while both delegates in C# and function pointers in C++ serve similar purposes of referencing methods/functions dynamically, delegates offer additional features such as type safety, object-oriented capabilities, and built-in support for event handling.

---
### Explain the concept of multicast delegates. Provide an example.

**Answer:**
### Multicast Delegates in C#:

Multicast delegates in C# are delegates that can hold references to multiple methods. They allow you to call multiple methods through a single delegate invocation. Multicast delegates are commonly used in scenarios where you want to invoke multiple methods in response to an event or perform multiple operations with a single delegate invocation.
### Example of Multicast Delegates:

```csharp
using System;

delegate void MyDelegate(string message);

class Program
{
    static void Main(string[] args)
    {
        MyDelegate delegate1 = Method1;
        MyDelegate delegate2 = Method2;

        // Combining delegates using the "+" operator
        MyDelegate multicastDelegate = delegate1 + delegate2;

        // Invoking the multicast delegate will call both Method1 and Method2
        multicastDelegate("Hello from multicast delegate!");

        Console.ReadLine();
    }

    static void Method1(string message)
    {
        Console.WriteLine("Method1: " + message);
    }

    static void Method2(string message)
    {
        Console.WriteLine("Method2: " + message);
    }
}
```



In this example: 
- We define a delegate type `MyDelegate` that takes a string parameter. 
- We define two methods `Method1` and `Method2` that match the delegate signature. 
- We create instances of `MyDelegate` using each method. 
- We then combine these delegates into a single multicast delegate `multicastDelegate` using the `+` operator. 
- When we invoke `multicastDelegate`, both `Method1` and `Method2` will be called, and the message will be passed to each method. 
- Running this code will produce the following output:

```vbnet
Method1: Hello from multicast delegate!
Method2: Hello from multicast delegate!
```
### Notes:
- The order of invocation of the methods is the same as the order in which they were combined.
- If any of the methods in the multicast delegate throws an exception, the subsequent methods will not be called, and the exception will propagate back to the caller. 
- You can also remove delegates from a multicast delegate using the `-` operator or the `Delegate.Remove()` method.
- Multicast delegates are commonly used in event handling scenarios where multiple subscribers need to be notified when an event occurs.

---
### What is an event in C#? How is it implemented?

**Answer:**
### Events in C#:

In C#, an event is a mechanism that enables a class or object to notify other classes or objects when something of interest occurs. Events are a key part of the observer design pattern, allowing for loose coupling between components in a system.
### Key Concepts: 
1. **Publisher/Subscriber Model** :
- In the event-driven programming model, there are typically two parties involved: the publisher (or sender) and the subscriber (or receiver).
- The publisher is responsible for raising the event when a particular action or condition occurs.
- The subscriber is interested in receiving notifications about the event and registers itself to handle those notifications. 
2. **Event Declaration** : 
- Events are declared using the `event` keyword in C#.
- Events are based on delegates and can only be invoked from within the declaring class or a derived class.
- Typically, events are declared as members of a class and are often exposed publicly to allow external classes to subscribe to them. 
3. **Event Handlers** :
- Event handlers are methods that are invoked when the event occurs.
- Event handlers are associated with events using delegate types that match the signature of the event.
- Multiple event handlers can be attached to the same event, allowing for multiple subscribers to be notified when the event is raised. 
4. **Publishing Events** : 
- To raise (or publish) an event, the publisher invokes the event using the event invocation syntax (`eventName?.Invoke(this, EventArgs)`).
- The event can include additional information by passing parameters to the event handler method.
### Example of Event Implementation:

```csharp
using System;

// Define custom event arguments if needed
public class CustomEventArgs : EventArgs
{
    public string Message { get; set; }

    public CustomEventArgs(string message)
    {
        Message = message;
    }
}

public class Publisher
{
    // Declare an event using EventHandler delegate
    public event EventHandler<CustomEventArgs> MyEvent;

    public void DoSomething()
    {
        Console.WriteLine("Something is happening...");
        // Raise the event
        OnMyEvent("Event message");
    }

    protected virtual void OnMyEvent(string message)
    {
        MyEvent?.Invoke(this, new CustomEventArgs(message));
    }
}

public class Subscriber
{
    public void Subscribe(Publisher publisher)
    {
        // Subscribe to the event
        publisher.MyEvent += HandleEvent;
    }

    public void HandleEvent(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        // Subscribe to the event
        subscriber.Subscribe(publisher);

        // Trigger the event
        publisher.DoSomething();

        Console.ReadLine();
    }
}
```



In this example: 
- `Publisher` declares an event named `MyEvent` using the `EventHandler<CustomEventArgs>` delegate. 
- `Subscriber` subscribes to the `MyEvent` event by attaching its `HandleEvent` method as an event handler. 
- When `Publisher` calls `DoSomething()`, it raises the `MyEvent`, and all subscribed `Subscriber` instances receive notifications through their `HandleEvent` method.
### Notes:
- Events provide a powerful way to implement the observer pattern, facilitating loosely coupled communication between objects.
- Events are commonly used in GUI programming, asynchronous programming, and many other scenarios where a class needs to notify other classes about changes or occurrences.

---
### How do you subscribe to and unsubscribe from events in C#?

**Answer:**
In C#, subscribing to and unsubscribing from events involves adding and removing event handlers to and from the event. This is typically done using the `+=` operator to subscribe and the `-=` operator to unsubscribe. Here's how you can subscribe to and unsubscribe from events:
### Subscribing to Events:

To subscribe to an event, you attach an event handler method to the event using the `+=` operator.

```csharp
publisher.MyEvent += HandleEvent;
```



In this example, `publisher` is the instance of the class declaring the event, `MyEvent` is the event, and `HandleEvent` is the method that will handle the event.
### Unsubscribing from Events:

To unsubscribe from an event, you detach the event handler method from the event using the `-=` operator.

```csharp
publisher.MyEvent -= HandleEvent;
```



This removes the `HandleEvent` method from the list of event handlers for `MyEvent`.
### Example:

```csharp
public class Subscriber
{
    public void Subscribe(Publisher publisher)
    {
        // Subscribe to the event
        publisher.MyEvent += HandleEvent;
    }

    public void Unsubscribe(Publisher publisher)
    {
        // Unsubscribe from the event
        publisher.MyEvent -= HandleEvent;
    }

    public void HandleEvent(object sender, CustomEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}
```



In this example, `Subscribe` method subscribes to the event, and `Unsubscribe` method unsubscribes from the event by adding and removing the `HandleEvent` method to and from the event, respectively.
### Notes:
- It's important to properly manage event subscriptions and unsubscriptions to prevent memory leaks and unexpected behavior.
- Subscribing multiple times to the same event with the same handler will result in the handler being invoked multiple times when the event is raised.
- Unsubscribing from an event that hasn't been subscribed to has no effect and won't throw an exception.

---
### Can you explain the concept of event-driven programming in the context of C#?

**Answer:**
Certainly! Event-driven programming is a programming paradigm where the flow of the program is determined by events such as user actions (e.g., mouse clicks, keyboard presses), system notifications, or messages from other programs. In the context of C#, event-driven programming is commonly used in graphical user interface (GUI) applications, web development, and asynchronous programming.
### Key Concepts of Event-Driven Programming in C#: 
1. **Events** :
- Events are occurrences that happen during the execution of a program, such as user actions or system notifications. 
- In C#, events are represented by the `event` keyword and are typically declared as members of classes.
- Events are based on delegates and allow one class (the publisher) to notify other classes (the subscribers) when a specific action or condition occurs. 
2. **Event Handlers** :
- Event handlers are methods that respond to events when they are raised.
- In C#, event handlers are typically methods with a specific signature that matches the delegate associated with the event. 
- Event handlers are attached to events using the `+=` operator and are executed when the event is raised. 
3. **Publishers and Subscribers** :
- In the event-driven programming model, there are typically two parties involved: publishers and subscribers.
- Publishers are responsible for raising events when specific actions or conditions occur.
- Subscribers are interested in receiving notifications about these events and register themselves to handle those notifications. 
4. **Loose Coupling** :
- Event-driven programming promotes loose coupling between components in a system.
- Publishers and subscribers are independent of each other, and the communication between them is facilitated through events.
- This allows for better modularity, scalability, and maintainability of the codebase. 
5. **Asynchronous Programming** :
- Event-driven programming is often used in asynchronous programming models, where code execution is not blocked while waiting for certain operations to complete.
- Asynchronous operations, such as I/O operations or user interactions, are handled through events and event handlers.
### Example:

In a GUI application written in C#, event-driven programming is used to handle user interactions with the interface. For instance, when a user clicks a button on a form, a `Click` event is raised by the button control. The application can subscribe to this event and execute a specific method (event handler) in response to the click event. This allows the application to respond dynamically to user actions without blocking the main thread of execution.

```csharp
button.Click += HandleButtonClick;

void HandleButtonClick(object sender, EventArgs e)
{
    // Perform actions in response to the button click event
}
```



In this example, `HandleButtonClick` is an event handler method that is executed when the `Click` event of the `button` control is raised. This follows the event-driven programming paradigm, where the flow of the program is determined by user actions triggering events and the corresponding event handlers responding to those events.

---
### What are some advantages of using events and delegates in software development?

**Answer:**
Using events and delegates in software development offers several advantages, including:
1. **Loose Coupling** : Events and delegates facilitate loose coupling between components in a system. Publishers and subscribers are decoupled, allowing changes to one component without affecting others. This promotes modularity and easier maintenance of the codebase. 
2. **Flexibility and Extensibility** : Events and delegates enable flexible and extensible architectures. New functionalities can be added by subscribing to existing events or creating new events without modifying existing code. This makes it easier to adapt the system to changing requirements. 
3. **Asynchronous Programming** : Delegates are commonly used in asynchronous programming models to execute code asynchronously without blocking the main thread. This improves responsiveness and scalability, especially in GUI applications and network programming. 
4. **Event-Driven Programming** : Events and delegates are fundamental to event-driven programming paradigms, where the flow of the program is determined by events such as user actions or system notifications. This allows for dynamic and responsive user interfaces and efficient handling of asynchronous operations. 
5. **Decoupling Layers of an Application** : Events and delegates can be used to decouple different layers of an application, such as the presentation layer and the business logic layer. For example, UI elements can raise events that are handled by business logic components, keeping the presentation layer separated from the application logic. 
6. **Testing and Debugging** : Events and delegates facilitate testing and debugging by allowing for easier isolation of components. Mock objects can be used to simulate events and test event handlers independently, improving the testability of the code. 
7. **Cross-Cutting Concerns** : Delegates can be used to implement cross-cutting concerns such as logging, error handling, and authentication. By attaching event handlers to specific events, these concerns can be addressed in a centralized manner without scattering the codebase. 
8. **Encapsulation and Information Hiding** : Events and delegates promote encapsulation and information hiding by allowing objects to expose only the events they want to be publicly accessible. This helps in building more maintainable and scalable systems by hiding implementation details from external components.

Overall, events and delegates are powerful constructs in C# and other programming languages that offer numerous benefits in terms of modularity, flexibility, responsiveness, and maintainability of software systems.

---
### Understanding the lifecycle of delegates and event handlers.

**Answer:**
Understanding the lifecycle of delegates and event handlers involves grasping how they are created, used, and managed throughout the execution of a program. Here's an overview of their lifecycle:
### Delegates: 
1. **Creation** : Delegates are created by defining a delegate type and instantiating it with a method or a lambda expression that matches its signature. 
2. **Invocation** : Delegates can be invoked to execute the method(s) they reference. Multiple methods can be combined into a single delegate using the `+` operator. 
3. **Execution** : When a delegate is invoked, it executes the methods it references in the order they were added. Each method is executed synchronously. 
4. **Completion** : After all methods have been executed, the delegate invocation completes, and control returns to the caller. 
5. **Garbage Collection** : Delegates are reference types and are subject to garbage collection. If no references to a delegate exist, it will be eligible for garbage collection.
### Event Handlers: 
1. **Subscription** : Event handlers are methods that are registered to handle events raised by an object. They are typically subscribed to events using the `+=` operator. 
2. **Execution** : When the event occurs, all registered event handlers are invoked in the order they were subscribed. Event handlers execute synchronously. 
3. **Unsubscription** : Event handlers can be unsubscribed from events using the `-=` operator. This removes them from the list of event handlers, preventing them from being invoked when the event occurs. 
4. **Completion** : After all registered event handlers have been invoked, control returns to the code that raised the event. 
5. **Lifetime Management** : Event handlers can have a shorter lifetime than the object raising the event. If an event handler is not properly unsubscribed, it can lead to memory leaks as the object holding a reference to the event handler prevents it from being garbage collected. 
6. **Thread Safety** : Event handlers should be written with thread safety in mind, especially in multithreaded applications. It's important to consider synchronization mechanisms to ensure proper handling of events in concurrent scenarios.
### Summary:
- Delegates are used to represent references to methods, while event handlers are methods that handle events raised by objects.
- Delegates and event handlers have lifecycles that involve creation, invocation or subscription, execution when triggered, unsubscription, and potential garbage collection.
- Proper management of delegates and event handlers, including subscription and unsubscription, is important to prevent memory leaks and ensure the correct behavior of the application.
- Considerations such as thread safety and lifetime management are crucial when working with event handlers, especially in complex or multithreaded applications.

---
### Best practices for managing memory and preventing memory leaks with delegates.

**Answer:**
Managing memory and preventing memory leaks when working with delegates is crucial for ensuring the stability and performance of your application. Here are some best practices:
### 1. Unsubscribe from Events:
- Always unsubscribe from events when they are no longer needed, especially in long-lived objects or when dynamically subscribing to events.
- Failing to unsubscribe from events can lead to memory leaks because the event source holds a reference to the event handler, preventing garbage collection.
### 2. Use Weak Event Patterns:
- Consider using weak event patterns to prevent memory leaks when subscribing to events.
- Weak event patterns use weak references to the event handlers, allowing them to be garbage collected even if the event source still holds a reference to them.
### 3. Avoid Capturing Unnecessary References:
- Be cautious when capturing references to objects in closures or anonymous methods, especially in long-lived delegates.
- Capturing unnecessary references can inadvertently keep objects alive longer than necessary, leading to memory leaks.
### 4. Implement IDisposable for Custom Delegates:
- If you create custom delegates or types that manage resources, implement the IDisposable interface to properly release resources when they are no longer needed.
- Dispose any resources held by the delegate when it is no longer needed or when the object owning the delegate is disposed.
### 5. Use Weak References:
- Consider using weak references to hold references to objects that are used as event handlers or delegates.
- Weak references allow objects to be garbage collected even if there are other references to them, preventing memory leaks.
### 6. Profile and Monitor Memory Usage:
- Profile and monitor memory usage of your application to detect any memory leaks caused by delegates.
- Use memory profiling tools to identify objects that are being held in memory longer than necessary and investigate potential causes.
### 7. Avoid Circular References:
- Be mindful of circular references between objects and delegates, as they can prevent objects from being garbage collected.
- Break circular references by using weak references or by redesigning the object relationships if necessary.
### 8. Test and Validate:
- Test your application thoroughly to ensure that delegates are properly managed and that no memory leaks occur under different usage scenarios.
- Perform memory leak detection and stress testing to identify any potential issues before deploying your application to production.

By following these best practices, you can effectively manage memory and prevent memory leaks when working with delegates in your applications, leading to improved performance and stability.

---
### How does garbage collection handle delegate instances?

**Answer:**
Garbage collection in .NET manages memory by reclaiming memory that is no longer in use, allowing it to be reused by the application. When it comes to delegate instances, garbage collection treats them like any other reference type objects. Here's how garbage collection handles delegate instances:
### 1. Reference Counting:
- Garbage collection in .NET does not use reference counting to track object lifetimes. Instead, it uses a tracing garbage collector that determines which objects are still reachable by the application.
### 2. Reachability Analysis:
- The garbage collector starts with a set of root objects, such as global variables, local variables, and object references on the stack.
- It then performs reachability analysis to traverse the object graph, identifying objects that are reachable from the roots. Any objects that are not reachable are considered garbage and eligible for collection.
### 3. Delegate Instances and Reachability:
- Delegate instances are considered reachable if they are referenced by root objects, local variables, or other reachable objects in the application.
- If a delegate instance is not reachable from any root object or other reachable objects, it becomes eligible for garbage collection.
### 4. Weak References:
- Weak references can be used to hold references to delegate instances without preventing them from being garbage collected.
- Weak references allow you to maintain a reference to an object while still allowing it to be collected if there are no strong references to it.
### 5. Finalization:
- Before an object is reclaimed by the garbage collector, its Finalize method (if defined) is called for cleanup tasks.
- However, delegate instances do not have finalizers by default, so they do not incur the performance overhead associated with finalization.
### 6. Timing of Garbage Collection:
- Garbage collection occurs periodically based on various factors such as memory pressure, generation sizes, and allocation rates.
- The exact timing of garbage collection is determined by the garbage collector itself and is not under direct control of the application.
### Summary:

Garbage collection in .NET treats delegate instances like any other reference type objects. It relies on reachability analysis to determine whether an object, including delegate instances, is still in use by the application. If a delegate instance is no longer reachable, it becomes eligible for garbage collection, and its memory is reclaimed for future use by the application.

---



<div id="generics"></div>

# Generics

Generics let you define type-safe, reusable classes, methods, and interfaces. They improve code reuse, type safety, and performance by avoiding boxing/unboxing overhead.

## Generic classes

```csharp
public class Repository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public T Get(int index) => _items[index];
}

// Usage
var intRepo = new Repository<int>();
intRepo.Add(42);
int number = intRepo.Get(0);
```

## Generic methods

```csharp
public T Echo<T>(T input) => input;

// Usage
string message = Echo("Hello");
int number = Echo(123);
```

## Constraints

```csharp
public class EmployeeRepository<T> where T : Employee, new()
{
    public T Create() => new T();
}
```

**Quick mental model**

- Generics let you write one abstraction that stays strongly typed for every concrete type it is used with.
- Good generic design is about expressing the minimum contract the implementation really needs, not maximizing cleverness.
- A generic API becomes stronger when its constraints explain what operations are valid and what assumptions are safe.

**Behind the covers**

- `List<int>` and `List<string>` are distinct closed generic types known to the runtime, which is why generics in .NET are not just erased templates.
- Invariant generic types protect type safety by preventing unsafe substitutions like treating `List<string>` as `List<object>`.
- Static fields on a generic type exist separately for each closed type argument combination.

### Interview Prep

**Senior Perspective (The "Why")**

- Generics let you express reusable behavior without giving up type safety.
- They reduce casts, avoid many `object`-style APIs, and often avoid boxing overhead.
- Strong answers frame generics as both a correctness tool and an API-design tool.
- A well-designed generic abstraction makes invalid usage harder at compile time.
- `Good opening answer:` "Generics are mainly about type-safe reuse and compile-time guarantees, with performance as a secondary benefit."
- `Then add:` mention invariance and constraints early, then bring in boxing avoidance and reusable API design as supporting points.

**Interview Gotchas & Confusion Points**

- Generics are invariant by default, so `List<string>` is not a `List<object>`.
- Variance applies only to certain interfaces and delegates.
- Constraint order matters, and `new()` must come last.
- Many candidates know constraint syntax but cannot explain why a constraint exists.

**Corner Cases**

- `default(T)` may be `null`, zero, or a default-initialized struct depending on `T`.
- An unconstrained `T` gives you very limited assumptions about construction, operators, and nullability.
- Static state on generic types is maintained per closed type, such as `Cache<int>` vs `Cache<string>`.
- Generic abstractions can become too vague if constraints do not communicate intent.

**Behind the Scenes / Internal Logic**

- .NET generics are reified at runtime, which means the runtime knows about the actual closed generic type such as `List<int>` vs `List<string>`.
- Constraints are used by the compiler and runtime to decide what operations are legal and what guarantees a generic implementation can rely on.
- Static members on generic types are effectively tracked per closed generic type, which is why `Repository<int>` and `Repository<string>` do not share the same static field values.

**Must Remember Facts**

- Generic method type arguments are often inferred.
- Common constraints include `class`, `struct`, `notnull`, `unmanaged`, and `new()`.
- `where T : new()` requires a public parameterless constructor.
- Type safety, invariance, and constraints are the core interview themes here.

**Question Bank (Common Questions + What to Say)**

- `Q: Why are generics better than using object everywhere?`<br>
  `What to say:` Generics preserve compile-time type safety, reduce casting, and often avoid boxing. They make APIs clearer because the contract says what type the abstraction actually works with.<br>
  `Focus on:` type safety, clarity, and performance.
- `Q: What does invariance mean in C# generics?`<br>
  `What to say:` Invariance means `List<string>` is not assignable to `List<object>` even though `string` is assignable to `object`. The type arguments must match exactly unless variance is explicitly supported.<br>
  `Focus on:` why generic collections are not automatically substitutable.
- `Q: When do covariance and contravariance apply?`<br>
  `What to say:` They apply only to certain interfaces and delegates. Covariance is about returning more specific types safely, and contravariance is about accepting more general input types safely.<br>
  `Focus on:` limited support plus input/output direction.
- `Q: What does where T : new() actually guarantee?`<br>
  `What to say:` It guarantees that `T` has a public parameterless constructor, so the generic code can create an instance with `new T()`.<br>
  `Focus on:` public parameterless construction.
- `Q: What are the risks of using default(T) blindly?`<br>
  `What to say:` You may get `null`, zero, or a default-initialized struct that violates business invariants. It is only safe when you truly understand what `T` can be.<br>
  `Focus on:` default value ambiguity.
- `Q: Why is List<string> not assignable to List<object>?`<br>
  `What to say:` Because generic collections like `List<T>` are invariant. Allowing that conversion would let callers insert an `object` that is not a `string`, which would break type safety.<br>
  `Focus on:` invariance protecting mutation safety.
- `Q: Why do generic constraints matter in interviews?`<br>
  `What to say:` They show that you know how to express the minimum guarantees generic code depends on. A good constraint makes misuse fail at compile time and makes the abstraction more self-documenting.<br>
  `Focus on:` compile-time guarantees and API design.

**Additional resources**:

- [Generics (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)


### Explanation of generics in .NET and their benefits.

**Answer:**
Generics in .NET provide a way to create classes, structures, methods, and interfaces with placeholders for data types. This allows you to write code that can work with any data type while still maintaining type safety. Here's an explanation of generics and their benefits:
### Explanation of Generics: 
1. **Type Parameter** :
- Generics allow you to define placeholders, called type parameters, for data types in classes, methods, structures, and interfaces.
- These type parameters can be used within the generic construct to define the types of parameters, fields, return types, etc. 
2. **Reusability** :
- Generics enable you to write code that can be reused with different data types without having to rewrite the code for each type.
- This promotes code reuse and reduces code duplication, leading to more maintainable and scalable codebases. 
3. **Type Safety** :
- Generics provide compile-time type checking, ensuring that the code is type-safe.
- The compiler enforces type constraints specified on the generic type parameters, preventing runtime errors related to type mismatches. 
4. **Performance** :
- Generics improve performance by avoiding the need for boxing and unboxing operations when working with value types.
- Unlike non-generic code that operates on objects (which requires boxing value types into objects), generic code operates directly on the underlying value types, leading to better performance. 
5. **Code Clarity** :
- Generics improve code clarity and maintainability by making the code more expressive and self-documenting.
- Using generics, you can write code that explicitly states its intention to work with a specific data type, making it easier for other developers to understand and maintain the code.
### Benefits of Generics: 
1. **Flexibility** :
- Generics allow you to write highly flexible code that can adapt to different data types without sacrificing type safety.
- This flexibility makes generics suitable for a wide range of scenarios, from collections and algorithms to data structures and utilities. 
2. **Performance Optimization** :
- By avoiding boxing and unboxing operations, generics improve the performance of code, especially when working with value types.
- This can lead to significant performance improvements in scenarios where performance is critical, such as high-performance computing or large-scale data processing. 
3. **Reduced Code Duplication** :
- Generics enable you to write generic algorithms, data structures, and components that can be reused with different data types.
- This reduces code duplication and promotes a more modular and maintainable codebase by centralizing common functionality. 
4. **Type Safety and Compile-Time Checking** :
- Generics provide type safety and compile-time checking, ensuring that type-related errors are caught at compile time rather than at runtime.
- This helps in identifying and fixing issues early in the development process, reducing the likelihood of runtime errors and improving code reliability. 
5. **Improved Developer Productivity** :
- Generics simplify the development process by allowing developers to write generic code that can be used with various data types.
- This improves developer productivity by reducing the need to write and maintain specialized code for each data type, leading to faster development cycles and shorter time-to-market.

Overall, generics in .NET offer a powerful mechanism for writing reusable, type-safe, and efficient code, leading to improved code quality, performance, and developer productivity. They are a fundamental feature of the .NET framework and are widely used across various domains, from application development to system programming.

---
### Writing generic classes, methods, and interfaces.

**Answer:**
Certainly! Below are examples of how to write generic classes, methods, and interfaces in C#:
### 1. Generic Class:

```csharp
public class GenericClass<T>
{
    private T _value;

    public GenericClass(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }
}
```



In this example, `GenericClass<T>` is a generic class with a single type parameter `T`. The constructor takes a parameter of type `T`, and the `GetValue` method returns the stored value of type `T`.
### 2. Generic Method:

```csharp
public class GenericMethod
{
    public T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}
```



Here, `Max` is a generic method that takes two parameters of type `T`. The `where T : IComparable<T>` constraint ensures that the type `T` implements the `IComparable<T>` interface, allowing comparison between the values.
### 3. Generic Interface:

```csharp
public interface IGenericInterface<T>
{
    T GetValue();
}
```



This is a generic interface `IGenericInterface<T>` with a single type parameter `T`. Any class implementing this interface must provide an implementation for the `GetValue` method, which returns a value of type `T`.
### Usage Examples:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Using generic class
        GenericClass<int> intClass = new GenericClass<int>(10);
        Console.WriteLine("Value: " + intClass.GetValue()); // Output: Value: 10

        // Using generic method
        GenericMethod genericMethod = new GenericMethod();
        Console.WriteLine("Max value: " + genericMethod.Max(5, 10)); // Output: Max value: 10

        // Using generic interface
        class Implementation : IGenericInterface<string>
        {
            public string GetValue()
            {
                return "Hello, world!";
            }
        }

        Implementation implementation = new Implementation();
        Console.WriteLine("Value: " + implementation.GetValue()); // Output: Value: Hello, world!
    }
}
```



In this example, we create instances of the generic class, call the generic method, and implement the generic interface. Each usage demonstrates how generics provide flexibility in working with different data types while maintaining type safety.

---
### Advantages of using generics over non-generic solutions.

**Answer:**
Using generics over non-generic solutions offers several advantages:
### 1. Type Safety: 
- **Generics** : With generics, the compiler enforces type safety at compile time. This ensures that the code operates on the correct data types, reducing the risk of runtime type errors. 
- **Non-Generic** : Non-generic solutions often rely on casting and boxing/unboxing operations, which can lead to runtime type errors if not handled correctly.
### 2. Code Reusability: 
- **Generics** : Generic classes, methods, and interfaces can be reused with different data types without modification. This promotes code reusability and reduces code duplication. 
- **Non-Generic** : Non-generic solutions may require separate implementations for each data type, leading to code duplication and maintenance overhead.
### 3. Performance: 
- **Generics** : Generics improve performance by avoiding boxing and unboxing operations for value types. They operate directly on the underlying data types, leading to better performance. 
- **Non-Generic** : Non-generic solutions may involve unnecessary overhead due to boxing and unboxing operations, especially when working with value types.
### 4. Compile-Time Checking: 
- **Generics** : Generics provide compile-time checking for type constraints and method signatures. This helps in identifying type-related errors early in the development process. 
- **Non-Generic** : Non-generic solutions may rely on runtime type checking, which can lead to errors that are discovered only at runtime.
### 5. Code Clarity and Maintainability: 
- **Generics** : Generics improve code clarity and maintainability by making the code more expressive and self-documenting. They explicitly specify the intended data types, making the code easier to understand and maintain. 
- **Non-Generic** : Non-generic solutions may require additional documentation or comments to clarify the expected data types, leading to less readable code.
### 6. Flexibility: 
- **Generics** : Generics provide flexibility in working with different data types without sacrificing type safety. They allow developers to write highly flexible and adaptable code. 
- **Non-Generic** : Non-generic solutions may be less flexible and require modification to support new data types or scenarios.
### 7. Scalability: 
- **Generics** : Generics facilitate scalable solutions by allowing developers to write generic algorithms, data structures, and components that can be reused and extended as the application evolves. 
- **Non-Generic** : Non-generic solutions may become less scalable as the codebase grows, leading to maintenance challenges and potential performance bottlenecks.

In summary, generics offer several advantages over non-generic solutions, including improved type safety, code reusability, performance, compile-time checking, code clarity, flexibility, and scalability. They are a powerful feature of the .NET framework and are widely used to write efficient, type-safe, and maintainable code.

---
### Understanding generic type constraints (e.g., class, struct, new(), interface).

**Answer:**
Generic type constraints in C# allow you to restrict the types that can be used as type arguments for a generic type parameter. These constraints specify the capabilities or characteristics that the type argument must have. Here are the common generic type constraints:
### 1. `where T : class`: 
- **Description** : Requires the type argument `T` to be a reference type (class). It cannot be a value type. 
- **Example** :

```csharp
public class MyClass<T> where T : class
{
    // Implementation
}
```
### 2. `where T : struct`: 
- **Description** : Requires the type argument `T` to be a value type (struct). It cannot be a reference type. 
- **Example** :

```csharp
public class MyClass<T> where T : struct
{
    // Implementation
}
```
### 3. `where T : new()`: 
- **Description** : Requires the type argument `T` to have a public parameterless constructor. This allows you to create new instances of `T` within the generic type or method. 
- **Example** :

```csharp
public class MyClass<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```
### 4. `where T : <base class>`: 
- **Description** : Requires the type argument `T` to be derived from or implement a specified base class or interface. 
- **Example** :

```csharp
public class MyClass<T> where T : MyBaseClass
{
    // Implementation
}
```
### 5. `where T : <interface>`: 
- **Description** : Requires the type argument `T` to implement a specified interface. 
- **Example** :

```csharp
public class MyClass<T> where T : IDisposable
{
    // Implementation
}
```
### 6. Combining Constraints: 
- You can combine multiple constraints using the `where` keyword and separating them with commas. 
- **Example** :

```csharp
public class MyClass<T> where T : MyBaseClass, IDisposable, new()
{
    // Implementation
}
```
### Usage Examples:

```csharp
public class Repository<T> where T : class
{
    public void Add(T item)
    {
        // Implementation
    }
}

public class Calculator<T> where T : struct
{
    public T Add(T a, T b)
    {
        return (dynamic)a + (dynamic)b;
    }
}

public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```



In these examples: 
- `Repository<T>` accepts only reference types (`class`) as type arguments. 
- `Calculator<T>` accepts only value types (`struct`) as type arguments. 
- `Factory<T>` requires type arguments with a parameterless constructor (`new()`).

---
### How do constraints help in writing more robust and maintainable code?

**Answer:**
Constraints in generic programming help in writing more robust and maintainable code by enforcing rules and requirements on the type arguments used with generic types or methods. Here's how constraints contribute to code robustness and maintainability:
### 1. Type Safety: 
- Constraints ensure that type arguments meet specific criteria, such as being a reference type (`class`) or a value type (`struct`). This prevents unexpected behavior or runtime errors due to incompatible types.
### 2. Encapsulation of Assumptions:
- Constraints encapsulate assumptions about the capabilities or characteristics of type arguments. This makes the code more self-documenting and communicates the intended usage of generic types or methods to other developers.
### 3. Compiler Warnings and Errors:
- Constraints result in compiler warnings or errors if type arguments do not satisfy the specified criteria. This helps in detecting type-related issues early in the development process, leading to fewer bugs and better code quality.
### 4. Improved Readability:
- Constraints improve the readability of code by explicitly stating the requirements for type arguments. Developers can easily understand the constraints and make informed decisions when using generic types or methods.
### 5. Preventing Runtime Errors:
- Constraints prevent runtime errors by ensuring that type arguments possess the necessary capabilities or characteristics required by the generic type or method. This reduces the likelihood of runtime exceptions or crashes due to incompatible types.
### 6. Code Reusability:
- Constraints promote code reusability by specifying generic types or methods that can work with a wide range of type arguments. This reduces code duplication and encourages the creation of generic components that can be reused across different parts of the codebase.
### 7. Ease of Maintenance:
- Constraints make code maintenance easier by providing clear guidelines on the types that can be used with generic types or methods. Developers can quickly understand the constraints and make changes or updates to the code with confidence, knowing that type-related issues are handled appropriately.
### 8. Enforcing Design Contracts:
- Constraints enforce design contracts by specifying the expectations and requirements for type arguments. This helps in designing robust and maintainable software architectures by enforcing consistency and adherence to design principles.

In summary, constraints in generic programming contribute to code robustness and maintainability by enforcing type safety, encapsulating assumptions, providing compiler feedback, improving readability, preventing runtime errors, promoting code reusability, facilitating maintenance, and enforcing design contracts. By leveraging constraints effectively, developers can write more reliable, scalable, and maintainable software solutions.

---
### Examples of using constraints in generic programming scenarios.

**Answer:**
Certainly! Here are some examples of using constraints in generic programming scenarios:
### 1. Repository with Class Constraint:

```csharp
public class Repository<T> where T : class
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T GetById(int id)
    {
        // Implementation
    }
}
```



In this example, `Repository<T>` is a generic class constrained to accept only reference types (`class`). This ensures that only class objects can be stored in the repository.
### 2. Calculator with Struct Constraint:

```csharp
public class Calculator<T> where T : struct
{
    public T Add(T a, T b)
    {
        return (dynamic)a + (dynamic)b;
    }
}
```



Here, `Calculator<T>` is a generic class constrained to accept only value types (`struct`). This ensures that the `Add` method can work with numeric value types like `int`, `float`, `double`, etc.
### 3. Factory with New Constraint:

```csharp
public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}
```



In this example, `Factory<T>` is a generic class constrained to accept only type arguments with a parameterless constructor (`new()`). This allows the factory to create instances of the specified type using the default constructor.
### 4. Generic Sorting Algorithm with Interface Constraint:

```csharp
public class SortingAlgorithm<T> where T : IComparable<T>
{
    public void Sort(T[] array)
    {
        // Sorting implementation using comparison via IComparable<T>
    }
}
```



Here, `SortingAlgorithm<T>` is a generic class constrained to accept only type arguments that implement the `IComparable<T>` interface. This ensures that the elements of the array can be compared and sorted.
### 5. Data Transformer with Multiple Constraints:

```csharp
public class DataTransformer<TInput, TOutput>
    where TInput : class
    where TOutput : struct
{
    public TOutput Transform(TInput input)
    {
        // Transformation logic from TInput to TOutput
    }
}
```



In this example, `DataTransformer<TInput, TOutput>` is a generic class constrained to accept: 
- `TInput` as a reference type (`class`). 
- `TOutput` as a value type (`struct`).
This allows the transformer to work with reference types as input and value types as output.

These examples demonstrate how constraints in generic programming scenarios enforce requirements and ensure type safety, contributing to more robust and maintainable code.

---
### Explaining covariance and contravariance in the context of generics.

**Answer:**
Covariance and contravariance are concepts related to the inheritance relationships between generic types. They specify how the inheritance relationship between types is preserved when using generic types with different type arguments. These concepts are important in ensuring type safety and flexibility when working with generic types. Let's explore each concept:
### Covariance:

Covariance allows you to use a more derived type (a derived class or interface) as a type argument where a less derived type (a base class or interface) is expected. In other words, it enables you to treat a generic type as more specific than originally specified.

In C#, covariance is supported in scenarios involving interfaces and delegates. It is denoted by the `out` keyword.

Example of covariance with interfaces:

```csharp
public interface IAnimal { }
public class Dog : IAnimal { }
public class Cat : IAnimal { }

public interface IAnimalShelter<out T>
{
    T GetAnimal();
}

public class AnimalShelter<T> : IAnimalShelter<T>
{
    private T _animal;

    public AnimalShelter(T animal)
    {
        _animal = animal;
    }

    public T GetAnimal()
    {
        return _animal;
    }
}
```



In this example, `IAnimalShelter<out T>` is covariant in `T`, meaning that you can use a more derived type (`Dog` or `Cat`) as `T` where `IAnimalShelter<IAnimal>` is expected. This allows for more flexibility when working with generic interfaces.
### Contravariance:

Contravariance allows you to use a less derived type as a type argument where a more derived type is expected. In other words, it enables you to treat a generic type as less specific than originally specified.

In C#, contravariance is supported only in delegate types. It is denoted by the `in` keyword.

Example of contravariance with delegates:

```csharp
public delegate void AnimalHandler<in T>(T animal);

public class AnimalHandlerHelper
{
    public static void HandleAnimal(IAnimal animal)
    {
        Console.WriteLine($"Handling {animal.GetType().Name}");
    }
}
```



In this example, `AnimalHandler<in T>` is contravariant in `T`, meaning that you can use a less derived type (`IAnimal`) as `T` where `AnimalHandler<Dog>` or `AnimalHandler<Cat>` is expected. This allows for more flexibility when passing arguments to delegate methods.
### Summary:
- Covariance allows you to use a more derived type as a type argument.
- Contravariance allows you to use a less derived type as a type argument.
- Covariance is supported in interfaces and return types of methods, while contravariance is supported only in delegate types and method parameter types. 
- Covariance is denoted by the `out` keyword, while contravariance is denoted by the `in` keyword.

---
### Differences between covariance and contravariance in tabular form
Here's a comparison between covariance and contravariance in a tabular form:

| Aspect                   | Covariance                                                                                                                                                                                                | Contravariance                                                                                                                                                                                                                 |
| ------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Definition               | Covariance allows the use of a more derived type (subclass) as the type argument where a less derived type (base class) is expected.                                                                      | Contravariance allows the use of a less derived type (base class) as the type argument where a more derived type (subclass) is expected.                                                                                       |
| Denoted by               | `out` keyword in C#                                                                                                                                                                                       | `in` keyword in C#                                                                                                                                                                                                             |
| Applicable to            | Interfaces and delegates                                                                                                                                                                                  | Delegates                                                                                                                                                                                                                      |
| Example                  | `IEnumerable<out T>`                                                                                                                                                                                      | `Comparison<in T>`                                                                                                                                                                                                             |
| Usage                    | Enables returning a more specific type from a method, such as returning `IEnumerable<Derived>` from a method that specifies `IEnumerable<Base>`.                                                          | Enables passing a less specific type to a method, such as passing `Comparison<Base>` to a method that expects `Comparison<Derived>`.                                                                                           |
| Example Scenario         | A method returning a collection of objects, where the method can return a more specialized collection (e.g., `List<Derived>`) when a less specialized collection (e.g., `IEnumerable<Base>`) is expected. | A method accepting a comparison function, where the method can accept a less specialized comparison function (e.g., `Comparison<Base>`) when a more specialized comparison function (e.g., `Comparison<Derived>`) is expected. |
| Direction of Inheritance | From the more derived type (subclass) to the less derived type (base class).                                                                                                                              | From the less derived type (base class) to the more derived type (subclass).                                                                                                                                                   |
| Use Cases                | Commonly used for read-only scenarios, such as enumerating collections.                                                                                                                                   | Commonly used for write-only or contravariant scenarios, such as passing parameter inputs.                                                                                                                                     |

These differences illustrate how covariance and contravariance provide flexibility when working with generic types, allowing you to write more flexible and reusable code in certain scenarios.


---

### 1. Generics: Classes & Methods
Generics allow you to use a placeholder (usually `T`) for a type.

* **Generic Classes:** `List<T>`, `Repository<T>`. The type is defined when the class is instantiated.
* **Generic Methods:** `public void Swap<T>(ref T a, ref T b)`. The type is inferred or specified when the method is called.

**The "Senior" Detail: Reification**
In .NET, generics are **reified**. This means the runtime knows the type at execution time. 
* If you use `List<int>`, the JIT compiler creates a specialized version of the class optimized for `int` (no boxing).
* If you use `List<string>`, it creates a version for reference types (sharing the same machine code because pointers are the same size).



---

### 2. Constraints (`where T : ...`)
Constraints restrict what types can be used for `T`, allowing you to call specific methods on the object.

| Constraint         | Syntax                  | Meaning                                               |
| :----------------- | :---------------------- | :---------------------------------------------------- |
| **Value Type**     | `where T : struct`      | `T` must be a value type (like `int`, `DateTime`).    |
| **Reference Type** | `where T : class`       | `T` must be a reference type (like `string`, `User`). |
| **Constructor**    | `where T : new()`       | `T` must have a public parameterless constructor.     |
| **Base Class**     | `where T : Entity`      | `T` must inherit from or be `Entity`.                 |
| **Interface**      | `where T : IComparable` | `T` must implement the interface.                     |
| **Not-Null**       | `where T : notnull`     | `T` cannot be a nullable type.                        |

---

### 3. Variance: Invariance, Covariance, Contravariance
This is how "assignment compatibility" works between generic types.

#### A. Invariance (The Default)
By default, generics are invariant. `List<Dog>` is **not** a `List<Animal>`, even if `Dog` inherits from `Animal`. 
* **Why?** Because if you could cast `List<Dog>` to `List<Animal>`, you could try to add a `Cat` to a list of `Dogs`, crashing the app.

#### B. Covariance (`out T`)
Allows you to use a more derived type than originally specified.
* **Keyword:** `out` (Think: Data is only coming **OUT**).
* **Example:** `IEnumerable<out T>`. 
* **Logic:** `IEnumerable<string>` can be treated as `IEnumerable<object>`. This is safe because you can't "Add" to an `IEnumerable`, so you can't break the list's type integrity.

#### C. Contravariance (`in T`)
Allows you to use a more generic type than originally specified.
* **Keyword:** `in` (Think: Data is only going **IN**).
* **Example:** `Action<in T>`, `IComparer<in T>`.
* **Logic:** If you have an `Action<object>` (which can log any object), it is perfectly safe to use it as an `Action<string>`.



---

### 📊 Summary Table for Study Notes

| Term               | Direction                      | Keyword | Example          | Use Case                |
| :----------------- | :----------------------------- | :------ | :--------------- | :---------------------- |
| **Invariance**     | Fixed                          | None    | `List<T>`        | Read/Write collections. |
| **Covariance**     | Specific $\rightarrow$ General | `out`   | `IEnumerable<T>` | Read-only / Producers.  |
| **Contravariance** | General $\rightarrow$ Specific | `in`    | `IComparer<T>`   | Write-only / Consumers. |

---

### 📝 Final Note for your Markdown

```markdown
### Generics & Variance
* **Performance:** Generics avoid boxing/unboxing and allow the JIT to optimize code for specific types.
* **Constraints:** Use `where` to limit `T`. Always use `new()` if your factory needs to instantiate `T`.
* **Covariance (out):** Safe for reading. `IEnumerable<string>` -> `IEnumerable<object>`.
* **Contravariance (in):** Safe for writing/consuming. `Action<object>` -> `Action<string>`.
* **Best Practice:** When designing interfaces, use `out` and `in` markers to make your API more flexible for consumers.
```

---


<div id="classes-and-inheritance"></div>
