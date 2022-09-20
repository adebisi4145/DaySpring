using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetCategories();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequestModel model)
        {
            await _categoryService.CreateCategory(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCategoryRequestModel model)
        {
            await _categoryService.UpdateCategory(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MediaIndex()
        {
            var category = await _categoryService.GetCategories();
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var category = await _categoryService.GetCategories();
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }
    }
}
