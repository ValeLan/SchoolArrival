using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;

namespace Application.Mapping
{
    public class UserMapping
    {
        public User FromRequestToEntity(UserRequest dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Password = dto.Password,
                Email = dto.Email,
                Role = dto.Role,
            };

            return user;
        }

        public UserDto FromEntityToResponse(User dto) 
        {
            var request = new UserDto
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DNI = dto.DNI,
                Role = dto.Role.ToString(),
                District = dto.District.ToString(),
                
            };
            return request;
        }

    }
}
