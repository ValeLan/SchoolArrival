using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TravelController : ControllerBase
    {
        private readonly ITravelServices _travelServices;
        public TravelController(ITravelServices travelServices)
        {
            _travelServices = travelServices;
        }

        [HttpGet("Historical")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _travelServices.GetHistoricalAsync());
        }

        [HttpGet("Pending")]
        public async Task<IActionResult> GetAllPendingAsync()
        {
            return Ok(await _travelServices.GetAllPendingAsync());
        }

        [HttpGet("Completed")]
        public async Task<IActionResult> GetAllCompletedAsync()
        {
            return Ok(await _travelServices.GetAllCompletedAsync());
        }
        [HttpGet("Delay")]
        public async Task<IActionResult> GetAllDelayAsync()
        {
            return Ok(await _travelServices.GetAllDelayAsync());
        }

        [HttpGet("Canceled")]
        public async Task<IActionResult> GetAllCanceledAsync()
        {
            return Ok(await _travelServices.GetAllCanceledAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTravel([FromBody] TravelSaveRequest request)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para crear viajes.");
                }

                var response = await _travelServices.CreateAsync(request);

                if (response)
                {
                    return Ok();
                }
                
                return BadRequest("Debe ingresar un chofer y una escuela válidos.");
                
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPut("IdTraver/{idTravel}/IdDriver/{idDriver}")]
        public async Task<IActionResult> ReplaceDriver(int idTravel, int idDriver)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim == Role.Passenger.ToString())
            {
                return StatusCode(403, "El pasajero no esta autorizado para modificar viajes.");
            }

            try
            {
                var response = await _travelServices.ReplaceDriverAsync(idTravel, idDriver);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("No se encontro el viaje seleccionado.");
                }
                
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            
            
        }
        [Authorize]
        [HttpPut("id/{idTravel}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idTravel, [FromBody] TravelSaveRequest request)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para modificar viajes.");
                }

                bool response = await _travelServices.UpdateTravelAsync(idTravel, request);
                if (response == false)
                {
                    return NotFound("No se encontro el viaje.");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("TravelCompleted/id/{idTravel}")]
        public async Task<IActionResult> UpdateState([FromRoute] int idTravel)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para eliminar viajes.");
                }
                bool response = await _travelServices.CompleteTravel(idTravel);
                if(response == false)
                {
                    return NotFound("No se encontro el Viaje.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("id/{idTravel}")]
        public async Task<IActionResult> DeleteTravel([FromRoute]int idTravel)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El pasajero no esta autorizado para eliminar viajes.");
                }

                bool response = await _travelServices.DeleteAsync(idTravel);
                if (response == false)
                {
                    return NotFound("No se encontro el Viaje.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
