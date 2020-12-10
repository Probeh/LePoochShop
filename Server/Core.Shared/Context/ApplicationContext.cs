using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Shared.Entities;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Identity;

namespace Core.Shared.Context
{
    public delegate void ContextChanged(KeyValuePair<string, string> target /* () => Scope, Action */ , KeyValuePair<string, string> items, string text);
    public class ApplicationData : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        // ======================================= //
        public static event ContextChanged ContextListener;
        // ======================================= //
        public DbSet<ActivityModel> ActivityLogs { get; set; }
        public DbSet<PoochModel> Pooches { get; set; }
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        // ======================================= //
        public ApplicationData(DbContextOptions options) : base(options) { }
        // ======================================= //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);
        // ======================================= //
        public static void UpdateListeners(KeyValuePair<string, string> target, KeyValuePair<string, string> items, string text) => ContextListener?.Invoke(target, items, text);
    }
}