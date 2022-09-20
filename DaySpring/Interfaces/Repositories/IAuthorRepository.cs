using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetSelectedAuthors(IList<int> ids);
    }
}
