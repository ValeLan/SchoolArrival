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

        public List<PassengerDto> GetAll()
        {
            var response = _passengerRepository.GetAll();
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
            var client = new Passenger();
            client.FullName = request.FullName;
            client.PhoneNumber = request.PhoneNumber;
            client.StudentDNI = request.StundentDNI;
            client.StudentAdress = request.StudentAdress;
            client.DistrictId = request.DistrictId;
            client.SchoolId = request.SchoolId;
            client.ClientId = request.ClientId;
            client.Travels = [];
                foreach(int id in request.TravelIds)
                {
                    var travel = await _travelRepositoryBase.GetByIdAsync(id);
                    client.Travels.Add(travel);
                }
            var response = await _passengerRepositoryBase.AddAsync(client);
        }

        public async Task UpdatePassengerAsync(int id, PassengerSaveRequest request)
        {
            var entity = await _passengerRepositoryBase.GetByIdAsync(id);

            entity.FullName = request.FullName;
            entity.StudentDNI = request.StundentDNI;
            entity.StudentAdress = request.StudentAdress;
            await _passengerRepositoryBase.UpdateAsync(entity);
        }

        public async Task DeletePassengerAsync(int id)
        {
            var entity = await _passengerRepositoryBase.GetByIdAsync(id);
            await _passengerRepositoryBase.DeleteAsync(entity);
        }
    }
}
