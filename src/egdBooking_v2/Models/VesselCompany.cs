namespace egdbooking_v2.Models
{
    public partial class VesselCompany
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int VesselId { get; set; }
        public Vessel Vessel { get; set; }
    }
}
