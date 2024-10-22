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
        public string StudentAdress { get; set; } = string.Empty;

        public int DriverId { get; set; }

        
    }
}
