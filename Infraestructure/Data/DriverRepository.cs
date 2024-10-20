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

namespace Infraestructure.Data
{
    public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(TravelArrivalDbContext context) : base(context) { }

        public List<DriverDto> GetAll()
        {
            var dto = _context.Drivers.ToList();

            return DriverDto.ToDto(dto);
        }
        public Driver? GetById(int id)
        {
            return _context.Drivers.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEntity(int id, DriverSaveRequest entity)
        {
            var DriverToUpdate = _context.Drivers.FirstOrDefault(e => e.Id == id);

            if (DriverToUpdate != null)
            {
                DriverToUpdate.Name = entity.Name;
                DriverToUpdate.Password = entity.Password;
                DriverToUpdate.Travels = _context.Travels.Where( e => e.Driver.Id == DriverToUpdate.Id ).ToList();
                _context.SaveChanges();
            }
        }
    }
}
