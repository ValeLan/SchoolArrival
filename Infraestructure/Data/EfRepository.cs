using Infraestructure.Data;
using SchoolArrival.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolArrival.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T> where T : class
{
    protected readonly TravelArrivalDbContext _context;
    public EfRepository(TravelArrivalDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}
