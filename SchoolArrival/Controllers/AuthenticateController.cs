using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ICustomAuthenticationServices _customAuthenticationServices;

        public AuthenticateController(ICustomAuthenticationServices customAuthenticationService)
        {
            _customAuthenticationServices = customAuthenticationService;
        }
        [HttpPost]
        public async Task<ActionResult> LoginAsync(AuthRequest request)
        {
            try
            {
                var token = await _customAuthenticationServices.Authenticate(request);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
