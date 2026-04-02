
# 2) SLIDING WINDOW

| #   | Problem                                           | Difficulty | Pattern                  | Data Structure                           | Recognition Trigger                    | C# Shorthand You Need                   |
| --- | ------------------------------------------------- | ---------: | ------------------------ | ---------------------------------------- | -------------------------------------- | --------------------------------------- |
| 9   | Maximum Average Subarray I                        |       Easy | Fixed-size window        | `int[]`                                  | Window size = `k`                      | `sum += nums[i]; if(i >= k) sum -= ...` |
| 10  | Find All Anagrams in a String                     |     Medium | Fixed window + frequency | `int[]`, `string`                        | Exact-size char matching               | `freq[c - 'a']++`                       |
| 11  | Permutation in String                             |     Medium | Fixed window + frequency | `int[]` / `Dictionary<char,int>`         | Window must match target count         | `right - left + 1 == s1.Length`         |
| 12  | Longest Substring Without Repeating Characters    |     Medium | Variable window          | `HashSet<char>` / `Dictionary<char,int>` | Longest substring, no repeats          | `while(set.Contains(...))`              |
| 13  | Longest Repeating Character Replacement           |     Medium | Variable window          | `int[]`                                  | Replace up to `k` chars                | `windowSize - maxFreq > k`              |
| 14  | Minimum Size Subarray Sum                         |     Medium | Variable window          | `int[]`                                  | Smallest contiguous window             | `while(sum >= target)`                  |
| 15  | Fruit Into Baskets                                |     Medium | Variable window          | `Dictionary<int,int>`                    | At most 2 distinct                     | `map.Count > 2`                         |
| 16  | Max Consecutive Ones III                          |     Medium | Variable window          | `int[]`                                  | At most `k` zeroes                     | `zeroCount > k`                         |
| 17  | Longest Ones After Replacement / similar variants |     Medium | Variable window          | `int[]` / `Dictionary`                   | Expand + shrink based on invalid state | `left++` shrink pattern                 |

---

## 🔹 Key Data Structures Used in Sliding Window

* `int[]`
* `string`
* `HashSet<char>`
* `Dictionary<char,int>`
* `Dictionary<int,int>`
* `int[26]` frequency array

---

## 🔹 Common Sliding Window C# Shorthands

### Fixed-size window

```csharp
int sum = 0;

for (int i = 0; i < nums.Length; i++)
{
    sum += nums[i];

    if (i >= k)
        sum -= nums[i - k];
}
```

---

### Variable-size window

```csharp
int left = 0;

for (int right = 0; right < nums.Length; right++)
{
    // expand

    while (condition)
    {
        // shrink
        left++;
    }
}
```

---

### Window size

```csharp
int windowSize = right - left + 1;
```

---

### HashSet-based no-repeat window

```csharp
while (set.Contains(s[right]))
{
    set.Remove(s[left]);
    left++;
}
set.Add(s[right]);
```

---

### Frequency map update

```csharp
map[c] = map.GetValueOrDefault(c, 0) + 1;
```

---

### Remove from map cleanly

```csharp
map[x]--;
if (map[x] == 0)
    map.Remove(x);
```

---

## 🔹 How to recognize Sliding Window

Use it when you see:

* substring
* subarray
* contiguous
* longest / shortest / max / min
* “at most k”
* “without repeating”
* fixed window size `k`

---
