using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverServices _userServices;

        public DriverController(IDriverServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userServices.GetAllDriversAsync();
            return Ok(response);
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int idUser)
        {
            var response = await _userServices.GetDriverAsync(idUser);
            if (response == null)
            {
                return StatusCode(404, "El usuario no fue encontrado.");
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet("MyTravels")]
        public async Task<IActionResult> GetMyTravelsAsync()
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Driver.ToString())
            {
                return StatusCode(403, "El usuario no esta autorizado ver esta información.");
            }
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _userServices.GetMyTravelsAsync(int.Parse(userIdClaim));
            if (response == null)
            {
                return StatusCode(404, "El usuario no tiene viajes asociados.");
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUser(DriverRequest request)
        {
            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRoleClaim != Role.Admin.ToString())
            {
                return StatusCode(403, "El usuario no esta autorizado para crear un Driver.");
            }
            var response = await _userServices.CreateUser(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{idUser}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idUser, [FromBody] DriverRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null || idUser != int.Parse(userIdClaim))
                {
                    return StatusCode(403, "El usuario no está autorizado para modificar este usuario.");
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
            var response = await _userServices.GetDriverAsync(idUser);

            try
            {
                var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRoleClaim == Role.Passenger.ToString())
                {
                    return StatusCode(403, "El usuario no esta autorizado para eliminar un Driver.");
                }

                if (userRoleClaim == Role.Admin.ToString())
                {
                    await _userServices.DeleteAsync(response.Id);

                    return NoContent();
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null || response.Id != int.Parse(userIdClaim))
                {
                    return StatusCode(403, "El usuario no está autorizado para eliminar este usuario.");
                }

                if (response == null)
                {
                    return NotFound("No se encontro el usuario que desea eliminar.");
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
