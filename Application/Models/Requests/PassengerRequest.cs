using Domain.Models;

namespace Application.Models.Requests
{
    public class PassengerRequest
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DNI { get; set; }
        public District? District { get; set; }
    }
}
