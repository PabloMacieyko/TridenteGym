using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Add(Client client)
        {
            var clientResult = _context.Client.Add(client);
            _context.SaveChanges();

            return clientResult.Entity;
        }

        public void Delete(int id)
        {
            var client = _context.Client.FirstOrDefault(x => x.Id == id);
            if (client != null)
                throw new Exception("Cliente no encontrado");
            
            _context.Client.Remove(client);
            _context.SaveChanges();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client Update(int id, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
