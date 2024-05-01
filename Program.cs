using System;
using System.Collections.Generic;
using System.Linq;


public delegate double CalcDelegate(double x, double y, char op);


public interface ISwimmable
{
    void Swim();
}


public interface IFlyable
{
    double MaxHeight { get; }
    void Fly();
}


public interface IRunnable
{
    double MaxSpeed { get; }
    void Run();
}


public interface IAnimal
{
    double LifeDuration { get; }
    void Voice();
    void ShowInfo();
}


public class CalcProgram
{
    
    public static double Calc(double x, double y, char op)
    {
        switch (op)
        {
            case '+': return x + y;
            case '-': return x - y;
            case '*': return x * y;
            case '/': return y != 0 ? x / y : 0;
            default: throw new ArgumentException("Unknown operation");
        }
    }
}


public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    
    public static void TotalPrice(ILookup<string, Product> search)
    {
        foreach (var group in search)
        {
            double totalPriceForCategory = 0;
            Console.WriteLine(group.Key);
            foreach (var product in group)
            {
                Console.WriteLine($"{product.Name} {product.Price}");
                totalPriceForCategory += product.Price;
            }
            Console.WriteLine($"Total: {totalPriceForCategory}");
        }
    }

    static void Main(string[] args)
    {
        
        var products = new List<Product>();
        products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
        products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
        products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
        products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
        products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });

       
        ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);

        
        TotalPrice(lookup);

        Console.ReadKey();
    }
}
