using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class ProductModel : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ProductImage { get; set; }
        public List<ColorModel> ProductColors { get; set; } = new List<ColorModel>();
        public List<SizeModel> ProductSizes { get; set; } = new List<SizeModel>();
    }
}
