// This file defines the Product model used in the order processing application.
namespace OrderProcessingConsoleDemo.Models
{
    // Represents a product that can be ordered by a customer.
    public class Product
    {
        // Unique identifier for the product (primary key).
        public int Id { get; set; }
        // Name of the product.
        public string Name { get; set; } = string.Empty;
        // Price of the product.
        public decimal Price { get; set; }
    }
}