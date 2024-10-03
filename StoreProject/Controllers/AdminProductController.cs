using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreProject.Models.Domain;
using StoreProject.Models.ViewModels;
using StoreProject.Repositories;

namespace StoreProject.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public AdminProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> List()
        {
            var products = await productRepository.GetAllAsync();
            return View(products);
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

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> SaveProduct(AddProductRequest addProductRequest)
        {

            var product = new Product
            {
                ProductName = addProductRequest.ProductName,
                Description = addProductRequest.Description,
                Price = addProductRequest.Price,
                Stock = addProductRequest.Stock,
                FeaturedImageUrl = addProductRequest.FeaturedImageUrl,
                Visible = addProductRequest.Visible,

                CreationDate = DateTime.Now,
            };

            var selectedCategories = new List<Category>();
            foreach (var selectedCategoryId in addProductRequest.SelectedCategories)
            {
                var selectedCategoryAsInt = int.Parse(selectedCategoryId);
                var existingCategory = await categoryRepository.GetAsync(selectedCategoryAsInt);
                if (existingCategory != null) 
                {
                   selectedCategories.Add(existingCategory); 
                }
            }

            product.Categories = selectedCategories;
            await productRepository.AddAsync(product);
            return RedirectToAction("Add");
        }
    }
}
