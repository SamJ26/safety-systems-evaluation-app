using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class MachineNormModel : ModelBase
    {
        public int MachineId { get; set; }
        public int NormId { get; set; }
    }
}
