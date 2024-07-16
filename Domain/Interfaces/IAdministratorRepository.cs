using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAdministratorRepository
    {
        public Administrator Add(Administrator owner);

        public Administrator Get(int id);

        public ICollection<Administrator> GetAll();

        public Administrator Update(Administrator owner);

        public void Delete(int id);
    }
}
