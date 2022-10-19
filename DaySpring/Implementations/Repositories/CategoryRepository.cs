using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<IEnumerable<Category>> GetSelectedCategories(IList<int> ids)
        {
            return await _daySpringDbContext.Categories.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            return await _daySpringDbContext.Categories.SingleOrDefaultAsync(c => c.Name == name);
        }
    }
}
