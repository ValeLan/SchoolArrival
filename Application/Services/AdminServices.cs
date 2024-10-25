using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
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
        private readonly IRepositoryBase<Admin> _adminRepositoryBase;
        private readonly AdminMapping _adminMapping;
        public AdminServices(IRepositoryBase<Admin> adminRepositoryBase, AdminMapping adminMapping)
        {
            _adminRepositoryBase = adminRepositoryBase;
            _adminMapping = adminMapping;
        }

        public async Task<List<AdminDto>> GetAllAsync()
        {
            var response = await _adminRepositoryBase.ListAsync();
            return response.Select(e => _adminMapping.FromEntityToResponse(e)).ToList();

        }

        //public AdminDto? GetById(int id)
        //{
        //    var admin = _adminRepository.GetById(id);
        //    if (admin == null)
        //    {
        //        return null;
        //    }
        //    return AdminDto.ToDto(admin);
        //}

        public async Task<AdminDto> CreateAdminAsync(AdminSaveRequest adminDto)
        {
            var entity = _adminMapping.FromRequestToEntity(adminDto);
            var response = await _adminRepositoryBase.AddAsync(entity);

            return _adminMapping.FromEntityToResponse(response);

        }

        //public void UpdateAdmin(int id, AdminSaveRequest adminDto)
        //{
        //    _adminRepository.UpdateEntity(id, adminDto);
        //}

        //public void DeleteAdmin(int id)
        //{
        //    _adminRepository.Remove(id);
        //}
    }
}
