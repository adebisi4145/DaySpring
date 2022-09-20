using DaySpring.Dtos;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseResponse> CreateCategory(CreateCategoryRequestModel model)
        {
            var category = new Category
            {
                Name = model.Name
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<CategoriesResponseModel> GetCategories()
        {
            var category = await _categoryRepository.GetAllAsync();
            return new CategoriesResponseModel
            {
                Data = category.Select(m => new CategoryModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<CategoryResponseModel> GetCategory(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return new CategoryResponseModel
            {
                Data = new CategoryModel
                {
                    Id = id,
                    Name = category.Name
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<BaseResponse> UpdateCategory(int id, UpdateCategoryRequestModel model)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Session not found"
                };
            }
            else
            {
                category.Name = model.Name;
                await _categoryRepository.UpdateAsync(category);
                await _categoryRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Successfully Updated"
                };
            }
        }
    }
}
