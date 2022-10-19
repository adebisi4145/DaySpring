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
    public class PaymentCategoryService: IPaymentCategoryService
    {
        private readonly IPaymentCategoryRepository _paymentCategoryRepository;
        public PaymentCategoryService(IPaymentCategoryRepository paymentCategoryRepository)
        {
            _paymentCategoryRepository = paymentCategoryRepository;
        }

        public async Task<BaseResponse> CreatePaymentCategory(CreatePaymentCategoryRequestModel model)
        {
            var paymentCategory = new PaymentCategory
            {
                Name = model.Name
            };
            await _paymentCategoryRepository.AddAsync(paymentCategory);
            await _paymentCategoryRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeletePaymentCategory(int id)
        {
            var paymentCategory = await _paymentCategoryRepository.GetAsync(id);
            await _paymentCategoryRepository.DeleteAsync(paymentCategory);
            await _paymentCategoryRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<PaymentCategoriesResponseModel> GetPaymentCategories()
        {
            var paymentCategories = await _paymentCategoryRepository.GetAllAsync();
            return new PaymentCategoriesResponseModel
            {
                Data = paymentCategories.Select(m => new PaymentCategoryModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<PaymentCategoryResponseModel> GetPaymentCategory(int id)
        {
            var paymentCategory = await _paymentCategoryRepository.GetAsync(id);
            return new PaymentCategoryResponseModel
            {
                Data = new PaymentCategoryModel
                {
                    Id = id,
                    Name = paymentCategory.Name
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<PaymentCategoryResponseModel> GetPaymentCategoryByName(string name)
        {
            var productCategory = await _paymentCategoryRepository.GetPaymentCategoryByName(name);
            if (productCategory == null)
            {
                return null;
            }
            return new PaymentCategoryResponseModel
            {
                Data = new PaymentCategoryModel
                {
                    Id = productCategory.Id,
                    Name = productCategory.Name
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<BaseResponse> UpdatePaymentCategory(int id, UpdatePaymentCategoryRequestModel model)
        {
            var productCategory = await _paymentCategoryRepository.GetAsync(id);
            productCategory.Name = model.Name;
            await _paymentCategoryRepository.UpdateAsync(productCategory);
            await _paymentCategoryRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
