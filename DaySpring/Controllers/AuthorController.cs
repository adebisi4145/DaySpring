using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Media")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
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
            TempData["authorId"] = id;
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id, UpdateAuthorRequestModel model)
        {
            await _authorService.UpdateAuthor(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsByName(string name)
        {
            var author = await _authorService.GetAuthorsByName(name);
            return View(author);
        }

        public async Task<IActionResult> MediaIndex()
        {
            var author = await _authorService.GetAuthors();
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            TempData["authorId"] = id;
            var author = await _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsByNameMedia(string name)
        {
            var author = await _authorService.GetAuthorsByName(name);
            return View(author);
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthorsByNameSuperAdmin(string name)
        {
            var author = await _authorService.GetAuthorsByName(name);
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
