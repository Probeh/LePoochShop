using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Shared.Models.Entities;
using Core.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Shared.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        // ======================================= //
        public DbSet<ActivityModel> ActivityLogs { get; set; }
        public DbSet<PoochModel> Pooches { get; set; }
        public DbSet<BreedModel> Breeds { get; set; }
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        // ======================================= //
        public ApplicationContext(DbContextOptions options) : base(options) { }
        // ======================================= //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        // ======================================= //

    }
}