using DaySpring.Dtos;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _transactionRepository;
        private readonly IMemberRepository _memberRepository;
        public PaymentService(IPaymentRepository transactionRepository, IMemberRepository memberRepository)
        {
            _transactionRepository = transactionRepository;
            _memberRepository = memberRepository;
        }
        public async Task<BaseResponse> CreatePayment(CreatePaymentRequestModel model, string email, string reference)
        {
            var member = await _memberRepository.GetMemberByEmailAsync(email);
            var transaction = new Payment
            {
                MemberId = member.Id,
                Member = member,
                Email = member.Email,
                Amount = model.Amount,
                CreatedAt = DateTime.Now,
                TransactionType = model.PaymentType,
                PaymentReference = reference
            };
            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }
        public async Task VerifyPayment(string reference)
        {
            var transaction = await _transactionRepository.GetPaymentByPaymentReference(reference);
            if (transaction != null)
            {
                transaction.Status = true;
            }
            await _transactionRepository.UpdateAsync(transaction);
            await _transactionRepository.SaveChangesAsync();
        }

        public Task<PaymentResponseModel> GetPayment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentsResponseModel> GetPayments()
        {
            var transactions = await _transactionRepository.GetPayments();
            return new PaymentsResponseModel
            {
                Data = transactions.Select(m => new PaymentModel
                {
                    Email = m.Email,
                    Amount = m.Amount,
                    Member = m.Member,
                    MemberId = m.MemberId,
                    PaymentType = m.TransactionType,
                    PaymentReference = m.PaymentReference,
                    CreatedAt = m.CreatedAt
                }).ToList(),
            };
        }

        public async Task<List<PaymentModel>> GetAllPaymentsByEmail(string email)
        {
            var transactions = await _transactionRepository.GetPaymentsByEmail(email);
            var transaction = transactions.Select(m => new PaymentModel
            {
                Email = m.Email,
                Amount = m.Amount,
                Member = m.Member,
                MemberId = m.MemberId,
                PaymentType = m.TransactionType,
                PaymentReference = m.PaymentReference,
                CreatedAt = m.CreatedAt
            }).ToList();
            return transaction;
        }
        public async Task<PaymentsResponseModel> GetPaymentsByEmail(string email)
        {
            var transactions = await _transactionRepository.GetPaymentsByEmail(email);
            return new PaymentsResponseModel
            {
                Data = transactions.Select(m => new PaymentModel
                {
                    Email = m.Email,
                    Amount = m.Amount,
                    Member = m.Member,
                    MemberId = m.MemberId,
                    PaymentType = m.TransactionType,
                    PaymentReference = m.PaymentReference,
                    CreatedAt = m.CreatedAt
                }).ToList(),
            };
        }

        public async Task<List<PaymentModel>> GetMembersPaymentsByEmail(string email)
        {
            var transactions = await _transactionRepository.GetPaymentsByEmail(email);
            var transaction = transactions.Select(m => new PaymentModel
            {
                Email = m.Email,
                Amount = m.Amount,
                Member = m.Member,
                MemberId = m.MemberId,
                PaymentType = m.TransactionType,
                PaymentReference = m.PaymentReference,
                CreatedAt = m.CreatedAt
            }).ToList();
            return transaction;
        }
        public async Task<PaymentsResponseModel> GetPaymentsByDate(DateTime date)
        {
            var payments = await _transactionRepository.GetPaymentsByDate(date);
            return new PaymentsResponseModel
            {
                Data = payments.Select(m => new PaymentModel
                {
                    Email = m.Email,
                    Amount = m.Amount,
                    Member = m.Member,
                    MemberId = m.MemberId,
                    PaymentType = m.TransactionType,
                    PaymentReference = m.PaymentReference,
                    CreatedAt = m.CreatedAt
                }).ToList(),
            };
        }
    }
}
