
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public Client Add(Client client);

        public Client Get(int id);

        public ICollection<Client> GetAll();

        public Client Update(Client client);

        public void Delete(int id);
    }
}
