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
    public class SermonService: ISermonService
    {
        private readonly ISermonRepository _sermonRepository;
        private readonly IPreacherRepository _preacherRepository;
        public SermonService(ISermonRepository sermonRepository, IPreacherRepository preacherRepository)
        {
            _sermonRepository = sermonRepository;
            _preacherRepository = preacherRepository;
        }

        public async Task<BaseResponse> CreateSermon(CreateSermonRequestModel model)
        {
            var preacher = await _preacherRepository.GetAsync(model.Preacher);
            var sermon = new Sermon
            {
                Title = model.Title,
                PreacherId = model.Preacher,
                Preacher = preacher,
                Audio = model.Audio,
                Video = model.Video
            };
            await _sermonRepository.AddAsync(sermon);
            await _sermonRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<SermonResponseModel> GetSermon(int id)
        {
            var sermon = await _sermonRepository.GetSermon(id);
            return new SermonResponseModel
            {
                Data = new SermonModel
                {
                    Id = id,
                    Title = sermon.Title,
                    PreacherId = sermon.PreacherId,
                    Preacher = sermon.Preacher,
                    Audio = sermon.Audio,
                    Video = sermon.Video
                },
                Status = true,
                Message = "Successful"
            };
        }


        public async Task<SermonsResponseModel> GetSermons()
        {
            var sermons = await _sermonRepository.GetSermons();
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<SermonsResponseModel> GetSermonAudios()
        {
            var sermons = await _sermonRepository.GetSermons();
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateSermon(int id, UpdateSermonRequestModel model)
        {
            var sermon = await _sermonRepository.GetSermon(id);
            sermon.Title = model.Title;
            sermon.PreacherId = model.Preacher;
            await _sermonRepository.UpdateAsync(sermon);
            await _sermonRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }

        public async Task<SermonsResponseModel> GetSermonsByPreacher(int preacherId)
        {
            var sermons = await _sermonRepository.GetSermonByPreacher(preacherId);
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<SermonResponseModel> GetSermonByTitle(string title)
        {
            var sermon = await _sermonRepository.GetSermonByTitle(title);
            return new SermonResponseModel
            {
                Data = new SermonModel
                {
                    Id = sermon.Id,
                    Title = sermon.Title,
                    Audio = sermon.Audio,
                    Video = sermon.Video
                },
                Status = true,
                Message = "Successful"
            };
        }
    }
}
