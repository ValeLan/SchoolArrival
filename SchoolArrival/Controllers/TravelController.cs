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
        public IActionResult GetAll()
        {
            return Ok(_travelServices.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        { 
            return Ok(_travelServices.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]TravelDto travel)
        {
            return Ok(_travelServices.Create(travel));
        }

        [HttpPut]
        public IActionResult Update([FromQuery] int id, TravelSaveRequest travel) 
        {
            _travelServices.UpdateEntity(id, travel);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            return Ok(_travelServices.Delete(id));
        }
    }
}
