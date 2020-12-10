using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Shared.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}