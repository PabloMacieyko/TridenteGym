
using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientService;
        public ClientService(IClientRepository clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<ActivityDto>> GetClientActivities(int clientId)
        {
            var activities = _clientService.GetClientActivities(clientId);
            var activitiesDto = new List<ActivityDto>();
            foreach (var activity in activitiesDto)
            {
                var activityDto = new ActivityDto()
                {
                    Title = activity.Title,
                    Description = activity.Description,
                    ProfessorId = activity.ProfessorId,
                    Price = activity.Price,
                };
                activitiesDto.Add(activityDto);
            }
            return activitiesDto;
        }
    }
}
