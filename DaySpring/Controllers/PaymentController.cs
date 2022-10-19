using DaySpring.Enums;
using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaySpring.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentCategoryService _paymentCategoryService;
        private readonly IMemberService _memberService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private PayStackApi Paystack { get; set; }
        private readonly IConfiguration  _configuration;
        private readonly string token;
        public PaymentController(IPaymentService transactionService, IMemberService memberService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _paymentService = transactionService;
            _memberService = memberService;
            _httpContextAccessor = httpContextAccessor;

            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var payments = await  _paymentService.GetPayments();
            return View(payments);
        }

        public async Task<IActionResult> GetPaymentsByEmail(string email)
        {
            var member = await _memberService.GetMemberByEmail(email);
            var payments = await _paymentService.GetMembersPaymentsByEmail(email);

            var memberspayments = new MembersPaymentViewModel
            {
                Member = member,
                Payments = payments
            };
            if (payments.Count == 0)
            {
                ViewBag.Message = "No Payments Yet";
                return View(memberspayments);
            }
            return View(memberspayments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentRequestModel model)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = model.Amount * 100,
                Email = email,
                Reference = GenerateReference().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:21690/payment/verify"
            };
            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                await _paymentService.CreatePayment(model, email, request.Reference);
                return Redirect(response.Data.AuthorizationUrl);
            }
            ViewData["error"] = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string reference)
        {
            TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                await _paymentService.VerifyPayment(reference);
                return RedirectToAction("GetPaymentsByEmailMember");
            }
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction("Create");
        }

        public static int GenerateReference()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(1000000, 999999999);
        }

        [HttpGet]
        public IActionResult MediaCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MediaCreate(CreatePaymentRequestModel model)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = model.Amount * 100,
                Email = email,
                Reference = GenerateReference().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:21690/payment/mediaverify"
            };
            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                await _paymentService.CreatePayment(model, email, request.Reference);
                return Redirect(response.Data.AuthorizationUrl);
            }
            ViewData["error"] = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MediaVerify(string reference)
        {
            TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                await _paymentService.VerifyPayment(reference);
                return RedirectToAction("GetPaymentsByEmailMedia");
            }
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction("MediaCreate");
        }

        public async Task<IActionResult> GetPaymentsByEmailMedia()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            var payments = await _paymentService.GetPaymentsByEmail(member.Data.Email);
            if (payments.Data.Count == 0)
            {
                ViewBag.Message = "No Payments Yet";
                return View(payments);
            }
            return View(payments);
        }
        public async Task<IActionResult> GetPaymentsByEmailMember()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            var payments = await _paymentService.GetPaymentsByEmail(member.Data.Email);
            if(payments.Data.Count == 0)
            {
                ViewBag.Message = "No Payments Yet";
                return View(payments);
            }
            return View(payments);
        }

        [HttpGet]
        public IActionResult SuperAdminCreate()
        {
            var paymentCategories = _paymentCategoryService.GetPaymentCategories();
            ViewData["PaymentCategories"] = new SelectList(paymentCategories.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SuperAdminCreate(CreatePaymentRequestModel model)
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = model.Amount * 100,
                Email = email,
                Reference = GenerateReference().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:21690/payment/superadminverify"
            };
            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                await _paymentService.CreatePayment(model, email, request.Reference);
                return Redirect(response.Data.AuthorizationUrl);
            }
            ViewData["error"] = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SuperAdminVerify(string reference)
        {
            TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                await _paymentService.VerifyPayment(reference);
                return RedirectToAction("GetPaymentsByEmailSuperAdmin");
            }
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction("SuperAdminCreate");
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentsByEmailSuperAdmin()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            var payments = await _paymentService.GetPaymentsByEmail(member.Data.Email);
            if (payments.Data.Count == 0)
            {
                ViewBag.Message = "No Payments Yet";
                return View(payments);
            }
            return View(payments);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetPaymentsByDates(DateTime date)
        {
            var payments = await _paymentService.GetPaymentsByDate(date);
            var totalAmount = await _paymentService.GetTotalPayment(date);
            var paymentbyDate = new PaymentByDateViewmodel
            {
                Payments = payments,
                TotalAmount = totalAmount
            };
            return View(payments);
        }

        

    }
}
