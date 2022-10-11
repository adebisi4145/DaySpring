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

        public async Task<List<Sermon>> GetSermonsByTitle(string title)
        {
            return await _daySpringDbContext.Sermons.Include(c => c.Preacher)
                .Include(c => c.Member)
                .Where(b => b.Title == title || b.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<List<Sermon>> GetSermonsByPreacher(int id)
        {
            return await _daySpringDbContext.Sermons
                .Include(c => c.Member)
                .Include(c => c.Preacher)
                .Where(c => c.PreacherId == id)
                .ToListAsync();
        }

        public async Task<List<Sermon>> GetSermons()
        {
            return await _daySpringDbContext.Sermons
                .Include(c => c.Preacher)
                .Include(c=>c.Member)
                .ToListAsync();
        }

        public async Task<Sermon> GetSermon(int id)
        {
            return await _daySpringDbContext.Sermons
                .Include(c => c.Preacher)
                .Include(c => c.Member)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
