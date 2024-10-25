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

        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute]int id) 
        //{ 
        //    return Ok(_travelServices.Get(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync([FromBody]TravelSaveRequest travel)
        //{
        //    return Ok(await _travelServices.CreateAsync(travel));
        //}

        [HttpPost]
        public async Task<IActionResult> CreateTravel(TravelSaveRequest request)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim == Role.Passenger.ToString())
            {
                return Forbid("El pasajero no esta autorizado para crear viajes.");
            }
            await _travelServices.CreateAsync(request);
            return Ok();
        }

        [HttpPut("{idTravel}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idTravel, [FromBody] TravelSaveRequest request)
        {
            try
            {

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
