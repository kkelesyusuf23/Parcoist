using Parcoist.UI.Entities;

namespace Parcoist.UI.Models
{
    public class ProductFilterViewModel
    {
        public List<Product> Products { get; set; }

        // Filtre Seçenekleri
        public List<string> Categories { get; set; }
        public List<string> Brands { get; set; }
        public List<decimal> Prices { get; set; }

        // Seçili filtreler
        public string SelectedCategory { get; set; }
        public string SelectedBrand { get; set; }
        public decimal? MaxPrice { get; set; }
    }

}
