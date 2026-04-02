
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
