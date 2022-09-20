using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IAnnouncementService
    {
        public Task<BaseResponse> CreateAnnouncement(CreateAnnouncementRequestModel model);

        public Task<BaseResponse> UpdateAnnouncement(int id, UpdateAnnouncementRequestModel model);

        public Task<BaseResponse> DeleteAnnouncements();

        public Task<AnnouncementResponseModel> GetAnnouncement(int id);

        public Task<AnnouncementsResponseModel> GetAnnouncements();
    }
}
