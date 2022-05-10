using System;

#nullable disable

namespace NoMoreYoyo.Models
{
    public partial class Calory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal? Fats { get; set; }
        public decimal? Carbohydrates { get; set; }
        public decimal? Proteins { get; set; }

        public virtual User User { get; set; }
    }
}
