﻿// <auto-generated />
using System;
using Core.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationData))]
    partial class ApplicationDataModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("Core.Shared.Entities.AppointmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActiveLast")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActiveSince")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PoochId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScheduleModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PoochId");

                    b.HasIndex("ScheduleModelId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.ActivityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActiveLast")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActiveSince")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PoochModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PoochModelId");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.MemberModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActiveLast")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActiveSince")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PoochId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PoochId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.PoochModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActiveLast")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActiveSince")
                        .HasColumnType("TEXT");

                    b.Property<string>("Breed")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pooches");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.ScheduleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActiveLast")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActiveSince")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Core.Shared.Models.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Core.Shared.Models.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Core.Shared.Models.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Core.Shared.Entities.AppointmentModel", b =>
                {
                    b.HasOne("Core.Shared.Models.Entities.MemberModel", "Owner")
                        .WithMany("Appointments")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Core.Shared.Models.Entities.PoochModel", "Pooch")
                        .WithMany("Appointments")
                        .HasForeignKey("PoochId");

                    b.HasOne("Core.Shared.Models.Entities.ScheduleModel", null)
                        .WithMany("Appointments")
                        .HasForeignKey("ScheduleModelId");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.ActivityModel", b =>
                {
                    b.HasOne("Core.Shared.Models.Entities.MemberModel", "Member")
                        .WithMany("Connections")
                        .HasForeignKey("MemberId");

                    b.HasOne("Core.Shared.Models.Entities.PoochModel", null)
                        .WithMany("Connections")
                        .HasForeignKey("PoochModelId");
                });

            modelBuilder.Entity("Core.Shared.Models.Entities.MemberModel", b =>
                {
                    b.HasOne("Core.Shared.Models.Entities.PoochModel", "Pooch")
                        .WithMany()
                        .HasForeignKey("PoochId");
                });

            modelBuilder.Entity("Core.Shared.Models.Identity.UserRole", b =>
                {
                    b.HasOne("Core.Shared.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Shared.Models.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("Core.Shared.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Shared.Models.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Core.Shared.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Core.Shared.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Core.Shared.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Core.Shared.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}