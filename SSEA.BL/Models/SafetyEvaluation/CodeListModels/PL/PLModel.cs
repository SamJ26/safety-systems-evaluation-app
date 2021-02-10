using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class PLModel : ModelBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }
    }
}
