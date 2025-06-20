namespace Parcoist.UI.Entities
{
    public class ReturnImage
    {
        public int ReturnImageID { get; set; }

        public int ReturnRequestID { get; set; } // İade talebinin ID'si
        public string ImageUrl { get; set; } // Görselin URL'si
        public DateTime UpdateDate { get; set; } // Görselin güncellenme tarihi

        public ReturnRequest ReturnRequest { get; set; } // İade talebine navigasyon
    }

}
