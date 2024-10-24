using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PassengerServices : IPassengerService
    {
        private readonly IRepositoryBase<Passenger> _passengerRepositoryBase;
        private readonly IPassengerRepository _passengerRepository;
        private readonly PassengerMapping _passengerMapping;
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;

        public PassengerServices(IRepositoryBase<Passenger> passengerRepositoryBase, IPassengerRepository passengerRepository, PassengerMapping passengerMapping, IRepositoryBase<Travel> travelRepositoryBase)
        {
            _passengerRepositoryBase = passengerRepositoryBase;
            _passengerRepository = passengerRepository;
            _passengerMapping = passengerMapping;
            _travelRepositoryBase = travelRepositoryBase;
        }

        public async Task<List<PassengerDto>> GetAllAsync()
        {
            var response = await _passengerRepositoryBase.ListAsync();
            var responseMapped = response.Select(e => _passengerMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;

        }

        public async Task<PassengerDto> GetAsync(int id)
        {
            var response = await _passengerRepositoryBase.GetByIdAsync(id);
            var responseMap = _passengerMapping.FromEntityToResponse(response);  
            return responseMap;
        }
        public async Task CreateAsync(PassengerSaveRequest request)
        {
            var entity = _passengerMapping.FromRequestToEntity(request);
            var response = await _passengerRepositoryBase.AddAsync(entity);
        }

        public async Task<bool> UpdatePassengerAsync(int idPassenger, PassengerSaveRequest request)
        {
            var entity = await _passengerRepositoryBase.GetByIdAsync(idPassenger);

            if (entity == null) 
            { 
                return false;
            }
            var entityUpdated = _passengerMapping.FromEntityToEntityUpdated(entity, request);

            await _passengerRepositoryBase.UpdateAsync(entityUpdated);

            return true;
        }

        public async Task DeletePassengerAsync(int id)
        {
            var entity = await _passengerRepositoryBase.GetByIdAsync(id);
            await _passengerRepositoryBase.DeleteAsync(entity);
        }
    }
}
