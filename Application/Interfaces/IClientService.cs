
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public Registration Add(Registration client);

        public Registration Get(int id);

        public ICollection<Registration> GetAll();

        public Registration Update(Registration client);

        public void Delete(int id);
    }
}
