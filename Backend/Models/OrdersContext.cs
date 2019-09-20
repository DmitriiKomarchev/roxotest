using Backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.InitialDataSeed();
        }
    }
}
