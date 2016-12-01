namespace egdBooking_v2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Company
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(Order = 1)]
        [StringLength(75)]
        public string Name { get; set; }

        [StringLength(75)]
        public string Name_f { get; set; }

        [StringLength(75)]
        public string Address1 { get; set; }

        [StringLength(75)]
        public string Address2 { get; set; }

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
    }
}