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
    }
}
