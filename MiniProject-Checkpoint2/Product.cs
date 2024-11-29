// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;
using System.Xml.Linq;

public class Product
{
    public string Category { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(string category, string name, double price)
    {
        Category = category;
        ProductName = name;
        Price = price;
    }

    public void PrintFormatted()
    {
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine(); 
    }

  
}