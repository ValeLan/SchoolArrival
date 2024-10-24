using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class SchoolMapping
    {
        PassengerMapping passengersMapped = new PassengerMapping();
        public School FromRequestToEntity(SchoolSaveRequest dto)
        {
            var school = new School
            {
                Name = dto.Name
            };
            return school;
        }

        public SchoolDto FromEntityToResponse(School school)
        {
            var dto = new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                Passengers = school.Passengers.Select(e => passengersMapped.FromEntityToResponse(e)).ToList()

            };
            return dto;
        }
    }
}
