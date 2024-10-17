using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminServices
    {
        List<Admin> GetAll();
        Admin? GetById(int id);
        AdminDto CreateAdmin(AdminSaveRequest adminDto);
        void UpdateAdmin(int id, AdminSaveRequest adminDto);
        void DeleteAdmin(int id);

        
    }
}
