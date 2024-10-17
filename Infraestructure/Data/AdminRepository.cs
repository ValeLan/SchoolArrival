using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;

namespace Infraestructure.Data
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(TravelArrivalDbContext context) : base(context) { }

        public Admin? GetById(int id)
        {
            return _context.Admins.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEntity(int id, AdminSaveRequest entity)
        {
            var adminToUpdate = _context.Admins.FirstOrDefault(e => e.Id == id);

            if (adminToUpdate != null)
            {
                adminToUpdate.Name = entity.Name;
                adminToUpdate.Password = entity.Password;
                _context.SaveChanges();
            }
        }
    }
}
