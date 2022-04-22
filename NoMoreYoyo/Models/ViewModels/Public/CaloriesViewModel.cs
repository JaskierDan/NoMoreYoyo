using System.ComponentModel;

namespace NoMoreYoyo.Models
{
    public class CaloriesViewModel
    {
        [DisplayName("Calories (kcal)")]
        public decimal Calories { get; set; }
        [DisplayName("Proteins (g)")]
        public decimal Proteins { get; set; }
        [DisplayName("Carbohydrates (g)")]
        public decimal Carbohydrates { get; set; }
        [DisplayName("Fats (g)")]
        public decimal Fats { get; set; }
        [DisplayName("Sex")]
        public int Sex { get; set; }
        [DisplayName("Weight")]
        public decimal Weight { get; set; }
        [DisplayName("Height")]
        public decimal Height { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Activity")]
        public decimal? Activity { get; set; }
    }
}
