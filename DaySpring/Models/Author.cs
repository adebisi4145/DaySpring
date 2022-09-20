using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class Author: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string AuthorsImage { get; set; }

        public string Biography { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
