using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<Announcement> AddAnnouncement(Announcement announcement)
        {
            await _daySpringDbContext.Announcements.AddRangeAsync(announcement);
            return announcement;
        }
    }
}
