using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Color: BaseEntity
    {
        public string Name { get; set; }
        public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
    }
}
