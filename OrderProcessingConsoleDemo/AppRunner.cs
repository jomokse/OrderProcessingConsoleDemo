using OrderProcessingConsoleDemo.Models;
using OrderProcessingConsoleDemo.Services;
using Microsoft.EntityFrameworkCore;

namespace OrderProcessingConsoleDemo
{
    public class AppRunner
    {
        public static async Task Run(string dbPath = "orders.db")
        {
            // Configure the database context to use a SQLite database named 'orders.db'.
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            // Create a new instance of the database context and ensure the database is created.
            using var dbContext = new OrderDbContext(options);
            dbContext.Database.EnsureCreated();

            // Create a new customer with the name 'John Doe' who is marked as a loyal customer.
            var customer = new Customer { Name = "John Doe", IsLoyalCustomer = true };
            // Create a list of products to be included in the order.
            var products = new List<Product>
            {
                new Product { Name = "Product A", Price = 100 },
                new Product { Name = "Product B", Price = 200 }
            };

            // Create an instance of the order service to handle business logic.
            var orderService = new OrderService();
            // Create a new order for the customer with the specified products.
            var order = orderService.CreateOrder(customer, products);

            // Create an instance of the repository to handle database operations.
            var repo = new OrderRepository(dbContext);
            // Save the order asynchronously to the database.
            await repo.SaveOrderAsync(order);

            // Output the order details to the console.
            Console.WriteLine($"The order for the customer: {customer.Name}");
            Console.WriteLine($"Total: {order.Total} Euros");
        }
    }
}