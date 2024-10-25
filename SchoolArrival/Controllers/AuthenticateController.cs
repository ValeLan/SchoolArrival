using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
