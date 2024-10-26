using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PassengerController : ControllerBase
    {
        private readonly IUserServices _userService;

        public PassengerController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("SignToTravel")]
        public async Task<IActionResult> SignToTravel(int idTravel)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Passenger.ToString())
            {
                return StatusCode(403, "El usuario no esta autorizado para anotarse en el viaje.");
            }
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _userService.SignToTravel(int.Parse(userIdClaim), idTravel);
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
                return StatusCode(403, "El usuario no esta autorizado para darse de baja del viaje.");
            }
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _userService.DropTravel(int.Parse(userIdClaim), idTravel);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
