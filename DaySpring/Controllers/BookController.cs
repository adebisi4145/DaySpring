using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooks();
            return View(books);
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAuthors();
            ViewData["Authors"] = new SelectList(authors.Data, "Id", "FirstName");
            var categories = await _categoryService.GetCategories();
            ViewData["Categories"] = new SelectList(categories.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create(CreateBookRequestModel model, IFormFile image, IFormFile pdf)
        {
            if(image == null || pdf == null)
            {
                ViewBag.Message = "Please upload an image or pdf";
                return View();
            }
            if (image != null)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "BookImages");
                Directory.CreateDirectory(imageDirectory);
                string contentType = image.ContentType.Split('/')[1];
                string bookImage = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(imageDirectory, bookImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                model.BookImage = bookImage;
            }
            if (pdf != null)
            {
                string pdfDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "BookPDFs");
                Directory.CreateDirectory(pdfDirectory);
                string contentType = pdf.ContentType.Split('/')[1];
                string bookPDF = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(pdfDirectory, bookPDF);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    pdf.CopyTo(fileStream);
                }
                model.BookPDF = bookPDF;
            }
            await _bookService.CreateBook(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id, UpdateBookRequestModel model)
        {
            await _bookService.UpdateBook(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBook(id);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> ReadBook(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksByTitle(string title)
        {
            var books = await _bookService.GetBooksByTitle(title);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            var books = await _bookService.GetBooksByCategory(categoryId);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksByAuthor(int id)
        {
            var books = await _bookService.GetBooksByAuthor(id);
            return View(books);
        }

        public async Task<IActionResult> MediaIndex()
        {
            var books = await _bookService.GetBooks();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksByTitleMedia(string title)
        {
            var books = await _bookService.GetBooksByTitle(title);
            return View(books);
        }

        public async Task<IActionResult> SuperAdminIndex()
        {
            var books = await _bookService.GetBooks();
            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksByTitleSuperAdmin(string title)
        {
            var books = await _bookService.GetBooksByTitle(title);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> MediaGetBooksByAuthor(int id)
        {
            var books = await _bookService.GetBooksByAuthor(id);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminGetBooksByAuthor(int id)
        {
            var books = await _bookService.GetBooksByAuthor(id);
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> MediaReadBook(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminReadBook(int id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }
    }
}
