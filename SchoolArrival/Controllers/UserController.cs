using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

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
