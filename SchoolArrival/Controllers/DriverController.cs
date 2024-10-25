using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize]
    //public class DriverController : Controller
    //{
    //    private readonly IDriverServices _driverServices;
    //    private readonly ITravelServices _travelServices;

    //    public DriverController(IDriverServices driverServices, ITravelServices travelServices) 
    //    {
    //        _driverServices = driverServices;
    //        _travelServices = travelServices;
    //    }

    //    [HttpGet]
    //    public IActionResult GetAll()
    //    {
    //        var drivers = _driverServices.GetAll();
    //        if (drivers.Count == 0)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(drivers);
    //    }

        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    return Ok(_driverServices.GetById(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(DriverSaveRequest request)
        //{
        //    var response = await _driverServices.CreateDriverAsync(request);
        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateTravel(TravelSaveRequest request)
        //{
        //    var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        //    if (userRoleClaim == Role.Passenger.ToString())
        //    {
        //        return Forbid("El pasajero no esta autorizado para crear viajes.");
        //    }
        //    await _travelServices.CreateAsync(request);
        //    return Ok();
        //}

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

   // }
}
