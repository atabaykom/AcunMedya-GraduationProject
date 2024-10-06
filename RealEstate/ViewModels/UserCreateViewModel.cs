using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen email adresinizi girin")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin")]
        public string Email { get; set; }
        public string ReCaptchaResponse { get; set; } = string.Empty;
    }
}
