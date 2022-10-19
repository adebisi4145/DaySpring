using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IPaymentCategoryRepository : IRepository<PaymentCategory>
    {
        Task<IEnumerable<PaymentCategory>> GetSelectedPaymentCategories(IList<int> ids);
        Task<PaymentCategory> GetPaymentCategoryByName(string name);
    }
}
