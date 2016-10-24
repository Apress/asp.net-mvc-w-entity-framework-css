using BabyStore.Models;
using System.Data.Entity;

namespace BabyStore.DAL
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}