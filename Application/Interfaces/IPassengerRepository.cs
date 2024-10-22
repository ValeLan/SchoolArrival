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

        List<Passenger> GetByIds(List<int> ids);

        void UpdateEntity(int id, PassengerSaveRequest entity);

        List<Passenger> GetBySchool(int id);
        List<Passenger> GetByDistrict(int id);
    }
}
