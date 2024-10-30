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
    public class DriverMapping
    {
        public User FromRequestToEntity(DriverRequest dto)
        {
            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                DNI = dto.DNI,
                IsActive = true,
                Role = Role.Driver,
            };

            return user;
        }

        public DriverDto FromEntityToResponse(User dto)
        {
            var request = new DriverDto
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

        public User FromEntityToEntityUpdated(User user, DriverRequest userRequest)
        {
            user.FullName = userRequest.FullName ?? user.FullName;
            user.Email = userRequest.Email ?? user.Email;
            user.PhoneNumber = userRequest.PhoneNumber ?? user.PhoneNumber;
            return user;
        }
    }
}
