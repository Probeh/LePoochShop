namespace Core.Shared.Models.Entities
{
    public class ActivityModel : BaseModel<ActivityModel>
    {
        // ======================================= //
        public int? MemberId { get; set; }
        public virtual MemberModel Member { get; set; }
        // ======================================= //
    }
}