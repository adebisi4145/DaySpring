using DaySpring.Dtos;
using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.ViewModels
{
    public class CreateAuthorRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string AuthorsImage { get; set; }

        public string Biography { get; set; }
    }

    public class UpdateAuthorRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Biography { get; set; }
    }

    public class AuthorResponseModel : BaseResponse
    {
        public AuthorModel Data { get; set; }
    }

    public class AuthorsResponseModel : BaseResponse
    {
        public List<AuthorModel> Data { get; set; }
    }
}
