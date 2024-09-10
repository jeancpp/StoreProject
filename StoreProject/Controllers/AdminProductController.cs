using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreProject.Models.ViewModels;
using StoreProject.Repositories;

namespace StoreProject.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public AdminProductController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Add()
        {
            var categories = await categoryRepository.GetAllAsync();

            var model = new AddProductRequest
            {
                Categories = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() })
            };
            return View(model);
        }
    }
}
