using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DaySpringDbContext _daySpringDbContext;
        public UserRoleRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            await _daySpringDbContext.UserRoles.AddAsync(userRole);
            return userRole;
        }
        public async Task<UserRole> GetUserRoleByName(int id)
        {
            return await _daySpringDbContext.UserRoles.SingleOrDefaultAsync(c => c.Role.Id == id);
        }
        /*public async Task RemoveUserRole(string name)
        {
            var userRole = GetUserRoleByName(name);
            await _daySpringDbContext.UserRoles.RemoveAsync(userRole);
        }*/
        public Task DeleteUserRole(UserRole userRole)
        {
            _daySpringDbContext.Entry(userRole).State = EntityState.Deleted;
            return Task.CompletedTask;
        }
    }
}
