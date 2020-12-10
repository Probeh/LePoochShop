namespace Core.Shared.Models.DTOs
{
    public class AppointmentDTO : BaseDTO<AppointmentDTO>
    {
        // ======================================= //
        public AppointmentDTO(int? id) : base(id) { }
        // ======================================= //
        public override AppointmentDTO FromSource<TSource>(TSource source) => this;
    }
}