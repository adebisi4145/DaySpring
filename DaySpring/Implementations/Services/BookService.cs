using DaySpring.Dtos;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
        }

        public async Task<BaseResponse> CreateBook(CreateBookRequestModel model)
        {
            var book = new Book
            {
                ISBN = model.ISBN,
                BookPDF = model.BookPDF,
                NumberOfPages = model.NumberOfPages,
                BookImage = model.BookImage,
                Publisher = model.Publisher,
                Title = model.Title
            };

            var authors = await _authorRepository.GetSelectedAuthors(model.Authors);
            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor
                {
                    Book = book,
                    BookId = book.Id,
                    Author = author,
                    AuthorId = author.Id
                };

                book.BookAuthors.Add(bookAuthor);
            }

            var categories = await _categoryRepository.GetSelectedCategories(model.Categories);
            foreach (var category in categories)
            {
                var bookCategory = new BookCategory
                {
                    Book = book,
                    BookId = book.Id,
                    Category = category,
                    CategoryId = category.Id
                };
                book.BookCategories.Add(bookCategory);
            }

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Book successfully added"
            };
        }


        public async Task<BaseResponse> DeleteBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            await _bookRepository.DeleteAsync(book);
            File.Delete($"C:\\Users\\dzumi\\source\\repos\\DaySpring\\DaySpring\\wwwroot\\BookImages\\{book.BookImage}");
            File.Delete($"C:\\Users\\dzumi\\source\\repos\\DaySpring\\DaySpring\\wwwroot\\BookPdfs\\{book.BookPDF}");
            await _bookRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Book Deleted Successfully"
            };
        }

        public async Task<BookResponseModel> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            return new BookResponseModel
            {
                Data = new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    BookPDF = book.BookPDF,
                    BookImage = book.BookImage,
                    NumberOfPages = book.NumberOfPages,
                    Publisher = book.Publisher,
                    Authors = book.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = book.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<BooksResponseModel> GetBooksByTitle(string title)
        {
            var books = await _bookRepository.GetBooksByTitle(title);
            return new BooksResponseModel
            {
                Data = books.Select(m => new BookModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ISBN = m.ISBN,
                    BookPDF = m.BookPDF,
                    BookImage = m.BookImage,
                    NumberOfPages = m.NumberOfPages,
                    Publisher = m.Publisher,
                    Authors = m.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = m.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BooksResponseModel> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            return new BooksResponseModel
            {
                Data = books.Select(m => new BookModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ISBN = m.ISBN,
                    BookPDF = m.BookPDF,
                    BookImage = m.BookImage,
                    NumberOfPages = m.NumberOfPages,
                    Publisher = m.Publisher,
                    Authors = m.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = m.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                }).ToList(),
                Status = true,
                Message = "successful"
            };
            
        }

        public async Task<BooksResponseModel> GetBooksByAuthor(int authorId)
        {
            var books = await _bookRepository.GetBooksByAuthor(authorId);
            return new BooksResponseModel
            {
                Data = books.Select(m => new BookModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ISBN = m.ISBN,
                    BookPDF = m.BookPDF,
                    BookImage = m.BookImage,
                    NumberOfPages = m.NumberOfPages,
                    Publisher = m.Publisher,
                    Authors = m.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = m.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BooksResponseModel> GetBooksByCategory(int categoryId)
        {
            var books = await _bookRepository.GetBooksByCategory(categoryId);
            return new BooksResponseModel
            {
                Data = books.Select(m => new BookModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ISBN = m.ISBN,
                    BookPDF = m.BookPDF,
                    BookImage = m.BookImage,
                    NumberOfPages = m.NumberOfPages,
                    Publisher = m.Publisher,
                    Authors = m.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = m.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BooksResponseModel> GetBooksByPublisher(string publisher)
        {
            var books = await _bookRepository.GetBooksByPublisher(publisher);
            return new BooksResponseModel
            {
                Data = books.Select(m => new BookModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    ISBN = m.ISBN,
                    BookPDF = m.BookPDF,
                    BookImage = m.BookImage,
                    NumberOfPages = m.NumberOfPages,
                    Publisher = m.Publisher,
                    Authors = m.BookAuthors.Select(a => new AuthorModel()
                    {
                        Id = a.AuthorId,
                        FirstName = a.Author.FirstName,
                        LastName = a.Author.LastName,
                        Biography = a.Author.Biography
                    }).ToList(),
                    BookCategories = m.BookCategories.Select(a => new CategoryModel()
                    {
                        Id = a.CategoryId,
                        Name = a.Category.Name,
                    }).ToList()
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateBook(int id, UpdateBookRequestModel model)
        {
            var book = await _bookRepository.GetBook(id);
            book.ISBN = model.ISBN;
            book.Title = model.Title;
            book.Publisher = model.Publisher;
            book.NumberOfPages = model.NumberOfPages;
            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
