using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRole> AddUserRole(UserRole userRole);
        Task<UserRole> GetUserRoleByName(int id);
        Task DeleteUserRole(UserRole userRole);
    }
}
