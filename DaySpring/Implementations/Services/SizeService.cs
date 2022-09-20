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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        public async Task<BaseResponse> CreateSize(CreateSizeRequestModel model)
        {
            var sizes = await _sizeRepository.GetAllAsync();
            var size = new Size
            {
                Name = model.Name,
                Abbreviation = model.Abbreviation
            };
            if (sizes.Contains(size))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Product Already Exits"
                };
            }
            await _sizeRepository.AddAsync(size);
            await _sizeRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeleteSize(int id)
        {
            var size = await _sizeRepository.GetAsync(id);
            await _sizeRepository.DeleteAsync(size);
            await _sizeRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<SizeResponseModel> GetSize(int id)
        {
            var size = await _sizeRepository.GetAsync(id);
            return new SizeResponseModel
            {
                Data = new SizeModel
                {
                    Id = id,
                    Name = size.Name,
                    Abbreviation = size.Abbreviation
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<SizesResponseModel> GetSizes()
        {
            var size = await _sizeRepository.GetAllAsync();
            return new SizesResponseModel
            {
                Data = size.Select(m => new SizeModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Abbreviation = m.Abbreviation
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateSize(int id, UpdateSizeRequestModel model)
        {
            var size = await _sizeRepository.GetAsync(id);
            size.Name = model.Name;
            size.Abbreviation = model.Abbreviation;
            await _sizeRepository.UpdateAsync(size);
            await _sizeRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
