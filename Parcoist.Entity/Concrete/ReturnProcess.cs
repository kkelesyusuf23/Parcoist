namespace Parcoist.UI.Entities
{
    public class ReturnProcess
    {
        public int ReturnProcessID { get; set; } // İade sürecinin benzersiz ID'si
        public int ReturnRequestID { get; set; } // İade talebine ait ID
        public ReturnRequest ReturnRequest { get; set; } // İade talebine navigasyon

        public int CourierID { get; set; } // İade işleminden sorumlu kuryenin ID'si
        public int CarrierID { get; set; } // İade taşıma işleminin sorumlu taşıyıcısının ID'si

        public string TrackingNumber { get; set; } // İade gönderisinin izleme numarası
        public DateTime RefundDate { get; set; } // Geri ödeme tarihi
        public string AdminNotes { get; set; } // Yöneticinin sürece dair notları
        public DateTime ComplatedAt { get; set; } // İade sürecinin tamamlanma tarihi

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
