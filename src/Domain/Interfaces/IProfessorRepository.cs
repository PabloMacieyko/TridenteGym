using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfessorRepository : IRepositoryBase<Professor>
    {
        Task<List<Activity>> GetAssignedActivitiesAsync(int professorId, CancellationToken cancellationToken = default);
    }
}
