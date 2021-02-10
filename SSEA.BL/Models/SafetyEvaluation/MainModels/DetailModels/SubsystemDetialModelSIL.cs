using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetialModelSIL : ExtendedModelBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        public double T1 { get; set; }
        public double T2 { get; set; }
        public double SFF_result { get; set; }

        [Required]
        public TypeOfSubsystemModel TypeOfSubsystem { get; set; }

        [Required]
        public ArchitectureModel Architecture { get; set; }

        public HFTModel HFT { get; set; }
        public PFHdModel PFHd_result { get; set; }
        public CFFModel CFF { get; set; }

        public ICollection<SafetyFunctionSubsystemModel> SafetyFunctionSubsystems { get; set; }
        public ICollection<ElementDetailModelSIL> Elements { get; set; }
        public ICollection<SubsystemCCFModel> SubsystemCCFs { get; set; }

        // public State CurrentState { get; set; }
    }
}
