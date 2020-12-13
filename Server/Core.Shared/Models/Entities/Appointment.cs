namespace Core.Shared.Models.Entities
{
    public class AppointmentModel : BaseModel<AppointmentModel>
    {
        // ======================================= //
        public int? OwnerId { get; set; }
        public int? PoochId { get; set; }
        // ======================================= //
        public MemberModel Owner { get; set; }
        public PoochModel Pooch { get; set; }
    }
}