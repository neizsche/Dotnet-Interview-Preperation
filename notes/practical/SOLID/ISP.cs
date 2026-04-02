using System;

namespace ISPLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (The "Fat" Interface)
    // ==========================================
    // This violates ISP because not every printer can Scan or Fax.
    public interface IMachine
    {
        void Print();
        void Scan();
        void Fax();
    }

    public class HighEndPrinter : IMachine
    {
        public void Print() => Console.WriteLine("Printing high-quality document...");
        public void Scan() => Console.WriteLine("Scanning to PDF...");
        public void Fax() => Console.WriteLine("Sending Fax...");
    }

    public class BasicPrinter : IMachine
    {
        public void Print() => Console.WriteLine("Printing black and white...");

        // VIOLATION: The BasicPrinter is FORCED to implement these, 
        // even though it physically cannot perform the actions.
        public void Scan() => throw new NotImplementedException("Basic Printer cannot scan!");
        public void Fax() => throw new NotImplementedException("Basic Printer cannot fax!");
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (Segregated Interfaces)
    // ==========================================
    // We break the "Fat" interface into smaller, specialized "Roles."

    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFaxMachine
    {
        void Fax();
    }

    // A simple device only takes what it needs
    public class GoodBasicPrinter : IPrinter
    {
        public void Print() => Console.WriteLine("Basic Print Job started.");
    }

    // An advanced device can implement multiple interfaces (Composition)
    public class Photocopier : IPrinter, IScanner
    {
        public void Print() => Console.WriteLine("Photocopier printing...");
        public void Scan() => Console.WriteLine("Photocopier scanning...");
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Running Bad Practice (ISP Violation) ---");
            try 
            {
                IMachine basic = new BasicPrinter();
                basic.Print();
                basic.Scan(); // This will crash the app
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }

            Console.WriteLine("\n--- Running Good Practice (ISP Compliant) ---");
            
            IPrinter goodBasic = new GoodBasicPrinter();
            goodBasic.Print(); // No Scan() or Fax() methods even exist here!

            Photocopier officeMachine = new Photocopier();
            officeMachine.Print();
            officeMachine.Scan();
        }
    }
}