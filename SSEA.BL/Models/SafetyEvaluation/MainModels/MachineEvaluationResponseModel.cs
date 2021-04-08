using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels
{
    public class MachineEvaluationResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TypeOfLogicModel Logic { get; set; }
    }
}
