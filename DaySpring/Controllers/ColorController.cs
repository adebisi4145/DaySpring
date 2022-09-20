using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }


        public async Task<IActionResult> Index()
        {
            var color = await _colorService.GetColors();
            return View(color);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorRequestModel model)
        {
            await _colorService.CreateColor(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await _colorService.GetColor(id);
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await _colorService.GetColor(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateColorRequestModel model)
        {
            await _colorService.UpdateColor(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorService.DeleteColor(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MediaIndex()
        {
            var color = await _colorService.GetColors();
            return View(color);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var color = await _colorService.GetColor(id);
            return View(color);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var color = await _colorService.GetColors();
            return View(color);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var color = await _colorService.GetColor(id);
            return View(color);
        }
    }
}
