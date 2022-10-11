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

        public Task<SermonsResponseModel> GetSermonsByTitle(string title);

        public Task<SermonsResponseModel> GetSermons();
        public Task<SermonsResponseModel> GetSermonAudios();
        public Task<SermonsResponseModel> GetSermonsByPreacher(int id);

        public Task<SermonResponseModel> GetSermon(int id);
        public Task<BaseResponse> DeleteSermon(int id);
    }
}
