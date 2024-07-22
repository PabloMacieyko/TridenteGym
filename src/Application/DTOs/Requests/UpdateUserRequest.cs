using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Requests
{
    public class UpdateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
