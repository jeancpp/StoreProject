using Microsoft.AspNetCore.Mvc.Rendering;
using StoreProject.Models.Domain;

namespace StoreProject.Models.ViewModels
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string FeaturedImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Visible { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public string SelectedCategories { get; set; }
    }
}
