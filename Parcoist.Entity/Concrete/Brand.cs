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
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
