using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfSubsystemModel : ModelBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
