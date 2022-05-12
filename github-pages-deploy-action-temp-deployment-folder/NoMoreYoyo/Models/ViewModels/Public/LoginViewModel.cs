using System.ComponentModel.DataAnnotations;

namespace NoMoreYoyo.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email/Username")]
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
