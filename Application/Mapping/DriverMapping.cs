using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class DriverMapping
    {
        public DriverDto FromEntityToResponse(Driver driver)
        {
            var travelMapping = new TravelMapping();
            var dto = new DriverDto
            {
                Id = driver.Id,
                Name = driver.Name,
                Travels = driver.Travels.Select(t => travelMapping.FromEntityToResponse(t)).ToList(),
            };

            return dto;
        }
       
        public Driver FromRequestToEntity(DriverSaveRequest dto)
        {
            var driver = new Driver
            {
                Name = dto.Name,
                Password = dto.Password,
            };

            return driver;
        }
    }
}
