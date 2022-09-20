using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class ProductColor:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
