using Application.Interfaces;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace Infraestructure.Data
{
    public class DriverRepository : EfRepository<User>, IDriverRepository
    {
        public DriverRepository(TravelArrivalDbContext context) : base(context) { }

        public List<User> GetAll()
        {
            var dto = _context.Users
                .ToList();
           
            return dto.Where(e => e.Role == Role.Driver).ToList();
        }
    }
}
