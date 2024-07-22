using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepositiry;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepositiry = activityRepository;
        }

        public async Task<ActivityDto> CreateAsync(ActivityCreateRequest request)
        {
            var activity = new Activity();
            activity.Title = request.Title;
            activity.Description = request.Description;
            activity.ProfessorId = request.ProfessorId;
            activity.Price = request.Price;

            _ = await _activityRepositiry.CreateAsync(activity);

            var dto = new ActivityDto();
            dto.ActivityId = activity.ActivityId;
            dto.Title = activity.Title;
            dto.Description = activity.Description;
            dto.ProfessorId = activity.ProfessorId;
            dto.Price = activity.Price;

            return dto;
        }

        public async Task<ActivityDto> GetActivityAsync(int id)
        {
            var result = await _activityRepositiry.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Activity not found");

            var activityDto = new ActivityDto();
            activityDto.ActivityId = result.ActivityId;
            activityDto.Title = result.Title;
            activityDto.Description = result.Description;
            activityDto.ProfessorId= result.ProfessorId;
            activityDto.Price = result.Price;
            
            return activityDto;
        }

        public async Task<List<ActivityDto>> GetAllAsync()
        {
            var result = await _activityRepositiry.GetAllAsync();
            var resultDto = new List<ActivityDto>();
            foreach (var activity in result)
            {
                var activityDto = new ActivityDto()
                {
                    ActivityId = activity.ActivityId,
                    Title = activity.Title,
                    Description = activity.Description,
                    Price = activity.Price,
                    ProfessorId = activity.ProfessorId,
                };
                resultDto.Add(activityDto);
            }
            return resultDto;
        }

        public async Task<ActivityDto> UpdateAsync( ActivityDto activityDto, int id)
        {
            var activity = await _activityRepositiry.GetByIdAsync(id);
            if (activity == null)
                throw new Exception("Activity not found");

            activity.Title = activityDto.Title;
            activity.Description = activityDto.Description;
            activity.Price = activityDto.Price;
            activity.ProfessorId = activityDto.ProfessorId;

            await _activityRepositiry.UpdateAsync(activity);

            var dto = new ActivityDto()
            {
                ActivityId = activity.ActivityId,
                Title = activity.Title,
                Description = activity.Description,
                Price = activity.Price,
                ProfessorId = activity.ProfessorId,
            };

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _activityRepositiry.GetByIdAsync(id);
            if (activity == null)
                throw new Exception("Activity not found");

            await _activityRepositiry.DeleteAsync(activity);
        }
    }
}
