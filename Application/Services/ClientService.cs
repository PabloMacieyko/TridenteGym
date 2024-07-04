

using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        { 
            _clientRepository = clientRepository;
        }
    }
}
