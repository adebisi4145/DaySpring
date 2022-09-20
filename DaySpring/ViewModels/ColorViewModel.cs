using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateColorRequestModel
    {
        public string Name { get; set; }
    }

    public class UpdateColorRequestModel
    {
        public string Name { get; set; }
    }

    public class ColorResponseModel : BaseResponse
    {
        public ColorModel Data { get; set; }
    }

    public class ColorsResponseModel : BaseResponse
    {
        public List<ColorModel> Data { get; set; }
    }
}
