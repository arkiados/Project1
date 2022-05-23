using Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public DbSet<InventoryItem> Inventory { get; set; }
    }
}
