namespace Parcoist.UI.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public int? ParentCategoryID { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }

        // Self-referencing navigation properties
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }

        // Many-to-many
        public List<BrandCategory> BrandCategories { get; set; }

        public List<FeatureTypeCategory> FeatureTypeCategories { get; set; }
    }

}
