using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolServices _schoolServices;
        public SchoolController(ISchoolServices services)
        {
            _schoolServices = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var school = await _schoolServices.GetAllAsync();
            if (school.Count == 0)
            {
                return NotFound();
            }
            return Ok(school);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(SchoolSaveRequest request)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Admin.ToString())
            {
                return StatusCode(403, "El usuario no esta autorizado para crear Escuelas.");
            }
            await _schoolServices.CreateSchoolAsync(request);
            return Ok();

            //var response = await _schoolServices.CreateSchoolAsync(request);
            //return Ok(response);
        }
        [Authorize]
        [HttpPut("{idSchool}")]

        public async Task<IActionResult> UpdateAsync([FromRoute] int idSchool, [FromBody] SchoolSaveRequest request)
        {
            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim != Role.Admin.ToString())
                {
                    return StatusCode(403, "El usuario no esta autorizado para modificar Escuelas.");
                }

                bool response = await _schoolServices.UpdateSchoolAsync(idSchool, request);
                if (response == false)
                {
                    return NotFound("No se encontro la escuela.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete("{idSchool}")]
        public async Task<IActionResult> DeleteSchool([FromRoute] int idSchool)
        {

            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Admin.ToString())
            {
                return StatusCode(403, "El usuario no esta autorizado para eliminar Escuelas.");
            }
            await _schoolServices.DeleteAsync(idSchool);
            return Ok();
        }
    }
}
