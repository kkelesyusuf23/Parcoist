namespace Parcoist.UI.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int ProductFeaturedID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal LineTotal { get; set; }
        public string SnapshotFeatureName { get; set; }
        public string SnapshotFeatureValue { get; set; }

    }
}
