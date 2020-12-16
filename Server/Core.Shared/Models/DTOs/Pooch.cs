using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class PoochDTO : BaseDTO
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int MemberId { get; set; }

    }
}