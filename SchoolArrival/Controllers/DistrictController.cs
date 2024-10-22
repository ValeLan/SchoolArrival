using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {
        private readonly IDistrictServices _districtServices;
        public DistrictController(IDistrictServices districtServices)
        {
            _districtServices = districtServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_districtServices.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_districtServices.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateDistrict([FromBody] DistrictSaveRequest request)
        {
            _districtServices.CreateDistrict(request);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult UpdateDistrict([FromQuery] int id, District request)
        {
            _districtServices.UpdateDistrict(id, request);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDistrict([FromRoute] int id)
        {
            _districtServices.DeleteDistrict(id);
            return Ok();
        }
    }
}
