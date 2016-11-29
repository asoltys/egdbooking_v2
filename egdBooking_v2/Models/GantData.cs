using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace egdBooking_v2.Models
{
    public class GantData
    {
        public GantData(BookingContext db)
        {
            rows = new List<List<Booking>>();
            SectionOne = db.Bookings.Where(b => b.Section1 == true).ToList();
            SectionTwo = db.Bookings.Where(b => b.Section2 == true).ToList();
            SectionThree = db.Bookings.Where(b => b.Section3 == true).ToList();
            NorthJetty = db.Bookings.Where(b => b.NorthJetty == true).ToList();
            SouthJetty = db.Bookings.Where(b => b.SouthJetty == true).ToList();

            rows.Add(SectionOne);
            rows.Add(SectionTwo);
            rows.Add(SectionThree);
            rows.Add(NorthJetty);
            rows.Add(SouthJetty);
        }
        public List<List<Booking>> rows { get; set; }

        public string Name { get; set; }
        
        private List<Booking> SectionOne { get; set; }
        private List<Booking> SectionTwo { get; set; }
        private List<Booking> SectionThree { get; set; }
        private List<Booking> NorthJetty { get; set; }
        private List<Booking> SouthJetty { get; set; }
    }
}
