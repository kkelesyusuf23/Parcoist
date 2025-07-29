namespace Parcoist.UI.Entities
{
    public class DeliveryStatus
    {
        public int DeliveryStatusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Delivery> Deliveries { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
