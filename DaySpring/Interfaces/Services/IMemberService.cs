using DaySpring.Dtos;
using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IMemberService
    {
        public Task<MemberModel> GetMemberByEmail(string email);

        public Task<MemberResponseModel> GetMember(int id);
        public Task<MembersResponseModel> GetMinisters();

        public Task<BaseResponse> CreateMember(CreateMemberRequestModel model);

        public Task<BaseResponse> UpdateMember(int id, UpdateMemberRequestModel model);

        public Task<MembersResponseModel> GetAllMembers();

        public Task<BaseResponse> DeleteMember(int id);

        public Task<BaseResponse> UpdateMemberPassword(int id, UpdateMemberPasswordRequestModel model);

        public Task<BaseResponse> UpdateMembershipStatusToMinister(int id);

        public Task<BaseResponse> UpdateMembershipStatusToMedia(int id);

        public Task<BaseResponse> RemoveMediaRole(int id);
        public Task<BaseResponse> RemoveMinisterRole(int id);
        public Task<MemberModel> GetMemberById(int id);
    }
}
