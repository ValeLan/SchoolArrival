using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;    
        public string StudentDNI {  get; set; } = string.Empty;
        public string StudentAdress {  get; set; } = string.Empty;
        public DateTime Hour { get; set; }
        public int DistrictId { get; set; }
        public int SchoolId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }   
        public District District {  get; set; }
        public School School { get; set; }
        public List<Travel> Travels { get; set; } = new List<Travel>();
    }
}
