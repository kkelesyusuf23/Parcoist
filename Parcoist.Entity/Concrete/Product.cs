namespace Parcoist.UI.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int SKU { get; set; }
        public string ModelNo { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public int CategoryID { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

        public int Stock { get; set; }
        public string Description { get; set; }

        public string? Link1 { get; set; }
        public string? Link2 { get; set; }
        public string? Link3 { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UptatedAt { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; } 

        // One-to-Many ilişki
        public List<CustomerFavory> CustomerFavorites { get; set; }

        // One-to-Many ilişki
        public List<OrderItem> OrderItems { get; set; }

        // One-to-Many ilişki: Bir ürün birden fazla görsele sahip olabilir
        public List<ProductImage> ProductImages { get; set; }

        public List<UserComment> UserComments { get; set; }

    }


}
