using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
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
            var entitys = _services.GetAll();
            if (entitys.Count == 0)
            {
                return NotFound();
            }
            return Ok(entitys);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var entity = await _services.GetAsync(id);

            if (entity is not null)
            {
                return Ok(entity);                
            }
            return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody] PassengerSaveRequest request) 
        {
            try
            {
                await _services.CreateAsync(request);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAsync([FromQuery] int id, PassengerSaveRequest request)
        {
            try
            {
                await _services.UpdatePassengerAsync(id, request);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _services.DeletePassengerAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

    }
}
