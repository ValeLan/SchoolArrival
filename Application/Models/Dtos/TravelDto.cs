using Domain.Models;

namespace Application.Models.Dtos
{
    public class TravelDto
    {
        public int Id { get; set; }
        public string? Hour { get; set; }
        public int Capacity { get; set; }
        public string? State { get; set; }
        public SchoolDto? School { get; set; }
        public DriverDto? Driver { get; set; }
        public List<PassengerDto> Passengers { get; set; } = new List<PassengerDto>();
        public District? District { get; set; }
    }
}
