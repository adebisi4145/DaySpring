using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class CategoryModel: BaseEntity
    {
        public string Name { get; set; }

        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
