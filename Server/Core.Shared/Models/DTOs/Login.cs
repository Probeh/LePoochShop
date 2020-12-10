using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class LoginDTO : BaseDTO<LoginDTO>
    {
        // ======================================= //
        [Required, MinLength(4)]
        public string UserName { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }
        // ======================================= //
        public LoginDTO(int? id) : base(id) { }
        // ======================================= //
        public override LoginDTO FromSource<TSource>(TSource source) => this;
    }
}