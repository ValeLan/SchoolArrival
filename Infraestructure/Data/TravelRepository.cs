using Application.Interfaces;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace Infraestructure.Data
{
    public class TravelRepository : EfRepository<Travel>, ITravelRepository
    {
        public TravelRepository(TravelArrivalDbContext context) : base(context) { }
        
        public async Task<Travel?> GetById(int id)
        {
            return await _context.Travels
                .Include(e => e.School)
                .Include(e => e.Passengers)
                .Include(e => e.Driver)
                .Where(t => t.Driver.Role == Role.Driver)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Travel>> GetAll()
        {
            return await _context.Travels
                .Include(e => e.School)
                .Include(e => e.Passengers)
                .Include (e => e.Driver)
                //.Where(t => t.Driver.Role == Role.Driver)
                .ToListAsync();
        }
    }
}
