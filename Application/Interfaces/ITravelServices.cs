using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface ITravelServices
    {
        Task<List<TravelDto>> GetAllAsync();
        Task<TravelDto> GetAsync(int idTravel);
        Task<bool> CreateAsync(TravelSaveRequest travel);
        Task<bool> UpdateTravelAsync(int idTravel, TravelSaveRequest request);

        Task<bool> CompleteTravel(int idTravel);
        Task<bool> DeleteAsync(int idTravel);
    }
}
