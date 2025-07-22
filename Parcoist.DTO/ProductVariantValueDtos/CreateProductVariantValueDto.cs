using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.ProductVariantValueDtos
{
    public class CreateProductVariantValueDto
    {
        public int CombinationID { get; set; } // Varyant kombinasyonu
        public int FeatureTypeID { get; set; }  // Özellik türü (örneğin renk)
        public int FeatureValueID { get; set; } // Özellik değeri (örneğin kırmızı)    }
    }
}