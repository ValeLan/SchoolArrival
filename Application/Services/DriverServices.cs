using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DriverServices : IDriverServices
    {
        private readonly IDriverRepository _driverRepository;
        public DriverServices(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public List<DriverDto> GetAll()
        {
            return _driverRepository.GetAll();
        }

        public DriverDto? GetById(int id)
        {
            var driver = _driverRepository.Get().FirstOrDefault(a => a.Id == id);
            if (driver == null)
            {
                return null;
            }

            return DriverDto.ToDto(driver);
        }

        public DriverDto CreateDriver(DriverSaveRequest driver)
        {
            var entity = DriverDto.ToEntity(driver);

            _driverRepository.Add(entity);
            return DriverDto.ToDto(entity);
        }

        public void UpdateDriver(int id, DriverSaveRequest driver)
        {
            _driverRepository.UpdateEntity(id, driver);
        }

        public void DeleteDriver(int id)
        {
            _driverRepository.Remove(id);
        }
    }
}
