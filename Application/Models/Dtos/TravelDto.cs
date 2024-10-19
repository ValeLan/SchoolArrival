using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class TravelDto
    {
        public TravelState State { get; set; }
        public string StudentAdress { get; set; } = string.Empty;

        public static Travel ToEntity(TravelDto dto)
        {
            Travel travel = new Travel
            {
                State = dto.State,
                StudentAdress = dto.StudentAdress
            };
            return travel;
        }

        public static TravelDto ToDto(Travel travel)
        {
            TravelDto dto = new TravelDto
            {
                State = travel.State,
                StudentAdress = travel.StudentAdress
            };
            return dto;
        }

    }
}
