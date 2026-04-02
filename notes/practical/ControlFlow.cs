using System;
using System.Collections.Generic;

class ControlFlowDemo
{
    static void Main()
    {
        // --- 1. SELECTION (if, else, switch, case, default) ---
        int hour = DateTime.Now.Hour;

        if (hour < 12) 
        {
            Console.WriteLine("Good Morning");
        }
        else 
        {
            Console.WriteLine("Good Afternoon/Evening");
        }

        string day = "Monday";
        switch (day)
        {
            case "Saturday":
            case "Sunday":
                Console.WriteLine("Weekend!");
                break; // Jump statement: exits the switch
            default:
                Console.WriteLine("Work day.");
                break;
        }

        // --- 2. ITERATION (for, foreach, while, do) ---
        string[] colors = { "Red", "Green", "Blue" };

        // foreach: Best for collections
        foreach (string color in colors)
        {
            if (color == "Green") continue; // Jumps to next iteration
            Console.WriteLine($"Color: {color}");
        }

        // while: Runs as long as condition is true
        int counter = 0;
        while (counter < 2)
        {
            Console.WriteLine($"Counter: {counter}");
            counter++;
        }

        // --- 3. EXCEPTION HANDLING (try, catch, finally, throw) ---
        try
        {
            int divisor = 0;
            if (divisor == 0) 
                throw new DivideByZeroException("Custom Error: You can't do that!");
            
            int result = 10 / divisor;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error caught: {ex.Message}");
        }
        finally
        {
            // This runs NO MATTER WHAT (success or error)
            Console.WriteLine("Cleanup: Closing connections...");
        }

        // --- 4. YIELD (Advanced Jump Statement) ---
        foreach (int num in GetNumbers())
        {
            Console.WriteLine($"Yielded: {num}");
        }
    }

    // yield return: Returns one item at a time without creating a whole list first
    static IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}