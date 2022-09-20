using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MemberController(IMemberService memberService, IHttpContextAccessor httpContextAccessor)
        {
            _memberService = memberService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllMembers();
            return View(members);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateMemberRequestModel model)
        {
            await _memberService.CreateMember(model);
            return RedirectToAction("Login","User");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> AdminDetails(int id)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberService.GetMember(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateMemberRequestModel model)
        {
            await _memberService.UpdateMember(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateToMedia(int id)
        {
            await _memberService.UpdateMembershipStatusToMedia(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateToMinister(int id)
        {
            await _memberService.UpdateMembershipStatusToMinister(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveMediaRole(int id)
        {
            await _memberService.RemoveMediaRole(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveMinisterRole(int id)
        {
            await _memberService.RemoveMinisterRole(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(int id, UpdateMemberPasswordRequestModel model)
        {
            var response = await _memberService.UpdateMemberPassword(id, model);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var member = _memberService.GetMember(id);
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberService.DeleteMember(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MemberDashboard()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        public async Task<IActionResult> MediaDashboard()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        public async Task<IActionResult> SuperAdminDashboard()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }
    }
}
