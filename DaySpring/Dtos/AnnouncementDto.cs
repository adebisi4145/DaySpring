using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class AnnouncementModel : BaseEntity
    {
        public string Title { get; set; }
        public string AnnouncementImage { get; set; }
        public string Description { get; set; }
        //public List<DateTime> Dates { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
