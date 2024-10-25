using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateUser(UserRequest request);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(int idUser);
        Task DeleteAsync(int idUser);
    }
}
