namespace Parcoist.UI.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
        public List<Adress> Adresses { get; set; }

        public List<CustomerCoupon> CustomerCoupons { get; set; }
        public List<CustomerFavory> FavoriteProducts { get; set; }

        public List<Order> Orders { get; set; }
        public List<Delivery> Deliveries { get; set; }

        // Ödeme kartları ilişki ekleniyor
        public List<PaymentCard> PaymentCards { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }


}
