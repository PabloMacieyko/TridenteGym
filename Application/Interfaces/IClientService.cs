using Application.Dto_s;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public ClientDto Add(ClientDto client);

        public ClientDto GetById(int id);

        public ICollection<ClientDto> GetAll();

        public ClientDto Update(ClientDto client);

        public void Delete(int id);
    }
}
