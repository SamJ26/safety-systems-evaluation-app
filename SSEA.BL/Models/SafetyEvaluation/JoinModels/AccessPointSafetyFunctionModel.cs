using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.JoinModels
{
    public class AccessPointSafetyFunctionModel : ModelBase
    {
        public int AccessPointId { get; set; }
        public int SafetyFunctionId { get; set; }
    }
}
