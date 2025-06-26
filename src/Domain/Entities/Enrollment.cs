using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; } // accede a los datos de la actividad

        public int ClientId { get; set; }
        public User Client { get; set; }
    }
}