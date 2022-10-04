using DaySpring.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class DetailsViewModel
    {
        public ProductModel Product { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
    }
}
