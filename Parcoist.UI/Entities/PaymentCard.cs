namespace Parcoist.UI.Entities
{
    public class PaymentCard
    {
        public int PaymentCardID { get; set; }
        public int CustomerID { get; set; }
        public string CardName { get; set; }
        public string CardLast4 { get; set; }
        public DateTime ExpireMonth { get; set; }
        public DateTime ExpireYear { get; set; }
        public string CardType { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CardToken { get; set; }
    }
}
