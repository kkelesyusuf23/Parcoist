namespace Parcoist.UI.Entities
{
    public class ReturnStatus
    {
        public int ReturnStatusID { get; set; }
        public string Name { get; set; } // Durum adı: "Beklemede", "İşlem Tamamlandı"
        public string Description { get; set; } // Durum açıklaması
    }

}
