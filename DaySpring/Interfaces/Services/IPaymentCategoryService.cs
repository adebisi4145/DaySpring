using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IPaymentCategoryService
    {
        public Task<PaymentCategoryResponseModel> GetPaymentCategory(int id);
        public Task<PaymentCategoryResponseModel> GetPaymentCategoryByName(string name);

        public Task<PaymentCategoriesResponseModel> GetPaymentCategories();

        public Task<BaseResponse> UpdatePaymentCategory(int id, UpdatePaymentCategoryRequestModel model);

        public Task<BaseResponse> CreatePaymentCategory(CreatePaymentCategoryRequestModel model);

        public Task<BaseResponse> DeletePaymentCategory(int id);
    }
}
