using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    internal class SchoolRepository : RepositoryBase<School>
    {
        private readonly TravelArrivalDbContext _context;
        public SchoolRepository(TravelArrivalDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
