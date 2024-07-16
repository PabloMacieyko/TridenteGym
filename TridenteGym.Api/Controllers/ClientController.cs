using Application.Dto_s;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TridenteGym.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET -> https://IP/client/getall
        [HttpGet("GetAll")]
        public IEnumerable<ClientDto> GetAll()
        {
            return _clientService.GetAll();
        }

        //

    }

}
