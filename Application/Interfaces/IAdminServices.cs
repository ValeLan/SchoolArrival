using Application.Models.Dtos;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminServices
    {
        Task<bool> CreateUser(AdminRequest request);
        Task<List<AdminDto>> GetAllAdminsAsync();
        Task<AdminDto> GetAdminAsync(int idUser);
        Task DeleteAsync(int idUser);
        Task<bool> UpdateUserAsync(int idUser, AdminRequest request);
    }
}
