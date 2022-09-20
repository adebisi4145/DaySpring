using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface ISizeService
    {
        public Task<BaseResponse> CreateSize(CreateSizeRequestModel model);

        public Task<BaseResponse> UpdateSize(int id, UpdateSizeRequestModel model);

        public Task<BaseResponse> DeleteSize(int id);

        public Task<SizeResponseModel> GetSize(int id);

        public Task<SizesResponseModel> GetSizes();
    }
}
