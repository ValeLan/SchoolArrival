﻿using Application.Interfaces;
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
        public AdminServices(IRepositoryBase<Admin> adminRepositoryBase)
        {
            _adminRepositoryBase = adminRepositoryBase;
        }

        //public List<AdminDto> GetAll()
        //{
        //    return _adminRepository.GetAll();
        //}

        //public AdminDto? GetById(int id)
        //{
        //    var admin = _adminRepository.GetById(id);
        //    if (admin == null)
        //    {
        //        return null;
        //    }

        //    return AdminDto.ToDto(admin);
        //}

        //public AdminDto CreateAdmin(AdminSaveRequest adminDto)
        //{
        //    var entity = AdminDto.ToEntity(adminDto);
        //    entity.Districts = _districtRepository.GetByIds(adminDto.DistrictsIds);
        //    entity.Schools = _schoolRepository.GetByIds(adminDto.SchoolsIds);
        //    _adminRepository.Add(entity);
        //    return AdminDto.ToDto(entity);
        //}

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
