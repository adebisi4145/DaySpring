using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }


        public async Task<IActionResult> Index()
        {
            var size = await _sizeService.GetSizes();
            return View(size);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSizeRequestModel model)
        {
            await _sizeService.CreateSize(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var size = await _sizeService.GetSize(id);
            return View(size);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var size = await _sizeService.GetSize(id);
            return View(size);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var size = await _sizeService.GetSize(id);
            return View(size);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sizeService.DeleteSize(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateSizeRequestModel model)
        {
            await _sizeService.UpdateSize(id, model);
            return RedirectToAction("Index");
        }

    }
}
