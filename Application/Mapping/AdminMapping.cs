using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AdminMapping
    {
        public User FromRequestToEntity(AdminRequest dto)
        {
            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                DNI = dto.DNI,
                IsActive = true,
                Role = Role.Admin,
            };

            return user;
        }

        public AdminDto FromEntityToResponse(User dto)
        {
            var request = new AdminDto
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                DNI = dto.DNI,
                Role = dto.Role.ToString(),
            };
            return request;
        }

        public User FromEntityToEntityUpdated(User user, AdminRequest userRequest)
        {
            user.FullName = userRequest.FullName ?? user.FullName;
            user.Email = userRequest.Email ?? user.Email;
            user.PhoneNumber = userRequest.PhoneNumber ?? user.PhoneNumber;            
            return user;
        }
    }
}
