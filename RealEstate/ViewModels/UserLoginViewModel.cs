using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Gecerli Bir Email Girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Sifrenizi Girin")]
        public string Password { get; set; }
    }
}
