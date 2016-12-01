namespace egdbooking_v2.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public bool Deleted { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public bool? SeenNotice { get; set; }
    }
}
