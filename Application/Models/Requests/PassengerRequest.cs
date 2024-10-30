using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class PassengerRequest
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? DNI { get; set; }
        [Required]
        public District? District { get; set; }
    }
}
