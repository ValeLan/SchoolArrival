using Domain.Entities;
using System.Linq;

namespace Infraestructure.Data
{
    public class AdminRepository : RepositoryBase<Admin>
    {
        private readonly TravelArrivalDbContext _context;
        public AdminRepository(TravelArrivalDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
