using Parcoist.UI.Entities;

namespace Parcoist.UI.Models
{
    public class ProductFilterViewModel
    {
        public List<Product> Products { get; set; }

        // Filtre seçenekleri
        public List<Category> Categories { get; set; }
        public List<string> Brands { get; set; }
        public List<decimal> Prices { get; set; }

        // Seçili filtreler
        public int? SelectedCategoryId { get; set; }
        public string SelectedBrand { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
    }
}
