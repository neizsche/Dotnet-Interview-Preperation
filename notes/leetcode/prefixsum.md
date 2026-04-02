
# 3) PREFIX SUM

| #   | Problem                                     | Difficulty | Pattern                 | Data Structure                   | Recognition Trigger                | C# Shorthand You Need       |
| --- | ------------------------------------------- | ---------: | ----------------------- | -------------------------------- | ---------------------------------- | --------------------------- |
| 18  | Running Sum of 1D Array                     |       Easy | Prefix sum build        | `int[]`                          | Running totals                     | `nums[i] += nums[i - 1];`   |
| 19  | Range Sum Query - Immutable                 |       Easy | Prefix array            | `int[]`                          | Many range sum queries             | `prefix[r] - prefix[l - 1]` |
| 20  | Pivot Index                                 |       Easy | Prefix reasoning        | `int[]`                          | Left sum = right sum               | `total - left - nums[i]`    |
| 21  | Subarray Sum Equals K                       |     Medium | Prefix sum + HashMap    | `Dictionary<int,int>`            | Count subarrays with sum = K       | `map[sum - k]`              |
| 22  | Continuous Subarray Sum                     |     Medium | Prefix modulo + HashMap | `Dictionary<int,int>`            | Sum divisible by `k`               | `sum % k`                   |
| 23  | Product of Array Except Self                |     Medium | Prefix + suffix         | `int[]`                          | Product except current index       | `prefix`, `suffix`          |
| 24  | Number of Subarrays with Odd Sum / variants |     Medium | Prefix parity           | `Dictionary<int,int>` / counters | Count subarrays by prefix property | `sum % 2`                   |

---

## 🔹 Key Data Structures Used in Prefix Sum

* `int[]`
* `Dictionary<int,int>`
* counters / running totals

---

## 🔹 Common Prefix Sum C# Shorthands

### Build prefix

```csharp
for (int i = 1; i < nums.Length; i++)
    nums[i] += nums[i - 1];
```

---

### Separate prefix array

```csharp
int[] prefix = new int[n];
prefix[0] = nums[0];

for (int i = 1; i < n; i++)
    prefix[i] = prefix[i - 1] + nums[i];
```

---

### Range sum

```csharp
int sum = left == 0 ? prefix[right] : prefix[right] - prefix[left - 1];
```

---

### Prefix sum + HashMap (VERY IMPORTANT)

```csharp
var map = new Dictionary<int, int>();
map[0] = 1;

int sum = 0, count = 0;

foreach (int num in nums)
{
    sum += num;

    if (map.ContainsKey(sum - k))
        count += map[sum - k];

    map[sum] = map.GetValueOrDefault(sum, 0) + 1;
}
```

This is one of the **most important interview templates**.

---

### Prefix + suffix product

```csharp
int[] result = new int[n];
int prefix = 1;

for (int i = 0; i < n; i++)
{
    result[i] = prefix;
    prefix *= nums[i];
}

int suffix = 1;
for (int i = n - 1; i >= 0; i--)
{
    result[i] *= suffix;
    suffix *= nums[i];
}
```

---

## 🔹 How to recognize Prefix Sum

Use it when you see:

* subarray sum
* range sum
* count subarrays
* sum = k
* cumulative totals
* product except self

---

# 🔥 MASTER DATA STRUCTURES YOU SHOULD BE FLUENT IN

This is your actual toolkit.
Don’t try to learn 50 things. Learn these **properly**.

---

# 1) `int[]`

Most used structure in interviews.

### Used for:

* Two pointer
* Sliding window
* Prefix sum
* Frequency counting

### Must know:

```csharp
nums.Length
nums[i]
```

---

# 2) `string`

Used heavily in:

* Two pointer
* Sliding window
* Anagram / substring problems

### Must know:

```csharp
s.Length
s[i]
```

---

# 3) `char[]`

Used when you need to **modify string content**

### Must know:

```csharp
char[] arr = s.ToCharArray();
string result = new string(arr);
```

---

# 4) `Dictionary<TKey, TValue>`

This is your **HashMap**.

### Used for:

* Frequency counts
* Prefix sum lookup
* Sliding window distinct tracking

### Must know:

```csharp
var map = new Dictionary<char, int>();

map.ContainsKey(c)
map[c] = 1;
map[c]++;
map.Remove(c);
```

### Best shorthand:

```csharp
map[c] = map.GetValueOrDefault(c, 0) + 1;
```

---

# 5) `HashSet<T>`

Used for:

* duplicates
* uniqueness
* fast existence check

### Must know:

```csharp
var set = new HashSet<char>();

set.Add(c);
set.Remove(c);
set.Contains(c);
```

---

# 6) `List<T>`

Used for dynamic answers

### Must know:

```csharp
var result = new List<IList<int>>();
result.Add(new List<int> { a, b, c });
```

---

# 🔥 TOP C# MICRO-SHORTHANDS YOU MUST MEMORIZE

These are the tiny things that stop you from fumbling.

---

## 1. char → alphabet index

```csharp
int idx = c - 'a';
```

---

## 2. char digit → int

```csharp
int num = c - '0';
```

---

## 3. int → char

```csharp
char c = (char)(i + 'a');
```

---

## 4. Frequency array

```csharp
int[] freq = new int[26];

foreach (char c in s)
    freq[c - 'a']++;
```

---

## 5. Early exit decrement

```csharp
if (--freq[c - 'a'] < 0)
    return false;
```

---

## 6. Dictionary count shorthand

```csharp
map[x] = map.GetValueOrDefault(x, 0) + 1;
```

---

## 7. Window size

```csharp
int windowSize = right - left + 1;
```

---

## 8. Swap

```csharp
(nums[i], nums[j]) = (nums[j], nums[i]);
```

---

## 9. Prefix-sum map init

```csharp
map[0] = 1;
```

This line is **extremely important** in `Subarray Sum Equals K`.

---

## 10. Skip duplicates

```csharp
while (l < r && nums[l] == nums[l + 1]) l++;
while (l < r && nums[r] == nums[r - 1]) r--;
```

---

# 🔥 FAST PATTERN IDENTIFICATION SHEET

This is what you should mentally ask in an interview.

---

## If I see…

### “sorted + pair/triplet”

👉 Think **Two Pointer**

---

## If I see…

### “substring / subarray / contiguous / longest / smallest”

👉 Think **Sliding Window**

---

## If I see…

### “subarray sum / count subarrays / range sum”

👉 Think **Prefix Sum**

---

# 🔴 Brutally Honest Assessment of What You Need

Your weak spot is **not raw problem-solving**.

It’s this:

### You are missing:

* fast recognition
* syntax fluency
* implementation shorthand

That’s why you “kind of know” but still fumble.

So your prep should be:

### NOT:

* random 100 LeetCode

### YES:

* these 20–24 problems
* repeated until templates become automatic

---

# ✅ Best next step

Now the smartest thing is:

## **Option B (recommended next)**

I turn this into a **Day 1 → Day 5 study roadmap**:

For each day:

* exact 4 problems
* pattern to learn
* C# shorthand to memorize
* what interviewer follow-up they ask

That would be **way more useful** than just staring at this table.

If you want, I’ll build that next.
