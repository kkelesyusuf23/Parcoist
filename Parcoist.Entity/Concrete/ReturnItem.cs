namespace Parcoist.UI.Entities
{
    public class ReturnItem
    {
        public int ReturnItemID { get; set; }

        public int ReturnRequestID { get; set; } // İade talebine bağlı
        public ReturnRequest ReturnRequest { get; set; }

        public int OrderItemID { get; set; } // Sipariş öğesinin ID'si
        public OrderItem OrderItem { get; set; }

        public int Quantity { get; set; } // İade edilen miktar
        public string Reason { get; set; } // İade sebebi
        public bool Condition { get; set; } // Ürün durumu (hasar var mı?)
        public int ApprovedQuantity { get; set; } // Onaylanan iade miktarı
        public int RefundAmount { get; set; } // Geri ödeme miktarı
    }

}
