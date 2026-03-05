# Exception Handling - Complete Deep Dive

## 📚 **Comprehensive Knowledge Base**

### **1. try-catch-finally Blocks**

#### **Basic Structure**
```csharp
try
{
    // Code that might throw an exception
    riskyOperation();
}
catch (SpecificException ex)
{
    // Handle specific exception
    logger.LogError(ex, "Specific error occurred");
}
catch (AnotherException ex)
{
    // Handle another specific exception
    logger.LogError(ex, "Another error occurred");
}
catch (Exception ex)
{
    // Catch-all for any other exceptions
    logger.LogError(ex, "Unexpected error occurred");
}
finally
{
    // Code that always executes (cleanup)
    resource?.Dispose();
}
```

#### **Deep Understanding**

**Execution Flow:**
1. **try block** executes normally
2. If exception occurs → execution jumps to matching **catch block**
3. **finally block** executes **regardless** of whether exception occurred
4. Control passes to next statement after try-catch-finally

**Key Points:**
- Multiple catch blocks are evaluated from **most specific to most general**
- **finally block always executes** - even with return statements or exceptions in catch blocks
- Exceptions in finally block will override original exception

```csharp
public string RiskyMethod()
{
    try
    {
        throw new InvalidOperationException("Original error");
        return "success"; // This never executes
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Caught: {ex.Message}");
        return "caught"; // This executes but finally runs first
    }
    finally
    {
        Console.WriteLine("Finally block executed");
        // If we throw here, it overrides everything!
    }
}
```

### **2. Exception Filters (when keyword)**

#### **Basic Usage**
```csharp
try
{
    riskyOperation();
}
catch (HttpRequestException ex) when (ex.StatusCode == 404)
{
    Console.WriteLine("Resource not found - handle gracefully");
}
catch (HttpRequestException ex) when (ex.StatusCode == 500)
{
    Console.WriteLine("Server error - retry logic");
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Other HTTP error");
}
```

#### **Deep Understanding**

**How Filters Work:**
- Exception filters are evaluated **before** the stack is unwound
- The stack remains intact during filter evaluation
- If filter returns false, search for matching catch continues

**Advanced Filter Patterns:**
```csharp
// Complex filter with method call
catch (SqlException ex) when (IsTransientError(ex))
{
    // Retry logic for transient errors
}

// Filter with logging that doesn't affect stack
catch (Exception ex) when (LogAndFilter(ex))
{
    // Only executes if filter returns true
}

private bool LogAndFilter(Exception ex)
{
    _logger.LogError(ex, "Exception occurred during filter evaluation");
    return ex is InvalidOperationException;
}
```

**Performance Benefit:** Stack trace remains intact during filter evaluation

### **3. Custom Exception Classes**

#### **Creating Custom Exceptions**
```csharp
[Serializable]
public class PaymentProcessingException : Exception
{
    public string PaymentId { get; }
    public decimal Amount { get; }
    public PaymentStatus Status { get; }
    
    // Basic constructors
    public PaymentProcessingException() { }
    
    public PaymentProcessingException(string message) : base(message) { }
    
    public PaymentProcessingException(string message, Exception inner) 
        : base(message, inner) { }
        
    // Custom constructor with additional data
    public PaymentProcessingException(string paymentId, decimal amount, PaymentStatus status)
        : base($"Payment {paymentId} failed with status {status}")
    {
        PaymentId = paymentId;
        Amount = amount;
        Status = status;
    }
    
    // Serialization support
    protected PaymentProcessingException(
        SerializationInfo info, StreamingContext context) : base(info, context)
    {
        PaymentId = info.GetString(nameof(PaymentId));
        Amount = info.GetDecimal(nameof(Amount));
        Status = (PaymentStatus)info.GetValue(nameof(Status), typeof(PaymentStatus));
    }
    
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(PaymentId), PaymentId);
        info.AddValue(nameof(Amount), Amount);
        info.AddValue(nameof(Status), Status);
    }
}
```

#### **Best Practices for Custom Exceptions**
- **End with "Exception" suffix**
- **Implement all standard constructors**
- **Make serializable** if crossing app domains
- **Include additional contextual data**
- **Provide meaningful error messages**

### **4. throw vs throw ex**

#### **Comparison Table**

| Aspect | `throw` | `throw ex` |
|--------|---------|------------|
| **Stack Trace** | Preserves original stack trace | **Resets** stack trace to current location |
| **Usage Scenario** | Re-throwing caught exception | **Never recommended** - loses debug info |
| **Performance** | Same | Same |
| **Debugging** | Shows original throw location | Shows re-throw location only |
| **Best Practice** | ✅ **Always use this** | ❌ **Avoid completely** |

#### **Code Examples**
```csharp
public void MethodA()
{
    try
    {
        MethodB();
    }
    catch (Exception ex)
    {
        // BAD - loses original stack trace
        // throw ex;
        
        // GOOD - preserves stack trace
        throw;
        
        // EVEN BETTER - wrap with additional context
        throw new CustomException("Additional context", ex);
    }
}

public void MethodB()
{
    throw new InvalidOperationException("Original error");
}
```

**Stack Trace Comparison:**
- **`throw;`**: Shows error originated in `MethodB()`
- **`throw ex;`**: Shows error originated in `MethodA()` - misleading!

### **5. Exception Handling Best Practices**

#### **Do's and Don'ts**

| Do | Don't |
|----|-------|
| ✅ Catch specific exceptions | ❌ Catch general Exception unless at top level |
| ✅ Use exception filters for conditional handling | ❌ Use exceptions for normal control flow |
| ✅ Provide meaningful error messages | ❌ Reveal sensitive information in errors |
| ✅ Log exceptions before re-throwing | ❌ Swallow exceptions silently |
| ✅ Use using statements for resource cleanup | ❌ Rely on finalizers for cleanup |

#### **Resource Management Patterns**
```csharp
// GOOD - using statement ensures disposal
public void ProcessFile(string path)
{
    using var stream = new FileStream(path, FileMode.Open);
    using var reader = new StreamReader(stream);
    // Automatic disposal even if exception occurs
}

// BAD - manual try-finally (verbose and error-prone)
public void ProcessFileManual(string path)
{
    FileStream stream = null;
    try
    {
        stream = new FileStream(path, FileMode.Open);
        // work with stream
    }
    finally
    {
        stream?.Dispose();
    }
}
```

---

## ❓ **Probable Interview Questions & Answers**

### **1. Basic Level Questions**

#### **Q1: What is the purpose of finally block?**
**Answer:** 
The finally block ensures that cleanup code executes regardless of whether an exception occurred. It runs:
- After successful try block completion
- After any catch block execution
- Even if there's a return statement in try/catch
- Even if another exception occurs in catch block

**Reasoning:** Critical for resource cleanup (database connections, file handles, etc.)

#### **Q2: Can we have try block without catch block?**
**Answer:** 
Yes, try-finally without catch is valid:
```csharp
try
{
    riskyOperation();
}
finally
{
    cleanup(); // Always executes
}
```
**Use case:** When you need cleanup but don't want to handle the exception at this level.

### **2. Intermediate Level Questions**

#### **Q3: What's the difference between throw and throw ex?**
**Answer:** 
```csharp
catch (Exception ex)
{
    // throw ex;    // RESETS stack trace - BAD!
    throw;          // PRESERVES stack trace - GOOD!
}
```
**Reasoning:** `throw ex` resets the stack trace, making debugging extremely difficult. Always use `throw` to preserve the original exception context.

#### **Q4: When should you create custom exceptions?**
**Answer:** Create custom exceptions when:
- You need to add domain-specific information
- You want to provide more specific exception types for callers
- You need to distinguish your exceptions from system exceptions
- You're building a library for others to use

**Example:** `PaymentDeclinedException` with `PaymentId` property is more useful than generic `InvalidOperationException`.

### **3. Advanced/Tricky Questions**

#### **Q5: What happens if exception occurs in finally block?**
**Answer:** 
If an exception occurs in finally block, it **overrides** any exception from try/catch blocks. The original exception is lost.

```csharp
try
{
    throw new Exception("Original error");
}
finally
{
    throw new Exception("Finally error"); // This becomes the actual exception!
}
// Result: "Finally error" is thrown, "Original error" is lost
```

**Best Practice:** Avoid complex logic in finally blocks. Use nested try-catch if needed.

#### **Q6: How do exception filters differ from catching and re-throwing?**
**Answer:** 
```csharp
// Filter (GOOD) - stack preserved
catch (Exception ex) when (ex.Message.Contains("timeout"))
{
    HandleTimeout();
}

// Catch and re-throw (BAD) - stack manipulation
catch (Exception ex)
{
    if (ex.Message.Contains("timeout"))
    {
        HandleTimeout();
        throw; // Stack preserved but less efficient
    }
    throw;
}
```
**Key Difference:** Filters evaluate **before stack unwind**, making them more efficient for conditional handling.

#### **Q7: What is exception swallowing and why is it dangerous?**
**Answer:** Exception swallowing is catching an exception but not handling it properly:
```csharp
// DANGEROUS - silent failure
try { riskyOperation(); }
catch { /* empty catch block */ }

// SLIGHTLY BETTER but still bad
try { riskyOperation(); }
catch (Exception ex) 
{ 
    // No logging, no re-throw, no handling
}
```
**Dangers:** 
- Bugs become invisible
- Data corruption can occur silently
- Debugging becomes extremely difficult

#### **Q8: How would you design exception handling for a web API?**
**Answer:** Use a layered approach:
```csharp
// Controller level - specific handling
[HttpPost]
public IActionResult ProcessPayment(PaymentRequest request)
{
    try
    {
        _paymentService.Process(request);
        return Ok();
    }
    catch (PaymentDeclinedException ex)
    {
        return BadRequest(ex.Message);
    }
    catch (ValidationException ex)
    {
        return BadRequest(ex.Errors);
    }
}

// Global level - catch-all with logging
public class ExceptionHandlingMiddleware
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal server error");
        }
    }
}
```

### **4. Tricky Scenario Questions**

#### **Q9: What will this code output?**
```csharp
public void TestMethod()
{
    try
    {
        Console.WriteLine("Try block");
        throw new Exception("Error in try");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Catch block: " + ex.Message);
        throw;
    }
    finally
    {
        Console.WriteLine("Finally block");
    }
    Console.WriteLine("After try-catch");
}
```

**Answer:** 
```
Try block
Catch block: Error in try
Finally block
// Exception is thrown to caller
// "After try-catch" never executes
```

#### **Q10: What's wrong with this exception handling?**
```csharp
public void ProcessData()
{
    try
    {
        foreach (var item in GetItems())
        {
            ProcessItem(item);
        }
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error processing data");
        throw ex; // PROBLEM HERE!
    }
}
```

**Problems:**
1. **`throw ex`** resets stack trace
2. **Catches Exception** too broadly
3. **Stops entire processing** on first error

**Better approach:**
```csharp
public void ProcessData()
{
    foreach (var item in GetItems())
    {
        try
        {
            ProcessItem(item);
        }
        catch (SpecificException ex)
        {
            _logger.LogError(ex, $"Failed to process item {item.Id}");
            // Continue with next item
        }
    }
}
```

### **5. Performance & Best Practices Questions**

#### **Q11: Are exceptions expensive in .NET?**
**Answer:** Yes, exceptions are relatively expensive because:
- Stack trace capture has overhead
- Exception object creation is costly
- Runtime has to walk stack for handlers

**Best Practices:**
- Use exceptions for **exceptional** conditions only
- Use `TryParse` pattern for expected failures:
```csharp
// GOOD - for expected failures
if (int.TryParse(input, out var result))
{
    UseResult(result);
}

// BAD - using exceptions for control flow
try
{
    var result = int.Parse(input);
    UseResult(result);
}
catch (FormatException)
{
    // Expected failure case
}
```

#### **Q12: How should exceptions be handled in async methods?**
**Answer:** Async methods should:
1. **Not swallow exceptions** - they propagate to caller
2. **Use specific exception types** for expected errors
3. **Consider using `AggregateException`** for multiple failures

```csharp
public async Task ProcessMultipleAsync()
{
    var tasks = GetTasks();
    try
    {
        await Task.WhenAll(tasks);
    }
    catch (Exception ex) when (ex is AggregateException aggr)
    {
        // Handle multiple failures
        foreach (var inner in aggr.InnerExceptions)
        {
            _logger.LogError(inner, "Task failed");
        }
    }
}
```

---

## 🎯 **Quick Reference Table**

| Concept | When to Use | When to Avoid |
|---------|-------------|---------------|
| **try-catch** | Handling expected exceptions | Normal control flow |
| **try-finally** | Resource cleanup without handling | When using `using` statements |
| **Exception Filters** | Conditional exception handling | Simple catch scenarios |
| **Custom Exceptions** | Domain-specific error information | When built-in exceptions suffice |
| **throw** | Re-throwing caught exceptions | Never use `throw ex` |
| **Exception Logging** | All caught exceptions | Don't log and re-throw unnecessarily |

This comprehensive guide covers everything from basic concepts to advanced scenarios you'll encounter in .NET exception handling interviews. The key is understanding not just the syntax, but the performance implications, debugging considerations, and architectural patterns.
