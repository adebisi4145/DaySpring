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
    public class MemberService: IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public MemberService(IMemberRepository memberRepository, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _memberRepository = memberRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<BaseResponse> DeleteMember(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            await _memberRepository.DeleteAsync(member);
            await _userRepository.DeleteAsync(user);
            await _memberRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Deleted"
            };
        }

        public async Task<MemberResponseModel> GetMember(int id)
        {
            var member = await _memberRepository.GetMember(id);
            return new MemberResponseModel
            {
                Data = new MemberModel
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    UserId = member.UserId,
                    User = member.User
                },
                Status = true,
                Message = "successful"
            };
        }

        public async Task<MemberModel> GetMemberById(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            return new MemberModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                UserId = member.UserId,
                User = member.User
            };
        }

        public async Task<MembersResponseModel> GetAllMembers()
        {
            var members = await _memberRepository.GetMembers();
            return new MembersResponseModel
            {
                Data = members.Select(m => new MemberModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    UserId = m.UserId,
                    User = m.User
                }).ToList(),
                Status = true,
                Message = "successful"
            };

        }

        public async Task<MembersResponseModel> GetMembersByName(string name)
        {
            var members = await _memberRepository.GetMembersByName(name);
            if(members.Count == 0)
            {
                return null;
            }
            return new MembersResponseModel
            {
                Data = members.Select(m => new MemberModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    UserId = m.UserId,
                    User = m.User
                }).ToList(),
                Status = true,
                Message = "successful"
            };

        }

        public async Task<MemberModel> GetMemberByEmail(string email)
        {
            var member = await _memberRepository.GetMemberByEmailAsync(email);
            if(member == null)
            {
                return null;
            }
            return new MemberModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                UserId = member.UserId,
                User = member.User
            };
        }

        public async Task<MembersResponseModel> GetMinisters()
        {
            var members = await _memberRepository.GetMinisters();
            return new MembersResponseModel
            {
                Data = members.Select(m => new MemberModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    UserId = m.UserId,
                    User = m.User
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> CreateMember(CreateMemberRequestModel model)
        {
            var members = await _memberRepository.GetAllAsync();
            var membersEmail = members.Select(c => c.Email);
            if(membersEmail.Contains(model.Email))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "member already exist"
                };
            }

            var role = await _roleRepository.GetRoleByNameAsync("member");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new User
            {
                Email = model.Email,
                PasswordHash = hashedPassword
            };
            await _userRepository.AddAsync(user);
            await _memberRepository.SaveChangesAsync();

            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            await _userRoleRepository.AddUserRole(userRole);
            await _memberRepository.SaveChangesAsync();

            var member = new Member
            {
                UserId = user.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            await _memberRepository.AddAsync(member);
            await _memberRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Student successfully registered"
            };

            /*else
            {
                var role = await _roleRepository.GetRoleByNameAsync("member");
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                if(!BCrypt.Net.BCrypt.Verify(model.ConfirmPassword, hashedPassword))
                {
                    return new BaseResponse
                    {
                        Status = true,
                        Message = "Password is not the same"
                    };
                }
                else
                {
                    var user = new User
                    {
                        Email = model.Email,
                        PasswordHash = hashedPassword
                    };
                    await _userRepository.AddAsync(user);
                    await _memberRepository.SaveChangesAsync();

                    var userRole = new UserRole
                    {
                        User = user,
                        UserId= user.Id,
                        Role = role,
                        RoleId = role.Id
                    };
                    await _userRoleRepository.AddUserRole(userRole);
                    await _memberRepository.SaveChangesAsync();

                    var member = new Member
                    {
                        UserId = user.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email
                    };
                    await _memberRepository.AddAsync(member);
                    await _memberRepository.SaveChangesAsync();
                    return new BaseResponse
                    {
                        Status = true,
                        Message = "Student successfully registered"
                    };
                }
            }*/
        }

        public async Task<BaseResponse> UpdateMember(int id, UpdateMemberRequestModel model)
        {
            var member = await _memberRepository.GetAsync(id);
            if (member == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Student not found"
                };
            }
            else
            {
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                await _memberRepository.UpdateAsync(member);
                await _memberRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Succesfully updated"
                };
            }

        }

        public async Task<BaseResponse> UpdateMemberPassword(int id, UpdateMemberPasswordRequestModel model)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            if(!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.PasswordHash))
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Your Old Password is incorrect"
                };
            }
            else
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                user.PasswordHash = hashedPassword;
                await _userRepository.UpdateAsync(user);
                await _memberRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Succesfully updated"
                };
            }
        }
        public async Task<BaseResponse> UpdateMembershipStatusToMinister(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            if (user.UserRoles.Select(c => c.Role.Name).Contains("minister"))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Member is a Minister"
                };
            }
            else
            {
                var role = await _roleRepository.GetRoleByNameAsync("minister");

                var userRole = new UserRole
                {
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                await _userRoleRepository.AddUserRole(userRole);
                await _memberRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Succesfully updated"
                };
            }
            
        }

        public async Task<BaseResponse> UpdateMembershipStatusToMedia(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            if(user.UserRoles.Select(c => c.Role.Name).Contains("Media"))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Member is in Media"
                };
            }
            else
            {
                var role = await _roleRepository.GetRoleByNameAsync("Media");
                var userRole = new UserRole
                {
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                await _userRoleRepository.AddUserRole(userRole);
                await _memberRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Succesfully updated"
                };
            }
            
        }

        public async Task<BaseResponse> RemoveMediaRole(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            var role = await _roleRepository.GetRoleByNameAsync("Media");

            var userRole = await _userRoleRepository.GetUserRoleByName(role.Id, user.Id);
            await _userRoleRepository.DeleteUserRole(userRole);
            await _memberRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Deleted"
            };
        }

        public async Task<BaseResponse> RemoveMinisterRole(int id)
        {
            var member = await _memberRepository.GetAsync(id);
            var user = await _userRepository.GetUserByEmailAsync(member.Email);
            var role = await _roleRepository.GetRoleByNameAsync("minister");

            var userRole = await _userRoleRepository.GetUserRoleByName(role.Id, user.Id);
            await _userRoleRepository.DeleteUserRole(userRole);
            await _memberRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Deleted"
            };
        }

    }
}

