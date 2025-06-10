namespace Parcoist.UI.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public int Gender { get; set; }
    }
}
