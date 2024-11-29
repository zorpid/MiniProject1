// See https://aka.ms/new-console-template for more information

ProductListManager productManager = new ProductListManager();


while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - follow the steps | To quit - enter: Q");
    Console.ResetColor();
    Console.Write("Enter Category: ");
    string category  = Console.ReadLine();
    if (category.ToLower() == "q") break;
    Console.Write("Enter Product Name: ");
    string productName = Console.ReadLine();
    if (productName.ToLower() == "q") break;

    double price;

    while (true)
    {
        Console.Write("Enter Product Price : ");
        string priceInput = Console.ReadLine();
        if (priceInput.ToLower() == "q") return;
        if (double.TryParse(priceInput, out price))
        {
            break;
        }
        else { 
            Console.WriteLine("Invalid price. Please enter a valid number."); }
    }
    Product product = new Product(category, productName, price);
    productManager.AddProduct(product);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Product added successfully!");
}

productManager.PrintSumSorted();
productManager.PrintProductDetails();

while (true)
{
    Console.ResetColor();
    Console.WriteLine("\nTo enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
    Console.Write("Enter your choice: ");
    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "P":
            // Loop to add new product
            while (true)
            {
                Console.ResetColor();
                
                Console.Write("Enter Category or type 'q' to quit adding products: ");
                string newCategory = Console.ReadLine();
                if (newCategory.ToLower() == "q") break;

                
                Console.Write("Enter Product Name or type 'q' to quit adding products: ");
                string newProductName = Console.ReadLine();
                if (newProductName.ToLower() == "q") break;

                double newPrice = 0;

                
                while (true)
                {
                    Console.Write("Enter Product Price or type 'q' to quit adding products: ");
                    string priceInput = Console.ReadLine();
                    if (priceInput.ToLower() == "q") break;

                    if (double.TryParse(priceInput, out newPrice))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                        Console.ResetColor();
                    }
                }

                // Create a product and add it to the product manager
                Product newProduct = new Product(newCategory, newProductName, newPrice); 
                productManager.AddProduct(newProduct);

                // Confirm product addition
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product added successfully!");
            }
            break;

        case "S":
            Console.Write("Enter product name to search: ");
            string searchName = Console.ReadLine();
            var product = productManager.SearchProduct(searchName);
            if (product != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Product Found: Category - {product.Category}, Name - {product.ProductName}, Price - {product.Price:C}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found.");
            }
            break;

        case "Q":
            
            return;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please enter P, S, or Q.");
            break;
    }
}

