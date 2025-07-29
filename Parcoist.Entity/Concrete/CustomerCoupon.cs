namespace Parcoist.UI.Entities
{
    public class CustomerCoupon
    {
        public int CustomerCouponID { get; set; }

        public int CustomerID { get; set; }

        // Navigation property
        public Customer Customer { get; set; }

        public string CouponCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsUsed { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
