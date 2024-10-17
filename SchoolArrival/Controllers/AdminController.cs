using Application.Interfaces;
using Application.Models.Requests;
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

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_AdminServices.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok(_AdminServices.GetById(id));
        }

        [HttpPost]
        public IActionResult CreateAdmin(AdminSaveRequest request) 
        { 
            _AdminServices.CreateAdmin(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAdmin([FromQuery] int id, AdminSaveRequest request) 
        { 
            _AdminServices.UpdateAdmin(id, request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAdmin(int id) 
        {
            _AdminServices.DeleteAdmin(id);
            return Ok();
        }
    }
}
