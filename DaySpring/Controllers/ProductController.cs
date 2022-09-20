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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IColorService colorService, ISizeService sizeService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _colorService = colorService;
            _sizeService = sizeService;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var author = await _productService.GetProducts();
            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var sizes = await _sizeService.GetSizes();
            ViewData["ProductSizes"] = new SelectList(sizes.Data, "Id", "Abbreviation");
            var colors = await _colorService.GetColors();
            ViewData["ProductColors"] = new SelectList(colors.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequestModel model, IFormFile image)
        {
            if (image != null)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "AuthorsImage");
                Directory.CreateDirectory(imageDirectory);
                string contentType = image.ContentType.Split('/')[1];
                string productImage = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(imageDirectory, productImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                model.ProductImage = productImage;
            }
            await _productService.CreateProduct(model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProduct(id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProductRequestModel model)
        {
            await _productService.UpdateProduct(id, model);
            return RedirectToAction("MediaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MediaIndex()
        {
            var product = await _productService.GetProducts();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails(int id)
        {
            var product = await _productService.GetProduct(id);
            return View(product);
        }
        public async Task<IActionResult> SuperAdminIndex()
        {
            var product = await _productService.GetProducts();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails(int id)
        {
            var product = await _productService.GetProduct(id);
            return View(product);
        }
    }
}
