namespace StoreProject.Models.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string FeaturedImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Visible { get; set; }
        public ICollection <Category> Categories { get; set; }
    }
}
