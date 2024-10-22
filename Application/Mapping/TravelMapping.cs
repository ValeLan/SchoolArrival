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
    public class TravelMapping
    {
        public Travel FromRequestToEntity(TravelSaveRequest dto)
        {
            var travel = new Travel
            {
                State = TravelState.Llegando,
                StudentAdress = dto.StudentAdress,
                DriverId = dto.DriverId,
            };
            return travel;
        }

        public TravelDto FromEntityToResponse(Travel travel)
        {
            var dto = new TravelDto
            {
                Id = travel.Id,
                State = travel.State.ToString(),
                StudentAdress = travel.StudentAdress

            };
            return dto;
        }
    }
}
