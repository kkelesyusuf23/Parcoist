namespace Parcoist.UI.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
