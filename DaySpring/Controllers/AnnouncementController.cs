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
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AnnouncementController(IAnnouncementService announcementService, IWebHostEnvironment webHostEnvironment)
        {
            _announcementService = announcementService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var announcement = await _announcementService.GetAnnouncements();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(announcement);
            }
            return View(announcement);
        }

        [HttpGet]
        public async Task<IActionResult> CurrentAnnouncement()
        {
            var announcement = await _announcementService.GetCurrentAnnouncements();
            return View(announcement);
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public IActionResult Create()
        {
            if (TempData.ContainsKey("days"))
            {
                string days = TempData["Days"].ToString();
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create(CreateAnnouncementRequestModel model, IFormFile image)
        {
            /*if (image == null)
            {
                ViewBag.Message = "Please upload an image";
                return View();
            }*/
            string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "AnnouncementImages");
            Directory.CreateDirectory(imageDirectory);
            string contentType = image.ContentType.Split('/')[1];
            string announcementImage = $"{Guid.NewGuid()}.{contentType}";
            string fullPath = Path.Combine(imageDirectory, announcementImage);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
               image.CopyTo(fileStream);
            }
            model.AnnouncementImage = announcementImage;
            await _announcementService.CreateAnnouncement(model);
            return RedirectToAction("MediaCurrentAnnouncements");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var announcement = await _announcementService.GetAnnouncement(id);
            return View(announcement);
        }


        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id)
        {
            var announcement = await _announcementService.GetAnnouncement(id);
            return View(announcement);
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id, UpdateAnnouncementRequestModel model)
        {
            await _announcementService.UpdateAnnouncement(id, model);
            return RedirectToAction("MediaIndex");
        }

        public async Task<IActionResult> MediaIndex()
        {
            var announcement = await _announcementService.GetAnnouncements();
            return View(announcement);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var announcement = await _announcementService.GetAnnouncements();
            return View(announcement);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var announcement = await _announcementService.GetAnnouncement(id);
            return View(announcement);
        }
        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var announcement = await _announcementService.GetAnnouncement(id);
            return View(announcement);
        }
        [HttpGet]
        public async Task<IActionResult> CurrentAnnouncements()
        {
            var announcement = await _announcementService.GetCurrentAnnouncements();
            if (announcement.Data.Count == 0)
            {
                ViewBag.Message = "No Current Programs";
                return View(announcement);
            }
            return View(announcement);
        }

        [HttpGet]
        public async Task<IActionResult> MediaCurrentAnnouncements()
        {
            var announcement = await _announcementService.GetCurrentAnnouncements();
            if (announcement.Data.Count == 0)
            {
                ViewBag.Message = "No Current Programs";
                return View(announcement);
            }
            return View(announcement);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminCurrentAnnouncements()
        {
            var announcement = await _announcementService.GetCurrentAnnouncements();
            if(announcement.Data.Count == 0)
            {
                ViewBag.Message = "No Current Programs";
                return View(announcement);
            }
            return View(announcement);
        }

        public async Task<IActionResult> GetAnnouncementsByTitle(string title)
        {
            var announcements = await _announcementService.GetAnnouncementsByTitle(title);
            if(announcements == null)
            {
                TempData["Message"] = "Not Found";
                return RedirectToAction("Index");
            }
            return View(announcements);
        }

        public async Task<IActionResult> GetAnnouncementsByTitleMedia(string title)
        {
            var announcements = await _announcementService.GetAnnouncementsByTitle(title);
            if (announcements == null)
            {
                TempData["Message"] = "Not Found";
                return RedirectToAction("MediaIndex");
            }
            return View(announcements);
        }
        public async Task<IActionResult> GetAnnouncementsByTitleSuperAdmin(string title)
        {
            var announcements = await _announcementService.GetAnnouncementsByTitle(title);
            if (announcements == null)
            {
                TempData["Message"] = "Not Found";
                return RedirectToAction("MediaIndex");
            }
            return View(announcements);
        }
    }
}
