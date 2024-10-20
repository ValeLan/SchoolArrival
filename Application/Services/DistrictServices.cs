using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DistrictServices : IDistrictServices
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IPassengerRepository _passengerRepository;

        public DistrictServices(IDistrictRepository repository, IPassengerRepository passengerRepository)
        {
            _districtRepository = repository;
            _passengerRepository = passengerRepository;
        }

        public List<District> GetAll()
        {
            return _districtRepository.Get();
        }

        public District? GetById(int id)
        {
            var district = _districtRepository.Get();

            return district.FirstOrDefault(a => a.Id == id);
        }

        public District CreateDistrict(District newDistrict)
        {
            newDistrict.Passengers = _passengerRepository.GetBySchool(newDistrict.Id);
            _districtRepository.Add(newDistrict);
            return newDistrict;
        }

        public void UpdateDistrict(int id, District newDistrict)
        {
            _districtRepository.UpdateEntity(id, newDistrict);
        }

        public void DeleteDistrict(int id)
        {
            _districtRepository.Remove(id);
        }
    }
}
