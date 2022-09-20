using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class SizeRepository : BaseRepository<Size>, ISizeRepository
    {
        public SizeRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<IEnumerable<Size>> GetSelectedSizes(IList<int> ids)
        {
            return await _daySpringDbContext.Sizes.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
    }
}
