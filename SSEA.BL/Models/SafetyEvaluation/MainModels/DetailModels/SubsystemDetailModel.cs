using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public abstract class SubsystemDetailModel : ExtendedModelBase
    {
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public TypeOfSubsystemModel TypeOfSubsystem { get; set; }

        [Required]
        public OperationPrincipleModel OperationPrinciple { get; set; }

        public HashSet<CCFModel> SelectedCCFs { get; set; }
    }
}
