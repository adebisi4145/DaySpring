using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Sermon: BaseEntity
    {
        public string Title { get; set; }
        // string Description { get; set; }
        public string Audio { get; set; } 
        public string Video { get; set; }
        public int PreacherId { get; set; }
        public Preacher Preacher { get; set; }
    }
}
