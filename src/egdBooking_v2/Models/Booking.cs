namespace egdbooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Resources;

    public partial class Booking
    {
        public int Id { get; set; }

        public int VesselId { get; set; }

        public DateTime StartDate { get; set; }
        public string FormattedStartDate { get { return this.StartDate.ToString(Resources.AbbrevDate); } }

        public DateTime EndDate { get; set; }
        public string FormattedEndDate { get { return this.EndDate.ToString(Resources.AbbrevDate); } }

        public DateTime BookingTime { get; set; }
        public string FormattedBookingDate { get { return this.BookingTime.ToString(Resources.AbbrevDate); } }

        public int UserId { get; set; }

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

        public string Sections
        {
            get
            {
                string returnstr = "";

                if ((NorthJetty.HasValue && NorthJetty == true) || (SouthJetty.HasValue && SouthJetty == true))
                {
                    returnstr = Resources.Booked;
                }
                else
                {
                    bool?[] sections = { Section1, Section2, Section3 };
                    for (int i = 0; i < sections.Length; i++)
                    {
                        if (sections[i].HasValue && sections[i] == true)
                        {
                            if (returnstr.Length > 0)
                            {
                                returnstr += " & ";
                            }
                            returnstr += (i + 1).ToString();
                        }
                    }
                }
                return returnstr;
            }
        }

        [StringLength(2)]
        public string Status { get; set; }

        public virtual Vessel Vessel { get; set; }
    }
}
