using System;

#nullable disable

namespace NoMoreYoyo.Models
{
    public partial class BodyAttribute
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeasurementTypeId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        public virtual MeasurementType MeasurementType { get; set; }
        public virtual User User { get; set; }
    }
}
