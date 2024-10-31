using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface ITravelServices
    {
        Task<List<TravelDto?>> GetHistoricalAsync();
        Task<List<TravelDto>> GetAllPendingAsync();
        Task<TravelDto> GetAsync(int idTravel);
        Task<List<TravelDto?>> GetAllCompletedAsync();
        Task<List<TravelDto?>> GetAllCanceledAsync();
        Task<bool> CreateAsync(TravelSaveRequest travel);
        Task<bool> UpdateTravelAsync(int idTravel, TravelSaveRequest request);

        Task<bool> CompleteTravel(int idTravel);
        Task<bool> DeleteAsync(int idTravel);
    }
}
