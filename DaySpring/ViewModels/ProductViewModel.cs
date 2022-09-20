using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateProductRequestModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ProductImage { get; set; }
        public List<int> ProductSizes { get; set; } = new List<int>();
        public List<int> ProductColors { get; set; } = new List<int>();
    }

    public class UpdateProductRequestModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<int> ProductColors { get; set; } = new List<int>();
        public List<int> ProductSizes { get; set; } = new List<int>();
    }

    public class ProductResponseModel : BaseResponse
    {
        public ProductModel Data { get; set; }
    }

    public class ProductsResponseModel : BaseResponse
    {
        public List<ProductModel> Data { get; set; }
    }
}
