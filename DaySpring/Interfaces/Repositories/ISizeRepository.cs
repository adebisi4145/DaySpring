using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface ISizeRepository : IRepository<Size>
    {
        Task<IEnumerable<Size>> GetSelectedSizes(IList<int> ids);
    }
}
