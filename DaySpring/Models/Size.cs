using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Size: BaseEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
