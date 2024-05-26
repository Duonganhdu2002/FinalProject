namespace FinalProject.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IconPath { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
