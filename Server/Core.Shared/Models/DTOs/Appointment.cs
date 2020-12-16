using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class AppointmentDTO : BaseDTO
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int MemberId { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}