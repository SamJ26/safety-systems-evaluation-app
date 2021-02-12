using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class SafetyFunctionSubsystemModel : ModelBase
    {
        public int SafetyFunctionId { get; set; }
        public int SubsystemId { get; set; }
    }
}
