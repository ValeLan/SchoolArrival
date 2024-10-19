using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolServices _services;
        public SchoolController(ISchoolServices services)
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
        public IActionResult CreateSchool([FromBody] School request)
        {
            _services.CreateSchool(request);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult UpdateSchool([FromQuery] int id, School request)
        {
            _services.UpdateSchool(id, request);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSchool([FromRoute] int id)
        {
            _services.DeleteSchool(id);
            return Ok();
        }
    }
}
