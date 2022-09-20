using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IUserService
    {
        public Task<MemberResponseModel> Login(LoginUserRequestModel model);
        public Task<UserResponseModel> GetUser(int id);
       public Task<List<string>> GetUserRole(string email);
        public Task<UsersResponseModel> GetAllUsers();
    }
}
