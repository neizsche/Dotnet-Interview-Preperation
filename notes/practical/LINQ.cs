using System;
using System.Collections.Generic;
using System.Linq; // CRITICAL: This is where the magic lives

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}

public class LinqDemo
{
    public static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200, Category = "Electronics" },
            new Product { Name = "Phone", Price = 800, Category = "Electronics" },
            new Product { Name = "Shirt", Price = 25, Category = "Clothing" },
            new Product { Name = "Desk", Price = 200, Category = "Furniture" },
            new Product { Name = "Monitor", Price = 300, Category = "Electronics" }
        };

        // 1. METHOD SYNTAX (Most common in industry)
        var expensiveElectronics = products
            .Where(p => p.Category == "Electronics") // Filter
            .OrderByDescending(p => p.Price)        // Sort
            .Select(p => p.Name);                   // Transform (Project)

        // 2. QUERY SYNTAX (Looks like SQL)
        var queryStyle = from p in products
                         where p.Price < 500
                         select p.Name;

        // 3. AGGREGATES (Math)
        decimal totalValue = products.Sum(p => p.Price);
        decimal maxPrice = products.Max(p => p.Price);

        // 4. ELEMENT OPERATORS
        // FirstOrDefault is safer than First() because it doesn't crash if the list is empty.
        var search = products.FirstOrDefault(p => p.Name == "Phone");

        // 5. GROUPING
        var groupedByCategory = products.GroupBy(p => p.Category);

        Console.WriteLine("--- Electronics (Expensive to Cheap) ---");
        foreach (var name in expensiveElectronics) Console.WriteLine(name);
    }
}