using DaySpring.Dtos;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IProductService
    {
        public Task<BaseResponse> CreateProduct(CreateProductRequestModel model);

        public Task<BaseResponse> UpdateProduct(int id, UpdateProductRequestModel model);

        public Task<BaseResponse> DeleteProduct(int id);
        public Task<ProductResponseModel> GetProduct(int id);
        public Task<ProductsResponseModel> GetProducts();
    }
}
