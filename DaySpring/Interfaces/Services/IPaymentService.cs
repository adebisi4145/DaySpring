using DaySpring.Dtos;
using DaySpring.Models;
using DaySpring.ViewModels;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IPaymentService
    {
        public Task<BaseResponse> CreatePayment(CreatePaymentRequestModel model, string email, string reference);
        public Task VerifyPayment(string reference);

        public Task<PaymentResponseModel> GetPayment(int id);

        public Task<PaymentsResponseModel> GetPayments();
        public Task<PaymentsResponseModel> GetPaymentsByEmail(string email);
        public Task<List<PaymentModel>> GetAllPaymentsByEmail(string email);
        public Task<PaymentsResponseModel> GetPaymentsByDate(DateTime date);
        public Task<List<PaymentModel>> GetMembersPaymentsByEmail(string email);
    }
}
