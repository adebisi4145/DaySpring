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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<BaseResponse> CreateAuthor(CreateAuthorRequestModel model)
        {
            var authors = await _authorRepository.GetAllAsync();
            
            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AuthorsImage = model.AuthorsImage,
                Biography = model.Biography
            };
            if (authors.Contains(author))
            {
                return new BaseResponse
                {
                    Status = true,
                    Message = "Author already exist"
                };
            }
          await _authorRepository.AddAsync(author);
           await _authorRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public async Task<AuthorResponseModel> GetAuthor(int id)
        {
            var author = await _authorRepository.GetAsync(id);
            return new AuthorResponseModel
            {
                Data = new AuthorModel
                {
                    Id = id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    AuthorsImage = author.AuthorsImage,
                    Biography = author.Biography
                },
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<AuthorsResponseModel> GetAuthors()
        {
            var author = await _authorRepository.GetAllAsync();
            return new AuthorsResponseModel
            {
                Data = author.Select(m => new AuthorModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    AuthorsImage = m.AuthorsImage,
                    Biography = m.Biography
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<AuthorsResponseModel> GetAuthorsByName(string name)
        {
            var author = await _authorRepository.GetAuthorsByName(name);
            return new AuthorsResponseModel
            {
                Data = author.Select(m => new AuthorModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    AuthorsImage = m.AuthorsImage,
                    Biography = m.Biography
                }).ToList(),
                Status = true,
                Message = "successful"
            };
        }

        public async Task<BaseResponse> UpdateAuthor(int id, UpdateAuthorRequestModel model)
        {
            var author = await _authorRepository.GetAsync(id);
            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.Biography = model.Biography;
            await _authorRepository.UpdateAsync(author);
            await _authorRepository.SaveChangesAsync();
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
