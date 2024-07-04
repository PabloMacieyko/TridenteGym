
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOwnerService
    {
        public Owner Add(Owner owner);

        public Owner Get(int id);

        public ICollection<Owner> GetAll();

        public Owner Update(Owner owner);

        public void Delete(int id);
    }
}
