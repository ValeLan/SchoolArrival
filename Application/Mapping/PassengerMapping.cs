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
    public class PassengerMapping
    {
        public PassengerDto FromEntityToResponse(Passenger passenger)
        {
            var dto = new PassengerDto
            {
                Id = passenger.Id,
                FullName = passenger.FullName,
                PhoneNumber = passenger.PhoneNumber,
                StudentDNI = passenger.StudentDNI,
                StudentAdress = passenger.StudentAdress,
            };

            return dto;
        }

        public Passenger FromRequestToEntity(PassengerSaveRequest request)
        {
            var client = new Passenger
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                StudentDNI = request.StundentDNI,
                StudentAdress = request.StudentAdress,
            };

            return client;
        }
    }
}
