using DaySpring.Interfaces.Repositories;
using DaySpring.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DaySpringDbContext daySpringDbContext)
        {
            _daySpringDbContext = daySpringDbContext;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _daySpringDbContext.Products
                .Include(b => b.ProductColors)
                .ThenInclude(a => a.Color)
                .Include(b => b.ProductSizes)
                .ThenInclude(a => a.Size)
                .ToListAsync();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _daySpringDbContext.Products
                .Include(b => b.ProductColors)
                .ThenInclude(a => a.Color)
                .Include(b => b.ProductSizes)
                .ThenInclude(a => a.Size)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
