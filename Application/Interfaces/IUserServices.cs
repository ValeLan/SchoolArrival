using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateUser(UserRequest request);
    }
}
