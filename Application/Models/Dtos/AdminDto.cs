using Application.Models.Requests;
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
        public string Name { get; set; } = string.Empty;
        public List<string> Districts { get; set; } = [];
        public List<SchoolDto> Schools { get; set; } = [];
        public static AdminDto ToDto(Admin admin)
        {
            var dto = new AdminDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Districts = admin.Districts.Select(d => d.Name).ToList(),
                Schools = admin.Schools.Select(s => new SchoolDto { Id = s.Id, Name = s.Name }).ToList()
            };

            return dto;
        }
        public static List<AdminDto> ToDtos(List<Admin> admins)
        {
            return admins.Select(admin => ToDto(admin)).ToList();
        }
        public static Admin ToEntity(AdminSaveRequest dto)
        {
            var admin = new Admin
            {
                Name = dto.Name,
                Password = dto.Password,
            };

            return admin;
        }
    }
}
