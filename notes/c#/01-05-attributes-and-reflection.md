# Attributes and Reflection - Complete Guide

## 📚 **1. Custom Attribute Creation**

### **Surface Level Knowledge**
Attributes are metadata tags that add declarative information to code elements (classes, methods, properties, etc.). They don't affect runtime behavior directly but can be read via reflection.

### **Deep Knowledge**

#### **Creating Custom Attributes**
```csharp
// 1. Basic Attribute Creation
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, 
                AllowMultiple = false, 
                Inherited = true)]
public class CustomAttribute : Attribute
{
    public string Description { get; }
    public int Version { get; set; }
    
    public CustomAttribute(string description)
    {
        Description = description;
        Version = 1;
    }
}

// Usage
[Custom("This is a sample class", Version = 2)]
public class MyClass
{
    [Custom("This is a sample method")]
    public void MyMethod() { }
}
```

#### **Attribute Usage Parameters Deep Dive**
```csharp
[AttributeUsage(
    AttributeTargets.Class |        // Where attribute can be applied
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true,           // Can multiple attributes of same type be applied?
    Inherited = false               // Does derived class inherit the attribute?
)]
public class AdvancedAttribute : Attribute { }

// AllowMultiple = true allows this:
[Advanced]
[Advanced]  // This is allowed
public class MyClass { }

// Inherited = false means:
[Advanced]
public class BaseClass { }

public class DerivedClass : BaseClass { } // DerivedClass WON'T have the attribute
```

#### **Advanced Attribute Patterns**
```csharp
// Parameterized attributes with validation
public class ValidationAttribute : Attribute
{
    private int _minLength;
    
    public int MinLength 
    { 
        get => _minLength;
        set 
        {
            if (value < 0) throw new ArgumentException("MinLength cannot be negative");
            _minLength = value;
        }
    }
    
    public ValidationAttribute(int minLength)
    {
        MinLength = minLength;
    }
}

// Conditional attribute based on compilation symbols
[Conditional("DEBUG")]
public class DebugOnlyAttribute : Attribute { }
```

---

## 🔍 **2. Reflection for Type Inspection and Dynamic Invocation**

### **Surface Level Knowledge**
Reflection allows examining and interacting with types, methods, properties, etc., at runtime. It's powerful but has performance implications.

### **Deep Knowledge**

#### **Type Inspection Deep Dive**
```csharp
using System.Reflection;

public class SampleClass
{
    public string PublicProperty { get; set; }
    private int PrivateField;
    public void PublicMethod() { }
    private void PrivateMethod() { }
}

// Comprehensive type inspection
Type type = typeof(SampleClass);

// Get all members with binding flags
var allMembers = type.GetMembers(BindingFlags.Public | 
                                BindingFlags.NonPublic | 
                                BindingFlags.Instance | 
                                BindingFlags.Static);

// Categorized inspection
var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); // Private fields
var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

// Attribute inspection on types and members
var classAttributes = type.GetCustomAttributes(typeof(CustomAttribute), false);
var methodAttributes = type.GetMethod("PublicMethod")?.GetCustomAttributes(false);
```

#### **Dynamic Invocation Patterns**
```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
    private int Multiply(int a, int b) => a * b;
}

// Dynamic invocation with error handling
object calculator = new Calculator();
Type calcType = calculator.GetType();

// Public method invocation
MethodInfo addMethod = calcType.GetMethod("Add");
int result = (int)addMethod.Invoke(calculator, new object[] { 5, 3 });

// Private method invocation (requires NonPublic flag)
MethodInfo multiplyMethod = calcType.GetMethod("Multiply", 
    BindingFlags.NonPublic | BindingFlags.Instance);
int privateResult = (int)multiplyMethod.Invoke(calculator, new object[] { 4, 5 });

// Generic method invocation
public class GenericClass<T>
{
    public T Process(T input) => input;
}

Type genericType = typeof(GenericClass<>);
Type constructedType = genericType.MakeGenericType(typeof(string));
object instance = Activator.CreateInstance(constructedType);
MethodInfo processMethod = constructedType.GetMethod("Process");
string output = (string)processMethod.Invoke(instance, new object[] { "hello" });
```

#### **Performance-Optimized Reflection**
```csharp
// Using Delegates for performance
public class OptimizedReflection
{
    private delegate int AddDelegate(int a, int b);
    private AddDelegate _addDelegate;
    
    public void CompileMethod()
    {
        MethodInfo method = typeof(Calculator).GetMethod("Add");
        _addDelegate = (AddDelegate)Delegate.CreateDelegate(typeof(AddDelegate), method);
    }
    
    public int FastAdd(int a, int b) => _addDelegate(a, b); // Much faster than Invoke()
}

// Using Expression Trees for dynamic code generation
public static class ExpressionReflection
{
    public static Func<object, object[]> CreateMethodInvoker(MethodInfo method)
    {
        var instanceParam = Expression.Parameter(typeof(object), "instance");
        var parametersParam = Expression.Parameter(typeof(object[]), "parameters");
        
        var parameters = method.GetParameters();
        var arguments = new Expression[parameters.Length];
        
        for (int i = 0; i < parameters.Length; i++)
        {
            arguments[i] = Expression.Convert(
                Expression.ArrayIndex(parametersParam, Expression.Constant(i)),
                parameters[i].ParameterType);
        }
        
        var call = Expression.Call(
            Expression.Convert(instanceParam, method.DeclaringType),
            method,
            arguments);
            
        var lambda = Expression.Lambda<Func<object, object[], object>>(
            Expression.Convert(call, typeof(object)),
            instanceParam, parametersParam);
            
        return lambda.Compile();
    }
}
```

---

## ⚡ **3. Dynamic Type Creation (AssemblyBuilder, TypeBuilder)**

### **Surface Level Knowledge**
Dynamically create types, methods, and assemblies at runtime using Reflection.Emit. Used for code generation, AOP, and dynamic proxies.

### **Deep Knowledge**

#### **Basic Dynamic Type Creation**
```csharp
using System.Reflection;
using System.Reflection.Emit;

public class DynamicTypeCreator
{
    public static Type CreateDynamicType()
    {
        // Create dynamic assembly
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
            assemblyName, AssemblyBuilderAccess.Run);
            
        // Create dynamic module
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        
        // Create dynamic type
        TypeBuilder typeBuilder = moduleBuilder.DefineType(
            "DynamicClass", 
            TypeAttributes.Public | TypeAttributes.Class);
            
        // Add fields
        FieldBuilder fieldBuilder = typeBuilder.DefineField(
            "_value", 
            typeof(int), 
            FieldAttributes.Private);
            
        // Add property
        PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(
            "Value",
            PropertyAttributes.HasDefault,
            typeof(int),
            null);
            
        // Add getter method
        MethodBuilder getMethodBuilder = typeBuilder.DefineMethod(
            "get_Value",
            MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
            typeof(int),
            Type.EmptyTypes);
            
        // Implement getter
        ILGenerator getIl = getMethodBuilder.GetILGenerator();
        getIl.Emit(OpCodes.Ldarg_0);
        getIl.Emit(OpCodes.Ldfld, fieldBuilder);
        getIl.Emit(OpCodes.Ret);
        
        propertyBuilder.SetGetMethod(getMethodBuilder);
        
        // Add setter method
        MethodBuilder setMethodBuilder = typeBuilder.DefineMethod(
            "set_Value",
            MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
            null,
            new[] { typeof(int) });
            
        // Implement setter
        ILGenerator setIl = setMethodBuilder.GetILGenerator();
        setIl.Emit(OpCodes.Ldarg_0);
        setIl.Emit(OpCodes.Ldarg_1);
        setIl.Emit(OpCodes.Stfld, fieldBuilder);
        setIl.Emit(OpCodes.Ret);
        
        propertyBuilder.SetSetMethod(setMethodBuilder);
        
        // Add constructor
        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            Type.EmptyTypes);
            
        ILGenerator constructorIl = constructorBuilder.GetILGenerator();
        constructorIl.Emit(OpCodes.Ldarg_0);
        constructorIl.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        constructorIl.Emit(OpCodes.Ret);
        
        // Create the type
        return typeBuilder.CreateType();
    }
}
```

#### **Advanced Dynamic Method Generation**
```csharp
public class AdvancedDynamicCreation
{
    public static Delegate CreateDynamicMethod()
    {
        // Create dynamic method
        DynamicMethod dynamicMethod = new DynamicMethod(
            "DynamicAdd",
            typeof(int),
            new[] { typeof(int), typeof(int) },
            typeof(AdvancedDynamicCreation).Module);
            
        // Generate IL
        ILGenerator il = dynamicMethod.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);  // Load first argument
        il.Emit(OpCodes.Ldarg_1);  // Load second argument
        il.Emit(OpCodes.Add);      // Add them
        il.Emit(OpCodes.Ret);      // Return result
        
        // Create delegate
        return dynamicMethod.CreateDelegate(typeof(Func<int, int, int>));
    }
    
    // Usage
    public static void UseDynamicMethod()
    {
        var dynamicAdd = (Func<int, int, int>)CreateDynamicMethod();
        int result = dynamicAdd(10, 20); // Returns 30
    }
}
```

#### **Dynamic Proxy Generation (AOP)**
```csharp
public interface IService
{
    void Execute();
}

public class DynamicProxyGenerator
{
    public static IService CreateProxy(IService realService)
    {
        AssemblyName assemblyName = new AssemblyName("ProxyAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
            assemblyName, AssemblyBuilderAccess.Run);
            
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType(
            "ServiceProxy",
            TypeAttributes.Public | TypeAttributes.Class,
            typeof(object),
            new[] { typeof(IService) });
            
        // Add field for real service
        FieldBuilder serviceField = typeBuilder.DefineField(
            "_realService",
            typeof(IService),
            FieldAttributes.Private);
            
        // Add constructor
        ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(
            MethodAttributes.Public,
            CallingConventions.Standard,
            new[] { typeof(IService) });
            
        ILGenerator constructorIl = constructorBuilder.GetILGenerator();
        constructorIl.Emit(OpCodes.Ldarg_0);
        constructorIl.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        constructorIl.Emit(OpCodes.Ldarg_0);
        constructorIl.Emit(OpCodes.Ldarg_1);
        constructorIl.Emit(OpCodes.Stfld, serviceField);
        constructorIl.Emit(OpCodes.Ret);
        
        // Implement interface method with logging
        MethodBuilder executeMethod = typeBuilder.DefineMethod(
            "Execute",
            MethodAttributes.Public | MethodAttributes.Virtual,
            typeof(void),
            Type.EmptyTypes);
            
        ILGenerator executeIl = executeMethod.GetILGenerator();
        
        // Log before execution
        executeIl.Emit(OpCodes.Ldstr, "Before Execute");
        executeIl.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
        
        // Call real service
        executeIl.Emit(OpCodes.Ldarg_0);
        executeIl.Emit(OpCodes.Ldfld, serviceField);
        executeIl.Emit(OpCodes.Callvirt, typeof(IService).GetMethod("Execute"));
        
        // Log after execution
        executeIl.Emit(OpCodes.Ldstr, "After Execute");
        executeIl.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
        
        executeIl.Emit(OpCodes.Ret);
        
        // Override the interface method
        typeBuilder.DefineMethodOverride(executeMethod, typeof(IService).GetMethod("Execute"));
        
        Type proxyType = typeBuilder.CreateType();
        return (IService)Activator.CreateInstance(proxyType, realService);
    }
}
```

---

## 📊 **Comparison Tables**

### **AttributeUsage vs Without AttributeUsage**
| Aspect | With AttributeUsage | Without AttributeUsage |
|--------|---------------------|------------------------|
| **Target Control** | Explicit control over where attribute can be applied | Can be applied anywhere |
| **Multiple Usage** | Controlled via AllowMultiple | Always allows multiple (like Obsolete) |
| **Inheritance** | Controlled via Inherited | Default inheritance behavior |
| **Compile-time Safety** | Prevents invalid usage | No compile-time restrictions |
| **When to Use** | Custom business attributes | Simple metadata attributes |

### **Reflection Methods Comparison**
| Method | Performance | Use Case | Flexibility |
|--------|-------------|----------|-------------|
| **Type.GetMethod()** | Medium | Simple method lookup | Limited binding control |
| **Type.GetMethods()** | Slow | Getting all methods | Returns array, needs filtering |
| **BindingFlags combination** | Fast (with cache) | Precise member lookup | Complex but powerful |
| **Delegate.CreateDelegate()** | Very Fast | High-performance scenarios | Requires known signature |
| **MethodInfo.Invoke()** | Slow | Dynamic invocation | Most flexible |

### **Dynamic Creation Techniques**
| Technique | Complexity | Performance | Use Cases |
|-----------|------------|-------------|-----------|
| **Activator.CreateInstance()** | Low | Medium | Simple object creation |
| **TypeBuilder (Reflection.Emit)** | High | Fast (after creation) | Complex dynamic types |
| **DynamicMethod** | Medium | Very Fast | Lightweight method generation |
| **Expression Trees** | Medium | Fast (after compilation) | LINQ providers, dynamic queries |

---

## ❓ **Probable Interview Questions & Answers**

### **1. Basic Questions**

**Q: What are attributes in C# and how do they differ from comments?**
```csharp
// A: Attributes are metadata that can be read at runtime via reflection, 
// while comments are completely ignored by the compiler.

[Serializable]  // This is an attribute - can be read via reflection
public class MyClass 
{
    // This is a comment - completely removed during compilation
    public void Method() { }
}
```
**Reasoning:** Attributes provide runtime metadata, comments are for developers only.

**Q: How do you create a custom attribute?**
```csharp
// A: Create a class deriving from Attribute and use AttributeUsage to define usage rules
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; }
    public MyCustomAttribute(string description) => Description = description;
}
```
**Reasoning:** Must inherit from Attribute class and can define usage constraints.

### **2. Intermediate Questions**

**Q: What's the difference between `GetCustomAttributes()` and `GetCustomAttributes(true)`?**
```csharp
// A: The boolean parameter controls inheritance lookup
var attributes = type.GetCustomAttributes(false);  // Only direct attributes
var allAttributes = type.GetCustomAttributes(true); // Includes inherited attributes

// Example:
[MyAttribute]
class Base { }

class Derived : Base { }

// GetCustomAttributes(false) on Derived returns empty
// GetCustomAttributes(true) on Derived returns MyAttribute (if Inherited=true)
```
**Reasoning:** The `inherit` parameter controls whether to search the inheritance chain.

**Q: How can you improve reflection performance?**
```csharp
// A: Use caching and delegate creation
public class OptimizedReflector
{
    private static Dictionary<string, MethodInfo> _methodCache = new();
    private static Dictionary<string, Delegate> _delegateCache = new();
    
    public static Delegate CreateOptimizedInvoker(Type type, string methodName)
    {
        string key = $"{type.FullName}.{methodName}";
        
        if (!_delegateCache.TryGetValue(key, out var delegate))
        {
            var method = type.GetMethod(methodName);
            delegate = Delegate.CreateDelegate(typeof(Action), method);
            _delegateCache[key] = delegate;
        }
        
        return delegate;
    }
}
```
**Reasoning:** Reflection is slow - caching and delegate creation provide significant performance gains.

### **3. Advanced/Tricky Questions**

**Q: When would you use Reflection.Emit vs Expression Trees?**
```csharp
// A: Reflection.Emit for low-level IL generation, Expression Trees for higher-level code generation

// Reflection.Emit - More control, more complex
ILGenerator il = methodBuilder.GetILGenerator();
il.Emit(OpCodes.Ldarg_0);
il.Emit(OpCodes.Ldfld, fieldBuilder);

// Expression Trees - Easier to work with, less control
Expression<Func<int, int, int>> add = (a, b) => a + b;
```
**Reasoning:** Expression Trees are safer and easier but Reflection.Emit offers more low-level control.

**Q: How do you handle versioning with custom attributes?**
```csharp
// A: Use optional parameters and version-aware reflection
[AttributeUsage(AttributeTargets.Class)]
public class VersionedAttribute : Attribute
{
    public int Version { get; set; } = 1;  // Default version
    public string Description { get; }
    
    public VersionedAttribute(string description) => Description = description;
}

// Reading with version awareness
var attr = (VersionedAttribute)type.GetCustomAttribute(typeof(VersionedAttribute));
if (attr.Version >= 2) 
{
    // Handle new version behavior
}
```
**Reasoning:** Optional properties allow backward compatibility when reading attributes.

**Q: What are the security implications of using reflection?**
```csharp
// A: Reflection can bypass access modifiers and create security vulnerabilities

// Dangerous: Accessing private members
var privateField = type.GetField("_password", BindingFlags.NonPublic | BindingFlags.Instance);
string password = (string)privateField.GetValue(instance);

// Safer: Use with appropriate permissions and validation
if (type.IsPublic && method.IsPublic)  // Validate accessibility
{
    method.Invoke(instance, parameters);
}
```
**Reasoning:** Reflection can break encapsulation - must be used carefully with proper security checks.

### **4. Tricky Follow-up Questions**

**Q: Why would `GetCustomAttributes()` return an empty array even when attributes are present?**
```csharp
// A: Common reasons:
// 1. Wrong BindingFlags
var attributes = type.GetCustomAttributes(typeof(MyAttribute), false);
// Should use: type.GetCustomAttributes(typeof(MyAttribute), true) for inheritance

// 2. Attribute not inherited and applied to base class
[MyAttribute(Inherited = false)]
class Base { }
class Derived : Base { } // GetCustomAttributes on Derived returns empty

// 3. Attribute usage doesn't include the target
[AttributeUsage(AttributeTargets.Class)]
public class MyAttribute : Attribute { }

[MyAttribute]  // This works
class MyClass { }

[MyAttribute]  // Compile error - not allowed on methods
void MyMethod() { }
```
**Reasoning:** Understanding AttributeUsage parameters and inheritance behavior is crucial.

**Q: How do you create a generic type dynamically using reflection?**
```csharp
// A: Use MakeGenericType with type arguments
Type openGenericType = typeof(List<>);
Type closedGenericType = openGenericType.MakeGenericType(typeof(string));
object stringList = Activator.CreateInstance(closedGenericType);

// For methods:
MethodInfo openMethod = typeof(Enumerable).GetMethod("Where");
Type[] typeArgs = { typeof(string) };
MethodInfo closedMethod = openMethod.MakeGenericMethod(typeArgs);
```
**Reasoning:** Generic type construction requires two steps: get open type, then make it closed.

**Q: What's the difference between `Type.GetType()` and `typeof()`?**
```csharp
// A: typeof() is compile-time, GetType() is runtime and can work with strings
Type type1 = typeof(string);  // Compile-time known type
Type type2 = Type.GetType("System.String");  // Runtime type resolution
Type type3 = someObject.GetType();  // Runtime type of instance

// GetType() can return null if type not found, typeof() always works
Type type4 = Type.GetType("NonExistent.Type");  // Returns null
```
**Reasoning:** `typeof()` is for known types at compile time, `GetType()` for dynamic type resolution.

This comprehensive guide covers everything from basic attribute usage to advanced dynamic type creation, with practical examples and interview-focused explanations.
