using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IPaymentRepository: IRepository<Payment>
    {
        Task<Payment> GetPayment(int id);
        public Task<Payment> GetPaymentByPaymentReference(string reference);
        Task<List<Payment>> GetPaymentsByEmail(string email);
        Task<List<Payment>> GetPaymentsByDate(DateTime date);
        Task<List<Payment>> GetPayments();
    }
}
