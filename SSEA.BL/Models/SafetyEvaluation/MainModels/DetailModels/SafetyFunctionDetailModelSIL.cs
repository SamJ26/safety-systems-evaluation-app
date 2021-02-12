using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class SafetyFunctionDetailModelSIL : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public TypeOfFunctionModel TypeOfFunction { get; set; }

        [Required]
        public EvaluationMethodModel EvaluationMethod { get; set; }

        public PFHdModel SILCL { get; set; }
        public PFHdModel SIL_result { get; set; }
        public SeModel Se { get; set; }
        public FrModel Fr { get; set; }
        public PrModel Pr { get; set; }
        public AvModel Av { get; set; }

        public ICollection<SafetyFunctionSubsystemModel> SafetyFunctionSubsystems { get; set; }

        // public State CurrentState { get; set; }
    }
}
