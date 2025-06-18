using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests
{
    public class ActivityCreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ProfessorId { get; set; }
        public int Price { get; set; }
        public int AvailableSlots { get; set; }

    }
}
