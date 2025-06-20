namespace Parcoist.UI.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string LogoURL { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }     
        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public List<BrandCategory> BrandCategories { get; set; }

        public OrderBrandStatus OrderBrandStatus { get; set; }
    }

}
