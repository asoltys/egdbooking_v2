namespace egdbooking_v2.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Company
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(Order = 1)]
        [StringLength(75)]
        public string Name { get; set; }

        public string Address { get; set; }
        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string Province { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(15)]
        public string Zip { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }

        [Column(Order = 2)]
        public bool Approved { get; set; }

        [Column(Order = 3)]
        public bool Deleted { get; set; }

        [StringLength(3)]
        public string Abbreviation { get; set; }

        [StringLength(32)]
        public string Fax { get; set; }

        public virtual ICollection<UserCompany> UserCompanies { get; set; }
        public virtual ICollection<VesselCompany> VesselCompanies { get; set; }
    }
}
