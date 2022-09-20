using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class SermonRepository : BaseRepository<Sermon>, ISermonRepository
    {
        public SermonRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }

        public async Task<Sermon> GetSermonByTitle(string title)
        {
            return await _daySpringDbContext.Sermons.Include(c => c.Preacher).SingleOrDefaultAsync(b => b.Title == title);
        }

        public async Task<List<Sermon>> GetSermonByPreacher(int preacherId)
        {
            return await _daySpringDbContext.Sermons.Include(c => c.Preacher)
                .Where(c => c.PreacherId == preacherId)
                .ToListAsync();
        }

        public async Task<List<Sermon>> GetSermons()
        {
            return await _daySpringDbContext.Sermons.Include(c => c.Preacher).ToListAsync();
        }

        public async Task<Sermon> GetSermon(int id)
        {
            return await _daySpringDbContext.Sermons.Include(c => c.Preacher).SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
