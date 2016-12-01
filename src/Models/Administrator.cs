namespace egdBooking_v2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Administrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UID { get; set; }
    }
}
