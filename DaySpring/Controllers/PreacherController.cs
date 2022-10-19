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
    public class PreacherController : Controller
    {
        private readonly IPreacherService _preacherService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PreacherController(IPreacherService preacherService, IWebHostEnvironment webHostEnvironment)
        {
            _preacherService = preacherService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _preacherService.GetPreachers();
            return View(category);
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create(CreatePreacherRequestModel model, IFormFile image)
        {
            var preacher = await _preacherService.GetPreacherByName(model.Name);
            if(preacher != null)
            {
                ViewBag.Message = "This Preacher already exist";
                return View();
            }
            string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "PreachersPicture");
            Directory.CreateDirectory(imageDirectory);
            string contentType = image.ContentType.Split('/')[1];
            string preachersPicture = $"{Guid.NewGuid()}.{contentType}";
            string fullPath = Path.Combine(imageDirectory, preachersPicture);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            model.Picture = preachersPicture;
            await _preacherService.CreatePreacher(model);
            return RedirectToAction("MediaIndex");
                
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var preacher = await _preacherService.GetPreacher(id);
            return View(preacher);
        }
        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id)
        {
            var preacher = await _preacherService.GetPreacher(id);
            return View(preacher);
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id, UpdatePreacherRequestModel model)
        {
            await _preacherService.UpdatePreacher(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> GetPreacherByName(string name)
        {
            var preacher = await _preacherService.GetPreacherByName(name);
            return View(preacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetPreacherByNameMedia(string name)
        {
            var preacher = await _preacherService.GetPreacherByName(name);
            return View(preacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetPreacherByNameSuperAdmin(string name)
        {
            var preacher = await _preacherService.GetPreacherByName(name);
            return View(preacher);
        }

        public async Task<IActionResult> MediaIndex()
        {
            var preacher = await _preacherService.GetPreachers();
            return View(preacher);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var preacher = await _preacherService.GetPreacher(id);
            return View(preacher);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var preacher = await _preacherService.GetPreachers();
            return View(preacher);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var preacher = await _preacherService.GetPreacher(id);
            return View(preacher);
        }
    }
}
