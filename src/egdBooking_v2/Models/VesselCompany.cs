namespace egdbooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class VesselCompany
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int VesselId { get; set; }
        public Vessel Vessel { get; set; }
    }
}
