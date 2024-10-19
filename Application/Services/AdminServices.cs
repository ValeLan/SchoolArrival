using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
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

        public List<AdminDto> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public AdminDto? GetById(int id) 
        {
            var admin = _adminRepository.Get().FirstOrDefault(a => a.Id == id);
            if (admin == null)
            {
                return null;
            }

            return AdminDto.ToDto(admin);
        }

        public AdminDto CreateAdmin(AdminSaveRequest adminDto) 
        {
            var entity = AdminDto.ToEntity(adminDto);

            _adminRepository.Add(entity);
            return AdminDto.ToDto(entity);
        }

        public void UpdateAdmin(int id, AdminSaveRequest adminDto)
        {
            _adminRepository.UpdateEntity(id, adminDto);
        }

        public void DeleteAdmin(int id) 
        { 
            _adminRepository.Remove(id);
        }
    }
}
