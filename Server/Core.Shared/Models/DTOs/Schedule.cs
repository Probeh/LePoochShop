namespace Core.Shared.Models.DTOs
{
    public class ScheduleDTO : BaseDTO<ScheduleDTO>
    {
        // ======================================= //
        public ScheduleDTO(int? id) : base(id) { }
        // ======================================= //
        public override ScheduleDTO FromSource<TSource>(TSource source) => this;
    }
}