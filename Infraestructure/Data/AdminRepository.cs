using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using SchoolArrival.Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infraestructure.Data
{
    public class AdminRepository : EfRepository<Admin>, IAdminRepository
    {
        public AdminRepository(TravelArrivalDbContext context) : base(context) { }

        //public List<AdminDto> GetAll()
        //{
        //    var dto = _context.Admins
        //        .Include(a => a.Districts)
        //        .Include(a => a.Schools)
        //        .ToList();

        //    return AdminDto.ToDtos(dto);
        //}

        //public Admin? GetById(int id)
        //{
        //    var dto = _context.Admins
        //        .Include(a => a.Districts)
        //        .ThenInclude(e => e.Passengers)
        //        .FirstOrDefault(a => a.Id == id);
        //    dto = _context.Admins.Include(m => m.Schools).FirstOrDefault(a => a.Id == id);
        //    return dto;
        //}
        //public void UpdateEntity(int id, AdminSaveRequest entity)
        //{
        //    var adminToUpdate = _context.Admins.FirstOrDefault(e => e.Id == id);

        //    if (adminToUpdate != null)
        //    {
        //        adminToUpdate.Name = entity.Name;
        //        adminToUpdate.Password = entity.Password;
        //        adminToUpdate.Schools = _context.Schools.Where(e => entity.SchoolsIds.Contains(e.Id)).ToList();
        //        adminToUpdate.Districts = _context.Districts.Where(e => entity.DistrictsIds.Contains(e.Id)).ToList();
        //        _context.SaveChanges();
        //    }
        //}
    }
}
