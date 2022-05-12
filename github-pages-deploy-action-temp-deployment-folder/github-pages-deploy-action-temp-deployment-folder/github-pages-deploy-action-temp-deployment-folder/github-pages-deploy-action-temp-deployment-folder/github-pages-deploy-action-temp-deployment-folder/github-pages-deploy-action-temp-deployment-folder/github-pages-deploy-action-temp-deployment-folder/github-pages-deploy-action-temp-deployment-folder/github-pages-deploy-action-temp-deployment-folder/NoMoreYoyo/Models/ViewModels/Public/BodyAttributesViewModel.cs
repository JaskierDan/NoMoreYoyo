using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NoMoreYoyo.Models
{
    public class BodyAttributesViewModel
    {
        public int UserId { get; set; }
        public decimal Value { get; set; }

        public List<SelectListItem> MeasurementTypes { get; set; }

        public BodyAttributesViewModel()
        {
            MeasurementTypes = new List<SelectListItem>();
        }
    }
}
