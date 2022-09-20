using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<IEnumerable<Color>> GetSelectedColors(IList<int> ids);
    }
}
