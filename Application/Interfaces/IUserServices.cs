using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateUser(PassengerRequest request);
        Task<List<PassengerDto>> GetAllPassengersAsync();
        Task<PassengerDto> GetPassengerAsync(int idUser);
        Task<TravelDto?> GetMyTravelAsync(int idClaim);
        Task DeleteAsync(int idUser);
        Task<bool> UpdateUserAsync(int idUser, PassengerRequest request);
        Task<bool> BloquedAsync(int idUser);
        Task<bool> UnBlockedAsync(int idUser);
        Task SignToTravel(int idUser, int idTravel);
        Task DropTravel(int idUser, int idTravel);

    }
}
