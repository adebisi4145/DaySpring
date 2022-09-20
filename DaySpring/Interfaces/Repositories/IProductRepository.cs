using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
    }
}
