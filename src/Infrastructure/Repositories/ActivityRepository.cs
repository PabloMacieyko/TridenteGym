using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : EfRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Activity>> GetActivitiesByProfessorIdAsync(int professorId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Activities
                .Where(activity => activity.ProfessorId == professorId)
                .ToListAsync(cancellationToken);
        }
    }
}
