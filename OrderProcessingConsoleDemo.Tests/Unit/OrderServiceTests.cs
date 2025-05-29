// This file contains unit tests for the OrderService class, verifying business logic for order creation and pricing.
using OrderProcessingConsoleDemo.Models;
using OrderProcessingConsoleDemo.Services;
using Xunit;

namespace OrderProcessingConsoleDemo.Tests.Unit
{
    // Unit tests for the OrderService class.
    public class OrderServiceTests
    {
        // Test to verify that a loyal customer receives a 10% discount on the order total.
        [Fact]
        public void LoyalCustomerGetsDiscount()
        {
            // Arrange: Create the service, a loyal customer, and a product list.
            var service = new OrderService();
            var customer = new Customer { Name = "Test Customer", IsLoyalCustomer = true };
            var products = new List<Product>
            {
                new Product { Name = "Test Product", Price = 100 }
            };

            // Act: Create the order using the service.
            var order = service.CreateOrder(customer, products);

            Assert.Equal("Test Customer", order.Customer.Name);
            Assert.True(order.Customer.IsLoyalCustomer);  
            // Assert: The total should reflect a 10% discount.
            Assert.Equal(90, order.Total);
        }

        // Test to verify that a regular (non-loyal) customer pays full price for the order.
        [Fact]
        public void RegularCustomerPaysFullPrice()
        {
            // Arrange: Create the service, a regular customer, and a product list.
            var service = new OrderService();
            var customer = new Customer { Name = "Test Customer", IsLoyalCustomer = false };
            var products = new List<Product>
            {
                new Product { Name = "Test Product", Price = 100 }
            };

            // Act: Create the order using the service.
            var order = service.CreateOrder(customer, products);

            // Assert: The total should be the full price (no discount).
            Assert.Equal(100, order.Total);
        }
    }
}