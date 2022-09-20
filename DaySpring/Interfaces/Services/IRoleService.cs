using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<RoleResponseModel> GetRole(int id);

        public Task<BaseResponse> CreateRole(CreateRoleRequestModel model);

        public Task<BaseResponse> UpdateRole(int id, UpdateRoleRequestModel model);

        public Task<RolesResponseModel> GetAllRoles();

        public Task<BaseResponse> DeleteRole(int id);
    }
}
