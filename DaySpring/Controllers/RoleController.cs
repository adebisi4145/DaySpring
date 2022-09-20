using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleRequestModel model)
        {
            await _roleService.CreateRole(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var role = await _roleService.GetRole(id);
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleService.GetRole(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateRoleRequestModel model)
        {
            await _roleService.UpdateRole(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleService.GetRole(id);
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            await _roleService.DeleteRole(id);
            return RedirectToAction("Index");
        }
    }
}
