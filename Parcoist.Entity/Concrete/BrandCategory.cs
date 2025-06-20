namespace Parcoist.UI.Entities
{
    public class BrandCategory
    {
        public int BrandID { get; set; }
        public int CategoryID { get; set; }

        // Navigation
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }

}
