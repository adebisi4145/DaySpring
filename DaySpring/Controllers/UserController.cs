using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserRequestModel model)
        {
            var user = await _userService.Login(model);
            if (user == null)
            {
                ViewBag.Message = "Invalid Email/Password";
                return View();
            }
            var userRoles = user.Data.User.UserRoles.Select(c => c.Role.Name).ToList();

            var roleClaims = new List<Claim>();
            foreach(var role in userRoles)
            {
                var claim = new Claim(ClaimTypes.Role, role);
                roleClaims.Add(claim);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.Data.FirstName} {user.Data.LastName}"),
                new Claim(ClaimTypes.GivenName, $"{user.Data.FirstName} {user.Data.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Data.Email),
            
           
            };
            claims.AddRange(roleClaims);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);


            var userRole = await _userService.GetUserRole(model.Email);
            if (userRole.Contains("superadmin"))
            {
                return RedirectToAction("SuperAdminDashboard", "Member");
            }
            else if(userRole.Contains("media"))
            {
                return RedirectToAction("MediaDashboard", "Member");
            }
            else
            {
                return RedirectToAction("MemberDashboard", "Member");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            await _userService.GetUser(id);
            return RedirectToAction("Index");
        }

    }
}
