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
    public class PassengerSaveRequest
    {
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StundentDNI { get; set; }
        public string? StudentAdress { get; set; }
        public string? Hour { get; set; }
        public District? District { get; set; }
    }
}
