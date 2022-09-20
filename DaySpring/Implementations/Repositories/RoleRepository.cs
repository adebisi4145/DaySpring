using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class RoleRepository:BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _daySpringDbContext.Roles.SingleOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
