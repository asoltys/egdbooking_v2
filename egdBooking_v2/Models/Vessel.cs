namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.Vessels")]
    public partial class Vessel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VNID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Name { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public double? BlockSetupTime { get; set; }

        public double? BlockTeardownTime { get; set; }

        [StringLength(20)]
        public string LloydsID { get; set; }

        public double? Tonnage { get; set; }

        public int? CID { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Anonymous { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Deleted { get; set; }

        public DateTime? EndHighlight { get; set; }
    }
}
