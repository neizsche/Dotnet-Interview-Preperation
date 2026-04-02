using System;

public class Program
{ // Implement Delegates(Action,Func,Predicate) and Events with this class
	
	public class Account
	{
		public string AccountNumber { get; init; }
		public float Balance { get; set; }
		public string Name { get; set; }

		public Account(string acc, float bal, string name)
		{
			AccountNumber = acc;
			Balance = bal;
			Name = name;
		}

		public void AddBalance(float amount)
		{
			Balance += amount;
		}

	}

	public static void Main()
	{
		var acc = new Account("001", (float)20.0, "Nevin");
		acc.AddBalance(40);
	}
}