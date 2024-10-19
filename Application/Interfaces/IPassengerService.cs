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
        PassengerDto? GetById(int id);
        PassengerDto CreatePassenger(PassengerSaveRequest dto);
        void UpdatePassenger(int id, PassengerSaveRequest adminDto);
        void DeletePassenger(int id);

    }
}
