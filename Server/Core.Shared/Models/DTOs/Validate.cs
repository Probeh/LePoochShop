using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class ValidateDTO
    {
        [Required, MinLength(4)]
        public string UserName { get; set; }
    }
}