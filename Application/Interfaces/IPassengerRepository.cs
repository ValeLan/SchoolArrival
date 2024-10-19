using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPassengerRepository : IRepositoryBase<Passenger>
    {
        List<PassengerDto> GetAll();
        Passenger? GetById(int id);

        void UpdateEntity(int id, PassengerSaveRequest entity);
    }
}
