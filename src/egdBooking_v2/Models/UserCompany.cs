namespace egdbooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserCompany 
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
