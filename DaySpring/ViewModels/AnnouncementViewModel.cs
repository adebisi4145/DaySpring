using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateAnnouncementRequestModel
    {
        public string Title { get; set; }
        public string AnnouncementImage { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }

    public class UpdateAnnouncementRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }

    public class AnnouncementResponseModel : BaseResponse
    {
        public AnnouncementModel Data { get; set; }
    }

    public class AnnouncementsResponseModel : BaseResponse
    {
        public List<AnnouncementModel> Data { get; set; }
    }
}
