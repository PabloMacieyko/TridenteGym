using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public ProfessorRepository(ApplicationDbContext appdbcontex)
        {
            _appDbContext = appdbcontex;
        }

        public Professor Create(Professor professor)
        {
            var result = _appDbContext.Professors.Add(professor);
            _appDbContext.SaveChanges();

            return result.Entity;
        }

        public void Delete(int id)
        {
            var professor = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            if (professor == null)
                throw new Exception("Profesor no encontrado");

            _appDbContext.Professors.Remove(professor);
            _appDbContext.SaveChanges();
        }

        public Professor Get(int id)
    {
            return _appDbContext.Professors.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Profesor no encontrado");
        }

        public IList<Professor> GetAll()
        {
            return _appDbContext.Professors.ToList();
        }

        public ICollection<Client> GetClientsEnrolledInMyActivities(int professorId)
        {
            throw new NotImplementedException(); 
        }

        public Professor Update(Professor professor, int id)
        {
            var result = _appDbContext.Professors.FirstOrDefault(x => x.Id == id);
            if (result == null)
                throw new Exception("Profesor no encontrado");
            else
            {
                result.Name = professor.Name;
                result.Email = professor.Email;
                result.Password = professor.Password;
            }
            _appDbContext.Professors.Update(professor);
            _appDbContext.SaveChanges();

            return result;
        }
    }
}
