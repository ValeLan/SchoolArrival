using Application.Models.Dtos;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDriverServices
    {
        Task<bool> CreateUser(DriverRequest request);
        Task<List<DriverDto>> GetAllDriversAsync();
        Task<DriverDto> GetDriverAsync(int idUser);
        Task DeleteAsync(int idUser);
        Task<bool> UpdateUserAsync(int idUser, DriverRequest request);
        Task<List<TravelDto?>> GetMyTravelsAsync(int idClaim);
    }
}
