
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IActivityRepository : IRepositoryBase<Activity>
    {
        Task<List<Client>> GetEnrolledClientsAsync(int activityId, CancellationToken cancellationToken = default);
        Task<Professor> GetAssignedProfessorAsync(int activityId, CancellationToken cancellationToken = default);

    }
}
