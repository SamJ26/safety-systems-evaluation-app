using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class ArchitectureModel : ModelBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool Logic { get; set; }
        public bool Diagnostic { get; set; }
        public short Channels { get; set; }
        public double SFF_min { get; set; }
        public double SFF_max { get; set; }

        [Required]
        public HFTModel HFT { get; set; }

        [Required]
        public PFHdModel PFHd_max { get; set; }
    }
}
