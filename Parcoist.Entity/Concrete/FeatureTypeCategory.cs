namespace Parcoist.UI.Entities
{
    public class FeatureTypeCategory
    {
        public int FeatureTypeCategoryID { get; set; }

        public int FeatureTypeID { get; set; }
        public FeatureType FeatureType { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }

}
