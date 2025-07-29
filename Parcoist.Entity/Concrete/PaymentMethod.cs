namespace Parcoist.UI.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
