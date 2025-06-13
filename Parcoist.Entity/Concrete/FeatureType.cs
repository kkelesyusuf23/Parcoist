namespace Parcoist.UI.Entities
{
    public class FeatureType
    {
        public int FeatureTypeID { get; set; }
        public string Value { get; set; }
        public DateTime UpdatetAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PriceAdjustment { get; set; }
        public bool IsDefault { get; set; }

    }
}
