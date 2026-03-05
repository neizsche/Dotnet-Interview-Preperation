# Arrays and Collections - Complete Guide

## 📚 **Single and Multi-dimensional Arrays**

### **Surface Level Knowledge**
```csharp
// Single-dimensional array
int[] numbers = new int[5] {1, 2, 3, 4, 5};

// Multi-dimensional array (rectangular)
int[,] matrix = new int[3,3] {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Jagged array (array of arrays)
int[][] jagged = new int[3][];
jagged[0] = new int[] {1, 2};
jagged[1] = new int[] {3, 4, 5};
```

### **Deep Understanding**

#### **Memory Layout & Performance**
```csharp
// Single-dimensional array: contiguous memory block
int[] arr = new int[1000]; // Single block of 4000 bytes (1000 * 4 bytes)

// Multi-dimensional array: single contiguous block
int[,] matrix = new int[100,100]; // 10000 elements in one block

// Jagged array: multiple memory blocks
int[][] jagged = new int[100][];
for(int i = 0; i < 100; i++)
    jagged[i] = new int[100]; // 100 separate memory blocks

// Performance implications:
// - Single/Multi-dimensional: better cache locality
// - Jagged: more flexible but worse cache performance
```

#### **Array Covariance (Important!)**
```csharp
// Arrays are covariant in C# (can lead to runtime errors)
object[] objArray = new string[10]; // This compiles!
objArray[0] = "hello"; // OK
// objArray[1] = 123; // Runtime ArrayTypeMismatchException!

// Why this exists: enables methods like Array.Sort to work with object[]
// But it's a source of potential runtime errors
```

### **Probable Interview Questions**

#### **Q1: What's the difference between these array declarations?**
```csharp
int[,] rectangular = new int[2,3];    // 2x3 matrix (6 elements)
int[][] jagged = new int[2][];        // Array of 2 arrays (can be different lengths)
```

**Answer:** 
- `rectangular` is a true 2D array with fixed dimensions
- `jagged` is an array of arrays, each sub-array can have different lengths
- Rectangular arrays have better memory locality and performance

#### **Q2: Why does this code compile but throw runtime exception?**
```csharp
object[] objects = new string[5];
objects[0] = 123; // Runtime error!
```

**Answer:** Array covariance allows string[] to be treated as object[], but you can only store strings in a string[].

#### **Q3: How would you efficiently copy a large array?**
```csharp
// For large arrays, use Buffer.BlockCopy for better performance
int[] source = new int[1000000];
int[] dest = new int[1000000];
Buffer.BlockCopy(source, 0, dest, 0, source.Length * sizeof(int));
```

---

## 📚 **List<T>, Dictionary<TKey, TValue>, HashSet<T>**

### **Surface Level Knowledge**
```csharp
List<string> names = new List<string> { "John", "Jane" };
names.Add("Bob");

Dictionary<int, string> employees = new Dictionary<int, string>();
employees.Add(1, "John");

HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 2 }; // Only {1, 2, 3}
```

### **Deep Understanding**

#### **List<T> Internals**
```csharp
public class List<T>
{
    private T[] _items;
    private int _size;
    private int _version;
    
    // Dynamic resizing: doubles capacity when full
    public void Add(T item)
    {
        if (_size == _items.Length)
        {
            // Double the capacity (amortized O(1) add operation)
            EnsureCapacity(_size + 1);
        }
        _items[_size++] = item;
        _version++;
    }
}
```

#### **Dictionary<TKey, TValue> Internals**
```csharp
// Uses hash table with buckets and entries
public class Dictionary<TKey, TValue>
{
    private struct Entry
    {
        public int hashCode;
        public int next; // Index of next entry in bucket
        public TKey key;
        public TValue value;
    }
    
    private int[] _buckets; // Bucket array
    private Entry[] _entries; // Entry array
    
    // Collision resolution: chaining within entries array
    // Load factor: resizes when ratio reaches 0.72 (default)
}
```

#### **HashSet<T> Internals**
```csharp
// Similar to Dictionary but only keys, no values
// Uses same hash table implementation
// Optimized for set operations (Union, Intersect, Except)
```

### **Probable Interview Questions**

#### **Q1: What's the time complexity of common operations?**
```csharp
// List<T>
list.Add(item);        // Amortized O(1)
list.Insert(0, item);  // O(n) - shifts all elements
list[5] = value;       // O(1) - direct index access
list.Contains(item);   // O(n) - linear search

// Dictionary<TKey, TValue>
dict.Add(key, value);  // O(1) average, O(n) worst case
dict[key] = value;     // O(1) average
dict.ContainsKey(key); // O(1) average

// HashSet<T>
set.Add(item);         // O(1) average
set.Contains(item);    // O(1) average
```

#### **Q2: When should you specify initial capacity?**
```csharp
// Good practice when you know the expected size
List<int> list = new List<int>(1000); // Avoids multiple resizes
Dictionary<string, int> dict = new Dictionary<string, int>(500);

// Resizing is expensive: new array allocation + copy all elements
```

#### **Q3: Why does Dictionary throw KeyNotFoundException?**
```csharp
Dictionary<string, int> dict = new Dictionary<string, int>();
// int value = dict["missing"]; // Throws KeyNotFoundException

// Safe alternatives:
if (dict.TryGetValue("missing", out int value)) { /* use value */ }
int val = dict.GetValueOrDefault("missing", -1);
```

#### **Q4: HashSet vs List for uniqueness - which is better?**
```csharp
// For checking uniqueness: HashSet is O(1) vs List O(n)
HashSet<int> set = new HashSet<int>();
List<int> list = new List<int>();

// Adding 1000 unique items:
set.Add(item); // ~1000 operations * O(1) = O(n)
if (!list.Contains(item)) list.Add(item); // ~1000 operations * O(n) = O(n²)
```

---

## 📚 **IEnumerable vs ICollection vs IList**

### **Surface Level Knowledge**
```csharp
IEnumerable<T>    // Can only iterate (foreach)
ICollection<T>    // Can add/remove/count
IList<T>         // Can access by index + all ICollection features
```

### **Deep Understanding**

#### **Interface Hierarchy**
```csharp
// Interface inheritance chain:
IEnumerable<T> → ICollection<T> → IList<T>

// Each interface adds capabilities:
public interface IEnumerable<T>
{
    IEnumerator<T> GetEnumerator();
}

public interface ICollection<T> : IEnumerable<T>
{
    int Count { get; }
    bool IsReadOnly { get; }
    void Add(T item);
    void Clear();
    bool Contains(T item);
    void CopyTo(T[] array, int arrayIndex);
    bool Remove(T item);
}

public interface IList<T> : ICollection<T>
{
    T this[int index] { get; set; }
    int IndexOf(T item);
    void Insert(int index, T item);
    void RemoveAt(int index);
}
```

#### **Deferred Execution with IEnumerable**
```csharp
public IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
    // Execution happens only when enumerated
}

// This doesn't execute the method until foreach:
IEnumerable<int> numbers = GetNumbers(); // No execution yet
foreach(var num in numbers) // Execution happens here
{
    Console.WriteLine(num);
}
```

### **Probable Interview Questions**

#### **Q1: What's the difference between these return types?**
```csharp
public IEnumerable<User> GetUsers() { }
public ICollection<User> GetUsers() { }
public IList<User> GetUsers() { }
```

**Answer:**
- `IEnumerable`: Most flexible, supports deferred execution
- `ICollection`: Caller can modify the collection
- `IList`: Caller can modify and access by index
- **Best practice**: Return the most restrictive interface that meets requirements

#### **Q2: Why use IEnumerable for method parameters?**
```csharp
public void ProcessUsers(IEnumerable<User> users)
{
    foreach(var user in users) { /* process */ }
}

// Benefits:
// - Accepts arrays, lists, collections, or custom enumerables
// - Doesn't allow caller to modify the collection
// - Supports LINQ operations
```

#### **Q3: What's wrong with this code?**
```csharp
public IEnumerable<int> GetNumbers()
{
    List<int> numbers = new List<int> { 1, 2, 3 };
    return numbers; // Returning List<int> as IEnumerable<int>
}

// Caller can cast back to List<int> and modify it!
var numbers = GetNumbers();
if (numbers is List<int> list)
    list.Add(4); // Modifies the original list!
```

**Solution:** Return a read-only collection or copy:
```csharp
public IEnumerable<int> GetNumbers()
{
    return new List<int> { 1, 2, 3 }.AsReadOnly();
    // OR return new ReadOnlyCollection<int>(new List<int> { 1, 2, 3 });
}
```

---

## 📚 **Collection Initializers**

### **Surface Level Knowledge**
```csharp
// Collection initializer syntax
List<string> names = new List<string> { "John", "Jane", "Bob" };
Dictionary<int, string> dict = new Dictionary<int, string>
{
    {1, "John"},
    {2, "Jane"}
};
```

### **Deep Understanding**

#### **How Collection Initializers Work**
```csharp
// The compiler translates this:
List<int> numbers = new List<int> { 1, 2, 3 };

// Into this:
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);

// Requirements for collection initializers:
// 1. Type must implement IEnumerable
// 2. Type must have Add method with appropriate parameters
```

#### **Custom Collection with Initializer Support**
```csharp
public class CustomCollection<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();
    
    public void Add(T item) => _items.Add(item);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Now you can use collection initializer:
var collection = new CustomCollection<int> { 1, 2, 3 };
```

### **Probable Interview Questions**

#### **Q1: Why does this code not compile?**
```csharp
public class MyCollection : IEnumerable<int>
{
    // Missing Add method!
    public IEnumerator<int> GetEnumerator() { /* implementation */ }
}

// var col = new MyCollection { 1, 2, 3 }; // Compilation error!
```

**Answer:** Collection initializers require an `Add` method.

#### **Q2: How to make Dictionary initializer work with different Add signatures?**
```csharp
public class MultiKeyDictionary : IEnumerable
{
    private Dictionary<string, string> _dict = new Dictionary<string, string>();
    
    public void Add(string key, string value) => _dict.Add(key, value);
    public void Add(string key, int value) => _dict.Add(key, value.ToString());
    
    public IEnumerator GetEnumerator() => _dict.GetEnumerator();
}

// Now both work:
var dict = new MultiKeyDictionary
{
    { "name", "John" },    // Calls Add(string, string)
    { "age", 25 }          // Calls Add(string, int)
};
```

---

## 📚 **Collection Interfaces Hierarchy**

### **Deep Understanding**

#### **Complete Interface Hierarchy**
```csharp
// Main interfaces:
IEnumerable<T>  // Basic enumeration
↓
ICollection<T>  // Collection operations (Add, Remove, Count)
↓
IList<T>        // Index-based access

// Read-only variants:
IReadOnlyCollection<T>  // Read-only collection
IReadOnlyList<T>        // Read-only list with indexer

// Specialized interfaces:
IDictionary<TKey, TValue>    // Key-value pairs
ISet<T>                      // Set operations
```

#### **Covariance and Contravariance in Interfaces**
```csharp
// IEnumerable<T> is covariant (out T)
IEnumerable<string> strings = new List<string>();
IEnumerable<object> objects = strings; // This works!

// ICollection<T> is invariant
ICollection<string> stringCollection = new List<string>();
// ICollection<object> objectCollection = stringCollection; // Error!

// Why? Covariance allows reading, but ICollection allows adding
// You can't add an object to a string collection safely
```

### **Probable Interview Questions**

#### **Q1: When to use IReadOnlyCollection vs IEnumerable?**
```csharp
public IReadOnlyCollection<User> GetUsers() { }
public IEnumerable<User> GetUsers() { }
```

**Answer:**
- `IReadOnlyCollection`: When you want to communicate that the result is a materialized collection with a known count
- `IEnumerable`: When the result might be lazily evaluated or streaming

#### **Q2: Why can't IList<T> be covariant?**
```csharp
// If IList<T> were covariant, this would be allowed:
IList<string> strings = new List<string>();
IList<object> objects = strings; // This would be dangerous!
objects[0] = new object(); // Would try to put object into string list!
```

**Answer:** Mutation operations prevent covariance for safety.

#### **Q3: Design a custom collection that supports both indexing and set operations**
```csharp
public class CustomCollection<T> : IList<T>, ISet<T>
{
    private List<T> _list = new List<T>();
    private HashSet<T> _set = new HashSet<T>();
    
    // Implement both interfaces
    public bool Add(T item)
    {
        if (_set.Add(item))
        {
            _list.Add(item);
            return true;
        }
        return false;
    }
    
    // IList members
    public T this[int index] { get => _list[index]; set => _list[index] = value; }
    
    // ISet members
    public bool IsProperSubsetOf(IEnumerable<T> other) => _set.IsProperSubsetOf(other);
}
```

---

## 🎯 **Tricky Follow-up Questions**

### **Q1: What happens when you modify a collection during enumeration?**
```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
foreach(var num in numbers)
{
    if (num == 2)
        numbers.Add(4); // Throws InvalidOperationException!
}
```

**Answer:** Most collection throw `InvalidOperationException` because the enumerator becomes invalid.

### **Q2: How to safely modify during enumeration?**
```csharp
// Option 1: Iterate backwards
for (int i = numbers.Count - 1; i >= 0; i--)
{
    if (numbers[i] == 2)
        numbers.Add(4); // Safe when iterating by index
}

// Option 2: Collect changes first, apply after
var toAdd = new List<int>();
foreach(var num in numbers)
{
    if (num == 2) toAdd.Add(4);
}
numbers.AddRange(toAdd);
```

### **Q3: What's the difference between these LINQ operations?**
```csharp
var list = new List<int> { 1, 2, 3 };
var result1 = list.Where(x => x > 1).ToList(); // Immediate execution
var result2 = list.Where(x => x > 1);           // Deferred execution

// result2 is executed every time it's enumerated!
```

### **Q4: When would you use Array over List?**
```csharp
// Use Array when:
// - Fixed size is known and won't change
// - Performance critical code (slightly faster)
// - Interoperability with APIs requiring arrays

// Use List when:
// - Size may change
// - More convenient API needed
// - Memory overhead is acceptable
```

This comprehensive guide covers everything from basic usage to advanced internals that interviewers love to test!
