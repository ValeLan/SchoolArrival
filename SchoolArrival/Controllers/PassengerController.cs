using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize]
    //public class PassengerController : Controller
    //{
    //    private readonly IPassengerService _services;
    //    public PassengerController(IPassengerService services)
    //    {
    //        _services = services;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetAllAsync()
    //    {
    //        var entitys = await _services.GetAllAsync();
    //        if (entitys.Count == 0)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(entitys);
    //    }

        //[HttpGet("{id}")]

        //public async Task<IActionResult> GetAsync([FromRoute] int id)
        //{
        //    var entity = await _services.GetAsync(id);

        //    if (entity is not null)
        //    {
        //        return Ok(entity);                
        //    }
        //    return NotFound();
        //}

        //[HttpPost]

        //public async Task<IActionResult> CreateAsync([FromBody] PassengerSaveRequest request)
        //{
        //    try
        //    {
        //        await _services.CreateAsync(request);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut("{idPassenger}")]

        //public async Task<IActionResult> UpdateAsync([FromRoute] int idPassenger, [FromBody] PassengerSaveRequest request)
        //{
        //    try
        //    {

        //        bool response = await _services.UpdatePassengerAsync(idPassenger, request);
        //        if (response == false)
        //        {
        //            return NotFound("No se encontro el pasajero.");
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        await _services.DeletePassengerAsync(id);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }

        //}

    
}
