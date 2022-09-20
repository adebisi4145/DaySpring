using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreatePreacherRequestModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Details { get; set; }
    }

    public class UpdatePreacherRequestModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
    }

    public class PreacherResponseModel : BaseResponse
    {
        public PreacherModel Data { get; set; }
    }

    public class PreachersResponseModel : BaseResponse
    {
        public List<PreacherModel> Data { get; set; }
    }
}
