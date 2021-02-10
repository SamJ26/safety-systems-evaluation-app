using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class SFFModel : ModelBase
    {
        [Required]
        [StringLength(100)]
        public string ComponentName { get; set; }

        [StringLength(100)]
        public string FailureMode { get; set; }

        public uint Value { get; set; }
    }
}
