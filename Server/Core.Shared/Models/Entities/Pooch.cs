using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class PoochModel : ProfileModel<PoochModel>
    {
        // ======================================= //
        public string Breed { get; set; }
        public int? OwnerId { get; set; }
        public virtual ICollection<AppointmentModel> Appointments { get; set; }
        // ======================================= //
    }
}