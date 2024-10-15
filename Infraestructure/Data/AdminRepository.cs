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

        public List<string> GetDistricts()
        {
            var districts = _context.Admins.ToList();

            return districts.District;
        }
        public void AddDistrict(string district)
        {

        }
        public List<string> GetSchools()
        {

        }
        public void AddSchool(string school)
        {

        }
    }
}
