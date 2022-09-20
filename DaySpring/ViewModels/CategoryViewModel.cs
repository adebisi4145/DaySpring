using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateCategoryRequestModel
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryRequestModel
    {
        public string Name { get; set; }
    }

    public class CategoryResponseModel : BaseResponse
    {
        public CategoryModel Data { get; set; }
    }
    public class CategoriesResponseModel : BaseResponse
    {
        public List<CategoryModel> Data { get; set; }
    }
}
