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
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse> CreateRole(CreateRoleRequestModel model)
        {
            var roles = await _roleRepository.GetAllAsync();
            foreach (var item in roles)
            {
                if (item.Name == model.Name)
                {
                    return new BaseResponse
                    {
                        Status = true,
                        Message = "session already exist"
                    };
                }
            }
            var role = new Role
            {
                Name = model.Name
            };
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully created"
            };
        }

        public async Task<BaseResponse> DeleteRole(int id)
        {
            var role = await _roleRepository.GetAsync(id);
            await _roleRepository.DeleteAsync(role);
            await _roleRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<RolesResponseModel> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllAsync();
            return new RolesResponseModel
            {
                Data = roles.Select(m => new RoleModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<RoleResponseModel> GetRole(int id)
        {

            var role = await _roleRepository.GetAsync(id);
            return new RoleResponseModel
            {
                Data = new RoleModel
                {
                    Id = id,
                    Name = role.Name
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<BaseResponse> UpdateRole(int id, UpdateRoleRequestModel model)
        {
            var role = await _roleRepository.GetAsync(id);
            if (role == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Session not found"
                };
            }
            else
            {
                role.Name = model.Name;
                await _roleRepository.UpdateAsync(role);
                await _roleRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Successfully Updated"
                };
            }
        }
    }
}
