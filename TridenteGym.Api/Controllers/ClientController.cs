using Application.Interfaces;
using Domain.Entities;
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
        public IEnumerable<Client> GetAll()
        {
            return _clientService.GetAll();
        }

        //

    }
