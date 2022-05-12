using System.Collections.Generic;

#nullable disable

namespace NoMoreYoyo.Models
{
    public partial class MeasurementType
    {
        public MeasurementType()
        {
            BodyAttributes = new HashSet<BodyAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Metric { get; set; }

        public virtual ICollection<BodyAttribute> BodyAttributes { get; set; }
    }
}
