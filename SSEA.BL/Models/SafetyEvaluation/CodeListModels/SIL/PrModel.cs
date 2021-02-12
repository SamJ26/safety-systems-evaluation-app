using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PrModel : ModelBase
    {
        [StringLength(50)]
        public string Description { get; set; }

        public short Value { get; set; }
    }
}
