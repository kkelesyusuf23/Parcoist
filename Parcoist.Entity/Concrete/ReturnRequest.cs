namespace Parcoist.UI.Entities
{
    public class ReturnRequest
    {
        public int ReturnRequestID { get; set; }
        public int OrderID { get; set; }
        public int ReturnNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ReturnStatusID { get; set; }
        public int ReturnReasonID { get; set; }

    }
}
