using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateBookRequestModel
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int NumberOfPages { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public List<int> Categories { get; set; } = new List<int>();

        public List<int> Authors { get; set; } = new List<int>();
    }

    public class UpdateBookRequestModel
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int NumberOfPages { get; set; }
    }

    public class BookResponseModel : BaseResponse
    {
        public BookModel Data { get; set; }
    }

    public class BooksResponseModel : BaseResponse
    {
        public List<BookModel> Data { get; set; }
    }
}
