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
        public TravelState State { get; set; } = TravelState.EnCamino;

        public string StudentAdress { get; set; }

        public DriverDto Driver { get; set; }

        public List<PassengerDto> Passengers { get; set; }
    }
}
