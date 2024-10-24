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
                Hour = passenger.Hour,
                District = passenger.District.ToString(),
            };

            return dto;
        }

        public Passenger FromRequestToEntity(PassengerSaveRequest request)
        {
            var client = new Passenger
            {
                Password = request.Password,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                StudentDNI = request.StundentDNI,
                StudentAdress = request.StudentAdress,
                Hour = request.Hour,
                District = request.District,
            };

            return client;
        }

        public Passenger FromEntityToEntityUpdated(Passenger passenger, PassengerSaveRequest passengerRequest) 
        {
            passenger.FullName = passengerRequest.FullName??passenger.FullName;
            passenger.StudentAdress = passengerRequest.StudentAdress??passenger.StudentAdress;
            passenger.StudentDNI = passengerRequest.StundentDNI ?? passenger.StudentDNI;
            passenger.PhoneNumber = passengerRequest.PhoneNumber ?? passenger.PhoneNumber;
            passenger.Hour = passengerRequest.Hour ?? passenger.Hour;
            passenger.District = passengerRequest?.District ?? passenger.District;

            return passenger;
        }
    }
}
