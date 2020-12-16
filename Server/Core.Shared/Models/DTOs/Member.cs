using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class MemberDTO : RegisterDTO
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}