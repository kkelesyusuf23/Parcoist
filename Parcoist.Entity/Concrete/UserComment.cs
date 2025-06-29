namespace Parcoist.UI.Entities
{
    public class UserComment
    {
        public int UserCommentID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; } // Navigasyon

        public int ProductID { get; set; }
        public Product Product { get; set; } // Navigasyon

        public string Comment { get; set; }
        public string Description { get; set; } // Başlık gibi düşünülebilir
        public string Date { get; set; } // string yerine DateTime tercih edilmeli
    }

}
