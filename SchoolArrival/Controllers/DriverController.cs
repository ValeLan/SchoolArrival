using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverServices _driverServices;

        public DriverController(IDriverServices driverServices) 
        {
            _driverServices = driverServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var drivers = _driverServices.GetAll();
            if (drivers.Count == 0)
            {
                return NotFound();
            }
            return Ok(drivers);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    return Ok(_driverServices.GetById(id));
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DriverSaveRequest request)
        {
            var response = await _driverServices.CreateDriverAsync(request);
            return Ok(response);
        }

        //[HttpPut]
        //public IActionResult Update([FromQuery] int id, DriverSaveRequest request)
        //{
        //    _driverServices.UpdateDriver(id, request);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    _driverServices.DeleteDriver(id);
        //    return Ok();
        //}

    }
}
