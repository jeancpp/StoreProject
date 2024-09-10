using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.Models.Domain;

namespace StoreProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _StoreDbContext;
        public CategoryRepository(StoreDbContext storeDbContext)
        {
            this._StoreDbContext = storeDbContext;
        }
        public async Task<Category> AddAsync(Category category)
        {
            await _StoreDbContext.Categories.AddAsync(category);
            await _StoreDbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var existingCategory = await _StoreDbContext.Categories.FindAsync(id);

            if (existingCategory != null) 
            {
                _StoreDbContext.Categories.Remove(existingCategory);
                await _StoreDbContext.SaveChangesAsync();
                return existingCategory;
            }

            return null;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _StoreDbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetAsync(int id)
        {
            var category = await _StoreDbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            return category;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await _StoreDbContext.Categories.FindAsync(category.CategoryId);

            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.CategoryDescription = category.CategoryDescription;

                await _StoreDbContext.SaveChangesAsync();
                return existingCategory;

            }
            return null;
        }
    }
}
