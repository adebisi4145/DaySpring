using DaySpring.Enums;
using DaySpring.Interfaces.Services;
using DaySpring.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPaymentService _transactionService;
        private readonly IMemberService _memberService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private PayStackApi Paystack { get; set; }
        private readonly IConfiguration  _configuration;
        private readonly string token;
        public PaymentController(IPaymentService transactionService, IMemberService memberService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _transactionService = transactionService;
            _memberService = memberService;
            _httpContextAccessor = httpContextAccessor;

            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var payments = await  _transactionService.GetPayments();
            return View(payments);
        }

        public async Task<IActionResult> GetPaymentsByEmail(string email)
        {
            var member = await _memberService.GetMemberByEmail(email);
            var payments = await _transactionService.GetMembersPaymentsByEmail(email);

            var memberspayments = new MembersPaymentViewModel
            {
                Member = member,
                Payments = payments
            };
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
                await _transactionService.CreatePayment(model, email, request.Reference);
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
                await _transactionService.VerifyPayment(reference);
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
                await _transactionService.CreatePayment(model, email, request.Reference);
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
                await _transactionService.VerifyPayment(reference);
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
            var payments = await _transactionService.GetPaymentsByEmail(member.Data.Email);
            return View(payments);
        }
        public async Task<IActionResult> GetPaymentsByEmailMember()
        {
            var signedInMemberId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var memberId = int.Parse(signedInMemberId);
            var member = await _memberService.GetMember(memberId);
            string email = member.Data.Email;
            var payments = await _transactionService.GetPaymentsByEmail(member.Data.Email);
            return View(payments);
        }

        [HttpGet]
        public IActionResult SuperAdminCreate()
        {
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
                await _transactionService.CreatePayment(model, email, request.Reference);
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
                await _transactionService.VerifyPayment(reference);
                return RedirectToAction("Index");
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
            var payments = await _transactionService.GetPaymentsByEmail(member.Data.Email);
            return View(payments);
        }

        

    }
}
