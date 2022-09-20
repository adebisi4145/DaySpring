using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateSizeRequestModel
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class UpdateSizeRequestModel
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class SizeResponseModel : BaseResponse
    {
        public SizeModel Data { get; set; }
    }

    public class SizesResponseModel : BaseResponse
    {
        public List<SizeModel> Data { get; set; }
    }
}
