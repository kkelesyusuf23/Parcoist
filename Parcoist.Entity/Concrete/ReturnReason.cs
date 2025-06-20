namespace Parcoist.UI.Entities
{
    public class ReturnReason
    {
        public int ReturnReasonID { get; set; }
        public string Name { get; set; } // Sebep adı: "Ürün Hasarlı", "Yanlış Ürün"
        public bool RequiresImage { get; set; } // Görsel gerekip gerekmediği
    }

}
