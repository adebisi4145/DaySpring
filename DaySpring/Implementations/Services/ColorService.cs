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
    public class ColorService: IColorService
    {
        private readonly IColorRepository _colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;       
        }

        public async Task<BaseResponse> CreateColor(CreateColorRequestModel model)
        {
            var colors = await _colorRepository.GetAllAsync();
            var color = new Color
            {
                Name = model.Name
            };
            if (colors.Contains(color))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Product Already Exits"
                };
            }
            await _colorRepository.AddAsync(color);
            await _colorRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeleteColor(int id)
        {
            var color = await _colorRepository.GetAsync(id);
            await _colorRepository.DeleteAsync(color);
            await _colorRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully deleted"
            };
        }

        public async Task<ColorResponseModel> GetColor(int id)
        {
            var color = await _colorRepository.GetAsync(id);
            return new ColorResponseModel
            {
                Data = new ColorModel
                {
                    Id = id,
                    Name = color.Name
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<ColorsResponseModel> GetColors()
        {
            var color = await _colorRepository.GetAllAsync();
            return new ColorsResponseModel
            {
                Data = color.Select(m => new ColorModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateColor(int id, UpdateColorRequestModel model)
        {
            var color = await _colorRepository.GetAsync(id);
            color.Name = model.Name;
            await _colorRepository.UpdateAsync(color);
            await _colorRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
