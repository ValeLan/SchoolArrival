using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface ITravelServices
    {
        Task<List<TravelDto>> GetAllAsync();
        Task<TravelDto> GetAsync(int idTravel);
        Task<TravelDto> CreateAsync(TravelSaveRequest travel);
        Task<bool> UpdateTravelAsync(int idTravel, TravelSaveRequest request);
        Task DeleteAsync(int idTravel);
    }
}
