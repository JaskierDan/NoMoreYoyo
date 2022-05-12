using System;
using System.Collections.Generic;

#nullable disable

namespace NoMoreYoyo.Models
{
    public partial class User
    {
        public User()
        {
            BodyAttributes = new HashSet<BodyAttribute>();
            Calories = new HashSet<Calory>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public bool Sex { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<BodyAttribute> BodyAttributes { get; set; }
        public virtual ICollection<Calory> Calories { get; set; }
    }
}
