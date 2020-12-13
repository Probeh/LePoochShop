using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class MemberModel : ProfileModel<MemberModel>
    {
        // ======================================= //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // ======================================= //
        public int? PoochId { get; set; }
        public virtual PoochModel Pooch { get; set; }
        public virtual ICollection<AppointmentModel> Appointments { get; set; }
        // ======================================= //
    }
}