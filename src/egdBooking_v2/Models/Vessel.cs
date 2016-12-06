namespace egdbooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Vessel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        [StringLength(20)]
        public string LloydsId { get; set; }

        public double? Tonnage { get; set; }

        public bool Anonymous { get; set; }

        public bool Deleted { get; set; }

        public DateTime? EndHighlight { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<VesselCompany> VesselCompanies { get; set; }
    }
}
