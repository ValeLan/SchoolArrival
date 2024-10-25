using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpPost("SignToTravel")]
        public async Task<IActionResult> SignToTravel(int idTravel)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Passenger.ToString())
            {
                return Forbid("El usuario no esta autorizado para anotarse en el viaje.");
            }
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _passengerService.SignToTravel(int.Parse(userIdClaim), idTravel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("DropTravel")]
        public async Task<IActionResult> DropTravel(int idTravel)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Passenger.ToString())
            {
                return Forbid("El usuario no esta autorizado para darse de baja del viaje.");
            }
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _passengerService.DropTravel(int.Parse(userIdClaim), idTravel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
