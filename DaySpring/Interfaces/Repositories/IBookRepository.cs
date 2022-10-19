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

        Task<List<Book>> GetBooksByTitle(string title);
        Task<Book> GetBookByISBN(string isbn);

        Task<List<Book>> GetBooksByPublisher(string publisher);

        Task<List<Book>> GetBooksByAuthor(int authorId);

        Task<List<Book>> GetBooksByCategory(int categoryId);
    }
}
