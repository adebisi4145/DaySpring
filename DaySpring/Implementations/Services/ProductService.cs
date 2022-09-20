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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        public ProductService(IProductRepository productRepository, IColorRepository colorRepository, ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
        }
        public async Task<BaseResponse> CreateProduct(CreateProductRequestModel model)
        {
            var products = await _productRepository.GetProducts();

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                PoductImage = model.ProductImage,
            };

            var sizes = await _sizeRepository.GetSelectedSizes(model.ProductSizes);
            foreach (var size in sizes)
            {
                var productSize = new ProductSize
                {
                    Product = product,
                    ProductId = product.Id,
                    Size = size,
                    SizeId = size.Id
                };

                product.ProductSizes.Add(productSize);
            }

            var colors = await _colorRepository.GetSelectedColors(model.ProductColors);
            foreach (var color in colors)
            {
                var productColor = new ProductColor
                {
                    Product = product,
                    ProductId = product.Id,
                    Color = color,
                    ColorId = color.Id
                };

                product.ProductColors.Add(productColor);
            }

            if (products.Contains(product))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Product Already Exits"
                };
            }

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            await _productRepository.DeleteAsync(product);
            await _productRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<ProductResponseModel> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            return new ProductResponseModel
            {
                Data = new ProductModel
                {
                    Id = id,
                    Name = product.Name,
                    Price = product.Price,
                    ProductImage = product.PoductImage,
                    ProductSizes = product.ProductSizes.Select(a => new SizeModel()
                    {
                        Id = a.SizeId,
                        Name = a.Size.Name,
                        Abbreviation = a.Size.Abbreviation,
                    }).ToList(),

                    ProductColors = product.ProductColors.Select(a => new ColorModel()
                    {
                        Id = a.ColorId,
                        Name = a.Color.Name
                    }).ToList()
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<ProductsResponseModel> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return new ProductsResponseModel
            {
                Data = products.Select(m => new ProductModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    ProductImage = m.PoductImage,
                    ProductSizes = m.ProductSizes.Select(a => new SizeModel()
                    {
                        Id = a.SizeId,
                        Name = a.Size.Name,
                        Abbreviation = a.Size.Abbreviation,
                    }).ToList(),

                    ProductColors = m.ProductColors.Select(a => new ColorModel()
                    {
                        Id = a.ColorId,
                        Name = a.Color.Name,
                    }).ToList()

                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateProduct(int id, UpdateProductRequestModel model)
        {
            var product = await _productRepository.GetAsync(id);
            var colors = await _colorRepository.GetSelectedColors(model.ProductColors);
            var sizes = await _sizeRepository.GetSelectedSizes(model.ProductSizes);

            product.Name = model.Name;
            product.Price = model.Price;
            foreach (var size in sizes)
            {
                var productSize = new ProductSize
                {
                    Product = product,
                    ProductId = product.Id,
                    Size = size,
                    SizeId = size.Id
                };
                product.ProductSizes.Add(productSize);
            }

            foreach (var color in colors)
            {
                var productColor = new ProductColor
                {
                    Product = product,
                    ProductId = product.Id,
                    Color = color,
                    ColorId = color.Id
                };
                product.ProductColors.Add(productColor);
            }

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
