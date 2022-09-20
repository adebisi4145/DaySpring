using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IPreacherService
    {
        public Task<PreacherResponseModel> GetPreacher(int id);
        public Task<PreacherResponseModel> GetPreacherByName(string name);

        public Task<PreachersResponseModel> GetPreachers();

        public Task<BaseResponse> UpdatePreacher(int id, UpdatePreacherRequestModel model);

        public Task<BaseResponse> CreatePreacher(CreatePreacherRequestModel model);

        public Task<BaseResponse> DeletePreacher(int id);
    }
}
