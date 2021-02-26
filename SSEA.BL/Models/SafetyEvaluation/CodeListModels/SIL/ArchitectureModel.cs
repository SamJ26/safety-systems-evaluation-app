using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class ArchitectureModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public bool Logic { get; set; }
        public bool Diagnostic { get; set; }
        public short Channels { get; set; }
        public double MinSFF { get; set; }
        public double MaxSFF { get; set; }
        public short HFT { get; set; }
        public PFHdModel MaxPFHd { get; set; }
    }
}
