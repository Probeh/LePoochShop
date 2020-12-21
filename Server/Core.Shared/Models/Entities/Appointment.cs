using System;

namespace Core.Shared.Models.Entities
{
    public class AppointmentModel : BaseModel<AppointmentModel>
    {
        public DateTime? Date { get; set; }
        public int? MemberId { get; set; }
        public int? PoochId { get; set; }
        // ======================================= //
        public MemberModel Member { get; set; }
        public PoochModel Pooch { get; set; }
        // ======================================= //
        public AppointmentModel() { }
        public AppointmentModel(string title, string details, bool isActive = true, DateTime? created = null) : base(isActive, title, details, created) { }
    }
}