using DaySpring.Models;
using DaySpring.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Interfaces.Services
{
    public interface IAuthorService
    {
        public Task<BaseResponse> CreateAuthor(CreateAuthorRequestModel model);

        public Task<BaseResponse> UpdateAuthor(int id, UpdateAuthorRequestModel model);

        public Task<BaseResponse> DeleteAuthor(int id);

        public Task<AuthorResponseModel> GetAuthor(int id);

        public Task<AuthorsResponseModel> GetAuthors();
    }
}
