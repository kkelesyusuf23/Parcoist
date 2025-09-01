using System.ComponentModel.DataAnnotations;

namespace Parcoist.UI.Models
{
    public class PasswordChangeByUserViewModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Yeni şifre gerekli")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalı")]
        public string NewPassword { get; set; }
    }
}
