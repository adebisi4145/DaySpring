﻿using DaySpring.Models;
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

        public Task<AnnouncementResponseModel> GetAnnouncement(int id);

        public Task<AnnouncementsResponseModel> GetCurrentAnnouncements();

        public Task<AnnouncementsResponseModel> GetAnnouncements();
        public Task<AnnouncementsResponseModel> GetAnnouncementsByTitle(string title);
    }
}
