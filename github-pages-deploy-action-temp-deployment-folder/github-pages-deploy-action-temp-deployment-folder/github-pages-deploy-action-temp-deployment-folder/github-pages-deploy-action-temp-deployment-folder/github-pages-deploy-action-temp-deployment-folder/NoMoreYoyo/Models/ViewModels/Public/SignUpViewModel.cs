using System.ComponentModel.DataAnnotations;

namespace NoMoreYoyo.Models
{
    public class SignUpViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Password Again")]
        public string PasswordAgain { get; set; }
        [Display(Name = "Weight (kg)")]
        public decimal? Weight { get; set; }
        [Display(Name = "Height (cm)")]
        public decimal? Height { get; set; }
        [Display(Name = "Sex")]
        public bool Sex { get; set; }
        [Display(Name = "Age")]
        public int? Age { get; set; }
    }
}
