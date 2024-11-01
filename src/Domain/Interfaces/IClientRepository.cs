using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Activity> GetClientActivities(int clientId);
    }
}
