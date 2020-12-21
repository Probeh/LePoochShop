using System;

namespace Core.Shared.Models.Entities
{
    public class ActivityModel : BaseModel<ActivityModel>
    {
        // ======================================= //
        public int? MemberId { get; set; }
        public virtual MemberModel Member { get; set; }
        // ======================================= //
        public ActivityModel(int? memberId, bool isActive, string title, string details, DateTime? created = null) : base(isActive, title, details, DateTime.Now)
        {
            MemberId = memberId;
        }
    }
}