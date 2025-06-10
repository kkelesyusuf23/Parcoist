namespace Parcoist.UI.Entities
{
    public class CustomerCoupon
    {
        public int CustomerCouponID { get; set; }
        public int CustomerID { get; set; }
        public string CouponCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsUsed { get; set; }
        public int Count { get; set; }
    }
}
