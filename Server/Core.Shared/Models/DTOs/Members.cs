namespace Core.Shared.Models.DTOs
{
    public class MembersDTO : BaseDTO<MembersDTO>
    {
        // ======================================= //
        public MembersDTO(int? id) : base(id) { }
        // ======================================= //
        public override MembersDTO FromSource<TSource>(TSource source) => this;
    }
}