using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class PaymentCategoryController : Controller
    {
        private readonly IPaymentCategoryService _paymentCategoryService;
        public PaymentCategoryController(IPaymentCategoryService categoryService)
        {
            _paymentCategoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _paymentCategoryService.GetPaymentCategories();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(CreatePaymentCategoryRequestModel model)
        {
            var paymentCategory = await _paymentCategoryService.GetPaymentCategoryByName(model.Name);
            if (paymentCategory != null)
            {
                ViewBag.Message = "This Payment Category already exist";
                return View();
            }
            await _paymentCategoryService.CreatePaymentCategory(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _paymentCategoryService.GetPaymentCategory(id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var paymentCategory = await _paymentCategoryService.GetPaymentCategory(id);
            return View(paymentCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdatePaymentCategoryRequestModel model)
        {
            await _paymentCategoryService.UpdatePaymentCategory(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var paymentCategory = await _paymentCategoryService.GetPaymentCategory(id);
            return View(paymentCategory);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentCategoryService.DeletePaymentCategory(id);
            return RedirectToAction("Index");
        }
    }
}
