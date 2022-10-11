using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IMemberRepository: IRepository<Member>
    {
        Task<Member> GetMemberByEmailAsync(string email);
        Task<List<Member>> GetMinisters();
        Task<List<Member>> GetMembers();
    }
}
