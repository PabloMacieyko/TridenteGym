using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty; //string.Empty para que sea vacio y nunca null
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }
        /// Propiedad de navegación para las actividades que enseña el profesor
        public ICollection<Enrollment> Enrollments { get; set; } 
    }

    public enum UserRole
    {
        Client,
        Owner,
        Professor,
    }
}
