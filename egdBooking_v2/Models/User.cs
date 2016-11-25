namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("egdbooking.Users")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Deleted { get; set; }

        [StringLength(50)]
        public string ReadOnly { get; set; }

        public bool? notice_acknowledged { get; set; }
    }
}
