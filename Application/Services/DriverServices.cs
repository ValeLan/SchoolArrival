using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Models;
using SchoolArrival.Domain.Interfaces;

namespace Application.Services
{
    public class DriverServices : IDriverServices
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly DriverMapping _userMapping;
        private readonly ITravelRepository _travelRepository;
        private readonly TravelMapping _travelMapping;
        public DriverServices(IRepositoryBase<User> userRepositoryBase, TravelMapping travelMapping, DriverMapping userMapping, ITravelRepository travelRepository, IRepositoryBase<Travel> travelRepositoryBase)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
            _travelRepository = travelRepository;
            _travelMapping = travelMapping;
            _travelRepositoryBase = travelRepositoryBase;
        
        }   

        public async Task<List<DriverDto?>> GetAllDriversAsync()
        {
            var response = await _userRepositoryBase.ListAsync();
            var filteredResponse = response
                .Where(e => e.Role == Domain.Enums.Role.Driver && e.IsActive)
                .ToList();
            var responseMapped = filteredResponse
                .Select(e => _userMapping.FromEntityToResponse(e))
                .ToList();
            return responseMapped;
        }

        public async Task<List<TravelDto?>> GetMyTravelsAsync(int idDriver)
        {
            var response = await _travelRepository.GetAll();
            var filteredResponse = response.Where(e => e.DriverId == idDriver).ToList();
            if (filteredResponse == null)
            {
                return null;
            }
            var responseMapped = filteredResponse.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;
        }

        public async Task<DriverDto?> GetDriverAsync(int idUser)
        {
            var response = await GetAllDriversAsync();
            var newResponse = response.FirstOrDefault(e => e.Id == idUser);
            if (newResponse != null)
            {
                return newResponse;
            }
            else
            {
                return null;
            }


        }

        public async Task<bool> CreateUser(DriverRequest request)
        {
            var entity = _userMapping.FromRequestToEntity(request);
            await _userRepositoryBase.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateUserAsync(int idUser, DriverRequest request)
        {
            var entity = await _userRepositoryBase.GetByIdAsync(idUser);

            if (entity == null)
            {
                return false;
            }
            var entityUpdated = _userMapping.FromEntityToEntityUpdated(entity, request);

            await _userRepositoryBase.UpdateAsync(entityUpdated);

            return true;
        }

        public async Task DeleteAsync(int idUser)
        {
            var myTravels = await _travelRepository.GetAll();
            var filteredResponse = myTravels.Where(e => e.DriverId == idUser).ToList();
            foreach (var travel in filteredResponse)
            {
                travel.State = TravelState.Demorado;
                travel.DriverId = null; 
            }
            await _travelRepositoryBase.SaveChangesAsync();
            var response = await _userRepositoryBase.GetByIdAsync(idUser);
            await _userRepositoryBase.DeleteAsync(response);
            
        }
    }
}
