using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class DistrictRepository : RepositoryBase<District>
    {
        private readonly TravelArrivalDbContext _context;
        public DistrictRepository(TravelArrivalDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
