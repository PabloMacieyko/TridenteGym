using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOwnerRepository
    {
        public Owner Add(Owner owner);

        public Owner Get(int id);

        public ICollection<Owner> GetAll();

        public Owner Update(Owner owner);

        public void Delete(int id);
    }
}
