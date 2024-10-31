using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _userServices;

        public AdminController(IAdminServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userServices.GetAllAdminsAsync();
            return Ok(response);
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int idUser)
        {
            var response = await _userServices.GetAdminAsync(idUser);
            if (response == null)
            {
                return StatusCode(404, "El usuario no fue encontrado.");
            }    
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(AdminRequest request)
        {
            var response = await _userServices.CreateUser(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{idUser}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idUser, [FromBody] AdminRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null || idUser != int.Parse(userIdClaim))
                {
                    return StatusCode(403, "El usuario no está autorizado para eliminar este usuario.");
                }

                bool response = await _userServices.UpdateUserAsync(idUser, request);
                if (response == false)
                {
                    return NotFound("No se encontro el usuario.");
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var response = await _userServices.GetAdminAsync(idUser);
            if(response == null)
            {
                return NotFound("No se encontró el usuario que desea eliminar.");
            }
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null || idUser != int.Parse(userIdClaim))
                {
                    return StatusCode(403, "El usuario no está autorizado para eliminar este usuario.");
                }
                await _userServices.DeleteAsync(response.Id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
