using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class SchoolRepository : EfRepository<School>, ISchoolRepository
    {
        public SchoolRepository(TravelArrivalDbContext context) : base(context) { }

        //public List<School> GetAll()
        //{
        //    return _context.Schools
        //        .Include(e => e.Passengers)
        //        .ToList();
        //}
        //public School? GetById(int id)
        //{
        //    return _context.Schools
        //        .Include(e => e.Passengers)
        //        .FirstOrDefault(e => e.Id == id);
        //}

        //public void UpdateEntity(int id, School entity)
        //{
        //    var SchoolToUpdate = _context.Schools.FirstOrDefault(e => e.Id == id);

        //    if (SchoolToUpdate != null)
        //    {
        //        SchoolToUpdate.Name = entity.Name;
        //        _context.SaveChanges();
        //    }
        //}

        //public List<School> GetByIds(List<int> ids)
        //{
        //    return _context.Schools.Where(e => ids.Contains(e.Id)).ToList();
        //}

    }
}
