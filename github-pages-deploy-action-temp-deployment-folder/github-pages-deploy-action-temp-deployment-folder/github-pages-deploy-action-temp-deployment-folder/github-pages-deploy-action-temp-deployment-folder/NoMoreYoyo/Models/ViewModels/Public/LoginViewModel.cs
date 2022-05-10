using System.ComponentModel.DataAnnotations;

namespace NoMoreYoyo.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public bool Sex { get; set; }
        public int? Age { get; set; }
    }
}
