using System;

// 1. DELEGATE: Defines a "shape" for a method
public delegate void Notify(string message);

// 2. ENUM: A set of named constants
public enum AccountStatus { Active, Suspended, Deleted }

// 3. INTERFACE: The Contract
public interface IIdentifiable
{
    string Id { get; } // Any class using this MUST have an Id
}

// 5. STRUCT: A lightweight value type
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

// 4. CLASS: The Blueprint
public class BankAccount : IIdentifiable
{
    // FIELD: A private variable (internal data)
    private decimal _balance;

    // PROPERTIES with get, set, and init
    public string Id { get; init; }      // 'init' means set-once-at-creation
    public string Owner { get; set; }    // Standard read/write
    public AccountStatus Status { get; set; }

    // Logic inside a property
    public decimal Balance 
    {
        get { return _balance; }
        set { if (value >= 0) _balance = value; } // Validation logic!
    }

    public BankAccount(string id) => Id = id;
}

class Program
{
    static void Main()
    {
        // 5. INIT IN ACTION:
        var account = new BankAccount("ACC-123") 
        { 
            Owner = "Alex", 
            Status = AccountStatus.Active 
        };
        
        // account.Id = "ACC-456"; // ERROR! 'init' prevents changes after creation.

        // 6. OBJECT: The root type
        object anything = "I can hold a string";
        anything = 42; // Now I hold an int.

        // 7. DYNAMIC: The "trust me" type
        dynamic looseType = "Hello";
        Console.WriteLine(looseType.Length); // Works
        looseType = 100;
        // Console.WriteLine(looseType.Length); // CRASHES at runtime (ints don't have lengths)

        // 8. DELEGATE IN ACTION:
        Notify logger = (msg) => Console.WriteLine($"LOG: {msg}");
        logger("Account created successfully.");
    }
}