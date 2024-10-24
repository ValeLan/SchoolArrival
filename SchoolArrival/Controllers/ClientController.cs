using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService) 
        { 
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Get() 
        {            
            return Ok(_clientService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientSaveRequest request)
        {
            try
            {

                await _clientService.CreateAsync(request);
                return Ok();
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }
    }
}
