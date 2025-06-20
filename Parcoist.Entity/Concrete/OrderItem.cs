namespace Parcoist.UI.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public int ProductID { get; set; } // Ürünün ID'si
        public Product Product { get; set; }

        public int ProductFeaturedID { get; set; } // Ürünün özellik ID'si
        public FeatureType ProductFeature { get; set; }

        public int OrderID { get; set; } // İlgili siparişin ID'si
        public Order Order { get; set; }

        public int Quantity { get; set; } // Sipariş edilen miktar
        public decimal UnitPrice { get; set; } // Birim fiyatı
        public decimal Discount { get; set; } // Uygulanan indirim
        public decimal LineTotal { get; set; } // Toplam tutar (quantity * unit price)

        public string SnapshotFeatureName { get; set; } // Özellik adı (örneğin, "Renk")
        public string SnapshotFeatureValue { get; set; } // Özellik değeri (örneğin, "Kırmızı")
    }


}
