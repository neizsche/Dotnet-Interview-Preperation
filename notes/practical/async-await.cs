using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class AdvancedBreakfast
{
    // A simple cache to demonstrate ValueTask
    private static string _cachedCoffeeType = "Arabica";

    public static async Task Main()
    {
        Console.WriteLine("--- Expert Kitchen Started ---");
        
        // CancellationToken allows us to "stop" the kitchen if there's a fire
        using var cts = new CancellationTokenSource();

        // 1. Calling a ValueTask method
        // If the coffee type is cached, this won't create a Task object in memory.
        string coffeeType = await GetCoffeeTypeAsync("Morning-Blend");

        // 2. Start tasks without awaiting (Concurrent execution)
        Task<string> toastTask = MakeToastAsync(true, cts.Token);
        Task<string> coffeeTask = BrewCoffeeAsync(coffeeType, cts.Token);

        // 3. IAsyncEnumerable: Getting items one by one as they are ready
        await foreach (var item in GetSideDishesAsync())
        {
            Console.WriteLine($"  [Sides] Just finished: {item}");
        }

        // 4. Await results
        string toast = await toastTask;
        string coffee = await coffeeTask;

        Console.WriteLine($"--- Final Meal: {toast}, {coffee}, and sides ready! ---");
    }

    // VALUE-TASK EXAMPLE: Great for performance when the result might already be ready
    static async ValueTask<string> GetCoffeeTypeAsync(string preference)
    {
        if (!string.IsNullOrEmpty(_cachedCoffeeType))
        {
            return _cachedCoffeeType; // Returns immediately, zero memory allocation
        }

        await Task.Delay(100); // Imagine a database call here
        return preference;
    }

    static async Task<string> MakeToastAsync(bool extraCrispy, CancellationToken ct)
    {
        Console.WriteLine("  [Toast] Bread in...");
        
        // CONFIGUREAWAIT(FALSE): Standard for library/background code. 
        // It tells the code "I don't need to return to the original thread context."
        await Task.Delay(2000, ct).ConfigureAwait(false); 

        return "Crispy Toast";
    }

    static async Task<string> BrewCoffeeAsync(string type, CancellationToken ct)
    {
        Console.WriteLine($"  [Coffee] Brewing {type}...");
        
        // Passing the CancellationToken down ensures the delay stops if we cancel.
        await Task.Delay(1500, ct).ConfigureAwait(false);

        return $"Hot {type}";
    }

    // IASYNC-ENUMERABLE: Returns items one at a time as they finish
    static async IAsyncEnumerable<string> GetSideDishesAsync()
    {
        string[] sides = { "Orange Juice", "Bacon", "Fruit Bowl" };
        foreach (var side in sides)
        {
            await Task.Delay(800); // Simulate cooking time for each side
            yield return side;     // Send it to the table one by one
        }
    }
}