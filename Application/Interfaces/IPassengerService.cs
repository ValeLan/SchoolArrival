using Application.Models.Dtos;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPassengerService
    {
        List<PassengerDto> GetAll();
        Task<PassengerDto> GetAsync(int id);
        Task CreateAsync( PassengerSaveRequest request);

        Task UpdatePassengerAsync(int id, PassengerSaveRequest request);
        Task DeletePassengerAsync(int id);
    }
}
