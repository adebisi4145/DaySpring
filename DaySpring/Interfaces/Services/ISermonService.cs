using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface ISermonService
    {
        public Task<BaseResponse> CreateSermon(CreateSermonRequestModel model);

        public Task<BaseResponse> UpdateSermon(int id, UpdateSermonRequestModel model);

        public Task<SermonResponseModel> GetSermonByTitle(string title);

        public Task<SermonsResponseModel> GetSermons();
        public Task<SermonsResponseModel> GetSermonsByPreacher(int preacherId);

        public Task<SermonResponseModel> GetSermon(int id);
    }
}
