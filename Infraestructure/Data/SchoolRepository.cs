using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(TravelArrivalDbContext context) : base(context) { }

        public School? GetById(int id)
        {
            return _context.Schools.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEntity(int id, School entity)
        {
            var SchoolToUpdate = _context.Schools.FirstOrDefault(e => e.Id == id);

            if (SchoolToUpdate != null)
            {
                SchoolToUpdate.Name = entity.Name;
                _context.SaveChanges();
            }
        }
    }
}
