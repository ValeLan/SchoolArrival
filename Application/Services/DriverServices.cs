using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;
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
        private readonly IRepositoryBase<Travel> _travelRepositoryBase;
        private readonly IRepositoryBase<Driver> _driverRepositoryBase;
        private readonly IDriverRepository _driverRepository;


        private readonly DriverMapping _mapping;
        public DriverServices(IRepositoryBase<Travel> travelRepositoryBase, IDriverRepository driverRepository, DriverMapping mapping, IRepositoryBase<Driver> driverRepositoryBase)
        {
            _travelRepositoryBase = travelRepositoryBase;
            _driverRepository = driverRepository;
            _mapping = mapping;
            _driverRepositoryBase = driverRepositoryBase;
        }

        public List<DriverDto> GetAll()
        {
            var response = _driverRepository.GetAll();
            var responseMapped = response.Select(e => _mapping.FromEntityToResponse(e)).ToList();
            return responseMapped;

        }

        //public DriverDto? GetById(int id)
        //{
        //    var driver = _driverRepository.Get().FirstOrDefault(a => a.Id == id);
        //    if (driver == null)
        //    {
        //        return null;
        //    }

        //    return DriverDto.ToDto(driver);
        //}

        public async Task<DriverDto> CreateDriverAsync(DriverSaveRequest driver)
        {
            var entity = _mapping.FromRequestToEntity(driver);
            var response = await _driverRepositoryBase.AddAsync(entity);

            return _mapping.FromEntityToResponse(response);
        }

        //public void UpdateDriver(int id, DriverSaveRequest driver)
        //{
        //    _driverRepository.UpdateEntity(id, driver);
        //}

        //public void DeleteDriver(int id)
        //{
        //    _driverRepository.Remove(id);
        //}
    }
}
