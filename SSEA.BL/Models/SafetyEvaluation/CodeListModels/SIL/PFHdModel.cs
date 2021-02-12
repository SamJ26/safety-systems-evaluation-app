using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PFHdModel : ModelBase
    {
        [Required]
        [StringLength(20)]
        public string Label { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}
