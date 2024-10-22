using Application.Models.Dtos;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class TravelSaveRequest
    {
        public TravelState State { get; set; }
        public string StudentAdress { get; set; } = string.Empty;

        public int DriverId { get; set; }

        public List<int> PassengersIds { get; set; } = new List<int>();

        public static Travel ToEntity(TravelDto dto)
        {
            var travel = new Travel
            {
                State = dto.State,
                StudentAdress = dto.StudentAdress
            };
            return travel;
        }

        public static TravelDto ToDto(Travel travel)
        {
            var dto = new TravelDto
            {
                State = travel.State,
                StudentAdress = travel.StudentAdress
            };
            return dto;
        }

        public static List<TravelDto> ToDto(List<Travel> travels)
        {
            var travel = travels.Select(x => ToDto(x)).ToList();
            return travel;
        }
    }
}
