using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class PaymentCategoryRepository: BaseRepository<PaymentCategory>, IPaymentCategoryRepository
    {
        public PaymentCategoryRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<IEnumerable<PaymentCategory>> GetSelectedPaymentCategories(IList<int> ids)
        {
            return await _daySpringDbContext.PaymentCategories.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
        public async Task<PaymentCategory> GetPaymentCategoryByName(string name)
        {
            return await _daySpringDbContext.PaymentCategories.SingleOrDefaultAsync(c => c.Name == name);
        }
    }
}
