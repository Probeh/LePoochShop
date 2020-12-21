using System.Collections.Generic;
using Core.Shared.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Shared.Models.Identity
{
    public class User : IdentityUser<int>
    {
        // ======================================= //
        public int? MemberId { get; set; }
        public virtual MemberModel Member { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        // ======================================= //
    }
}