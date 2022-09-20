using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class MemberRepository: BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<Member> GetMemberByEmailAsync(string email)
        {
            return await _daySpringDbContext.Members.SingleOrDefaultAsync(c => c.Email == email);
        }
        public async Task<List<Member>> GetMembers()
        {
            return await _daySpringDbContext.Members
                 .Include(c => c.User)
                 .ThenInclude(c => c.UserRoles)
                 .ThenInclude(c => c.Role).ToListAsync();
        }
    }
}
