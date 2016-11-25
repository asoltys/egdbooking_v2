namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.TariffFees")]
    public partial class TariffFee
    {
        public int? Item { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public string ServiceE { get; set; }

        [StringLength(15)]
        public string Fee { get; set; }

        [StringLength(200)]
        public string ServiceF { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sequence { get; set; }

        [StringLength(50)]
        public string Abbreviation { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Flex { get; set; }
    }
}
