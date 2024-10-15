using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;

        public AdminServices(IAdminRepository adminRepository) 
        { 
            _adminRepository = adminRepository;
        }

        public List<Admin> GetAll()
        {
            return _adminRepository.Get();
        }

        public Admin? GetById(int id) 
        {
            var admin = _adminRepository.Get();

            return admin.FirstOrDefault (a => a.Id == id);
        }

        public 
    }
}
