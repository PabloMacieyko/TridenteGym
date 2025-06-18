using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }
        public int Price { get; set; }
        // Propiedad de navegación para el profesor que enseña esta actividad
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        // Relación uno a muchos con Enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        [Range(0, int.MaxValue, ErrorMessage = "AvailableSlots debe ser mayor o igual a cero.")]
        public int AvailableSlots { get; set; }
    }
}
