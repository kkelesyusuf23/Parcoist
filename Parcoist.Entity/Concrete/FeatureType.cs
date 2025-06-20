namespace Parcoist.UI.Entities
{
    public class FeatureType
    {
        public int FeatureTypeID { get; set; }
        public string Value { get; set; } // Örneğin: "Renk" veya "Beden"
        public DateTime UpdatetAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PriceAdjustment { get; set; } // Bu türdeki bir özelliğin fiyat üzerinde etkisi varsa
        public bool IsDefault { get; set; } // Varsayılan mı?

        public List<FeatureTypeCategory> FeatureTypeCategories { get; set; } // Kategorilere bağlanabilir
    }


}
