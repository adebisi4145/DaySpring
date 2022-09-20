using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Book: BaseEntity
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int NumberOfPages { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
