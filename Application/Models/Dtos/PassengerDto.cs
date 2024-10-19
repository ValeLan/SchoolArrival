using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string StundentDNI { get; set; } = string.Empty;
        public string StudentAdress { get; set; } = string.Empty;
        public DateTime Hour { get; set; }

        public static PassengerDto ToDto(Passenger entity)
        {
            var dto = new PassengerDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                StundentDNI = entity.StundentDNI,
                StudentAdress = entity.StudentAdress,
                Hour = entity.Hour,
            };

            return dto;
        }

        public static List<PassengerDto> ToDto(List<Passenger> entity)
        {
            return entity.Select(Passenger => ToDto(Passenger)).ToList();
        }

        public static Passenger ToEntity(PassengerSaveRequest dto)
        {
            var entity = new Passenger
            {
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                StundentDNI= dto.StundentDNI,
                StudentAdress = dto.StudentAdress,
                Hour = dto.Hour,
            };

            return entity;
        }
    }
}
