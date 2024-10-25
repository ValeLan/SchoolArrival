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
    }
}
