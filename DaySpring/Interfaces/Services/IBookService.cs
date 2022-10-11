using DaySpring.Dtos;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BookResponseModel> GetBook(int id);

        public Task<BooksResponseModel> GetBooksByTitle(string title);

        public Task<BooksResponseModel> GetBooks();

        public Task<BooksResponseModel> GetBooksByPublisher(string publisher);

        public Task<BooksResponseModel> GetBooksByAuthor(int authorId);

        public Task<BooksResponseModel> GetBooksByCategory(int categoryId);

        public Task<BaseResponse> CreateBook(CreateBookRequestModel model);

        public Task<BaseResponse> UpdateBook(int id, UpdateBookRequestModel model);
        public Task<BaseResponse> DeleteBook(int id);
    }
}
