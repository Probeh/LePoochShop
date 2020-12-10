namespace Core.Shared.Models.DTOs
{
    public class UserProfileDTO : BaseDTO<UserProfileDTO>
    {
        // ======================================= //
        public UserProfileDTO(int? id) : base(id) { }
        // ======================================= //
        public override UserProfileDTO FromSource<TSource>(TSource source) => this;
    }
}