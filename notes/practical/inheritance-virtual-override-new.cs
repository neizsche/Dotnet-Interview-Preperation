using System;

namespace CSharpDemo
{
    // Base Class demonstrating Inheritance
    public class Animal
    {
        // 1. Access Modifiers
        public string Name = "Generic Animal";      // Accessible everywhere
        protected string Species = "Unknown";      // Accessible in this class and subclasses
        private int _age = 0;                      // Accessible ONLY in this class

        // 2. Virtual Method (Polymorphism)
        // This says: "Subclasses CAN override this if they want to."
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a generic sound.");
        }

        // 3. Method for 'new' keyword demonstration
        public void Eat()
        {
            Console.WriteLine("The animal eats food.");
        }
    }

    // Inheritance: Dog "is a" Animal
    public class Dog : Animal
    {
        public Dog()
        {
            // Accessing protected member from base class
            Species = "Canine"; 
        }

        // 4. Override (Polymorphism)
        // This replaces the base method completely when using a Dog object.
        public override void MakeSound()
        {
            Console.WriteLine("The dog barks: Woof! Woof!");
        }

        // 5. New Keyword (Method Hiding)
        // This hides the base method. It doesn't replace it; it just creates 
        // a new version specifically for the Dog type.
        public new void Eat()
        {
            Console.WriteLine("The dog eats kibble from a bowl.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Scenario A: Creating a Dog as a Dog
            Dog myDog = new Dog();
            
            // Scenario B: Polymorphism (Creating a Dog as an Animal)
            Animal polyDog = new Dog();

            Console.WriteLine("--- Scenario A: Dog reference ---");
            myDog.MakeSound(); // Calls Dog's override
            myDog.Eat();       // Calls Dog's new method

            Console.WriteLine("\n--- Scenario B: Animal reference (Polymorphism) ---");
            polyDog.MakeSound(); // Calls Dog's override (Dynamic Binding)
            polyDog.Eat();       // Calls Animal's method (Static Binding - 'new' doesn't override!)
			
			
			//--- Scenario A: Dog reference ---
			//The dog barks: Woof! Woof!
			//The dog eats kibble from a bowl.

			//--- Scenario B: Animal reference (Polymorphism) ---
			//The dog barks: Woof! Woof!
			//The animal eats food.
        }
    }
}