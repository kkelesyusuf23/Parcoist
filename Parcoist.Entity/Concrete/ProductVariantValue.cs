using Parcoist.Entity.Concrete;

namespace Parcoist.UI.Entities
{
    public class ProductVariantValue
    {
        public int ProductVariantValueID { get; set; }

        public int CombinationID { get; set; } // Varyant kombinasyonu
        public ProductVariantCombination Combination { get; set; }

        public int FeatureTypeID { get; set; }  // Özellik türü (örneğin renk)
        public FeatureType FeatureType { get; set; }

        public int FeatureValueID { get; set; } // Özellik değeri (örneğin kırmızı)
        public FeatureValue FeatureValue { get; set; }
    }

}
