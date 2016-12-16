using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egdbooking_v2.ViewModels
{
    public class FormViewModel
    {
        // Left side
        public string DrydockDates { get; set; }
        public string DrydockPurpose { get; set; }
        public string BerthageDates { get; set; }
        public string BerthagePurpose { get; set; }
        public string MasterName { get; set; }
        public string AgentName { get; set; }
        public string DockmasterName { get; set; }
        public string OverallLength { get; set; }
        public string ExtremeBreadth { get; set; }
        public string AftDraft { get; set; }
        public string Engines { get; set; }
        public string Keel { get; set; }
        public string ExplosiveMatter { get; set; }

        // Right side
        public string VesselName { get; set; }
        public string OwnerName { get; set; }
        public string RegistryPort { get; set; }
        public string OwnerAddress { get; set; }
        public string MasterAddress { get; set; }
        public string AgentAddress { get; set; }
        public string GrossTonnage { get; set; }
        public string PerpendicularsLength { get; set; }
        public string ForwardDraft { get; set; }
        public string VesselType { get; set; }
        public string FuelType { get; set; }
        public string FloorRiseAmidships { get; set; }

        public string DangerousGoods { get; set; }
        public string OilLeak { get; set; }
        public string SpecialFeatures { get; set; }
        public string AdditionalLength { get; set; }

    }
}
