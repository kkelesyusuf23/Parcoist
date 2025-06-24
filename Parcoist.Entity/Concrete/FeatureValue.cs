using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Entity.Concrete
{
    public class FeatureValue
    {
        public int FeatureValueID { get; set; }

        public int FeatureTypeID { get; set; } // İlgili özellik türü (örneğin "Renk")
        public FeatureType FeatureType { get; set; }

        public string Value { get; set; } // Örneğin "Kırmızı", "M", "XL"
        public DateTime UpdatedAt { get; set; } 
        public int PriceAdjustment { get; set; } // Bu değerin fiyat üzerindeki etkisi
        public int Stock { get; set; } // Bu değerin stoğu
    }

}





