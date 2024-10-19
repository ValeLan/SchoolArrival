using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {
        private readonly IPassengerService _services;
        public PassengerController(IPassengerService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }

        [HttpGet("{id}")]

        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_services.GetById(id));
        }

        [HttpPost]

        public IActionResult Create([FromBody] PassengerSaveRequest request) 
        {
            _services.CreatePassenger(request);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update([FromQuery] int id, PassengerSaveRequest request)
        {
            _services.UpdatePassenger(id, request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _services.DeletePassenger(id);
            return Ok();
        }

    }
}
