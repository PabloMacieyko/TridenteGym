

using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
