using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPaymentService _paymentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MemberController(IMemberService memberService, IPaymentService paymentService, IHttpContextAccessor httpContextAccessor)
        {
            _memberService = memberService;
            _paymentService = paymentService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllMembers();
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                return View(members);
            }
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
            var member = await _memberService.GetMemberByEmail(model.Email);
            if(member != null)
            {
                ViewBag.Message = "This email already exist, proceed to Login";
                return View();
            }
            if(model.Password != model.ConfirmPassword)
            {
                ViewBag.Message = "The passwords must be the same";
                return View();
            }
            else
            {
                await _memberService.CreateMember(model);
                return RedirectToAction("Login", "User");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details()
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
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Role(int id)
        {
            var member = await _memberService.GetMember(id);
            return View(member);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> UpdateToMedia(int id)
        {
            await _memberService.UpdateMembershipStatusToMedia(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> UpdateToMinister(int id)
        {
            await _memberService.UpdateMembershipStatusToMinister(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> RemoveMediaRole(int id)
        {
            await _memberService.RemoveMediaRole(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
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
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var response = await _memberService.UpdateMemberPassword(memberId, model);
            return RedirectToAction("MediaDashboard");
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
            var member = await _memberService.GetMemberById(memberId);
            var payments = await _paymentService.GetAllPaymentsByEmail(member.Email);
            var dashboardViewModel = new MembersPaymentViewModel
            {
                Member = member,
                Payments = payments
            };

            if (payments.Count == 0)
            {
                ViewBag.Message = "No Payment Yet";
                return View(dashboardViewModel);
            }
            return View(dashboardViewModel);
        }

        [Authorize(Roles = "Media")]
        public async Task<IActionResult> MediaDashboard()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMemberById(memberId);
            var payments = await _paymentService.GetAllPaymentsByEmail(member.Email);
            var dashboardViewModel = new MembersPaymentViewModel
            {
                Member = member,
                Payments = payments
            };
            if (payments.Count == 0)
            {
                ViewBag.Message = "No Payment Yet";
                return View(dashboardViewModel);
            }
            return View(dashboardViewModel);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> SuperAdminDashboard()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMemberById(memberId);
            var payments = await _paymentService.GetAllPaymentsByEmail(member.Email);
            var dashboardViewModel = new MembersPaymentViewModel
            {
                Member = member,
                Payments = payments
            };
            if (payments.Count == 0)
            {
                ViewBag.Message = "No Payment Yet";
                return View(dashboardViewModel);
            }
            return View(dashboardViewModel);
        }

        [HttpGet]
        public IActionResult EditPasswordMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPasswordMedia(UpdateMemberPasswordRequestModel model)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var response = await _memberService.UpdateMemberPassword(memberId, model);
            ViewBag.Message = "Password Updated";
            return View("MediaDashboard");
        }

        [HttpGet]
        public async Task<IActionResult> MediaDetails()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        [HttpGet]
        public IActionResult EditPasswordSuperAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditPasswordSuperAdmin(UpdateMemberPasswordRequestModel model)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var response = await _memberService.UpdateMemberPassword(memberId, model);
            return RedirectToAction("SuperAdminDashboard");
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminDetails()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            return View(member);
        }

        [HttpGet]
        public async Task<IActionResult> GetMembersByName(string name)
        {
            var members = await _memberService.GetMembersByName(name);
            if (members == null)
            {
                TempData["Message"] = "Member Not Found";
                return RedirectToAction("Index");
            }
            return View(members);
        }
    }
}
