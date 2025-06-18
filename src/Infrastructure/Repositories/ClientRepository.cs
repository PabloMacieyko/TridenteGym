using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Activity>> GetClientActivities(int clientId)
        {
            // Busca el usuario y valida que sea Client
            var user = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == clientId && u.Role == UserRole.Client);

            if (user == null)
                throw new KeyNotFoundException($"Client with ID {clientId} not found.");

            // Busca las actividades en las que está inscripto
            var activities = await _appDbContext.Enrollments
                .Where(e => e.ClientId == clientId)
                .Include(e => e.Activity) // <-- Esto es importante
                .Select(e => e.Activity)
                .ToListAsync();

            return activities;
        }
    }
}
