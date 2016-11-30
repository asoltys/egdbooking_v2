namespace egdBooking_v2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingContext : DbContext
    {
        public BookingContext()
            : base("name=BookingContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<UserCompany> UserCompanies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vessel> Vessels { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<VesselCompany> VesselCompanies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingTimeChangeStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Vessel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Vessel>()
                .Property(e => e.LloydsID)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name_f)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Province)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<Tariff>()
                .Property(e => e.OtherText)
                .IsUnicode(false);
        }
    }
}