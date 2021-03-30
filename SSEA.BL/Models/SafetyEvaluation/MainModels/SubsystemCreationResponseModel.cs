using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels
{
    public class SubsystemCreationResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int SubsystemId { get; set; }
    }
}
