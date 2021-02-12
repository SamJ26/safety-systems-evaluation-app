using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfFunctionModel : ModelBase
    {
        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
