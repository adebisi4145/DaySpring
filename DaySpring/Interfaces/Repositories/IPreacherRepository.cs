using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IPreacherRepository : IRepository<Preacher>
    {
        Task<Preacher> GetPreacherByName(string name);
    }
}
