﻿using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class PreacherModel: BaseEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Details { get; set; }
        public List<Sermon> Sermons { get; set; } = new List<Sermon>();
    }
}
