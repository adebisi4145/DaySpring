using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class PreacherRepository : BaseRepository<Preacher>, IPreacherRepository
    {
        public PreacherRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<Preacher> GetPreacherByName(string name)
        {
            return await _daySpringDbContext.Preachers.SingleOrDefaultAsync(c => c.Name == name || c.Name.Contains(name));
        }
    }
}
