﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PassengerDto> Passengers { get; set; } = new List<PassengerDto>();
    }
}
