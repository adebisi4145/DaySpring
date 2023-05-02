using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class PaymentRepository :BaseRepository<Payment> , IPaymentRepository
    {
        public PaymentRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<Payment> GetPayment(int id)
        {
            return await _daySpringDbContext.Payments
                .Include(c => c.Member)
                .ThenInclude(c => c.User)
                .Include(c => c.PaymentCategory)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Payment> GetPaymentByPaymentReference(string reference)
        {
            return await _daySpringDbContext.Payments
                .Include(c => c.Member)
                .ThenInclude(c => c.User)
                .Include(c => c.PaymentCategory)
                .SingleOrDefaultAsync(c => c.PaymentReference == reference);
        }

        public async Task<List<Payment>> GetPaymentsByDate(DateTime startingDate, DateTime endingDate, List<int> paymentCategoryIds)
        {
            return await _daySpringDbContext.Payments
                .Include(c => c.Member)
                .ThenInclude(c => c.User)
                .Include(c => c.PaymentCategory)
                .Where(c => c.CreatedAt >= startingDate && c.CreatedAt <= endingDate && c.Status==true && paymentCategoryIds.Contains(c.PaymentCategoryId))
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsByEmail(string email)
        {
            return await _daySpringDbContext.Payments
                .Include(c => c.Member)
                .ThenInclude(c => c.User)
                .Include(c=>c.PaymentCategory)
                .Where(c => c.Email == email && c.Status== true)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPayments()
        {
            return await _daySpringDbContext.Payments
                .Include(c => c.Member)
                .ThenInclude(c => c.User)
                .Include(c => c.PaymentCategory)
                .Where(c => c.Status == true)
                .ToListAsync();
        }
    }
}
