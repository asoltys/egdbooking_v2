using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using egdbooking_v2.Models;

namespace egdbooking_v2.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Booking>()
                .Property(e => e.BookingTimeChangeStatus);

            builder.Entity<Booking>()
                .Property(e => e.Status);

            builder.Entity<User>()
                .Property(e => e.FirstName);

            builder.Entity<User>()
                .Property(e => e.LastName);

            builder.Entity<User>()
                .Property(e => e.Password);

            builder.Entity<User>()
                .Property(e => e.Email);

            builder.Entity<User>()
                .Property(e => e.Role);

            builder.Entity<Vessel>()
                .Property(e => e.Name);

            builder.Entity<Vessel>()
                .Property(e => e.LloydsID);

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
                .Property(e => e.OtherText);
        }
    }
}
