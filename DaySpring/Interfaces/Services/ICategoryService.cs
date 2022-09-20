using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<CategoryResponseModel> GetCategory(int id);

        public Task<CategoriesResponseModel> GetCategories();

        public Task<BaseResponse> UpdateCategory(int id, UpdateCategoryRequestModel model);

        public Task<BaseResponse> CreateCategory(CreateCategoryRequestModel model);

        public Task<BaseResponse> DeleteCategory(int id);
    }
}
