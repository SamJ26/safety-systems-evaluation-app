using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class PModel : ModelBase
    {
        [Required]
        [StringLength(2)]
        public string Value { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
    }
}
