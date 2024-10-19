using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public static DriverDto ToDto(Driver driver)
        {
            var dto = new DriverDto
            {
                Id = driver.Id,
                Name = driver.Name
            };

            return dto;
        }
        public static List<DriverDto> ToDto(List<Driver> drivers)
        {
            return drivers.Select(driver => ToDto(driver)).ToList();
        }
        public static Driver ToEntity(DriverSaveRequest dto)
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
