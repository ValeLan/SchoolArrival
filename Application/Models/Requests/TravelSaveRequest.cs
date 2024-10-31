using Domain.Models;

namespace Application.Models.Requests
{
    public class TravelSaveRequest
    {
        public string? Hour { get; set; }
        public int SchoolId { get; set; }
        public int DriverId { get; set; }
        public int Capacity { get; set; }
        public int? District { get; set; }

    }
}
