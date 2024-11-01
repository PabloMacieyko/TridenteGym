
namespace Domain.Entities
{
    public class Client : User
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
