using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class User  //porque abstract?
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string Password { get; set; }
    }
}
