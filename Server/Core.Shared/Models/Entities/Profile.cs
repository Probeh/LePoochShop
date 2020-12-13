using System;
using System.Collections.Generic;

namespace Core.Shared.Models.Entities
{
    public class ProfileModel<TSource> : BaseModel<TSource> where TSource : BaseModel<TSource>
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