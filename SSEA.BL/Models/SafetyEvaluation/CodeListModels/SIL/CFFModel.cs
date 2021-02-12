using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class CFFModel : ModelBase
    {
        public short CCF_min { get; set; }
        public short CCF_max { get; set; }
        public double Beta { get; set; }
    }
}
