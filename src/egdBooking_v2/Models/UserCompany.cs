namespace egdbooking_v2.Models
{
    public partial class UserCompany 
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
