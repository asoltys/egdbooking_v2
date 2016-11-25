namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.Docks")]
    public partial class Dock
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BRID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Section1 { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Section2 { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Section3 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string Status { get; set; }
    }
}
