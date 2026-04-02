using System;

namespace ArchitectureLab
{
    // 1. ABSTRACT CLASS: The "Incomplete Blueprint"
    // We can't have a "Generic" Payment; it must be a specific type.
    public abstract class Payment
    {
        public decimal Amount { get; set; }
        
        // A regular method: Every payment has this logic (Inheritance)
        public void PrintReceipt() => Console.WriteLine($"Receipt for ${Amount}");

        // ABSTRACT Method: No implementation here. 
        // Derived classes MUST provide the logic.
        public abstract void Process();

        // VIRTUAL Method: Has a default implementation. 
        // Derived classes CAN override it, but they don't have to.
        public virtual void CalculateFees() 
        {
            Console.WriteLine("Applying standard 2% fee.");
        }
    }

    // 2. NORMAL CLASS: Inherits from Abstract
    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }

        // Must implement the abstract method from the parent
        public override void Process()
        {
            Console.WriteLine($"Charging ${Amount} to Card: {CardNumber}");
        }

        // Overriding the virtual method to provide specific logic
        public override void CalculateFees()
        {
            Console.WriteLine("Applying Credit Card 3% fee.");
        }
    }

    // 3. SEALED CLASS: The "Final Version"
    // No one can inherit from BitcoinPayment. The logic is locked.
    public sealed class BitcoinPayment : Payment
    {
        public string WalletAddress { get; set; }

        public override void Process()
        {
            Console.WriteLine($"Transferring {Amount} BTC to {WalletAddress}");
        }
        
        // We use the default CalculateFees from the parent (didn't override it)
    }

    // 4. STATIC CLASS: The "Toolbox"
    // Cannot be instantiated. Used for helper functions.
    public static class PaymentValidator
    {
        public static bool IsValid(decimal amount) => amount > 0;
    }

    // ==========================================
    // EXECUTION (The Entry Point)
    // ==========================================
    class Program
    {
        static void Main()
        {
            // Payment p = new Payment(); // ERROR: Cannot create an instance of an abstract class.

            if (PaymentValidator.IsValid(100)) // Static call
            {
                // Polymorphism in action:
                Payment myPayment = new CreditCardPayment { Amount = 100, CardNumber = "1234-5678" };
                
                myPayment.Process();       // Calls CreditCard version
                myPayment.CalculateFees(); // Calls CreditCard version
                myPayment.PrintReceipt();  // Calls Base version
                
                Console.WriteLine("----------------");

                Payment crypto = new BitcoinPayment { Amount = 50, WalletAddress = "bc1q..." };
                crypto.Process();       // Calls Bitcoin version
                crypto.CalculateFees(); // Calls Base version (Default)
            }
        }
    }
}