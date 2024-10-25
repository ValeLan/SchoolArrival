using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Domain.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class TravelServices : ITravelServices
    {
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly ITravelRepository _travelRepository;
        private readonly TravelMapping _travelMapping;

        public TravelServices(IRepositoryBase<Travel> travelRepositoryBase, TravelMapping TravelMapping, ITravelRepository travelRepository)
        {
            _travelMapping = TravelMapping;
            _travelRepositoryBase = travelRepositoryBase;
            _travelRepository = travelRepository;
        }

        public async Task<List<TravelDto>> GetAllAsync()
        {
            var response = await _travelRepository.GetAll();
            var responseMapped = response.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;
        }
        public async Task<TravelDto> GetAsync(int idTravel)
        {
            var response = await GetAllAsync();
            var newResponse = response.FirstOrDefault(e => e.Id == idTravel);
            return newResponse;

        }

        public async Task<TravelDto> CreateAsync(TravelSaveRequest travel)
        {
            var entity = _travelMapping.FromRequestToEntity(travel);
            var response = await _travelRepositoryBase.AddAsync(entity);
            var responseMapped = _travelMapping.FromEntityToResponse(response);
            
            return  responseMapped; 
        }


        public async Task<bool> UpdateTravelAsync(int idTravel, TravelSaveRequest request)
        {
            var entity = await _travelRepositoryBase.GetByIdAsync(idTravel);

            if (entity == null)
            {
                return false;
            }
            var entityUpdated = _travelMapping.FromEntityToEntityUpdated(entity, request);

            await _travelRepositoryBase.UpdateAsync(entityUpdated);

            return true;
        }


        public async Task DeleteAsync(int idTravel)
        {
            var response = await _travelRepositoryBase.GetByIdAsync(idTravel);
            await _travelRepositoryBase.DeleteAsync(response);
        }


    }
}
