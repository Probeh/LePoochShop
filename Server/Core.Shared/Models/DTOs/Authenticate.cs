using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.DTOs
{
    public class AuthenticateDTO : BaseDTO<AuthenticateDTO>
    {
        [Required, MinLength(4)]
        public string UserName { get; set; }
        // ======================================= //
        public AuthenticateDTO(int? id) : base(id) { }
        // ======================================= //
        public override AuthenticateDTO FromSource<TSource>(TSource source) => this;
    }
}