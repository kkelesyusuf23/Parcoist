namespace Parcoist.UI.Entities
{
    public class PaymentCard
    {
        public int PaymentCardID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public string CardName { get; set; }
        public string CardLast4 { get; set; } // Güvenlik nedeniyle sadece son 4 rakamı saklamak
        public DateTime ExpireMonth { get; set; }
        public DateTime ExpireYear { get; set; }
        public string CardType { get; set; }
        public bool IsDefault { get; set; } // Varsayılan kart
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CardToken { get; set; } // Kart token'ı, güvenli ödeme için kullanılır
    }

}
