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

        public async Task<List<Member>> GetMinisters()
        {
            return await _daySpringDbContext.Members
                .Include(c => c.User)
                .ThenInclude(c => c.UserRoles)
                .ThenInclude(c => c.Role)
                .Where(c => c.User.UserRoles.Select(c=>c.Role.Name).Contains("minister"))
                .ToListAsync();
        }
        public async Task<List<Member>> GetMembers()
        {
            return await _daySpringDbContext.Members
                 .Include(c => c.User)
                 .ThenInclude(c => c.UserRoles)
                 .ThenInclude(c => c.Role).ToListAsync();
        }

        public async Task<Member> GetMember(int id)
        {
            return await _daySpringDbContext.Members
                 .Include(c => c.User)
                 .ThenInclude(c => c.UserRoles)
                 .ThenInclude(c => c.Role)
                 .SingleOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<List<Member>> GetMembersByName(string name)
        {
            return await _daySpringDbContext.Members
                 .Include(c => c.User)
                 .ThenInclude(c => c.UserRoles)
                 .ThenInclude(c => c.Role)
                 .Where(m => EF.Functions.Like(m.LastName, $"%{name}%"))
                 //.Where(c => c.FirstName.ToLower() == name.ToLower() || c.LastName.ToLower() == name.ToLower() || c.FirstName.ToLower().Contains(name.ToLower()) || c.LastName.Contains(name.ToLower()))
                 .ToListAsync();
        }
    }
}
