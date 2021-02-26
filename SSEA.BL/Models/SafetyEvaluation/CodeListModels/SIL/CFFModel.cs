using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class CFFModel : CodeListModelBase
    {
        public short MinCCF { get; set; }
        public short MaxCCF { get; set; }
        public double Beta { get; set; }
    }
}
