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
    public interface IPassengerService
    {
        Task<List<PassengerDto>> GetAllAsync();
        Task<PassengerDto> GetAsync(int id);
        Task CreateAsync( PassengerSaveRequest request);

        Task<bool> UpdatePassengerAsync(int id, PassengerSaveRequest request);
        Task DeletePassengerAsync(int id);
        Passenger? Authenticate(string username, string password);
    }
}
