using System;
using System.IO;
using System.Collections.Generic;

namespace SRPLab
{
    // ==========================================
    // 1. THE BAD PRACTICE (The "God" Class)
    // ==========================================
    // This class violates SRP because it has 3 reasons to change:
    // - Data changes (Name/Email)
    // - Logic changes (How we calculate totals)
    // - Storage changes (Saving to File/Database)
    public class OrderProcessor
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }

        public void ProcessOrder()
        {
            // Logic: Validation
            if (Amount <= 0) throw new Exception("Invalid Amount");

            // Logic: Calculation (Tax)
            decimal total = Amount * 1.15m;
            Console.WriteLine($"Processing {OrderId} for total: {total}");

            // Storage: Writing to a file
            File.WriteAllText("orders.txt", $"Order {OrderId} processed.");
        }
    }

    // ==========================================
    // 2. THE GOOD PRACTICE (The SRP Way)
    // ==========================================
    
    // Responsibility 1: Data Model
    public class Order
    {
        public string Id { get; init; }
        public decimal BaseAmount { get; init; }
    }

    // Responsibility 2: Business Logic (Tax/Math)
    public class TaxCalculator
    {
        private const decimal TaxRate = 0.15m;
        public decimal CalculateTotal(decimal amount) => amount + (amount * TaxRate);
    }

    // Responsibility 3: Persistence (File I/O)
    public class OrderRepository
    {
        public void SaveToFile(Order order, decimal total)
        {
            File.WriteAllText($"{order.Id}.txt", $"Order ID: {order.Id}\nTotal: {total}");
            Console.WriteLine($"[Storage] Saved {order.Id} to disk.");
        }
    }

    // Responsibility 4: Orchestration (The "Manager")
    public class OrderService
    {
        private readonly TaxCalculator _calc = new();
        private readonly OrderRepository _repo = new();

        public void FinalizeOrder(Order order)
        {
            decimal total = _calc.CalculateTotal(order.BaseAmount);
            _repo.SaveToFile(order, total);
            Console.WriteLine($"[Service] Order {order.Id} completed successfully.");
        }
    }

    // ==========================================
    // EXECUTION
    // ==========================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Running Bad Practice ---");
            var bad = new OrderProcessor { OrderId = "BAD-101", Amount = 100m };
            bad.ProcessOrder();

            Console.WriteLine("\n--- Running Good Practice (SRP) ---");
            var goodOrder = new Order { Id = "GOOD-202", BaseAmount = 100m };
            var service = new OrderService();
            service.FinalizeOrder(goodOrder);
        }
    }
}