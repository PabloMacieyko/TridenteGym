using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
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

    public async Task<ProfessorDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null || user.Role != UserRole.Professor)
            return null;

        return new ProfessorDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            UserName = user.UserName,
            Password = user.Password
        };
    }

    public async Task<List<ClientDto>> GetClientsEnrolledInMyActivities(int professorId)
    {
        // Validar que el usuario es un profesor usando el método correcto
        var professor = await _userRepository.GetByIdAsync(professorId);
        if (professor == null || professor.Role != UserRole.Professor)
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


