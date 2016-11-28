namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VesselCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vessel_id { get; set; }

        public int? company_id { get; set; }
    }
}
