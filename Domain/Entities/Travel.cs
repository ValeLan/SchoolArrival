using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Hour { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int Capacity { get; set; } = 20;
        [Required]
        public TravelState State { get; set; }
        [Required]
        public int DriverId { get; set; }
        public School? School { get; set; }       
        public User? Driver { get; set; }
        public List<User> Passengers { get; set; } = new List<User>();

    }
}
