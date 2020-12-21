using System;
using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class MemberModel : ProfileModel<MemberModel>
    {
        // ======================================= //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        // ======================================= //
        public int? UserId { get; set; }
        public virtual PoochModel Pooch { get; set; }
        public virtual ICollection<AppointmentModel> Appointments { get; set; }
        public virtual ICollection<ActivityModel> Connections { get; set; }
        // ======================================= //
        public MemberModel() { }
        public MemberModel(string firstName, string lastName, string email, string gender, string picture, bool isActive, string details, int age, DateTime? created = null) : base(age, gender, picture, isActive, $"{firstName} {lastName}", details)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}