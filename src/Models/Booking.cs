namespace egdbooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
        public int ID { get; set; }

        public int VesselID { get; set; }

        public DateTime StartDate { get; set; }
        public string FormattedStartDate { get { return this.StartDate.ToString(Resources.AbbrevDate); } }

        public DateTime EndDate { get; set; }
        public string FormattedEndDate { get { return this.EndDate.ToString(Resources.AbbrevDate); } }

        public DateTime BookingTime { get; set; }
        public string FormattedBookingDate { get { return this.BookingTime.ToString(Resources.AbbrevDate); } }

        public int UID { get; set; }

        public bool Deleted { get; set; }

        public DateTime? EndHighlight { get; set; }

        public DateTime? BookingTimeChange { get; set; }

        [StringLength(100)]
        public string BookingTimeChangeStatus { get; set; }

        public bool? Section1 { get; set; }

        public bool? Section2 { get; set; }

        public bool? Section3 { get; set; }

        public bool? NorthJetty { get; set; }

        public bool? SouthJetty { get; set; }

        public List<string> Sections {
            get {
                List<string> sections = new List<string>();
                if (Section1.HasValue) {
                    if ((bool)Section1) {
                        sections.Add("Section 1");
                    }
                }
                if (Section2.HasValue)
                {
                    if ((bool)Section2)
                    {
                        sections.Add("Section 2");
                    }
                }
                if (Section3.HasValue)
                {
                    if ((bool)Section3)
                    {
                        sections.Add("Section 3");
                    }
                }

                return sections;
            }
        }

        [StringLength(2)]
        public string Status { get; set; }

        public virtual Vessel Vessel { get; set; }
    }
}
