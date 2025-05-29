// This file defines the Order model used in the order processing application.
namespace OrderProcessingConsoleDemo.Models
{
    // Represents a customer's order, containing products and customer information.
    public class Order
    {
        // Unique identifier for the order (primary key).
        public int Id { get; set; }
        // The customer who placed the order.
        public Customer Customer { get; set; } = new();
        // The list of products included in the order.
        public List<Product> Products { get; set; } = new();
        // The total price of the order, applying a 10% discount if the customer is loyal.
        public decimal Total => Products.Sum(p => p.Price) * (Customer.IsLoyalCustomer ? 0.9m : 1.0m);
    }
}