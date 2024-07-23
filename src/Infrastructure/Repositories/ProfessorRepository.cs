using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : EfRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Client> GetClientsEnrolledInMyActivities(int professorId)
        {
            var professor = _appDbContext.Professors
                .Include(p => p.Activities)
                .ThenInclude(a => a.Enrollments)
                .ThenInclude(e => e.Client)
                .SingleOrDefault(p => p.Id == professorId);

            if (professor == null)
            {
                throw new KeyNotFoundException($"Professor with ID {professorId} not found.");
            }

            return professor.Activities.SelectMany(a => a.Enrollments.Select(e => e.Client)).ToList();
        }
    }
}
