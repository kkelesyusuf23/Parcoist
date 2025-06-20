using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Entity.Concrete
{
    public class ProductVariantCombination
    {
        public int ProductVariantCombinationID { get; set; }

        public int ProductID { get; set; } // İlgili ürün
        public Product Product { get; set; }

        public string VariantKey { get; set; } // Örneğin: "Kırmızı-M"
        public int Stock { get; set; } // Varyantın stoğu
        public int PriceAdjustment { get; set; } // Fiyat farkı
        public bool isDefault { get; set; } // Varsayılan mı?
        public DateTime CreatedAt { get; set; }

        public List<ProductVariantValue> ProductVariantValues { get; set; } // Bir kombinasyon birden fazla özellik değeri içerebilir
    }

}
