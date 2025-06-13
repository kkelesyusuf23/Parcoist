namespace Parcoist.UI.Entities
{
    public class ReturnItem
    {
        public int ReturnItemID { get; set; }
        public int ReturnRequestID { get; set; }
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public bool Condition { get; set; }
        public int ApprovedQuantity { get; set; }
        public int RefundAmount { get; set; }
    }
}
