// This file defines the OrderDbContextFactory class, which is used to create OrderDbContext instances at design time for Entity Framework Core tooling.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderProcessingConsoleDemo.Services
{
    // Factory class for creating OrderDbContext instances during design time (e.g., for migrations).
    // Implements IDesignTimeDbContextFactory<OrderDbContext> to support EF Core CLI tools.
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        // Creates a new OrderDbContext with the specified options.
        // This method is called by EF Core tools at design time.
        // Parameters:
        //   args - Command-line arguments (not used here).
        // Returns:
        //   A configured OrderDbContext instance using a SQLite database.
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            // Configure the context to use a SQLite database named 'orders.db'.
            optionsBuilder.UseSqlite("Data Source=orders.db");

            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}