using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        Task<Announcement> AddAnnouncement(Announcement announcement);
        Task<List<Announcement>> GetCurrentAnnouncements();
        Task<List<Announcement>> GetAnnouncementsByTitle(string title);
    }
}
