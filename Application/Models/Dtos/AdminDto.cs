using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static AdminDto ToDto(Admin admin)
        {
            var dto = new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name
            };

            return dto;
        }

        public static List<AdminDto> ToDto(List<Admin> admins)
        {
            return admins.Select(admin => ToDto(admin)).ToList();
        }
        public static Admin ToEntity(AdminDto dto)
        {
            var admin = new Admin
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return admin;
        }
    }
}
