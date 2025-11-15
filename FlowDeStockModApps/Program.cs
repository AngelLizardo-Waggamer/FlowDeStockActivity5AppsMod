/**
 * Program.cs
 * Emulation of the process that QuickInv follows to modify the stock of a Product
 */
using FlowDeStockModApps;
using FlowDeStockModApps.Data;
using FlowDeStockModApps.Users;

// The first step is to create a company that will have the inventory
Company greedyCompany = new(1, "BaussyCorp");

// Before the next step, a list of products need to be created
List<Product> products =
[
    new Product("Laptop", "High-performance laptop with 16GB RAM", 25, 899.99f, "Electronics"),
    new Product("Office Chair", "Ergonomic office chair with lumbar support", 50, 249.99f, "Furniture"),
    new Product("Coffee Maker", "Automatic drip coffee maker with timer", 100, 79.99f, "Appliances"),
    new Product("Notebook Set", "Pack of 5 ruled notebooks, 100 pages each", 200, 12.99f, "Stationery"),
    new Product("Wireless Mouse", "Bluetooth wireless mouse with adjustable DPI", 150, 29.99f, "Electronics")
];

// Store initial values for comparison
string initialProductOne = $"Product {products[0].Name}: {products[0].Quantity}";
string initialProductTwo = $"Product {products[1].Name}: {products[1].Quantity}";

// After that, the inventory is created.
Inventory inventory = new(69, "A department store inventory", products, greedyCompany);

// Then, two users are created, one with normal user role and the other one with admin role.
User userOne = new(1, "Alan Bauza", "alan@gmail.com", "alansito123", greedyCompany, Roles.USER);
User userTwo = new(2, "Luis Enrique", "LuisE@gmail.com", "luisito123", greedyCompany, Roles.ADMIN);

// After that, let's suppose that userOne wants to modify the stock of a product.
// userOne is not an admin, so the request will be rejected.
Console.WriteLine($"\nUser {userOne.Name} is trying to increase the stock of product ID 1 by 30 units.");
Backend.MakeRequestToChangeStock(userOne, StockChangeOperation.INCREASE, inventory, 1, 30);

// If userTwo makes the same request, it will be successful.
Console.WriteLine($"\nUser {userTwo.Name} is trying to increase the stock of product ID 1 by 30 units.");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.INCREASE, inventory, 1, 30);

// But if userTwo wants to increase the stock of a product with a negative amount, the request will be rejected.
Console.WriteLine($"\nUser {userTwo} is trying to increase the stock of product ID 2 by -5 units (which is wrong)");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.INCREASE, inventory, 2, -5);

// And the same happens if userTwo wants to increase the stock of a product with zero amount.}
Console.WriteLine($"\nUser {userTwo} is trying to increase the stock of product ID 2 by 0 units (which is wrong)");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.INCREASE, inventory, 2, 0);

// Then, if userTwo wants to decrease the stock of a product (but exceeding the current quantity), the request will be rejected.
Console.WriteLine($"\nUser {userTwo} is trying to decrease the stock of product ID 2 by 1000 units (which is wrong)");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.DECREASE, inventory, 2, 1000);

// The same happens if userTwo wants to decrease the stock of a product with a negative amount.
Console.WriteLine($"\nUser {userTwo} is trying to decrease the stock of product ID 2 by -20 units (which is wrong)");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.DECREASE, inventory, 2, -20);

// Or if userTwo wants to decrease the stock of a product with zero amount.
Console.WriteLine($"\nUser {userTwo} is trying to decrease the stock of product ID 2 by 0 units (which is wrong)");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.DECREASE, inventory, 2, 0);

// Finally, if userTwo decreases the stock of a product within the limits, the request will be successful.
Console.WriteLine($"\nUser {userTwo.Name} is trying to increase the stock of product ID 2 by 10 units.");
Backend.MakeRequestToChangeStock(userTwo, StockChangeOperation.DECREASE, inventory, 2, 10);

// Initial values
Console.WriteLine("\nInitial Values of the products");
Console.WriteLine(initialProductOne);
Console.WriteLine(initialProductTwo);

// Actual values
Console.WriteLine("\nValues after the modifications");
Console.WriteLine($"Product {inventory.GetProduct(1).Name}: {inventory.GetProduct(1).Quantity}");
Console.WriteLine($"Product {inventory.GetProduct(2).Name}: {inventory.GetProduct(2).Quantity}");