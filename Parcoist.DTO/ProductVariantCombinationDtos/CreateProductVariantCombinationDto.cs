using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.ProductVariantCombinationDtos
{
    public class CreateProductVariantCombinationDto
    {
        public int ProductID { get; set; } // İlgili ürün
        public string VariantKey { get; set; } // Örneğin: "Kırmızı-M"
        public int Stock { get; set; } // Varyantın stoğu
        public int PriceAdjustment { get; set; } // Fiyat farkı
    }
}
