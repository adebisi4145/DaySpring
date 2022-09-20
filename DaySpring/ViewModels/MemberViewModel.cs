using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateMemberRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class UpdateMemberRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UpdateMemberPasswordRequestModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class MemberResponseModel : BaseResponse
    {
        public MemberModel Data { get; set; }
    }
    public class MembersResponseModel : BaseResponse
    {
        public List<MemberModel> Data { get; set; }
    }
}
