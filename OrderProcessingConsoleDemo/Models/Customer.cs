// This file defines the Customer model used in the order processing application.
namespace OrderProcessingConsoleDemo.Models
{
    // Represents a customer who can place orders.
    public class Customer
    {
        // Unique identifier for the customer (primary key).
        public int Id { get; set; }
        // Name of the customer.
        public string Name { get; set; } = string.Empty;
        // Indicates whether the customer is considered loyal (eligible for discounts).
        public bool IsLoyalCustomer { get; set; }
    }
}