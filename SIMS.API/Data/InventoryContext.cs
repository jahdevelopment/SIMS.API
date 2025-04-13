using Microsoft.EntityFrameworkCore;
using SIMS.Models;

namespace SIMS.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<InventoryItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { Id = 1, Brand = "Nike", Reference = "NK001", Size = "10", Colour = "Black", Quantity = 15, UnitPrice = 120.00M },
                new InventoryItem { Id = 2, Brand = "Adidas", Reference = "AD002", Size = "9", Colour = "White", Quantity = 10, UnitPrice = 100.00M },
                new InventoryItem { Id = 3, Brand = "Puma", Reference = "PM003", Size = "8", Colour = "Blue", Quantity = 20, UnitPrice = 90.00M }
            );
        }
    }
}

