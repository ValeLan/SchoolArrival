﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TravelState? State {  get; set; }
        public string? StudentAdress { get; set; }
        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }
        public List<Passenger> Passenger { get; set; } = new List<Passenger>();

    }
}
