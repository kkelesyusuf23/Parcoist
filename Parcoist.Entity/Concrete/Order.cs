namespace Parcoist.UI.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int OrderNo { get; set; }

        public int ShippingCost { get; set; }
        public int PaymentMethodID { get; set; }
        public int CouponID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public Delivery Delivery { get; set; }

        public int TaxAmount { get; set; }
        public int SubTotal { get; set; }
        public int GrandTotal { get; set; }
        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }
        public int DiscountAmount { get; set; }

        public int ShippingAddressID { get; set; }
        public int BillingAddressID { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        // Siparişe ait iade talepleri ekleniyor
        public List<ReturnRequest> ReturnRequests { get; set; }

        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; }
    }


}
