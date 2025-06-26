
namespace Domain.Entities
{
    public class Client : User
    {
        //relacion con enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
