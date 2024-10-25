using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userServices.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int idUser)
        {
            var response = await _userServices.GetAsync(idUser);
            return Ok(response);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            var response = await _userServices.CreateUser(request);
            return Ok(response);
        }

        [HttpPut("{idUser}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int idUser, [FromBody] UserRequest request)
        {
            try
            {

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

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var response = await _userServices.GetAsync(idUser);

            try
            {
                if (response == null)
                {
                    return NotFound();
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
