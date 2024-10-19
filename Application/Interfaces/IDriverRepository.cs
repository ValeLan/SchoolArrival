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
    public interface IDriverRepository : IRepositoryBase<Driver>
    {
        List<DriverDto> GetAll();
        Driver? GetById(int id);
        void UpdateEntity(int id, DriverSaveRequest entity);
    }
}
