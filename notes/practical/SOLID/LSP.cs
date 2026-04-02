using System;
using System.Collections.Generic;

namespace LSPLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (Violates LSP)
    // ==========================================
    // This is the classic "Ostrich" problem. 
    // We assume ALL birds can fly, but an Ostrich is a bird that CANNOT.
    public class BadBird
    {
        public virtual void Fly() => Console.WriteLine("Bird is flying!");
    }

    public class Eagle : BadBird { }

    public class Ostrich : BadBird
    {
        public override void Fly()
        {
            // VIOLATION: We are throwing an exception where a behavior was expected.
            // Any code expecting a 'BadBird' to fly will now crash.
            throw new InvalidOperationException("Ostriches cannot fly!");
        }
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (The LSP Way)
    // ==========================================
    // We stop assuming all birds have the same behavior. 
    // We split the behaviors into specific interfaces.

    public abstract class Bird
    {
        public abstract void Eat();
    }

    public interface IFlyingBird
    {
        void Fly();
    }

    public class GoodEagle : Bird, IFlyingBird
    {
        public override void Eat() => Console.WriteLine("Eagle eats fish.");
        public void Fly() => Console.WriteLine("Eagle soars in the sky.");
    }

    public class GoodOstrich : Bird
    {
        // Ostrich only implements what it can actually do.
        public override void Eat() => Console.WriteLine("Ostrich eats seeds.");
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Running Bad Practice (LSP Violation) ---");
            List<BadBird> badBirds = new List<BadBird> { new Eagle(), new Ostrich() };

            try
            {
                foreach (var bird in badBirds)
                {
                    bird.Fly(); // This will CRASH when it hits the Ostrich
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Running Good Practice (LSP Compliant) ---");
            
            // Now we only call 'Fly' on things that we KNOW can fly.
            List<Bird> allBirds = new List<Bird> { new GoodEagle(), new GoodOstrich() };
            
            foreach (var bird in allBirds)
            {
                bird.Eat(); // Safe for all birds

                // We check for the specific 'IFlyingBird' capability
                if (bird is IFlyingBird flyer)
                {
                    flyer.Fly();
                }
            }
        }
    }
}