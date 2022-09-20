using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IColorService
    {
        public Task<BaseResponse> CreateColor(CreateColorRequestModel model);

        public Task<BaseResponse> UpdateColor(int id, UpdateColorRequestModel model);

        public Task<BaseResponse> DeleteColor(int id);

        public Task<ColorResponseModel> GetColor(int id);

        public Task<ColorsResponseModel> GetColors();
    }
}
