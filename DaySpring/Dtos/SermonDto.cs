using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class SermonModel: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PreacherId { get; set; }
        public Preacher Preacher { get; set; }
        public string Audio { get; set; }
        public string Video { get; set; }
    }
}
