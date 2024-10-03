using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.Models.Domain;

namespace StoreProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await storeDbContext.Products.AddAsync(product);
            await storeDbContext.SaveChangesAsync();
            return product;
            
        }

        public Task<Product?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await storeDbContext.Products.Include(x=> x.Categories).ToListAsync();
            return products;
        }

        public Task<Product?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
