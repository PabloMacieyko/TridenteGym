
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests
{
    public class EnrollmentCreateRequest
    {
        [Required]
        public int ActivityId { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
