using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<IEnumerable<Author>> GetSelectedAuthors(IList<int> ids)
        {
            return await _daySpringDbContext.Authors.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
    }
}
