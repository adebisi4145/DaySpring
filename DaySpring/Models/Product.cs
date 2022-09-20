using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string PoductImage { get; set; }
        public List<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
