using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            var passengersDto = _context.Passengers
                .Select(p => new PassengerDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    District = new DistrictDto
                    {
                        Id = p.District.Id,
                        Name = p.District.Name,
                    },
                    School = new SchoolDto
                    {
                        Id = p.School.Id,
                        Name = p.School.Name
                    },
                    Travels = p.Travels.Select(e => TravelSaveRequest.ToDto(e)).ToList(),
                })
                .ToList();
            return passengersDto;
        }
        public Passenger? GetById(int id)
        {
            return _context.Passengers
                .Include(e => e.District)
                .Include(e => e.School)
                .Include (e => e.Travels)
                .ThenInclude(e => e.Driver)
                .FirstOrDefault(e => e.Id == id);
        }

        public List<Passenger> GetByIds(List<int> ids)
        {
            return _context.Passengers
                .Where(p => ids.Contains(p.Id))
                .ToList();
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
            return _context.Passengers.Where(e => e.School != null && e.School.Id == id).ToList();
        }

        public List<Passenger> GetByDistrict(int id)
        {
            return _context.Passengers.Where(e => e.District != null && e.District.Id == id).ToList();
        }

    }
}
