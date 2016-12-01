namespace egdBooking_v2.Models
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class ApplicationDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vessel> Vessels { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingTimeChangeStatus);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Status);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName);

            modelBuilder.Entity<User>()
                .Property(e => e.Password);

            modelBuilder.Entity<User>()
                .Property(e => e.Email);

            modelBuilder.Entity<User>()
                .Property(e => e.Role);

            modelBuilder.Entity<Vessel>()
                .Property(e => e.Name);

            modelBuilder.Entity<Vessel>()
                .Property(e => e.LloydsID);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name_f);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address1);

            modelBuilder.Entity<Company>()
                .Property(e => e.Address2);

            modelBuilder.Entity<Company>()
                .Property(e => e.City);

            modelBuilder.Entity<Company>()
                .Property(e => e.Province);

            modelBuilder.Entity<Company>()
                .Property(e => e.Country);

            modelBuilder.Entity<Company>()
                .Property(e => e.Zip);

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone);

            modelBuilder.Entity<Company>()
                .Property(e => e.Abbreviation);

            modelBuilder.Entity<Company>()
                .Property(e => e.Fax);

            modelBuilder.Entity<Tariff>()
                .Property(e => e.OtherText);
        }
    }
}
