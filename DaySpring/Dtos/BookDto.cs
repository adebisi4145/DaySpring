using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class BookModel: BaseEntity
    {
        public string Title { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }
        
        public int NumberOfPages { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public int? Count { get; set; }

        public List<CategoryModel> BookCategories { get; set; } = new List<CategoryModel>();

        public List<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}
