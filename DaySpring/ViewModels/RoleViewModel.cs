using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
    }

    public class UpdateRoleRequestModel
    {
        public string Name { get; set; }
    }

    public class RoleResponseModel : BaseResponse
    {
        public RoleModel Data { get; set; }
    }
    public class RolesResponseModel : BaseResponse
    {
        public List<RoleModel> Data { get; set; }
    }
}
