

namespace Domain.Entities
{
    public class Owner : User
    {
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Professor> Professors { get; set; } = new List<Professor>();
    }
}
