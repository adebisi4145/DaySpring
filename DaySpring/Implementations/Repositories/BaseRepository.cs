using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected DaySpringDbContext _daySpringDbContext { get; set; }

        public async Task<T> AddAsync(T entity)
        {
            await _daySpringDbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _daySpringDbContext.Set<T>().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _daySpringDbContext.Set<T>().ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _daySpringDbContext.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        /* public Task DeleteAsync(int id)
         {
             var entity = new T
             {
                 Id = id
             };
             _cgpaDbContext.Entry(entity).State = EntityState.Deleted;
             return Task.CompletedTask;
         }*/

        public Task DeleteAsync(T entity)
        {
            _daySpringDbContext.Entry(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _daySpringDbContext.SaveChangesAsync();
        }

    }
}
