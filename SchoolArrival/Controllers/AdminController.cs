using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _AdminServices;
        public AdminController(IAdminServices adminServices)
        {
            _AdminServices = adminServices;
        }
        [HttpGet("{name}")]
        public IActionResult Get([FromRoute]string name)
        {
            return Ok(_AdminServices.Get(name));
        }
    }
}
