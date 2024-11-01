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

        public Activity Activity { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}