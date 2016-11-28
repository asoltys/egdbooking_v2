namespace egdBooking_v2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TariffForm
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BRID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool BookFee { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool FullDrain { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool VesselDockage { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool CargoDockage { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool WorkVesselBerthNorth { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool NonworkVesselBerthNorth { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool VesselBerthSouth { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool CargoStore { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool TopWharfage { get; set; }

        [Key]
        [Column(Order = 10)]
        public bool CraneLightHook { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool CraneMedHook { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool CraneBigHook { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool CraneHyster { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool CraneGrove { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool Forklift { get; set; }

        [Key]
        [Column(Order = 16)]
        public bool CompressPrimary { get; set; }

        [Key]
        [Column(Order = 17)]
        public bool CompressSecondary { get; set; }

        [Key]
        [Column(Order = 18)]
        public bool CompressPortable { get; set; }

        [Key]
        [Column(Order = 19)]
        public bool Tug { get; set; }

        [Key]
        [Column(Order = 20)]
        public bool FreshH2O { get; set; }

        [Key]
        [Column(Order = 21)]
        public bool Electric { get; set; }

        [Key]
        [Column(Order = 22)]
        public bool TieUp { get; set; }

        [Key]
        [Column(Order = 23)]
        public bool Commissionaire { get; set; }

        [Key]
        [Column(Order = 24)]
        public bool OvertimeLabour { get; set; }

        [Key]
        [Column(Order = 25)]
        public bool LightsStandard { get; set; }

        [Key]
        [Column(Order = 26)]
        public bool LightsCaisson { get; set; }

        [StringLength(1000)]
        public string OtherText { get; set; }

        [Key]
        [Column(Order = 27)]
        public bool Other { get; set; }
    }
}
