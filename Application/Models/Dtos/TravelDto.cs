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
        public int Id { get; set; }
        public string State { get; set; } 
        public string StudentAdress { get; set; }
        public List<PassengerDto> Passengers { get; set; } = new List<PassengerDto>();
    }
}
