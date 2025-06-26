using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientService;
        private readonly IUserService _userService;
        public ClientService(IClientRepository clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        public async Task<List<ActivityDto>> GetClientActivities(int clientId)
        {
            var user = await _userService.GetUserByIdAsync(clientId);
            if (user == null || user.Role != UserRole.Client)
                throw new Exception("The ID provided does not correspond to a client.");

            var activities = await _clientService.GetClientActivities(clientId);
            var activitiesDto = new List<ActivityDto>();
            foreach (var activity in activities)
            {
                var activityDto = new ActivityDto()
                {
                    ActivityId = activity.ActivityId,
                    Title = activity.Title,
                    Description = activity.Description,
                    ProfessorId = activity.ProfessorId,
                    Price = activity.Price,
                    AvailableSlots = activity.AvailableSlots
                };
                activitiesDto.Add(activityDto);
            }
            return activitiesDto;
        }
    }
}
