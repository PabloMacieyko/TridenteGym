
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ActivityDto>> GetClientActivities(int clientId);
    }
}
