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
        List<DriverDto> GetAll();
        DriverDto? GetById(int id);
        DriverDto CreateDriver(DriverSaveRequest driver);
        void UpdateDriver(int id, DriverSaveRequest driver);
        void DeleteDriver(int id);
    }
}
