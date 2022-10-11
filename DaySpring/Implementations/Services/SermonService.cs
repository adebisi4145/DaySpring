using DaySpring.Dtos;
using DaySpring.Interfaces.Repositories;
using DaySpring.Interfaces.Services;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class SermonService: ISermonService
    {
        private readonly ISermonRepository _sermonRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IPreacherRepository _preacherRepository;
        public SermonService(ISermonRepository sermonRepository, IPreacherRepository preacherRepository, IMemberRepository memberRepository)
        {
            _sermonRepository = sermonRepository;
            _memberRepository = memberRepository;
            _preacherRepository = preacherRepository;
        }

        public async Task<BaseResponse> CreateSermon(CreateSermonRequestModel model)
        {
            var preacher = await _preacherRepository.GetAsync(model.Preacher);
            var member = await _memberRepository.GetAsync(model.Member);
            if(member  == null)
            {
                var sermon = new Sermon
                {
                    Title = model.Title,
                    SermonType = model.SermonType,
                    PreacherId = model.Preacher,
                    Preacher = preacher,
                    Audio = model.Audio,
                    Video = model.Video
                };
                await _sermonRepository.AddAsync(sermon);
                await _sermonRepository.SaveChangesAsync();
            }
            else if(preacher == null)
            {
                var sermon = new Sermon
                {
                    Title = model.Title,
                    SermonType = model.SermonType,
                    MemberId = model.Member,
                    Member = member,
                    Audio = model.Audio,
                    Video = model.Video
                };
                await _sermonRepository.AddAsync(sermon);
                await _sermonRepository.SaveChangesAsync();
            }
            
            
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<SermonResponseModel> GetSermon(int id)
        {
            var sermon = await _sermonRepository.GetSermon(id);
            return new SermonResponseModel
            {
                Data = new SermonModel
                {
                    Id = id,
                    Title = sermon.Title,
                    PreacherId = sermon.PreacherId,
                    Preacher = sermon.Preacher,
                    MemberId = sermon.MemberId,
                    Member = sermon.Member,
                    Audio = sermon.Audio,
                    Video = sermon.Video
                },
                Status = true,
                Message = "Successful"
            };
        }


        public async Task<SermonsResponseModel> GetSermons()
        {
            var sermons = await _sermonRepository.GetSermons();
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    MemberId = m.MemberId,
                    Member = m.Member,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<SermonsResponseModel> GetSermonAudios()
        {
            var sermons = await _sermonRepository.GetSermons();
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    MemberId = m.MemberId,
                    Member = m.Member,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateSermon(int id, UpdateSermonRequestModel model)
        {
            var sermon = await _sermonRepository.GetSermon(id);
            sermon.Title = model.Title;
            sermon.PreacherId = model.Preacher;
            await _sermonRepository.UpdateAsync(sermon);
            await _sermonRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }

        public async Task<SermonsResponseModel> GetSermonsByPreacher(int id)
        {
            var sermons = await _sermonRepository.GetSermonsByPreacher(id);
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    MemberId = m.MemberId,
                    Member = m.Member,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<SermonsResponseModel> GetSermonsByTitle(string title)
        {
            var sermons = await _sermonRepository.GetSermonsByTitle(title);
            return new SermonsResponseModel
            {
                Data = sermons.Select(m => new SermonModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PreacherId = m.PreacherId,
                    Preacher = m.Preacher,
                    MemberId = m.MemberId,
                    Member = m.Member,
                    Audio = m.Audio,
                    Video = m.Video
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> DeleteSermon(int id)
        {
            var sermon = await _sermonRepository.GetSermon(id);
            await _sermonRepository.DeleteAsync(sermon);
            File.Delete($"C:\\Users\\dzumi\\source\\repos\\DaySpring\\DaySpring\\wwwroot\\SermonAudios\\{sermon.Audio}");
            File.Delete($"C:\\Users\\dzumi\\source\\repos\\DaySpring\\DaySpring\\wwwroot\\SermonVideos\\{sermon.Video}");
            await _sermonRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successful"
            };
        }
    }
}
