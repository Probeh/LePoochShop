using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Shared.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}