using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AdminMapping
    {
        public AdminDto FromEntityToResponse(Admin admin)
        {

            var dto = new AdminDto
            {
                Id = admin.Id,
                FullName = admin.FullName

            };

            return dto;
        }

        public Admin FromRequestToEntity(AdminSaveRequest dto)
        {
            var admin = new Admin
            {
                FullName = dto.FullName,
                Password = dto.Password,
            };

            return admin;
        }
    }
}
