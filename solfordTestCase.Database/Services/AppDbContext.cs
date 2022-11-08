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
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Provider> Providers => Set<Provider>();

    }
}