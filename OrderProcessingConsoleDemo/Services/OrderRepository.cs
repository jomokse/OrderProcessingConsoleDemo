// This file contains the OrderDbContext and OrderRepository classes, which handle database access for orders, customers, and products.
using Microsoft.EntityFrameworkCore;
using OrderProcessingConsoleDemo.Models;

namespace OrderProcessingConsoleDemo.Services
{
    // The Entity Framework Core DbContext for the order processing application.
    // Provides access to Customers, Products, and Orders tables.
    public class OrderDbContext : DbContext
    {
        // DbSet representing the Customers table in the database.
        public DbSet<Customer> Customers => Set<Customer>();
        // DbSet representing the Products table in the database.
        public DbSet<Product> Products => Set<Product>();
        // DbSet representing the Orders table in the database.
        public DbSet<Order> Orders => Set<Order>();

        // Constructor that accepts DbContextOptions for configuration (e.g., connection string).
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
    }

    // Repository class for handling order-related database operations.
    public class OrderRepository
    {
        // The application's database context, injected via constructor.
        private readonly OrderDbContext _context;

        // Constructor that receives the OrderDbContext dependency.
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        // Asynchronously saves a new order to the database.
        // Parameters:
        //   order - The Order entity to be saved.
        public async Task SaveOrderAsync(Order order)
        {
            _context.Orders.Add(order); // Add the order to the Orders DbSet.
            await _context.SaveChangesAsync(); // Persist changes to the database.
        }
    }
}