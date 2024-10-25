using Application.Interfaces;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class DriverRepository : EfRepository<Driver>, IDriverRepository
    {
        public DriverRepository(TravelArrivalDbContext context) : base(context) { }

        public List<Driver> GetAll()
        {
            var dto = _context.Drivers
                .Include(e => e.Travels)
                .ToList();

            return dto;
        }
        //public Driver? GetById(int id)
        //{
        //    return _context.Drivers
        //        .Include(a => a.Travels)
        //        .ThenInclude(t => t.Passengers)
        //        .FirstOrDefault(e => e.Id == id);
        //}

        //public void UpdateEntity(int id, DriverSaveRequest entity)
        //{
        //    var DriverToUpdate = _context.Drivers.FirstOrDefault(e => e.Id == id);

        //    if (DriverToUpdate != null)
        //    {
        //        DriverToUpdate.Name = entity.Name;
        //        DriverToUpdate.Password = entity.Password;
        //        DriverToUpdate.Travels = _context.Travels.Where( e => e.Driver.Id == DriverToUpdate.Id ).ToList();
        //        _context.SaveChanges();
        //    }
        //}
    }
}
