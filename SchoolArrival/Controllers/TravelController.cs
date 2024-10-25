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

        //[HttpPut]
        //public IActionResult Update([FromQuery] int id, TravelSaveRequest travel) 
        //{
        //    _travelServices.UpdateEntity(id, travel);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(int id) 
        //{
        //    return Ok(_travelServices.Delete(id));
        //}
    }
}
