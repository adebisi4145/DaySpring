using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<Book> GetBook(int id);

        Task<List<Book>> GetBooks();

        Task<Book> GetBookByTitle(string title);

        Task<List<Book>> GetBooksByPublisher(string publisher);

        Task<List<Book>> GetBooksByAuthor(int authorId);

        Task<List<Book>> GetBooksByCategory(int categoryId);
    }
}
