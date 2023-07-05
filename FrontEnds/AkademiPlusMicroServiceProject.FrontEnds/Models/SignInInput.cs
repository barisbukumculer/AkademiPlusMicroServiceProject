using System.ComponentModel.DataAnnotations;

namespace AkademiPlusMicroServiceProject.FrontEnds.Models
{
    public class SignInInput
    {
        [Required]
        [Display(Name ="Email Adresi")]
       
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
    }
}
