using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;  
        }

        public async Task<Book> GetBook(int id)
        {
            return await _daySpringDbContext.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category).SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            return await _daySpringDbContext.Books
                .Include(b => b.BookAuthors).ThenInclude(b => b.Author)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .SingleOrDefaultAsync(b => b.Title == title);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _daySpringDbContext.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByAuthor(int authorId)
        {
            return await _daySpringDbContext.Books
                .Include(b => b.BookAuthors).ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories).ThenInclude(c => c.Category)
                .Where(b => b.BookAuthors.All(b => b.AuthorId == authorId)).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByCategory(int categoryId)
        {
            return await _daySpringDbContext.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.BookCategories.All(a => a.CategoryId == categoryId)).ToListAsync();
        }

        public async Task<List<Book>> GetBooksByPublisher(string publisher)
        {
            return await _daySpringDbContext.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.Publisher == publisher).ToListAsync();
        }
    }
}
