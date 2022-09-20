using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<T> UpdateAsync(T entity);

        Task<T> AddAsync(T entity);

        /*Task DeleteAsync(int id);*/

        public Task DeleteAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}
