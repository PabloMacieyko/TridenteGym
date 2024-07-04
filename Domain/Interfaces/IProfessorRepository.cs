using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        public Professor Add(Professor professor);

        public Professor Get(int id);

        public ICollection<Professor> GetAll();

        public Professor Update(Professor professor);

        public void Delete(int id);
    }
}
