﻿using DaySpring.Dtos;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<BaseResponse> CreateAnnouncement(CreateAnnouncementRequestModel model)
        {
            var anouncements = await _announcementRepository.GetAllAsync();
            var announcement = new Announcement()
            {
                Title = model.Title,
                AnnouncementImage = model.AnnouncementImage,
                Description = model.Description,
                StartingDate = model.StartingDate,
                EndingDate = model.EndingDate,
                DateAdded = DateTime.Now
            };
            
            if(anouncements.Contains(announcement))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Announcement already exist"
                };
            }
            await _announcementRepository.AddAsync(announcement);
            await _announcementRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Announcement Successfully added"
            };
        }

        public async Task<AnnouncementResponseModel> GetAnnouncement(int id)
        {
            var announcement = await _announcementRepository.GetAsync(id);
            return new AnnouncementResponseModel
            {
                Data = new AnnouncementModel
                {
                    Id = id,
                    Title = announcement.Title,
                    AnnouncementImage = announcement.AnnouncementImage,
                    Description = announcement.Description,
                    StartingDate = announcement.StartingDate,
                    EndingDate = announcement.EndingDate,
                    DateAdded = announcement.DateAdded
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<AnnouncementsResponseModel> GetAnnouncements()
        {
            var announcement = await _announcementRepository.GetAllAsync();
            announcement.Reverse();
            return new AnnouncementsResponseModel
            {
                Data = announcement.Select(m => new AnnouncementModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    AnnouncementImage = m.AnnouncementImage,
                    Description = m.Description,
                    StartingDate = m.StartingDate,
                    EndingDate = m.EndingDate,
                    DateAdded = m.DateAdded
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }
        public async Task<AnnouncementsResponseModel> GetAnnouncementsByTitle(string title)
        {
            var announcement = await _announcementRepository.GetAnnouncementsByTitle(title);
            if (announcement.Count == 0)
            {
                return null;
            }
            return new AnnouncementsResponseModel
            {
                Data = announcement.Select(m => new AnnouncementModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    AnnouncementImage = m.AnnouncementImage,
                    Description = m.Description,
                    StartingDate = m.StartingDate,
                    EndingDate = m.EndingDate,
                    DateAdded = m.DateAdded
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<AnnouncementsResponseModel> GetCurrentAnnouncements()
        {
            var announcement = await _announcementRepository.GetCurrentAnnouncements();
            announcement.Reverse();
            return new AnnouncementsResponseModel
            {
                Data = announcement.Select(m => new AnnouncementModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    AnnouncementImage = m.AnnouncementImage,
                    Description = m.Description,
                    StartingDate = m.StartingDate,
                    EndingDate = m.EndingDate,
                    DateAdded = m.DateAdded
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }



        public async Task<BaseResponse> UpdateAnnouncement(int id, UpdateAnnouncementRequestModel model)
        {
            var announcement = await _announcementRepository.GetAsync(id);
            announcement.Title = model.Title;
            announcement.Description = model.Description;
            announcement.StartingDate = model.StartingDate;
            announcement.EndingDate = model.EndingDate;
            await _announcementRepository.UpdateAsync(announcement);
            await _announcementRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
