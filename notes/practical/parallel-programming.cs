using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ParallelismLab
{
    public static void Main()
    {
        Console.WriteLine($"--- Kitchen started on Thread {Thread.CurrentThread.ManagedThreadId} ---");

        var orders = Enumerable.Range(1, 10).ToList();

        // 1. Parallel.ForEach: Best for "Fire and Forget" heavy work
        // It automatically splits the 10 orders across your CPU cores.
        Console.WriteLine("\n[Action] Starting Parallel.ForEach...");
        Parallel.ForEach(orders, orderId => 
        {
            CookMeal(orderId);
        });

        // 2. Parallel LINQ (PLINQ): Best for data processing/filtering
        // Adding .AsParallel() makes the 'Where' and 'Select' run on multiple threads.
        Console.WriteLine("\n[Action] Starting PLINQ Processing...");
        var expensiveOrders = orders.AsParallel()
                                    .WithDegreeOfParallelism(2) // Limit to 2 chefs
                                    .Where(o => o > 5)
                                    .Select(o => $"Fancy Meal {o}")
                                    .ToList();

        // 3. Task.Run: Best for moving a single heavy job to a background thread
        Task.Run(() => Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Doing dishes in background..."));

        Console.WriteLine("\n--- All work finished. ---");
    }

    static void CookMeal(int id)
    {
        // Thread.Sleep is "Blocking" - perfect for simulating CPU-heavy work (like chopping)
        // rather than "Waiting" work (like brewing).
        Thread.Sleep(500); 
        Console.WriteLine($"  [Chef] Order {id} finished on Thread {Thread.CurrentThread.ManagedThreadId}");
    }
}