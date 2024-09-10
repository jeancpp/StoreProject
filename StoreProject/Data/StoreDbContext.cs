using Microsoft.EntityFrameworkCore;
using StoreProject.Models.Domain;

namespace StoreProject.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>Products { get; set; }
        public DbSet<Category>Categories { get; set; }
    }
}
