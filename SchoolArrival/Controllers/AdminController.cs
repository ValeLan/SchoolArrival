using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
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
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var admins = await _adminServices.GetAllAsync();
            if (admins.Count == 0)
            {
                return NotFound();
            }
            return Ok(admins);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    return Ok(_AdminServices.GetById(id));
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAdminAsync(AdminSaveRequest request)
        {

            try
            {
                await _adminServices.CreateAdminAsync(request);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        //[HttpPut]
        //public IActionResult UpdateAdmin([FromQuery] int id, AdminSaveRequest request)
        //{
        //    _AdminServices.UpdateAdmin(id, request);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult DeleteAdmin(int id)
        //{
        //    _AdminServices.DeleteAdmin(id);
        //    return Ok();
        //}
    }
}
