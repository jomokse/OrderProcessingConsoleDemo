// This file contains integration tests for the OrderRepository class, verifying database persistence.
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OrderProcessingConsoleDemo.Models;
using OrderProcessingConsoleDemo.Services;
using Xunit;

namespace OrderProcessingConsoleDemo.Tests.Integration
{
    // Integration tests for the OrderRepository class.
    public class OrderRepositoryTests
    {
        // Tests that saving an order persists the data to the in-memory SQLite database.
        [Fact]
        public async Task SaveOrder_PersistsDataToDatabase()
        {
            // Create an in-memory SQLite connection for testing.
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            // Configure the DbContext to use the in-memory SQLite connection.
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseSqlite(connection)
                .Options;

            // Create a new database context and ensure the schema is created.
            using var context = new OrderDbContext(options);
            context.Database.EnsureCreated();

            // Create a test customer and a list of products.
            var customer = new Customer { Name = "Test Customer", IsLoyalCustomer = false };
            var products = new List<Product>
            {
                new Product { Name = "Product1", Price = 50 },
                new Product { Name = "Product2", Price = 75 }
            };

            // Create a new order with the test customer and products.
            var order = new Order
            {
                Customer = customer,
                Products = products
            };

            // Create the repository and save the order asynchronously.
            var repo = new OrderRepository(context);
            await repo.SaveOrderAsync(order);

            // Assert that the order was saved and contains the correct number of products.
            Assert.Single(context.Orders);
            Assert.Equal(2, context.Orders.First().Products.Count);
        }
    }
}
