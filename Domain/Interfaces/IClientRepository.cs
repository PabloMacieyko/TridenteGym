using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        public Client Add(Client client);

        public Client Get(int id);

        public IList<Client> GetAll();

        public Client Update(int id, Client client);

        public void Delete(int id);
    }
}
