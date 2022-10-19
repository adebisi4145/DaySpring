using DaySpring.Enums;
using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class SermonController : Controller
    {
        private readonly ISermonService _sermonService;
        private readonly IPreacherService _preacherService;
        private readonly IMemberService _memberService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SermonController(ISermonService sermonService, IMemberService memberService, IPreacherService preacherService, IWebHostEnvironment webHostEnvironment)
        {
            _sermonService = sermonService;
            _preacherService = preacherService;
            _memberService = memberService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> VideoIndex()
        {
            var sermons = await _sermonService.GetSermons();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonsByTitle(string title)
        {
            var sermons = await _sermonService.GetSermonsByTitle(title);
            if (sermons == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("VideoIndex");
            }
            return View(sermons);
        }


        public async Task<IActionResult> AudioIndex()
        {
            var sermons = await _sermonService.GetSermonAudios();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonAudiosByTitle(string title)
        {
            var sermons = await _sermonService.GetSermonsByTitle(title);
            if (sermons == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("AudioIndex");
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonsByPreacher(int id)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(id);
            if (sermons == null)
            {
                TempData["Message"] = "This preacher's sermon is yet to be uploaded";
                return RedirectToAction("Index");
            }
            return View(sermons);
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public IActionResult SermonType()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public IActionResult SermonType(SermonTypeRequestModel model)
        {
            TempData["SermonType"] = model.SermonType;
            return RedirectToAction("Create");
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create()
        {
            ViewBag.SermonType = int.Parse(TempData.Peek("SermonType").ToString());
           
            var members = await _memberService.GetMinisters();
            var preachers = await _preacherService.GetPreachers();
            ViewData["Member"] = new SelectList(members.Data, "Id", "FirstName");
            ViewData["Preacher"] = new SelectList(preachers.Data, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Create(CreateSermonRequestModel model, IFormFile audio, IFormFile video)
        {
            if (audio == null && video == null)
            {
                ViewBag.Message = "You can't upload a sermon without an audio or video";
                return View();
            }
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
            model.SermonType = (SermonType)TempData.Peek("SermonType");
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
        [Authorize(Roles = "media")]
        public async Task<IActionResult> Edit(int id)
        {
            var sermon = await _sermonService.GetSermon(id);
            return View(sermon);
        }

        [HttpPost]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Edit(int id, UpdateSermonRequestModel model)
        {
            await _sermonService.UpdateSermon(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        [Authorize(Roles = "Media")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sermonService.DeleteSermon(id);
            return RedirectToAction("MediaIndex");
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


        public async Task<IActionResult> MediaAudioIndex()
        {
            var sermons = await _sermonService.GetSermonAudios();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonAudiosByTitleMedia(string title)
        {
            var sermons = await _sermonService.GetSermonsByTitle(title);
            if (sermons == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("MediaAudioIndex");
            }
            return View(sermons);
        }

        public async Task<IActionResult> MediaIndex()
        {
            var sermons = await _sermonService.GetSermons();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonsByTitleMedia(string title)
        {
            var sermon = await _sermonService.GetSermonsByTitle(title);
            if (sermon == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("MediaIndex");
            }
            return View(sermon);
        }

        public async Task<IActionResult> superAdminAudioIndex()
        {
            var sermons = await _sermonService.GetSermonAudios();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonAudiosByTitleSuperAdmin(string title)
        {
            var sermons = await _sermonService.GetSermonsByTitle(title);
            if (sermons == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("superAdminAudioIndex");
            }
            return View(sermons);
        }

        public async Task<IActionResult> SuperAdminIndex()
        {

            var sermons = await _sermonService.GetSermons();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(sermons);
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> GetSermonsByTitleSuperAdmin(string title)
        {
            var sermon = await _sermonService.GetSermonsByTitle(title);
            if (sermon == null)
            {
                TempData["Message"] = "Sermon Not found";
                return RedirectToAction("SuperAdminIndex");
            }
            return View(sermon);
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
        public async Task<IActionResult> MediaGetSermonsByPreacher(int id)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(id);
            if (sermons == null)
            {
                TempData["Message"] = "This preacher's sermon is yet to be uploaded";
                return RedirectToAction("MediaIndex");
            }
            return View(sermons);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminGetSermonsByPreacher(int id)
        {
            var sermons = await _sermonService.GetSermonsByPreacher(id);
            if(sermons == null)
            {
                TempData["Message"] = "This preacher's sermon is yet to be uploaded";
                return RedirectToAction("SuperAdminIndex");
            }
            return View(sermons);
        }
    }
}
