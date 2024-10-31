using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Domain.Interfaces;
using Domain.Entities;
using Domain.Enums;
using System.Diagnostics;
using Domain.Models;

namespace Application.Services
{
    public class TravelServices : ITravelServices
    {
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly IRepositoryBase<School> _schoolRepositoryBase;
        private readonly IDriverRepository _driverRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly TravelMapping _travelMapping;

        public TravelServices(IRepositoryBase<Travel> travelRepositoryBase, TravelMapping TravelMapping, ITravelRepository travelRepository, IDriverRepository userRepositoryBase, IRepositoryBase<School> schoolRepositoryBase)
        {
            _travelMapping = TravelMapping;
            _travelRepositoryBase = travelRepositoryBase;
            _travelRepository = travelRepository;
            _driverRepository = userRepositoryBase;
            _schoolRepositoryBase = schoolRepositoryBase;
        }
        public async Task<List<TravelDto?>> GetHistoricalAsync()
        {
            var response = await _travelRepository.GetAll();
            if (response == null)
            {
                return null;
            }
            var responseMapped = response.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();

            return responseMapped;
        }

        public async Task<List<TravelDto?>> GetAllPendingAsync()
        {
            var response = await _travelRepository.GetAll();
            if (response == null) 
            {
                return null;
            }
            var responsePending = response.Where(e => e.State == TravelState.EnProceso);
            var responseMapped = responsePending.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();
            
            return responseMapped;
        }
        public async Task<TravelDto?> GetAsync(int idTravel)
        {
            var response = await GetHistoricalAsync();
            if (response == null)
            {
                return null;
            }
            var newResponse = response.FirstOrDefault(e => e.Id == idTravel);
            return newResponse;

        }
        public async Task<List<TravelDto?>> GetAllCompletedAsync()
        {
            var response = await _travelRepository.GetAll();
            if (response == null)
            {
                return null;
            }
            var responsePending = response.Where(e => e.State == TravelState.Completado);
            var responseMapped = responsePending.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();

            return responseMapped;
        }
        public async Task<List<TravelDto?>> GetAllCanceledAsync()
        {
            var response = await _travelRepository.GetAll();
            if (response == null)
            {
                return null;
            }
            var responsePending = response.Where(e => e.State == TravelState.Cancelado);
            var responseMapped = responsePending.Select(e => _travelMapping.FromEntityToResponse(e)).ToList();

            return responseMapped;
        }
        public async Task<bool> CreateAsync(TravelSaveRequest travel)
        {
            var driver = _driverRepository.GetAll();
            var school = await _schoolRepositoryBase.ListAsync();
            if (driver.Any(e => e.Id == travel.DriverId) && school.Any(e => e.Id == travel.SchoolId))
            {
                var entity = _travelMapping.FromRequestToEntity(travel);

                var response = await _travelRepositoryBase.AddAsync(entity);
                return true;
            }

            return false;
        }


        public async Task<bool> UpdateTravelAsync(int idTravel, TravelSaveRequest request)
        {
            var entity = await _travelRepositoryBase.GetByIdAsync(idTravel);
            var driver = _driverRepository.GetAll();
            var school = await _schoolRepositoryBase.ListAsync();
            
            if (entity == null)
            {
                return false;
            }
            if (driver.Any(e => e.Id == request.DriverId) && school.Any(e => e.Id == request.SchoolId))
            {
                var entityUpdated = _travelMapping.FromEntityToEntityUpdated(entity, request);

                await _travelRepositoryBase.UpdateAsync(entityUpdated);

                return true;
            }
            throw new Exception("Debe ingresar un chofer y una escuela válidos.");
        }

        public async Task<bool> CompleteTravel(int idTravel)
        {
            var response = await _travelRepositoryBase.GetByIdAsync(idTravel);

            if (response == null)
            {
                return false;
            }
            _travelMapping.CompleteTravel(response);
            await _travelRepositoryBase.UpdateAsync(response);
            return true;
        }

        public async Task<bool> DeleteAsync(int idTravel)
        {
            var response = await _travelRepositoryBase.GetByIdAsync(idTravel);
            if (response == null)
            {
                return false;
            }
            response.State = TravelState.Cancelado;
            await _travelRepositoryBase.UpdateAsync(response);
            return true;
        }


    }
}
