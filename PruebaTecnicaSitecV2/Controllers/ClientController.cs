using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSitecV2.Interfaces;

namespace PruebaTecnicaSitecV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientservice;
        public ClientController(IClientService clientservice)
        {
            _clientservice = clientservice;
        }
        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_clientservice.GetClients());
        }
    }
}
