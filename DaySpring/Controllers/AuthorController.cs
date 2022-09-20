using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthorController(IAuthorService authorService, IWebHostEnvironment webHostEnvironment)
        {
            _authorService = authorService;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var author = await _authorService.GetAuthors();
            return View(author);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorRequestModel model, IFormFile image)
        {
            if (image != null)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "AuthorsImage");
                Directory.CreateDirectory(imageDirectory);
                string contentType = image.ContentType.Split('/')[1];
                string authorImage = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(imageDirectory, authorImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                model.AuthorsImage = authorImage;
            }
            await _authorService.CreateAuthor(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateAuthorRequestModel model)
        {
            await _authorService.UpdateAuthor(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MediaIndex()
        {
            var author = await _authorService.GetAuthors();
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var author = await _authorService.GetAuthors();
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }
    }
}
