using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string name);
    }
}
