using DaySpring.Dtos;
using DaySpring.Enums;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateSermonRequestModel
    {
        public string Title { get; set; }
        public SermonType SermonType { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
        public int Preacher { get; set; }
        public int Member { get; set; }
    }
    public class SermonTypeRequestModel
    {
        public SermonType SermonType { get; set; }
    }

    public class UpdateSermonRequestModel
    {
        public string Title { get; set; }
        public int Preacher { get; set; }
    }

    public class SermonResponseModel : BaseResponse
    {
        public SermonModel Data { get; set; }
    }

    public class SermonsResponseModel : BaseResponse
    {
        public List<SermonModel> Data { get; set; }
    }
}
