// See https://aka.ms/new-console-template for more information
internal class ProductListManager
{
    private List<Product> productList;

    public ProductListManager()
    {
        productList = new List<Product>();
    }
    public void AddProduct(Product product)
    {
        productList.Add(product);
    }
    // 
    public void PrintProductDetails()
    {

        var sortedProducts = productList.OrderBy(p => p.Price).ToList();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price".PadRight(15));
        Console.ResetColor();
        foreach (var product in sortedProducts)
        {
            Console.WriteLine(product.Category.PadRight(15) + product.ProductName.PadRight(15) + product.Price.ToString().PadRight(1));
        }
        double totalAmount = productList.Sum(product => product.Price);
        Console.WriteLine( "".PadRight(15)+"Total amount:".PadRight(15)+totalAmount );
        Console.WriteLine("--------------------------------------------------------------------");
    }

    // Function/method that sorts and adds the sum of price
    public void PrintSumSorted()
    {
        var sortedProducts = productList.OrderBy(p => p.Price).ToList();

        Console.WriteLine("\nList of all products (sorted by price):");
        foreach (var product in sortedProducts)
        {
            product.PrintFormatted();
        }

        double totalPrice = sortedProducts.Sum(p => p.Price);
        Console.WriteLine($"Total Price of all Products: {totalPrice:C}");
    }
    public Product SearchProduct(string productName)
    {
        // Search for the product using linq
        var foundProduct = productList.FirstOrDefault(product => product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (foundProduct != null)
        {
            // Print all products and highlight the found product
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price".PadRight(15));

            foreach (var product in productList)
            {
                if (product.ProductName.Equals(foundProduct.ProductName, StringComparison.OrdinalIgnoreCase))
                {

                    Console.ForegroundColor = ConsoleColor.Magenta; // Highlight color
                }
                else
                {
                    Console.ResetColor(); 
                }

                Console.WriteLine(product.Category.PadRight(15) + product.ProductName.PadRight(15) + product.Price.ToString().PadRight(15));
            }

            Console.ResetColor(); // Reset console color after printing
            Console.WriteLine("--------------------------------------------------------------------");
        }

        return foundProduct;
    }

    
}