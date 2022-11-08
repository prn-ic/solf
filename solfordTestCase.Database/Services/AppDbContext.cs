using Microsoft.EntityFrameworkCore;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Database.Services
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().Property(x => x.Quantity).HasPrecision(18, 3);
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnType("datetime2(7)");
            modelBuilder.Entity<Order>().HasIndex(x => x.Number).IsUnique();
        }
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Provider> Providers => Set<Provider>();

    }
}