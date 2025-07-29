namespace Parcoist.UI.Entities
{
    public class ReturnStatus
    {
        public int ReturnStatusID { get; set; }
        public string Name { get; set; } // Durum adı: "Beklemede", "İşlem Tamamlandı"
        public string Description { get; set; } // Durum açıklaması

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
