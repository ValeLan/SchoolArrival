using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SchoolServices : ISchoolServices
    {
        private readonly ISchoolRepository _repository;
        private readonly IPassengerRepository _passengerRepository;

        public SchoolServices(ISchoolRepository repository, IPassengerRepository passengerRepository)
        {  
           _repository = repository; 
           _passengerRepository = passengerRepository;
        }

        public List<School> GetAll()
        {
            return _repository.GetAll();
        }

        public School? GetById(int id)
        {
            var district = _repository.Get();

            return district.FirstOrDefault(a => a.Id == id);
        }

        public School CreateSchool(School newSchool)
        {
            newSchool.Passengers = _passengerRepository.GetBySchool(newSchool.Id);
            _repository.Add(newSchool);
            return newSchool;
        }

        public void UpdateSchool(int id, School newSchool)
        {
            _repository.UpdateEntity(id, newSchool);
        }

        public void DeleteSchool(int id)
        {
            _repository.Remove(id);
        }
    }
}
