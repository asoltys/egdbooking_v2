namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vessel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? BlockSetupTime { get; set; }

        public double? BlockTeardownTime { get; set; }

        [StringLength(20)]
        public string LloydsID { get; set; }

        public double? Tonnage { get; set; }

        public bool Anonymous { get; set; }

        public bool Deleted { get; set; }

        public DateTime? EndHighlight { get; set; }
    }
}
