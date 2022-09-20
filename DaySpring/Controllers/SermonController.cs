using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
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
    public class SermonController : Controller
    {
        private readonly ISermonService _sermonService;
        private readonly IPreacherService _preacherService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SermonController(ISermonService sermonService, IPreacherService preacherService, IWebHostEnvironment webHostEnvironment)
        {
            _sermonService = sermonService;
            _preacherService = preacherService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var sermons = await _sermonService.GetSermons();
            return View(sermons);
        }
        [HttpGet]
        public async Task<IActionResult> GetSermonsByPreacher(int preacherId)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(preacherId);
            return View(sermons);
        }
        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var preachers = await _preacherService.GetPreachers();
            ViewData["Preacher"] = new SelectList(preachers.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSermonRequestModel model, IFormFile audio, IFormFile video)
        {
            if (audio != null)
            {
                string audioDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "SermonAudios");
                Directory.CreateDirectory(audioDirectory);
                string contentType = audio.ContentType.Split('/')[1];
                string sermonAudio = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(audioDirectory, sermonAudio);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    audio.CopyTo(fileStream);
                }
                model.Audio = sermonAudio;
            }
            if (video != null)
            {
                string videoDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "SermonVideos");
                Directory.CreateDirectory(videoDirectory);
                string contentType = video.ContentType.Split('/')[1];
                string sermonVideo = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(videoDirectory, sermonVideo);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    video.CopyTo(fileStream);
                }
                model.Video = sermonVideo;
            }
            await _sermonService.CreateSermon(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var sermon = await _sermonService.GetSermon(id);
            return View(sermon);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sermon = await _sermonService.GetSermon(id);
            return View(sermon);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateSermonRequestModel model)
        {
            await _sermonService.UpdateSermon(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonByTitle(string title)
        {
            var sermon = await _sermonService.GetSermonByTitle(title);
            return View(sermon);
        }

        /* [HttpGet]
         public async Task<IActionResult> GetSermonAudioByTitle(string title)
         {
             var sermon = await _sermonService.GetSermonAudioByTitle(title);
             return View(sermon);
         }

         [HttpGet]
         public async Task<IActionResult> GetSermonVideoByTitle(string title)
         {
             var sermon = await _sermonService.GetSermonVideoByTitle(title);
             return View(sermon);
         }*/

        public async Task<IActionResult> MediaIndex()
        {
            var author = await _sermonService.GetSermons();
            return View(author);
        }

        public async Task<IActionResult> SuperAdminIndex()
        {
            var author = await _sermonService.GetSermons();
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var sermon = await _sermonService.GetSermon(id);
            return View(sermon);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var sermon = await _sermonService.GetSermon(id);
            return View(sermon);
        }

        [HttpGet]
        public async Task<IActionResult> MediaGetSermonsByPreacher(int preacherId)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(preacherId);
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminGetSermonsByPreacher(int preacherId)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(preacherId);
            return View(sermons);
        }
    }
}
