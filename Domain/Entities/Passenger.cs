using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        public string? PhoneNumber {  get; set; }   
        public string? StudentDNI {  get; set; }
        public string? StudentAdress {  get; set; }
        public string? Hour { get; set; }
        public District? District { get; set; }
    }
}
