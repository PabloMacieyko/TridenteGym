using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProfessorService
    {
        Task<List<ClientDto>> GetClientsEnrolledInMyActivities(int professorId);
        Task<ProfessorDto?> GetByIdAsync(int id);
    }
}