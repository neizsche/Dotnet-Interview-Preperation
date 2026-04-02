using System;
using System.Collections.Generic;

namespace GenericsLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (Non-Generic / Object)
    // ==========================================
    // Using 'object' is dangerous. It requires "Casting" and can crash at runtime.
    public class OldBox
    {
        public object Content { get; set; }
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (Generics)
    // ==========================================

    // T is the placeholder for "Type"
    // CONSTRAINTS: 'where T : class, new()' means T must be a class with a constructor.
    public class SecureBox<T> where T : class, new()
    {
        private T _content;

        public void Pack(T item) 
        {
            _content = item;
            Console.WriteLine($"Packed a {typeof(T).Name}");
        }

        public T Unpack() => _content;
    }

    // GENERIC METHOD: Works on any type without needing the whole class to be generic
    public class Utility
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }

    // ==========================================
    // 3. GENERIC INTERFACES (Common for Repository Pattern)
    // ==========================================
    public interface IRepository<T>
    {
        void Add(T item);
        T GetById(int id);
    }

    public class User { public string Name { get; set; } }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            // --- The Dangerous Way (Object) ---
            var oldBox = new OldBox();
            oldBox.Content = 123; 
            // string myVal = (string)oldBox.Content; // CRASH! InvalidCastException

            // --- The Safe Way (Generics) ---
            
            var userBox = new SecureBox<User>(); 
            userBox.Pack(new User { Name = "Alice" });
            User u = userBox.Unpack(); // No casting needed! Type safe.

            // --- Generic Method in Action ---
            int a = 1, b = 2;
            Utility.Swap(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");

            string s1 = "Hello", s2 = "World";
            Utility.Swap(ref s1, ref s2); // Same method works for strings!
        }
    }
}