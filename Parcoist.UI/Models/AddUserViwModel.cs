using System.ComponentModel.DataAnnotations;

namespace Parcoist.UI.Models
{
    public class AddUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleID { get; set; }  // Admin veya SuperAdmin
    }
}
