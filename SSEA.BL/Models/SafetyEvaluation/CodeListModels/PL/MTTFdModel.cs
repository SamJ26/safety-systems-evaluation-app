using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class MTTFdModel : ModelBase
    {
        [Required]
        [StringLength(10)]
        public string Value { get; set; }

        public short Min { get; set; }
        public short Max { get; set; }
    }
}
