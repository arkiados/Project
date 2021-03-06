using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project
{
    public class InventoryContext : DbContext
    {

        public InventoryContext()
        {

        }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public DbSet<InventoryItem> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>().ToTable("InventoryItem");
        }
    }
}
