using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using System.Collections.Generic;

namespace SIMS.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<InventoryItem> Items { get; set; }
    }
}

