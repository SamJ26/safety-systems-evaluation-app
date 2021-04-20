using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public abstract class SafetyFunctionDetailModel : ExtendedModelBase
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool UsedOnMachine { get; set; }

        [Required]
        public TypeOfFunctionModel TypeOfFunction { get; set; }

        [Required]
        public EvaluationMethodModel EvaluationMethod { get; set; }
    }
}
