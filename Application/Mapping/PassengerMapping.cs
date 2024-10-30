using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mapping
{
    public class PassengerMapping
    {
        public User FromRequestToEntity(PassengerRequest dto)
        {
            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password,      
                PhoneNumber = dto.PhoneNumber,
                DNI = dto.DNI,
                IsActive = true,
                District = dto.District,
                Role = Role.Passenger,
            };

            return user;
        }

        public PassengerDto FromEntityToResponse(User dto) 
        {
            var request = new PassengerDto
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

        public User FromEntityToEntityUpdated(User user, PassengerRequest userRequest)
        {
            user.FullName = userRequest.FullName ?? user.FullName;
            user.Email = userRequest.Email ?? user.Email;
            user.PhoneNumber = userRequest.PhoneNumber ?? user.PhoneNumber;
            if (userRequest.District.HasValue)
            {
                user.District = userRequest.District.Value;
            }
            return user;
        }

    }
}
