using System.ComponentModel.DataAnnotations;

namespace Parcoist.UI.Entities
{
    public class User
    {
        public int UserID { get; set; }

        // Temel Bilgiler
        public required string Name { get; set; }   

        public required string Surname { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        public string Phone { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        // Şifreleme
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; } 

        // Rol
        public int RoleID { get; set; }
        public Role Role { get; set; }

        // Cinsiyet: 0 = Belirtilmedi, 1 = Erkek, 2 = Kadın, 3 = Diğer
        public int Gender { get; set; } = 0;

        // Hesap Durumu
        public bool IsActive { get; set; } = true;
        public bool IsEmailConfirmed { get; set; } = false;
        public string EmailConfirmationToken { get; set; }

        // Güvenlik
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }

        public int FailedLoginCount { get; set; } = 0;
        public bool IsLocked { get; set; } = false;

        public string ProfileImageUrl { get; set; } = string.Empty;

        // One-to-One İlişkiler
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }

        // One-to-Many İlişkiler
        public List<UserComment> UserComments { get; set; }

    }

}
