using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<List<Activity>> GetActivitiesByProfessorIdAsync(int professorId, CancellationToken cancellationToken = default);
    }
}
