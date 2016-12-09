using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using egdbooking_v2.Models;

namespace egdbooking_v2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> EGDUsers { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<Vessel> Vessels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Booking>()
                .Property(e => e.BookingTimeChangeStatus);

            builder.Entity<Booking>()
                .Property(e => e.Status);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "AspNetUsers");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Password);
                entity.Property(e => e.Email);
                entity.Property(e => e.Role);
            });

            builder.Entity<Vessel>()
                .Property(e => e.Name);

            builder.Entity<Vessel>()
                .Property(e => e.LloydsId);

            builder.Entity<Company>()
                .Property(e => e.Name);

            builder.Entity<Company>()
                .Property(e => e.Name_f);

            builder.Entity<Company>()
                .Property(e => e.Address1);

            builder.Entity<Company>()
                .Property(e => e.Address2);

            builder.Entity<Company>()
                .Property(e => e.City);

            builder.Entity<Company>()
                .Property(e => e.Province);

            builder.Entity<Company>()
                .Property(e => e.Country);

            builder.Entity<Company>()
                .Property(e => e.Zip);

            builder.Entity<Company>()
                .Property(e => e.Phone);

            builder.Entity<Company>()
                .Property(e => e.Abbreviation);

            builder.Entity<Company>()
                .Property(e => e.Fax);

            builder.Entity<Tariff>()
                .Property(e => e.Id);

            builder.Entity<Tariff>()
                .Property(e => e.OtherText);

            builder.Entity<UserCompany>()
                .HasKey(t => new { t.CompanyId, t.UserId});

            builder.Entity<UserCompany>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserCompanies)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserCompany>()
                .HasOne(p => p.Company)
                .WithMany(p => p.UserCompanies)
                .HasForeignKey(p=> p.CompanyId);

            builder.Entity<VesselCompany>()
                .HasKey(t => new { t.CompanyId, t.VesselId});

            builder.Entity<VesselCompany>()
                .HasOne(p => p.Vessel)
                .WithMany(p => p.VesselCompanies)
                .HasForeignKey(p => p.VesselId);

            builder.Entity<VesselCompany>()
                .HasOne(p => p.Company)
                .WithMany(p => p.VesselCompanies)
                .HasForeignKey(p => p.CompanyId);

            builder.Entity<Booking>()
                .HasOne(e => e.Vessel)
                .WithMany(e => e.Bookings)
                .HasForeignKey(e => e.VesselId);
        }
    }
}
