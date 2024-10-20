﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }

        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
