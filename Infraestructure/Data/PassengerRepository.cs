using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class PassengerRepository : RepositoryBase<Passenger>, IPassengerRepository
    {
        public PassengerRepository(TravelArrivalDbContext context) : base(context) { }

        public List<PassengerDto> GetAll()
        {
            var passengersDto = _context.Passengers.ToList();
            return PassengerDto.ToDto(passengersDto);
        }
        public Passenger? GetById(int id)
        {
            return _context.Passengers.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEntity(int id, PassengerSaveRequest entity)
        {
            var PassengerToUpdate = _context.Passengers.FirstOrDefault(e => e.Id == id);

            if (PassengerToUpdate != null)
            {
                PassengerToUpdate.Name = entity.Name;
                PassengerToUpdate.Password = entity.Password;
                PassengerToUpdate.PhoneNumber = entity.PhoneNumber;
                PassengerToUpdate.StundentDNI = entity.StundentDNI;
                PassengerToUpdate.StudentAdress = entity.StudentAdress;
                PassengerToUpdate.Hour = entity.Hour;
                _context.SaveChanges();
            }
        }

        public List<Passenger> GetBySchool(int id)
        {
            return _context.Passengers.Where(e => e.School.Id == id).ToList();
        }

    }
}
