namespace Parcoist.UI.Entities
{
    public class BrandCategory
    {
        public int BrandCategoryID { get; set; }
        public int CategoryID { get; set; }

        // Navigation
        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
