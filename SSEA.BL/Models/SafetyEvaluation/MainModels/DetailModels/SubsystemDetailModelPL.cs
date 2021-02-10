using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SubsystemDetailModelPL : ExtendedModelBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        public bool CCF_valid { get; set; }

        [Required]
        public TypeOfSubsystemModel TypeOfSubsystem { get; set; }

        [Required]
        public CategoryModel Category { get; set; }

        public MTTFdModel MTTFd_result { get; set; }
        public DCModel DC_result { get; set; }
        public PLModel PL_result { get; set; }

        public ICollection<SafetyFunctionSubsystemModel> SafetyFunctionSubsystems { get; set; }
        public ICollection<ElementDetailModelPL> Elements { get; set; }
        public ICollection<SubsystemCCFModel> SubsystemCCFs { get; set; }

        // public State CurrentState { get; set; }
    }
}
