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

        public DistrictServices(IDistrictRepository repository)
        {
            _districtRepository = repository;
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
            var entity = new District
            {
                Name = newDistrict.Name,
            };

            _districtRepository.Add(entity);
            return entity;
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
