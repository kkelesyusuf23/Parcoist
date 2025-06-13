namespace Parcoist.UI.Entities
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        public int CourierID { get; set; }
        public int CarrierID { get; set; }
        public string Notes { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public int DeliveryStatusID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UptadetAt { get; set; }

    }
}
