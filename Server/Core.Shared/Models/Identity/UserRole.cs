using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core.Shared.Models.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        // ======================================= //
        public Role Role { get; set; }
        public User User { get; set; }
        // ======================================= //
    }
}