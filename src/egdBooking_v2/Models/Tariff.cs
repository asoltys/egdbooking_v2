namespace egdbooking_v2.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Tariff
    {
        [Key]
        public int ID { get; set; }
        
        public int BookingID { get; set; }

        public bool BookFee { get; set; }

        public bool FullDrain { get; set; }

        public bool VesselDockage { get; set; }

        public bool CargoDockage { get; set; }

        public bool WorkVesselBerthNorth { get; set; }

        public bool NonworkVesselBerthNorth { get; set; }

        public bool VesselBerthSouth { get; set; }

        public bool CargoStore { get; set; }

        public bool TopWharfage { get; set; }

        public bool CraneLightHook { get; set; }

        public bool CraneMedHook { get; set; }

        public bool CraneBigHook { get; set; }

        public bool CraneHyster { get; set; }

        public bool CraneGrove { get; set; }

        public bool Forklift { get; set; }

        public bool CompressPrimary { get; set; }

        public bool CompressSecondary { get; set; }

        public bool CompressPortable { get; set; }

        public bool Tug { get; set; }

        public bool FreshH2O { get; set; }

        public bool Electric { get; set; }

        public bool TieUp { get; set; }

        public bool Commissionaire { get; set; }

        public bool OvertimeLabour { get; set; }

        public bool LightsStandard { get; set; }

        public bool LightsCaisson { get; set; }

        [StringLength(1000)]
        public string OtherText { get; set; }

        public bool Other { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
