    using System.ComponentModel.DataAnnotations;

    namespace RealEstate.Areas.AccountSummary.Models
    {
        public class UserEditViewModel
        {
            [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Ad soyad gereklidir.")]
            public string Surname { get; set; }

            [Required(ErrorMessage = "Eski parola gereklidir.")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "Yeni parola gereklidir.")]
            public string NewPassword { get; set; }
        }

    }
