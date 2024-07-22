using Domain.Entities;

namespace Application.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int ActivityId { get; set; }
        public int ClientId { get; set; }

    }
}
