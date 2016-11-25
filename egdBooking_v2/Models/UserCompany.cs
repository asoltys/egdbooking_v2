namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.UserCompanies")]
    public partial class UserCompany
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CID { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Approved { get; set; }
    }
}
