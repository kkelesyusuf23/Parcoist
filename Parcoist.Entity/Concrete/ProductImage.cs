namespace Parcoist.UI.Entities
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public string ImagePath { get; set; }
        public string Order { get; set; } // Görsellerin sırası

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
