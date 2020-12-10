using Core.Shared.Models.Entities;

namespace Core.Shared.Entities
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