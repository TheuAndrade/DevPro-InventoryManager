using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
}

public class InventoryManager
{
    public List<Product> SortProducts(List<Product> products, string sortKey, bool ascending)
    {
        switch (sortKey.ToLower())
        {
            case "name":
                if (ascending)
                    return products.OrderBy(p => p.Name).ToList();
                else
                    return products.OrderByDescending(p => p.Name).ToList();
            case "price":
                if (ascending)
                    return products.OrderBy(p => p.Price).ToList();
                else
                    return products.OrderByDescending(p => p.Price).ToList();
            case "stock":
                if (ascending)
                    return products.OrderBy(p => p.Stock).ToList();
                else
                    return products.OrderByDescending(p => p.Stock).ToList();
            default:
                throw new ArgumentException("Invalid sort key. Valid keys are 'name', 'price', or 'stock'.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Product A", Price = 100, Stock = 1 },
            new Product { Name = "Product B", Price = 200, Stock = 2 },
            new Product { Name = "Product C", Price = 300, Stock = 3 },
            new Product { Name = "Product D", Price = 400, Stock = 4 },
            new Product { Name = "Product E", Price = 500, Stock = 5 }
        };

        string sortKey = "price"; 
        bool ascending = false;

        InventoryManager manager = new InventoryManager();
        List<Product> sortedProducts = manager.SortProducts(products, sortKey, ascending);

        //Display
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
        }
    }
}
