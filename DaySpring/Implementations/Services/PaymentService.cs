﻿using DaySpring.Dtos;
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
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentCategoryRepository _paymentCategoryRepository;
        private readonly IMemberRepository _memberRepository;
        public PaymentService(IPaymentRepository transactionRepository, IMemberRepository memberRepository, IPaymentCategoryRepository paymentCategoryRepository)
        {
            _paymentRepository = transactionRepository;
            _memberRepository = memberRepository;
            _paymentCategoryRepository = paymentCategoryRepository;
        }
        public async Task<BaseResponse> CreatePayment(CreatePaymentRequestModel model, string email, string reference)
        {
            var paymentCategory = await _paymentCategoryRepository.GetAsync(model.PaymentCategoryId);
            var member = await _memberRepository.GetMemberByEmailAsync(email);
            var transaction = new Payment
            {
                MemberId = member.Id,
                Member = member,
                Email = member.Email,
                Amount = model.Amount,
                CreatedAt = DateTime.Now,
                PaymentCategoryId = model.PaymentCategoryId,
                PaymentCategory = paymentCategory,
                PaymentReference = reference
            };
            await _paymentRepository.AddAsync(transaction);
            await _paymentRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }
        public async Task VerifyPayment(string reference)
        {
            var transaction = await _paymentRepository.GetPaymentByPaymentReference(reference);
            if (transaction != null)
            {
                transaction.Status = true;
            }
            await _paymentRepository.UpdateAsync(transaction);
            await _paymentRepository.SaveChangesAsync();
        }

        public Task<PaymentResponseModel> GetPayment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentsResponseModel> GetPayments()
        {
            var transactions = await _paymentRepository.GetPayments();
            transactions.Reverse();
            return new PaymentsResponseModel
            {
                Data = transactions.Select(m => new PaymentModel
                {
                    Email = m.Email,
                    Amount = m.Amount,
                    Member = m.Member,
                    MemberId = m.MemberId,
                    PaymentCategory = m.PaymentCategory,
                    PaymentCategoryId = m.PaymentCategoryId,
                    PaymentReference = m.PaymentReference,
                    CreatedAt = m.CreatedAt
                }).ToList(),
            };
        }

        public async Task<List<PaymentModel>> GetAllPaymentsByEmail(string email)
        {
            var transactions = await _paymentRepository.GetPaymentsByEmail(email);
            transactions.Reverse();
            var transaction = transactions.Select(m => new PaymentModel
            {
                Email = m.Email,
                Amount = m.Amount,
                Member = m.Member,
                MemberId = m.MemberId,
                PaymentCategory = m.PaymentCategory,
                PaymentCategoryId = m.PaymentCategoryId,
                PaymentReference = m.PaymentReference,
                CreatedAt = m.CreatedAt
            }).ToList();
            return transaction;
        }
        public async Task<PaymentsResponseModel> GetPaymentsByEmail(string email)
        {
            var transactions = await _paymentRepository.GetPaymentsByEmail(email);
            transactions.Reverse();
            return new PaymentsResponseModel
            {
                Data = transactions.Select(m => new PaymentModel
                {
                    Email = m.Email,
                    Amount = m.Amount,
                    Member = m.Member,
                    MemberId = m.MemberId,
                    PaymentCategory = m.PaymentCategory,
                    PaymentCategoryId = m.PaymentCategoryId,
                    PaymentReference = m.PaymentReference,
                    CreatedAt = m.CreatedAt
                }).ToList(),
            };
        }

        public async Task<List<PaymentModel>> GetMembersPaymentsByEmail(string email)
        {
            var transactions = await _paymentRepository.GetPaymentsByEmail(email);
            transactions.Reverse();
            var transaction = transactions.Select(m => new PaymentModel
            {
                Email = m.Email,
                Amount = m.Amount,
                Member = m.Member,
                MemberId = m.MemberId,
                PaymentCategory = m.PaymentCategory,
                PaymentCategoryId = m.PaymentCategoryId,
                PaymentReference = m.PaymentReference,
                CreatedAt = m.CreatedAt
            }).ToList();
            return transaction;
        }
        public async Task<List<PaymentModel>> GetPaymentsByDate(DateTime startingDate, DateTime endingDate, List<int> paymentCategoryIds)
        {
            var payments = await _paymentRepository.GetPaymentsByDate(startingDate, endingDate, paymentCategoryIds);
            var payment = payments.Select(m => new PaymentModel
            {
                Email = m.Email,
                Amount = m.Amount,
                Member = m.Member,
                MemberId = m.MemberId,
                PaymentCategory = m.PaymentCategory,
                PaymentCategoryId = m.PaymentCategoryId,
                PaymentReference = m.PaymentReference,
                CreatedAt = m.CreatedAt
            }).ToList();
            return payment;
        }

        public async Task<Double> GetTotalPayment(DateTime startingDate, DateTime endingDate, List<int> paymentCategoryIds)
        {
            var payments = await _paymentRepository.GetPaymentsByDate(startingDate, endingDate, paymentCategoryIds);
            var amounts = payments.Select(c => c.Amount);
            double totalAmount = 0;
            foreach(var amount in amounts)
            {
                totalAmount += amount;
            }
            return totalAmount;
        }
    }
}
