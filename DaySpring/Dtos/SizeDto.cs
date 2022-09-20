using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class SizeModel : BaseEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
