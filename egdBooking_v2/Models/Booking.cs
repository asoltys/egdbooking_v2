namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.Bookings")]
    public partial class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? VNID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime BookingTime { get; set; }

        public int UID { get; set; }

        public bool Deleted { get; set; }

        public DateTime? EndHighlight { get; set; }

        public DateTime? BookingTimeChange { get; set; }

        [StringLength(100)]
        public string BookingTimeChangeStatus { get; set; }
    }
}
