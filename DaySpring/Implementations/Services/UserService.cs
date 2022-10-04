using DaySpring.Dtos;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemberRepository _memberRepository;
        public UserService(IUserRepository userRepository, IMemberRepository memberRepository)
        {
            _userRepository = userRepository;
            _memberRepository = memberRepository;
        }
        public async Task<MemberResponseModel> Login(LoginUserRequestModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);
            var member = await _memberRepository.GetMemberByEmailAsync(user.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }
            return new MemberResponseModel
            {
                Data = new MemberModel
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    User = user,
                    UserId= user.Id
                },
                Status = true,
                Message = "Login Successful"
            };

        }

        public async Task<UsersResponseModel> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return new UsersResponseModel
            {
                Data = users.Select(m => new UserModel
                {
                    Id = m.Id,
                    Email = m.Email,
                    PasswordHash = m.PasswordHash
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<UserResponseModel> GetUser(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return new UserResponseModel
            {
                Data = new UserModel
                {
                    Id = id,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash
                },
                Status = true,
                Message = "Successful"
            };
        }
        public async Task<List<string>> GetUserRole(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            var userRole = user.UserRoles.Select(c => c.Role.Name.ToLower()).ToList();
            return userRole;
        }



    }
}
