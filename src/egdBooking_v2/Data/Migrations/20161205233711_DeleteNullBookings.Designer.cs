using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161205233711_DeleteNullBookings")]
    partial class DeleteNullBookings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("egdbooking_v2.Models.Administrator", b =>
                {
                    b.Property<int>("UserId");

                    b.HasKey("UserId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("egdbooking_v2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("egdbooking_v2.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BookingTime");

                    b.Property<DateTime?>("BookingTimeChange");

                    b.Property<string>("BookingTimeChangeStatus")
                        .HasMaxLength(100);

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime?>("EndHighlight");

                    b.Property<bool?>("NorthJetty");

                    b.Property<bool?>("Section1");

                    b.Property<bool?>("Section2");

                    b.Property<bool?>("Section3");

                    b.Property<bool?>("SouthJetty");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status")
                        .HasMaxLength(2);

                    b.Property<int>("UserId");

                    b.Property<int>("VesselId");

                    b.HasKey("Id");

                    b.HasIndex("VesselId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("egdbooking_v2.Models.Company", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(3);

                    b.Property<string>("Address1")
                        .HasMaxLength(75);

                    b.Property<string>("Address2")
                        .HasMaxLength(75);

                    b.Property<bool>("Approved");

                    b.Property<string>("City")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .HasMaxLength(40);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Fax")
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .HasMaxLength(75);

                    b.Property<string>("Name_f")
                        .HasMaxLength(75);

                    b.Property<string>("Phone")
                        .HasMaxLength(32);

                    b.Property<string>("Province")
                        .HasMaxLength(40);

                    b.Property<string>("Zip")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("egdbooking_v2.Models.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BookFee");

                    b.Property<int>("BookingId");

                    b.Property<bool>("CargoDockage");

                    b.Property<bool>("CargoStore");

                    b.Property<bool>("Commissionaire");

                    b.Property<bool>("CompressPortable");

                    b.Property<bool>("CompressPrimary");

                    b.Property<bool>("CompressSecondary");

                    b.Property<bool>("CraneBigHook");

                    b.Property<bool>("CraneGrove");

                    b.Property<bool>("CraneHyster");

                    b.Property<bool>("CraneLightHook");

                    b.Property<bool>("CraneMedHook");

                    b.Property<bool>("Electric");

                    b.Property<bool>("Forklift");

                    b.Property<bool>("FreshH2O");

                    b.Property<bool>("FullDrain");

                    b.Property<bool>("LightsCaisson");

                    b.Property<bool>("LightsStandard");

                    b.Property<bool>("NonworkVesselBerthNorth");

                    b.Property<bool>("Other");

                    b.Property<string>("OtherText")
                        .HasMaxLength(1000);

                    b.Property<bool>("OvertimeLabour");

                    b.Property<bool>("TieUp");

                    b.Property<bool>("TopWharfage");

                    b.Property<bool>("Tug");

                    b.Property<bool>("VesselBerthSouth");

                    b.Property<bool>("VesselDockage");

                    b.Property<bool>("WorkVesselBerthNorth");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("egdbooking_v2.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Role")
                        .HasMaxLength(50);

                    b.Property<bool?>("SeenNotice");

                    b.HasKey("Id");

                    b.ToTable("EGDUsers");
                });

            modelBuilder.Entity("egdbooking_v2.Models.Vessel", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Anonymous");

                    b.Property<double?>("BlockSetupTime");

                    b.Property<double?>("BlockTeardownTime");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("EndHighlight");

                    b.Property<double?>("Length");

                    b.Property<string>("LloydsId")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double?>("Tonnage");

                    b.Property<double?>("Width");

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("egdbooking_v2.Models.Booking", b =>
                {
                    b.HasOne("egdbooking_v2.Models.Vessel", "Vessel")
                        .WithMany("Bookings")
                        .HasForeignKey("VesselId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("egdbooking_v2.Models.Tariff", b =>
                {
                    b.HasOne("egdbooking_v2.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("egdbooking_v2.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("egdbooking_v2.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("egdbooking_v2.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
