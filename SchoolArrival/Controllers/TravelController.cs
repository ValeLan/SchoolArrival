using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]TravelSaveRequest travel)
        {
            return Ok(await _travelServices.CreateAsync(travel));
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
