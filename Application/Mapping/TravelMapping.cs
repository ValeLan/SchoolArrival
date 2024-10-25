using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Models;

namespace Application.Mapping
{
    public class TravelMapping
    {
        public Travel FromRequestToEntity(TravelSaveRequest dto)
        {
            var travel = new Travel
            {
                Hour = dto.Hour,
                SchoolId = dto.SchoolId,
            };
            return travel;
        }

        public TravelDto FromEntityToResponse(Travel travel)
        {
            var _userMapping = new UserMapping();
            var _schoolMapping = new SchoolMapping();
            var dto = new TravelDto
            {
                Id = travel.Id,
                Hour = travel.Hour,
                SchoolDto = _schoolMapping.FromEntityToResponse(travel.School),
                Passengers = travel.Passengers.Select(p => _userMapping.FromEntityToResponse(p)).ToList()

            };
            return dto;
        }

        public Travel FromEntityToEntityUpdated(Travel travel, TravelSaveRequest travelRequest)
        {
            travel.Hour = travelRequest.Hour ?? travel.Hour;
            travel.SchoolId = travelRequest.SchoolId;

            return travel;
        }
    }
}
