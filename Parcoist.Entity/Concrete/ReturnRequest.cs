namespace Parcoist.UI.Entities
{
    public class ReturnRequest
    {
        public int ReturnRequestID { get; set; } // İade talebinin ID'si
        public int OrderID { get; set; } // İlgili siparişin ID'si
        public Order Order { get; set; } // Siparişin ilişkisi

        public ReturnItem ReturnItem { get; set; } // İade edilen ürün bilgisi

        public int ReturnStatusID { get; set; } // İade durumunun ID'si
        public ReturnStatus ReturnStatus { get; set; } // İade durumu ilişkisi

        public int ReturnReasonID { get; set; } // İade sebebinin ID'si
        public ReturnReason ReturnReason { get; set; } // İade sebebi ilişkisi

        public DateTime RequestDate { get; set; } // İade talebinin yapıldığı tarih
        public DateTime? ResolutionDate { get; set; } // İade işleminin tamamlanma tarihi

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }



}
