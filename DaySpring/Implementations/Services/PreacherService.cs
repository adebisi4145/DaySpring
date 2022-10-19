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
    public class PreacherService: IPreacherService
    {
        private readonly IPreacherRepository _preacherRepository;
        public PreacherService(IPreacherRepository preacherRepository)
        {
            _preacherRepository = preacherRepository;
        }

        public async Task<BaseResponse> CreatePreacher(CreatePreacherRequestModel model)
        {

            var preacher = new Preacher
            {
                Name = model.Name,
                Picture = model.Picture,
                Details = model.Details
            };
            await _preacherRepository.AddAsync(preacher);
            await _preacherRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<BaseResponse> DeletePreacher(int id)
        {
            var preacher = await _preacherRepository.GetAsync(id);
            if(preacher == null)
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Preacher not found"
                };
            }
            else
            {
                await _preacherRepository.DeleteAsync(preacher);
                await _preacherRepository.SaveChangesAsync();
                return new BaseResponse
                {
                    Status = true,
                    Message = "Successfully deleted"
                };
            }
            
        }

        public async Task<PreacherResponseModel> GetPreacher(int id)
        {
            var preacher = await _preacherRepository.GetAsync(id);
            if (preacher == null)
            {
                return null;
            }
            return new PreacherResponseModel
            {
                Data = new PreacherModel
                {
                    Id = id,
                    Name = preacher.Name,
                    Picture = preacher.Picture,
                    Details = preacher.Details
                },
                Status = true,
                Message = "Successful"
            };
            
        }
        public async Task<PreacherResponseModel> GetPreacherByName(string name)
        {
            var preacher = await _preacherRepository.GetPreacherByName(name);
            if (preacher == null)
            {
                return null;
            }
            return new PreacherResponseModel
            {
                Data = new PreacherModel
                {
                    Id = preacher.Id,
                    Name = preacher.Name,
                    Picture = preacher.Picture,
                    Details = preacher.Details
                },
                Status = true,
                Message = "Successful"
            };

        }

        public async Task<PreachersResponseModel> GetPreachers()
        {
            var preacher = await _preacherRepository.GetAllAsync();
            return new PreachersResponseModel
            {
                Data = preacher.Select(m => new PreacherModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Picture = m.Picture,
                    Details = m.Details
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdatePreacher(int id, UpdatePreacherRequestModel model)
        {
            var preacher = await _preacherRepository.GetAsync(id);
            if (preacher == null)
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Preacher not found"
                };
            }
            preacher.Name = model.Name;
            preacher.Details = model.Details;
            await _preacherRepository.UpdateAsync(preacher);
            await _preacherRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
