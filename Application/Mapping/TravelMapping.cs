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
            var travel = new Travel();
            travel.Hour = dto.Hour;
            travel.SchoolId = dto.SchoolId;
            travel.DriverId = dto.DriverId;
            travel.Capacity = dto.Capacity;
            travel.State = TravelState.EnProceso;

            return travel;
        }

        public TravelDto FromEntityToResponse(Travel travel)
        {
            var _userMapping = new PassengerMapping();
            var _schoolMapping = new SchoolMapping();
            var _driverMapping = new DriverMapping();
            var dto = new TravelDto
            {
                Id = travel.Id,
                Hour = travel.Hour,
                Capacity = travel.Capacity,
                State = travel.State.ToString(),
                School = travel.School != null ? _schoolMapping.FromEntityToResponse(travel.School) : null,
                Driver = travel.Driver != null ? _driverMapping.FromEntityToResponse(travel.Driver) : null,
                Passengers = travel.Passengers != null ? travel.Passengers.Select(p => _userMapping.FromEntityToResponse(p)).ToList() : new List<PassengerDto>()
            };
            return dto;
        }

        public Travel FromEntityToEntityUpdated(Travel travel, TravelSaveRequest travelRequest) 
        {
            travel.Hour = travelRequest.Hour ?? travel.Hour;
            travel.SchoolId = travelRequest.SchoolId;
            travel.DriverId = travelRequest.DriverId;
            travel.Capacity = travelRequest.Capacity;

            return travel;
        }

        //public void CancelTravel(Travel travel)
        //{
        //    travel.State = TravelState.Cancelado;
        //}

        public void CompleteTravel(Travel travel)
        {
            travel.State = TravelState.Completado;
        }
    }
}
