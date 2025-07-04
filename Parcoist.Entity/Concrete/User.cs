namespace Parcoist.UI.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        //public int Gender { get; set; }

        public Admin Admin { get; set; } // one-to-one
        public Customer Customer { get; set; } // one-to-one
        public List<UserComment> UserComments { get; set; }

    }

}
