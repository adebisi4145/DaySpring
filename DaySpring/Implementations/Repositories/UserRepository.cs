using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _daySpringDbContext.Users
                .Include(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .SingleOrDefaultAsync(c => c.Email == email);
        }
    }
}
