using Application.Models.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class PassengerSaveRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string StundentDNI { get; set; } = string.Empty;
        public string StudentAdress { get; set; } = string.Empty;
        public DateTime Hour { get; set; }
        public int DistrictId { get; set; }
        public int SchoolId { get; set; }
        public int ClientId { get; set; }
        public List<int> TravelIds { get; set; } = [];
    }
}
