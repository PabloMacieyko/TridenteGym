using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        ICollection<Client> GetClientsEnrolledInMyActivities(int professorId);
    }
}
