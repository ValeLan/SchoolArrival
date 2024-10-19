using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        public string PhoneNumber {  get; set; } = string.Empty;
     
        public string StundentDNI {  get; set; } = string.Empty;
        public string StudentAdress {  get; set; } = string.Empty;
        public DateTime Hour { get; set; }
        public District? District {  get; set; }
        public School? School { get; set; }
        public List<Travel> Travels { get; set; } = [];
    }
}
