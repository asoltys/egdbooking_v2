namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.Jetties")]
    public partial class Jetty
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BRID { get; set; }

        public bool? NorthJetty { get; set; }

        public bool? SouthJetty { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Status { get; set; }
    }
}
