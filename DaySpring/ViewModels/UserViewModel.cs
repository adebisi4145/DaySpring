using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class RegisterUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserResponseModel : BaseResponse
    {
        public UserModel Data { get; set; }
    }
    public class UsersResponseModel : BaseResponse
    {
        public List<UserModel> Data { get; set; }
    }
}
