using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class TravelSaveRequest
    {
        [Required]
        public string? Hour { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
