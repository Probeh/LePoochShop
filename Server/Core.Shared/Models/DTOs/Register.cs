using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        // ======================================= //
        [Required, EmailAddress]
        public string Email { get; set; }
        // ======================================= //
    }
}