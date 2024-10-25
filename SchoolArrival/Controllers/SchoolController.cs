using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SchoolSaveRequest request)
        {
            var response = await _schoolServices.CreateSchoolAsync(request);
            return Ok(response);
        }

        [HttpPut("{idSchool}")]

        public async Task<IActionResult> UpdateAsync([FromRoute] int idSchool, [FromBody] SchoolSaveRequest request)
        {
            try
            {

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


        [HttpDelete("{idSchool}")]
        public async Task<IActionResult> DeleteSchool([FromRoute] int idSchool)
        {
            await _schoolServices.DeleteAsync(idSchool);
            return Ok();
        }
    }
}
