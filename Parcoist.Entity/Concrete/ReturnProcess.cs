namespace Parcoist.UI.Entities
{
    public class ReturnProcess
    {
        public int ReturnProcessID { get; set; }
        public int ReturnRequestID { get; set; }
        public int CourierID { get; set; }
        public int CarrierID { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime RefundDate { get; set; }
        public string AdminNotes { get; set; }
        public DateTime ComplatedAt { get; set; }
    }
}
