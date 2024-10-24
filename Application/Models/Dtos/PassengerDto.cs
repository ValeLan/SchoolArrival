using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string StudentDNI { get; set; } = string.Empty;
        public string StudentAdress { get; set; } = string.Empty;
        public DateTime Hour { get; set; } = DateTime.UtcNow;
        public DistrictDto District { get; set; }
        public SchoolDto School { get; set; }
        public ClientDto Client { get; set; }
        public List<TravelDto> Travels { get; set; } = new List<TravelDto>();
    }
}
