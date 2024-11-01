using Application.DTOs.Requests;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityDto> CreateAsync(ActivityCreateRequest user);

        Task<ActivityDto> GetActivityAsync(int id);

        Task<List<ActivityDto>> GetAllAsync();

        Task<ActivityDto> UpdateAsync(ActivityDto activity, int id);

        Task DeleteAsync(int id);
    }
}
