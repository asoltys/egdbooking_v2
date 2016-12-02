using egdbooking_v2.Models;
using System.Collections.Generic;

namespace egdbooking_v2.ViewModels
{
    public class BookingsViewModel
    {
        public DockViewModel Drydock;
        public DockViewModel NorthJetty;
        public DockViewModel SouthJetty;
        public IEnumerable<DockViewModel> Docks;

        public BookingsViewModel(string drydock, string north, string south)
        {
            Drydock = new DockViewModel(drydock);
            NorthJetty = new DockViewModel(north);
            SouthJetty = new DockViewModel(south);

            Docks = new List<DockViewModel> { Drydock, NorthJetty, SouthJetty };
        }
    }

    public class DockViewModel
    {
        public IEnumerable<Booking> Bookings;
        public string DockName;

        public DockViewModel(string dock)
        {
            Bookings = new List<Booking>();
            DockName = dock;
        }
    }
}