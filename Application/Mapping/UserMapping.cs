using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;

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

        public User FromEntityToEntityUpdated(User user, UserRequest userRequest)
        {
            user.FullName = userRequest.FullName ?? user.FullName;
            user.Password = userRequest.Password ?? user.Password;
            user.Email = userRequest.Email ?? user.Email;
            user.Role = userRequest.Role; //no me deja poner ToString() por ser enum.

            return user;
        }

    }
}
