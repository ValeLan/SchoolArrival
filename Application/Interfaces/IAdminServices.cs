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
        Task<List<AdminDto>> GetAllAsync();
        Task<AdminDto> CreateAdminAsync(AdminSaveRequest adminDto);

    }
}
