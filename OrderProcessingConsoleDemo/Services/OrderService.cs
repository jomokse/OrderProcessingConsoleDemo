// This file defines the OrderService class, which provides business logic for creating orders.
using OrderProcessingConsoleDemo.Models;

namespace OrderProcessingConsoleDemo.Services
{
    // Service class responsible for order-related business operations.
    public class OrderService
    {
        // Creates a new Order object for a given customer and list of products.
        // Parameters:
        //   customer - The customer placing the order.
        //   products - The list of products included in the order.
        // Returns:
        //   An Order object with the specified customer and products.
        public Order CreateOrder(Customer customer, List<Product> products)
        {
            return new Order
            {
                Customer = customer,
                Products = products
            };
        }
    }
}
