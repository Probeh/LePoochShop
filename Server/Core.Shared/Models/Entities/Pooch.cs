using System;
using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class PoochModel : ProfileModel<PoochModel>
    {
        // ======================================= //
        public int? BreedId { get; set; }
        public int? OwnerId { get; set; }
        // ======================================= //
        public virtual BreedModel Breed { get; set; }
        public virtual MemberModel Owner { get; set; }
        public virtual ICollection<AppointmentModel> Appointments { get; set; }
        // ======================================= //
        public PoochModel() { }
        public PoochModel(int age, string gender, bool isActive, string title, string details, string picture = null, DateTime? created = null) : base(age, gender, picture, isActive, title, details, created) { }
    }
}