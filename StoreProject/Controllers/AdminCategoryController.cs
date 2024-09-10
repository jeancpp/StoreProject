using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.Models;
using StoreProject.Models.Domain;
using StoreProject.Models.ViewModels;
using StoreProject.Repositories;

namespace StoreProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        public AdminCategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> SaveCategory(AddCategoryRequest addCategoryRequest)
        {

            var category = new Category
            {
                CategoryName = addCategoryRequest.Name,
                CategoryDescription = addCategoryRequest.Description,

                CreationDate = DateTime.Now,
            };

            await categoryRepository.AddAsync(category);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            var categories = await categoryRepository.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await categoryRepository.GetAsync(id);

            if (category != null)
            {
                var editCategoryRequest = new EditCategoryRequest
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription

                };

                return View(editCategoryRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryRequest editCategoryRequest)
        {

            var category = new Category
            {
                CategoryId = editCategoryRequest.CategoryId,
                CategoryName = editCategoryRequest.CategoryName,
                CategoryDescription = editCategoryRequest.CategoryDescription

            };

            var existingCategory = await categoryRepository.UpdateAsync(category);

            if (existingCategory != null)
            {
                return RedirectToAction("List");
            }

            else
            {
                return RedirectToAction("Edit", new { id = category.CategoryId });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = await categoryRepository.DeleteAsync(id);

            if (deletedCategory != null) 
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = id });
        }
    }
}
