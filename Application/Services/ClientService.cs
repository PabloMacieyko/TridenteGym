using Application.Dto_s;
using Application.Interfaces;
using Domain.Entities;
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

        public ClientDto Add(ClientDto dto)
        {
            var client = new Client();
            client.Email = dto.Email;

            _clientRepository.Add(client)
        }
        public void Delete(int id)
        {
            return;
        }
        public ClientDto Get(ClientDto dto)
        {
            return dto;
        }
        public ClientDto Update(ClientDto dto)
        {
            return dto;
        }
        public ICollection<ClientDto> GetAll()
        {

            return ;
        }

        public ClientDto GetById(int id)
        {

            return ;
        }

    }
}
