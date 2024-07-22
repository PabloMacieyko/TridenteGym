using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

public class ProfessorService : IProfessorService
{
    private readonly IUserRepository _userRepository;
    private readonly IActivityRepository _activityRepository;

    public ProfessorService(IUserRepository userRepository, IActivityRepository activityRepository)
    {
        _userRepository = userRepository;
        _activityRepository = activityRepository;
    }

    public async Task<List<ClientDto>> GetClientsEnrolledInMyActivities(int professorId)
    {
        var professor = await _userRepository.GetProfessorByIdAsync(professorId);

        if (professor == null)
        {
            throw new KeyNotFoundException($"Professor with ID {professorId} not found.");
        }

        var activities = await _activityRepository.GetActivitiesByProfessorIdAsync(professorId);
        var clients = activities.SelectMany(a => a.Enrollments)
                                .Select(e => new ClientDto
                                {
                                    Id = e.Client.Id,
                                    Name = e.Client.Name,
                                    UserName = e.Client.UserName,
                                }).ToList();

        return clients;
    }
}


