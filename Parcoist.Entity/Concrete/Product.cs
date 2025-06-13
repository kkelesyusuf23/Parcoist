namespace Parcoist.UI.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int SKU { get; set; }
        public string Name { get; set; }    
        public string Slug { get; set; }
        public int CategoryID { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscoundetPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UptatedAt { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public int BrandID { get; set; }
    }
}
