using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Interfaces;
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

        private readonly ITravelRepository _travelRepository;
        public DriverServices(IDriverRepository driverRepository, ITravelRepository travelRepository)
        {
            _driverRepository = driverRepository;
            _travelRepository = travelRepository;
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
            _driverRepository.UpdateEntity(entity.Id, driver);
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
