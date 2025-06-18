using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Activity>> GetClientActivities(int clientId);
    }
}
