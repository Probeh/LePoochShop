using System;
using System.Collections.Generic;
using Core.Shared.Entities;

namespace Core.Shared.Models.Entities
{
    public class ProfileModel<T> : BaseModel<ProfileModel<T>>
    {
        // ======================================= //
        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        // ======================================= //
        public virtual ICollection<ActivityModel> Connections { get; set; }
        // ======================================= //
    }
}