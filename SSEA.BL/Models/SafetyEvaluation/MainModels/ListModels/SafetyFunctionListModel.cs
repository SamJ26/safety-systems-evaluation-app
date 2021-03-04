using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class SafetyFunctionListModel : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public TypeOfFunctionModel TypeOfFunction { get; set; }
        public EvaluationMethodModel EvaluationMethod { get; set; }

        // public State CurrentState { get; set; }
    }
}
