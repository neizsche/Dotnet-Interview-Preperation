using System;

namespace OOPSLab
{
    // ==========================================
    // 1. ENCAPSULATION
    // ==========================================
    // BAD: Data is public. Anyone can set a negative balance or steal money.
    public class BadAccount
    {
        public decimal Balance; 
    }

    // GOOD: Data is hidden (private). Access is controlled through properties.
    public class GoodAccount
    {
        private decimal _balance; // Hidden "Field"

        public decimal Balance 
        {
            get => _balance;
            // Logic inside 'set' protects the data
            private set 
            {
                if (value >= 0) _balance = value;
            }
        }

        public void Deposit(decimal amount) => Balance += amount;
    }

    // ==========================================
    // 2. ABSTRACTION
    // ==========================================
    // We provide a "Contract" (Interface or Abstract Class).
    // The user doesn't need to know HOW interest is calculated, just that it is.
    
    public abstract class BankAccount
    {
        public string Owner { get; init; }
        public decimal Balance { get; protected set; }

        public abstract void ApplyInterest(); // "What" to do, not "How"
    }

    // ==========================================
    // 3. INHERITANCE
    // ==========================================
    // 'SavingsAccount' IS-A 'BankAccount'. It gains all its properties automatically.
    
    public class SavingsAccount : BankAccount
    {
        public override void ApplyInterest() 
        {
            // Specific logic for Savings
            Balance *= 1.05m; 
            Console.WriteLine("Applied 5% Savings Interest.");
        }
    }

    public class CheckingAccount : BankAccount
    {
        public override void ApplyInterest() 
        {
            // Specific logic for Checking
            Balance *= 1.01m; 
            Console.WriteLine("Applied 1% Checking Interest.");
        }
    }

    // ==========================================
    // 4. POLYMORPHISM
    // ==========================================
    class Program
    {
        static void Main()
        {
            // Encapsulation Demo
            var acc = new GoodAccount();
            acc.Deposit(100);
            // acc.Balance = -500; // ERROR: This is now impossible!

            // Polymorphism Demo
            // We treat different objects (Savings/Checking) as the same general type (BankAccount)
            
            BankAccount[] myAccounts = {
                new SavingsAccount { Owner = "Alice", Balance = 1000 },
                new CheckingAccount { Owner = "Bob", Balance = 500 }
            };

            foreach (var account in myAccounts)
            {
                // The program decides at RUNTIME which ApplyInterest to call.
                // This is the heart of Polymorphism.
                account.ApplyInterest();
            }
        }
    }
}