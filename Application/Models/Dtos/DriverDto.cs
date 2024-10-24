using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public List<TravelDto> Travels { get; set; }
    }
}
