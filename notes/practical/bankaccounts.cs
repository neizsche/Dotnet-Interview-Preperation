using System;
using System.Collections.Generic;
using System.Linq;

// ==================================================================================
// 1. EXTENSIONS & DELEGATES
// ==================================================================================
// SYNTAX: Static class + static method + 'this' keyword on the first parameter.
// VARIANTS: Built-in 'Action<T>' or 'Func<T, TResult>' are now preferred over custom delegates.
// GOTCHA: Extension methods CAN be called on null objects without crashing immediately.
//         Also, an instance method always takes precedence over an extension method.
// ==================================================================================
public static class Printer
{
	public static string CurrencyFormatter<T>(this T amount) => $"${amount}";
}

// Custom Delegates (Classic style)
public delegate void FraudDetector(string message);
public delegate void SMSGenerator(float amount);

// ==================================================================================
// 2. INTERFACES
// ==================================================================================
// SYNTAX: Defines a contract. 'init' (C# 9+) allows setting values only during creation.
// VARIANTS: C# 8+ allows "Default Interface Methods" (methods with bodies inside interfaces).
// GOTCHA: If two interfaces have the same method name, use "Explicit Implementation"
//         (e.g., void ITaxable.Deduct() {..}) to resolve the conflict.
// ==================================================================================
public interface ITaxable
{
	public string TaxId { get; init; } // Init-only: Immutable after construction
	public void DeductTax();
}

public interface ITransactional
{
	public void Deposit(float amount);
	public void Withdraw(float amount);
}

// ==================================================================================
// 3. BASE CLASS (FinProduct)
// ==================================================================================
// SYNTAX: 'abstract' means the class cannot be instantiated and some methods MUST be overridden.
//         'protected set' allows child classes to change the value, but keeps it private to others.
// VARIANTS: Use 'virtual' for a default implementation, 'abstract' for no implementation.
// GOTCHA: The 'event' keyword is a safety wrapper. Without it, any external class could
//         reset the delegate to null (smsEvent = null). With 'event', they can only += or -=.
// ==================================================================================
public abstract class FinProduct
{
	public string AccountNumber { get; init; }
	public double Balance { get; protected set; } // Controlled access
	public double Interest { get; set; }

	// Function Pointers (Modern C# style)
	public Action<string> CheckFraudtransaction; // Returns void
	public Predicate<float> IsLowBalance;        // Returns bool
	public Func<float, float> TransactionFee;    // Takes float, returns float
	
	public event Action<float> TransactionSMS;   // Event wrapper for safety

	public FinProduct(string acc, double initBalance)
	{
		AccountNumber = acc;
		Balance = initBalance;
	}

	public void RaiseTransactionSMSEvent(float amount) => TransactionSMS?.Invoke(amount);
	public abstract void CalculateInterest(); // Must be implemented by child

	public virtual void PrintStatement() => 
		Console.WriteLine($"Acc: {AccountNumber}, Bal: {Balance.CurrencyFormatter()}");
}

// ==================================================================================
// 4. DERIVED CLASSES
// ==================================================================================
// SYNTAX: ':' used for inheritance. 'base()' calls the parent constructor.
// VARIANTS: Use 'sealed' if you want to prevent further inheritance from these classes.
// GOTCHA: 'override' vs 'new'. Use 'override' to participate in polymorphism. 
//         Using 'new' (shadowing) breaks the link to the base class method when cast.
// ==================================================================================
public class Savings : FinProduct, ITransactional
{
	public Savings(string acc, float initBalance) : base(acc, initBalance) { }

	public override void CalculateInterest()
	{
		Interest = (Balance * 0.03);
		Console.WriteLine("Savings Interest Calculated.");
	}

	public void Deposit(float amount)
	{
		Balance += amount;
		CheckFraudtransaction?.Invoke($"In: {amount}, Bal: {Balance.CurrencyFormatter()}");
		RaiseTransactionSMSEvent(amount);
	}

	public void Withdraw(float amount)
	{
		var fee = TransactionFee?.Invoke(amount) ?? 0;
		Balance -= (amount + fee);
		CheckFraudtransaction?.Invoke($"Out: {amount}, Fee: {fee}, Bal: {Balance.CurrencyFormatter()}");
		
		if (IsLowBalance?.Invoke((float)Balance) == true) Console.WriteLine("!!! LOW BALANCE !!!");
	}
}

public class Loans : FinProduct
{
	public Loans(string acc, float initBalance) : base(acc, initBalance) { }
	public override void CalculateInterest() { Interest = 9.6; }
}

public class CC : FinProduct
{
	public CC(string acc, float initBalance) : base(acc, initBalance) { }
	public override void CalculateInterest() { Interest = 15; }
}

public class Corporateinv : FinProduct, ITaxable
{
	public string TaxId { get; init; }
	public Corporateinv(string tid, string acc, float init) : base(acc, init) { TaxId = tid; }

	public void DeductTax() => Balance -= (0.1 * Balance);
	public override void CalculateInterest() { Interest = 15; }
}

// ==================================================================================
// 5. GENERIC VAULTS (Generics)
// ==================================================================================
// SYNTAX: <T> makes the class reusable for different types.
// VARIANTS: 'where T : class' (must be reference type) or 'where T : new()' (must have empty constructor).
// GOTCHA: Generics prevent "Boxing/Unboxing" overhead, making them much faster than using 'object'.
// ==================================================================================
public class BankVault<T> where T : ITransactional
{
	private List<T> accounts = new List<T>();
	public BankVault(T account) => accounts.Add(account);

	public void AnnualInterest()
	{
		foreach (var acc in accounts) acc.Deposit(999);
	}
}

// ==================================================================================
// 6. MAIN & LINQ
// ==================================================================================
// SYNTAX: Method syntax (shown below) is standard. LINQ uses "Deferred Execution."
// GOTCHA: 'First()' throws if empty; 'FirstOrDefault()' returns null if empty.
// GOTCHA: 'Single()' throws if more than one item exists.
// GOTCHA: Chaining sorts must use 'ThenBy'. Using 'OrderBy' twice resets the sort.
// ==================================================================================
public class Program
{
	public static void Main()
	{
		var savings = new Savings("123", 1000);
		savings.TransactionFee = amt => (float)(amt * 0.01);
		
		// Event Subscription
		savings.CheckFraudtransaction = msg => Console.WriteLine($"[LOG]: {msg}");
		savings.TransactionSMS += amt => { if(amt > 100) Console.WriteLine($"[SMS]: Large Tx: {amt}"); };
		
		var accounts1 = new List<FinProduct>
		{
			new Savings("S001", 1200),
			new Savings("S002", 50),
			new Loans("L001", -50000),
			new CC("C001", 15000),
			new CC("C002", -500),
			new Corporateinv("INTEL", "I001", 100000)
		};

		// 1. Where & OrderBy (Basic filtering)
		var debt = accounts1.Where(x => x.Balance < 0).OrderBy(x => x.Balance).ToList();

		// 2. OfType (Filter by interface/type)
		var taxables = accounts1.OfType<ITaxable>().ToList();

		// 3. GroupBy & Anonymous Types (Reporting)
		var stats = accounts1.GroupBy(x => x.GetType().Name)
							 .Select(g => new { Type = g.Key, Avg = g.Average(a => a.Balance) });

		// 4. ThenBy (Secondary sorting)
		var sorted = accounts1.OrderBy(x => x.Balance).ThenBy(x => x.AccountNumber);

		// 5. FirstOrDefault vs SingleOrDefault
		var specific = accounts1.SingleOrDefault(x => x.AccountNumber == "S001");

		Console.WriteLine("--- Execution Complete ---");
	}
}