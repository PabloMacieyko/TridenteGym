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
        private readonly IProfessorService _professorService;
        public ActivityService(IActivityRepository activityRepository, IProfessorService professorService)
        {
            _activityRepositiry = activityRepository;
            _professorService = professorService;
        }

        public async Task<ActivityDto> CreateAsync(ActivityCreateRequest request)
        {
            // Validar que el profesor exista
            var professor = await _professorService.GetByIdAsync(request.ProfessorId);
            if (professor == null)
                throw new Exception("Incorrect teacher ID.");
            
            if (request.AvailableSlots < 0)
                throw new Exception("AvailableSlots can't be negative.");

            if (request.Price < 0)
                throw new Exception("Price can't be negative.");

            var activity = new Activity();
            activity.Title = request.Title;
            activity.Description = request.Description;
            activity.ProfessorId = request.ProfessorId;
            activity.Price = request.Price;
            activity.AvailableSlots = request.AvailableSlots;

            _ = await _activityRepositiry.CreateAsync(activity); //guarda en la base de datos

            var dto = new ActivityDto(); //solo devuelve los datos necesarios
            dto.ActivityId = activity.ActivityId;
            dto.Title = activity.Title;
            dto.Description = activity.Description;
            dto.ProfessorId = activity.ProfessorId;
            dto.Price = activity.Price;
            dto.AvailableSlots = activity.AvailableSlots;

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
            activityDto.AvailableSlots = result.AvailableSlots;
            
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
                    AvailableSlots = activity.AvailableSlots
                };
                resultDto.Add(activityDto);
            }
            return resultDto;
        }

        public async Task<ActivityDto> UpdateAsync( ActivityDto activityDto, int id)
        {
            // Validar que el profesor exista
            var professor = await _professorService.GetByIdAsync(activityDto.ProfessorId);
            if (professor == null)
                throw new Exception("Incorrect teacher ID");

            var activity = await _activityRepositiry.GetByIdAsync(id);
            if (activity == null)
                throw new Exception("Activity not found");

            activity.Title = activityDto.Title;
            activity.Description = activityDto.Description;
            activity.Price = activityDto.Price;
            activity.ProfessorId = activityDto.ProfessorId;

            if (activityDto.AvailableSlots < 0)
                throw new Exception("AvailableSlots can't be negative.");
            activity.AvailableSlots = activityDto.AvailableSlots;

            await _activityRepositiry.UpdateAsync(activity);

            var dto = new ActivityDto()
            {
                ActivityId = activity.ActivityId,
                Title = activity.Title,
                Description = activity.Description,
                Price = activity.Price,
                ProfessorId = activity.ProfessorId,
                AvailableSlots=activity.AvailableSlots
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

