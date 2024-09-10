namespace StoreProject.Models.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public DateTime CreationDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}