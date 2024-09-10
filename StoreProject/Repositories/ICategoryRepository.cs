using StoreProject.Models.Domain;

namespace StoreProject.Repositories
{
    public interface ICategoryRepository
    {
        Task <IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetAsync(int id);

        Task <Category>AddAsync(Category category);

        Task<Category?> UpdateAsync(Category category);
        Task<Category?> DeleteAsync(int id);

    }
}
