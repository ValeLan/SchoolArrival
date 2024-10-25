using ConsultaAlumnos.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(TravelArrivalDbContext context) : base(context) { }

        public async Task<User?> GetUserByUserEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
