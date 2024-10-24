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
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StudentDNI { get; set; }
        public string? StudentAdress { get; set; }
        public string? Hour { get; set; }
        public string? District { get; set; }
    }
}
