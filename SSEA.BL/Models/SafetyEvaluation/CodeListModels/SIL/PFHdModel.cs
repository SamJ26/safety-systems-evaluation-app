using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class PFHdModel : CodeListModelBase
    {
        public short ValueSIL { get; set; }
        public float MinPFHd { get; set; }
        public float MaxPFHd { get; set; }
    }
}
