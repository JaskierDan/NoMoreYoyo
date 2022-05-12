using System.ComponentModel.DataAnnotations;

namespace NoMoreYoyo.Models
{
    public class MyProfileViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
