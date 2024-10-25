using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TravelController : ControllerBase
    {
        private readonly ITravelServices _travelServices;
        public TravelController(ITravelServices travelServices)
        {
            _travelServices = travelServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _travelServices.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravel(TravelSaveRequest request)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para crear viajes.");
                }
                await _travelServices.CreateAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
            
        }

        [HttpPut("{idTravel}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idTravel, [FromBody] TravelSaveRequest request)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para crear viajes.");
                }

                bool response = await _travelServices.UpdateTravelAsync(idTravel, request);
                if (response == false)
                {
                    return NotFound("No se encontro el viaje.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int idTravel)
        {
            var response = await _travelServices.GetAsync(idTravel);

            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para crear viajes.");
                }
                if (response == null)
                {
                    return NotFound();
                }
                await _travelServices.DeleteAsync(response.Id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
