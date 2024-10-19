using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PassengerServices : IPassengerService
    {
        private readonly IPassengerRepository _repository;

        public PassengerServices(IPassengerRepository repository)
        {
            _repository = repository;
        }

        public List<PassengerDto> GetAll()
        {
            return _repository.GetAll();
        }

        public PassengerDto? GetById(int id)
        {
            var entity = _repository.Get().FirstOrDefault(a => a.Id == id);
            if (entity == null)
            {
                return null;
            }

            return PassengerDto.ToDto(entity);
        }

        public PassengerDto CreatePassenger(PassengerSaveRequest dto)
        {
            var entity = PassengerDto.ToEntity(dto);

            _repository.Add(entity);
            return PassengerDto.ToDto(entity);
        }

        public void UpdatePassenger(int id, PassengerSaveRequest adminDto)
        {
            _repository.UpdateEntity(id, adminDto);
        }

        public void DeletePassenger(int id)
        {
            _repository.Remove(id);
        }
    }
}
