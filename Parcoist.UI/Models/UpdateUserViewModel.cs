using System.ComponentModel.DataAnnotations;

namespace Parcoist.UI.Models;

public class UpdateUserViewModel
{
    public int UserID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime? BirthDate { get; set; }

    [Required]
    public int RoleID { get; set; }

    public bool IsActive { get; set; }
}
