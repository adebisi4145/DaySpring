using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class ColorRepository: BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<IEnumerable<Color>> GetSelectedColors(IList<int> ids)
        {
            return await _daySpringDbContext.Colors.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
    }
}
