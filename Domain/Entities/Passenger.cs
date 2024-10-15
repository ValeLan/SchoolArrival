using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        public string? PhoneNumber {  get; set; }
        public string? StudentSchool {  get; set; }
        public string? StundentDNI {  get; set; }
        public string? StudentAdress {  get; set; }
        public string? District {  get; set; }
        public DateTime Hour {  get; set; }
    }
}
