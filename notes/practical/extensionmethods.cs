using System;
using System.Linq;

namespace ExtensionLab
{
    // ==========================================
    // THE RULES FOR EXTENSION METHODS:
    // 1. Must be in a non-generic, STATIC class.
    // 2. The method itself must be STATIC.
    // 3. The first parameter uses the 'this' keyword.
    // ==========================================
    public static class MyExtensions
    {
        // Example 1: Extending a built-in type (string)
        // Checks if a string has a certain word count
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Example 2: Extending a built-in type (int)
        // Checks if a number is greater than another
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }

        // Example 3: Extending an interface (The LINQ Pattern)
        // This is exactly how .Enumerable.Any() or .Where() works!
        public static void PrintAll<T>(this System.Collections.Generic.IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            // --- Usage 1: String ---
            string bio = "I love coding in C#.";
            // We call it like it was a natural part of the string class!
            int count = bio.WordCount(); 
            Console.WriteLine($"Words: {count}");

            // --- Usage 2: Int ---
            int age = 25;
            if (age.IsGreaterThan(18)) 
            {
                Console.WriteLine("User is an adult.");
            }

            // --- Usage 3: Collections ---
            var fruits = new[] { "Apple", "Banana", "Cherry" };
            fruits.PrintAll(); 
        }
    }
}