
# 1) TWO POINTER

| #   | Problem                             | Difficulty | Pattern                  | Data Structure              | Recognition Trigger                  | C# Shorthand You Need          |
| --- | ----------------------------------- | ---------: | ------------------------ | --------------------------- | ------------------------------------ | ------------------------------ |
| 1   | Valid Palindrome                    |       Easy | Opposite-end two pointer | `string`                    | Compare from both ends               | `int l = 0, r = s.Length - 1;` |
| 2   | Two Sum II (Sorted)                 |       Easy | Opposite-end two pointer | `int[]`                     | Sorted + pair sum                    | `while (l < r)`                |
| 3   | Remove Duplicates from Sorted Array |       Easy | Fast/Slow pointer        | `int[]`                     | In-place overwrite                   | `nums[slow] = nums[fast];`     |
| 4   | Move Zeroes                         |       Easy | Fast/Slow pointer        | `int[]`                     | Move valid items forward             | `(nums[i], nums[j]) = ...`     |
| 5   | Squares of a Sorted Array           |       Easy | Two pointer from ends    | `int[]`                     | Largest abs value at ends            | `int pos = n - 1;`             |
| 6   | Container With Most Water           |     Medium | Opposite-end two pointer | `int[]`                     | Max area between ends                | `Math.Min(a,b) * width`        |
| 7   | 3Sum                                |     Medium | Sort + two pointer       | `int[]`, `List<IList<int>>` | Triplets / sorted duplicate handling | `Array.Sort(nums);`            |
| 8   | Sort Colors                         |     Medium | Pointer partitioning     | `int[]`                     | Rearranging 0,1,2 in-place           | `low / mid / high`             |

---

## 🔹 Key Data Structures Used in Two Pointer

* `int[]`
* `string`
* `char[]`
* `List<IList<int>>` (for output)

---

## 🔹 Common Two Pointer C# Shorthands

### Opposite ends

```csharp
int l = 0, r = nums.Length - 1;
while (l < r)
{
    ...
}
```

### Fast / slow pointer

```csharp
int slow = 0;
for (int fast = 0; fast < nums.Length; fast++)
{
    ...
}
```

### Swap

```csharp
(nums[i], nums[j]) = (nums[j], nums[i]);
```

### Skip duplicates

```csharp
while (l < r && nums[l] == nums[l + 1]) l++;
while (l < r && nums[r] == nums[r - 1]) r--;
```

---

## 🔹 How to recognize Two Pointer

Use it when you see:

* sorted array
* pair / triplet
* palindrome
* compare both ends
* remove duplicates in-place
* move elements around without extra space

---
