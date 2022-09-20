using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class ColorModel: BaseEntity
    {
        public string Name { get; set; }
        public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    }
}
